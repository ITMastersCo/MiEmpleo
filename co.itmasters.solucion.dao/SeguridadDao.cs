using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using co.itmasters.solucion.vo;
using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;
using Microsoft.Win32;

namespace co.itmasters.solucion.dao
{
    public class SeguridadDao : BaseDao
    {
        #region [Constants]

        //DECLARA PROCEDIMIENTOS 
        private const String SEGURIDAD_VALIDARUSUARIO = "SeguridadValidarUsuario";
        private const String SEGURIDAD_GETUSUARIO = "SeguridadBuscarUsuario";
        private const String SEGURIDAD_RESTABLECECONTRASENA = "SeguridadRestableceContrasena";
        private const String SEGURIDAD_ACTUALIZACONTRASENA = "SeguridadActualizaContrasena";  
        private const String SEGURIDAD_VALIDARTOKEN = "SeguridadValidaToken";
        private const String SEGURIDAD_REGISTROUSUARIOEMPRESA = "SeguridadRegistroEmpresa";
        private const String SEGURIDAD_REGISTROUSUARIOTOKENEMPRESA = "SeguridadRegistroTokenEmpresa";  
        private const String SEGURIDAD_REGISTROPERSONAS = "SeguridadRegistroPersonas";
        private const String SEGURIDAD_ENVIARRESPUESTAS = "sp_Seguridad_EnviarRespuestas";
        private const String SEGURIDAD_BUSCARPREGUNTAS = "SeguridadBuscarPreguntas";
        private const String SEGURIDAD_BASICAS_CREDENCIALES = "SeguridadBasicas_Credenciales";

        // Constantes Entidad Seguridad
        public const string SEGURIDAD_NOMBREUSUARIO = "nombreUsuario";
        public const string SEGURIDAD_CLAVE = "clave";

        //Constantes para cargar VO Usuario
        public const string SEGURIDAD_IDEMPRESA = "idEmpresa";
        public const string SEGURIDAD_NOMEMPRESA= "nomEmpresa";
        public const string SEGURIDAD_NOMEMPRESA2 = "nomEmpresa2";
        public const string SEGURIDAD_WEBSITE = "webSite";
        public const string SEGURIDAD_DOMINIO = "dominio";
        public const string SEGURIDAD_IDUSUARIO = "idUsuario";
        public const string SEGURIDAD_TIPIDENTIFICACION = "tipIdentificacion";
        public const string SEGURIDAD_NUMIDENTIFICACION = "numIdentificacion";
        public const string SEGURIDAD_NOMBRE1 = "nombre1";
        public const string SEGURIDAD_NOMBRE2 = "nombre2";
        public const string SEGURIDAD_APELLIDO1 = "apellido1";
        public const string SEGURIDAD_APELLIDO2 = "apellido2";
        public const string SEGURIDAD_NOMBRECOMPLETO = "nombreCompleto";  
        public const string SEGURIDAD_TIPOMITADPERIODO = "tipoMitadPeriodo";
        public const string SEGURIDAD_ESADMON = "esAdmon";
        public const string SEGURIDAD_AVATAR = "avatar";
        public const string SEGURIDAD_TIPOUSUARIO = "tipoUsuario";
        public const string SEGURIDAD_DILIGENCIAFORMULARIO = "diligenciaFormulario";
        public const string SEGURIDAD_TOKEN = "token";
        public const string SEGURIDAD_PASSWORD1 = "password1";
        public const string SEGURIDAD_PASSWORD2 = "password2";

        //Constantes para cargar VO Rol
        public const string ROL_IDROL = "idRol";
        public const string ROL_NOMBRE = "nombreRol";

        //Constantes para cargar VO Formulario
        public const string FORMULARIO_IDFORMULARIO = "IdFormulario";
        public const string FORMULARIO_NOMFORMULARIO = "NomFormulario";
        public const string FORMULARIO_DIRECCION = "Direccion";
        public const string FORMULARIO_IDPADRE = "IdPadre";
        public const string FORMULARIO_VISIBLE = "Visible";
        public const string FORMULARIO_RUTAICONO = "rutaIcono";
        

