﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace co.itmasters.solucion.web.MercadoPagoNotification {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MercadoPagoNotification.IMercadoPagoNotification")]
    public interface IMercadoPagoNotification {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMercadoPagoNotification/ProcessNotification", ReplyAction="http://tempuri.org/IMercadoPagoNotification/ProcessNotificationResponse")]
        void ProcessNotification();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMercadoPagoNotification/ProcessNotification", ReplyAction="http://tempuri.org/IMercadoPagoNotification/ProcessNotificationResponse")]
        System.Threading.Tasks.Task ProcessNotificationAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMercadoPagoNotificationChannel : co.itmasters.solucion.web.MercadoPagoNotification.IMercadoPagoNotification, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MercadoPagoNotificationClient : System.ServiceModel.ClientBase<co.itmasters.solucion.web.MercadoPagoNotification.IMercadoPagoNotification>, co.itmasters.solucion.web.MercadoPagoNotification.IMercadoPagoNotification {
        
        public MercadoPagoNotificationClient() {
        }
        
        public MercadoPagoNotificationClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MercadoPagoNotificationClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MercadoPagoNotificationClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MercadoPagoNotificationClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void ProcessNotification() {
            base.Channel.ProcessNotification();
        }
        
        public System.Threading.Tasks.Task ProcessNotificationAsync() {
            return base.Channel.ProcessNotificationAsync();
        }
    }
}