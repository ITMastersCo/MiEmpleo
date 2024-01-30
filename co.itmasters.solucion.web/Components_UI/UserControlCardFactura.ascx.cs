using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace co.itmasters.solucion.web.Components_UI
{
    public partial class UserControlCardFactura : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string PriceFact
        {
            set { priceFac.InnerText = $"$ {value}"; }
        }
        
    }
}