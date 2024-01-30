using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using co.itmasters.solucion.vo;
using System.Data;
using System.Data.SqlClient;
using System.CodeDom;
using System.Security.Policy;

namespace co.itmasters.solucion.dao
{
    public class EmpresaDao : BaseDao
    {
        private EmpresaDao _empresa;

        #region [StoredProcedures]
        public const string EMPRESA_PLANESADQUIRIDOS = "Empresa_PlanesAdquiridos";
        public const string EMPRESA_TRAEDATOSEMPRESASAPROBAR = "Empresa_TraeDatosEmpresaAprobar";
        public const string EMPRESA_DATOSEMPRESABUSCAR = "Empresa_BuscarDatosEmpresa";
        public const string EMPRESA_DATOSEMPRESAGUARDAR = "Empresa_GuardarDatosEmpresa";
        public const string EMPRESA_APROBAREMPRESA = "Empresa_AprobarEmpresa";

        #endregion


        #region [Constantes empresa]
        /// <summary>
        /// Tabla actres.empresas
        /// </summary>
        public const string EMPRESA_IDEMPRESA = "idEmpresa";
        public const string EMPRESA_IDUSUARIO = "idUsuario";
        public const string EMPRESA_FASE = "fase";
        public const string EMPRESA_NOMEMPRESA = "nomEmpresa";
        public const string EMPRESA_IDTIPOIDE = "idTipoIde";
        public const string EMPRESA_NUMEROIDE = "numeroIde";
        public const string EMPRESA_IDSECTORECONOMICO = "idSectorEconomico";
        public const string EMPRESA_IDACTIVIDADECONOMICA = "idActividadEconomica";
        public const string EMPRESA_IDDEPARTAMENTODEMPRESA = "idDepartamentoEmpresa";
        public const string EMPRESA_IDCIUDADEMPRESA = "idCiudadEmpresa";
        public const string EMPRESA_CORREOELECTRONICO = "correoElectronico";
        public const string EMPRESA_NOMCIUDAD = "nomCiudad";
        public const string EMPRESA_TELEFONO = "telefono";
        public const string EMPRESA_DIRECCION = "direccion";
        public const string EMPRESA_IDTIPOIDEREPLEGAL = "idTipoIdeRepLegal";
        public const string EMPRESA_NUMIDEREPLEGAL = "numIdeRepLegal";
        public const string EMPRESA_NOMREPLEGAL = "nomRepLegal";
        public const string EMPRESA_TELREPLEGAL = "telRepLegal";
        public const string EMPRESA_CAMARACOMERCIO = "camaraComercio";
        public const string EMPRESA_RUT = "rut";
        public const string EMPRESA_COMPLETADATOS = "completaDatos";
        public const string EMPRESA_USUARIOCREA = "usuarioCrea";
        public const string EMPRESA_FECHACREA = "fechaCrea";
        public const string EMPRESA_USUARIOMODFICA = "usuarioModfica";
        public const string EMPRESA_FECHAMODFICIA = "fechaModficia";
        public const string EMPRESA_RUTAAVATAR = "rutaAvatar";
        public const string EMPRESA_PAQUETESACTIVOS = "paquetesActivos";
        public const string EMPRESA_ESTADO = "estado";
        public const string EMPRESA_OBSERVACION = "observacion";
        // Planes
        public const string EMPRESA_TYPEMODIFY = "typeModify";
        public const string PLAN_IDPLAN = "idPlan";
        public const string PLAN_VIGENCIAPLAN = "vigenciaPlan";
        public const string PLAN_NUMEROOFERTAS = "numeroOfertas";
        public const string PLAN_VALORPLAN = "valorPlan";


        /*************************Proceso de formulario****************************************************/


        #endregion

