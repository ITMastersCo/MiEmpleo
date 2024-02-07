using co.itmasters.solucion.servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace co.itmasters.solucion.servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IMercadoPagoNotification" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IMercadoPagoNotification
    {
        [OperationContract]
        [WebInvoke(Method = "POST", 
            UriTemplate = "ProcessNotification",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
         void ProcessNotification();

    }
}
