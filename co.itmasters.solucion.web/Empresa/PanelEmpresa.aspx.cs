using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using co.itmasters.solucion.web.Code;
using co.itmasters.solucion.web.OfertaService;
using co.itmasters.solucion.vo;
using System.Web.Services;
using System.IO;
using co.itmasters.solucion.web.EmpresaService;

namespace co.itmasters.solucion.web.Empresa
{
    public partial class PanelEmpresa : System.Web.UI.Page
    {
        private OfertaServiceClient _OfertaService;
        private UserVO user;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = ((UserVO)Session["UsuarioAutenticado"]);
            if (!Page.IsPostBack)
            {
                this.traeEstadistico(user.IdUsuario);
                this.traListadOfertas(user.IdUsuario);
            }
        }

        protected void traeEstadistico(int idusuario)
        {
            try
            {
                OfertaVO estadistica = new OfertaVO();
                estadistica.idUsuario = idusuario;
                _OfertaService = new OfertaServiceClient();
                OfertaVO _resultado = _OfertaService.TraerEstadisticasOferta(estadistica);
                _OfertaService.Close();

                btnOfertasPendientes.Text = _resultado.pendientes.ToString();
                btnOfertasPublicadas.Text = _resultado.activas.ToString();
                btnOfertasVencidas.Text = _resultado.vencidas.ToString();
                btnSeguidores.Text = "Total: " + _resultado.seguidores.ToString() + " seguidores";
                btnHvRecibidas.Text = "Total: " + _resultado.hojasdeVida.ToString() + " Hv";
                lblPorcentajeSeg.Text = "36%";
                lblPorcentajeHv.Text = "46%";
            }
            catch (Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);

            }
            

        }

        protected void traListadOfertas(int idusuario)
        {
            try
            {
                OfertaVO estadistica = new OfertaVO();
                estadistica.idUsuario = idusuario;
                _OfertaService = new OfertaServiceClient();
                List<OfertaVO> resultado = _OfertaService.TraeOfertaEmpresa(estadistica).ToList<OfertaVO>(); ;
                _OfertaService.Close();
                if (resultado.Count > 0)
                {
                    GrdOfertas.DataSource = resultado;
                    GrdOfertas.DataBind();
                    for (int j = 0; j < GrdOfertas.Rows.Count; j++)
                    {
                        GridViewRow rowPro = GrdOfertas.Rows[j];
                        ((Label)rowPro.FindControl("lbltotalhv")).ToolTip = "Total hojas de vida aplicadas.";
                        ((Label)rowPro.FindControl("lblHvVistas")).ToolTip = "Total hojas de vida vistas por la empresa.";
                        ((Label)rowPro.FindControl("lblHvVistas")).Text =Convert.ToString(((Label)rowPro.FindControl("lblHvVistas")).Text) + "<br/>No leidos";
                        if (((Label)rowPro.FindControl("lblEstadoOferta")).Text == "PEN")
                        {
                            ((Label)rowPro.FindControl("lblEstadoOferta")).Text = "Pendiente";
                            ((Label)rowPro.FindControl("lblEstadoOferta")).ForeColor = System.Drawing.Color.Orange;                        
                        }
                        else if (((Label)rowPro.FindControl("lblEstadoOferta")).Text == "VEN")
                        {
                            ((Label)rowPro.FindControl("lblEstadoOferta")).Text = "Vencida";
                            ((Label)rowPro.FindControl("lblEstadoOferta")).ForeColor = System.Drawing.Color.Red;
                        }
                        else if (((Label)rowPro.FindControl("lblEstadoOferta")).Text == "RCH")
                        {
                            ((Label)rowPro.FindControl("lblEstadoOferta")).Text = "Pendiente";
                            ((Label)rowPro.FindControl("lblEstadoOferta")).ForeColor = System.Drawing.Color.Orange;
                        }
                        else if (((Label)rowPro.FindControl("lblEstadoOferta")).Text == "ACT")
                        {
                            ((Label)rowPro.FindControl("lblEstadoOferta")).Text = "Activo";
                            ((Label)rowPro.FindControl("lblEstadoOferta")).ForeColor = System.Drawing.Color.DarkGreen;
                        }
                    }
                        //(Convert.ToString(((Label)rowPro.FindControl("lblIdAlumnoCol")).Text));
                }
                else
                {
                    lbldetalleOferta.Text = "No exíste historial de ofertas";
                }
                

            }
            catch(Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);

            }
            

        }

        protected void GrdOfertas_RowCommand(object sender, EventArgs e)
        {

        }
    }
}