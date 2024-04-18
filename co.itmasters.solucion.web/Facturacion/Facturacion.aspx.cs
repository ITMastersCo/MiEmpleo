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
using co.itmasters.solucion.web.Components_UI;
using System.Web.UI.HtmlControls;
using System.Runtime;
using MercadoPago.Resource.Preference;
using MercadoPago.Client.Preference;
using MercadoPago.Resource.Payment;
using co.itmasters.solucion.vo.constantes;
using co.itmasters.solucion.web.MercadoPagoService;
using Newtonsoft.Json;
using System.Net;

namespace co.itmasters.solucion.web.Facturacion
{
    public partial class Facturacion : PageBase
    {
        private OfertaServiceClient _OfertaService;
        private UserVO user;
        private EmpresaServiceClient _Empresa;
        private MercadoPagoServiceClient _MercadoPagoService;
        private String AccesToken;


        protected void Page_Load(object sender, EventArgs e)
        {
            user = ((UserVO)Session["UsuarioAutenticado"]);
            AccesToken = (Session["AccesToken"].ToString());
            

            if (!Page.IsPostBack)
            {
                ProcesarPago();
                List<OfertaVO> listaOfertas = TraePlanesAdquiridos();  // Obtiene una lista de ofertas desde la base de datos.
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
            datosConsulta.estado = EstadoPago.ESTADO_CONCILIADO;

            _OfertaService = new OfertaServiceClient();
            List<OfertaVO> resultado = _OfertaService.TraePlanesAdquiridosEmpresa(datosConsulta).ToList();
            _OfertaService.Close();
            return resultado;


        }
        protected void AddPlanToContainer(OfertaVO plan)
        {
            
            UserControlCardPlanFacturacion ucCardPlan = (UserControlCardPlanFacturacion)LoadControl("~/Components_UI/UserControlCardPlanFacturacion.ascx");
            ucCardPlan.ID = plan.idPlan.ToString();
            ucCardPlan.Name = $"PAQUETE {plan.nomPlan} (Paquete Activo)"; ;
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
        protected void ProcesarPago()
        
        {

            if (Request.QueryString["preference_id"] != null 
                && Request.QueryString["status"] != null 
                && Request.QueryString["payment_id"] != null)
            {
                string preferenceId = Request.QueryString["preference_id"];
                string status = Request.QueryString["status"];
                string paymentId = Request.QueryString["payment_id"];
                
                switch (status)
                {
                    case PaymentStatus.Approved:
                        
                        UpdatePlanAdquirido(preferenceId, paymentId, EstadoPago.ESTADO_CONCILIADO);
                        UpdatePago(paymentId, EstadoPago.ESTADO_CONCILIADO);
                        break;
                    case PaymentStatus.InProcess:
                        Master.mostrarMensaje("En unas horas validaremos el pago", Master.INFORMACION);
                        UpdatePlanAdquirido(preferenceId, paymentId, EstadoPago.ESTADO_PENDIENTE);
                        break;
                    case PaymentStatus.Rejected:
                        Master.mostrarMensaje("No logramos procesar el pago intentalo nuevamente", Master.ERROR);
                        UpdatePlanAdquirido(preferenceId, paymentId, EstadoPago.ESTADO_RECHAZADO);
                        break;
                    default:
                        break;
                }
            }
            else
            {

            }
        }
        protected void UpdatePlanAdquirido(string preferenceId, string paymentId, string estado)
        {
            user = ((UserVO)Session["UsuarioAutenticado"]);
            try
            {
                EmpresaVO newEmpresa = new EmpresaVO();
                OfertaVO newPlan = new OfertaVO();

                newEmpresa.typeModify = TipoConsulta.MODIFY_UPDATE;
                newEmpresa.idUsuario = user.IdUsuario;
                newPlan.estado = estado;
                newPlan.payment_id = paymentId;
                newPlan.preference_id = preferenceId;
                newEmpresa.Oferta = newPlan;

                _Empresa = new EmpresaServiceClient();
                _Empresa.CreatePlanAdquirido(newEmpresa);
                _Empresa.Close();


            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        private void UpdatePago(string id, string estadoPago)
        {
            
            //api
            PaymentVO payment = GetPayment(id);

            var newPago = new OfertaVO();
            newPago.typeModify = TipoConsulta.MODIFY_INSERT;
            newPago.idUsuario = user.IdUsuario;
            newPago.descripcionPago = payment.description;
            newPago.payment_id = payment.id.ToString();
            newPago.payment_method = payment.payment_type_id;
            if (payment.description.Contains("Oferta"))
            {
                Master.mostrarMensaje("Oferta destacada con Exito", Master.EXITO);
                newPago.idOferta = Convert.ToInt16(payment.additional_info.items[0].id);
            }
            else
            {
                Master.mostrarMensaje("Plan Adquirido con Exito", Master.EXITO);
                newPago.idPlanAdquirido = Convert.ToInt16(payment.additional_info.items[0].id);
            }
            newPago.estado = EstadoPago.ESTADO_CONCILIADO;

            newPago.valorPago = Convert.ToInt32(payment.transaction_amount);

            _OfertaService = new OfertaServiceClient();
            _OfertaService.ModifyPagos(newPago);
            _OfertaService.Close();

            if (!payment.description.Contains("Oferta") )
            {
                Response.Redirect("~/Empresa/PublicarOfertas.aspx");
            }
        }
        private PaymentVO GetPayment(string id)
        {
            // Activa SSL para entorno de desarrollo 
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            this.AccesToken = (Session["AccesToken"].ToString());
            

            string ApiUrl = "https://api.mercadopago.com/v1/";
            string AccesToken = this.AccesToken;


            var url = $"{ApiUrl}payments/{id}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Headers["Authorization"] = $"Bearer {AccesToken}";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null; ;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();

                            PaymentVO payment = JsonConvert.DeserializeObject<PaymentVO>(responseBody);


                            return payment;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                return null;
                throw new Exception();
            }
        }
    }
}