        //Constantes para cargar Preguntas para restaurar clave
        public const string PREGUNTA_IDPREGUNTA = "idPregunta";
        public const string PREGUNTA_DESPREGUNTA = "desPregunta";
        public const string PREGUNTA_VALORRESPUESTA1 = "valorRespuesta1";
        public const string PREGUNTA_VALORRESPUESTA2 = "valorRespuesta2";
        public const string PREGUNTA_VALORRESPUESTA3 = "valorRespuesta3";
        public const string PREGUNTA_RESPUESTA1 = "Respuesta1";
        public const string PREGUNTA_RESPUESTA2 = "Respuesta2";
        public const string PREGUNTA_RESPUESTA3 = "Respuesta3";
        public const string PREGUNTA_IDPREGUNTA1RETORNAR = "idPreguntaRetornar1";
        public const string PREGUNTA_IDPREGUNTA2RETORNAR = "idPreguntaRetornar2";
        public const string PREGUNTA_IDPREGUNTA3RETORNAR = "idPreguntaRetornar3";
        public const string PREGUNTA_NUMRESPUESTASINCORRECTAS = "numRespuestasIncorrectas";


        //contante de credenciales 
        public const string CREDENCIALES_ID = "id";
        public const string CREDENCIALES_SERVICIO = "valor";
        public const string CREDENCIALES_NOMBRE = "nombre";
        public const string CREDENCIALES_VALOR = "valor";


        #endregion

