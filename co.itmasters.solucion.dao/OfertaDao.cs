using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using co.itmasters.solucion.vo;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Win32;

namespace co.itmasters.solucion.dao
{
    public class OfertaDao : BaseDao
    {
        private OfertaDao _empresa;

        #region [StoredProcedures]
        public const string OFERTA_GUARDAR = "Oferta_Guardar";
        public const string OFERTA_ANULAR = "Oferta_Anular";
        public const string OFERTA_PUBLICAR = "Oferta_Publicar";
        public const string OFERTA_POSTULAR = "Oferta_Postular";
        public const string OFERTA_CONSULTAROFERTAEMPRESA = "Oferta_ConsultarOfertaEmpresa";
        public const string OFERTA_TRAERESTADISTICASOFERTA = "Oferta_TraerEstadisticasOferta";
        public const string OFERTA_TRAEESTADOOFERTAEMPRESA = "Oferta_TraeEstadoOfertaEmpresa";
        public const string OFERTA_TRAEESTADOOFERTA = "Oferta_TraeEstadoOferta";
        public const string OFERTA_TRAEOFERTADETALLE = "Oferta_TraeOfertaDetalle";
        public const string OFERTA_TRAEROFERTAPERSONA = "Oferta_TraerOfertaPersona";
        public const string OFERTA_TRAEROFERTAPERSONADETALLE = "Oferta_TraerOfertaPersonaDetalle";
        public const string EMPRESA_PLANESADQUIRIDOS = "Empresa_PlanesAdquiridos";
        public const string OFERTA_TRAEROFERTASAPR = "Oferta_TraerOfertaApr";
        public const string OFERTA_APROBARPUBLICAR = "Oferta_AprobarPublicar";
        public const string OFERTA_PAGOS = "Oferta_Pagos";
        #endregion


        #region [Constantes oferta]
        /// <summary>
        /// Tablas ofertas
        /// </summary>
        public const string OFERTA_IDUSUARIO = "idUsuario";
        public const string OFERTA_IDPERSONA = "idPersona";
        public const string OFERTA_IDOFERTA = "idOferta";
        public const string OFERTA_IDEMPRESA = "idEmpresa";
        public const string OFERTA_IDPLAN = "idPlan";
        public const string OFERTA_IDPAGO = "idPago";
        public const string OFERTA_DESCRIPCIONPAGO = "descripcion";
        public const string OFERTA_VALORPAGO = "valor";
        public const string OFERTA_IDPLANADQUIRIDO = "idPlanAdquirido";
        public const string OFERTA_TITULOVACANTE = "tituloVacante";
        public const string OFERTA_DESCRIPCIONVACANTE = "descripcionVacante";
        public const string OFERTA_IDMODALIDAD = "idModalidad";
        public const string OFERTA_TIEMPOEXPERIENCIA = "tiempoExperiencia";
        public const string OFERTA_UNIDADMEDIDAEXPERIENCIA = "unidadMedidaExperiencia";
        public const string OFERTA_CANTIDADVACANTES = "cantidadVacantes";
        public const string OFERTA_CONSUMIDA = "ofertasConsumidas";
        public const string OFERTA_NIVELESTUDIOS = "NivelEstudiosRequeridos";  
        public const string OFERTA_NROHOJASVIDAAPLICADA = "nroHojasVidaAplicada";
        public const string OFERTA_CARGO = "cargo";
        public const string OFERTA_FECHAPUBLICACION = "fechaPublicacion";
        public const string OFERTA_FECHAVENCIMIENTO = "fechaVencimiento";
        public const string OFERTA_IDNIVELESTUDIOSREQUERIDOS = "idNivelEstudiosRequeridos";
        public const string OFERTA_IDOCUPACION = "idOcupacion";
        public const string OFERTA_IDOCUPACION1 = "idOcupacion1";
        public const string OFERTA_IDOCUPACION2 = "idOcupacion2";
        public const string OFERTA_IDOCUPACION3 = "idOcupacion3";
        public const string OFERTA_IDOCUPACION4 = "idOcupacion4";
        public const string OFERTA_IDOCUPACION5 = "idOcupacion5";
        public const string OFERTA_IDOCUPACION6 = "idOcupacion6";
        public const string OFERTA_IDOCUPACION7 = "idOcupacion7";
        public const string OFERTA_IDOCUPACION8 = "idOcupacion8";
        public const string OFERTA_IDOCUPACION9 = "idOcupacion9";
        public const string OFERTA_IDOCUPACION10 = "idOcupacion10";
        public const string OFERTA_NOMOCUPACION = "nomOcupacion";
        public const string OFERTA_NOMOCUPACION2 = "nomOcupacion2";
        public const string OFERTA_NOMOCUPACION3 = "nomOcupacion3";
        public const string OFERTA_NOMOCUPACION4 = "nomOcupacion4";
        public const string OFERTA_NOMOCUPACION5 = "nomOcupacion5";
        public const string OFERTA_NOMOCUPACION6 = "nomOcupacion6";
        public const string OFERTA_NOMOCUPACION7 = "nomOcupacion7";
        public const string OFERTA_NOMOCUPACION8 = "nomOcupacion8";
        public const string OFERTA_NOMOCUPACION9 = "nomOcupacion9";
        public const string OFERTA_NOMOCUPACION10 = "nomOcupacion10";
        public const string OFERTA_IDRANGOSALARIO = "idRangoSalario";
        public const string OFERTA_RANGOSALARIO = "nomRangoSalarial";
        public const string OFERTA_IDCIUDADVACANTE = "idCiudadVacante";
        public const string OFERTA_IDMUNISIPIOVACANTE = "idMunicipioVacante";
        public const string OFERTA_IDSECTORECONOMICO = "idSectorEconomico";
        public const string OFERTA_DISPONIBILIDADVIAJAR = "disponibilidadViajar";
        public const string OFERTA_CAMBIOCIUDADRESIDENCIA = "cambioCiudadResidencia";
        public const string OFERTA_ESDESTACADA = "esDestacada";
        public const string OFERTA_ESCONFIDENCIAL = "esConfidencial";
        public const string OFERTA_ESTADO = "estado";
        public const string OFERTA_NOMCIUDAD = "nomCiudad";
        public const string OFERTA_FECHAAPROBACION = "fechaAprobacion";
        public const string OFERTA_USUARIOAPRUEBA = "usuarioAprueba";
        public const string OFERTA_OBSERVACIONES = "Observaciones";
        public const string OFERTA_USUARIOCREA = "usuarioCrea";
        public const string OFERTA_FECHACREA = "fechaCrea";
        public const string OFERTA_USUARIOMODIFICA = "usuarioModifica";
        public const string OFERTA_FECHAMODIFICA = "fechaModifica";
        public const string OFERTA_NOMEMPRESA = "nomEmpresa";
        public const string OFERTA_PERSONAPOSTULACIONES = "Oferta_PersonaPostulaciones";
        public const string OFERTA_TYPEMODIFY = "typeModify";

