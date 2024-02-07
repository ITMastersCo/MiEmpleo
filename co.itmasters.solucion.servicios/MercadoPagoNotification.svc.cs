using co.itmasters.solucion.servicios.code.MercadoPagoApi;
using co.itmasters.solucion.servicios.code;
using co.itmasters.solucion.vo;
using MercadoPago.Config;
using MercadoPago.Resource.Payment;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Security.Policy;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using System.Text.Json;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace co.itmasters.solucion.servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "MercadoPagoNotification" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione MercadoPagoNotification.svc o MercadoPagoNotification.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class MercadoPagoNotification : IMercadoPagoNotification
    {
             /// <summary>
        /// Recibe la notificaion de mercado pago, la prosesa y envia una respuesta.
        /// </summary>
        /// <exception cref="FaultException"></exception>
        public void ProcessNotification()
        {
        MercadoPagoConfig.AccessToken = "APP_USR-2148574929506385-013011-2a326a05936b10aaeafa5b0b78b61be6-1660977390";


            // Acceder al contexto de la operación actual
            OperationContext context = OperationContext.Current;

            // Obtener el mensaje de la solicitud
            Message message = context.RequestContext.RequestMessage;
         
            XmlSerializer serializer = new XmlSerializer(typeof(PaymentNotification));
            using (TextReader reader = new StringReader(message.ToString()))
            {
                PaymentNotification notification = (PaymentNotification)serializer.Deserialize(reader);
                {
                    try
                    {
                        if (notification != null)
                        {

                            Payment payment = MercadoPagoApi.GetItem(notification.Id);
                            if (payment != null)
                            {
                                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.OK;
                            }
                            else
                            {
                                 WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
                            }
                            
                                 
                                


                            }
                            else
                            {
                                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Accepted;
                            }



                    }
                    catch (Exception err)
                    {
                        Log.Write(err.Message, Log.ERROR);
                        throw new FaultException(new FaultReason(err.Message));
                    }
                }
            }
        }
        
        public void  ProcessValidNotificationAsync(PaymentNotification notification)
        {
            try
            {

                switch (notification.Type)
                {
                    case "payment":
                        
                        
                        //ProcessPaymentNotification(notification.Data);
                        break;
                    // Add other cases for other topics if needed
                    default:
                        // Handle unsupported topic
                        break;
                }
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }


        }

        private void ProcessPaymentNotification(Payment payment)
        {
            try
            {
                if (payment.Status == PaymentStatus.Approved)
                {
                    // Handle approved payment
                }
                // Add other cases for other payment statuses if needed
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }

            
        }


    }
}
