using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using co.itmasters.solucion.vo;

namespace co.itmasters.solucion.dao
{
    public class FuncionarioDao : BaseDao
    {
        #region [StoredProcedures]

        public const string FUNCIONARIO_BUSCAR = "Funcionario_Buscar";
        public const string FUNCIONARIO_GRABAR = "Funcionario_Grabar";
        

        #endregion

        #region [Constantes Funcionario]

        public const string FUNCIONARIO_IDFUNCIONARIO = "idFuncionario";
        public const string FUNCIONARIO_IDEMPRESA= "idEmpresa";
        public const string FUNCIONARIO_IDUSUARIO = "idUsuario";

        //Se crean para manejar el usuario desde el funcionario.
        public const string FUNCIONARIO_DOMINIO = "dominio";
        public const string FUNCIONARIO_NOMBREUSUARIO = "nombreUsuario";
        public const string FUNCIONARIO_CLAVE = "clave";
        public const string FUNCIONARIO_IDROL = "idRol";
        //FIN

        public const string FUNCIONARIO_TIPIDENTIFICACION = "tipIdentificacion";
        public const string FUNCIONARIO_NUMIDENTIFICACION = "numIdentificacion";
        public const string FUNCIONARIO_IDPAISEXPEDICION = "idPaisExpedicion";
        public const string FUNCIONARIO_IDPROVINCIAEXPEDICION = "idProvinciaExpedicion";
        public const string FUNCIONARIO_IDCIUDADEXPEDICION = "idCiudadExpedicion";
        public const string FUNCIONARIO_FECHAEXPEDICION = "fechaExpedicion";
        public const string FUNCIONARIO_NOMBRE1 = "nombre1";
        public const string FUNCIONARIO_NOMBRE2 = "nombre2";
        public const string FUNCIONARIO_APELLIDO1 = "apellido1";
        public const string FUNCIONARIO_APELLIDO2 = "apellido2";
        public const string FUNCIONARIO_FECHANACIMIENTO = "fechaNacimiento";
        public const string FUNCIONARIO_IDPAISNACIMIENTO = "idPaisNacimiento";
        public const string FUNCIONARIO_IDPROVINCIANACIMIENTO = "idProvinciaNacimiento";
        public const string FUNCIONARIO_IDCIUDADNACIMIENTO = "idCiudadNacimiento";
        public const string FUNCIONARIO_IDSEXO = "idSexo";
        public const string FUNCIONARIO_IDRH = "idRH";
        public const string FUNCIONARIO_IDPROFESION = "idProfesion";
        public const string FUNCIONARIO_IDCARGO = "idCargo";
        public const string FUNCIONARIO_NOMCARGO = "nomCargo";
        public const string FUNCIONARIO_IDJEFE = "idJefe";
        public const string FUNCIONARIO_NOMJEFE = "nomJefe";
        public const string FUNCIONARIO_ESCALAFON = "escalafon";
        public const string FUNCIONARIO_RESESCALAFON = "resEscalafon";
        public const string FUNCIONARIO_FECHARESOLUCION = "fechaResolucion";
        public const string FUNCIONARIO_ESTADOCIVIL = "estadoCivil";
        public const string FUNCIONARIO_DIRECCIONRESIDENCIA = "direccionResidencia";
        public const string FUNCIONARIO_BARRIORESIDENCIA = "barrioResidencia";
        public const string FUNCIONARIO_TELEFONORESIDENCIA = "telefonoResidencia";
        public const string FUNCIONARIO_TELEFONOCELULAR = "telefonoCelular";
        public const string FUNCIONARIO_IDPAISRESIDENCIA = "idPaisResidencia";
        public const string FUNCIONARIO_IDPROVINCIARESIDENCIA = "idProvinciaResidencia";
        public const string FUNCIONARIO_IDCIUDADRESIDENCIA = "idCiudadResidencia";
        public const string FUNCIONARIO_CORREOELECTRONICO = "correoElectronico";
        public const string FUNCIONARIO_IDAFP = "idAFP";
        public const string FUNCIONARIO_IDEPS = "idEPS";
        public const string FUNCIONARIO_FECHAINGRESO = "fechaIngreso";
        public const string FUNCIONARIO_FECHARETIRO = "fechaRetiro";
        public const string FUNCIONARIO_IDESTRATO = "idEstrato";
        public const string FUNCIONARIO_IDTIPOCONTRATO = "idTipoContrato";
        public const string FUNCIONARIO_ESTADO = "estado";
        public const string FUNCIONARIO_NOTAS = "notas";
        public const string FUNCIONARIO_USUARIOCREA = "usuarioCrea";
        public const string FUNCIONARIO_FECHACREA = "fechaCrea";
        public const string FUNCIONARIO_USUARIOMODIFICA = "usuarioModifica";
        public const string FUNCIONARIO_FECHAMODIFICA = "fechaModifica";
        public const string FUNCIONARIO_OBSERVACIONES = "Observaciones"; 