        #region  [Metodos Expuestos]



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CredencialesVO> GetCredenciales(int idUser)
        {

            try
            {
                Parametro[] valParam = new Parametro[]
                {
                     new Parametro(SEGURIDAD_IDUSUARIO, idUser , DbType.Int32),
                };
                DataTable dt = this.EjecutarStoredProcedureDataTable(SEGURIDAD_BASICAS_CREDENCIALES, valParam);
                List<CredencialesVO> rPersona = new List<CredencialesVO>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        CredencialesVO credencial = new CredencialesVO();
                        credencial.id = Convert.ToString(dr[CREDENCIALES_ID]);
                        credencial.nombre = Convert.ToString(dr[CREDENCIALES_NOMBRE]);
                        credencial.servicio = Convert.ToString(dr[CREDENCIALES_SERVICIO]);
                        credencial.valor = Convert.ToString(dr[CREDENCIALES_VALOR]);
                        
                        rPersona.Add(credencial);
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
        /// <summary>
        /// Se Actualiza en log de tredenciales del usuario para el acceso temporal.
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <param name="clave"></param>
        /// <returns></returns>
        /// 
        public void RegistroUsuarioTokenEmpresa(UsuarioVO Actor)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                   {
                         new Parametro(SEGURIDAD_NOMBREUSUARIO, Actor.NomUsuario, DbType.String),
                         new Parametro(SEGURIDAD_NUMIDENTIFICACION, Actor.NumIdentificacion, DbType.String),
                         new Parametro(SEGURIDAD_TIPOUSUARIO, Actor.tipoUsuario, DbType.Int32),
                         new Parametro(SEGURIDAD_TOKEN, Actor.Token, DbType.String),
                   };
                this.EjecutarStoredProcedure(SEGURIDAD_REGISTROUSUARIOTOKENEMPRESA, valParam);
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
        public void RegistroUsuarioEmpresa(UsuarioVO Actor)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                   {

                         new Parametro(SEGURIDAD_NOMBREUSUARIO, Actor.NomUsuario, DbType.String),
                         new Parametro(SEGURIDAD_NUMIDENTIFICACION, Actor.NumIdentificacion, DbType.String),
                         new Parametro(SEGURIDAD_PASSWORD1, Actor.pasword1, DbType.String),
                         new Parametro(SEGURIDAD_PASSWORD2, Actor.pasword2, DbType.String),
            };
                this.EjecutarStoredProcedure(SEGURIDAD_REGISTROUSUARIOEMPRESA, valParam);
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
        public void RegistroUsuarioCandidato(UsuarioVO Actor)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                   {

                         new Parametro(SEGURIDAD_TIPOUSUARIO, Actor.tipoUsuario, DbType.Int32),
                         new Parametro(SEGURIDAD_TIPIDENTIFICACION, Actor.TipIdentificacion, DbType.Int32),
                         new Parametro(SEGURIDAD_NUMIDENTIFICACION, Actor.NumIdentificacion, DbType.String),
                         new Parametro(SEGURIDAD_NOMBREUSUARIO, Actor.NomUsuario, DbType.String),
                         new Parametro(SEGURIDAD_PASSWORD1, Actor.pasword1, DbType.String),
                         new Parametro(SEGURIDAD_PASSWORD2, Actor.pasword2, DbType.String),


                   };
                this.EjecutarStoredProcedure(SEGURIDAD_REGISTROPERSONAS, valParam);
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

        public void ActualizaContrasena(UsuarioVO Actor)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                   {

                         new Parametro(SEGURIDAD_TIPOUSUARIO, Actor.tipoUsuario, DbType.Int32),
                         new Parametro(SEGURIDAD_NUMIDENTIFICACION, Actor.NumIdentificacion, DbType.String),
                         new Parametro(SEGURIDAD_PASSWORD1, Actor.pasword1, DbType.String),
                         new Parametro(SEGURIDAD_PASSWORD2, Actor.pasword2, DbType.String),
                         
                         
                   };
                this.EjecutarStoredProcedure(SEGURIDAD_ACTUALIZACONTRASENA, valParam);
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
        /// Se valida eltoken del usuario sean correctas.
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <param name="clave"></param>
        /// <returns></returns>
        /// 
        public Boolean validarToken(UsuarioVO token)
        {
            try
            {
                bool validarNulo = false;
                Parametro[] valParam = new Parametro[]
                   {
                         new Parametro(SEGURIDAD_TOKEN, token.Token, DbType.String),
                         new Parametro(SEGURIDAD_TIPOUSUARIO, token.tipoUsuario, DbType.Int32),
                         new Parametro(SEGURIDAD_NUMIDENTIFICACION, token.NumIdentificacion, DbType.String),
                   };

                DataRow dr = this.EjecutarStoredProcedureDataRow(SEGURIDAD_VALIDARTOKEN, valParam);
                UsuarioVO _Usuario = new UsuarioVO();
                if (dr != null)
                {
                    _Usuario.IdUsuario = Convert.ToInt32(dr[SEGURIDAD_IDUSUARIO]);
                    if (_Usuario.IdUsuario > 0)
                    {
                        validarNulo = true;
                       
                    }
                    else
                        
                    validarNulo = false;
                }


                return validarNulo;

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
        /// Se valida que las credenciales del usuario sean correctas.
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <param name="clave"></param>
        /// <returns></returns>
        /// 
        public void RestablecerContrasena(UsuarioVO Actor)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                   {
                       
                         new Parametro(SEGURIDAD_TIPOUSUARIO, Actor.tipoUsuario, DbType.Int32),
                         new Parametro(SEGURIDAD_NUMIDENTIFICACION, Actor.NumIdentificacion, DbType.String),
                         new Parametro(SEGURIDAD_NOMBREUSUARIO, Actor.NomUsuario, DbType.String),
                         new Parametro(SEGURIDAD_TOKEN, Actor.Token, DbType.String)
                   };
                this.EjecutarStoredProcedure(SEGURIDAD_RESTABLECECONTRASENA, valParam);
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
        public Boolean validarUsuario(String nombreUsuario, String clave)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                   { 
                         new Parametro(SEGURIDAD_NOMBREUSUARIO, nombreUsuario, DbType.String),
                         new Parametro(SEGURIDAD_CLAVE, clave, DbType.String)
                   };

                DataRow dr = this.EjecutarStoredProcedureDataRow(SEGURIDAD_VALIDARUSUARIO, valParam);

                if (dr != null)
                    return true;
                else
                    return false;

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
        /// Se obtiene la informacion del usuario. Una vez se ha autenticado.
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <returns></returns>
        public UsuarioVO getUsuario(String nombreUsuario)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                   { 
                         new Parametro(SEGURIDAD_NOMBREUSUARIO, nombreUsuario, DbType.String),
                         
                   };

                DataSet ds = this.EjecutarStoredProcedureDataSet(SEGURIDAD_GETUSUARIO, valParam);
                UsuarioVO item = this.CargaUsuarioVO(ds.Tables[0].Rows[0]);
                List<RolVO> roles = this.CargaRolVO(ds.Tables[1]);
                List<FormularioVO> formularios = this.CargaFormularioVO(ds.Tables[2]);
                item.Rol = roles;
                item.Formulario = formularios;
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

        /// <summary>
        /// Se obtiene la informacion del usuario. Una vez se ha autenticado.
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <returns></returns>
        public List<UsuarioVO> buscarPreguntas(UsuarioVO Usuario)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                   { 
                         new Parametro(SEGURIDAD_NOMBREUSUARIO, Usuario.NomUsuario, DbType.String)
                   };

                DataSet ds = this.EjecutarStoredProcedureDataSet(SEGURIDAD_BUSCARPREGUNTAS, valParam);
                List<UsuarioVO> item = this.CargaPreguntas(ds.Tables[0]);
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

        /// <summary>
        /// Se obtiene la informacion del usuario. Una vez se ha autenticado.
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <returns></returns>
        public List<UsuarioVO> EnviarRespuestas(UsuarioVO Usuario)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                   { 
                         new Parametro(SEGURIDAD_NOMBREUSUARIO, Usuario.NomUsuario, DbType.String),
                         new Parametro(PREGUNTA_IDPREGUNTA1RETORNAR, Usuario.idPregunta1Retornar, DbType.Int32),
                         new Parametro(PREGUNTA_IDPREGUNTA2RETORNAR, Usuario.idPregunta2Retornar, DbType.Int32),
                         new Parametro(PREGUNTA_IDPREGUNTA3RETORNAR, Usuario.idPregunta3Retornar, DbType.Int32),
                         new Parametro(PREGUNTA_RESPUESTA1, Usuario.respuesta1, DbType.String),
                         new Parametro(PREGUNTA_RESPUESTA2, Usuario.respuesta2, DbType.String),
                         new Parametro(PREGUNTA_RESPUESTA3, Usuario.respuesta3, DbType.String),
                         new Parametro(PREGUNTA_VALORRESPUESTA1, Usuario.valorRespuesta1, DbType.Int32),
                         new Parametro(PREGUNTA_VALORRESPUESTA2, Usuario.valorRespuesta2, DbType.Int32),
                         new Parametro(PREGUNTA_VALORRESPUESTA3, Usuario.valorRespuesta3, DbType.Int32),
                   };

                DataSet ds = this.EjecutarStoredProcedureDataSet(SEGURIDAD_ENVIARRESPUESTAS, valParam);
                List<UsuarioVO> retorno = new List<UsuarioVO>();
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["Resultado"]) == 1)
                {
                    UsuarioVO item = new UsuarioVO();
                    item.resultadoEnvioRespuestas = 1;
                    retorno.Add(item);

                }
                else
                {
                    retorno = this.CargaPreguntas(ds.Tables[1]);
                    retorno[0].resultadoEnvioRespuestas = 0;
                }
                return retorno;
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

        private List<UsuarioVO> CargaPreguntas(DataTable dt)
        {
            //  Generando Metodo
            if (dt == null)
                return null;

            List<UsuarioVO> Preguntas = new List<UsuarioVO>();

            foreach (DataRow dr in dt.Rows)
            {
                UsuarioVO Pregunta = new UsuarioVO();
                Pregunta.idPregunta = Convert.ToInt32(dr[PREGUNTA_IDPREGUNTA]);
                Pregunta.desPregunta = Convert.ToString(dr[PREGUNTA_DESPREGUNTA]);
                Pregunta.valorRespuesta1 = Convert.ToInt32(dr[PREGUNTA_VALORRESPUESTA1]);
                Pregunta.valorRespuesta2 = Convert.ToInt32(dr[PREGUNTA_VALORRESPUESTA2]);
                Pregunta.valorRespuesta3 = Convert.ToInt32(dr[PREGUNTA_VALORRESPUESTA3]);
                Pregunta.respuesta1 = Convert.ToString(dr[PREGUNTA_RESPUESTA1]);
                Pregunta.respuesta2 = Convert.ToString(dr[PREGUNTA_RESPUESTA2]);
                Pregunta.respuesta3 = Convert.ToString(dr[PREGUNTA_RESPUESTA3]);
                Pregunta.numRespuestasIncorrectas = Convert.ToInt32(dr[PREGUNTA_NUMRESPUESTASINCORRECTAS]);                
                Preguntas.Add(Pregunta);
            }
            return Preguntas;
        }

        public UsuarioVO CargaUsuarioVO(DataRow dr)
        {
            //  Generando Metodo
            if (dr == null)
                return null;

            UsuarioVO retorno = new UsuarioVO();
            retorno.IdUsuario = Convert.ToInt32(dr[SEGURIDAD_IDUSUARIO]);
            retorno.NomUsuario = Convert.ToString(dr[SEGURIDAD_NOMBREUSUARIO]);
            retorno.TipIdentificacion = Convert.ToInt32(dr[SEGURIDAD_TIPIDENTIFICACION]);
            retorno.NumIdentificacion = Convert.ToString(dr[SEGURIDAD_NUMIDENTIFICACION]);
            retorno.NombreCompleto = Convert.ToString(dr[SEGURIDAD_NOMBRECOMPLETO]);
            retorno.esAdmon = Convert.ToInt32(dr[SEGURIDAD_ESADMON]);
            retorno.Avatar = Convert.ToString(dr[SEGURIDAD_AVATAR]);
            retorno.WebSite = Convert.ToString(dr[SEGURIDAD_WEBSITE]);
            retorno.tipoUsuario = Convert.ToInt32(dr[SEGURIDAD_TIPOUSUARIO]);
            retorno.diligenciaFormulario = Convert.ToInt32(dr[SEGURIDAD_DILIGENCIAFORMULARIO]);
            return retorno;
        }

        private List<RolVO> CargaRolVO(DataTable dt)
        {
            //  Generando Metodo
            if (dt == null)
                return null;

            List<RolVO> roles = new List<RolVO>();

            foreach (DataRow dr in dt.Rows) 
            {
                RolVO rol = new RolVO();
                rol.IdRol = Convert.ToInt32(dr[ROL_IDROL]);
                rol.Nombre = Convert.ToString(dr[ROL_NOMBRE]);
                roles.Add(rol);
            }
            return roles;
        }

        private List<FormularioVO> CargaFormularioVO(DataTable dt)
        {
            //  Generando Metodo
            if (dt == null)
                return null;

            List<FormularioVO> formularios = new List<FormularioVO>();

            foreach (DataRow dr in dt.Rows)
            {
                FormularioVO form = new FormularioVO();
                form.RutaIcono = Convert.ToString(dr[FORMULARIO_RUTAICONO]);
                form.IdFormulario = Convert.ToInt32(dr[FORMULARIO_IDFORMULARIO]);
                form.NomFormulario = Convert.ToString(dr[FORMULARIO_NOMFORMULARIO]);
                form.Direccion = Convert.ToString(dr[FORMULARIO_DIRECCION]);
                form.Visible = Convert.ToBoolean(dr[FORMULARIO_VISIBLE]);
                if (dr[FORMULARIO_IDPADRE] != System.DBNull.Value)
                    form.IdPadre = Convert.ToInt32(dr[FORMULARIO_IDPADRE]);
                
                //form.Visible = true;

                formularios.Add(form);
            }
            return formularios;
        }

        #endregion
    }
}
