using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using co.itmasters.solucion.web.Code;
using co.itmasters.solucion.web.PersonaService;
using co.itmasters.solucion.web.Components_UI;
using co.itmasters.solucion.vo;
using System.IO;
using System.Web.Services;
using System.Web;
using MercadoPago.Config;
using MercadoPago.Client.Payment;
using MercadoPago.Resource.Payment;
using System.Threading.Tasks;
using MercadoPago.Client.Preference;
using MercadoPago.Resource.Preference;



namespace co.itmasters.solucion.web.Pagos
{
    public partial class Pagar : PageBase
    {
    public string preferenceID { get; set; }
      
        protected void Page_Load(object sender, EventArgs e)
        {
  
     
        }
        
    }
}