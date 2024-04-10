using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using co.itmasters.solucion.vo;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;

namespace co.itmasters.solucion.dao
{
    public class PersonaDao : BaseDao
    {
        private PersonaDao _persona;

        #region [StoredProcedures]
        public const string PERSONA_BUSCARHV = "Persona_TraerHojaVida";
        public const string PERSONA_BUSCARID = "Persona_BuscarId";
        public const string PERSONA_BUSCARDATOSMODIFICADOS = "Alumno_ConsultaExternosBuscarPersona";
        public const string PERSONA_DATOSBASICOSUPDATE = "Persona_DatosBasicosUpdate";
        public const string PERSONA_ACADEMIAUPDATE = "Persona_AcademiaUpdate";
        public const string PERSONA_EXPERIENCIAUPDATE = "Persona_ExperienciaUpdate";
        public const string PERSONA_APTITUDUPDATE = "Persona_AptitudUpdate";
        public const string PERSONA_CONDICIONMANOOBRA = "Persona_CondicionManoObra";
        public const string PERSONA_GRABARTERCERO = "Persona_GrabarTercero";
        public const string PERSONA_CAMBIARCLAVE = "Persona_CambiarClave";
        public const string PERSONA_BUSCARDATOSBASICOS = "Persona_BuscarDatosBasicos";
        public const string PERSONA_BUSCARPERSONAFORMULARIO = "Persona_BuscarPersonaFormulario";
        public const string PERSONA_BUSCARDATOSBASICOSPERSONAS = "Persona_BuscarDatosBasicosPersonas";

        #endregion

