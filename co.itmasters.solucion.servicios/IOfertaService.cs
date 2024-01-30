﻿using co.itmasters.solucion.vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace co.itmasters.solucion.servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IOfertaService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IOfertaService
    {
        [OperationContract]
        OfertaVO GetOfertaPersonaDetalle(OfertaVO Ofertas);
        [OperationContract]
        List<OfertaVO> GetOfertaPersona(OfertaVO Ofertas);
        [OperationContract]
        OfertaVO TraeOfertaDetalle(OfertaVO Ofertas);
        [OperationContract]
        OfertaVO TraerEstadisticasOferta(OfertaVO Ofertas);
        [OperationContract]
        List<OfertaVO> TraeOfertaEmpresa(OfertaVO Ofertas);
        [OperationContract]
        List<OfertaVO> TraeEstadoOfertaEmpresa(OfertaVO Estado);
        [OperationContract]
        List<OfertaVO> TraeEstadoOferta(OfertaVO Estado);
        [OperationContract]
        void AnulaOferta(OfertaVO Oferta);
        [OperationContract]
        void PublicarOferta(OfertaVO Oferta);
    }
}