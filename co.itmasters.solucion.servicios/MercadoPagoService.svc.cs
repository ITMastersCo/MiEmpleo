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
using System.Web.Configuration;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace co.itmasters.solucion.servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "MercadoPago" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione MercadoPago.svc o MercadoPago.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class MercadoPagoService : IMercadoPagoService
    {
        EmpresaService _Empresa;
        OfertaService _Oferta;


        /// <summary>
        /// Consulta GET de un pago.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public PaymentVO GetPayment(string id)
        {
            // Activa SSL para entorno de desarrollo 
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            string ApiUrl = "https://api.mercadopago.com/v1/";
            string AccesToken = "APP_USR-2148574929506385-013011-2a326a05936b10aaeafa5b0b78b61be6-1660977390";


            var url = $"{ApiUrl}payments/{id}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Headers["Authorization"] = $"Bearer {AccesToken}";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null; ;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();

                            PaymentVO payment = JsonConvert.DeserializeObject<PaymentVO>(responseBody);


                            return payment;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                return null;
                throw new Exception();
            }
        }

        public void UpdatePayment(PaymentVO payment, string estadoPago)
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


                if (estadoPago == EstadoPago.ESTADO_CONSOLIDADO) {

                    var newPago = new OfertaVO();
                    newPago.typeModify = TipoConsulta.MODIFY_INSERT;
                    newPago.descripcionPago = payment.description;
                    newPago.payment_id = payment.id.ToString();
                    newPago.payment_method = payment.payment_type_id;
                    newPago.idPlanAdquirido = Convert.ToInt16(payment.additional_info.items[0].id);
                    newPago.estado = EstadoPago.ESTADO_CONSOLIDADO;
                    newPago.valorPago = Convert.ToInt32(payment.transaction_amount);

                    _Oferta = new OfertaService();
                    _Oferta.ModifyPagos(newPago);
                }
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    
    }
}
