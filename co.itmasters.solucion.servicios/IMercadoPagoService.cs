using co.itmasters.solucion.vo;
using MercadoPago.Client.Preference;
using MercadoPago.Resource.Preference;
using co.itmasters.solucion.servicios.code.MercadoPagoApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace co.itmasters.solucion.servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IMercadoPago" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IMercadoPagoService
    {
        [OperationContract]
        Task<Preference>  CrearPreferencia(EmpresaVO newPlanAdquirido);

        [OperationContract]
        void UpdatePayment(Payment payment, string estadoPago);

        
    }
 
}
