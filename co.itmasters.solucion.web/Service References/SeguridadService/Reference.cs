﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace co.itmasters.solucion.web.SeguridadService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SeguridadService.ISeguridadService")]
    public interface ISeguridadService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridadService/GetCredenciales", ReplyAction="http://tempuri.org/ISeguridadService/GetCredencialesResponse")]
        co.itmasters.solucion.vo.CredencialesVO[] GetCredenciales(int idUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridadService/GetCredenciales", ReplyAction="http://tempuri.org/ISeguridadService/GetCredencialesResponse")]
        System.Threading.Tasks.Task<co.itmasters.solucion.vo.CredencialesVO[]> GetCredencialesAsync(int idUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridadService/RegistroUsuarioTokenEmpresa", ReplyAction="http://tempuri.org/ISeguridadService/RegistroUsuarioTokenEmpresaResponse")]
        void RegistroUsuarioTokenEmpresa(co.itmasters.solucion.vo.UsuarioVO Actor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridadService/RegistroUsuarioTokenEmpresa", ReplyAction="http://tempuri.org/ISeguridadService/RegistroUsuarioTokenEmpresaResponse")]
        System.Threading.Tasks.Task RegistroUsuarioTokenEmpresaAsync(co.itmasters.solucion.vo.UsuarioVO Actor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridadService/RegistroUsuarioFuncionario", ReplyAction="http://tempuri.org/ISeguridadService/RegistroUsuarioFuncionarioResponse")]
        void RegistroUsuarioFuncionario(co.itmasters.solucion.vo.UsuarioVO Actor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridadService/RegistroUsuarioFuncionario", ReplyAction="http://tempuri.org/ISeguridadService/RegistroUsuarioFuncionarioResponse")]
        System.Threading.Tasks.Task RegistroUsuarioFuncionarioAsync(co.itmasters.solucion.vo.UsuarioVO Actor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridadService/RegistroUsuarioEmpresa", ReplyAction="http://tempuri.org/ISeguridadService/RegistroUsuarioEmpresaResponse")]
        void RegistroUsuarioEmpresa(co.itmasters.solucion.vo.UsuarioVO Actor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridadService/RegistroUsuarioEmpresa", ReplyAction="http://tempuri.org/ISeguridadService/RegistroUsuarioEmpresaResponse")]
        System.Threading.Tasks.Task RegistroUsuarioEmpresaAsync(co.itmasters.solucion.vo.UsuarioVO Actor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridadService/RegistroUsuarioCandidato", ReplyAction="http://tempuri.org/ISeguridadService/RegistroUsuarioCandidatoResponse")]
        void RegistroUsuarioCandidato(co.itmasters.solucion.vo.UsuarioVO Actor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridadService/RegistroUsuarioCandidato", ReplyAction="http://tempuri.org/ISeguridadService/RegistroUsuarioCandidatoResponse")]
        System.Threading.Tasks.Task RegistroUsuarioCandidatoAsync(co.itmasters.solucion.vo.UsuarioVO Actor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridadService/ActualizaContrasena", ReplyAction="http://tempuri.org/ISeguridadService/ActualizaContrasenaResponse")]
        void ActualizaContrasena(co.itmasters.solucion.vo.UsuarioVO Actor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridadService/ActualizaContrasena", ReplyAction="http://tempuri.org/ISeguridadService/ActualizaContrasenaResponse")]
        System.Threading.Tasks.Task ActualizaContrasenaAsync(co.itmasters.solucion.vo.UsuarioVO Actor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridadService/validarToken", ReplyAction="http://tempuri.org/ISeguridadService/validarTokenResponse")]
        bool validarToken(co.itmasters.solucion.vo.UsuarioVO token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridadService/validarToken", ReplyAction="http://tempuri.org/ISeguridadService/validarTokenResponse")]
        System.Threading.Tasks.Task<bool> validarTokenAsync(co.itmasters.solucion.vo.UsuarioVO token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridadService/RestablecerContrasena", ReplyAction="http://tempuri.org/ISeguridadService/RestablecerContrasenaResponse")]
        void RestablecerContrasena(co.itmasters.solucion.vo.UsuarioVO Actor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridadService/RestablecerContrasena", ReplyAction="http://tempuri.org/ISeguridadService/RestablecerContrasenaResponse")]
        System.Threading.Tasks.Task RestablecerContrasenaAsync(co.itmasters.solucion.vo.UsuarioVO Actor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridadService/validarUsuario", ReplyAction="http://tempuri.org/ISeguridadService/validarUsuarioResponse")]
        bool validarUsuario(string nombreUsuario, string clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridadService/validarUsuario", ReplyAction="http://tempuri.org/ISeguridadService/validarUsuarioResponse")]
        System.Threading.Tasks.Task<bool> validarUsuarioAsync(string nombreUsuario, string clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridadService/getUsuario", ReplyAction="http://tempuri.org/ISeguridadService/getUsuarioResponse")]
        co.itmasters.solucion.vo.UsuarioVO getUsuario(string nombreUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridadService/getUsuario", ReplyAction="http://tempuri.org/ISeguridadService/getUsuarioResponse")]
        System.Threading.Tasks.Task<co.itmasters.solucion.vo.UsuarioVO> getUsuarioAsync(string nombreUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridadService/buscarPreguntas", ReplyAction="http://tempuri.org/ISeguridadService/buscarPreguntasResponse")]
        co.itmasters.solucion.vo.UsuarioVO[] buscarPreguntas(co.itmasters.solucion.vo.UsuarioVO Usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridadService/buscarPreguntas", ReplyAction="http://tempuri.org/ISeguridadService/buscarPreguntasResponse")]
        System.Threading.Tasks.Task<co.itmasters.solucion.vo.UsuarioVO[]> buscarPreguntasAsync(co.itmasters.solucion.vo.UsuarioVO Usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridadService/EnviarRespuestas", ReplyAction="http://tempuri.org/ISeguridadService/EnviarRespuestasResponse")]
        co.itmasters.solucion.vo.UsuarioVO[] EnviarRespuestas(co.itmasters.solucion.vo.UsuarioVO Usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridadService/EnviarRespuestas", ReplyAction="http://tempuri.org/ISeguridadService/EnviarRespuestasResponse")]
        System.Threading.Tasks.Task<co.itmasters.solucion.vo.UsuarioVO[]> EnviarRespuestasAsync(co.itmasters.solucion.vo.UsuarioVO Usuario);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISeguridadServiceChannel : co.itmasters.solucion.web.SeguridadService.ISeguridadService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SeguridadServiceClient : System.ServiceModel.ClientBase<co.itmasters.solucion.web.SeguridadService.ISeguridadService>, co.itmasters.solucion.web.SeguridadService.ISeguridadService {
        
        public SeguridadServiceClient() {
        }
        
        public SeguridadServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SeguridadServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SeguridadServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SeguridadServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public co.itmasters.solucion.vo.CredencialesVO[] GetCredenciales(int idUser) {
            return base.Channel.GetCredenciales(idUser);
        }
        
        public System.Threading.Tasks.Task<co.itmasters.solucion.vo.CredencialesVO[]> GetCredencialesAsync(int idUser) {
            return base.Channel.GetCredencialesAsync(idUser);
        }
        
        public void RegistroUsuarioTokenEmpresa(co.itmasters.solucion.vo.UsuarioVO Actor) {
            base.Channel.RegistroUsuarioTokenEmpresa(Actor);
        }
        
        public System.Threading.Tasks.Task RegistroUsuarioTokenEmpresaAsync(co.itmasters.solucion.vo.UsuarioVO Actor) {
            return base.Channel.RegistroUsuarioTokenEmpresaAsync(Actor);
        }
        
        public void RegistroUsuarioFuncionario(co.itmasters.solucion.vo.UsuarioVO Actor) {
            base.Channel.RegistroUsuarioFuncionario(Actor);
        }
        
        public System.Threading.Tasks.Task RegistroUsuarioFuncionarioAsync(co.itmasters.solucion.vo.UsuarioVO Actor) {
            return base.Channel.RegistroUsuarioFuncionarioAsync(Actor);
        }
        
        public void RegistroUsuarioEmpresa(co.itmasters.solucion.vo.UsuarioVO Actor) {
            base.Channel.RegistroUsuarioEmpresa(Actor);
        }
        
        public System.Threading.Tasks.Task RegistroUsuarioEmpresaAsync(co.itmasters.solucion.vo.UsuarioVO Actor) {
            return base.Channel.RegistroUsuarioEmpresaAsync(Actor);
        }
        
        public void RegistroUsuarioCandidato(co.itmasters.solucion.vo.UsuarioVO Actor) {
            base.Channel.RegistroUsuarioCandidato(Actor);
        }
        
        public System.Threading.Tasks.Task RegistroUsuarioCandidatoAsync(co.itmasters.solucion.vo.UsuarioVO Actor) {
            return base.Channel.RegistroUsuarioCandidatoAsync(Actor);
        }
        
        public void ActualizaContrasena(co.itmasters.solucion.vo.UsuarioVO Actor) {
            base.Channel.ActualizaContrasena(Actor);
        }
        
        public System.Threading.Tasks.Task ActualizaContrasenaAsync(co.itmasters.solucion.vo.UsuarioVO Actor) {
            return base.Channel.ActualizaContrasenaAsync(Actor);
        }
        
        public bool validarToken(co.itmasters.solucion.vo.UsuarioVO token) {
            return base.Channel.validarToken(token);
        }
        
        public System.Threading.Tasks.Task<bool> validarTokenAsync(co.itmasters.solucion.vo.UsuarioVO token) {
            return base.Channel.validarTokenAsync(token);
        }
        
        public void RestablecerContrasena(co.itmasters.solucion.vo.UsuarioVO Actor) {
            base.Channel.RestablecerContrasena(Actor);
        }
        
        public System.Threading.Tasks.Task RestablecerContrasenaAsync(co.itmasters.solucion.vo.UsuarioVO Actor) {
            return base.Channel.RestablecerContrasenaAsync(Actor);
        }
        
        public bool validarUsuario(string nombreUsuario, string clave) {
            return base.Channel.validarUsuario(nombreUsuario, clave);
        }
        
        public System.Threading.Tasks.Task<bool> validarUsuarioAsync(string nombreUsuario, string clave) {
            return base.Channel.validarUsuarioAsync(nombreUsuario, clave);
        }
        
        public co.itmasters.solucion.vo.UsuarioVO getUsuario(string nombreUsuario) {
            return base.Channel.getUsuario(nombreUsuario);
        }
        
        public System.Threading.Tasks.Task<co.itmasters.solucion.vo.UsuarioVO> getUsuarioAsync(string nombreUsuario) {
            return base.Channel.getUsuarioAsync(nombreUsuario);
        }
        
        public co.itmasters.solucion.vo.UsuarioVO[] buscarPreguntas(co.itmasters.solucion.vo.UsuarioVO Usuario) {
            return base.Channel.buscarPreguntas(Usuario);
        }
        
        public System.Threading.Tasks.Task<co.itmasters.solucion.vo.UsuarioVO[]> buscarPreguntasAsync(co.itmasters.solucion.vo.UsuarioVO Usuario) {
            return base.Channel.buscarPreguntasAsync(Usuario);
        }
        
        public co.itmasters.solucion.vo.UsuarioVO[] EnviarRespuestas(co.itmasters.solucion.vo.UsuarioVO Usuario) {
            return base.Channel.EnviarRespuestas(Usuario);
        }
        
        public System.Threading.Tasks.Task<co.itmasters.solucion.vo.UsuarioVO[]> EnviarRespuestasAsync(co.itmasters.solucion.vo.UsuarioVO Usuario) {
            return base.Channel.EnviarRespuestasAsync(Usuario);
        }
    }
}