        //oferta.PlanesAdquiridos
        public const string OFERTA_FECHAINICIA = "fechaInicia";
        public const string OFERTA_FECHAFINALIZA = "fechaFinaliza";
        public const string OFERTA_NUMEROOFERTAS = "numeroOfertas";
        public const string OFERTA_OFERTASCONSUMIDAS = "ofertasConsumidas";
        public const string OFERTA_FECHAULTIMAOFERTA = "fechaUltimaOferta";

        public const string OFERTA_NOMPLAN = "nomPlan";
        public const string OFERTA_NROOFERTAS = "nroOfertas";
        public const string OFERTA_NROHOJASPOROFERTA = "nroHojasPorOferta";
        public const string OFERTA_FILTROCANDIDATOS = "filtroCandidatos";
        public const string OFERTA_MULTIUSUARIO = "multiusuario";
        public const string OFERTA_DIASPUBLICACIONOFERTA = "diasPublicacionOferta";
        public const string OFERTA_OFERTADESTACADA = "ofertaDestacada";
        public const string OFERTA_OFERTACONFIDENCIAL = "ofertaConfidencial";
        public const string OFERTA_PREGUNTASDEFILTRO = "preguntasDeFiltro";
        public const string OFERTA_CAPACITACIONES = "capacitaciones";
        public const string OFERTA_VIGENCIAPLAN = "vigenciaPlan";
        public const string OFERTA_ENTREVISTAZOOM = "entrevistaZoom";
        public const string OFERTA_VALORPLAN = "valorPlan";
        public const string OFERTA_PENDIENTES = "pendientes";
        public const string OFERTA_ACTIVAS = "activas";
        public const string OFERTA_VENCIDAS = "vencidas";
        public const string OFERTA_SEGUIDORES = "seguidores";
        public const string OFERTA_HOJASDEVIDA = "hv";
        public const string OFERTA_TOTALHOJASDEVIDA = "totHv";
        public const string OFERTA_HVVISTAS = "HvVistas";
        public const string OFERTA_NOMRANGOSALARIAL = "nomRangoSalarial";
        public const string ACTORES_NUMIDENTIFICACION = "numIdentificacion";

        #endregion

        #region Constantes Mercado Pago
        // Mercado Pago

        public const string MERCADOPAGO_PAYMENT_ID = "payment_id";
        public const string MERCADOPAGO_PAYMENT_METHOD = "payment_method";
        public const string MERCADOPAGO_PREFERENCE_ID = "preference_id";

        #endregion

        #region [Constantes persona]

        public const string PERSONA_IDPERSONA = "idPersona";
        public const string PERSONA_IDUSUARIO = "idUsuario";
        public const string PERSONA_IDTIPOIDE = "idTipoIde";
        public const string PERSONA_NUMEROIDE = "numeroIde";
        public const string PERSONA_NOMPERSONA = "nomPersona";
        public const string PERSONA_APEPERSONA = "apePersona";
        public const string PERSONA_PERFIL = "perfil";
        public const string PERSONA_EDAD = "edad";
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
        public const string PERSONA_NOMMODALIDADTRABAJO = "nomModalidadTrabajo";
        public const string PERSONA_NOMMAXNIVELEDUCATIVO = "nomMaxNivelEducativo";
        
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

        #region  [Metodos Expuestos]
        public List<OfertaVO> Oferta_PersonaPostulaciones(OfertaVO Ofertas)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    //Se adicionan los parametros para la busqueda del objeto
                    new Parametro(OFERTA_IDUSUARIO, Ofertas.idUsuario, DbType.Int32),
                    new Parametro(OFERTA_IDOCUPACION, Ofertas.idOcupacion, DbType.Int32),
                    new Parametro(OFERTA_FECHAINICIA, Ofertas.fechaInicia, DbType.DateTime),
                    new Parametro(OFERTA_FECHAFINALIZA, Ofertas.fechaFinaliza, DbType.DateTime),
                };

                DataTable dt = this.EjecutarStoredProcedureDataTable(OFERTA_PERSONAPOSTULACIONES, valParam);

