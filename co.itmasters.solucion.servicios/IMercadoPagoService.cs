using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace co.itmasters.solucion.servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IMercadoPago" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IMercadoPagoService
    {
        [OperationContract]
        void RecibirInformacionBackUrl(string preferenceId, string status, string collection_id, string payment_id, string external_reference, string payment_type, string merchant_order_id, string site_id, string processing_mode, string merchant_account_id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void ProcessNotification(Stream inputStream);
    }
 
}
