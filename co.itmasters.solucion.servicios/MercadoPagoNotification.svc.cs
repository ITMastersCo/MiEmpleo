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
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using MercadoPago.Resource.AdvancedPayment;

namespace co.itmasters.solucion.servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "MercadoPagoNotification" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione MercadoPagoNotification.svc o MercadoPagoNotification.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class MercadoPagoNotification : IMercadoPagoNotification
    {
        private MercadoPagoService _MercadoPago;
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

             // Tranforma XML en un Tipo PaymentNotification
            XmlSerializer serializer = new XmlSerializer(typeof(PaymentNotification));
            using (TextReader reader = new StringReader(message.ToString()))
            {
                PaymentNotification notification = (PaymentNotification)serializer.Deserialize(reader);
                {
                    try
                    {
                        if (notification != null)
                        {
                            WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.OK;
                            ProcessValidNotification(notification);
                            
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
        
        public void  ProcessValidNotification(PaymentNotification notification)
        {
            try
            {

                switch (notification.Type)
                {
                    case "payment":
                        //Consulta el pago en la Api
                        co.itmasters.solucion.servicios.code.MercadoPagoApi.Models.Payment payment =
                            MercadoPagoApi.GetPayment(notification.Data.Id);
                        if(payment != null) 
                        ProcessPaymentNotification(payment); 
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

        private void ProcessPaymentNotification(co.itmasters.solucion.servicios.code.MercadoPagoApi.Models.Payment payment)
        {
            
          try
            {
                switch (payment.status)
                {
                    case PaymentStatus.Approved:
                        MercadoPagoService _MercadoPagoServiceApproved = new MercadoPagoService();
                        _MercadoPagoServiceApproved.UpdatePayment(payment, EstadoPago.ESTADO_CONSOLIDADO);
                        break;
                    case PaymentStatus.InProcess:
                        MercadoPagoService _MercadoPagoServiceInProcess = new MercadoPagoService();
                        _MercadoPagoServiceInProcess.UpdatePayment(payment, EstadoPago.ESTADO_PENDIENTE);
                        break; 
                    case PaymentStatus.Rejected:
                        MercadoPagoService _MercadoPagoServiceRejected = new MercadoPagoService();
                        _MercadoPagoServiceRejected.UpdatePayment(payment, EstadoPago.ESTADO_RECHAZADO);
                        break;
                    default:
                        MercadoPagoService _MercadoPagoServiceOther = new MercadoPagoService();
                        _MercadoPagoServiceOther.UpdatePayment(payment, payment.status);
                        break;
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
