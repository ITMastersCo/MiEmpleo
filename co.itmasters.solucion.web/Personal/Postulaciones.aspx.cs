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
using MercadoPago.Resource.User;

namespace co.itmasters.solucion.web.Personal
{
    public partial class Postulaciones : PageBase
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
            {
                List<ListaVO> listadeOcupaciones = _carga.TablasBasicas(TipoCombo.CMBOCUPACIONESPERSONAPOSTULACION, new string[] { user.IdUsuario.ToString() });
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
            datosConsulta.idOcupacion = ocupacion;
            datosConsulta.fechaInicia = fechaIni;
            datosConsulta.fechaFinaliza = fechaFin;
            _OfertaService = new OfertaServiceClient();
            List<OfertaVO> resultado = _OfertaService.Oferta_PersonaPostulaciones(datosConsulta).ToList<OfertaVO>();
            _OfertaService.Close();
            if (resultado.Count > 0)
            {
                GrdOfertas.DataSource = resultado;
                GrdOfertas.DataBind();
              }

        }
   
        protected void btnFilter_Click(object sender, EventArgs e)
        {
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
            lblOfferUserWhoPublished.Text = viewOferta.nomEmpresa;
            lblOfferLocation.Text = viewOferta.nomCiudad;
            lblDescriptioOffer.Text = viewOferta.descripcionVacante;
      
        }
        protected void btnCloseModal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", $"CloseModal('{detalleOferta.ClientID}', '{openModal.ClientID}')", true);
        }
    }
}