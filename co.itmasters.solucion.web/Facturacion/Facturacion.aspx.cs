using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using co.itmasters.solucion.web.Components_UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using co.itmasters.solucion.web.Code;
using co.itmasters.solucion.web.OfertaService;
using co.itmasters.solucion.vo;
using System.Web.Services;
using System.IO;
using co.itmasters.solucion.web.EmpresaService;


namespace co.itmasters.solucion.web.Facturacion
{
    public partial class Facturacion : PageBase
    {
        private OfertaServiceClient _OfertaService;
        private UserVO user;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = ((UserVO)Session["UsuarioAutenticado"]);
            List<OfertaVO> listaOfertas = TraePlanesAdquiridos();  // Obtiene una lista de ofertas desde la base de datos.

            if (!Page.IsPostBack)
            {
                ShowPlans(listaOfertas); // Renderiza un lista de Ofertas
            }
            
        }


        protected List<OfertaVO> GetOffers()
        {
            user = ((UserVO)Session["UsuarioAutenticado"]);
            Master.OcultarBanda();
            try
            {
                OfertaVO datosConsulta = new OfertaVO();
                datosConsulta.idUsuario = user.IdUsuario;

                _OfertaService = new OfertaServiceClient();
                List<OfertaVO> resultado = _OfertaService.TraeEstadoOferta(datosConsulta).ToList<OfertaVO>();
                _OfertaService.Close();

                return resultado;
            }
            catch (Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);
                return null;
            }

        }
        protected List<OfertaVO> TraePlanesAdquiridos()
        {
            OfertaVO datosConsulta = new OfertaVO();
            datosConsulta.typeModify = TipoConsulta.GET;
            datosConsulta.idUsuario = user.IdUsuario;
            datosConsulta.estado = EstadoPago.ESTADO_CONSOLIDADO;

            _OfertaService = new OfertaServiceClient();
            List<OfertaVO> resultado = _OfertaService.TraePlanesAdquiridosEmpresa(datosConsulta).ToList();
            _OfertaService.Close();
            return resultado;


        }
        protected void AddPlanToContainer(OfertaVO plan)
        {
            
            UserControlCardPlanFacturacion ucCardPlan = (UserControlCardPlanFacturacion)LoadControl("~/Components_UI/UserControlCardPlanFacturacion.ascx");
            ucCardPlan.ID = plan.idPlan.ToString();
            ucCardPlan.Name = $"PAQUETE {plan.nomPlan} (Paquete Actual)"; ;
            ucCardPlan.OffersFeatured = Convert.ToBoolean(plan.ofertaDestacada);
            ucCardPlan.OffersConfidential = Convert.ToBoolean(plan.ofertaConfidencial);
            ucCardPlan.QuestionsFilter = Convert.ToBoolean(plan.preguntasDeFiltro);
            ucCardPlan.ProgrammingMeetZoom = Convert.ToBoolean(plan.entrevistaZoom);
            ucCardPlan.MultiUser = Convert.ToBoolean(plan.multiusuario);
            ucCardPlan.TrainingTech = Convert.ToBoolean(plan.capacitaciones);
            ucCardPlan.TimePublication = $"{plan.diasPublicacionOferta} días";
            ucCardPlan.PlanValidity = $"{plan.vigenciaPlan} días";
            ucCardPlan.TextBtnPlan = "Ver Otros Paquetes";


            containerPlans.Controls.Add(ucCardPlan);
        }
        protected void AddFactToContainer()
        {
            UserControlCardFactura ucCardFac = (UserControlCardFactura)LoadControl("~/Components_UI/UserControlCardFactura.ascx");
            

            containerFacturas.Controls.Add(ucCardFac);
        }
        protected void ShowPlans(List<OfertaVO> plans)
        {
            foreach (OfertaVO plan in plans)
            {
                AddPlanToContainer(plan);
            }
        }
        protected void ActiveLash(HtmlButton lash)
        {
            lash.Attributes.Add("class", "pestana active");
        }
        protected void DesactiveLash(HtmlButton lash)
        {
            lash.Attributes.Add("class", "pestana");
        }
    }
}