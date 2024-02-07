using MercadoPago.Resource.Payment;
using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace co.itmasters.solucion.servicios
{
    
    [XmlRoot("root")]
    public class ActionNotification
    {
        [XmlElement("action")]
        public string Action { get; set; }
    }

    /// <summary>
    /// Estructura de notificacion tipo pago de Mercado pago.
    /// </summary>
    [XmlRoot("root")]
    public class PaymentNotification
    {
        [XmlElement("action")]
        public string Action { get; set; }

        [XmlElement("api_version")]
        public string ApiVersion { get; set; }

        [XmlElement("data")]
        public Paymentnotification_DataObject Data { get; set; }

        [XmlElement("date_created")]
        public DateTime DateCreated { get; set; }

        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("live_mode")]
        public bool LiveMode { get; set; }

        [XmlElement("type")]
        public string Type { get; set; }

        /// <summary>
        /// Este lo podemos relacionar con el preference_id.
        /// </summary>
        [XmlElement("user_id")]
        public int UserId { get; set; }
    }

    /// <summary>
    /// Objeto anidado de la notificacion, aqui se encuentra el payment_id
    /// </summary>
    public class Paymentnotification_DataObject
    {
        [XmlElement("id")]
        public int Id { get; set; }
    }

    class XSignatureData
    {
        public string Timestamp { get; set; }
        public string V1 { get; set; }
    }


}