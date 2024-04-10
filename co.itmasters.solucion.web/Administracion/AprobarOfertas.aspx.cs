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

using Microsoft.Win32;


namespace co.itmasters.solucion.web.Administracion
{
    public partial class AprobarOfertas : PageBase
    {
        
        private OfertaServiceClient _ActoresService;
        private UserVO user;
        private CargaCombos _carga = new CargaCombos();
        protected void Page_Load(object sender, EventArgs e)
        {
            user = ((UserVO)Session["UsuarioAutenticado"]);
            if (!Page.IsPostBack)
            {
                CargaOfertas();
            }

        }
        protected void CargaOfertas()
        {
            user = ((UserVO)Session["UsuarioAutenticado"]);
            OfertaVO datosEmpresa = new OfertaVO();
            datosEmpresa.idUsuario = user.IdUsuario;
            _ActoresService = new OfertaServiceClient();
            List<OfertaVO> resultado = _ActoresService.TraeOfertas(datosEmpresa).ToList<OfertaVO>(); ;
            _ActoresService.Close();
            if (resultado.Count > 0)
            {
                GrdOferta.DataSource = resultado;
                GrdOferta.DataBind();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }
        protected void GrdOferta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Master.OcultarBanda();
            Int32 index = Convert.ToInt32(e.CommandArgument) % GrdOferta.PageSize;
            GridViewRow row = GrdOferta.Rows[index];
            if (e.CommandName == "VerDatos")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", "showModal();", true);
                LabelIdOferta.Text =  Convert.ToString(((Label)row.FindControl("lblidOferta")).Text);
                empresa.InnerText = Convert.ToString(((Label)row.FindControl("lblnomEmpresa")).Text);
                lblNomOferta2.InnerText =  Convert.ToString(((Label)row.FindControl("lblnomOferta")).Text);
                nombreOferta.Text = Convert.ToString(((Label)row.FindControl("lblnomOferta")).Text);
                labelDescripcionVacante.InnerText =  Convert.ToString(((Label)row.FindControl("lblDescripcionVacante")).Text);
                labeltiempoExperiencia.InnerText = Convert.ToString(((Label)row.FindControl("lbltiempoExperiencia")).Text);
                LabelNmonCiudad2.InnerText =  Convert.ToString(((Label)row.FindControl("lblNomCiudad")).Text);
                laberRango.InnerText = Convert.ToString(((Label)row.FindControl("lblRangoSalario")).Text);
                vacantes.InnerText = Convert.ToString(((Label)row.FindControl("lblcantidadVacantes")).Text);
                cargo.InnerText = Convert.ToString(((Label)row.FindControl("lblcargo")).Text);
            }

        }

        protected void Aprobar_Click(object sender, EventArgs e)
        {
            try 
            {
                OfertaVO aprobar = new OfertaVO();
                aprobar.idOferta = Convert.ToInt32(LabelIdOferta.Text);
                aprobar.estado = "ACT";
                aprobar.idUsuario = user.IdUsuario;
                aprobar.Observaciones = "";
                _ActoresService = new OfertaServiceClient();
                _ActoresService.AprobarOfertas(aprobar);
                _ActoresService.Close();
                GrdOferta.DataSource = null;
                GrdOferta.DataBind();
                this.CargaOfertas();
                Master.mostrarMensaje("La oferta fue actualizada con éxito.", Master.EXITO);
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
                lblError.Text = "";
                divObservacion.Style["display"] = "block";
             
                if (txtObservacion.Text.Length >10)
                {
                    
                    OfertaVO aprobar = new OfertaVO();
                    aprobar.idOferta = Convert.ToInt32(LabelIdOferta.Text);
                    aprobar.estado = "RCH";
                    aprobar.idUsuario = user.IdUsuario;
                    aprobar.Observaciones = txtObservacion.Text;
                    _ActoresService = new OfertaServiceClient();
                    _ActoresService.AprobarOfertas(aprobar);
                    _ActoresService.Close();
                    GrdOferta.DataSource = null;
                    GrdOferta.DataBind();
                    this.CargaOfertas();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", "CloseModal2();", true);
                    string observacionAnulacion = "La oferta " + nombreOferta.Text + " fue fechazada.";
                    Master.mostrarMensaje(observacionAnulacion, Master.INFORMACION);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", "showModal();", true);
                    lblError.Text = "La observación debe ser mayor a 10 caractares";
                }
                
            }
            catch (Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);
            }
        }
      
    }
}