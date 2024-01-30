using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using co.itmasters.solucion.web.Code;
using co.itmasters.solucion.web.OfertaService;
using co.itmasters.solucion.web.Components_UI;
using co.itmasters.solucion.vo;
using System.Web.Services;
using System.IO;
using co.itmasters.solucion.web.EmpresaService;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Win32;

namespace co.itmasters.solucion.web.Empresa
{
    public partial class PublicarOfertas : PageBase
    {
        private OfertaServiceClient _OfertaService;
        private EmpresaServiceClient _ActoresService;
        private UserVO user;
        private CargaCombos _carga = new CargaCombos();
        private List<Control> tags = new List<Control>();
        private List<Label> tagsNames = new List<Label>();



        protected void Page_Load(object sender, EventArgs e)
        {  
           
            if (!Page.IsPostBack)

            {
                user = ((UserVO)Session["UsuarioAutenticado"]);
                if (Request.QueryString["idOferta"] == null)
                {
                    ViewState["IdOferta"] = "0";
                    ViewState["Estado"] = "New";
                    this.cargarCombos();
                }
                else
                {
                    ViewState["IdOferta"] = Request.QueryString["idOferta"];
                    ViewState["Estado"] = Request.QueryString["estado"];
                    
                    
                    this.cargarCombos();
                    this.validaOferta();
                }
            this.CargaDatosBasicos();
            }
            this.FillList();


        }
        protected void cargarCombos()
        {
            _carga.Cargar(cmbTiempoExperiencia, TipoCombo.CMBTIEMPOEXPERIENCIA);
            _carga.Cargar(cmbNivelEstudiosRequeridos, TipoCombo.CMBNIVELEDUCATIVO);
            if (ViewState["IdOferta"].ToString() == "0")
            {
                _carga.CargarVacio(cmbOcupacion);
            }
            else
            {
                _carga.Cargar(cmbOcupacion, TipoCombo.CMBNIVELEDUCATIVO,cmbNivelEstudiosRequeridos.SelectedValue);
            }
                
            _carga.Cargar(cmbRangoSalarial, TipoCombo.CMBRANGOSALARIAL);
            _carga.Cargar(cmbModalidadEmpleo, TipoCombo.CMBMODALIDADEMPLEO);
            _carga.Cargar(cmbDepartamento, TipoCombo.CMBDEPRTAMENTO, ("170"));
            _carga.Cargar(cmbSectorEconomico, TipoCombo.CMBSECTORECONOMICO);

        }

        protected void FillList()
        {
            tags.Add(tagOcupacion1);
            tags.Add(tagOcupacion2);
            tags.Add(tagOcupacion3);
            tags.Add(tagOcupacion4);
            tags.Add(tagOcupacion5);
            tagsNames.Add(nameTagOcupacion);
            tagsNames.Add(nameTagOcupacion2);
            tagsNames.Add(nameTagOcupacion3);
            tagsNames.Add(nameTagOcupacion4);
            tagsNames.Add(nameTagOcupacion5);
        }
        protected void validaOferta()

