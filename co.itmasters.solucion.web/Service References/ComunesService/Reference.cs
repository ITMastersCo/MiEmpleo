﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace co.itmasters.solucion.web.ComunesService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ComunesService.IComunesService")]
    public interface IComunesService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IComunesService/ObtenerLista", ReplyAction="http://tempuri.org/IComunesService/ObtenerListaResponse")]
        co.itmasters.solucion.vo.ListaVO[] ObtenerLista(string nombre);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IComunesService/ObtenerLista", ReplyAction="http://tempuri.org/IComunesService/ObtenerListaResponse")]
        System.Threading.Tasks.Task<co.itmasters.solucion.vo.ListaVO[]> ObtenerListaAsync(string nombre);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IComunesService/ObtenerListaFiltro", ReplyAction="http://tempuri.org/IComunesService/ObtenerListaFiltroResponse")]
        co.itmasters.solucion.vo.ListaVO[] ObtenerListaFiltro(string nombre, string idFiltro);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IComunesService/ObtenerListaFiltro", ReplyAction="http://tempuri.org/IComunesService/ObtenerListaFiltroResponse")]
        System.Threading.Tasks.Task<co.itmasters.solucion.vo.ListaVO[]> ObtenerListaFiltroAsync(string nombre, string idFiltro);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IComunesService/ObtenerListaFiltros", ReplyAction="http://tempuri.org/IComunesService/ObtenerListaFiltrosResponse")]
        co.itmasters.solucion.vo.ListaVO[] ObtenerListaFiltros(string nombre, string[] filtro);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IComunesService/ObtenerListaFiltros", ReplyAction="http://tempuri.org/IComunesService/ObtenerListaFiltrosResponse")]
        System.Threading.Tasks.Task<co.itmasters.solucion.vo.ListaVO[]> ObtenerListaFiltrosAsync(string nombre, string[] filtro);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IComunesService/ObtenerListaTablaFiltro", ReplyAction="http://tempuri.org/IComunesService/ObtenerListaTablaFiltroResponse")]
        System.Data.DataTable ObtenerListaTablaFiltro(string nombre, string filtro);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IComunesService/ObtenerListaTablaFiltro", ReplyAction="http://tempuri.org/IComunesService/ObtenerListaTablaFiltroResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> ObtenerListaTablaFiltroAsync(string nombre, string filtro);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IComunesService/ObtenerListaTablaFiltros", ReplyAction="http://tempuri.org/IComunesService/ObtenerListaTablaFiltrosResponse")]
        System.Data.DataTable ObtenerListaTablaFiltros(string nombre, string[] filtro);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IComunesService/ObtenerListaTablaFiltros", ReplyAction="http://tempuri.org/IComunesService/ObtenerListaTablaFiltrosResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> ObtenerListaTablaFiltrosAsync(string nombre, string[] filtro);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IComunesService/InsertDinamico", ReplyAction="http://tempuri.org/IComunesService/InsertDinamicoResponse")]
        void InsertDinamico(string procedimiento, co.itmasters.solucion.vo.Parametro[] parametros);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IComunesService/InsertDinamico", ReplyAction="http://tempuri.org/IComunesService/InsertDinamicoResponse")]
        System.Threading.Tasks.Task InsertDinamicoAsync(string procedimiento, co.itmasters.solucion.vo.Parametro[] parametros);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IComunesService/RelacionListaInsertaList", ReplyAction="http://tempuri.org/IComunesService/RelacionListaInsertaListResponse")]
        void RelacionListaInsertaList(co.itmasters.solucion.vo.RelacionParamVO[] list);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IComunesService/RelacionListaInsertaList", ReplyAction="http://tempuri.org/IComunesService/RelacionListaInsertaListResponse")]
        System.Threading.Tasks.Task RelacionListaInsertaListAsync(co.itmasters.solucion.vo.RelacionParamVO[] list);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IComunesService/RelacionInserta", ReplyAction="http://tempuri.org/IComunesService/RelacionInsertaResponse")]
        void RelacionInserta(co.itmasters.solucion.vo.RelacionParamVO inserta);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IComunesService/RelacionInserta", ReplyAction="http://tempuri.org/IComunesService/RelacionInsertaResponse")]
        System.Threading.Tasks.Task RelacionInsertaAsync(co.itmasters.solucion.vo.RelacionParamVO inserta);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IComunesService/ObtenerConsultaReporte", ReplyAction="http://tempuri.org/IComunesService/ObtenerConsultaReporteResponse")]
        System.Data.DataSet ObtenerConsultaReporte(string procedimiento, co.itmasters.solucion.vo.Parametro[] parametros);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IComunesService/ObtenerConsultaReporte", ReplyAction="http://tempuri.org/IComunesService/ObtenerConsultaReporteResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> ObtenerConsultaReporteAsync(string procedimiento, co.itmasters.solucion.vo.Parametro[] parametros);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IComunesServiceChannel : co.itmasters.solucion.web.ComunesService.IComunesService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ComunesServiceClient : System.ServiceModel.ClientBase<co.itmasters.solucion.web.ComunesService.IComunesService>, co.itmasters.solucion.web.ComunesService.IComunesService {
        
        public ComunesServiceClient() {
        }
        
        public ComunesServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ComunesServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ComunesServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ComunesServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public co.itmasters.solucion.vo.ListaVO[] ObtenerLista(string nombre) {
            return base.Channel.ObtenerLista(nombre);
        }
        
        public System.Threading.Tasks.Task<co.itmasters.solucion.vo.ListaVO[]> ObtenerListaAsync(string nombre) {
            return base.Channel.ObtenerListaAsync(nombre);
        }
        
        public co.itmasters.solucion.vo.ListaVO[] ObtenerListaFiltro(string nombre, string idFiltro) {
            return base.Channel.ObtenerListaFiltro(nombre, idFiltro);
        }
        
        public System.Threading.Tasks.Task<co.itmasters.solucion.vo.ListaVO[]> ObtenerListaFiltroAsync(string nombre, string idFiltro) {
            return base.Channel.ObtenerListaFiltroAsync(nombre, idFiltro);
        }
        
        public co.itmasters.solucion.vo.ListaVO[] ObtenerListaFiltros(string nombre, string[] filtro) {
            return base.Channel.ObtenerListaFiltros(nombre, filtro);
        }
        
        public System.Threading.Tasks.Task<co.itmasters.solucion.vo.ListaVO[]> ObtenerListaFiltrosAsync(string nombre, string[] filtro) {
            return base.Channel.ObtenerListaFiltrosAsync(nombre, filtro);
        }
        
        public System.Data.DataTable ObtenerListaTablaFiltro(string nombre, string filtro) {
            return base.Channel.ObtenerListaTablaFiltro(nombre, filtro);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> ObtenerListaTablaFiltroAsync(string nombre, string filtro) {
            return base.Channel.ObtenerListaTablaFiltroAsync(nombre, filtro);
        }
        
        public System.Data.DataTable ObtenerListaTablaFiltros(string nombre, string[] filtro) {
            return base.Channel.ObtenerListaTablaFiltros(nombre, filtro);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> ObtenerListaTablaFiltrosAsync(string nombre, string[] filtro) {
            return base.Channel.ObtenerListaTablaFiltrosAsync(nombre, filtro);
        }
        
        public void InsertDinamico(string procedimiento, co.itmasters.solucion.vo.Parametro[] parametros) {
            base.Channel.InsertDinamico(procedimiento, parametros);
        }
        
        public System.Threading.Tasks.Task InsertDinamicoAsync(string procedimiento, co.itmasters.solucion.vo.Parametro[] parametros) {
            return base.Channel.InsertDinamicoAsync(procedimiento, parametros);
        }
        
        public void RelacionListaInsertaList(co.itmasters.solucion.vo.RelacionParamVO[] list) {
            base.Channel.RelacionListaInsertaList(list);
        }
        
        public System.Threading.Tasks.Task RelacionListaInsertaListAsync(co.itmasters.solucion.vo.RelacionParamVO[] list) {
            return base.Channel.RelacionListaInsertaListAsync(list);
        }
        
        public void RelacionInserta(co.itmasters.solucion.vo.RelacionParamVO inserta) {
            base.Channel.RelacionInserta(inserta);
        }
        
        public System.Threading.Tasks.Task RelacionInsertaAsync(co.itmasters.solucion.vo.RelacionParamVO inserta) {
            return base.Channel.RelacionInsertaAsync(inserta);
        }
        
        public System.Data.DataSet ObtenerConsultaReporte(string procedimiento, co.itmasters.solucion.vo.Parametro[] parametros) {
            return base.Channel.ObtenerConsultaReporte(procedimiento, parametros);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ObtenerConsultaReporteAsync(string procedimiento, co.itmasters.solucion.vo.Parametro[] parametros) {
            return base.Channel.ObtenerConsultaReporteAsync(procedimiento, parametros);
        }
    }
}