        // Estudios
        public const string FUNCIONARIO_IDTIPOESTUDIO = "idTipoEstudio";
        public const string FUNCIONARIO_NOMBREESTUDIO = "nombreEstudio";
        public const string FUNCIONARIO_INSTITUCION = "institucion";
        public const string FUNCIONARIO_FECHAESTUDIO = "fechaEstudio";
        public const string FUNCIONARIO_TITULO = "titulo";

        // Experiencias

        public const string FUNCIONARIO_IDEXPERIENCIA = "idexperiencia";
        public const string FUNCIONARIO_FECHAINICIO = "fechaInicio";
        public const string FUNCIONARIO_FECHAFIN = "fechaFin";
        public const string FUNCIONARIO_CARGOEXP = "cargo";                
        public const string FUNCIONARIO_JEFEEXP = "jefe";
        public const string FUNCIONARIO_TELEFONOEXP = "telefono";
        public const string FUNCIONARIO_DIRECCIONEXP = "direccion";
        public const string FUNCIONARIO_OBSERVACIONESEXP = "Observaciones";

        #endregion

        #region  [Metodos Expuestos]

        public void Guardar_Funcionario(FuncionarioVO funcionario)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                 {
                    new Parametro(FUNCIONARIO_IDFUNCIONARIO, funcionario.IdFuncionario, DbType.Int32),
                    new Parametro(FUNCIONARIO_IDEMPRESA, funcionario.IdEmpresa, DbType.Int32),
                    new Parametro(FUNCIONARIO_IDUSUARIO, funcionario.IdUsuario, DbType.Int32),
                    new Parametro(FUNCIONARIO_NOMBREUSUARIO, funcionario.NombreUsuario, DbType.String),
                    new Parametro(FUNCIONARIO_CLAVE, funcionario.Clave, DbType.String),
                    new Parametro(FUNCIONARIO_IDROL, funcionario.IdRol, DbType.Int32),
                    new Parametro(FUNCIONARIO_TIPIDENTIFICACION, funcionario.TipIdentificacion, DbType.Int32),
                    new Parametro(FUNCIONARIO_NUMIDENTIFICACION, funcionario.NumIdentificacion, DbType.String),
                    new Parametro(FUNCIONARIO_IDPAISEXPEDICION, funcionario.IdPaisExpedicion, DbType.Int32),
                    new Parametro(FUNCIONARIO_IDPROVINCIAEXPEDICION, funcionario.IdProvinciaExpedicion, DbType.Int32),
                    new Parametro(FUNCIONARIO_IDCIUDADEXPEDICION, funcionario.IdCiudadExpedicion, DbType.Int32),
                    new Parametro(FUNCIONARIO_FECHAEXPEDICION, funcionario.FechaExpedicion, DbType.DateTime),
                    new Parametro(FUNCIONARIO_NOMBRE1, funcionario.Nombre1, DbType.String),
                    new Parametro(FUNCIONARIO_NOMBRE2, funcionario.Nombre2, DbType.String),
                    new Parametro(FUNCIONARIO_APELLIDO1, funcionario.Apellido1, DbType.String),
                    new Parametro(FUNCIONARIO_APELLIDO2, funcionario.Apellido2, DbType.String),
                    new Parametro(FUNCIONARIO_FECHANACIMIENTO, funcionario.FechaNacimiento, DbType.DateTime),
                    new Parametro(FUNCIONARIO_IDPAISNACIMIENTO, funcionario.IdPaisNacimiento, DbType.Int32),
                    new Parametro(FUNCIONARIO_IDPROVINCIANACIMIENTO, funcionario.IdProvinciaNacimiento, DbType.Int32),
                    new Parametro(FUNCIONARIO_IDCIUDADNACIMIENTO, funcionario.IdCiudadNacimiento, DbType.Int32),
                    new Parametro(FUNCIONARIO_IDSEXO, funcionario.IdSexo, DbType.Int32),
                    new Parametro(FUNCIONARIO_IDRH, funcionario.IdRH, DbType.Int32),
                    new Parametro(FUNCIONARIO_IDPROFESION, funcionario.IdProfesion, DbType.Int32),
                    new Parametro(FUNCIONARIO_IDCARGO, funcionario.IdCargo, DbType.Int32),
                    new Parametro(FUNCIONARIO_IDJEFE, funcionario.IdJefe, DbType.Int32),
                    new Parametro(FUNCIONARIO_ESCALAFON, funcionario.Escalafon, DbType.String),
                    new Parametro(FUNCIONARIO_RESESCALAFON, funcionario.ResEscalafon, DbType.String),
                    new Parametro(FUNCIONARIO_FECHARESOLUCION, funcionario.FechaResolucion, DbType.DateTime),
                    new Parametro(FUNCIONARIO_ESTADOCIVIL, funcionario.EstadoCivil, DbType.Int32),
                    new Parametro(FUNCIONARIO_DIRECCIONRESIDENCIA, funcionario.DireccionResidencia, DbType.String),
                    new Parametro(FUNCIONARIO_BARRIORESIDENCIA, funcionario.BarrioResidencia, DbType.String),
                    new Parametro(FUNCIONARIO_TELEFONORESIDENCIA, funcionario.TelefonoResidencia, DbType.String),
                    new Parametro(FUNCIONARIO_TELEFONOCELULAR, funcionario.TelefonoCelular, DbType.String),
                    new Parametro(FUNCIONARIO_IDPAISRESIDENCIA, funcionario.IdPaisResidencia, DbType.Int32),
                    new Parametro(FUNCIONARIO_IDPROVINCIARESIDENCIA, funcionario.IdProvinciaResidencia, DbType.Int32),
                    new Parametro(FUNCIONARIO_IDCIUDADRESIDENCIA, funcionario.IdCiudadResidencia, DbType.Int32),
                    new Parametro(FUNCIONARIO_CORREOELECTRONICO, funcionario.CorreoElectronico, DbType.String),
                    new Parametro(FUNCIONARIO_IDAFP, funcionario.IdAFP, DbType.Int32),
                    new Parametro(FUNCIONARIO_IDEPS, funcionario.IdEPS, DbType.Int32),
                    new Parametro(FUNCIONARIO_FECHAINGRESO, funcionario.FechaIngreso, DbType.DateTime),
                    new Parametro(FUNCIONARIO_FECHARETIRO, funcionario.FechaRetiro, DbType.DateTime),
                    new Parametro(FUNCIONARIO_IDESTRATO, funcionario.IdEstrato, DbType.Int32),
                    new Parametro(FUNCIONARIO_IDTIPOCONTRATO, funcionario.IdTipoContrato, DbType.Int32),
                    new Parametro(FUNCIONARIO_ESTADO, funcionario.Estado, DbType.String),
                    new Parametro(FUNCIONARIO_NOTAS, funcionario.Notas, DbType.String),
                    new Parametro(FUNCIONARIO_USUARIOCREA, funcionario.UsuarioCrea, DbType.String),
                    new Parametro(FUNCIONARIO_USUARIOMODIFICA, funcionario.UsuarioModifica, DbType.String),
                };
                this.EjecutarStoredProcedure(FUNCIONARIO_GRABAR, valParam);
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
        public FuncionarioVO Buscar_Funcionario(FuncionarioVO pFuncionario)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                 {
                    //Se adicionan los parametros para la busqueda del objeto
                    new Parametro(FUNCIONARIO_TIPIDENTIFICACION, pFuncionario.TipIdentificacion, DbType.Int32),
                    new Parametro(FUNCIONARIO_NUMIDENTIFICACION, pFuncionario.NumIdentificacion, DbType.String),
                    new Parametro(FUNCIONARIO_IDEMPRESA, pFuncionario.IdEmpresa, DbType.Int32),
                 };

