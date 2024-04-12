using co.itmasters.solucion.web.Code;
using co.itmasters.solucion.vo;
using co.itmasters.solucion.web.EmpresaService;
using MercadoPago.Client.Preference;
using MercadoPago.Config;
using MercadoPago.Resource.Preference;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SqlServer.Server;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using co.itmasters.solucion.web.Empresa;
using MercadoPago.Client.Payment;
using co.itmasters.solucion.vo.constantes;
using System.Security.Cryptography.X509Certificates;
using System.Globalization;

namespace co.itmasters.solucion.web.Components_UI
{
    public partial class UserControlCardPlan : UserControl
    {
        private EmpresaServiceClient _Empresa;
        private UserVO user ;
        private String AccesToken;
        private String PublicToken;
        

        private string IconState(Boolean state)
        {
            if (state == true)
            {
                return @"
                     <svg xmlns='http://www.w3.org/2000/svg' class='icon-24 color-green-400' fill='none' viewBox='0 0 24 24' stroke='currentColor' stroke-width='2'>
                        <path stroke-linecap='round' stroke-linejoin='round' d='M5 13l4 4L19 7' />
                     </svg>
                    ";
            }
            else if (state == false)
            {
                return @"
                     <svg xmlns='http://www.w3.org/2000/svg' class='icon-24 color-red-500' fill='none' viewBox='0 0 24 24' stroke='currentColor' stroke-width='2'>
                        <path stroke-linecap='round' stroke-linejoin='round' d='M6 18L18 6M6 6l12 12' />
                     </svg>
                    ";
            }
            else
            {
                return state.ToString();
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                user = ((UserVO)Session["UsuarioAutenticado"]);
                AccesToken = (Session["AccesToken"].ToString());
                PublicToken = (Session["PublicToken"].ToString());
            }
            PlanesEmpresa page = Page as PlanesEmpresa;
            if (page != null)
            {
                this.PreferenceID = page.PreferenceID;
                
            }

        }

        private int PlanPrice { get; set; }
        private int PlanId { get; set; }
        private int VigenciaPlan { get; set; }
        private int NumerodeOfertas { get; set; }
        public int IdEmpresa { get; set; }
        public string idPlan
        {
            set { PlanId = Convert.ToInt32(value); }
        }
        public string TextBtnPlan
        {
            set { btnGetPlan.Text = value; }
        }
        public string Name
        {
            set { namePlan.InnerText = value; }
        }
        public int? Price
        {
            set
            {
                if (value != null)
                {
                    PlanPrice = Convert.ToInt32(value);
                    pricePlan.InnerText = $"${Convert.ToInt32(value).ToString("N0", CultureInfo.InvariantCulture)}";
                }
            }
        }
        public Boolean OffersFeatured

        {
            set { stateOfertaDestacad.InnerHtml = IconState(value); }
        }
        public Boolean OffersConfidential
        {
            set { stateOfertasConfidenciales.InnerHtml = IconState(value); }
        }
        public Boolean QuestionsFilter
        {
            set { statePreguntaFiltro.InnerHtml = IconState(value); }
        }
        public Boolean ProgrammingMeetZoom
        {
            set { stateProgramacionZoom.InnerHtml = IconState(value); }
        }
        public Boolean MultiUser
        {
            set { stateMultiUsuario.InnerHtml = IconState(value); }
        }
        public Boolean TrainingTech
        {
            set { stateCapacitacion.InnerHtml = IconState(value); }
        }
        public string TimePublication
        {
            set { stateTiempoPublicacion.InnerText = value; }
        }
        public string PlanValidity
        {
            set {
                VigenciaPlan = Convert.ToInt32(value);
                stateVigenciaPlan.InnerText = $"{value} días"; }
        }
         public string PreferenceID { get; set; }

        protected void btnGetPlan_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                CreatePreferenceAsync();

            }
            catch (Exception err) {
                throw new Exception(err.Message);
            }
        }
        protected async void CreatePreferenceAsync() 
        {

            user = ((UserVO)Session["UsuarioAutenticado"]);
            AccesToken = (Session["AccesToken"].ToString());
            PublicToken = (Session["PublicToken"].ToString());

            try
            {


                string fullUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
                string ruta = "MiEmpleo";


                MercadoPagoConfig.AccessToken = AccesToken;


                //Crea el objeto de request de la preference
                string idPlanAdquirido =  CreaPlanAdquirido();
                var request = new PreferenceRequest
                {

                Items = new List<PreferenceItemRequest>
                      {
                          new PreferenceItemRequest
                          {
                              Id = idPlanAdquirido,
                              Title = namePlan.InnerText ,
                              Quantity = 1,
                              CurrencyId = "COP",
                              UnitPrice = Convert.ToInt32(this.PlanPrice),
                          },
                          
                      },
                    BackUrls = new PreferenceBackUrlsRequest
                    {
                        Success = $"{fullUrl}/{ruta}/Facturacion/Facturacion.aspx",
                        Failure = $"{fullUrl}/{ruta}/Facturacion/Facturacion.aspx",
                        Pending = $"{fullUrl}/{ruta}/Facturacion/Facturacion.aspx",
                    },
                    AutoReturn = "approved",
                };

                // Crea la preferencia usando el client
                var client = new PreferenceClient();
                Preference preference = await client.CreateAsync(request);
                if (preference != null)
                {
                   ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba"
                    , $"payMercadoPago_{this.ClientID}('{preference.Id}','{wallet_container.ClientID}','{PublicToken}')", true);
                    AddPreferenceIdToPlanesAdquiridos(int.Parse(idPlanAdquirido), preference.Id);
                }
                
                
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }

        }
        protected string CreaPlanAdquirido()
        {
             user = ((UserVO)Session["UsuarioAutenticado"]);
             try { 
             EmpresaVO newEmpresa = new EmpresaVO();
             OfertaVO newPlan = new OfertaVO();

             newEmpresa.typeModify = TipoConsulta.MODIFY_INSERT;
             newEmpresa.idUsuario = user.IdUsuario;
             newPlan.idPlan = Convert.ToInt32(PlanId);
             newPlan.vigenciaPlan = VigenciaPlan;
             newPlan.numeroOfertas = NumerodeOfertas;
             newPlan.valorPlan = PlanPrice;
              newEmpresa.Oferta = newPlan;

             _Empresa = new EmpresaServiceClient();
             string idPlanAdquirido =  _Empresa.CreatePlanAdquirido(newEmpresa);
             _Empresa.Close();
                 return idPlanAdquirido;
             }catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
        protected void AddPreferenceIdToPlanesAdquiridos(int idPlanAdquirido, string preference_id)
        {

            user = ((UserVO)Session["UsuarioAutenticado"]);
            try
            {
                EmpresaVO newEmpresa = new EmpresaVO();
                OfertaVO newPlan = new OfertaVO();

                newEmpresa.typeModify = TipoConsulta.MODIFY_UPDATE;
                newEmpresa.idUsuario = user.IdUsuario;
                newPlan.preference_id = preference_id;
                newPlan.idPlanAdquirido = idPlanAdquirido;
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

        protected void btnSubmitPay_Click(object sender, EventArgs e)
        {
        }
        
    }
}