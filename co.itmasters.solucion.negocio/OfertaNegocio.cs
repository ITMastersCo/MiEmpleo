﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using co.itmasters.solucion.dao;
using co.itmasters.solucion.vo;

namespace co.itmasters.solucion.negocio
{
    public class OfertaNegocio
    {
        OfertaDao _oferta;
        SeguridadDao _seguridad;
        public OfertaNegocio()
        {
            _oferta = new OfertaDao();
        }
        

        public OfertaVO GetOfertaPersonaDetalle(OfertaVO Oferta)
        {
           return _oferta.GetOfertaPersonaDetalle(Oferta);
        }
        public List<OfertaVO> GetOfertaPersona(OfertaVO Oferta)
        {
           return _oferta.GetOfertaPersona(Oferta);
        }
        public void PublicarOferta(OfertaVO Oferta)
        {
            _oferta.PublicarOferta(Oferta);
        }
        public void AnulaOferta(OfertaVO Oferta)
        {
           _oferta.AnulaOferta(Oferta);
        }
        public OfertaVO TraerEstadisticasOferta(OfertaVO Ofertas)
        {
            return _oferta.TraerEstadisticasOferta(Ofertas);
        }
        public OfertaVO TraeOfertaDetalle(OfertaVO Ofertas)
        {
            return _oferta.TraeOfertaDetalle(Ofertas);
        }
        public List<OfertaVO> TraeOfertaEmpresa(OfertaVO Ofertas)
        {
            return _oferta.TraeOfertaEmpresa(Ofertas);
        }
        public List<OfertaVO> TraeEstadoOfertaEmpresa(OfertaVO Estado)
        {
            return _oferta.TraeEstadoOfertaEmpresa(Estado);
        }
        public List<OfertaVO> TraeEstadoOferta(OfertaVO Estado)
        {
            return _oferta.TraeEstadoOferta(Estado);
        }

    }
}