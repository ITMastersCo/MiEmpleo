using co.itmasters.solucion.servicios;
using co.itmasters.solucion.vo;
using MercadoPago.Config;
using MercadoPago.Resource.Payment;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace co.itmasters.solucion.servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "MercadoPagoNotification" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione MercadoPagoNotification.svc o MercadoPagoNotification.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class MercadoPagoNotification : IMercadoPagoNotification
    {
        public MessageProperties IncomingWebRequestContext { get; private set; }

        public void ProcessNotification()
        {
            // Acceder al contexto de la operación actual
            OperationContext context = OperationContext.Current;
            IncomingWebRequestContext = context.IncomingMessageProperties;

            // Obtener el mensaje de la solicitud
            Message message = context.RequestContext.RequestMessage;

            XmlSerializer serializer = new XmlSerializer(typeof(PaymentNotification));
            using (TextReader reader = new StringReader(message.ToString()))
            {
                PaymentNotification rootObject = (PaymentNotification)serializer.Deserialize(reader);
                Console.WriteLine("Id: " + rootObject.Id);
            }
            MercadoPagoConfig.AccessToken = "APP_USR-2148574929506385-013011-2a326a05936b10aaeafa5b0b78b61be6-1660977390";
            try
            {
                //var serializer = new DataContractJsonSerializer(typeof(PaymentNotification));
                //using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                //{
                //    //var notification = (PaymentNotification)serializer.ReadObject(stream);
                //    string notification = null;


                //    if (notification != null)
                //    {
                //        ProcessValidNotification(notification);
                //        WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Accepted;
                //    }
                //    else
                //    {
                //        WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Unused;
                //    }


                //}
               
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }

        }

        private void ProcessValidNotification(dynamic notification)
        {
            try
            {

                switch (notification.ToString())
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
