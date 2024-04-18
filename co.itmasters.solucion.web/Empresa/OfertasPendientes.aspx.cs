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
using System.Data;
using co.itmasters.solucion.vo.constantes;

namespace co.itmasters.solucion.web.Empresa
{
    public partial class OfertasPendientes : PageBase
    {
        private OfertaServiceClient _OfertaService;
        private UserVO user;
        private CargaCombos _carga = new CargaCombos();

        protected void Page_Load(object sender, EventArgs e)
        {
            user = ((UserVO)Session["UsuarioAutenticado"]);
            //  List<OfertaVO> listaOfertas = GetOffers();  // Obtiene una lista de ofertas desde la base de datos.

            if (!Page.IsPostBack)
            {
                //ShowOffers(listaOfertas); // Renderiza un lista de Ofertas
                this.CargaCombos();
                this.traeOfertas(0, Convert.ToDateTime("01/01/1900"), Convert.ToDateTime("12/12/2040"));
            }
        }
        protected void CargaCombos()
        {
            _carga.Cargar(cmbFiltros, TipoCombo.CMBTIPOFILTROS);

        }
        protected void cmbFiltros_SelectedIndexChanged(object sender, EventArgs e)
        {
            Master.OcultarBanda();

            if (cmbFiltros.SelectedValue == "1")
            {//Activas = 1 Pendientes = 2 Vencidas = 3
                List<ListaVO> listadeOcupaciones = _carga.TablasBasicas(TipoCombo.CMBOCUPACIONOFERTA, new string[] { "PEN", user.IdUsuario.ToString() });
                _carga.Cargar(cmbOcupacionOfertaEmpresa, listadeOcupaciones);
                cmbOcupacionOfertaEmpresa.Visible = true;
                txtFecha1.Visible = false;
                txtFecha2.Visible = false;
                btnBuscar.Visible = false;

            }
            else if (cmbFiltros.SelectedValue == "2")
            {
                cmbOcupacionOfertaEmpresa.Visible = false;
                txtFecha1.Visible = true;
                txtFecha2.Visible = true;
                btnBuscar.Visible = true;
            }
            else
            {
                cmbFiltros.SelectedValue = "-1";

            }

        }
        protected void cmbOcupacionOfertaEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            Master.OcultarBanda();
            this.traeOfertas(Convert.ToInt32(cmbOcupacionOfertaEmpresa.SelectedValue), Convert.ToDateTime("01/01/1900"), Convert.ToDateTime("12/12/2040"));
        }
        protected void btnBuscar_Click(object sender, EventArgs e)

