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


namespace co.itmasters.solucion.web.Empresa
{
    public partial class OfertasActivas : System.Web.UI.Page
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
                List<ListaVO> listadeOcupaciones = _carga.TablasBasicas(TipoCombo.CMBOCUPACIONOFERTA, new string[] { user.IdUsuario.ToString() });
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
                if (Convert.ToDateTime(txtFecha1.Text) >= Convert.ToDateTime(txtFecha2.Text))
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
                datosConsulta.estado = "1";

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
            datosConsulta.estado = "1";
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
                    ((Label)rowPro.FindControl("lbltotalhv")).ToolTip = "Total hojas de vida aplicadas.";
                    ((Label)rowPro.FindControl("lblHvVistas")).ToolTip = "Total hojas de vida vistas por la empresa.";
                    ((Label)rowPro.FindControl("lblHvVistas")).Text = Convert.ToString(((Label)rowPro.FindControl("lblHvVistas")).Text) + "<br/>No leidos";
                    if (((Label)rowPro.FindControl("lblEstadoOferta")).Text == "PEN")
                    {
                        ((Label)rowPro.FindControl("lblEstadoOferta")).Text = "Pendiente";
                        ((Label)rowPro.FindControl("lblEstadoOferta")).ForeColor = System.Drawing.Color.Orange;
                        var imgEdit = rowPro.FindControl("imgEditar") as Image;
                        var imgDelete = rowPro.FindControl("ImgBorrar") as Image;
                        var imgRenew = rowPro.FindControl("ImgRenovar") as Image;
                        var imgDup = rowPro.FindControl("ImgDuplicar") as Image;

                        imgEdit.Enabled = false;
                        imgDelete.Enabled = true;
                        imgRenew.Enabled = false;
                        imgDup.Enabled = false;

                    }
                    else if (((Label)rowPro.FindControl("lblEstadoOferta")).Text == "VEN")
                    {
                        ((Label)rowPro.FindControl("lblEstadoOferta")).Text = "Vencida";
                        ((Label)rowPro.FindControl("lblEstadoOferta")).ForeColor = System.Drawing.Color.Red;
                        var imgEdit = rowPro.FindControl("imgEditar") as Image;
                        var imgDelete = rowPro.FindControl("ImgBorrar") as Image;
                        var imgRenew = rowPro.FindControl("ImgRenovar") as Image;
                        var imgDup = rowPro.FindControl("ImgDuplicar") as Image;

                        imgEdit.Enabled = false;
                        imgDelete.Enabled = true;
                        imgRenew.Enabled = true;
                        imgDup.Enabled = true;
                    }
                    else if (((Label)rowPro.FindControl("lblEstadoOferta")).Text == "RCH")
                    {
                        ((Label)rowPro.FindControl("lblEstadoOferta")).Text = "Pendiente";
                        ((Label)rowPro.FindControl("lblEstadoOferta")).ForeColor = System.Drawing.Color.Orange;
                        
                        var imgEdit = rowPro.FindControl("imgEditar") as Image;
                        var imgDelete = rowPro.FindControl("ImgBorrar") as Image;
                        var imgRenew = rowPro.FindControl("ImgRenovar") as Image;
                        var imgDup = rowPro.FindControl("ImgDuplicar") as Image;
                        imgEdit.Enabled = false;
                        imgDelete.Enabled = true;
                        imgRenew.Enabled = true;
                        imgDup.Enabled = true;
                    }
                    else if (((Label)rowPro.FindControl("lblEstadoOferta")).Text == "ACT")
                    {
                        ((Label)rowPro.FindControl("lblEstadoOferta")).Text = "Activo";
                        ((Label)rowPro.FindControl("lblEstadoOferta")).ForeColor = System.Drawing.Color.DarkGreen;
                        var imgEdit = rowPro.FindControl("imgEditar") as Image;
                        var imgDelete = rowPro.FindControl("ImgBorrar") as Image;
                        var imgRenew = rowPro.FindControl("ImgRenovar") as Image;
                        var imgDup = rowPro.FindControl("ImgDuplicar") as Image;
                        imgEdit.Enabled = true;
                        imgDelete.Enabled = true;
                        imgRenew.Enabled = false;
                        imgDup.Enabled = true;
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
            cmbFiltros.Visible = true;
            btnBuscar.Visible = true;
        }
        protected void GrdOfertas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Master.OcultarBanda();
            Int32 index = Convert.ToInt32(e.CommandArgument) % GrdOfertas.PageSize;
            GridViewRow row = GrdOfertas.Rows[index];
            if (e.CommandName == "Editar")
            {
                Response.Redirect("../Empresa/PublicarOfertas.aspx?idOferta=" + Convert.ToString(((Label)row.FindControl("lblidOferta")).Text)+ "&estado=Editar");

            }
            if (e.CommandName == "Eliminar")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba",
         $"OpenModal('{ModalBorrarOferta.ClientID}','{openModal.ClientID}')", true);
                lblIdOfertaDelete.Text = Convert.ToString(((Label)row.FindControl("lblidOferta")).Text);

            }
            if (e.CommandName == "Renovar")
            {
                Response.Redirect("../Empresa/PublicarOfertas.aspx?idOferta=" + Convert.ToString(((Label)row.FindControl("lblidOferta")).Text)+"&estado=Renovar");
            }
            if (e.CommandName == "Duplicar")
            {
                Response.Redirect("../Empresa/PublicarOfertas.aspx?idOferta=" + Convert.ToString(((Label)row.FindControl("lblidOferta")).Text) + "&estado=Duplicar");
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
            user = ((UserVO)Session["UsuarioAutenticado"]);
            try 
            {
                Master.OcultarBanda();
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
            catch(Exception err)
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
            Int32 Id = Convert.ToInt32(((Label)row.FindControl("lblidOferta")).Text);
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

            // Trae los Postulados de la ofeta

            List<PersonaVO> postulados = GetPostulados(Id);

            if (postulados.Count > 0)
            {
                grdCandidatos.DataSource = postulados;
                grdCandidatos.DataBind();
            }
            else
            {
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
