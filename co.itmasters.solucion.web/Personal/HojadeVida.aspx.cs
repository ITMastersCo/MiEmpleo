using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using co.itmasters.solucion.web.Code;
using co.itmasters.solucion.web.PersonaService;
using co.itmasters.solucion.web.Components_UI;
using co.itmasters.solucion.vo;
using System.IO;
using System.Web.Services;
using System.Web;


namespace co.itmasters.solucion.web.Personal
{
    public partial class HojadeVida : PageBase
    {
        private CargaCombos _carga = new CargaCombos();
        private PersonaServiceClient _ActoresService;
        private UserVO user;
        private List<Control> tags = new List<Control>();
        private List<Label> tagsNames = new List<Label>();
        private List<Label> tagsId = new List<Label>();
        private List<Label> tagsIdPersona = new List<Label>();
        public delegate void ExternalFunctionAccept();
        public event ExternalFunctionAccept OnSubmitAccept;
        public ExternalFunctionAccept FunctionAccept { get; set; }
        public string MODALPERSONALINFO { get; set; }
        public string MODALCLOSE { get; set; }
        public string MODALACADEMIA { get; set; }
        public string MODALEXPERIENCIA { get; set; }
        public string MODALELIMINARACADEMIA { get; set; }
        public string MODALELIMINAREXPERIENCIA { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            user = ((UserVO)Session["UsuarioAutenticado"]);
            Master.OcultarBanda();
            PersonaVO persona = GetPersona();
            MODALPERSONALINFO = $"showModal('{formPersonalInfo.ClientID}')";
            MODALACADEMIA = $"showModal('{formEstudios.ClientID}')";
            MODALEXPERIENCIA = $"showModal('{formExperiencias.ClientID}')";
            MODALELIMINARACADEMIA = $"showModal('{messageEliminarEstudios.ClientID}')";
            MODALELIMINAREXPERIENCIA = $"showModal('{messageEliminarExperiencia.ClientID}')";
            MODALCLOSE = $"CloseModal()";
            if (!IsPostBack)
            {
                DataBind();
                CargarCombos();
                SetFormPersoalInfo(persona);
                grdInsertAcademia(persona.Academia);
                grdInsertExperiencia(persona.Experiencia);
                FillSkillList();
                ShowSkills(persona);
                ShowPersonalInfo(persona);
                validatePersonalInfo(persona);
            }


        }
        
        protected void CargarCombos()
        {
            _carga.Cargar(cmbSkill, TipoCombo.CMBPERSONAAPTITUD);
        }
        protected void grdInsertAcademia(List<PersonaAcademiaVO> academia)
        {
            grdPersonaAcademia.DataSource = academia;
            grdPersonaAcademia.DataBind();

        }
        protected void grdInsertExperiencia(List<PersonaExperienciaVO> experiencia)
        {
            grdPersonaExperienca.DataSource = experiencia;
            grdPersonaExperienca.DataBind();

        }
        protected void FillSkillList()
        {
            //Etiquetas
            //Exixten 10 se Renderizan 5

            tags.Add(tagSkill1);
            tags.Add(tagSkill2);
            tags.Add(tagSkill3);
            tags.Add(tagSkill4);
            tags.Add(tagSkill5);
            //tags.Add(tagSkill6);
            //tags.Add(tagSkill7);
            //tags.Add(tagSkill8);
            //tags.Add(tagSkill9);
            //tags.Add(tagSkill10);
            tagsNames.Add(nameTagSkill);
            tagsNames.Add(nameTagSkill2);
            tagsNames.Add(nameTagSkill3);
            tagsNames.Add(nameTagSkill4);
            tagsNames.Add(nameTagSkill5);
            //tagsNames.Add(nameTagSkill6);
            //tagsNames.Add(nameTagSkill7);
            //tagsNames.Add(nameTagSkill8);
            //tagsNames.Add(nameTagSkill9);
            //tagsNames.Add(nameTagSkill10);
            tagsId.Add(lblIdAptitud1);
            tagsId.Add(lblIdAptitud2);
            tagsId.Add(lblIdAptitud3);
            tagsId.Add(lblIdAptitud4);
            tagsId.Add(lblIdAptitud5);

            tagsIdPersona.Add(lblIdPersonaAptitud1);
            tagsIdPersona.Add(lblIdPersonaAptitud2);
            tagsIdPersona.Add(lblIdPersonaAptitud3);
            tagsIdPersona.Add(lblIdPersonaAptitud4);
            tagsIdPersona.Add(lblIdPersonaAptitud5);
        }
        protected void AddTag(Control control)
        {
            ulSkills.Controls.Add(control);
        }
        protected void RemoveTag(Control tag, Label tagName, string tagId, string tagIdPersona)
        {
            tag.Visible = false;
            tagName.Text = "";

            PersonaAptitudVO newAptitud = new PersonaAptitudVO();
            newAptitud.typeModify = TipoConsulta.MODIFY_DELETE;
            newAptitud.idUsuario = user.IdUsuario;
            newAptitud.idAptitud = Convert.ToInt32(tagId);
            newAptitud.idPersona = GetPersona().idPersona;
            newAptitud.idPersonaAptitud = Convert.ToInt32(tagIdPersona);

            ModifyAptitud(newAptitud);
            ShowSkills(GetPersona());
        }
        private PersonaVO GetPersona()
        {
            PersonaVO personaVo = new PersonaVO();
            try
            {
                personaVo.idUsuario = user.IdUsuario;
                _ActoresService = new PersonaServiceClient();
                PersonaVO persona = _ActoresService.Buscar_Persona(personaVo);
                _ActoresService.Close();
                return persona;

            }
            catch (Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);
                return null;
            }


        }
        private void ShowPersonalInfo(PersonaVO persona)
        {
            wrpPersonalInfo.ID = persona.idPersona.ToString();
            if (user.Avatar != "")
            {
                imgAvatar.Src = $".{user.Avatar}";
            }
            else
            {
                imgAvatar.Src = "../Images/AvatarDefault.png";
            }
            userName.InnerText = $"{persona.nomPersona} {persona.apePersona}";
            userEmail.Text = persona.correoElectronico;
            userPhone.Text = persona.telefono;
            userHousingAddress.Text = persona.ciudadResidencia;
            lblRutaAvatar.Text = user.Avatar;

            ShowDescription(persona);


            ShowAttachments();

           

        }
        protected void validatePersonalInfo(PersonaVO persona) {

            if (persona.nomPersona == ""
               || persona.apePersona == ""
               || persona.telefono == ""
               || persona.ciudadResidencia == "")
            {
                modalSinDatosBasicos.Style["display"] = "flex";
                modalSinDatosBasicos.Visible = true;
            }
            else
            {
                modalSinDatosBasicos.Style["display"] = "none";
                modalSinDatosBasicos.Visible = false;
            }
        }


