using MercadoPago.Resource.Payment;

using MercadoPago.Client.Preference;
using MercadoPago.Config;
using MercadoPago.Resource.Preference;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using co.itmasters.solucion.vo;
using MercadoPago.Resource.User;
using co.itmasters.solucion.servicios.code;
using System.Numerics;
using co.itmasters.solucion.servicios.code.MercadoPagoApi.Models;

namespace co.itmasters.solucion.servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "MercadoPago" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione MercadoPago.svc o MercadoPago.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class MercadoPagoService : IMercadoPagoService
    {    
        EmpresaService _Empresa;
        OfertaService _Oferta;
        public async Task<Preference> CrearPreferencia(EmpresaVO newPlanAdquirido)
        {

            MercadoPagoConfig.AccessToken = "APP_USR-2148574929506385-013011-2a326a05936b10aaeafa5b0b78b61be6-1660977390";

            //Crea el objeto de request de la preference
            var request = new PreferenceRequest
            {
                Items = new List<PreferenceItemRequest>
                      {
                        new PreferenceItemRequest
                        {
                            Title = newPlanAdquirido.Oferta.nomPlan,
                            Quantity = 1,
                            CurrencyId = "COP",
                            UnitPrice = Convert.ToInt32(newPlanAdquirido.Oferta.valorPlan),
                        }

                },
                BackUrls = new PreferenceBackUrlsRequest
                {
                    Success = "http://localhost:8080/Empresa/PagoAprobado.aspx",
                    Failure = "http://localhost:8080/Empresa/PagoAprobado.aspx",
                    Pending = "http://localhost:8080/Empresa/PagoAprobado.aspx",
                },
                AutoReturn = "approved",
            };

            // Crea la preferencia usando el client
            var client = new PreferenceClient();
            Preference preference = await client.CreateAsync(request);
            return preference;
        }
        public void UpdatePayment(co.itmasters.solucion.servicios.code.MercadoPagoApi.Models.Payment payment, string estadoPago)
        {
            try
            {
                EmpresaVO newEmpresa = new EmpresaVO();
                OfertaVO newPlan = new OfertaVO();
                newEmpresa.typeModify = TipoConsulta.MODIFY_UPDATE;
                newPlan.idPlanAdquirido = Convert.ToInt32(payment.additional_info.items[0].id);
                newPlan.estado = estadoPago;
                newPlan.payment_id = payment.id.ToString();
                
                newEmpresa.Oferta = newPlan;

                _Empresa = new EmpresaService();
                _Empresa.CreatePlanAdquirido(newEmpresa);



                var newPago = new OfertaVO();
                newPago.typeModify = TipoConsulta.MODIFY_INSERT;
                newPago.payment_id = payment.id.ToString() ;
                newPago.payment_method = payment.payment_method.ToString();
                newPago.idPlanAdquirido = Convert.ToInt16(payment.additional_info.items[0].id);
                switch (payment.status)
                {
                    case PaymentStatus.Approved:
                        newPago.estado = EstadoPago.ESTADO_CONSOLIDADO;

                        break;
                    case PaymentStatus.InProcess:
                        newPago.estado = EstadoPago.ESTADO_PENDIENTE;
                        break;
                    case PaymentStatus.Rejected:
                        newPago.estado = EstadoPago.ESTADO_RECHAZADO;
                        break;
                    default:
                        break;
                }
                newPago.valorPago = Convert.ToInt32(payment.transaction_amount);

                _Oferta = new OfertaService();
                //_Oferta.ModifyPagos(newPago);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    
    }
}
