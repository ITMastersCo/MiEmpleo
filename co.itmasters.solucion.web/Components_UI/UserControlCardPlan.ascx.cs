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

namespace co.itmasters.solucion.web.Components_UI
{
    public partial class UserControlCardPlan : UserControl
    {
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

        }
        private int PlanPrice { get; set; }
        public string TextBtnPlan
        {
            set { btnGetPlan.Text = value; }
        }
        public string Name
        {
            set { namePlan.InnerText = value; }
        }
        public string Price
        {
            set
            {
                PlanPrice = Convert.ToInt32(value);
                pricePlan.InnerText = $"${value}";
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
            set { stateVigenciaPlan.InnerText = value; }
        }
      


        protected void btnGetPlan_ClickAsync(object sender, EventArgs e)
        {
            CreatePreferenceAsync();
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba"
            //    , $"payMercadoPago({preference})", true);

        }
        protected async void CreatePreferenceAsync() 
        {
            try
            {

            MercadoPagoConfig.AccessToken = "APP_USR-2148574929506385-013011-2a326a05936b10aaeafa5b0b78b61be6-1660977390";

                //Crea el objeto de request de la preference
                var request = new PreferenceRequest
                {
                    Items = new List<PreferenceItemRequest>
                      {
                          new PreferenceItemRequest
                          {
                              Title = namePlan.InnerText ,
                              Quantity = 1,
                              CurrencyId = "COP",
                              UnitPrice = Convert.ToInt32(this.PlanPrice),
                          },
                          
                      },
                    BackUrls = new PreferenceBackUrlsRequest
                    {
                        Success = "http://localhost:8080/Empresa/PlanesEmpresa.aspx",
                        Failure = "http://localhost:8080/Empresa/PlanesEmpresa.aspx",
                        Pending = "http://localhost:8080/Empresa/PlanesEmpresa.aspx",
                    },
                    AutoReturn = "approved",
                };

                // Crea la preferencia usando el client
                var client = new PreferenceClient();
                Preference preference = await client.CreateAsync(request);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba"
                    , $"payMercadoPago('{preference.Id}')", true);
            }
            catch (Exception err) 
            {
             
            }
        }

    }
}