        private void ShowDescription(PersonaVO persona)
        {
            txtPerfil.Text = persona.perfil;
            txtPerfil.Attributes.Add("readonly", "");
        }
        private void ShowSkills(PersonaVO persona)
        {
            List<PersonaAptitudVO> skillList = persona.Aptitud;


            for (int i = 0; i < skillList.Count && i < tags.Count; i++)
            {
                if (skillList[i] != null)
                {
                    tags[i].Visible = true;
                    tagsNames[i].Text = skillList[i].nomAptitud;
                    tagsId[i].Text = skillList[i].idAptitud.ToString();
                    tagsIdPersona[i].Text = skillList[i].idPersonaAptitud.ToString();
                }

            }
        }
        private void ShowAttachments()
        {
            fileUploadProfile.Visible = true;
        }
        private void EditarExperiencia(string id, string idPersona, string idUsuario)
        {



            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", MODALEXPERIENCIA, true);
        }
        private void DeleteExperience()
        {

        }
        private UserControlBuildForm BuildFormPersonalInfo(PersonaVO persona)
        {

            // Calcular la fecha mínima permitida (mayor a 18 años)
            DateTime fechaActual = DateTime.Now;
            DateTime fechaMinimaMayorEdad = fechaActual.AddYears(-18);

            UserControlBuildForm ucFormPersonalInfo = (UserControlBuildForm)LoadControl("~/Components_UI/UserControlBuildForm.ascx");

            ucFormPersonalInfo.AddRow("Tipo de Identificación", "dropdown-label", cmb: TipoCombo.CMBTIPIDENTIFICACION, inputValue: persona.idTipoIde.ToString());
            ucFormPersonalInfo.AddRow("Número de identificación ", "label", persona.numeroIde.ToString());
            ucFormPersonalInfo.AddRow("Correo Electronico", "label", persona.correoElectronico);
            ucFormPersonalInfo.AddRow("Nombres", "text", persona.nomPersona);
            ucFormPersonalInfo.AddRow("Apellidos", "text", persona.apePersona);
            ucFormPersonalInfo.AddRow("Sexo", "dropdown", inputValue: persona.idSexo.ToString(), cmb: TipoCombo.CMBSEXO);

            ucFormPersonalInfo.AddRow("Fecha de Nacimiento", "date", persona.fechaNac.ToString(),
                max: fechaMinimaMayorEdad
                );

            ucFormPersonalInfo.AddRow("País de nacimiento", "dropdown",
                inputValue: persona.idCiudadNac.ToString().Substring(0, 3),
                cmb: TipoCombo.CMBPAIS);

            ucFormPersonalInfo.AddRow("Departamento de nacimiento", "dropdown",
                inputValue: persona.idCiudadNac.ToString().Substring(0, 5),
                cmb: TipoCombo.CMBDEPRTAMENTO,
                cmbFiltro: persona.idCiudadNac.ToString().Substring(0, 3));

            ucFormPersonalInfo.AddRow("Municipio de nacimiento", "dropdown",
                inputValue: persona.idCiudadNac.ToString(),
                cmb: TipoCombo.CMBPROVINCIA,
                cmbFiltro: persona.idCiudadNac.ToString().Substring(0, 5));

            ucFormPersonalInfo.AddRow("Numero Telefonico", "number", persona.telefono.ToString());
            ucFormPersonalInfo.AddRow("País de residencia", "dropdown",
                inputValue: persona.idCiudadResidencia.ToString().Substring(0, 3),
                cmb: TipoCombo.CMBPAIS);

            ucFormPersonalInfo.AddRow("Departamento de residencia", "dropdown",
                inputValue: persona.idCiudadResidencia.ToString().Substring(0, 5),
                cmb: TipoCombo.CMBDEPRTAMENTO,
                cmbFiltro: persona.idCiudadResidencia.ToString().Substring(0, 3));

            ucFormPersonalInfo.AddRow("Municipio de residencia", "dropdown", inputValue: persona.idCiudadResidencia.ToString(), cmb: TipoCombo.CMBPROVINCIA, cmbFiltro: persona.idCiudadResidencia.ToString().Substring(0, 5));

            return ucFormPersonalInfo;
        }
        private void SetFormPersoalInfo(PersonaVO persona)
        {

            lblIdPersona.Text = persona.idPersona.ToString();
            _carga.Cargar(cmbTipoIdentificacion, TipoCombo.CMBTIPIDENTIFICACION);
            cmbTipoIdentificacion.SelectedValue = persona.idTipoIde.ToString();
            cmbTipoIdentificacion.Enabled = false;
            txtNumeroIdentificacion.Text = persona.numeroIde.ToString();
            txtCorreoElectronico.Text = persona.correoElectronico;
            txtNombres.Text = persona.nomPersona;
            txtApellidos.Text = persona.apePersona;
            _carga.Cargar(cmbSexo, TipoCombo.CMBSEXO);
            cmbSexo.SelectedValue = persona.idSexo.ToString();
            DateTime fechaActual = DateTime.Now;
            DateTime fechaMinimaMayorEdad = fechaActual.AddYears(-18);
            string dateMax = String.Format("{0:yyyy-MM-dd}", fechaMinimaMayorEdad);
            txtFechaNacimiento.Attributes["max"] = dateMax.ToString();
            DateTime dateconvert = Convert.ToDateTime(persona.fechaNac);
            string dateValue = String.Format("{0:yyyy-MM-dd}", dateconvert);
            txtFechaNacimiento.Attributes["value"] = dateValue.ToString();
            txtNumeroTelefonico.Text = persona.telefono.ToString();
            _carga.Cargar(cmbPaisResidencia, TipoCombo.CMBPAIS);
            if (persona.idCiudadResidencia != null)
            {
                cmbPaisResidencia.SelectedValue = persona.idCiudadResidencia.ToString().Substring(0, 3);
                _carga.Cargar(cmbDepartamentoResidencia, TipoCombo.CMBDEPRTAMENTO, cmbPaisResidencia.SelectedValue);
                cmbDepartamentoResidencia.SelectedValue = persona.idCiudadResidencia.ToString().Substring(0, 5);
                _carga.Cargar(cmbMunicipioResidencia, TipoCombo.CMBPROVINCIA, cmbDepartamentoResidencia.SelectedValue);
                cmbMunicipioResidencia.SelectedValue = persona.idCiudadResidencia.ToString();
            }
            else
            {
                _carga.CargarVacio(cmbDepartamentoResidencia);
                _carga.CargarVacio(cmbMunicipioResidencia);
            }

            _carga.Cargar(cmbPaisNacimiento, TipoCombo.CMBPAIS);
            if (persona.idCiudadNac != null)
            {
                cmbPaisNacimiento.SelectedValue = persona.idCiudadNac.ToString().Substring(0, 3);
                _carga.Cargar(cmbDepartamentoNacimiento, TipoCombo.CMBDEPRTAMENTO, cmbPaisNacimiento.SelectedValue);
                cmbDepartamentoNacimiento.SelectedValue = persona.idCiudadNac.ToString().Substring(0, 5);
                _carga.Cargar(cmbMunicipioNacimiento, TipoCombo.CMBPROVINCIA, cmbDepartamentoNacimiento.SelectedValue);
                cmbMunicipioNacimiento.SelectedValue = persona.idCiudadNac.ToString();

            }
            else
            {
                _carga.CargarVacio(cmbDepartamentoNacimiento);
                _carga.CargarVacio(cmbMunicipioNacimiento);
            }

        }
        private UserControl BuildFormExperience(PersonaExperienciaVO experiencia)
        {
            UserControlBuildForm ucFormExperience = (UserControlBuildForm)LoadControl("~/Components_UI/UserControlBuildForm.ascx");

            ucFormExperience.AddRow("Nombre del Cargo", "text", inputValue: experiencia.nomCargo);
            ucFormExperience.AddRow("Perfil Profesional", "textarea", inputValue: experiencia.desCargo);
            ucFormExperience.AddRow("Pais", "dropdown", inputValue: experiencia.idCiudadCargo.ToString().Substring(0, 3),
                cmb: TipoCombo.CMBPAIS
                );
            ucFormExperience.AddRow("Departamento", "dropdown",
                inputValue: experiencia.idCiudadCargo.ToString().Substring(0, 5),
                cmb: TipoCombo.CMBDEPRTAMENTO,
                cmbFiltro: experiencia.idCiudadCargo.ToString().Substring(0, 3)
                );
            ucFormExperience.AddRow("Municipio o Localidad", "dropdown",
                inputValue: experiencia.idCiudadCargo.ToString(),
                cmb: TipoCombo.CMBPROVINCIA,
                cmbFiltro: experiencia.idCiudadCargo.ToString().Substring(0, 5)
                );
            ucFormExperience.AddRow("Nivel Educativo Relacionado al Cargo", "dropdown",
                inputValue: experiencia.idNivelEducativo,
                cmb: TipoCombo.CMBNIVELEDUCATIVO
                );
            ucFormExperience.AddRow("Ocupación Relacionada al Cargo", "dropdown",
                inputValue: experiencia.idOcupacion,
                cmb: TipoCombo.CMBEDUCACIONOCUPACION,
                cmbFiltro: experiencia.idNivelEducativo.ToString()
                );
            ucFormExperience.AddRow("Fecha Inicio", "date", inputValue: experiencia.fechaIniCargo,
                max: DateTime.Now
                );
            ucFormExperience.AddRow("Fecha Fin", "date", inputValue: experiencia.fechaFinCargo,
                max: DateTime.Now
                );
            ucFormExperience.AddRow("Total Tiempo de Experiencia Laboral", "number", inputValue: experiencia.tiempoCargo);




            return ucFormExperience;
        }
        private string GetStudyIcon()
        {
            return @"
                <svg xmlns='http://www.w3.org/2000/svg' class='h-6 w-6' fill='none' viewBox='0 0 24 24' stroke='currentColor'>
                    <path d='M12 14l9-5-9-5-9 5 9 5z' />
                    <path d='M12 14l6.16-3.422a12.083 12.083 0 01.665 6.479A11.952 11.952 0 0012 20.055a11.952 11.952 0 00-6.824-2.998 12.078 12.078 0 01.665-6.479L12 14z' />
                    <path stroke-linecap='round' stroke-linejoin='round' d='M12 14l9-5-9-5-9 5 9 5zm0 0l6.16-3.422a12.083 12.083 0 01.665 6.479A11.952 11.952 0 0012 20.055a11.952 11.952 0 00-6.824-2.998 12.078 12.078 0 01.665-6.479L12 14zm-4 6v-7.5l4-2.222' />
                </svg>
             ";
        }
        private string GetExperienceIcon()
        {
            return @"
               <svg xmlns=""http://www.w3.org/2000/svg"" fill=""none"" viewBox=""0 0 24 24"" stroke-width=""1.5"" stroke=""currentColor"" class=""w-6 h-6"">
                <path stroke-linecap=""round"" stroke-linejoin=""round"" d=""M20.25 14.15v4.25c0 1.094-.787 2.036-1.872 2.18-2.087.277-4.216.42-6.378.42s-4.291-.143-6.378-.42c-1.085-.144-1.872-1.086-1.872-2.18v-4.25m16.5 0a2.18 2.18 0 00.75-1.661V8.706c0-1.081-.768-2.015-1.837-2.175a48.114 48.114 0 00-3.413-.387m4.5 8.006c-.194.165-.42.295-.673.38A23.978 23.978 0 0112 15.75c-2.648 0-5.195-.429-7.577-1.22a2.016 2.016 0 01-.673-.38m0 0A2.18 2.18 0 013 12.489V8.706c0-1.081.768-2.015 1.837-2.175a48.111 48.111 0 013.413-.387m7.5 0V5.25A2.25 2.25 0 0013.5 3h-3a2.25 2.25 0 00-2.25 2.25v.894m7.5 0a48.667 48.667 0 00-7.5 0M12 12.75h.008v.008H12v-.008z"" />
                </svg>
             ";
        }
        private void ShowModal(ModalUserControl modal, UserControl content)
        {

            if (modal != null)
            {
                modal.SetContent(content);
                modal.Visible = true;

            }
            else
            {
                modal.Visible = true;
            }
        }
        private PersonaVO GetFormValuesPersonalInfo()
        {
            user = ((UserVO)Session["UsuarioAutenticado"]);
            try
            {

                PersonaVO newPersona = new PersonaVO();

                newPersona.idPersona = Convert.ToInt32(lblIdPersona.Text);
                newPersona.nomPersona = txtNombres.Text;
                newPersona.apePersona = txtApellidos.Text;
                newPersona.idSexo = Convert.ToInt32(cmbSexo.SelectedValue);
                newPersona.fechaNac = Convert.ToDateTime(txtFechaNacimiento.Text);
                newPersona.telefono = txtNumeroTelefonico.Text;
                newPersona.idCiudadResidencia = Convert.ToInt32(cmbMunicipioResidencia.SelectedValue);
                newPersona.idCiudadNac = Convert.ToInt32(cmbMunicipioNacimiento.SelectedValue);
                newPersona.perfil = txtPerfil.Text;
                newPersona.rutaAvatar = lblRutaAvatar.Text;

                return newPersona;
            }
            catch (Exception err)
            {

                Master.mostrarMensaje(err.Message, Master.ERROR);
                return null;
            }
        }
        private void ShowModalButton(Button button)
        {
            btnModalSubmmit.Visible = false;
            btnModalAvatarSubmit.Visible = false;
            btnModalEstudiosSubmit.Visible = false;
            btnModalExperienciaSubmit.Visible = false;
            btnModalEliminarEstudio.Visible = false;
            btnModalEliminarExperiencia.Visible = false;

            button.Visible = true;
            openModal.Update();

        }
        protected void btnUploadDocs_Click(object sender, EventArgs e)
        {

        }
        protected void btnEditPersonalInfo_Click(object sender, EventArgs e)
        {
       


        }
        protected void btnEditInformacionBasica_Click(object sender, EventArgs e)
        {
            Master.OcultarBanda();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", MODALPERSONALINFO, true);
            ShowModalButton(btnModalSubmmit);

        }
        protected void btnEditDescription_Click(object sender, EventArgs e)
        {
            txtPerfil.Attributes.Remove("disabled");
            txtPerfil.Attributes.Remove("readonly");
            txtPerfil.TextMode = TextBoxMode.MultiLine;
            txtPerfil.Attributes.Remove("class");
            txtPerfil.Attributes.Add("class", "text-normal w-100per text-area active cv-text-description");
            lblCuentaCaracteres.Visible = true;
            rfvPerfil.Visible = true;
            btnSaveDescription.Visible = true;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba",
                $"contadorTexto({txtPerfil.ClientID},{lblCuentaCaracteres.ClientID}, 2000)", true);
            

        }
        protected void btnSaveDescription_Click(object sender, EventArgs e)
        {
            PersonaVO data = GetFormValuesPersonalInfo();
            if (data != null)
                UpdatePersonalInfo(data);
            ShowDescription(GetPersona());
            txtPerfil.Attributes.Remove("class");
            txtPerfil.TextMode = TextBoxMode.SingleLine;
            txtPerfil.Attributes.Add("class", "text-normal w-100per input-label");
            btnSaveDescription.Visible = false;
            rfvPerfil.Visible = false;
            lblCuentaCaracteres.Visible = false;


        }
        protected void UpdatePersonalInfo(PersonaVO persona)
        {
            user = ((UserVO)Session["UsuarioAutenticado"]);
            try
            {
                PersonaVO registro = new PersonaVO();
                registro.idUsuario = Convert.ToInt32(user.IdUsuario);
                registro.idPersona = Convert.ToInt32(persona.idPersona);
                registro.perfil = persona.perfil;
                registro.rutaAvatar = persona.rutaAvatar;
                registro.nomPersona = persona.nomPersona;
                registro.apePersona = persona.apePersona;
                registro.idSexo = persona.idSexo;
                registro.fechaNac = persona.fechaNac;
                registro.idCiudadNac = persona.idCiudadNac;
                registro.telefono = persona.telefono;
                registro.idCiudadResidencia = persona.idCiudadResidencia;
                registro.idUsuario = user.IdUsuario;

                _ActoresService = new PersonaServiceClient();
                _ActoresService.PersonaDatosBasicos_Update(registro);
                _ActoresService.Close();


            }
            catch (Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);
            }
        }
        protected void btnModalSubmmit_Click(object sender, EventArgs e)
        {
            try
            {
                SubmitPersonalInfo();
                PersonaVO persona = GetPersona();
                validatePersonalInfo(persona);
                ShowPersonalInfo(persona);
            }
            catch (Exception err)
            {
                Master.mostrarMensaje($"Error al Actualizar, error: {err}", Master.ERROR);
            }
            UpdatePanelform.Update();

        }
        protected void SubmitPersonalInfo()
        {
            PersonaVO data = GetFormValuesPersonalInfo();
            Master.OcultarBanda();

            try
            {
                if (data != null)
                {
                    UpdatePersonalInfo(data);
                    Master.mostrarMensaje("Datos Actualizados Correctamente", Master.EXITO);
                }

            }
            catch (Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);
                throw;
            }
        }
        protected void btnModalEstudiosSubmit_Click(object sender, EventArgs e)
        {
            Master.OcultarBanda();
            try
            {
                PersonaAcademiaVO newAcademia = new PersonaAcademiaVO();

                newAcademia.idUsuario = user.IdUsuario;
                newAcademia.idPersonaAcademia = Convert.ToInt32(lblIdAcademia.Text);
                newAcademia.idPersona = Convert.ToInt32(lblIdPersonaAcademia.Text);
                newAcademia.idNivelEducativo = Convert.ToInt32(cmbNivelEducativoEstudio.SelectedValue);
                newAcademia.tituloFormacionAcademica = txtTituloEstudios.Text;
                newAcademia.nomInstitucion = txtInstitucionEstudios.Text;
                newAcademia.fechaFinFormacion = Convert.ToDateTime(txtFechaGraduacion.Text);
                newAcademia.idOcupacion = Convert.ToInt32(cmbOcupacionEstudio.SelectedValue);
                newAcademia.idCiudadFormacion = Convert.ToInt32(cmbMunicipioEstudios.SelectedValue);
                newAcademia.typeModify = lblTypeModifyAcademia.Text;

                _ActoresService = new PersonaServiceClient();
                _ActoresService.PersonaAcademia_Update(newAcademia);
                _ActoresService.Close();
                Master.mostrarMensaje("Informacion de Estudio actualizada correctamente", Master.EXITO);
                grdInsertAcademia(GetPersona().Academia);

            }
            catch (Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);
            }

            UpdatePanelform.Update();

        }

        protected void btnModalExperienciaSubmit_Click(object sender, EventArgs e)
        {


            Master.OcultarBanda();
            try
            {
                PersonaExperienciaVO newExperiencia = new PersonaExperienciaVO();

                newExperiencia.idUsuario = user.IdUsuario;
                newExperiencia.idPersonaExperiencia = Convert.ToInt32(lblIdExperiencia.Text);
                newExperiencia.idPersona = Convert.ToInt32(lblIdPersonaExperiencia.Text);
                newExperiencia.nomCargo = txtNombreCargo.Text;
                newExperiencia.idNivelEducativo = Convert.ToInt32(cmbNivelEducativoExperiencia.SelectedValue);
                newExperiencia.idOcupacion = Convert.ToInt32(cmbOcupacionExperiencia.SelectedValue);
                newExperiencia.idCiudadCargo = Convert.ToInt32(cmbMunicipioExperiencia.SelectedValue);
                newExperiencia.fechaIniCargo = Convert.ToDateTime(txtFechaIniExperiencia.Text);
                newExperiencia.fechaFinCargo = Convert.ToDateTime(txtFechaFinExperiencia.Text);
                newExperiencia.tiempoCargo = Convert.ToInt32(txtTiempoCargo.Text);
                newExperiencia.desCargo = txtPerfilProfecional.Text;
                newExperiencia.typeModify = lblTypeModifyExperiencia.Text;
                _ActoresService = new PersonaServiceClient();
                _ActoresService.PersonaExperiencia_Update(newExperiencia);
                _ActoresService.Close();
                Master.mostrarMensaje("Informacion de Experiencia laboral actualizada correctamente", Master.EXITO);
                grdInsertExperiencia(GetPersona().Experiencia);

            }
            catch (Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);
            }
            UpdatePanelform.Update();
        }
        protected void btnModalCancel_Click(object sender, EventArgs e)
        {

            UpdatePanelform.Update();
        }
        protected void btnRemoveFile_Click(object sender, EventArgs e)
        {
            previewFile.Attributes.CssStyle.Remove("hidden");
        }
        protected void btnRemoveSkill1_Click(object sender, EventArgs e)
        {
            RemoveTag(tagSkill1, nameTagSkill, lblIdAptitud1.Text, lblIdPersonaAptitud1.Text);
        }
        protected void btnRemoveSkill2_Click(object sender, EventArgs e)
        {
            RemoveTag(tagSkill2, nameTagSkill2, lblIdAptitud2.Text, lblIdPersonaAptitud2.Text);
        }
        protected void btnRemoveSkill3_Click(object sender, EventArgs e)
        {
            RemoveTag(tagSkill3, nameTagSkill3, lblIdAptitud3.Text, lblIdPersonaAptitud3.Text);
        }
        protected void btnRemoveSkill4_Click(object sender, EventArgs e)
        {
            RemoveTag(tagSkill4, nameTagSkill4, lblIdAptitud4.Text, lblIdPersonaAptitud4.Text);
        }
        protected void btnRemoveSkill5_Click(object sender, EventArgs e)
        {
            RemoveTag(tagSkill5, nameTagSkill5, lblIdAptitud5.Text, lblIdPersonaAptitud5.Text);
        }
        protected void btnRemoveSkill6_Click(object sender, EventArgs e)
        {
        }
        protected void btnRemoveSkill7_Click(object sender, EventArgs e)
        {
        }
        protected void btnRemoveSkill8_Click(object sender, EventArgs e)
        {
        }
        protected void btnRemoveSkill9_Click(object sender, EventArgs e)
        {
        }
        protected void btnRemoveSkill10_Click(object sender, EventArgs e)
        {
        }
        protected void btnAddSkill_Click(object sender, EventArgs e)
        {
            PersonaVO persona = GetPersona();
            if (persona.Aptitud.Count < 5 && cmbSkill.SelectedValue != "-1")
            {
                PersonaAptitudVO newAptitud = new PersonaAptitudVO();
                newAptitud.typeModify = TipoConsulta.MODIFY_INSERT;
                newAptitud.idUsuario = user.IdUsuario;
                newAptitud.idAptitud = Convert.ToInt32(cmbSkill.SelectedValue);
                newAptitud.idPersona = Convert.ToInt32(persona.idPersona);
                newAptitud.idPersonaAptitud = null;

                ModifyAptitud(newAptitud);
                FillSkillList();
                
                updSkill.Update();
                string contentCmbSkill = cmbSkill.SelectedItem.Text;

                


                for (int i = 0; i < tagsNames.Count; i++)
                {
                    if (tagsNames[i].Text == "" && tags[i].Visible == false && contentCmbSkill != "Seleccione un elemento")
                    {
                        tags[i].Visible = true;
                        tagsNames[i].Text = contentCmbSkill;
                        tagsId[i].Text = cmbSkill.SelectedValue;
                        break;
                    }

                }
                ShowSkills(GetPersona());
            }
            else
            {
                Master.mostrarMensaje("Maximo de habilidades alcanzado", Master.ERROR);
            }


        }
        private void ModifyAptitud(PersonaAptitudVO aptitud)
        {
            try
            {
                _ActoresService = new PersonaServiceClient();
                _ActoresService.PersonaAptitud_Update(aptitud);
                _ActoresService.Close();
            }
            catch (Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);
            }

        }
        protected void grdPersonaAcademia_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Master.OcultarBanda();
            Int32 index = Convert.ToInt32(e.CommandArgument) % grdPersonaAcademia.PageSize;
            GridViewRow row = grdPersonaAcademia.Rows[index];
            switch (e.CommandName.ToUpper())
            {
                case TipoConsulta.MODIFY_UPDATE:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", MODALACADEMIA, true);
                    lblTypeModifyAcademia.Text = TipoConsulta.MODIFY_UPDATE;
                    lblIdAcademia.Text = Convert.ToString(((Label)row.FindControl("lblidAcademia")).Text);
                    lblIdPersonaAcademia.Text = Convert.ToString(((Label)row.FindControl("lblidPersonaAcademia")).Text);
                    _carga.Cargar(cmbPaisEstudios, TipoCombo.CMBPAIS);
                    cmbPaisEstudios.SelectedValue = Convert.ToString(((Label)row.FindControl("lblidCiudadFormacion")).Text).Substring(0, 3);
                    _carga.Cargar(cmbDepartamentoEstudios, TipoCombo.CMBDEPRTAMENTO, cmbPaisEstudios.SelectedValue);
                    cmbDepartamentoEstudios.SelectedValue = Convert.ToString(((Label)row.FindControl("lblidCiudadFormacion")).Text).Substring(0, 5);
                    _carga.Cargar(cmbMunicipioEstudios, TipoCombo.CMBPROVINCIA, cmbDepartamentoEstudios.SelectedValue);
                    cmbMunicipioEstudios.SelectedValue = Convert.ToString(((Label)row.FindControl("lblidCiudadFormacion")).Text);
                    _carga.Cargar(cmbNivelEducativoEstudio, TipoCombo.CMBNIVELEDUCATIVO);
                    cmbNivelEducativoEstudio.SelectedValue = Convert.ToString(((Label)row.FindControl("lblidNivelEducativo")).Text);
                    _carga.Cargar(cmbOcupacionEstudio, TipoCombo.CMBEDUCACIONOCUPACION, Convert.ToString(((Label)row.FindControl("lblidNivelEducativo")).Text));
                    cmbOcupacionEstudio.SelectedValue = Convert.ToString(((Label)row.FindControl("lblidOcupacion")).Text);
                    txtTituloEstudios.Text = Convert.ToString(((Label)row.FindControl("grdEstudioTitle")).Text);
                    txtInstitucionEstudios.Text = Convert.ToString(((Label)row.FindControl("lblnomInstitucion")).Text);
                    string dateValue = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(((Label)row.FindControl("lblfechaFinFormacion")).Text));
                    txtFechaGraduacion.Attributes["value"] = dateValue.ToString();
                    ShowModalButton(btnModalEstudiosSubmit);
                    break;
                case TipoConsulta.MODIFY_DELETE:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", MODALELIMINARACADEMIA, true);
                    ShowModalButton(btnModalEliminarEstudio);
                    lblIdAcademiaEliminar.Text = Convert.ToString(((Label)row.FindControl("lblidAcademia")).Text);
                    lblIdPersonaAcademiaEliminar.Text = Convert.ToString(((Label)row.FindControl("lblidPersonaAcademia")).Text);
                    break;
            }





        }
        protected void grdPersonaExperienca_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Master.OcultarBanda();
            Int32 index = Convert.ToInt32(e.CommandArgument) % grdPersonaExperienca.PageSize;
            GridViewRow row = grdPersonaExperienca.Rows[index];
            switch (e.CommandName.ToUpper())
            {
                case TipoConsulta.MODIFY_UPDATE:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", MODALEXPERIENCIA, true);
                    lblTypeModifyExperiencia.Text = TipoConsulta.MODIFY_UPDATE;
                    lblIdExperiencia.Text = Convert.ToString(((Label)row.FindControl("lblidExperiencia")).Text);
                    lblIdPersonaExperiencia.Text = Convert.ToString(((Label)row.FindControl("lblidPersonaExperiencia")).Text);
                    txtNombreCargo.Text = Convert.ToString(((Label)row.FindControl("lblnomCargo")).Text);
                    txtPerfilProfecional.Text = Convert.ToString(((Label)row.FindControl("lbldesCargo")).Text);
                    _carga.Cargar(cmbPaisExperiencia, TipoCombo.CMBPAIS);
                    cmbPaisExperiencia.SelectedValue = Convert.ToString(((Label)row.FindControl("lblidCiudadCargo")).Text).Substring(0, 3);
                    _carga.Cargar(cmbDepartamentoExperiencia, TipoCombo.CMBDEPRTAMENTO, cmbPaisExperiencia.SelectedValue);
                    cmbDepartamentoExperiencia.SelectedValue = Convert.ToString(((Label)row.FindControl("lblidCiudadCargo")).Text).Substring(0, 5);
                    _carga.Cargar(cmbMunicipioExperiencia, TipoCombo.CMBPROVINCIA, cmbDepartamentoExperiencia.SelectedValue);
                    cmbMunicipioExperiencia.SelectedValue = Convert.ToString(((Label)row.FindControl("lblidCiudadCargo")).Text);
                    _carga.Cargar(cmbNivelEducativoExperiencia, TipoCombo.CMBNIVELEDUCATIVO);
                    cmbNivelEducativoExperiencia.SelectedValue = Convert.ToString(((Label)row.FindControl("lblidNivelEducativoExperiencia")).Text);
                    _carga.Cargar(cmbOcupacionExperiencia, TipoCombo.CMBEDUCACIONOCUPACION, Convert.ToString(((Label)row.FindControl("lblidNivelEducativoExperiencia")).Text));
                    cmbOcupacionExperiencia.SelectedValue = Convert.ToString(((Label)row.FindControl("lblidOcupacionExperiencia")).Text);
                    txtTiempoCargo.Text = Convert.ToString(((Label)row.FindControl("lbltiempoCargo")).Text);
                    string dateValueIni = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(((Label)row.FindControl("lblfechaIniCargo")).Text));
                    txtFechaIniExperiencia.Attributes["value"] = dateValueIni.ToString();
                    string dateValueFin = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(((Label)row.FindControl("lblfechaFinCargo")).Text));
                    txtFechaFinExperiencia.Attributes["value"] = dateValueFin.ToString();
                    ShowModalButton(btnModalExperienciaSubmit);
                    break;
                case TipoConsulta.MODIFY_DELETE:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", MODALELIMINAREXPERIENCIA, true);
                    ShowModalButton(btnModalEliminarExperiencia);
                    lblIdExperienciaEliminar.Text = Convert.ToString(((Label)row.FindControl("lblidExperiencia")).Text);
                    lblIdPersonaExperienciaEliminar.Text = Convert.ToString(((Label)row.FindControl("lblidPersonaExperiencia")).Text);

                    break;

            }
        }
        protected void cmbPaisResidencia_SelectedIndexChanged(object sender, EventArgs e)
        {

            _carga.Cargar(cmbDepartamentoResidencia, TipoCombo.CMBDEPRTAMENTO, cmbPaisResidencia.SelectedValue);
            _carga.CargarVacio(cmbMunicipioResidencia);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", MODALPERSONALINFO, true);


        }
        protected void cmbDepartamentoResidencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            _carga.Cargar(cmbMunicipioResidencia, TipoCombo.CMBPROVINCIA, cmbDepartamentoResidencia.SelectedValue);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", MODALPERSONALINFO, true);
        }
        protected void cmbMunicipioResidencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", MODALPERSONALINFO, true);
        }
        protected void cmbPaisNacimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            _carga.Cargar(cmbDepartamentoNacimiento, TipoCombo.CMBDEPRTAMENTO, cmbPaisNacimiento.SelectedValue);
            _carga.CargarVacio(cmbMunicipioNacimiento);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", MODALPERSONALINFO, true);
        }
        protected void cmbDepartamentoNacimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            _carga.Cargar(cmbMunicipioNacimiento, TipoCombo.CMBPROVINCIA, cmbDepartamentoNacimiento.SelectedValue);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", MODALPERSONALINFO, true);
        }
        protected void cmbMunicipioNacimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", MODALPERSONALINFO, true);
        }

        protected void cmbPaisEstudios_SelectedIndexChanged(object sender, EventArgs e)
        {
            _carga.Cargar(cmbDepartamentoEstudios, TipoCombo.CMBDEPRTAMENTO, cmbPaisEstudios.SelectedValue);
            _carga.CargarVacio(cmbMunicipioEstudios);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", MODALACADEMIA, true);
        }
        protected void cmbDepartamentoEstudios_SelectedIndexChanged(object sender, EventArgs e)
        {
            _carga.Cargar(cmbMunicipioEstudios, TipoCombo.CMBPROVINCIA, cmbDepartamentoEstudios.SelectedValue);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", MODALACADEMIA, true);
        }
        protected void cmbMunicipioEstudios_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", MODALACADEMIA, true);
        }


        protected void cmbNivelEducativoEstudio_SelectedIndexChanged(object sender, EventArgs e)
        {
            _carga.Cargar(cmbOcupacionEstudio, TipoCombo.CMBEDUCACIONOCUPACION, cmbNivelEducativoEstudio.SelectedValue);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", MODALACADEMIA, true);
        }

        protected void cmbOcupacionEstudio_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", MODALACADEMIA, true);
        }




        protected void cmbPaisExperiencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            _carga.Cargar(cmbDepartamentoExperiencia, TipoCombo.CMBDEPRTAMENTO, cmbPaisExperiencia.SelectedValue);
            _carga.CargarVacio(cmbMunicipioExperiencia);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", MODALEXPERIENCIA, true);
        }

        protected void cmbDepartamentoExperiencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            _carga.Cargar(cmbMunicipioExperiencia, TipoCombo.CMBPROVINCIA, cmbDepartamentoExperiencia.SelectedValue);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", MODALEXPERIENCIA, true);
        }

        protected void cmbNivelEducativoExperiencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            _carga.Cargar(cmbOcupacionExperiencia, TipoCombo.CMBEDUCACIONOCUPACION, cmbNivelEducativoExperiencia.SelectedValue);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", MODALEXPERIENCIA, true);
        }

        protected void btnModalEliminarEstudio_Click(object sender, EventArgs e)
        {
            Master.OcultarBanda();
            try
            {
                PersonaAcademiaVO newAcademia = new PersonaAcademiaVO();

                newAcademia.idUsuario = user.IdUsuario;
                newAcademia.idPersonaAcademia = Convert.ToInt32(lblIdAcademiaEliminar.Text);
                newAcademia.idPersona = Convert.ToInt32(lblIdPersonaAcademiaEliminar.Text);
                newAcademia.typeModify = TipoConsulta.MODIFY_DELETE;
                _ActoresService = new PersonaServiceClient();
                _ActoresService.PersonaAcademia_Update(newAcademia);
                _ActoresService.Close();
                grdInsertAcademia(GetPersona().Academia);

                Master.mostrarMensaje("Informacion de estudio eliminada correctamente", Master.EXITO);

            }
            catch (Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);
            }
            UpdatePanelform.Update();
        }

        protected void btnModalEliminarExperiencia_Click(object sender, EventArgs e)
        {
            Master.OcultarBanda();
            try
            {
                PersonaExperienciaVO newExperiencia = new PersonaExperienciaVO();

                newExperiencia.idUsuario = user.IdUsuario;
                newExperiencia.idPersonaExperiencia = Convert.ToInt32(lblIdExperienciaEliminar.Text);
                newExperiencia.idPersona = Convert.ToInt32(lblIdPersonaExperienciaEliminar.Text);
                newExperiencia.typeModify = TipoConsulta.MODIFY_DELETE;
                _ActoresService = new PersonaServiceClient();
                _ActoresService.PersonaExperiencia_Update(newExperiencia);
                _ActoresService.Close();
                grdInsertExperiencia(GetPersona().Experiencia);
                Master.mostrarMensaje("Experiencia laboral eliminada correctamente", Master.EXITO);

            }
            catch (Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);
            }
            UpdatePanelform.Update();
        }

        protected void btnAddAcademia_Click(object sender, EventArgs e)
        {
            PersonaVO persona = GetPersona();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", MODALACADEMIA, true);
            lblTypeModifyAcademia.Text = TipoConsulta.MODIFY_INSERT;
            lblIdAcademia.Text = "0";
            lblIdPersonaAcademia.Text = persona.idPersona.ToString();
            _carga.Cargar(cmbPaisEstudios, TipoCombo.CMBPAIS);
            _carga.CargarVacio(cmbDepartamentoEstudios);
            _carga.CargarVacio(cmbMunicipioEstudios);
            _carga.Cargar(cmbNivelEducativoEstudio, TipoCombo.CMBNIVELEDUCATIVO);
            _carga.CargarVacio(cmbOcupacionEstudio);
            txtTituloEstudios.Text = null;
            txtInstitucionEstudios.Text = null;
            txtFechaGraduacion.Attributes["value"] = null;
            ShowModalButton(btnModalEstudiosSubmit);


        }
        protected void btnAddExperiencia_Click(object sender, EventArgs e)
        {
            PersonaVO persona = GetPersona();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", MODALEXPERIENCIA, true);
            lblTypeModifyExperiencia.Text = TipoConsulta.MODIFY_INSERT;
            lblIdExperiencia.Text = "0";
            lblIdPersonaExperiencia.Text = persona.idPersona.ToString(); ;
            txtNombreCargo.Text = null;
            txtPerfilProfecional.Text = null;
            _carga.Cargar(cmbPaisExperiencia, TipoCombo.CMBPAIS);
            _carga.CargarVacio(cmbDepartamentoExperiencia);
            _carga.CargarVacio(cmbMunicipioExperiencia);
            _carga.Cargar(cmbNivelEducativoExperiencia, TipoCombo.CMBNIVELEDUCATIVO);
            _carga.CargarVacio(cmbOcupacionExperiencia);
            cmbOcupacionExperiencia.SelectedValue = null;
            txtTiempoCargo.Text = null;
            txtFechaIniExperiencia.Text = null;
            txtFechaFinExperiencia.Text = null;
            ShowModalButton(btnModalExperienciaSubmit);

            
        }

        protected void btnModalAvatarSubmit_Click(object sender, EventArgs e)
        {
                Master.OcultarBanda();
                try
                {
                
                    if (fuAvatar.HasFile)
                    {

                        EmpresaVO _empresa = new EmpresaVO();
                        string filename = Path.GetFileName(fuAvatar.FileName);
                        FileInfo Info = new FileInfo(filename);
                        int size = (fuAvatar.FileBytes).Length;
                        if (Info.Extension == ".jpg" && size < 220000 || Info.Extension == ".JPG" && size < 220000)
                        {

                            if (!System.IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "/Fotos/" + "Candidatos"))
                            {
                                System.IO.Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "Fotos\\" + "\\Candidatos" + "\\");
                            }
                            fuAvatar.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory + "/Fotos/" + "\\Candidatos\\" + filename);
                            System.IO.File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "/Fotos/" + "\\Candidatos\\" + (txtNumeroIdentificacion.Text).TrimStart().TrimEnd() + ".jpg");
                            System.IO.File.Move(System.AppDomain.CurrentDomain.BaseDirectory + "/Fotos/" + "\\Candidatos\\" + filename, System.AppDomain.CurrentDomain.BaseDirectory + "/Fotos/" + "\\Candidatos\\" + (txtNumeroIdentificacion.Text).TrimStart().TrimEnd() + ".jpg");


                        PersonaVO data = GetFormValuesPersonalInfo();
                        data.rutaAvatar = $"./Fotos/Candidatos/{txtNumeroIdentificacion.Text}.jpg";
                        Master.OcultarBanda();

                        try
                        {
                            if (data != null)
                            {
                                UpdatePersonalInfo(data);
                                ShowPersonalInfo(GetPersona());
                                Master.mostrarMensaje("Datos Actualizados Correctamente", Master.EXITO);
                            }

                        }
                        catch (Exception err)
                        {
                            Master.mostrarMensaje(err.Message, Master.ERROR);
                            throw;
                        }
                    }
                        else
                        {
                            Master.mostrarMensaje("La foto no cumple con los parametros establecidos, debe ser formato jpg y no mayor a  200Kb", Master.ERROR);
                        }


                    }
                    else

                    {
                        Master.mostrarMensaje("Archivo no existe, por favor intente nuevamente.", Master.ERROR);
                    }
                }
                catch (Exception)
                {
                    Master.mostrarMensaje("Error cargando el archivo, por favor renombre el archivo de la fotografía.", Master.ERROR);
                }
                
        }




        protected void btnSubirAvatar_Click(object sender, EventArgs e)
        {
            Master.OcultarBanda();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", $"showModal('{messageAvatar.ClientID}')", true);
            ShowModalButton(btnModalAvatarSubmit);
        }
    }
};