        {
            Master.OcultarBanda();
            if (txtFecha1.Text == "" || txtFecha2.Text == "")
            {
                Master.mostrarMensaje("por favor seleccione un rango de fecha.", Master.ERROR);
            }
            else
            {
                if (Convert.ToDateTime(txtFecha1.Text) <= Convert.ToDateTime(txtFecha2.Text))
                {
                    this.traeOfertas(0, Convert.ToDateTime(txtFecha1.Text), Convert.ToDateTime(txtFecha2.Text));
                }
                else
                {
                    Master.mostrarMensaje("La fecha inicial no pede ser mayor a la fecha final", Master.ERROR);

                }
            }




        }
        protected List<OfertaVO> OptenerDdatos()
        {
            user = ((UserVO)Session["UsuarioAutenticado"]);
            Master.OcultarBanda();
            try
            {
                OfertaVO datosConsulta = new OfertaVO();
                datosConsulta.idUsuario = user.IdUsuario;
                datosConsulta.estado = "2";

                _OfertaService = new OfertaServiceClient();
                List<OfertaVO> resultado = _OfertaService.TraeEstadoOfertaEmpresa(datosConsulta).ToList<OfertaVO>();

                _OfertaService.Close();
                return resultado;
            }
            catch (Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);
                return null;
            }

        }
        protected void traeOfertas(int ocupacion, DateTime fechaIni, DateTime fechaFin)
        {
            GrdOfertas.DataSource = null;
            GrdOfertas.DataBind();
            OfertaVO datosConsulta = new OfertaVO();
            datosConsulta.idUsuario = user.IdUsuario;
            datosConsulta.estado = "2";
            datosConsulta.idOcupacion = ocupacion;
            datosConsulta.fechaInicia = fechaIni;
            datosConsulta.fechaFinaliza = fechaFin;
            _OfertaService = new OfertaServiceClient();
            List<OfertaVO> resultado = _OfertaService.TraeEstadoOfertaEmpresa(datosConsulta).ToList<OfertaVO>();
            _OfertaService.Close();
            if (resultado.Count > 0)
            {
                GrdOfertas.DataSource = resultado;
                GrdOfertas.DataBind();
                for (int j = 0; j < GrdOfertas.Rows.Count; j++)
                {
                    GridViewRow rowPro = GrdOfertas.Rows[j];
                    ((Label)rowPro.FindControl("offerAppications")).ToolTip = "Total hojas de vida aplicadas.";
                    ((Label)rowPro.FindControl("offerViews")).ToolTip = "Total hojas de vida vistas por la empresa.";
                    if (((Label)rowPro.FindControl("state")).Text == "PEN")
                    {
                        ((Label)rowPro.FindControl("state")).Text = "Pendiente";
                        ((Label)rowPro.FindControl("state")).ForeColor = System.Drawing.Color.Orange;
                        ((Label)rowPro.FindControl("lblOfferDuplicate")).Visible = false;
                        ((Label)rowPro.FindControl("lblOfferEdit")).Visible = false;
                    }
                    else if (((Label)rowPro.FindControl("state")).Text == "VEN")
                    {
                        ((Label)rowPro.FindControl("state")).Text = "Vencida";
                        ((Label)rowPro.FindControl("state")).ForeColor = System.Drawing.Color.Red;
                        ((Label)rowPro.FindControl("lblOfferEdit")).Visible=false;

                    }
                    else if (((Label)rowPro.FindControl("state")).Text == "RCH")
                    {
                        ((Label)rowPro.FindControl("state")).Text = "Rechazada, puede modificar";
                        ((Label)rowPro.FindControl("state")).ForeColor = System.Drawing.Color.Red;


                    }
                    else if (((Label)rowPro.FindControl("state")).Text == "ACT")
                    {
                        ((Label)rowPro.FindControl("state")).Text = "Activo";
                        ((Label)rowPro.FindControl("state")).ForeColor = System.Drawing.Color.DarkGreen;
 
                    }

                }
            }

        }
        protected void AddOfferToContainer(OfertaVO offer)
        {
            UserControlCardOfferTech ucOffer = (UserControlCardOfferTech)LoadControl("~/Components_UI/UserControlCardOfferTech.ascx");

            ucOffer.ID = offer.idOferta.ToString();
            ucOffer.Title = offer.tituloVacante;
            ucOffer.Views = offer.hvVista;
            ucOffer.UserWhoPublishing = offer.usuarioCrea;
            ucOffer.Date = offer.fechaPublicacion;
            ucOffer.SalaryRange = offer.RangoSalario;
            ucOffer.NumApplications = offer.totHv;

            //containerOffers.Controls.Add(ucOffer);

        }
        protected void ShowOffers(List<OfertaVO> offers)
        {
            foreach (OfertaVO offer in offers)
            {
                AddOfferToContainer(offer);
            }
        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {
        }
        protected void GrdOfertas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Int32 index = Convert.ToInt32(e.CommandArgument) % GrdOfertas.PageSize;
            GridViewRow row = GrdOfertas.Rows[index];
            if (e.CommandName == "Editar")
            {
                Response.Redirect("../Empresa/PublicarOfertas.aspx?idOferta=" + Convert.ToString(((Label)row.FindControl("idOferta")).Text) + "&estado=Editar");

            }
            if (e.CommandName == "Eliminar")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba",
               $"OpenModal('{ModalBorrarOferta.ClientID}','{openModal.ClientID}')", true);
                lblIdOfertaDelete.Text = Convert.ToString(((Label)row.FindControl("idOferta")).Text);
            }
            if (e.CommandName == "Renovar")
            {
                Response.Redirect("../Empresa/PublicarOfertas.aspx?idOferta=" + Convert.ToString(((Label)row.FindControl("idOferta")).Text) + "&estado=Renovar");
            }
            if (e.CommandName == "Duplicar")
            {
                Response.Redirect("../Empresa/PublicarOfertas.aspx?idOferta=" + Convert.ToString(((Label)row.FindControl("idOferta")).Text) + "&estado=Duplicar");
            }

        }

        protected void Cancerlar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", $"CloseModal('{detalleOferta.ClientID}', '{openModal.ClientID}')", true);
            Master.OcultarBanda();
            lblIdOfertaDelete.Text = "";
        }

        protected void Anular_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", $"CloseModal('{detalleOferta.ClientID}', '{openModal.ClientID}')", true);
            Master.OcultarBanda();
            user = ((UserVO)Session["UsuarioAutenticado"]);
            try
            {
                OfertaVO elimina = new OfertaVO();
                elimina.idOferta = Convert.ToInt32(lblIdOfertaDelete.Text);
                elimina.idUsuario = user.IdUsuario;
                elimina.numIdentificacion = user.NumIdentificacion;
                _OfertaService = new OfertaServiceClient();
                _OfertaService.AnulaOferta(elimina);
                _OfertaService.Close();
                this.traeOfertas(0, Convert.ToDateTime("01/01/1900"), Convert.ToDateTime("12/12/2040"));
                Master.mostrarMensaje("Oferta anulada con éxito.", Master.EXITO);
            }
            catch (Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);
            }
        }
        protected List<PersonaVO> GetPostulados(int idOffer)
        {

            OfertaVO oferta = new OfertaVO();
            oferta.idOferta = idOffer;
            oferta.typeModify = TipoConsulta.GET;

            OfertaServiceClient _OfertaService = new OfertaServiceClient();
            List<PersonaVO> postulados = _OfertaService.Postulados(oferta).ToList();
            _OfertaService.Close();

            return postulados;

        }
        protected void btnViewDetailOffer_Command(object sender, CommandEventArgs e)
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
            if (viewOferta.estado == "RCH" && viewOferta.Observaciones != null)
            {
                titleGrdPostulados.InnerText = "Observaciones";
                grdCandidatos.Visible = false;
                msgNoResults.InnerText = "Lo sentimos la oferta ha sido rechazada";
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
        protected void btnCloseModal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", $"CloseModal('{detalleOferta.ClientID}', '{openModal.ClientID}')", true);
        }
    }
}