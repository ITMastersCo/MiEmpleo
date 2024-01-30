using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MercadoPago.Config;
using MercadoPago.Client;
using co.itmasters.solucion.servicios.MercadoPagoNotification;
using MercadoPago.Resource.Payment;

using Newtonsoft.Json;

namespace co.itmasters.solucion.servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "MercadoPago" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione MercadoPago.svc o MercadoPago.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class MercadoPagoNotificationService : IMercadoPagoNotificationService
    {
        public void DoWork()
        {
        }
        public void ProcessNotification(Stream inputStream)
        {
            MercadoPagoConfig.AccessToken = "YOUR_ACCESS_TOKEN";

            using (var reader = new StreamReader(inputStream))
            {
                var rawNotification = reader.ReadToEnd();
                var notification = JsonConvert.DeserializeObject<Notification>(rawNotification);

                if (notification != null)
                {
                    ProcessValidNotification(notification);
                }
                else
                {
                    // Handle invalid notification
                }
            }
        }

        private void ProcessValidNotification(Notification notification)
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

        private void ProcessPaymentNotification(Payment payment)
        {
            if (payment.Status == PaymentStatus.Approved)
            {
                // Handle approved payment
            }
            // Add other cases for other payment statuses if needed
        }
    }
}
