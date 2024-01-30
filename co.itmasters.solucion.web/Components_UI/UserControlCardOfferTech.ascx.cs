using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace co.itmasters.solucion.web.Components_UI
{
    public partial class UserControlCardOfferTech : System.Web.UI.UserControl
    {
        public string Title
        {
            set { offerTitle.InnerText = value; }
        }

        public int? Views
        {
            set { offerViews.InnerText = value.ToString(); }
        }
        public string UserWhoPublishing
        {
            set { offerUserWhoPublished.InnerText = value; }
        }
        public DateTime? Date
        {
            

            set {
                

                offerDate.InnerText = value.ToString(); 
            }
        }
        public string SalaryRange
        {
            set { offerSalaryRange.InnerText = value; }
        }
        public int? Location
        {
            set { offerLocation.InnerText = value.ToString(); }
        }
        public int? NumApplications
        {
            set { offerAppications.InnerText = value.ToString(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        
    }
}