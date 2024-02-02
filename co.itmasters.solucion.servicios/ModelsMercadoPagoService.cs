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

    [XmlRoot("root")]
    public class PaymentNotification
    {
        [XmlElement("action")]
        public string Action { get; set; }

        [XmlElement("timestamp")]
        public string Timestamp { get; set; }
        

        [XmlElement("api_version")]
        public string ApiVersion { get; set; }

        [XmlElement("data")]
        public string Data { get; set; }

        [XmlElement("date_created")]
        public string DateCreated { get; set; }

        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("live_mode")]
        public bool LiveMode { get; set; }

        [XmlElement("type")]
        public string Type { get; set; }

        [XmlElement("user_id")]
        public long UserId { get; set; }
    }

    public class Paymentnotification_DataObject
    {
        [XmlElement("id")]
        public string Id { get; set; }
    }

    class XSignatureData
    {
        public string Timestamp { get; set; }
        public string V1 { get; set; }
    }


}