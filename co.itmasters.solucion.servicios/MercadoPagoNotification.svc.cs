using co.itmasters.solucion.servicios;
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

namespace co.itmasters.solucion.servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "MercadoPagoNotification" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione MercadoPagoNotification.svc o MercadoPagoNotification.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class MercadoPagoNotification : IMercadoPagoNotification
    {
        private string ClaveSecereta;
        public void ProcessNotification()
        {
            // Acceder al contexto de la operación actual
            OperationContext context = OperationContext.Current;

            // Obtener el mensaje de la solicitud
            Message message = context.RequestContext.RequestMessage;

            XmlSerializer serializer = new XmlSerializer(typeof(PaymentNotification));
            using (TextReader reader = new StringReader(message.ToString()))
            {
                PaymentNotification notification = (PaymentNotification)serializer.Deserialize(reader);
                if (notification != null)
                {
                    // Acceder al contexto de la solicitud actual
                    IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;

                    // Obtener la cadena X-Signature del encabezado de la solicitud
                    string xSignatureHeader = request.Headers["X-Signature"];

                    // Convertir la cadena X-Signature en un objeto XSignatureData
                    XSignatureData xSignature = ParseXSignature(xSignatureHeader);

                    // Obtener la propiedad de la solicitud entrante
                    string requestUrl = request.UriTemplateMatch.RequestUri.AbsoluteUri;
                    // Obtener el URL path de la solicitud
                    Uri uri = new Uri(requestUrl);
                    //Usar en Produccion
                    string urlPath = uri.Host + uri.AbsolutePath;
                    // Obtener los query params de la solicitud
                    string dataIdUrl = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["data.id"];
                    string typeUrl = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["type"];
                    // Plantilla para la generación del HMAC

                    string template = $"post;{$"lcnnbg8m-3487.use2.devtunnels.ms{uri.AbsolutePath}"};data.id={dataIdUrl};type={typeUrl};user-agent:mercadopago webhook v1.0;{xSignature.Timestamp};action:{notification.Action};api_version:{notification.ApiVersion};date_created:{String.Format("{0:yyyy-MM-dd'T'HH:mm:ssK}", notification.DateCreated)};id:{notification.Id};live_mode:{notification.LiveMode};type:{notification.Type};user_id:{notification.UserId};";
                    string claveSercretaNotification = Tools.CalculateHMAC(template, "df7431336faceaad8906add358db5b7e7bf0264dc85cf9507f018154f856ebc9");

                    if (xSignature != null && claveSercretaNotification == xSignature.V1)
                    {

                    }
                }
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
        static XSignatureData ParseXSignature(string xSignature)
        {
            // Dividir la cadena en pares clave-valor
            string[] parts = xSignature.Split(',');

            // Crear un diccionario para almacenar los pares clave-valor
            Dictionary<string, string> signatureDict = new Dictionary<string, string>();

            // Iterar sobre cada par clave-valor
            foreach (string part in parts)
            {
                // Dividir el par clave-valor en su clave y valor
                string[] keyValue = part.Split('=');

                // Asegurarse de que haya exactamente dos partes (clave y valor)
                if (keyValue.Length == 2)
                {
                    // Agregar el par clave-valor al diccionario
                    signatureDict.Add(keyValue[0], keyValue[1]);
                }
                else
                {
                    // Manejar errores de formato
                    Console.WriteLine($"Error: El par clave-valor '{part}' no tiene el formato correcto.");
                }
            }

            // Convertir los datos del diccionario a un objeto XSignatureData
            XSignatureData data = new XSignatureData();
            if (signatureDict.ContainsKey("ts"))
            {
                data.Timestamp = signatureDict["ts"];
            }
            if (signatureDict.ContainsKey("v1"))
            {
                data.V1 = signatureDict["v1"];
            }

            return data;
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