        #region  [Metodos Expuestos]
        public void CreatePlanAdquirido(EmpresaVO empresa) {

            empresa.typeModify = "INS";
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    new Parametro(EMPRESA_TYPEMODIFY, empresa.typeModify, DbType.String),
                    new Parametro(EMPRESA_IDUSUARIO, empresa.idUsuario, DbType.Int32),
                    new Parametro(EMPRESA_IDEMPRESA, empresa.idEmpresa, DbType.Int32),
                    new Parametro(PLAN_IDPLAN, empresa.Oferta.idPlan, DbType.Int32),
                    new Parametro(PLAN_VIGENCIAPLAN, empresa.Oferta.vigenciaPlan, DbType.Int32),
                    new Parametro(PLAN_NUMEROOFERTAS, empresa.Oferta.numeroOfertas, DbType.Int32),
                    new Parametro(PLAN_VALORPLAN, empresa.Oferta.valorPlan, DbType.Int32),
            };
                this.EjecutarStoredProcedure(EMPRESA_PLANESADQUIRIDOS, valParam);

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
        public List<EmpresaVO> TraeEmpresas(EmpresaVO empresa)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    //Se adicionan los parametros para la busqueda del objeto
                    new Parametro(EMPRESA_IDUSUARIO, empresa.idUsuario, DbType.Int32)

                };

                DataTable dt = this.EjecutarStoredProcedureDataTable(EMPRESA_TRAEDATOSEMPRESASAPROBAR, valParam);

