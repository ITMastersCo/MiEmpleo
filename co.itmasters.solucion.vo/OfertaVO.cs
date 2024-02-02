using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace co.itmasters.solucion.vo
{
    [Serializable]
    public class OfertaVO
    {
        public int idEmpresa { get; set; }
        public int  idPersona { get; set; }
        public int? idUsuario { get; set; }
        public int? idOferta { get; set; }
        public int? idPlan { get; set; }
        public int? idPlanAdquirido { get; set; }
        public string tituloVacante { get; set; }
        public string numIdentificacion { get; set; }
        public string descripcionVacante { get; set; }
        public int? idModalidad { get; set; }
        public int? tiempoExperiencia { get; set; }
        public int? unidadMedidaExperiencia { get; set; }
        public int? cantidadVacantes { get; set; }
        public int? nroHojasVidaAplicada { get; set; }
        public string cargo { get; set; }
        public DateTime? fechaPublicacion { get; set; }
        public DateTime? fechaVencimiento { get; set; }
        public int? idNivelEstudiosRequeridos { get; set; }
        public int? idOcupacion { get; set; }
        public int? idOcupacion1 { get; set; }
        public int? idOcupacion2 { get; set; }
        public int? idOcupacion3 { get; set; }
        public int? idOcupacion4 { get; set; }
        public int? idOcupacion5 { get; set; }
        public int? idOcupacion6 { get; set; }
        public int? idOcupacion7 { get; set; }
        public int? idOcupacion8 { get; set; }
        public int? idOcupacion9 { get; set; }
        public int? idOcupacion10 { get; set; }
        public string nomOcupacion { get; set; }
        public string nomOcupacion2 { get; set; }
        public string nomOcupacion3 { get; set; }
        public string nomOcupacion4 { get; set; }
        public string nomOcupacion5 { get; set; }
        public string nomOcupacion6 { get; set; }
        public string nomOcupacion7 { get; set; }
        public string nomOcupacion8 { get; set; }
        public string nomOcupacion9 { get; set; }
        public string nomOcupacion10 { get; set; }
        public int? idRangoSalario { get; set; }
        public int? idCiudadVacante { get; set; }
        public int? idMunicipioVacante { get; set; }
        public int? idSectorEconomico { get; set; }
        public Boolean? disponibilidadViajar { get; set; }
        public Boolean? cambioCiudadResidencia { get; set; }
        public Boolean? esDestacada { get; set; }
        public Boolean? esConfidencial { get; set; }
        public string estado { get; set; }
        public string nomCiudad { get; set; }
        public DateTime fechaAprobacion { get; set; }
        public string Observaciones { get; set; }
        public string  usuarioCrea { get; set; }
        public DateTime? fechaCrea { get; set; }
        public string usuarioModfica { get; set; }
        public DateTime? fechaModifica { get; set; }
        public string nomEmpresa { get; set; }
        //Campos de ofertas adquiridas
        public DateTime? fechaInicia { get; set; }
        public DateTime? fechaFinaliza { get; set; }
        public DateTime? fechaUltimaOferta { get; set; }
        public int? numeroOfertas { get; set; }
        public int? ofertasConsumidas { get; set; }
        public string RangoSalario { get; set; }
        //Planes.oferta
        public string nomPlan { get; set; }
        public int? nroHojasPorOferta { get; set; }
        public int? nroOfertas { get; set; }
        public Boolean? filtroCandidatos { get; set; }
        public Boolean? multiusuario { get; set; }
        public int? diasPublicacionOferta { get; set; }
        public Boolean? ofertaDestacada { get; set; }
        public Boolean? ofertaConfidencial { get; set; }
        public Boolean? preguntasDeFiltro { get; set; }
        public Boolean? capacitaciones { get; set; }
        public int? vigenciaPlan { get; set; }
        public Boolean? entrevistaZoom { get; set; }
        public double? valorPlan { get; set; }
        //    otros campos
        public string typeModify { get; set; }
        public int? activas { get; set; }
        public int? vencidas { get; set; }
        public int? pendientes { get; set; }
        public int? hojasdeVida { get; set; }
        public int? seguidores { get; set; }
        public int? totHv { get; set; }
        public int? hvVista { get; set; }

        //Campos de Mercado Pago

        public string preference_id { get; set; }

    }
}

