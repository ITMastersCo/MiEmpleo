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
using System.Web.Hosting;
using System.Data;
using co.itmasters.solucion.vo.constantes;

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
                lblPorcentajeSeg.Text = "0%";
                lblPorcentajeHv.Text = "0%";

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
                List<OfertaVO> resultado = _OfertaService.TraeOfertaEmpresa(estadistica).ToList<OfertaVO>(); 
                _OfertaService.Close();
                if (resultado.Count > 0)
                {
                    GrdOfertas.DataSource = resultado;
                    GrdOfertas.DataBind();
                    for (int j = 0; j < GrdOfertas.Rows.Count; j++)
                    {
                        GridViewRow rowPro = GrdOfertas.Rows[j];
                        ((Label)rowPro.FindControl("offerViews")).ToolTip = "Total hojas de vida aplicadas.";
                        //((Label)rowPro.FindControl("lblHvVistas")).ToolTip = "Total hojas de vida vistas por la empresa.";
                        //((Label)rowPro.Fi ndControl("lblHvVistas")).Text =Convert.ToString(((Label)rowPro.FindControl("lblHvVistas")).Text) + "<br/>No leidos";
                        Label text = ((Label)rowPro.FindControl("state"));
                        if (((Label)rowPro.FindControl("state")).Text == "PEN")
                        {
                            ((Label)rowPro.FindControl("state")).Text = "Pendiente";
                            ((Label)rowPro.FindControl("state")).ForeColor = System.Drawing.Color.Orange;
                        }
                        else if (((Label)rowPro.FindControl("state")).Text == "VEN")
                        {
                            ((Label)rowPro.FindControl("state")).Text = "Vencida";
                            ((Label)rowPro.FindControl("state")).ForeColor = System.Drawing.Color.Red;
                        }
                        else if (((Label)rowPro.FindControl("state")).Text == "RCH")
                        {
                            ((Label)rowPro.FindControl("lblEstadoOferta")).Text = "Rechazada";
                            ((Label)rowPro.FindControl("state")).ForeColor = System.Drawing.Color.Red;
                        }
                        else if (((Label)rowPro.FindControl("state")).Text == "ACT")
                        {
                            ((Label)rowPro.FindControl("state")).Text = "Activo";
                            ((Label)rowPro.FindControl("state")).ForeColor = System.Drawing.Color.DarkGreen;
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
        protected List<PersonaVO> GetPostulados(int idOffer)
        {

            OfertaVO oferta = new OfertaVO();
            oferta.idPersona = user.IdUsuario;
            oferta.idOferta = idOffer;
            oferta.typeModify = TipoConsulta.GET;

            OfertaServiceClient _OfertaService = new OfertaServiceClient();
            List<PersonaVO> postulados = _OfertaService.Postulados(oferta).ToList();
            _OfertaService.Close();

            return postulados;

        }
        protected void GrdOfertas_RowCommand(object sender, EventArgs e)
        {

        }

        protected void btnViewDetailOffer_Command(object sender, CommandEventArgs e)
        {
            try
            {
                Int32 index = Convert.ToInt32(e.CommandArgument) % GrdOfertas.PageSize;
                GridViewRow row = GrdOfertas.Rows[index];
                Int32 Id = Convert.ToInt32(((Label)row.FindControl("idOferta")).Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba",
                    $"OpenModal('{detalleOferta.ClientID}','{openModal.ClientID}')", true);

                OfertaVO oferta = new OfertaVO();
                oferta.idOferta = Convert.ToInt32(Id);
                OfertaServiceClient _OfertaService = new OfertaServiceClient();

                OfertaVO viewOferta = _OfertaService.GetOfertaPersonaDetalle(oferta);
                _OfertaService.Close();
                lblIdOferta.Text = viewOferta.idOferta.ToString();
                imgAvatarEmpresa.Src = $".{viewOferta.rutaAvatar}";
                lblOfferTitle.Text = viewOferta.tituloVacante;
                lblOfferSalaryRange.Text = viewOferta.RangoSalario;
                lblDateCrateOffer.Text = String.Format("{0:yyyy-MM-dd}", viewOferta.fechaPublicacion);
                lblDateRemoveOffer.Text = String.Format("{0:yyyy-MM-dd}", viewOferta.fechaVencimiento);
                lblOfferUserWhoPublished.Text = viewOferta.nomEmpresa;
                lblOfferLocation.Text = viewOferta.nomCiudad;
                lblDescriptioOffer.Text = viewOferta.descripcionVacante;
                if(viewOferta.estado == "RCH" && viewOferta.Observaciones != null)
                {
                titleGrdPostulados.InnerText = "Observaciones";
                 grdCandidatos.Visible = false;
                 msgNoResults.InnerText = "Lo sentimos ls oferta ha sido rechazada";
                 msgNoResults.Attributes["class"] = "text-center text-item text-regular color-red-500 p-32";
                msgObservacion.Visible = true;
                 msgObservacion.InnerText = $"Motivo de rechazo:{viewOferta.Observaciones}";
                }

                // Trae los Postulados de la ofeta

                List<PersonaVO> postulados = GetPostulados(Id);

                if (postulados.Count > 0)
                {
                    grdCandidatos.DataSource = postulados;
                    grdCandidatos.DataBind();
                }
                else
                {
                    grdCandidatos.DataBind();
                    noResultsShare.Visible = true;
                }

            }
            catch(Exception err)
            {
                Master.mostrarMensaje(err.ToString(), Master.ERROR);
            }
            





        }

        protected void btnCloseModal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", $"CloseModal('{detalleOferta.ClientID}', '{openModal.ClientID}')", true);
        }

        protected void btnViewCandidato_Command(object sender, CommandEventArgs e)
        {
            Int32 index = Convert.ToInt32(e.CommandArgument) % grdCandidatos.PageSize;
            GridViewRow row = grdCandidatos.Rows[index];
            Int32 IdPersona = Convert.ToInt32(((Label)row.FindControl("lblIdPersona")).Text);

            try
            {
                AdmonReporte conex = new AdmonReporte("");
                String datosReporte = "Reportes//Candidato//HojadeVida.rpt:Rpt_HojaVida";
                Int32 Idreporte = 5;
                int Cantidad = datosReporte.IndexOf(":") - 22;
                Parametro[] valParam = new Parametro[]
                 {
                      new Parametro("idUsuario", user.IdUsuario, DbType.Int32),
                    new Parametro("idPersona", IdPersona, DbType.Int32),
                 };

                conex.ImprimeReporte(datosReporte, valParam, "PDF");

            }
            catch (Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);
            }
        }

        protected void btnViewOfferFeatured_Command(object sender, CommandEventArgs e)
        {

        }
    }
}