                List<EmpresaVO> rEmpresa = new List<EmpresaVO>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        EmpresaVO persona = new EmpresaVO();
                        persona.idEmpresa = Convert.ToInt32(dr[EMPRESA_IDEMPRESA]);
                        persona.idUsuario = Convert.ToInt32(dr[EMPRESA_IDUSUARIO]);
                        persona.nomEmpresa = Convert.ToString(dr[EMPRESA_NOMEMPRESA]);
                        persona.idTipoIde = Convert.ToInt32(dr[EMPRESA_IDTIPOIDE]);
                        persona.numeroIde = Convert.ToString(dr[EMPRESA_NUMEROIDE]);
                        persona.idSectorEconomico = dr[EMPRESA_IDSECTORECONOMICO] == Convert.DBNull ? intNull : Convert.ToInt32(dr[EMPRESA_IDSECTORECONOMICO]);
                        persona.idActividadEconomica = dr[EMPRESA_IDACTIVIDADECONOMICA] == Convert.DBNull ? intNull : Convert.ToInt32(dr[EMPRESA_IDACTIVIDADECONOMICA]);
                        persona.idDepartamentoEmpresa = dr[EMPRESA_IDDEPARTAMENTODEMPRESA] == Convert.DBNull ? intNull : Convert.ToInt32(dr[EMPRESA_IDDEPARTAMENTODEMPRESA]);
                        persona.idCiudadEmpresa = dr[EMPRESA_IDDEPARTAMENTODEMPRESA] == Convert.DBNull ? intNull : Convert.ToInt32(dr[EMPRESA_IDDEPARTAMENTODEMPRESA]);     
                        persona.NomCiudadEmpresa = Convert.ToString(dr[EMPRESA_NOMCIUDAD]);
                        persona.correoElectronico = Convert.ToString(dr[EMPRESA_CORREOELECTRONICO]);
                        persona.telefono = Convert.ToString(dr[EMPRESA_TELEFONO]);
                        persona.direccion = Convert.ToString(dr[EMPRESA_DIRECCION]);
                        persona.idTipoIdeRepLegal = dr[EMPRESA_IDTIPOIDEREPLEGAL] == Convert.DBNull ? intNull : Convert.ToInt32(dr[EMPRESA_IDTIPOIDEREPLEGAL]);
                        persona.numIdeRepLegal = dr[EMPRESA_NUMIDEREPLEGAL] == Convert.DBNull ? intNull : Convert.ToInt32(dr[EMPRESA_NUMIDEREPLEGAL]);
                        persona.nomRepLegal = Convert.ToString(dr[EMPRESA_NOMREPLEGAL]);
                        persona.telRepLegal = Convert.ToString(dr[EMPRESA_TELREPLEGAL]);
                        persona.camaraComercio = dr[EMPRESA_CAMARACOMERCIO] == Convert.DBNull ? boolNull : Convert.ToBoolean(dr[EMPRESA_CAMARACOMERCIO]);
                        persona.rut = dr[EMPRESA_RUT] == Convert.DBNull ? boolNull : Convert.ToBoolean(dr[EMPRESA_RUT]);
                        persona.completaDatos = dr[EMPRESA_COMPLETADATOS] == Convert.DBNull ? boolNull : Convert.ToBoolean(dr[EMPRESA_COMPLETADATOS]);
                        persona.fechaCrea = dr[EMPRESA_FECHACREA] == Convert.DBNull ? dateNull : Convert.ToDateTime(dr[EMPRESA_FECHACREA]);
                        persona.paquetesActivos = Convert.ToInt32(dr[EMPRESA_PAQUETESACTIVOS]);
                        persona.estado = Convert.ToString(dr[EMPRESA_ESTADO]);
                        rEmpresa.Add(persona);
                    }
                }
                return rEmpresa;
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
        public void AprobarEmpresas(EmpresaVO Empresa)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    new Parametro(EMPRESA_IDUSUARIO, Empresa.idUsuario, DbType.Int32),
                    new Parametro(EMPRESA_IDEMPRESA, Empresa.idEmpresa, DbType.Int32),
                    new Parametro(EMPRESA_ESTADO, Empresa.estado, DbType.String),
                    new Parametro(EMPRESA_OBSERVACION, Empresa.observacion, DbType.String),
            };
                this.EjecutarStoredProcedure(EMPRESA_APROBAREMPRESA, valParam);

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
        public void GuardarDatosEmpresa(EmpresaVO Empresa)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    new Parametro(EMPRESA_IDUSUARIO, Empresa.idUsuario, DbType.Int32),
                    new Parametro(EMPRESA_FASE, Empresa.fase, DbType.Int32),
                    new Parametro(EMPRESA_NOMEMPRESA, Empresa.nomEmpresa, DbType.String),
                    new Parametro(EMPRESA_IDTIPOIDE, Empresa.idTipoIde, DbType.Int32),
                    new Parametro(EMPRESA_NUMEROIDE, Empresa.numeroIde, DbType.String),
                    new Parametro(EMPRESA_IDSECTORECONOMICO, Empresa.idSectorEconomico, DbType.Int32),
                    new Parametro(EMPRESA_IDACTIVIDADECONOMICA, Empresa.idActividadEconomica, DbType.Int32),
                    new Parametro(EMPRESA_IDDEPARTAMENTODEMPRESA, Empresa.idDepartamentoEmpresa, DbType.Int32),
                    new Parametro(EMPRESA_IDCIUDADEMPRESA, Empresa.idCiudadEmpresa, DbType.Int32),
                    new Parametro(EMPRESA_DIRECCION, Empresa.direccion, DbType.String),
                    new Parametro(EMPRESA_TELEFONO, Empresa.telefono, DbType.String),
                    new Parametro(EMPRESA_IDTIPOIDEREPLEGAL, Empresa.idTipoIdeRepLegal, DbType.Int32),
                    new Parametro(EMPRESA_NUMIDEREPLEGAL, Empresa.numIdeRepLegal, DbType.Int32),
                    new Parametro(EMPRESA_NOMREPLEGAL, Empresa.nomRepLegal, DbType.String),
                    new Parametro(EMPRESA_TELREPLEGAL, Empresa.telRepLegal, DbType.String),
                    new Parametro(EMPRESA_CAMARACOMERCIO, Empresa.camaraComercio, DbType.Boolean),
                    new Parametro(EMPRESA_RUT, Empresa.rut, DbType.Boolean),
                    new Parametro(EMPRESA_RUTAAVATAR, Empresa.rutaAvatar, DbType.String),
            };
               this.EjecutarStoredProcedure(EMPRESA_DATOSEMPRESAGUARDAR, valParam);
                
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
        /// <summary>
        /// Buscar una persona dado el Empresa y la identificacion
        /// </summary>
        /// <param name="ppersona"></param>
        /// <returns></returns>

        public EmpresaVO DatosEmpresa(EmpresaVO Empresa)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    new Parametro(EMPRESA_IDUSUARIO, Empresa.idUsuario, DbType.Int32),

                };
                DataRow dr = this.EjecutarStoredProcedureDataRow(EMPRESA_DATOSEMPRESABUSCAR, valParam);
                if (dr != null)
                    return cargarVO(dr);
                else
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
        //public EmpresaVO Buscar_personaId(EmpresaVO ppersona)
        //{
        //    try
        //    {
        //        Parametro[] valParam = new Parametro[]
        // {
        //    new Parametro(PERSONA_IDPERSONA, ppersona.IdPersona, DbType.Int32),
        //    };
        //        DataRow dr = this.EjecutarStoredProcedureDataRow(PERSONA_BUSCARID, valParam);

        //        if (dr != null)
        //            return cargarVO(dr);

        //        return null;
        //    }
        //    catch (System.Data.SqlClient.SqlException e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}
        //public List<EmpresaVO> Buscar_personaDatosModificados(EmpresaVO ppersona)
        //{
        //    try
        //    {
        //        Parametro[] valParam = new Parametro[]
        //        {
        //            new Parametro(PERSONA_IDPERSONA, ppersona.IdPersona, DbType.Int32),
        //        };
        //        DataTable dt = this.EjecutarStoredProcedureDataTable(PERSONA_BUSCARDATOSMODIFICADOS, valParam);

        //        List<EmpresaVO> rPersona = null;

        //        if (dt.Rows.Count > 0)
        //        {
        //            rPersona = new List<EmpresaVO>();

        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                EmpresaVO persona = new EmpresaVO();

        //                persona.IdEmpresa = Convert.ToInt32(dr[PERSONA_IDEMPRESA]);
        //                persona.IdPersona = Convert.ToInt32(dr[PERSONA_IDPERSONA]);
        //                if (dr.Table.Columns.Contains(PERSONA_IDPERSONAMODIFICADO))
        //                {
        //                    persona.IdPersonaModificado = dr[PERSONA_IDPERSONAMODIFICADO] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPERSONAMODIFICADO]);
        //                }
        //                persona.TipIdentificacion = Convert.ToInt32(dr[PERSONA_TIPIDENTIFICACION]);
        //                persona.NumIdentificacion = Convert.ToString(dr[PERSONA_NUMIDENTIFICACION]);
        //                persona.Nombres = Convert.ToString(dr[PERSONA_NOMBRES]);
        //                persona.Apellidos = Convert.ToString(dr[PERSONA_APELLIDOS]);
        //                persona.IdProfesion = dr[PERSONA_IDPROFESION] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPROFESION]);
        //                persona.Empresa = Convert.ToString(dr[PERSONA_EMPRESA]);
        //                persona.CargoPersona = Convert.ToString(dr[PERSONA_CARGOPERSONA]);
        //                persona.Correo = Convert.ToString(dr[PERSONA_CORREO]);
        //                persona.NumCelular = Convert.ToString(dr[PERSONA_NUMCELULAR]);
        //                persona.DireccionResidencia = Convert.ToString(dr[PERSONA_DIRECCIONRESIDENCIA]);
        //                persona.BarrioResidencia = Convert.ToString(dr[PERSONA_BARRIORESIDENCIA]);
        //                persona.TelefonoResidencia = Convert.ToString(dr[PERSONA_TELEFONORESIDENCIA]);
        //                persona.IdPaisResidencia = dr[PERSONA_IDPAISRESIDENCIA] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPAISRESIDENCIA]);
        //                persona.IdProvinciaResidencia = dr[PERSONA_IDPROVINCIARESIDENCIA] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPROVINCIARESIDENCIA]);
        //                persona.IdCiudadResidencia = dr[PERSONA_IDCIUDADRESIDENCIA] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDCIUDADRESIDENCIA]);
        //                persona.nomPaisResidencia = Convert.ToString(dr[PERSONA_NOMPAISRESIDENCIA]);
        //                persona.nomProvinciaResidencia = Convert.ToString(dr[PERSONA_NOMPROVINCIARESIDENCIA]);
        //                persona.nomCiudadResidencia = Convert.ToString(dr[PERSONA_NOMCIUDADRESIDENCIA]);
        //                persona.DireccionLaboral = Convert.ToString(dr[PERSONA_DIRECCIONLABORAL]);
        //                persona.BarrioLaboral = Convert.ToString(dr[PERSONA_BARRIOLABORAL]);
        //                persona.TelefonoLaboral = Convert.ToString(dr[PERSONA_TELEFONOLABORAL]);
        //                persona.IdPaisLaboral = dr[PERSONA_IDPAISLABORAL] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPAISLABORAL]);
        //                persona.IdProvinciaLaboral = dr[PERSONA_IDPROVINCIALABORAL] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDPROVINCIALABORAL]);
        //                persona.IdCiudadLaboral = dr[PERSONA_IDCIUDADLABORAL] == Convert.DBNull ? intNull : Convert.ToInt32(dr[PERSONA_IDCIUDADLABORAL]);
        //                persona.nomPaisLaboral = Convert.ToString(dr[PERSONA_NOMPAISLABORAL]);
        //                persona.nomProvinciaLaboral = Convert.ToString(dr[PERSONA_NOMPROVINCIALABORAL]);
        //                persona.nomCiudadLaboral = Convert.ToString(dr[PERSONA_NOMCIUDADLABORAL]);
        //                persona.UsuarioCrea = Convert.ToString(dr[PERSONA_USUARIOCREA]);
        //                persona.FechaCrea = Convert.ToDateTime(dr[PERSONA_FECHACREA]);
        //                persona.UsuarioModifica = Convert.ToString(dr[PERSONA_USUARIOMODIFICA]);
        //                persona.FechaModifica = dr[PERSONA_FECHAMODIFICA] == Convert.DBNull ? dateNull : Convert.ToDateTime(dr[PERSONA_FECHAMODIFICA]);
        //                rPersona.Add(persona);
        //            }
        //        }

        //        return rPersona;
        //    }
        //    catch (System.Data.SqlClient.SqlException e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}
        //public void Guardar_persona(EmpresaVO persona)
        //{
        //    try
        //    {
        //        Parametro[] valParam = new Parametro[]
        //        {

        //            new Parametro(PERSONA_TIPOPERSONA, persona.TipoPersona, DbType.Int32),
        //            new Parametro(PERSONA_IDEMPRESA, persona.IdEmpresa, DbType.Int32),
        //            new Parametro(PERSONA_IDPERSONA, persona.IdPersona, DbType.Int32),
        //            new Parametro(PERSONA_TIPIDENTIFICACION, persona.TipIdentificacion, DbType.Int32),
        //            new Parametro(PERSONA_NUMIDENTIFICACION, persona.NumIdentificacion, DbType.String),
        //            new Parametro(PERSONA_NOMBRES, persona.Nombres, DbType.String),
        //            new Parametro(PERSONA_APELLIDOS, persona.Apellidos, DbType.String),
        //            new Parametro(PERSONA_IDPROFESION, persona.IdProfesion, DbType.Int32),
        //            new Parametro(PERSONA_EMPRESA, persona.Empresa, DbType.String),
        //            new Parametro(PERSONA_CARGOPERSONA, persona.CargoPersona, DbType.String),
        //            new Parametro(PERSONA_CORREO, persona.Correo, DbType.String),
        //            new Parametro(PERSONA_NUMCELULAR, persona.NumCelular, DbType.String),
        //            new Parametro(PERSONA_DIRECCIONRESIDENCIA, persona.DireccionResidencia, DbType.String),
        //            new Parametro(PERSONA_BARRIORESIDENCIA, persona.BarrioResidencia, DbType.String),
        //            new Parametro(PERSONA_TELEFONORESIDENCIA, persona.TelefonoResidencia, DbType.String),
        //            new Parametro(PERSONA_IDPAISRESIDENCIA, persona.IdPaisResidencia, DbType.Int32),
        //            new Parametro(PERSONA_IDPROVINCIARESIDENCIA, persona.IdProvinciaResidencia, DbType.Int32),
        //            new Parametro(PERSONA_IDCIUDADRESIDENCIA, persona.IdCiudadResidencia, DbType.Int32),
        //            new Parametro(PERSONA_DIRECCIONLABORAL, persona.DireccionLaboral, DbType.String),
        //            new Parametro(PERSONA_BARRIOLABORAL, persona.BarrioLaboral, DbType.String),
        //            new Parametro(PERSONA_TELEFONOLABORAL, persona.TelefonoLaboral, DbType.String),
        //            new Parametro(PERSONA_IDPAISLABORAL, persona.IdPaisLaboral, DbType.Int32),
        //            new Parametro(PERSONA_IDPROVINCIALABORAL, persona.IdProvinciaLaboral, DbType.Int32),
        //            new Parametro(PERSONA_IDCIUDADLABORAL, persona.IdCiudadLaboral, DbType.Int32),
        //            new Parametro(PERSONA_USUARIOCREA, persona.UsuarioCrea, DbType.String),
        //            new Parametro(PERSONA_USUARIOMODIFICA, persona.UsuarioModifica, DbType.String),
        //            };
        //        this.EjecutarStoredProcedure(PERSONA_GRABAR, valParam);
        //    }
        //    catch (System.Data.SqlClient.SqlException e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}


        #endregion

        #region  [Metodos Privados]

        private EmpresaVO cargarVO(DataRow dr)
        {
            EmpresaVO persona = new EmpresaVO();

            persona.idEmpresa = Convert.ToInt32(dr[EMPRESA_IDEMPRESA]);
            persona.idUsuario = Convert.ToInt32(dr[EMPRESA_IDUSUARIO]);
            persona.nomEmpresa = Convert.ToString(dr[EMPRESA_NOMEMPRESA]);
            persona.idTipoIde = Convert.ToInt32(dr[EMPRESA_IDTIPOIDE]);
            persona.numeroIde = Convert.ToString(dr[EMPRESA_NUMEROIDE]);
            persona.idSectorEconomico = dr[EMPRESA_IDSECTORECONOMICO] == Convert.DBNull ? intNull : Convert.ToInt32(dr[EMPRESA_IDSECTORECONOMICO]); 
            persona.idActividadEconomica = dr[EMPRESA_IDACTIVIDADECONOMICA] == Convert.DBNull ? intNull : Convert.ToInt32(dr[EMPRESA_IDACTIVIDADECONOMICA]);
            persona.idDepartamentoEmpresa = dr[EMPRESA_IDDEPARTAMENTODEMPRESA] == Convert.DBNull ? intNull : Convert.ToInt32(dr[EMPRESA_IDDEPARTAMENTODEMPRESA]);
            persona.idCiudadEmpresa = dr[EMPRESA_IDCIUDADEMPRESA] == Convert.DBNull ? intNull : Convert.ToInt32(dr[EMPRESA_IDCIUDADEMPRESA]);
            persona.correoElectronico = Convert.ToString(dr[EMPRESA_CORREOELECTRONICO]);
            persona.NomCiudadEmpresa = Convert.ToString(dr[EMPRESA_NOMCIUDAD]);
            persona.telefono =  Convert.ToString(dr[EMPRESA_TELEFONO]);
            persona.direccion = Convert.ToString(dr[EMPRESA_DIRECCION]);
            persona.idTipoIdeRepLegal = dr[EMPRESA_IDTIPOIDEREPLEGAL] == Convert.DBNull ? intNull : Convert.ToInt32(dr[EMPRESA_IDTIPOIDEREPLEGAL]);
            persona.numIdeRepLegal = dr[EMPRESA_NUMIDEREPLEGAL] == Convert.DBNull ? intNull : Convert.ToInt32(dr[EMPRESA_NUMIDEREPLEGAL]);
            persona.nomRepLegal = Convert.ToString(dr[EMPRESA_NOMREPLEGAL]);
            persona.telRepLegal = Convert.ToString(dr[EMPRESA_TELREPLEGAL]);
            persona.camaraComercio = dr[EMPRESA_CAMARACOMERCIO] == Convert.DBNull ? boolNull : Convert.ToBoolean(dr[EMPRESA_CAMARACOMERCIO]);
            persona.rut = dr[EMPRESA_RUT] == Convert.DBNull ? boolNull : Convert.ToBoolean(dr[EMPRESA_RUT]);
            persona.completaDatos = dr[EMPRESA_COMPLETADATOS] == Convert.DBNull ? boolNull : Convert.ToBoolean(dr[EMPRESA_COMPLETADATOS]);
            persona.fechaCrea = dr[EMPRESA_FECHACREA] == Convert.DBNull ? dateNull : Convert.ToDateTime(dr[EMPRESA_FECHACREA]);
            persona.paquetesActivos = Convert.ToInt32(dr[EMPRESA_PAQUETESACTIVOS]);
            
            return persona;

        }

        #endregion


    }

}