        {
            try
            {
            Master.OcultarBanda();
            user = ((UserVO)Session["UsuarioAutenticado"]);
            string idOferta = ViewState["IdOferta"].ToString();
            string estado = ViewState["Estado"].ToString();
            OfertaVO oferta = new OfertaVO();
            oferta.idUsuario = user.IdUsuario;
            oferta.idOferta = Convert.ToInt32(idOferta);
            _OfertaService = new OfertaServiceClient();

            OfertaVO resultado = _OfertaService.TraeOfertaDetalle(oferta);
            if(resultado != null)
            {
                lblEstadoOferta.Text = resultado.estado;
                txtTituloVacante.Text = resultado.tituloVacante;
                txtDescripcionVacante.Text = resultado.descripcionVacante;
                cmbTiempoExperiencia.SelectedValue = resultado.tiempoExperiencia.ToString();
                txtCantidadVacantes.Text = resultado.cantidadVacantes.ToString();
                txtCargo.Text = resultado.cargo;
                txtFechaPublicacion.Text = resultado.fechaPublicacion.ToString().Substring(0, 10);
                txtFechaVencimiento.Text = resultado.fechaVencimiento.ToString().Substring(0, 10);
                cmbNivelEstudiosRequeridos.SelectedValue = resultado.idNivelEstudiosRequeridos.ToString();
                //nameTagOcupacion.Text = resultado.idOcupacion1.ToString();
                cmbRangoSalarial.SelectedValue = resultado.idRangoSalario.ToString();
                cmbModalidadEmpleo.SelectedValue = resultado.idModalidad.ToString();
                cmbDepartamento.SelectedValue = resultado.idMunicipioVacante.ToString();
                cmbDepartamento_SelectedIndexChanged(null,null);
                cmbMunicipio.SelectedValue = resultado.idCiudadVacante.ToString();
                cmbSectorEconomico.SelectedValue = resultado.idSectorEconomico.ToString();
                if (resultado.esConfidencial == true)
                    {
                       ChkConfidencial.Checked = true;
                    }
                else
                    {
                       ChkConfidencial.Checked = false;
                    }
                if (resultado.idOcupacion1 != null)
                {
                    idTagOcupacion.Text = resultado.idOcupacion1.ToString();
                    nameTagOcupacion.Text = resultado.nomOcupacion;
                    tagOcupacion1.Visible = true;
                }
                if (resultado.idOcupacion2 != null)
                {
                    idTagOcupacion2.Text = resultado.idOcupacion2.ToString();
                    nameTagOcupacion2.Text = resultado.nomOcupacion2;
                    tagOcupacion2.Visible = true;
                }
                if (resultado.idOcupacion3 != null)
                {
                    idTagOcupacion3.Text = resultado.idOcupacion3.ToString();
                    nameTagOcupacion3.Text = resultado.nomOcupacion3;
                    tagOcupacion3.Visible = true;
                }
                if (resultado.idOcupacion4 != null)
                {
                    idTagOcupacion4.Text = resultado.idOcupacion4.ToString();
                    nameTagOcupacion4.Text = resultado.nomOcupacion4;
                    tagOcupacion4.Visible = true;
                }
                if (resultado.idOcupacion5 != null)
                {
                    idTagOcupacion5.Text = resultado.idOcupacion5.ToString();
                    nameTagOcupacion5.Text = resultado.nomOcupacion5;
                    tagOcupacion5.Visible = true;
                }
                if (estado == "Editar")
                { if(resultado.estado !="RCH")
                        {
                            txtTituloVacante.ReadOnly = true;
                            txtDescripcionVacante.ReadOnly = true;
                            txtTituloVacante.Enabled = false;
                            txtDescripcionVacante.Enabled = false;
                        }
                    
                }
                else
                {
                    txtTituloVacante.ReadOnly = false;
                    txtDescripcionVacante.ReadOnly = false;
                    txtTituloVacante.Enabled = true;
                    txtDescripcionVacante.Enabled = true;
                }
                if (resultado.estado =="ACT")
                    {
                        txtFechaPublicacion.ReadOnly = false;
                        txtFechaPublicacion.Enabled = false;
                    }
                 if (ViewState["Estado"].ToString() == "Duplicar" )
                  {
                        ViewState["IdOferta"] = "0";
                        txtFechaPublicacion.Text = "";
                        txtFechaVencimiento.Text = "";
                    }
                    if (ViewState["Estado"].ToString() == "Renovar")
                    {
                        
                        txtFechaPublicacion.Text = "";
                        txtFechaVencimiento.Text = "";
                    }
                }
            else 
            { 
            }
            }
            catch (Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);
            }
        }
        protected Control CreateTag(string textTag )
        {
            
            HtmlGenericControl iconClose = new HtmlGenericControl();
            iconClose.InnerHtml = "<svg xmlns='http://www.w3.org/2000/svg' class='icon-24' fill='none' viewBox='0 0 24 24' stroke='currentColor' stroke-width='2'>< path stroke - linecap = 'round' stroke - linejoin = 'round' d = 'M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z' />"; 
            Label lblTagOcupacion = new Label();
            Label lblNameTagOcupacion = new Label();
            HtmlGenericControl tagContainerOcupacion = new HtmlGenericControl("li");
            Button btnRemoveOcupacion = new Button();
            btnRemoveOcupacion.Text = "X";
            tagContainerOcupacion.Attributes.Add("class", "tag");
            tagContainerOcupacion.Controls.Add(lblTagOcupacion);
            lblTagOcupacion.Attributes.Add("class", "tagpointer flex-inline");
            lblTagOcupacion.AssociatedControlID = btnRemoveOcupacion.ID;
            lblTagOcupacion.Controls.Add(btnRemoveOcupacion);
            lblTagOcupacion.Controls.Add(lblNameTagOcupacion);
            lblTagOcupacion.Controls.Add(iconClose);
            lblNameTagOcupacion.Text = textTag;
            return tagContainerOcupacion;

        }

