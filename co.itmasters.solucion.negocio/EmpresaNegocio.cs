using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using co.itmasters.solucion.dao;
using co.itmasters.solucion.vo;

namespace co.itmasters.solucion.negocio
{
    public class EmpresaNegocio
    {
        EmpresaDao _empresa;
        SeguridadDao _seguridad;
        public EmpresaNegocio()
        {
            _empresa = new EmpresaDao();
        }
        public void CreatePlanAdquirido(EmpresaVO empresa)
        {
            _empresa.CreatePlanAdquirido(empresa);
        }
        public List<EmpresaVO> TraeEmpresas(EmpresaVO empresa)
        {
            return _empresa.TraeEmpresas(empresa);
        }
        public EmpresaVO DatosEmpresa(EmpresaVO Empresa)
        {
            return _empresa.DatosEmpresa(Empresa);
        }
        public void GuardarDatosEmpresa(EmpresaVO Empresa)
        {
            _empresa.GuardarDatosEmpresa(Empresa);
        }
        public void AprobarEmpresas(EmpresaVO Empresa)
        {
            _empresa.AprobarEmpresas(Empresa);
        }
        

    }
}
