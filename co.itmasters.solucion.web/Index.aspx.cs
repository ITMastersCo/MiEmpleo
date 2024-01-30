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
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrdOfertas();
        }

        private void LlenarGrdOfertas()
        {
            OfertaVO oferta = new OfertaVO();
            oferta.idUsuario = 0;



            _OfertaService = new OfertaServiceClient();
            List<OfertaVO> listOffer = _OfertaService.GetOfertaPersona(oferta).ToList<OfertaVO>();
            _OfertaService.Close();

            

            if (listOffer.Count > 0)
            
            { grdOfertasDestacadas.DataSource = listOffer.Take(4);
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
                lblOfferSalaryRange.Text = viewOferta.RangoSalario;
                lblDateCrateOffer.Text = String.Format("{0:yyyy-MM-dd}", viewOferta.fechaPublicacion);
                lblDateRemoveOffer.Text = String.Format("{0:yyyy-MM-dd}", viewOferta.fechaVencimiento);
                lblOfferUserWhoPublished.Text = viewOferta.nomEmpresa;
                lblOfferLocation.Text = viewOferta.nomCiudad;
                lblDescriptioOffer.Text = viewOferta.descripcionVacante;
                
            }   

        }

        protected void btnPostularOferta_Click(object sender, EventArgs e)
        {
            Response.Redirect(UrlBase());
        }
    }
}
