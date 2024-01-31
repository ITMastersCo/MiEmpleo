using Newtonsoft.Json;
using System;

namespace co.itmasters.solucion.servicios.MercadoPagoNotification
{
    public class Notification
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("topic")]
        public string Topic { get; set; }

        [JsonProperty("data")]
        public PaymentNotificationData Data { get; set; }

        [JsonProperty("live_mode")]
        public bool LiveMode { get; set; }

        [JsonProperty("date_created")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("date_last_updated")]
        public DateTime DateLastUpdated { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("sender_id")]
        public string SenderId { get; set; }
    }

    public class PaymentNotificationData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        // Add other properties if needed, such as payment_type_id, currency_id, etc.
    }
}