                List<OfertaVO> newOferta = new List<OfertaVO>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        OfertaVO Oferta = new OfertaVO();
                        Oferta.idOferta = Convert.ToInt32(dr[OFERTA_IDOFERTA]);
                        Oferta.tituloVacante = Convert.ToString(dr[OFERTA_TITULOVACANTE]);
                        Oferta.RangoSalario = Convert.ToString(dr[OFERTA_NOMRANGOSALARIAL]);
                        Oferta.nomCiudad = Convert.ToString(dr[OFERTA_NOMCIUDAD]);
                        Oferta.nomEmpresa = Convert.ToString(dr[OFERTA_NOMEMPRESA]);
                        Oferta.rutaAvatar = Convert.ToString(dr[PERSONA_RUTAAVATAR]);
                        Oferta.descripcionVacante = Convert.ToString(dr[OFERTA_DESCRIPCIONVACANTE]);
                        newOferta.Add(Oferta);
                    }
                }
                return newOferta;
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
        public void ModifyPagos(OfertaVO pago)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    new Parametro(OFERTA_TYPEMODIFY, pago.typeModify, DbType.String),
                    new Parametro(OFERTA_IDPAGO, pago.idPago, DbType.Int32),
                    new Parametro(OFERTA_IDUSUARIO, pago.idUsuario, DbType.Int32),
                    new Parametro(OFERTA_IDPLAN, pago.idPlan, DbType.Int32),
                    new Parametro(OFERTA_IDPLANADQUIRIDO, pago.idPlanAdquirido, DbType.Int32),
                    new Parametro(OFERTA_IDOFERTA, pago.idOferta, DbType.Int32),
                    new Parametro(OFERTA_DESCRIPCIONPAGO, pago.descripcionPago, DbType.String),
                    new Parametro(MERCADOPAGO_PAYMENT_ID, pago.payment_id, DbType.String),
                    new Parametro(MERCADOPAGO_PAYMENT_METHOD, pago.payment_method, DbType.String),
                    new Parametro(OFERTA_ESTADO, pago.estado, DbType.String),
                    new Parametro(OFERTA_VALORPAGO, pago.valorPago, DbType.Int32),
                };
                this.EjecutarStoredProcedure(OFERTA_PAGOS, valParam);

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
        public void Postulacion(OfertaVO postulacion)
        {

            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    new Parametro(OFERTA_IDOFERTA, postulacion.idOferta, DbType.Int32),
                    new Parametro(OFERTA_IDPERSONA, postulacion.idPersona, DbType.Int32),
                    new Parametro(OFERTA_ESTADO, postulacion.estado, DbType.String),
                    new Parametro(OFERTA_TYPEMODIFY, postulacion.typeModify, DbType.String),
                };
                this.EjecutarStoredProcedure(OFERTA_POSTULAR, valParam);

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

        public List<PersonaVO> Postulados(OfertaVO oferta)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    new Parametro(OFERTA_IDOFERTA, oferta.idOferta, DbType.Int32),
                    new Parametro(OFERTA_IDPERSONA, oferta.idPersona, DbType.Int32),
                    new Parametro(OFERTA_TYPEMODIFY, oferta.typeModify, DbType.String),
                    new Parametro(OFERTA_ESTADO, null, DbType.String),
                };
                DataTable dt = this.EjecutarStoredProcedureDataTable(OFERTA_POSTULAR, valParam);
                List<PersonaVO> rPersona = new List<PersonaVO>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        PersonaVO persona = new PersonaVO();
                        persona.idPersona = Convert.ToInt32(dr[PERSONA_IDPERSONA]);
                        persona.idUsuario = Convert.ToInt32(dr[PERSONA_IDUSUARIO]);
                        persona.rutaAvatar = Convert.ToString(dr[PERSONA_RUTAAVATAR]);
                        persona.nomPersona = Convert.ToString(dr[PERSONA_NOMPERSONA]);
                        persona.perfil = Convert.ToString(dr[PERSONA_PERFIL]);
                        persona.edad = Convert.ToInt32(dr[PERSONA_EDAD]);
                        persona.correoElectronico = Convert.ToString(dr[PERSONA_CORREOELECTRONICO]);
                        persona.telefono = Convert.ToString(dr[PERSONA_TELEFONO]);
                        persona.ciudadResidencia = Convert.ToString(dr[PERSONA_CIUDADRECIDENCIA]);
                        persona.nomMaxNivelEducativo = Convert.ToString(dr[PERSONA_NOMMAXNIVELEDUCATIVO]);
                        persona.fechaCrea = Convert.ToDateTime(dr[PERSONA_FECHACREA]);
                        persona.nomModalidadTrabajo = Convert.ToString(dr[PERSONA_NOMMODALIDADTRABAJO]);
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
        public List<OfertaVO> TraePlanesAdquiridosEmpresa(OfertaVO oferta)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    //Se adicionan los parametros para la busqueda del objeto
                    new Parametro(OFERTA_TYPEMODIFY, oferta.typeModify, DbType.String),
                    new Parametro(OFERTA_IDUSUARIO, oferta.idUsuario, DbType.Int32),
                    new Parametro(OFERTA_IDEMPRESA, oferta.idEmpresa, DbType.Int32),
                    new Parametro(OFERTA_ESTADO, oferta.estado, DbType.String),
                    new Parametro(OFERTA_IDPLAN, oferta.idPlan, DbType.Int32),
                    new Parametro(OFERTA_IDPLANADQUIRIDO, oferta.idPlanAdquirido, DbType.Int32),
                    new Parametro(MERCADOPAGO_PAYMENT_ID, oferta.payment_id,DbType.String ),
                    new Parametro(MERCADOPAGO_PREFERENCE_ID, oferta.preference_id,DbType.String ),
                    new Parametro(OFERTA_VIGENCIAPLAN, oferta.vigenciaPlan, DbType.Int32),
                    new Parametro(OFERTA_NUMEROOFERTAS, oferta.numeroOfertas, DbType.Int32),
                    new Parametro(OFERTA_VALORPLAN, oferta.valorPlan, DbType.Int32),

            };

                DataTable dt = this.EjecutarStoredProcedureDataTable(EMPRESA_PLANESADQUIRIDOS, valParam);

                List<OfertaVO> rOferta = new List<OfertaVO>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        OfertaVO Oferta = new OfertaVO();
                        Oferta.idPlanAdquirido = Convert.ToInt32(dr[OFERTA_IDPLANADQUIRIDO]);
                        Oferta.idEmpresa = Convert.ToInt32(dr[OFERTA_IDEMPRESA]);
                        Oferta.idPlan = Convert.ToInt32(dr[OFERTA_IDPLAN]);
                        Oferta.fechaInicia = Convert.ToDateTime(dr[OFERTA_FECHAINICIA]);
                        Oferta.fechaFinaliza = Convert.ToDateTime(dr[OFERTA_FECHAFINALIZA]);
                        Oferta.ofertasConsumidas= Convert.ToInt32(dr[OFERTA_OFERTASCONSUMIDAS]);
                        Oferta.estado = Convert.ToString(dr[OFERTA_ESTADO]);
                        oferta.fechaUltimaOferta = dr[OFERTA_FECHAULTIMAOFERTA] == Convert.DBNull ? dateNull : Convert.ToDateTime(dr[OFERTA_FECHAULTIMAOFERTA]);
                        Oferta.valorPlan = dr[OFERTA_VALORPLAN] == Convert.DBNull ? intNull :  Convert.ToInt32(dr[OFERTA_VALORPLAN]);
                        Oferta.nomPlan = Convert.ToString(dr[OFERTA_NOMPLAN]);
                        Oferta.nroOfertas = Convert.ToInt32(dr[OFERTA_NROOFERTAS]);
                        Oferta.filtroCandidatos = Convert.ToBoolean(dr[OFERTA_FILTROCANDIDATOS]);
                        Oferta.multiusuario = Convert.ToBoolean(dr[OFERTA_MULTIUSUARIO]);
                        Oferta.diasPublicacionOferta = Convert.ToInt32(dr[OFERTA_DIASPUBLICACIONOFERTA]);
                        Oferta.ofertaDestacada = Convert.ToBoolean(dr[OFERTA_OFERTADESTACADA]);
                        Oferta.ofertaConfidencial = Convert.ToBoolean(dr[OFERTA_OFERTACONFIDENCIAL]);
                        Oferta.preguntasDeFiltro = Convert.ToBoolean(dr[OFERTA_PREGUNTASDEFILTRO]);
                        Oferta.capacitaciones = Convert.ToBoolean(dr[OFERTA_CAPACITACIONES]);
                        Oferta.vigenciaPlan = Convert.ToInt32(dr[OFERTA_VIGENCIAPLAN]);
                        Oferta.entrevistaZoom = Convert.ToBoolean(dr[OFERTA_ENTREVISTAZOOM]);
                        rOferta.Add(Oferta);
                    }
                }
                return rOferta;
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

        public OfertaVO GetOfertaPersonaDetalle (OfertaVO Ofertas)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    //Se adicionan los parametros para la busqueda del objeto
                    new Parametro(OFERTA_IDUSUARIO, Ofertas.idUsuario, DbType.Int32),
                    new Parametro(OFERTA_IDOFERTA, Ofertas.idOferta, DbType.Int32)

                };

                DataRow dr = this.EjecutarStoredProcedureDataRow(OFERTA_TRAEROFERTAPERSONADETALLE, valParam);
                if (dr != null)
                    return cargarOfertaPersonaDetalleVO(dr);
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
        public List<OfertaVO> GetOfertaPersona(OfertaVO Ofertas)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    //Se adicionan los parametros para la busqueda del objeto
                    new Parametro(OFERTA_IDUSUARIO, Ofertas.idUsuario, DbType.Int32),
                    new Parametro(OFERTA_TITULOVACANTE, Ofertas.tituloVacante, DbType.String),
                    new Parametro(OFERTA_IDCIUDADVACANTE, Ofertas.idCiudadVacante, DbType.Int32),
                    new Parametro(OFERTA_IDOCUPACION, Ofertas.idOcupacion, DbType.Int32),
                };

                DataTable dt = this.EjecutarStoredProcedureDataTable(OFERTA_TRAEROFERTAPERSONA, valParam);

                List<OfertaVO> newOferta = new List<OfertaVO>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        OfertaVO Oferta = new OfertaVO();
                        Oferta.idOferta = Convert.ToInt32(dr[OFERTA_IDOFERTA]);
                        Oferta.tituloVacante = Convert.ToString(dr[OFERTA_TITULOVACANTE]);
                        Oferta.nomEmpresa = Convert.ToString(dr[OFERTA_NOMEMPRESA]);
                        Oferta.RangoSalario = Convert.ToString(dr[OFERTA_NOMRANGOSALARIAL]);
                        Oferta.nomCiudad = Convert.ToString(dr[OFERTA_NOMCIUDAD]);
                        Oferta.cantidadVacantes = Convert.ToInt32(dr[OFERTA_CANTIDADVACANTES]);
                        Oferta.rutaAvatar = Convert.ToString(dr[PERSONA_RUTAAVATAR]);
                        newOferta.Add(Oferta);
                    }
                }
                return newOferta;
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
        public void AnulaOferta(OfertaVO Oferta)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    new Parametro(OFERTA_IDOFERTA, Oferta.idOferta, DbType.Int32),
                    new Parametro(OFERTA_IDUSUARIO, Oferta.idUsuario, DbType.Int32),
                    new Parametro(ACTORES_NUMIDENTIFICACION, Oferta.numIdentificacion, DbType.String),
                };
                this.EjecutarStoredProcedure(OFERTA_ANULAR, valParam);

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
        public void PublicarOferta(OfertaVO Oferta)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    new Parametro(OFERTA_IDOFERTA, Oferta.idOferta, DbType.Int32),
                    new Parametro(OFERTA_IDEMPRESA, Oferta.idEmpresa, DbType.Int32),
                    new Parametro(OFERTA_ESTADO, Oferta.estado, DbType.String),
                    new Parametro(OFERTA_TITULOVACANTE, Oferta.tituloVacante, DbType.String),
                    new Parametro(OFERTA_DESCRIPCIONVACANTE, Oferta.descripcionVacante, DbType.String),
                    new Parametro(OFERTA_TIEMPOEXPERIENCIA, Oferta.tiempoExperiencia, DbType.Int32),
                    new Parametro(OFERTA_CANTIDADVACANTES, Oferta.cantidadVacantes, DbType.Int32),
                    new Parametro(OFERTA_CARGO, Oferta.cargo, DbType.String),
                    new Parametro(OFERTA_FECHAPUBLICACION, Oferta.fechaPublicacion, DbType.DateTime),
                    new Parametro(OFERTA_FECHAVENCIMIENTO, Oferta.fechaVencimiento, DbType.DateTime),
                    new Parametro(OFERTA_IDNIVELESTUDIOSREQUERIDOS, Oferta.idNivelEstudiosRequeridos, DbType.Int32),
                    new Parametro(OFERTA_IDRANGOSALARIO, Oferta.idRangoSalario, DbType.Int32),
                    new Parametro(OFERTA_IDMODALIDAD, Oferta.idModalidad, DbType.Int32),
                    new Parametro(OFERTA_IDMUNISIPIOVACANTE, Oferta.idMunicipioVacante, DbType.Int32),
                    new Parametro(OFERTA_IDCIUDADVACANTE, Oferta.idCiudadVacante, DbType.Int32),
                    new Parametro(OFERTA_IDSECTORECONOMICO, Oferta.idSectorEconomico, DbType.Int32),
                    new Parametro(OFERTA_ESCONFIDENCIAL, Oferta.esConfidencial, DbType.Boolean),
                    new Parametro(OFERTA_IDOCUPACION1, Oferta.idOcupacion1, DbType.Int32),
                    new Parametro(OFERTA_IDOCUPACION2, Oferta.idOcupacion2, DbType.Int32),
                    new Parametro(OFERTA_IDOCUPACION3, Oferta.idOcupacion3, DbType.Int32),
                    new Parametro(OFERTA_IDOCUPACION4, Oferta.idOcupacion4, DbType.Int32),
                    new Parametro(OFERTA_IDOCUPACION5, Oferta.idOcupacion5, DbType.Int32),
                    new Parametro(OFERTA_IDOCUPACION6, Oferta.idOcupacion6, DbType.Int32),
                    new Parametro(OFERTA_IDOCUPACION7, Oferta.idOcupacion7, DbType.Int32),
                    new Parametro(OFERTA_IDOCUPACION8, Oferta.idOcupacion8, DbType.Int32),
                    new Parametro(OFERTA_IDOCUPACION9, Oferta.idOcupacion9, DbType.Int32),
                    new Parametro(OFERTA_IDOCUPACION10, Oferta.idOcupacion10, DbType.Int32),
                    new Parametro(OFERTA_IDUSUARIO, Oferta.idUsuario, DbType.Int32),
                    new Parametro(OFERTA_USUARIOCREA, Oferta.usuarioCrea, DbType.String),

                };
                this.EjecutarStoredProcedure(OFERTA_PUBLICAR, valParam);

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
        public void GuardarOferta(OfertaVO Oferta)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                  
                };
               this.EjecutarStoredProcedure(OFERTA_GUARDAR, valParam);
                
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

        public OfertaVO TraerEstadisticasOferta(OfertaVO Oferta)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    new Parametro(OFERTA_IDUSUARIO, Oferta.idUsuario, DbType.Int32),
                    
                };
                DataRow dr = this.EjecutarStoredProcedureDataRow(OFERTA_TRAERESTADISTICASOFERTA, valParam);
                if (dr != null)
                    return cargarEstadisticaVO(dr);
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
        public OfertaVO TraeOfertaDetalle(OfertaVO Oferta)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    new Parametro(OFERTA_IDUSUARIO, Oferta.idUsuario, DbType.Int32),
                    new Parametro(OFERTA_IDOFERTA, Oferta.idOferta, DbType.Int32),
                };
                DataRow dr = this.EjecutarStoredProcedureDataRow(OFERTA_TRAEOFERTADETALLE, valParam);
                if (dr != null)
                    return cargarOfertaDetalleVO(dr); 
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
        public List<OfertaVO> TraeOfertaEmpresa(OfertaVO Ofertas)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    //Se adicionan los parametros para la busqueda del objeto
                    new Parametro(OFERTA_IDUSUARIO, Ofertas.idUsuario, DbType.Int32)
                    
                };

                DataTable dt = this.EjecutarStoredProcedureDataTable(OFERTA_CONSULTAROFERTAEMPRESA, valParam);

                List<OfertaVO> rOferta = new List<OfertaVO>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        OfertaVO Oferta = new OfertaVO();
                        Oferta.idOferta = Convert.ToInt32(dr[OFERTA_IDOFERTA]);
                        Oferta.tituloVacante = Convert.ToString(dr[OFERTA_TITULOVACANTE]);
                        Oferta.estado = Convert.ToString(dr[OFERTA_ESTADO]);
                        Oferta.totHv = Convert.ToInt32(dr[OFERTA_TOTALHOJASDEVIDA]);
                        Oferta.hvVista = Convert.ToInt32(dr[OFERTA_HVVISTAS]);
                        Oferta.RangoSalario = Convert.ToString(dr[OFERTA_RANGOSALARIO]);
                        Oferta.nomCiudad = Convert.ToString(dr[OFERTA_NOMCIUDAD]);
                        Oferta.fechaPublicacion = Convert.ToDateTime(dr[OFERTA_FECHAPUBLICACION]);
                        rOferta.Add(Oferta);
                    }
                }
                return rOferta;
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
        public List<OfertaVO> TraeEstadoOfertaEmpresa(OfertaVO Estado)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    //Se adicionan los parametros para la busqueda del objeto
                    new Parametro(OFERTA_IDUSUARIO, Estado.idUsuario, DbType.Int32),
                    new Parametro(OFERTA_ESTADO, Estado.estado, DbType.String),
                    new Parametro(OFERTA_IDOCUPACION, Estado.idOcupacion, DbType.Int32),
                    new Parametro(OFERTA_FECHAINICIA, Estado.fechaInicia, DbType.DateTime),
                    new Parametro(OFERTA_FECHAFINALIZA, Estado.fechaFinaliza, DbType.DateTime),
                  
            };

                DataTable dt = this.EjecutarStoredProcedureDataTable(OFERTA_TRAEESTADOOFERTAEMPRESA, valParam);

                List<OfertaVO> rOferta = new List<OfertaVO>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        OfertaVO Oferta = new OfertaVO();
                        Oferta.idOferta = Convert.ToInt32(dr[OFERTA_IDOFERTA]);
                        Oferta.tituloVacante = Convert.ToString(dr[OFERTA_TITULOVACANTE]);
                        Oferta.fechaPublicacion = Convert.ToDateTime(dr[OFERTA_FECHAPUBLICACION]);
                        Oferta.estado = Convert.ToString(dr[OFERTA_ESTADO]);
                        Oferta.nomCiudad = Convert.ToString(dr[OFERTA_NOMCIUDAD]);
                        Oferta.usuarioCrea = Convert.ToString(dr[OFERTA_USUARIOCREA]);
                        Oferta.totHv = Convert.ToInt32(dr[OFERTA_TOTALHOJASDEVIDA]);
                        Oferta.hvVista = Convert.ToInt32(dr[OFERTA_HVVISTAS]);
                        Oferta.RangoSalario = Convert.ToString(dr[OFERTA_RANGOSALARIO]);
                        Oferta.esDestacada = Convert.ToBoolean(dr[OFERTA_ESDESTACADA]);
                        Oferta.esConfidencial = Convert.ToBoolean(dr[OFERTA_ESCONFIDENCIAL]);
                        rOferta.Add(Oferta);
                    }
                }
                return rOferta;
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
        public List<OfertaVO> TraeEstadoOferta(OfertaVO Estado)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    //Se adicionan los parametros para la busqueda del objeto
                    new Parametro(OFERTA_IDUSUARIO, Estado.idUsuario, DbType.Int32),

            };

                DataTable dt = this.EjecutarStoredProcedureDataTable(OFERTA_TRAEESTADOOFERTA, valParam);

                List<OfertaVO> rOferta = new List<OfertaVO>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        OfertaVO Oferta = new OfertaVO();
                        Oferta.idPlan = Convert.ToInt32(dr[OFERTA_IDPLAN]);
                        Oferta.nomPlan = Convert.ToString(dr[OFERTA_NOMPLAN]);
                        Oferta.nroOfertas = Convert.ToInt32(dr[OFERTA_NROOFERTAS]);
                        Oferta.nroHojasPorOferta = Convert.ToInt32(dr[OFERTA_NROHOJASPOROFERTA]);
                        Oferta.filtroCandidatos = Convert.ToBoolean(dr[OFERTA_FILTROCANDIDATOS]);
                        Oferta.multiusuario = Convert.ToBoolean(dr[OFERTA_MULTIUSUARIO]);
                        Oferta.diasPublicacionOferta = Convert.ToInt32(dr[OFERTA_DIASPUBLICACIONOFERTA]);
                        Oferta.ofertaDestacada = Convert.ToBoolean(dr[OFERTA_OFERTADESTACADA]);
                        Oferta.ofertaConfidencial = Convert.ToBoolean(dr[OFERTA_OFERTACONFIDENCIAL]);
                        Oferta.capacitaciones = Convert.ToBoolean(dr[OFERTA_CAPACITACIONES]);
                        Oferta.vigenciaPlan = Convert.ToInt32(dr[OFERTA_VIGENCIAPLAN]);
                        Oferta.entrevistaZoom = Convert.ToBoolean(dr[OFERTA_ENTREVISTAZOOM]);
                        Oferta.valorPlan = dr[OFERTA_VALORPLAN] == Convert.DBNull ? intNull : Convert.ToInt32(dr[OFERTA_VALORPLAN]);
                        Oferta.estado = Convert.ToString(dr[OFERTA_ESTADO]);
                        Oferta.preguntasDeFiltro = Convert.ToBoolean(dr[OFERTA_PREGUNTASDEFILTRO]);
                        rOferta.Add(Oferta);
                    }
                }
                return rOferta;
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


        private OfertaVO cargarOfertaDetalleVO(DataRow dr)
        {
            OfertaVO oferta = new OfertaVO();
            oferta.idOferta = Convert.ToInt32(dr[OFERTA_IDOFERTA]);
            oferta.idEmpresa = Convert.ToInt32(dr[OFERTA_IDEMPRESA]);
            oferta.idPlan = Convert.ToInt32(dr[OFERTA_IDPLAN]);
            oferta.idPlanAdquirido = Convert.ToInt32(dr[OFERTA_IDPLANADQUIRIDO]);
            oferta.tituloVacante = Convert.ToString(dr[OFERTA_TITULOVACANTE]);
            oferta.descripcionVacante = Convert.ToString(dr[OFERTA_DESCRIPCIONVACANTE]);
            oferta.idModalidad = Convert.ToInt32(dr[OFERTA_IDMODALIDAD]);
            oferta.tiempoExperiencia = Convert.ToInt32(dr[OFERTA_TIEMPOEXPERIENCIA]);
            oferta.cantidadVacantes = Convert.ToInt32(dr[OFERTA_CANTIDADVACANTES]);
            oferta.nroHojasVidaAplicada = Convert.ToInt32(dr[OFERTA_NROHOJASVIDAAPLICADA]);
            oferta.cargo = Convert.ToString(dr[OFERTA_CARGO]);
            oferta.fechaPublicacion = Convert.ToDateTime(dr[OFERTA_FECHAPUBLICACION]);
            oferta.fechaVencimiento = Convert.ToDateTime(dr[OFERTA_FECHAVENCIMIENTO]);
            oferta.idNivelEstudiosRequeridos = Convert.ToInt32(dr[OFERTA_IDNIVELESTUDIOSREQUERIDOS]);
            oferta.idRangoSalario = Convert.ToInt32(dr[OFERTA_IDRANGOSALARIO]);
            oferta.idMunicipioVacante = Convert.ToInt32(dr[OFERTA_IDMUNISIPIOVACANTE]);
            oferta.idCiudadVacante = Convert.ToInt32(dr[OFERTA_IDCIUDADVACANTE]);
            oferta.idSectorEconomico = Convert.ToInt32(dr[OFERTA_IDSECTORECONOMICO]);
            oferta.disponibilidadViajar = Convert.ToBoolean(dr[OFERTA_DISPONIBILIDADVIAJAR]);
            oferta.cambioCiudadResidencia = Convert.ToBoolean(dr[OFERTA_CAMBIOCIUDADRESIDENCIA]);
            oferta.esDestacada = Convert.ToBoolean(dr[OFERTA_ESDESTACADA]);
            oferta.esConfidencial = Convert.ToBoolean(dr[OFERTA_ESCONFIDENCIAL]);
            oferta.estado = Convert.ToString(dr[OFERTA_ESTADO]);
            oferta.fechaAprobacion = Convert.ToDateTime(dr[OFERTA_FECHAAPROBACION]);
            oferta.Observaciones = Convert.ToString(dr[OFERTA_OBSERVACIONES]);
            oferta.idOcupacion1 = dr[OFERTA_IDOCUPACION1] == Convert.DBNull ? intNull : Convert.ToInt32(dr[OFERTA_IDOCUPACION1]);
            oferta.idOcupacion2 = dr[OFERTA_IDOCUPACION2] == Convert.DBNull ? intNull : Convert.ToInt32(dr[OFERTA_IDOCUPACION2]);
            oferta.idOcupacion3 = dr[OFERTA_IDOCUPACION3] == Convert.DBNull ? intNull : Convert.ToInt32(dr[OFERTA_IDOCUPACION3]);
            oferta.idOcupacion4 = dr[OFERTA_IDOCUPACION4] == Convert.DBNull ? intNull : Convert.ToInt32(dr[OFERTA_IDOCUPACION4]);
            oferta.idOcupacion5 = dr[OFERTA_IDOCUPACION5] == Convert.DBNull ? intNull : Convert.ToInt32(dr[OFERTA_IDOCUPACION5]);
            oferta.idOcupacion6 = dr[OFERTA_IDOCUPACION6] == Convert.DBNull ? intNull : Convert.ToInt32(dr[OFERTA_IDOCUPACION6]);
            oferta.idOcupacion7 = dr[OFERTA_IDOCUPACION7] == Convert.DBNull ? intNull : Convert.ToInt32(dr[OFERTA_IDOCUPACION7]);
            oferta.idOcupacion8 = dr[OFERTA_IDOCUPACION8] == Convert.DBNull ? intNull : Convert.ToInt32(dr[OFERTA_IDOCUPACION8]);
            oferta.idOcupacion9 = dr[OFERTA_IDOCUPACION9] == Convert.DBNull ? intNull : Convert.ToInt32(dr[OFERTA_IDOCUPACION9]);
            oferta.idOcupacion10 = dr[OFERTA_IDOCUPACION10] == Convert.DBNull ? intNull : Convert.ToInt32(dr[OFERTA_IDOCUPACION10]);
            oferta.nomOcupacion = Convert.ToString(dr[OFERTA_NOMOCUPACION]);
            oferta.nomOcupacion2 = Convert.ToString(dr[OFERTA_NOMOCUPACION2]);
            oferta.nomOcupacion3 = Convert.ToString(dr[OFERTA_NOMOCUPACION3]);
            oferta.nomOcupacion4 = Convert.ToString(dr[OFERTA_NOMOCUPACION4]);
            oferta.nomOcupacion5 = Convert.ToString(dr[OFERTA_NOMOCUPACION5]);
            oferta.nomOcupacion6 = Convert.ToString(dr[OFERTA_NOMOCUPACION6]);
            oferta.nomOcupacion7 = Convert.ToString(dr[OFERTA_NOMOCUPACION7]);
            oferta.nomOcupacion8 = Convert.ToString(dr[OFERTA_NOMOCUPACION8]);
            oferta.nomOcupacion9 = Convert.ToString(dr[OFERTA_NOMOCUPACION8]);
            oferta.nomOcupacion10 = Convert.ToString(dr[OFERTA_NOMOCUPACION9]);
            return oferta;

        }
        private OfertaVO cargarOfertaPersonaDetalleVO(DataRow dr)
        {
            OfertaVO oferta = new OfertaVO();
            oferta.idOferta = Convert.ToInt32(dr[OFERTA_IDOFERTA]);
            oferta.nomEmpresa = Convert.ToString(dr[OFERTA_NOMEMPRESA]);
            oferta.rutaAvatar = Convert.ToString(dr[PERSONA_RUTAAVATAR]);
            oferta.tituloVacante = Convert.ToString(dr[OFERTA_TITULOVACANTE]);
            oferta.descripcionVacante = Convert.ToString(dr[OFERTA_DESCRIPCIONVACANTE]);
            oferta.idModalidad = Convert.ToInt32(dr[OFERTA_IDMODALIDAD]);
            oferta.tiempoExperiencia = Convert.ToInt32(dr[OFERTA_TIEMPOEXPERIENCIA]);
            oferta.cantidadVacantes = Convert.ToInt32(dr[OFERTA_CANTIDADVACANTES]);
            oferta.nroHojasVidaAplicada = Convert.ToInt32(dr[OFERTA_NROHOJASVIDAAPLICADA]);
            oferta.cargo = Convert.ToString(dr[OFERTA_CARGO]);
            oferta.fechaPublicacion = Convert.ToDateTime(dr[OFERTA_FECHAPUBLICACION]);
            oferta.fechaVencimiento = Convert.ToDateTime(dr[OFERTA_FECHAVENCIMIENTO]);
            oferta.idNivelEstudiosRequeridos = Convert.ToInt32(dr[OFERTA_IDNIVELESTUDIOSREQUERIDOS]);
            oferta.idRangoSalario = Convert.ToInt32(dr[OFERTA_IDRANGOSALARIO]);
            oferta.RangoSalario = Convert.ToString(dr[OFERTA_RANGOSALARIO]);
            oferta.idCiudadVacante = Convert.ToInt32(dr[OFERTA_IDCIUDADVACANTE]);
            oferta.nomCiudad = Convert.ToString(dr[OFERTA_NOMCIUDAD]);
            oferta.idSectorEconomico = Convert.ToInt32(dr[OFERTA_IDSECTORECONOMICO]);
            oferta.disponibilidadViajar = Convert.ToBoolean(dr[OFERTA_DISPONIBILIDADVIAJAR]);
            oferta.cambioCiudadResidencia = Convert.ToBoolean(dr[OFERTA_CAMBIOCIUDADRESIDENCIA]);
            oferta.esDestacada = Convert.ToBoolean(dr[OFERTA_ESDESTACADA]);
            oferta.estado = Convert.ToString(dr[OFERTA_ESTADO]);
            oferta.fechaAprobacion = dr[OFERTA_FECHAAPROBACION] == Convert.DBNull ? dateNull : Convert.ToDateTime(dr[OFERTA_FECHAAPROBACION]);
            oferta.idOcupacion1 = dr[OFERTA_IDOCUPACION1] == Convert.DBNull ? intNull : Convert.ToInt32(dr[OFERTA_IDOCUPACION1]); 
            oferta.idOcupacion2 = dr[OFERTA_IDOCUPACION2] == Convert.DBNull ? intNull : Convert.ToInt32(dr[OFERTA_IDOCUPACION2]);
            oferta.idOcupacion3 = dr[OFERTA_IDOCUPACION3] == Convert.DBNull ? intNull : Convert.ToInt32(dr[OFERTA_IDOCUPACION3]);
            oferta.idOcupacion4 = dr[OFERTA_IDOCUPACION4] == Convert.DBNull ? intNull : Convert.ToInt32(dr[OFERTA_IDOCUPACION4]);
            oferta.idOcupacion5 = dr[OFERTA_IDOCUPACION5] == Convert.DBNull ? intNull : Convert.ToInt32(dr[OFERTA_IDOCUPACION5]);
            oferta.idOcupacion6 = dr[OFERTA_IDOCUPACION6] == Convert.DBNull ? intNull : Convert.ToInt32(dr[OFERTA_IDOCUPACION6]);
            oferta.idOcupacion7 = dr[OFERTA_IDOCUPACION7] == Convert.DBNull ? intNull : Convert.ToInt32(dr[OFERTA_IDOCUPACION7]);
            oferta.idOcupacion8 = dr[OFERTA_IDOCUPACION8] == Convert.DBNull ? intNull : Convert.ToInt32(dr[OFERTA_IDOCUPACION8]);
            oferta.idOcupacion9 = dr[OFERTA_IDOCUPACION9] == Convert.DBNull ? intNull : Convert.ToInt32(dr[OFERTA_IDOCUPACION9]);
            oferta.idOcupacion10 = dr[OFERTA_IDOCUPACION10] == Convert.DBNull ? intNull : Convert.ToInt32(dr[OFERTA_IDOCUPACION10]);
            //oferta.nomOcupacion = Convert.ToString(dr[OFERTA_NOMOCUPACION]);
            //oferta.nomOcupacion2 = Convert.ToString(dr[OFERTA_NOMOCUPACION2]);
            //oferta.nomOcupacion3 = Convert.ToString(dr[OFERTA_NOMOCUPACION3]);
            //oferta.nomOcupacion4 = Convert.ToString(dr[OFERTA_NOMOCUPACION4]);
            //oferta.nomOcupacion5 = Convert.ToString(dr[OFERTA_NOMOCUPACION5]);
            //oferta.nomOcupacion6 = Convert.ToString(dr[OFERTA_NOMOCUPACION6]);
            //oferta.nomOcupacion7 = Convert.ToString(dr[OFERTA_NOMOCUPACION7]);
            //oferta.nomOcupacion8 = Convert.ToString(dr[OFERTA_NOMOCUPACION8]);
            //oferta.nomOcupacion9 = Convert.ToString(dr[OFERTA_NOMOCUPACION8]);
            //oferta.nomOcupacion10 = Convert.ToString(dr[OFERTA_NOMOCUPACION9]);
            oferta.Observaciones = Convert.ToString(dr[OFERTA_OBSERVACIONES]);
            return oferta;

        }
        private OfertaVO cargarEstadisticaVO(DataRow dr)
        {
            OfertaVO oferta = new OfertaVO();
            oferta.idEmpresa = Convert.ToInt32(dr[OFERTA_IDEMPRESA]);
            oferta.pendientes = Convert.ToInt32(dr[OFERTA_PENDIENTES]);
            oferta.activas = Convert.ToInt32(dr[OFERTA_ACTIVAS]);
            oferta.vencidas = Convert.ToInt32(dr[OFERTA_VENCIDAS]);
            oferta.seguidores = Convert.ToInt32(dr[OFERTA_SEGUIDORES]);
            oferta.hojasdeVida = Convert.ToInt32(dr[OFERTA_HOJASDEVIDA]);
            return oferta;

        }
        public List<OfertaVO> TraeOfertas(OfertaVO Ofertas)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    //Se adicionan los parametros para la busqueda del objeto
                    new Parametro(OFERTA_IDUSUARIO, Ofertas.idUsuario, DbType.Int32),

                };

                DataTable dt = this.EjecutarStoredProcedureDataTable(OFERTA_TRAEROFERTASAPR, valParam);

                List<OfertaVO> newOferta = new List<OfertaVO>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        OfertaVO Oferta = new OfertaVO();
                        Oferta.idOferta = Convert.ToInt32(dr[OFERTA_IDOFERTA]);
                        Oferta.tituloVacante = Convert.ToString(dr[OFERTA_TITULOVACANTE]);
                        Oferta.descripcionVacante = Convert.ToString(dr[OFERTA_DESCRIPCIONVACANTE]);
                        Oferta.tiempoExperiencia = Convert.ToInt32(dr[OFERTA_TIEMPOEXPERIENCIA]);
                        Oferta.nomEmpresa = Convert.ToString(dr[OFERTA_NOMEMPRESA]);
                        Oferta.RangoSalario = Convert.ToString(dr[OFERTA_NOMRANGOSALARIAL]);
                        Oferta.nomCiudad = Convert.ToString(dr[OFERTA_NOMCIUDAD]);
                        Oferta.cantidadVacantes = Convert.ToInt32(dr[OFERTA_CANTIDADVACANTES]);
                        Oferta.ofertasConsumidas = Convert.ToInt32(dr[OFERTA_CONSUMIDA]);
                        Oferta.fechaInicia = Convert.ToDateTime(dr[OFERTA_FECHAINICIA]);
                        Oferta.fechaFinaliza = Convert.ToDateTime(dr[OFERTA_FECHAFINALIZA]);
                        Oferta.cargo = Convert.ToString(dr[OFERTA_CARGO]);
                        Oferta.fechaPublicacion = Convert.ToDateTime(dr[OFERTA_FECHAPUBLICACION]);
                        Oferta.fechaVencimiento = Convert.ToDateTime(dr[OFERTA_FECHAVENCIMIENTO]);
                        Oferta.NivelEstudios = Convert.ToString(dr[OFERTA_NIVELESTUDIOS]);
                        newOferta.Add(Oferta);
                    }
                }
                return newOferta;
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
        public void AprobarOfertas(OfertaVO Oferta)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    new Parametro(OFERTA_IDOFERTA, Oferta.idOferta, DbType.Int32),
                    new Parametro(OFERTA_IDUSUARIO, Oferta.idUsuario, DbType.Int32),
                    new Parametro(OFERTA_ESTADO, Oferta.estado, DbType.String),
                    new Parametro(OFERTA_OBSERVACIONES, Oferta.Observaciones, DbType.String),

            };
                this.EjecutarStoredProcedure(OFERTA_APROBARPUBLICAR, valParam);

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


    }

}