        #region[Autocomplete actividad economica]
        public List<AutocompleteActividadEconomica> ActEconomicaAutocomplete(AutocompleteActividadEconomica Act)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                    {
                        new Parametro("IdAct", Act.IdAct, DbType.Int32),
                        new Parametro("Nombre", Act.Nombre, DbType.String),

                    };
                DataTable dt = this.EjecutarStoredProcedureDataTable("ActEconomicaAutocomplete", valParam);
                List<AutocompleteActividadEconomica> Actividades = new List<AutocompleteActividadEconomica>();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        AutocompleteActividadEconomica Actividad = new AutocompleteActividadEconomica();
                        Actividad.Nombre = dr["Descripcion"].ToString();
                        Actividad.IdAct = Convert.ToInt32(dr["idActividad"]);
                        Actividades.Add(Actividad);
                    }
                }
                return Actividades;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion

        #region[AutocompleteCiudad]
        /* METHOD  CiudadAutocomplete*/

        public List<String> CiudadAutocompleteForm(AutocompleteFormulario Autocomplete)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                    {
                        new Parametro("NomCiudad", Autocomplete.NomCiudad, DbType.String),
                        new Parametro("IdCiudad", Autocomplete.IdCiudad, DbType.Int32),
                        new Parametro("idprovincia",Autocomplete.idprovincia , DbType.Int32),
                        new Parametro("idpais", Autocomplete.idpais, DbType.Int32),
                    };
                DataTable dt = this.EjecutarStoredProcedureDataTable("CiudadAutocomplete", valParam);
                List<String> Ciudades = new List<String>();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Ciudades.Add(dr["NOMBRE"].ToString());
                    }
                }
                return Ciudades;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /* METHOD CiudadDepartamentoPais*/
        public AutocompleteFormulario CiudadDepartamentoPaisForm(AutocompleteFormulario Autocomplete)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                    {
                        new Parametro("NomCiudad", Autocomplete.NomCiudad, DbType.String),
                        new Parametro("NomDepartamento", Autocomplete.NomDepartamento, DbType.String),
                        new Parametro("NomPais",Autocomplete.NomPais , DbType.String),
                    };
                DataTable dt = this.EjecutarStoredProcedureDataTable("CiudadDepartamentoPais", valParam);
                AutocompleteFormulario Ciudades = new AutocompleteFormulario();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Ciudades.IdCiudad = Convert.ToInt32(dr["idciudad"]);
                        Ciudades.idprovincia = Convert.ToInt32(dr["idprovincia"]);
                        Ciudades.idpais = Convert.ToInt32(dr["idpais"]);
                        Ciudades.NomCiudad = dr["NOMBRE"].ToString();
                    }
                }
                return Ciudades;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion       

        #region [Constantes persona]

        public const string PERSONA_IDPERSONA = "idPersona";
        public const string PERSONA_IDUSUARIO = "idUsuario";
        public const string PERSONA_IDTIPOIDE = "idTipoIde";
        public const string PERSONA_NUMEROIDE = "numeroIde";
        public const string PERSONA_NOMPERSONA = "nomPersona";
        public const string PERSONA_APEPERSONA = "apePersona";
        public const string PERSONA_PERFIL = "perfil";
        public const string PERSONA_FECHANAC = "fechaNac";
        public const string PERSONA_IDCIUDADNAC = "idCiudadNac";
        public const string PERSONA_IDSEXO = "idSexo";
        public const string PERSONA_CORREOELECTRONICO = "correoElectronico";
        public const string PERSONA_TELEFONO = "telefono";
        public const string PERSONA_IDCIUDADRESIDENCIA = "idCiudadResidencia";
        public const string PERSONA_RUTAAVATAR = "rutaAvatar";
        public const string PERSONA_CIUDADRECIDENCIA = "ciudadRecidencia";
        public const string PERSONA_IDRANGOSALARIO = "idRangoSalario";
        public const string PERSONA_IDMODALIDADTRABAJO = "idModalidadTrabajo";
        public const string PERSONA_DILIGENCIABASICOS = "diligenciaBasicos";
        public const string PERSONA_DILIGENCIAPERFIL = "diligenciaPerfil";
        public const string PERSONA_DILIGENCIAACADEMIA = "diligenciaAcademia";
        public const string PERSONA_DILIGENCIAEXPERIENCIA = "diligenciaExperiencia";
        public const string PERSONA_DILIGENCIAAPTITUD = "diligenciaAptitud";
        public const string PERSONA_USUARIOCREA = "usuarioCrea";
        public const string PERSONA_FECHACREA = "fechaCrea";
        public const string PERSONA_USUARIOMODIFICA = "usuarioModifica";
        public const string PERSONA_FECHAMODIFICA = "fechaModifica";

        public const string PERSONA_IDPERSONAACADEMIA = "idPersonaAcademia";
        public const string PERSONA_IDNIVELEDUCATIVO = "idNivelEducativo";
        public const string PERSONA_NIVELEDUCATIVO = "nivelEducativo";
        public const string PERSONA_IDOCUPACION = "idOcupacion";
        public const string PERSONA_IDCIUDADFORMACION = "idCiudadFormacion";
        public const string PERSONA_TITULOFORMACIONACADEMICA = "tituloFormacionAcademica";
        public const string PERSONA_NOMINSTITUCION = "nomInstitucion";
        public const string PERSONA_FECHAFINFORMACION = "fechaFinFormacion";

        public const string PERSONA_IDPERSONAAPTITUD = "idPersonaAptitud";
        public const string PERSONA_IDAPTITUD = "idAptitud";
        public const string PERSONA_NOMAPTITUD = "nomAptitud";

        public const string PERSONA_IDPERSONAEXPERIENCIA = "idPersonaExperiencia";
        public const string PERSONA_NOMCARGO = "nomCargo";
        public const string PERSONA_IDCIUDADCARGO = "idCiudadCargo";
        public const string PERSONA_FECHAINICARGO = "fechaIniCargo";
        public const string PERSONA_FECHAFINCARGO = "fechaFinCargo";
        public const string PERSONA_TIEMPOCARGO = "tiempoCargo";
        public const string PERSONA_DESCARGO = "desCargo";


        #endregion

        #region [Constates Modificacion]

        public const string MODIFY_TYPE = "modifyType";
        public const string MODIFY_INSERT = "INS";
        public const string MODIFY_UPDATE = "UPD";
        public const string MODIFY_DELETE = "DEL";

        #endregion

        #region  [Metodos Expuestos]

        /// <summary>
        /// Buscar una persona dado el Colegio y la identificacion
        /// </summary>
        /// <param name="ppersona"></param>
        /// <returns></returns>
        public PersonaVO Buscar_persona(PersonaVO persona)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    new Parametro(PERSONA_IDUSUARIO, persona.idUsuario, DbType.Int32),
                };
                DataSet ds = this.EjecutarStoredProcedureDataSet(PERSONA_BUSCARHV, valParam);

                PersonaVO item = this.CargarPersonaVO(ds.Tables[0].Rows[0]);
                List<PersonaAcademiaVO> academia = this.CargarPersonaAcademiaVO(ds.Tables[1]);
                List<PersonaAptitudVO> aptitud = this.CargarPersonaAptitudVO(ds.Tables[2]);
                List<PersonaExperienciaVO> experiencia = this.CargarPersonaExperienciaVO(ds.Tables[3]);
                item.Academia = academia;
                item.Aptitud = aptitud;
                item.Experiencia = experiencia;
                return item;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public PersonaVO Buscar_personaId(PersonaVO ppersona)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
         {
            //new Parametro(PERSONA_IDPERSONA, ppersona.IdPersona, DbType.Int32),
            };
                DataRow dr = this.EjecutarStoredProcedureDataRow(PERSONA_BUSCARID, valParam);

                if (dr != null)
                    return cargarVO(dr);

                return null;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<PersonaVO> Buscar_personaDatosModificados(PersonaVO ppersona)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    //new Parametro(PERSONA_IDPERSONA, ppersona.IdPersona, DbType.Int32),
                };
                DataTable dt = this.EjecutarStoredProcedureDataTable(PERSONA_BUSCARDATOSMODIFICADOS, valParam);

                List<PersonaVO> rPersona = null;

                if (dt.Rows.Count > 0)
                {
                    rPersona = new List<PersonaVO>();

                    foreach (DataRow dr in dt.Rows)
                    {
                        PersonaVO persona = new PersonaVO();

                        //persona.IdEmpresa = Convert.ToInt32(dr[PERSONA_IDEMPRESA]);
                        //persona.IdPersona = Convert.ToInt32(dr[PERSONA_IDPERSONA]);
                        //if (dr.Table.Columns.Contains(PERSONA_IDPERSONAMODIFICADO))
                        {
                            //persona.IdPersonaModificado = dr[PERSONA_IDPERSONAMODIFICADO] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPERSONAMODIFICADO]);
                        }
                        //persona.TipIdentificacion = Convert.ToInt32(dr[PERSONA_TIPIDENTIFICACION]);
                        //persona.NumIdentificacion = Convert.ToString(dr[PERSONA_NUMIDENTIFICACION]);
                        //persona.Nombres = Convert.ToString(dr[PERSONA_NOMBRES]);
                        //persona.Apellidos = Convert.ToString(dr[PERSONA_APELLIDOS]);
                        //persona.IdProfesion = dr[PERSONA_IDPROFESION] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPROFESION]);
                        //persona.Empresa = Convert.ToString(dr[PERSONA_EMPRESA]);
                        //persona.CargoPersona = Convert.ToString(dr[PERSONA_CARGOPERSONA]);
                        //persona.Correo = Convert.ToString(dr[PERSONA_CORREO]);
                        //persona.NumCelular = Convert.ToString(dr[PERSONA_NUMCELULAR]);
                        //persona.DireccionResidencia = Convert.ToString(dr[PERSONA_DIRECCIONRESIDENCIA]);
                        //persona.BarrioResidencia = Convert.ToString(dr[PERSONA_BARRIORESIDENCIA]);
                        //persona.TelefonoResidencia = Convert.ToString(dr[PERSONA_TELEFONORESIDENCIA]);
                        //persona.IdPaisResidencia = dr[PERSONA_IDPAISRESIDENCIA] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPAISRESIDENCIA]);
                        //persona.IdProvinciaResidencia = dr[PERSONA_IDPROVINCIARESIDENCIA] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPROVINCIARESIDENCIA]);
                        //persona.IdCiudadResidencia = dr[PERSONA_IDCIUDADRESIDENCIA] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDCIUDADRESIDENCIA]);
                        //persona.nomPaisResidencia = Convert.ToString(dr[PERSONA_NOMPAISRESIDENCIA]);
                        //persona.nomProvinciaResidencia = Convert.ToString(dr[PERSONA_NOMPROVINCIARESIDENCIA]);
                        //persona.nomCiudadResidencia = Convert.ToString(dr[PERSONA_NOMCIUDADRESIDENCIA]);
                        //persona.DireccionLaboral = Convert.ToString(dr[PERSONA_DIRECCIONLABORAL]);
                        //persona.BarrioLaboral = Convert.ToString(dr[PERSONA_BARRIOLABORAL]);
                        //persona.TelefonoLaboral = Convert.ToString(dr[PERSONA_TELEFONOLABORAL]);
                        //persona.IdPaisLaboral = dr[PERSONA_IDPAISLABORAL] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPAISLABORAL]);
                        //persona.IdProvinciaLaboral = dr[PERSONA_IDPROVINCIALABORAL] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPROVINCIALABORAL]);
                        //persona.IdCiudadLaboral = dr[PERSONA_IDCIUDADLABORAL] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDCIUDADLABORAL]);
                        //persona.nomPaisLaboral = Convert.ToString(dr[PERSONA_NOMPAISLABORAL]);
                        //persona.nomProvinciaLaboral = Convert.ToString(dr[PERSONA_NOMPROVINCIALABORAL]);
                        //persona.nomCiudadLaboral = Convert.ToString(dr[PERSONA_NOMCIUDADLABORAL]);
                        //persona.UsuarioCrea = Convert.ToString(dr[PERSONA_USUARIOCREA]);
                        //persona.FechaCrea = Convert.ToDateTime(dr[PERSONA_FECHACREA]);
                        //persona.UsuarioModifica = Convert.ToString(dr[PERSONA_USUARIOMODIFICA]);
                        //persona.FechaModifica = dr[PERSONA_FECHAMODIFICA] == Convert.DBNull ? dateNull : Convert.ToDateTime(dr[PERSONA_FECHAMODIFICA]);
                        rPersona.Add(persona);
                    }
                }

                return rPersona;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<PersonaVO> Persona_DatosBasicos(PersonaVO pPersona)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    //Se adicionan los parametros para la busqueda del objeto
                    //new Parametro(PERSONA_NOMBREPOPUP1, pPersona.Nombres, DbType.String),
                    //new Parametro(PERSONA_APELLIDOPOPUP1, pPersona.Apellidos, DbType.String),
                    //new Parametro(PERSONA_IDEMPRESA,pPersona.IdEmpresa, DbType.Int32)
                };

                DataTable dt = this.EjecutarStoredProcedureDataTable(PERSONA_BUSCARDATOSBASICOS, valParam);

                List<PersonaVO> rPersona = new List<PersonaVO>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        PersonaVO Persona = new PersonaVO();
                        //Persona.Nombres = Convert.ToString(dr[PERSONA_NOMBRES]);
                        //Persona.Apellidos = Convert.ToString(dr[PERSONA_APELLIDOS]);
                        //Persona.NumDoc = Convert.ToString(dr[PERSONA_NUMDOC]);
                        //Persona.TipoDoc = Convert.ToInt32(dr[PERSONA_TIPODOC]);
                        rPersona.Add(Persona);
                    }
                }
                return rPersona;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<PersonaVO> Persona_DatosBasicosPersonas(PersonaVO pPersona)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    //Se adicionan los parametros para la busqueda del objeto
                    //new Parametro(PERSONA_NOMBREPOPUP1, pPersona.Nombres, DbType.String),
                    //new Parametro(PERSONA_APELLIDOPOPUP1, pPersona.Apellidos, DbType.String)
                };

                DataTable dt = this.EjecutarStoredProcedureDataTable(PERSONA_BUSCARDATOSBASICOSPERSONAS, valParam);

                List<PersonaVO> rPersona = new List<PersonaVO>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        PersonaVO Persona = new PersonaVO();
                        //Persona.Nombres = Convert.ToString(dr[PERSONA_NOMBRES]);
                        //Persona.Apellidos = Convert.ToString(dr[PERSONA_APELLIDOS]);
                        //Persona.NumDoc = Convert.ToString(dr[PERSONA_NUMDOC]);
                        //Persona.TipoDoc = Convert.ToInt32(dr[PERSONA_TIPODOC]);
                        rPersona.Add(Persona);
                    }
                }
                return rPersona;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void PersonaDatosBasicos_Update(PersonaVO persona)

        {
            try
            {

                persona.perfil = UpperFirstChar(persona.perfil);
                 persona.nomPersona = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(
                     persona.nomPersona.ToString().ToLower());
                 persona.apePersona = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(
                     persona.apePersona.ToString().ToLower());
                Parametro[] valParam = new Parametro[]
                {

                    
                    new Parametro(PERSONA_IDPERSONA, persona.idPersona, DbType.Int32),
                    new Parametro(PERSONA_IDUSUARIO, persona.idUsuario, DbType.Int32),
                    new Parametro(PERSONA_NOMPERSONA, persona.nomPersona, DbType.String),
                    new Parametro(PERSONA_APEPERSONA, persona.apePersona, DbType.String),
                    new Parametro(PERSONA_PERFIL, persona.perfil, DbType.String),
                    new Parametro(PERSONA_FECHANAC, persona.fechaNac, DbType.Date),
                    new Parametro(PERSONA_IDCIUDADNAC, persona.idCiudadNac, DbType.Int32),
                    new Parametro(PERSONA_IDSEXO, persona.idSexo, DbType.Int32),
                    new Parametro(PERSONA_TELEFONO, persona.telefono, DbType.String),
                    new Parametro(PERSONA_IDCIUDADRESIDENCIA, persona.idCiudadResidencia, DbType.Int32),
                    new Parametro(PERSONA_RUTAAVATAR, persona.rutaAvatar, DbType.String),
                    new Parametro(MODIFY_TYPE, MODIFY_UPDATE, DbType.String),
                  
    };
                this.EjecutarStoredProcedure(PERSONA_DATOSBASICOSUPDATE, valParam);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void PersonaAcademia_Update(PersonaAcademiaVO persona)
            
        {
            try
            {
                persona.tituloFormacionAcademica = UpperFirstChar(persona.tituloFormacionAcademica);
                persona.nomInstitucion = UpperFirstChar(persona.nomInstitucion);
                Parametro[] valParam = new Parametro[]
                {
                    new Parametro(MODIFY_TYPE, persona.typeModify, DbType.String),

                    new Parametro(PERSONA_IDUSUARIO, persona.idUsuario, DbType.Int32),
                    new Parametro(PERSONA_IDPERSONAACADEMIA, persona.idPersonaAcademia, DbType.Int32),
                    new Parametro(PERSONA_IDPERSONA, persona.idPersona, DbType.Int32),
                    new Parametro(PERSONA_IDNIVELEDUCATIVO, persona.idNivelEducativo, DbType.Int32),
                    new Parametro(PERSONA_TITULOFORMACIONACADEMICA, persona.tituloFormacionAcademica, DbType.String),
                    new Parametro(PERSONA_NOMINSTITUCION, persona.nomInstitucion, DbType.String),
                    new Parametro(PERSONA_FECHAFINFORMACION, persona.fechaFinFormacion, DbType.Date),
                    new Parametro(PERSONA_IDOCUPACION, persona.idOcupacion, DbType.Int32),
                    new Parametro(PERSONA_IDCIUDADFORMACION, persona.idCiudadFormacion, DbType.Int32),
                   
    };
                this.EjecutarStoredProcedure(PERSONA_ACADEMIAUPDATE, valParam);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }
        public void PersonaExperiencia_Update(PersonaExperienciaVO persona)
            
        {
            try
            {
                persona.nomCargo = UpperFirstChar(persona.nomCargo);
                persona.desCargo = UpperFirstChar(persona.desCargo);
                Parametro[] valParam = new Parametro[]
                {
                    new Parametro(MODIFY_TYPE, persona.typeModify, DbType.String),

                    new Parametro(PERSONA_IDUSUARIO, persona.idUsuario, DbType.Int32),
                    new Parametro(PERSONA_IDPERSONAEXPERIENCIA, persona.idPersonaExperiencia, DbType.Int32),
                    new Parametro(PERSONA_IDPERSONA, persona.idPersona, DbType.Int32),
                    new Parametro(PERSONA_NOMCARGO, persona.nomCargo, DbType.String),
                    new Parametro(PERSONA_IDNIVELEDUCATIVO, persona.idNivelEducativo, DbType.Int32),
                    new Parametro(PERSONA_IDOCUPACION, persona.idOcupacion, DbType.Int32),
                    new Parametro(PERSONA_IDCIUDADCARGO, persona.idCiudadCargo, DbType.Int32),
                    new Parametro(PERSONA_FECHAINICARGO, persona.fechaIniCargo, DbType.Date),
                    new Parametro(PERSONA_FECHAFINCARGO, persona.fechaFinCargo, DbType.Date),
                    new Parametro(PERSONA_TIEMPOCARGO, persona.tiempoCargo, DbType.Int32),
                    new Parametro(PERSONA_DESCARGO, persona.desCargo, DbType.String),
    };
                this.EjecutarStoredProcedure(PERSONA_EXPERIENCIAUPDATE, valParam);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void PersonaAptitud_Update(PersonaAptitudVO persona)

        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    new Parametro(MODIFY_TYPE, persona.typeModify, DbType.String),

                    new Parametro(PERSONA_IDUSUARIO, persona.idUsuario, DbType.Int32),
                    new Parametro(PERSONA_IDAPTITUD, persona.idAptitud, DbType.Int32),
                    new Parametro(PERSONA_IDPERSONA, persona.idPersona, DbType.Int32),
                    new Parametro(PERSONA_IDPERSONAAPTITUD, persona.idPersonaAptitud, DbType.Int32),
    };
                this.EjecutarStoredProcedure(PERSONA_APTITUDUPDATE, valParam);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void PersonaCondicionManoObra_Update(PersonaVO persona)

        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    new Parametro(MODIFY_TYPE, persona.typeModify, DbType.String),

                    new Parametro(PERSONA_IDUSUARIO, persona.idUsuario, DbType.Int32),
                    new Parametro(PERSONA_IDPERSONA, persona.idPersona, DbType.Int32),
                    new Parametro(PERSONA_IDRANGOSALARIO, persona.idRangoSalario, DbType.Int32),
                    new Parametro(PERSONA_IDMODALIDADTRABAJO, persona.idModalidadTrabajo, DbType.Int32),
    };
                this.EjecutarStoredProcedure(PERSONA_CONDICIONMANOOBRA, valParam);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Guardar_PersonaTercero(PersonaVO persona)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    //new Parametro(PERSONA_IDEMPRESA, persona.IdEmpresa, DbType.Int32),
                    //new Parametro(PERSONA_IDPERSONA, persona.IdPersona, DbType.Int32),
                    //new Parametro(PERSONA_TIPIDENTIFICACION, persona.TipIdentificacion, DbType.Int32),
                    //new Parametro(PERSONA_NUMIDENTIFICACION, persona.NumIdentificacion, DbType.String),
                    //new Parametro(PERSONA_NOMBRES, persona.Nombres, DbType.String),
                    //new Parametro(PERSONA_APELLIDOS, persona.Apellidos, DbType.String),
                    //new Parametro(PERSONA_CORREO, persona.Correo, DbType.String),
                    //new Parametro(PERSONA_NUMCELULAR, persona.NumCelular, DbType.String),
                    //new Parametro(PERSONA_DIRECCIONRESIDENCIA, persona.DireccionResidencia, DbType.String),
                    //new Parametro(PERSONA_BARRIORESIDENCIA, persona.BarrioResidencia, DbType.String),
                    //new Parametro(PERSONA_TELEFONORESIDENCIA, persona.TelefonoResidencia, DbType.String),
                    //new Parametro(PERSONA_IDPAISRESIDENCIA, persona.IdPaisResidencia, DbType.Int32),
                    //new Parametro(PERSONA_IDPROVINCIARESIDENCIA, persona.IdProvinciaResidencia, DbType.Int32),
                    //new Parametro(PERSONA_IDCIUDADRESIDENCIA, persona.IdCiudadResidencia, DbType.Int32),
                    //new Parametro(PERSONA_USUARIOCREA, persona.UsuarioCrea, DbType.String),
                    //new Parametro(PERSONA_USUARIOMODIFICA, persona.UsuarioModifica, DbType.String),
                    };
                this.EjecutarStoredProcedure(PERSONA_GRABARTERCERO, valParam);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Guardar_CambiarClave(FuncionarioVO persona)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    //new Parametro(PERSONA_USUARIO, persona.Usuario, DbType.String),
                    //new Parametro(PERSONA_CLAVEACTUAL, persona.ClaveActual, DbType.String),
                    //new Parametro(PERSONA_CLAVENUEVA, persona.ClaveNueva, DbType.String),
                };
                this.EjecutarStoredProcedure(PERSONA_CAMBIARCLAVE, valParam);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public PersonaVO Buscar_personaFormulario(PersonaVO ppersona)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    //new Parametro(PERSONA_IDPERSONA, ppersona.IdPersona, DbType.Int32),
                };
                DataTable dt = this.EjecutarStoredProcedureDataTable(PERSONA_BUSCARPERSONAFORMULARIO, valParam);

                PersonaVO rPersona = null;

                if (dt.Rows.Count > 0)
                {
                    rPersona = new PersonaVO();

                    foreach (DataRow dr in dt.Rows)
                    {
                        PersonaVO persona = new PersonaVO();

                        //persona.IdEmpresa = Convert.ToInt32(dr[PERSONA_IDEMPRESA]);
                        //persona.IdPersona = Convert.ToInt32(dr[PERSONA_IDPERSONA]);
                        //persona.TipIdentificacion = Convert.ToInt32(dr[PERSONA_TIPIDENTIFICACION]);
                        //persona.NumIdentificacion = Convert.ToString(dr[PERSONA_NUMIDENTIFICACION]);
                        //persona.Nombres = Convert.ToString(dr[PERSONA_NOMBRES]);
                        //persona.Apellidos = Convert.ToString(dr[PERSONA_APELLIDOS]);
                        //persona.IdProfesion = dr[PERSONA_IDPROFESION] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPROFESION]);
                        //persona.Empresa = Convert.ToString(dr[PERSONA_EMPRESA]);
                        //persona.CargoPersona = Convert.ToString(dr[PERSONA_CARGOPERSONA]);
                        //persona.Correo = Convert.ToString(dr[PERSONA_CORREO]);
                        //persona.NumCelular = Convert.ToString(dr[PERSONA_NUMCELULAR]);
                        //persona.DireccionResidencia = Convert.ToString(dr[PERSONA_DIRECCIONRESIDENCIA]);
                        //persona.BarrioResidencia = Convert.ToString(dr[PERSONA_BARRIORESIDENCIA]);
                        //persona.TelefonoResidencia = Convert.ToString(dr[PERSONA_TELEFONORESIDENCIA]);
                        //persona.IdPaisResidencia = dr[PERSONA_IDPAISRESIDENCIA] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPAISRESIDENCIA]);
                        //persona.IdProvinciaResidencia = dr[PERSONA_IDPROVINCIARESIDENCIA] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPROVINCIARESIDENCIA]);
                        //persona.IdCiudadResidencia = dr[PERSONA_IDCIUDADRESIDENCIA] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDCIUDADRESIDENCIA]);
                        //persona.DireccionLaboral = Convert.ToString(dr[PERSONA_DIRECCIONLABORAL]);
                        //persona.BarrioLaboral = Convert.ToString(dr[PERSONA_BARRIOLABORAL]);
                        //persona.TelefonoLaboral = Convert.ToString(dr[PERSONA_TELEFONOLABORAL]);
                        //persona.IdPaisLaboral = dr[PERSONA_IDPAISLABORAL] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPAISLABORAL]);
                        //persona.IdProvinciaLaboral = dr[PERSONA_IDPROVINCIALABORAL] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPROVINCIALABORAL]);
                        //persona.IdCiudadLaboral = dr[PERSONA_IDCIUDADLABORAL] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDCIUDADLABORAL]);
                        //persona.UsuarioCrea = Convert.ToString(dr[PERSONA_USUARIOCREA]);
                        //persona.FechaCrea = Convert.ToDateTime(dr[PERSONA_FECHACREA]);
                        //persona.UsuarioModifica = Convert.ToString(dr[PERSONA_USUARIOMODIFICA]);
                        //persona.FechaModifica = dr[PERSONA_FECHAMODIFICA] == Convert.DBNull ? dateNull : Convert.ToDateTime(dr[PERSONA_FECHAMODIFICA]);
                        rPersona = persona;
                    }
                }

                return rPersona;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region  [Metodos Privados]

        private PersonaVO CargarPersonaVO(DataRow dr)
        {
            if (dr == null)
                return null;

            PersonaVO persona = new PersonaVO();

            persona.idPersona = Convert.ToInt32(dr[PERSONA_IDPERSONA]);
            persona.idUsuario = Convert.ToInt32(dr[PERSONA_IDUSUARIO]);
            persona.idTipoIde = Convert.ToInt32(dr[PERSONA_IDTIPOIDE]);
            persona.numeroIde = Convert.ToInt32(dr[PERSONA_NUMEROIDE]);
            persona.nomPersona = Convert.ToString(dr[PERSONA_NOMPERSONA]);
            persona.apePersona = Convert.ToString(dr[PERSONA_APEPERSONA]);
            persona.perfil = Convert.ToString(dr[PERSONA_PERFIL]);
            persona.fechaNac = dr[PERSONA_FECHANAC] == Convert.DBNull ? dateNull : Convert.ToDateTime(dr[PERSONA_FECHANAC]);
            persona.idCiudadNac = dr[PERSONA_IDCIUDADNAC] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDCIUDADNAC]);
            persona.idSexo = dr[PERSONA_IDSEXO] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDSEXO]);
            persona.correoElectronico = Convert.ToString(dr[PERSONA_CORREOELECTRONICO]);
            persona.telefono = Convert.ToString(dr[PERSONA_TELEFONO]);
            persona.idCiudadResidencia = dr[PERSONA_IDCIUDADRESIDENCIA] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDCIUDADRESIDENCIA]);
            persona.ciudadResidencia = Convert.ToString(dr[PERSONA_CIUDADRECIDENCIA]);
            persona.idRangoSalario = dr[PERSONA_IDRANGOSALARIO] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDRANGOSALARIO]);
            persona.idModalidadTrabajo = dr[PERSONA_IDMODALIDADTRABAJO] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDMODALIDADTRABAJO]);
            persona.diligenciaBasicos = dr[PERSONA_DILIGENCIABASICOS] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_DILIGENCIABASICOS]);
            persona.diligenciaPerfil = dr[PERSONA_DILIGENCIAPERFIL] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_DILIGENCIAPERFIL]);
            persona.diligenciaAcademia = dr[PERSONA_DILIGENCIAACADEMIA] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_DILIGENCIAACADEMIA]);
            persona.diligenciaExperiencia = dr[PERSONA_DILIGENCIAEXPERIENCIA] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_DILIGENCIAEXPERIENCIA]);
            persona.diligenciaAptitud = dr[PERSONA_DILIGENCIAAPTITUD] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_DILIGENCIAAPTITUD]);
            
            return persona;
        }
        private List<PersonaAcademiaVO> CargarPersonaAcademiaVO(DataTable dt)
        {
            //  Generando Metodo
            if (dt == null)
                return null;

            List<PersonaAcademiaVO> academiaList = new List<PersonaAcademiaVO>();

            foreach (DataRow dr in dt.Rows)
            {
                PersonaAcademiaVO academia = new PersonaAcademiaVO();
                academia.idPersonaAcademia = dr[PERSONA_IDPERSONAACADEMIA] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPERSONAACADEMIA]);
                academia.idPersona= dr[PERSONA_IDPERSONA] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPERSONA]);
                academia.idNivelEducativo = dr[PERSONA_IDNIVELEDUCATIVO] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDNIVELEDUCATIVO]);
                academia.nivelEducativo = Convert.ToString(dr[PERSONA_NIVELEDUCATIVO]);
                academia.tituloFormacionAcademica = Convert.ToString(dr[PERSONA_TITULOFORMACIONACADEMICA]);
                academia.nomInstitucion = Convert.ToString(dr[PERSONA_NOMINSTITUCION]);
                academia.fechaFinFormacion = dr[PERSONA_FECHAFINFORMACION] == Convert.DBNull ? dateNull : Convert.ToDateTime(dr[PERSONA_FECHAFINFORMACION]);
                academia.idOcupacion = dr[PERSONA_IDOCUPACION] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDOCUPACION]);
                academia.idCiudadFormacion = dr[PERSONA_IDCIUDADFORMACION] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDCIUDADFORMACION]);

                academiaList.Add(academia);
            }
            return academiaList;
        }
        private List<PersonaAptitudVO> CargarPersonaAptitudVO(DataTable dt)
        {
            //  Generando Metodo
            if (dt == null)
                return null;

            List<PersonaAptitudVO> aptitudList = new List<PersonaAptitudVO>();

            foreach (DataRow dr in dt.Rows)
            {
                PersonaAptitudVO aptitud = new PersonaAptitudVO();
                aptitud.idPersonaAptitud = dr[PERSONA_IDPERSONAAPTITUD] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPERSONAAPTITUD]);
                aptitud.nomAptitud = Convert.ToString(dr[PERSONA_NOMAPTITUD]);
                aptitud.idAptitud = dr[PERSONA_IDAPTITUD] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDAPTITUD]);

                aptitudList.Add(aptitud);
            }
            return aptitudList;
        }
        private List<PersonaExperienciaVO> CargarPersonaExperienciaVO(DataTable dt)
        {
            //  Generando Metodo
            if (dt == null)
                return null;

            List<PersonaExperienciaVO> ExperienciaList = new List<PersonaExperienciaVO>();

            foreach (DataRow dr in dt.Rows)
            {
                PersonaExperienciaVO experiencia = new PersonaExperienciaVO();
                experiencia.idPersonaExperiencia = dr[PERSONA_IDPERSONAEXPERIENCIA] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPERSONAEXPERIENCIA]);
                experiencia.idPersona= dr[PERSONA_IDPERSONA] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPERSONA]);
                experiencia.nomCargo = Convert.ToString(dr[PERSONA_NOMCARGO]);
                experiencia.idCiudadCargo = dr[PERSONA_IDCIUDADCARGO] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDCIUDADCARGO]);
                experiencia.fechaIniCargo = dr[PERSONA_FECHAINICARGO] == Convert.DBNull ? dateNull : Convert.ToDateTime(dr[PERSONA_FECHAINICARGO]);
                experiencia.fechaFinCargo = dr[PERSONA_FECHAFINCARGO] == Convert.DBNull ? dateNull : Convert.ToDateTime(dr[PERSONA_FECHAFINCARGO]);
                experiencia.tiempoCargo = dr[PERSONA_TIEMPOCARGO] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_TIEMPOCARGO]);
                experiencia.desCargo = Convert.ToString(dr[PERSONA_DESCARGO]);
                experiencia.idNivelEducativo = dr[PERSONA_IDNIVELEDUCATIVO] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDNIVELEDUCATIVO]);
                experiencia.idOcupacion = dr[PERSONA_IDOCUPACION] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDOCUPACION]);

                ExperienciaList.Add(experiencia);
            }
            return ExperienciaList;
        }
        private PersonaVO cargarVO(DataRow dr)
        {
            PersonaVO persona = new PersonaVO();

            //persona.IdEmpresa = Convert.ToInt32(dr[PERSONA_IDEMPRESA]);
            //persona.IdPersona = Convert.ToInt32(dr[PERSONA_IDPERSONA]);
            //if (dr.Table.Columns.Contains(PERSONA_IDPERSONAMODIFICADO))
            {
                //persona.IdPersonaModificado = dr[PERSONA_IDPERSONAMODIFICADO] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPERSONAMODIFICADO]);
            }
            //persona.TipIdentificacion = Convert.ToInt32(dr[PERSONA_TIPIDENTIFICACION]);
            //persona.NumIdentificacion = Convert.ToString(dr[PERSONA_NUMIDENTIFICACION]);
            //persona.Nombres = Convert.ToString(dr[PERSONA_NOMBRES]);
            //persona.Apellidos = Convert.ToString(dr[PERSONA_APELLIDOS]);
            //persona.IdProfesion = dr[PERSONA_IDPROFESION] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPROFESION]);
            //persona.Empresa = Convert.ToString(dr[PERSONA_EMPRESA]);
            //persona.CargoPersona = Convert.ToString(dr[PERSONA_CARGOPERSONA]);
            //persona.Correo = Convert.ToString(dr[PERSONA_CORREO]);
            //persona.NumCelular = Convert.ToString(dr[PERSONA_NUMCELULAR]);
            //persona.DireccionResidencia = Convert.ToString(dr[PERSONA_DIRECCIONRESIDENCIA]);
            //persona.BarrioResidencia = Convert.ToString(dr[PERSONA_BARRIORESIDENCIA]);
            //persona.TelefonoResidencia = Convert.ToString(dr[PERSONA_TELEFONORESIDENCIA]);
            //persona.IdPaisResidencia = dr[PERSONA_IDPAISRESIDENCIA] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPAISRESIDENCIA]);
            //persona.IdProvinciaResidencia = dr[PERSONA_IDPROVINCIARESIDENCIA] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPROVINCIARESIDENCIA]);
            //persona.IdCiudadResidencia = dr[PERSONA_IDCIUDADRESIDENCIA] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDCIUDADRESIDENCIA]);
            //persona.DireccionLaboral = Convert.ToString(dr[PERSONA_DIRECCIONLABORAL]);
            //persona.BarrioLaboral = Convert.ToString(dr[PERSONA_BARRIOLABORAL]);
            //persona.TelefonoLaboral = Convert.ToString(dr[PERSONA_TELEFONOLABORAL]);
            //persona.IdPaisLaboral = dr[PERSONA_IDPAISLABORAL] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPAISLABORAL]);
            //persona.IdProvinciaLaboral = dr[PERSONA_IDPROVINCIALABORAL] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPROVINCIALABORAL]);
            //persona.IdCiudadLaboral = dr[PERSONA_IDCIUDADLABORAL] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDCIUDADLABORAL]);
            //persona.UsuarioCrea = Convert.ToString(dr[PERSONA_USUARIOCREA]);
            //persona.FechaCrea = Convert.ToDateTime(dr[PERSONA_FECHACREA]);
            //persona.UsuarioModifica = Convert.ToString(dr[PERSONA_USUARIOMODIFICA]);
            //persona.FechaModifica = dr[PERSONA_FECHAMODIFICA] == Convert.DBNull ? dateNull : Convert.ToDateTime(dr[PERSONA_FECHAMODIFICA]);
            return persona;

        }
        private string UpperFirstChar(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

            char[] chars = input.ToCharArray();
            chars[0] = char.ToUpper(chars[0]);
            return new string(chars);
        }
    }

    #endregion


}

