using System;
using System.Collections.Generic;
using System.Linq;
using co.itmasters.solucion.vo;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using co.itmasters.solucion.web.Components_UI;
using System.Web.UI.HtmlControls;
using co.itmasters.solucion.web.Code;
using co.itmasters.solucion.web.PersonaService;
using System.IO;
using System.Web.Services;
using co.itmasters.solucion.web.OfertaService;


namespace co.itmasters.solucion.web
{
    public partial class Index : PageBase
    {
        private OfertaServiceClient _OfertaService;
        private static List<ListaVO> listaCiudad;
        private CargaCombos _carga = new CargaCombos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listaCiudad = _carga.TablasBasicas(TipoLista.LISTACIUDADESTADOPAIS);
                LlenarGrdOfertasDestacadas();
            }
        }

        private void LlenarGrdOfertasDestacadas()
        {
            OfertaVO oferta = new OfertaVO();
            oferta.idUsuario = 0;



            _OfertaService = new OfertaServiceClient();
            List<OfertaVO> listOffer = _OfertaService.GetOfertaPersona(oferta).ToList<OfertaVO>();
            _OfertaService.Close();



            if (listOffer.Count > 0)

            {
                grdOfertasDestacadas.DataSource = listOffer.Take(4);
                grdOfertasDestacadas.DataBind();
            }

        }

        protected void grdOfertasDestacadas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            Int32 index = Convert.ToInt32(e.CommandArgument) % grdOfertasDestacadas.PageSize;
            GridViewRow row = grdOfertasDestacadas.Rows[index];
            switch (e.CommandName.ToUpper())
            {
                case "GET":

                    OfertaVO oferta = new OfertaVO();

                    oferta.idOferta = Convert.ToInt32(((Label)row.FindControl("idOferta")).Text);
                    OfertaVO viewOferta = _OfertaService.GetOfertaPersonaDetalle(oferta);
                    _OfertaService.Close();
                    break;
            }

        }

        protected void ScriptManager1_AsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e)
        {
            String dir = ((ScriptManager)sender).Page.AppRelativeVirtualPath;
            //Response.Redirect("~/Error.aspx);
            Server.Transfer("~/Error.aspx");
        }

        protected void btnViewOffer_Click(object sender, EventArgs e)
        {

        }

        protected void btnViewOffer_Command(object sender, CommandEventArgs e)
        {

            if (e.CommandName == "GET")
            {
                Int32 index = Convert.ToInt32(e.CommandArgument) % grdOfertas.PageSize;
                GridViewRow row = grdOfertas.Rows[index];
                Int32 Id = Convert.ToInt32(((Label)row.FindControl("idOferta")).Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", $"showModal('{detalleOferta.ClientID}')", true);

                OfertaVO oferta = new OfertaVO();
                oferta.idOferta = Convert.ToInt32(Id);
                OfertaServiceClient _OfertaService = new OfertaServiceClient();
                OfertaVO viewOferta = _OfertaService.GetOfertaPersonaDetalle(oferta);
                _OfertaService.Close();
                lblOfferTitle.Text = viewOferta.tituloVacante;
                imgAvatarOffer.Src = $"{viewOferta.rutaAvatar}";
                lblOfferSalaryRange.Text = viewOferta.RangoSalario;
                lblDateCrateOffer.Text = String.Format("{0:yyyy-MM-dd}", viewOferta.fechaPublicacion);
                lblDateRemoveOffer.Text = String.Format("{0:yyyy-MM-dd}", viewOferta.fechaVencimiento);
                lblOfferUserWhoPublished.Text = viewOferta.nomEmpresa;
                lblOfferLocation.Text = viewOferta.nomCiudad;
                lblDescriptioOffer.Text = viewOferta.descripcionVacante;

            }

        }

        protected void LlenarGrdOfertas()
        {


            OfertaVO ofertaSearch = new OfertaVO();
            ofertaSearch.tituloVacante = txtBuscarCargo.Text;
            if (txtIdCiudadBuscar.Text != "")
            {
                ofertaSearch.idCiudadVacante = Convert.ToInt32(txtIdCiudadBuscar.Text);
            }



            _OfertaService = new OfertaServiceClient();

            List<OfertaVO> listOffer = _OfertaService.GetOfertaPersona(ofertaSearch).ToList();
            _OfertaService.Close();

            if (listOffer.Count > 0)
            {
                containerOfertas.Visible = true;
                grdOfertas.DataSource = listOffer;
                grdOfertas.DataBind();
                noResultsShare.Visible = false;
            }
            else
            {
                noResultsShare.Visible = true;
                containerOfertas.Visible = true;
                grdOfertas.DataBind();
            }

        }
        protected void btnBuscarOferta_Click(object sender, EventArgs e)
        {
            LlenarGrdOfertas();
            imgBanner.Visible = false;

        }

        protected void btnPostularOferta_Click(object sender, EventArgs e)
        {
            Response.Redirect(UrlBase());
        }

        protected void btnViewOfferFeatured_Command(object sender, CommandEventArgs e)
        {


            if (e.CommandName == "GET")
            {
                Int32 index = Convert.ToInt32(e.CommandArgument) % grdOfertasDestacadas.PageSize;
                GridViewRow row = grdOfertasDestacadas.Rows[index];
                Int32 Id = Convert.ToInt32(((Label)row.FindControl("idOferta")).Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", $"showModal('{detalleOferta.ClientID}')", true);

                OfertaVO oferta = new OfertaVO();
                oferta.idOferta = Convert.ToInt32(Id);
                OfertaServiceClient _OfertaService = new OfertaServiceClient();
                OfertaVO viewOferta = _OfertaService.GetOfertaPersonaDetalle(oferta);
                _OfertaService.Close();
                lblOfferTitle.Text = viewOferta.tituloVacante;
                imgAvatarOffer.Src = $"{viewOferta.rutaAvatar}";
                lblOfferSalaryRange.Text = viewOferta.RangoSalario;
                lblDateCrateOffer.Text = String.Format("{0:yyyy-MM-dd}", viewOferta.fechaPublicacion);
                lblDateRemoveOffer.Text = String.Format("{0:yyyy-MM-dd}", viewOferta.fechaVencimiento);
                lblOfferUserWhoPublished.Text = viewOferta.nomEmpresa;
                lblOfferLocation.Text = viewOferta.nomCiudad;
                lblDescriptioOffer.Text = viewOferta.descripcionVacante;

            }

        }

        protected void btnCloseModal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", $"CloseModal('{detalleOferta.ClientID}', '{openModal.ClientID}')", true);
        }

        protected void txtCiudadBuscar_TextChanged(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<ListaVO> GetCiudades()
        {
            try
            {

                // Filtrar la lista de ciudades
                return listaCiudad;
            }
            catch
            {
                List<ListaVO> list = new List<ListaVO>();
                return list;
            }
        }
    }
}
