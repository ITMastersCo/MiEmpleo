using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using co.itmasters.solucion.web.Components_UI;
using System.Web.UI.WebControls;
using co.itmasters.solucion.web.Code;
using co.itmasters.solucion.web.OfertaService;
using co.itmasters.solucion.vo;
using System.Web.Services;
using System.IO;
using co.itmasters.solucion.web.EmpresaService;
using Microsoft.Win32;


namespace co.itmasters.solucion.web.Administracion
{
    public partial class AprobarEmpresa : PageBase
    {
        
        private EmpresaServiceClient _ActoresService;
        private UserVO user;
        private CargaCombos _carga = new CargaCombos();
        protected void Page_Load(object sender, EventArgs e)
        {
            user = ((UserVO)Session["UsuarioAutenticado"]);
            if (!Page.IsPostBack)
            {
                CargaEmpresas();
            }

        }
        protected void CargaEmpresas()
        {
            user = ((UserVO)Session["UsuarioAutenticado"]);
            EmpresaVO datosEmpresa = new EmpresaVO();
            datosEmpresa.idUsuario = user.IdUsuario;
            _ActoresService = new EmpresaServiceClient();
            List<EmpresaVO> resultado = _ActoresService.TraeEmpresas(datosEmpresa).ToList<EmpresaVO>(); ;
            _ActoresService.Close();
            if (resultado.Count > 0)
            {
                GrdEmpresa.DataSource = resultado;
                GrdEmpresa.DataBind();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }
        protected void GrdEmpresa_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Master.OcultarBanda();
            Int32 index = Convert.ToInt32(e.CommandArgument) % GrdEmpresa.PageSize;
            GridViewRow row = GrdEmpresa.Rows[index];
            if (e.CommandName == "VerDatos")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", "showModal();", true);
                LabelIdEmpresa.Text =  Convert.ToString(((Label)row.FindControl("lblidEmpresa")).Text);
                lblNomEmpresa2.InnerText =  Convert.ToString(((Label)row.FindControl("lblnomEmpresa")).Text);
                LabelNIT2.InnerText =  Convert.ToString(((Label)row.FindControl("lblnumeroIde")).Text);
                lblCorreoElectronico2.InnerText = Convert.ToString(((Label)row.FindControl("lblcorreoElectronico")).Text);
                
                LabelNmonCiudad2.InnerText =  Convert.ToString(((Label)row.FindControl("lblNomCiudad")).Text);
                LabelTelefono2.InnerText = Convert.ToString(((Label)row.FindControl("lbltelefono")).Text);
                LabelDireccion2.InnerText = Convert.ToString(((Label)row.FindControl("lbldireccion")).Text);
                LabelRepresentantelegal2.InnerText =  Convert.ToString(((Label)row.FindControl("lblnomRepLegal")).Text);
                LabeNumIdeRepLegal2.InnerText =  Convert.ToString(((Label)row.FindControl("lblnumIdeRepLegal")).Text);
                LabelTelRepLegal2.InnerText =  Convert.ToString(((Label)row.FindControl("lbltelRepLegal")).Text);
                rut.HRef =  "../DocsEmpresa/" + "Legalizacion/" + Convert.ToString(((Label)row.FindControl("lblnumeroIde")).Text).TrimStart().TrimEnd() + "_RUT.pdf";
                CC.HRef = "../DocsEmpresa/" + "Legalizacion/" + Convert.ToString(((Label)row.FindControl("lblnumeroIde")).Text).TrimStart().TrimEnd() + "_CC.pdf";
            }

        }

        protected void Aprobar_Click(object sender, EventArgs e)
        {
            try 
            {
                EmpresaVO aprobar = new EmpresaVO();
                aprobar.idEmpresa = Convert.ToInt32(LabelIdEmpresa.Text);
                aprobar.estado = "APR";
                aprobar.idUsuario = user.IdUsuario;
                _ActoresService = new EmpresaServiceClient();
                _ActoresService.AprobarEmpresas(aprobar);
                Master.mostrarMensaje("La empresa fue actualizada con éxito", Master.EXITO);
            }
            catch(Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);
            }
        }

        protected void Volver_Click(object sender, EventArgs e)
        {
            try
            {
                EmpresaVO aprobar = new EmpresaVO();
                aprobar.idEmpresa = Convert.ToInt32(LabelIdEmpresa.Text);
                aprobar.estado = "RCH";
                aprobar.idUsuario = user.IdUsuario;
                _ActoresService = new EmpresaServiceClient();
                _ActoresService.AprobarEmpresas(aprobar);
                Master.mostrarMensaje("La empresa fue actualizada con éxito", Master.INFORMACION);
            }
            catch (Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);
            }
        }
      
    }
}