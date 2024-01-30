using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using co.itmasters.solucion.web.SeguridadService;
using co.itmasters.solucion.vo;

namespace co.itmasters.solucion.web.Code
{
    public class UserVO : MembershipUser
    {
        public String Avatar { get; set; }
        public int IdEmpresa { get; set; }
        public string NomEmpresa { get; set; }
        public string NomEmpresa2 { get; set; }
        public string NomUsuario { get; set; }
        
        
        public string WebSite { get; set; }
        public string Dominio { get; set; }
        public int IdUsuario { get; set; }
        public int TipIdentificacion { get; set; }
        public string NumIdentificacion { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string NombreCompleto { get; set; }
        public string Error { get; set; }
        
        public int tipoUsuario { get; set; }
        public int diligenciaFormulario { get; set; }
        public Int32 tipoMitadPeriodo { get; set; }
        public Int32 esAdmon { get; set; }

        public List<RolVO> Rol { get; set; }
        public List<FormularioVO> Formulario { get; set; }
    }
}
