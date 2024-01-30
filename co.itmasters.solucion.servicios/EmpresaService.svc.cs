using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using co.itmasters.solucion.negocio;

using co.itmasters.solucion.vo;
using System.Data;
namespace co.itmasters.solucion.servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "EmpresaService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione EmpresaService.svc o EmpresaService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class EmpresaService : IEmpresaService
    {
        private EmpresaNegocio _empresa;

        public void CreatePlanAdquirido(EmpresaVO empresa)
        {
            try
            {

                _empresa = new EmpresaNegocio();
                 _empresa.CreatePlanAdquirido(empresa);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public List<EmpresaVO> TraeEmpresas(EmpresaVO empresa)
        {
            try
            {

                _empresa = new EmpresaNegocio();
                return _empresa.TraeEmpresas(empresa);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public EmpresaVO DatosEmpresa(EmpresaVO Empresa)
        {
            try
            {
                _empresa = new EmpresaNegocio();
                return _empresa.DatosEmpresa(Empresa);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public void GuardarDatosEmpresa(EmpresaVO Empresa)
        {
            try
            {
                _empresa = new EmpresaNegocio();
                _empresa.GuardarDatosEmpresa(Empresa);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public void AprobarEmpresas(EmpresaVO Empresa)
        {
            try
            {
                _empresa = new EmpresaNegocio();
                _empresa.AprobarEmpresas(Empresa);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        
    }
}