                DataRow dr = this.EjecutarStoredProcedureDataRow(FUNCIONARIO_BUSCAR, valParam);

                if (dr != null)
                    return CargarFuncionarioVO(dr);
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


        #endregion


        #region  [Metodos Privados]

        private FuncionarioVO CargarFuncionarioVO(DataRow dr)
        {
            FuncionarioVO funcionario = new FuncionarioVO();

            funcionario.IdFuncionario = Convert.ToInt32(dr[FUNCIONARIO_IDFUNCIONARIO]);
            funcionario.IdEmpresa = Convert.ToInt32(dr[FUNCIONARIO_IDEMPRESA]);
            funcionario.IdUsuario = dr[FUNCIONARIO_IDUSUARIO] == Convert.DBNull ? intNull : Convert.ToInt32(dr[FUNCIONARIO_IDUSUARIO]);
            //Se Cargan para manejar el Usuario dentro del funcionario.
            funcionario.Dominio = Convert.ToString(dr[FUNCIONARIO_DOMINIO]);
            funcionario.NombreUsuario = Convert.ToString(dr[FUNCIONARIO_NOMBREUSUARIO]);
            funcionario.Clave = Convert.ToString(dr[FUNCIONARIO_CLAVE]);
            funcionario.IdRol = dr[FUNCIONARIO_IDROL] == Convert.DBNull ? intNull : Convert.ToInt32(dr[FUNCIONARIO_IDROL]);
            //FIN

            funcionario.TipIdentificacion = Convert.ToInt32(dr[FUNCIONARIO_TIPIDENTIFICACION]);
            funcionario.NumIdentificacion = Convert.ToString(dr[FUNCIONARIO_NUMIDENTIFICACION]);
            funcionario.IdPaisExpedicion = Convert.ToInt32(dr[FUNCIONARIO_IDPAISEXPEDICION]);
            funcionario.IdProvinciaExpedicion = Convert.ToInt32(dr[FUNCIONARIO_IDPROVINCIAEXPEDICION]);
            funcionario.IdCiudadExpedicion = Convert.ToInt32(dr[FUNCIONARIO_IDCIUDADEXPEDICION]);
            funcionario.FechaExpedicion = Convert.ToDateTime(dr[FUNCIONARIO_FECHAEXPEDICION]);
            funcionario.Nombre1 = Convert.ToString(dr[FUNCIONARIO_NOMBRE1]);
            funcionario.Nombre2 = Convert.ToString(dr[FUNCIONARIO_NOMBRE2]);
            funcionario.Apellido1 = Convert.ToString(dr[FUNCIONARIO_APELLIDO1]);
            funcionario.Apellido2 = Convert.ToString(dr[FUNCIONARIO_APELLIDO2]);
            funcionario.FechaNacimiento = Convert.ToDateTime(dr[FUNCIONARIO_FECHANACIMIENTO]);
            funcionario.IdPaisNacimiento = Convert.ToInt32(dr[FUNCIONARIO_IDPAISNACIMIENTO]);
            funcionario.IdProvinciaNacimiento = Convert.ToInt32(dr[FUNCIONARIO_IDPROVINCIANACIMIENTO]);
            funcionario.IdCiudadNacimiento = Convert.ToInt32(dr[FUNCIONARIO_IDCIUDADNACIMIENTO]);
            funcionario.IdSexo = Convert.ToInt32(dr[FUNCIONARIO_IDSEXO]);
            funcionario.IdRH = Convert.ToInt32(dr[FUNCIONARIO_IDRH]);
            funcionario.IdProfesion = Convert.ToInt32(dr[FUNCIONARIO_IDPROFESION]);
            funcionario.IdCargo = Convert.ToInt32(dr[FUNCIONARIO_IDCARGO]);
            funcionario.nomCargo = Convert.ToString(dr[FUNCIONARIO_NOMCARGO]);
            funcionario.IdJefe = dr[FUNCIONARIO_IDJEFE] == Convert.DBNull ? intNull : Convert.ToInt32(dr[FUNCIONARIO_IDJEFE]);
            funcionario.nomJefe = Convert.ToString(dr[FUNCIONARIO_NOMJEFE]);
            funcionario.Escalafon = Convert.ToString(dr[FUNCIONARIO_ESCALAFON]);
            //funcionario.Escalafon = dr[FUNCIONARIO_ESCALAFON] == Convert.DBNull ? intNull : Convert.ToInt32(dr[FUNCIONARIO_ESCALAFON]);
            funcionario.ResEscalafon = Convert.ToString(dr[FUNCIONARIO_RESESCALAFON]);
            funcionario.FechaResolucion = dr[FUNCIONARIO_FECHARESOLUCION] == Convert.DBNull ? dateNull : Convert.ToDateTime(dr[FUNCIONARIO_FECHARESOLUCION]);
            funcionario.EstadoCivil = Convert.ToInt32(dr[FUNCIONARIO_ESTADOCIVIL]);
            funcionario.DireccionResidencia = Convert.ToString(dr[FUNCIONARIO_DIRECCIONRESIDENCIA]);
            funcionario.BarrioResidencia = Convert.ToString(dr[FUNCIONARIO_BARRIORESIDENCIA]);
            funcionario.TelefonoResidencia = Convert.ToString(dr[FUNCIONARIO_TELEFONORESIDENCIA]);
            funcionario.TelefonoCelular = Convert.ToString(dr[FUNCIONARIO_TELEFONOCELULAR]);
            funcionario.IdPaisResidencia = Convert.ToInt32(dr[FUNCIONARIO_IDPAISRESIDENCIA]);
            funcionario.IdProvinciaResidencia = Convert.ToInt32(dr[FUNCIONARIO_IDPROVINCIARESIDENCIA]);
            funcionario.IdCiudadResidencia = Convert.ToInt32(dr[FUNCIONARIO_IDCIUDADRESIDENCIA]);
            funcionario.CorreoElectronico = Convert.ToString(dr[FUNCIONARIO_CORREOELECTRONICO]);
            funcionario.IdAFP = Convert.ToInt32(dr[FUNCIONARIO_IDAFP]);
            funcionario.IdEPS = Convert.ToInt32(dr[FUNCIONARIO_IDEPS]);
            funcionario.FechaIngreso = dr[FUNCIONARIO_FECHAINGRESO] == Convert.DBNull ? dateNull : Convert.ToDateTime(dr[FUNCIONARIO_FECHAINGRESO]);
            funcionario.FechaRetiro = dr[FUNCIONARIO_FECHARETIRO] == Convert.DBNull ? dateNull : Convert.ToDateTime(dr[FUNCIONARIO_FECHARETIRO]);
            funcionario.IdEstrato = Convert.ToInt32(dr[FUNCIONARIO_IDESTRATO]);
            funcionario.IdTipoContrato = Convert.ToInt32(dr[FUNCIONARIO_IDTIPOCONTRATO]);
            funcionario.Estado = Convert.ToString(dr[FUNCIONARIO_ESTADO]);
            funcionario.Notas = Convert.ToString(dr[FUNCIONARIO_NOTAS]);
            funcionario.UsuarioCrea = Convert.ToString(dr[FUNCIONARIO_USUARIOCREA]);
            funcionario.FechaCrea = Convert.ToDateTime(dr[FUNCIONARIO_FECHACREA]);
            funcionario.UsuarioModifica = Convert.ToString(dr[FUNCIONARIO_USUARIOMODIFICA]);
            funcionario.FechaModifica = dr[FUNCIONARIO_FECHAMODIFICA] == Convert.DBNull ? dateNull : Convert.ToDateTime(dr[FUNCIONARIO_FECHAMODIFICA]);

            return funcionario;
        }

    
        #endregion
    }
}
