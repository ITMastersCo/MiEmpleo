using co.itmasters.solucion.servicios.MercadoNotification;
using MercadoPago.Config;
using MercadoPago.Resource.Payment;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace co.itmasters.solucion.servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "MercadoPagoNotification" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione MercadoPagoNotification.svc o MercadoPagoNotification.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class MercadoPagoNotification : IMercadoPagoNotification
    {
        public void ProcessNotification(Stream inputStream)
        {
            try
            {

                MercadoPagoConfig.AccessToken = "APP_USR-2148574929506385-013011-2a326a05936b10aaeafa5b0b78b61be6-1660977390";

                using (var reader = new StreamReader(inputStream))
                {
                    var rawNotification = reader.ReadToEnd();
                    var notification = JsonConvert.DeserializeObject<Notification>(rawNotification);

                    if (notification != null)
                    {
                        ProcessValidNotification(notification);
                        WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.BadRequest;
                    }
                    
                }
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }

        }

        private void ProcessValidNotification(Notification notification)
        {
            try
            {

                switch (notification.Topic)
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
