using co.itmasters.solucion.negocio;
using co.itmasters.solucion.vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace co.itmasters.solucion.servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "OfertaService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione OfertaService.svc o OfertaService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class OfertaService : IOfertaService
    {
        private OfertaNegocio _oferta;

        public List<OfertaVO> TraePlanesAdquiridosEmpresa(OfertaVO Oferta)
        {

            try
            {
                _oferta = new OfertaNegocio();
                return _oferta.TraePlanesAdquiridosEmpresa(Oferta);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public OfertaVO GetOfertaPersonaDetalle(OfertaVO Oferta)
        {

            try
            {
                _oferta = new OfertaNegocio();
                return _oferta.GetOfertaPersonaDetalle(Oferta);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public List<OfertaVO> GetOfertaPersona(OfertaVO Oferta)
        {

            try
            {
                _oferta = new OfertaNegocio();
                return _oferta.GetOfertaPersona(Oferta);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public void AnulaOferta(OfertaVO Oferta)
        {
            try
            {

                _oferta = new OfertaNegocio();
                _oferta.AnulaOferta(Oferta);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public void PublicarOferta(OfertaVO Oferta)
        {
            try
            {

                _oferta = new OfertaNegocio();
                _oferta.PublicarOferta(Oferta);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public OfertaVO TraeOfertaDetalle(OfertaVO Ofertas)
        {
            try
            {
                _oferta = new OfertaNegocio();
                return _oferta.TraeOfertaDetalle(Ofertas);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public OfertaVO TraerEstadisticasOferta(OfertaVO Ofertas)
        {
            try
            {
                _oferta = new OfertaNegocio();
                return _oferta.TraerEstadisticasOferta(Ofertas);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public List<OfertaVO> TraeOfertaEmpresa(OfertaVO Ofertas)
        {
            try
            {

                _oferta = new OfertaNegocio();
                return _oferta.TraeOfertaEmpresa(Ofertas);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public List<OfertaVO> TraeEstadoOfertaEmpresa(OfertaVO Estado)
        {

            try
            {

                _oferta = new OfertaNegocio();
                return _oferta.TraeEstadoOfertaEmpresa(Estado);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public List<OfertaVO> TraeEstadoOferta(OfertaVO Estado)
        {

            try
            {

                _oferta = new OfertaNegocio();
                return _oferta.TraeEstadoOferta(Estado);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
    }
}
