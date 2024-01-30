using co.itmasters.solucion.vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;

namespace co.itmasters.solucion.servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IEmpresaService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IEmpresaService
    {
        [OperationContract]
        void CreatePlanAdquirido(EmpresaVO empresa);
        [OperationContract]
        void GuardarDatosEmpresa(EmpresaVO Empresa);
        [OperationContract]
        List<EmpresaVO> TraeEmpresas(EmpresaVO empresa);

        [OperationContract]
        EmpresaVO DatosEmpresa(EmpresaVO Empresa);
        [OperationContract]
        void AprobarEmpresas(EmpresaVO Empresa);

     
        
    }
}