        protected void AddTag(Control control)
        {
            ulSkills.Controls.Add(control);
        }

        protected void RemoveTag(Control tag, Label tagName, Label TagId)
        {
            tag.Visible = false;
            tagName.Text = "";
            TagId.Text = "";
        }

        protected void btnRemoveOcupacion1_Click(object sender, EventArgs e)
        {
            RemoveTag(tagOcupacion1,nameTagOcupacion, idTagOcupacion);
            
        }
        protected void btnRemoveOcupacion2_Click(object sender, EventArgs e)
        {
            RemoveTag(tagOcupacion2, nameTagOcupacion2, idTagOcupacion2);
            idTagOcupacion2.Text = "";
        }
        protected void btnRemoveOcupacion3_Click(object sender, EventArgs e)
        {
            RemoveTag(tagOcupacion3, nameTagOcupacion3, idTagOcupacion3);
            idTagOcupacion3.Text = "";
        }
        protected void btnRemoveOcupacion4_Click(object sender, EventArgs e)
        {
            RemoveTag(tagOcupacion4, nameTagOcupacion4, idTagOcupacion4);
            idTagOcupacion4.Text = "";
        }
        protected void btnRemoveOcupacion5_Click(object sender, EventArgs e)
        {
            RemoveTag(tagOcupacion5, nameTagOcupacion5, idTagOcupacion5);
            idTagOcupacion5.Text = "";
        }
        protected void btnAddOcupacion_Click(object sender, EventArgs e)
        {
            string contentCmbOcupacion = cmbOcupacion.SelectedItem.Text;

            for (int i = 0; i < tagsNames.Count; i++)
            {
                if (tagsNames[i].Text == "" && tags[i].Visible == false && contentCmbOcupacion != "Seleccione un elemento")
                {
                    tagsNames[i].Text = contentCmbOcupacion;
                    tags[i].Visible = true;
                    break;
                }

            }
        }
        protected void cmbNivelEstudiosRequeridos_SelectedIndexChanged(object sender, EventArgs e)
        {
            _carga.Cargar(cmbOcupacion, TipoCombo.CMBEDUCACIONOCUPACION, cmbNivelEstudiosRequeridos.SelectedValue);
        }
        protected void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            _carga.Cargar(cmbMunicipio, TipoCombo.CMBPROVINCIA, cmbDepartamento.SelectedValue);
        }
        protected void btnPublicarOferta_Click(object sender, EventArgs e)
        {
            user = ((UserVO)Session["UsuarioAutenticado"]);
            try 
            {
                OfertaVO registro = new OfertaVO();
                registro.idOferta = Convert.ToInt32(ViewState["IdOferta"]);
                registro.idEmpresa = Convert.ToInt32(ViewState["idEmpresa"]);
                registro.estado = ViewState["Estado"].ToString();
                registro.tituloVacante = txtTituloVacante.Text;
                registro.descripcionVacante = txtDescripcionVacante.Text;
                registro.tiempoExperiencia = Convert.ToInt32(cmbTiempoExperiencia.SelectedValue);
                registro.cantidadVacantes = Convert.ToInt32(txtCantidadVacantes.Text);
                registro.cargo = txtCargo.Text;
                registro.fechaPublicacion = Convert.ToDateTime(txtFechaPublicacion.Text);
                registro.fechaVencimiento = Convert.ToDateTime(txtFechaVencimiento.Text);
                registro.idNivelEstudiosRequeridos = Convert.ToInt32(cmbNivelEstudiosRequeridos.SelectedValue);
                registro.idRangoSalario = Convert.ToInt32(cmbRangoSalarial.SelectedValue);
                registro.idModalidad = Convert.ToInt32(cmbModalidadEmpleo.SelectedValue);
                registro.idMunicipioVacante = Convert.ToInt32(cmbDepartamento.SelectedValue);
                registro.idCiudadVacante = Convert.ToInt32(cmbMunicipio.SelectedValue);
                registro.idSectorEconomico = Convert.ToInt32(cmbSectorEconomico.SelectedValue);
                registro.esConfidencial = ChkConfidencial.Checked;
                if (idTagOcupacion.Text !="")
                {
                    registro.idOcupacion1 = Convert.ToInt32(idTagOcupacion.Text);
                }
                else
                {
                    registro.idOcupacion = null;
                }

                if (idTagOcupacion2.Text != "")
                {
                    registro.idOcupacion2 = Convert.ToInt32(idTagOcupacion2.Text);
                }
                else
                {
                    registro.idOcupacion2 = null;
                }

                if (idTagOcupacion3.Text != "")
                {
                    registro.idOcupacion3 = Convert.ToInt32(idTagOcupacion3.Text);
                }
                else
                {
                    registro.idOcupacion3 = null;
                }

                if (idTagOcupacion4.Text != "")
                {
                    registro.idOcupacion4 = Convert.ToInt32(idTagOcupacion4.Text);
                }
                else
                {
                    registro.idOcupacion4 = null;
                }

                if (idTagOcupacion5.Text != "")
                {
                    registro.idOcupacion5 = Convert.ToInt32(idTagOcupacion5.Text);
                }
                else
                {
                    registro.idOcupacion5 = null;
                }

                registro.idUsuario = user.IdUsuario;
                registro.usuarioCrea = user.NomUsuario;
                _OfertaService = new OfertaServiceClient();
                 _OfertaService.PublicarOferta(registro);
                _OfertaService.Close();
                if (lblEstadoOferta.Text != "ACT" || ViewState["Estado"].ToString() =="Duplicar")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", "showModal();", true);
                }
                else
                {
                    limpiarCampos();
                    Master.mostrarMensaje("Novedad actualizada correctamente.", Master.EXITO);
                    home.Focus();

                }
                

            }
            catch(Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);
                home.Focus();
            }
            
        }
        protected void Volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Empresa/PublicarOfertas.aspx");
        }

        protected void Panel_Click(object sender, EventArgs e)
        {
            lblIdOfertaDelete.Text = "";
            Response.Redirect("~/Default.aspx");
        }
        protected void Adquirir_Click(object sender, EventArgs e)
        {
            lblIdOfertaDelete.Text = "";
            Response.Redirect("~/Empresa/PlanesEmpresa.aspx");
        }
        protected void limpiarCampos()
        {

            ViewState["IdOferta"] = "0";
            ViewState["Estado"] = "New";
            txtTituloVacante.Text = "";
            txtTituloVacante.Enabled = true;
            txtTituloVacante.ReadOnly = false;
            txtDescripcionVacante.Text = "";
            txtDescripcionVacante.Enabled = true;
            txtDescripcionVacante.ReadOnly = false;
            cmbTiempoExperiencia.SelectedValue = "-1";
            cmbTiempoExperiencia.SelectedValue = "-1";
            txtCantidadVacantes.Text = "";
            txtCargo.Text="";
            txtFechaPublicacion.Text = "";
            txtFechaPublicacion.Enabled = true;
            txtFechaPublicacion.ReadOnly = false;
            txtFechaVencimiento.Text="";
            cmbNivelEstudiosRequeridos.SelectedValue ="-1";
            cmbRangoSalarial.SelectedValue="-1";
            cmbModalidadEmpleo.SelectedValue ="-1";
            cmbDepartamento.SelectedValue = "-1";
            cmbMunicipio.SelectedValue = "-1";
            cmbSectorEconomico.SelectedValue = "-1";
            tagOcupacion1.Visible = false;
            idTagOcupacion.Text = "";
            nameTagOcupacion.Text = "";
            tagOcupacion2.Visible = false;
            idTagOcupacion2.Text = "";
            nameTagOcupacion2.Text = "";
            tagOcupacion3.Visible = false;
            idTagOcupacion3.Text = "";
            nameTagOcupacion3.Text = "";
            tagOcupacion4.Visible = false;
            idTagOcupacion4.Text = "";
            nameTagOcupacion4.Text = "";
            tagOcupacion5.Visible = false;
            idTagOcupacion5.Text = "";
            nameTagOcupacion5.Text = "";
          

        }

        protected void CargaDatosBasicos()
        {
            user = ((UserVO)Session["UsuarioAutenticado"]);
            try
            {
                EmpresaVO datosEmpresa = new EmpresaVO();
                datosEmpresa.idUsuario = user.IdUsuario;
                _ActoresService = new EmpresaServiceClient();
                EmpresaVO _resultado = _ActoresService.DatosEmpresa(datosEmpresa);
                _ActoresService.Close();
                ViewState["idEmpresa"] = _resultado.idEmpresa;
                if (_resultado.paquetesActivos == 0 && ViewState["Estado"].ToString() != "Editar")
                {

                    Formulario.Visible = false;
                    openModal2.Style["display"] = "flex";
                }
            }
            catch (Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);

            }
        }
    }
}