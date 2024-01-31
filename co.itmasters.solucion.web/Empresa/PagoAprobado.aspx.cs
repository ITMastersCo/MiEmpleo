using CrystalDecisions.ReportAppServer.DataDefModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace co.itmasters.solucion.web.Empresa
{
    public partial class PagoAprobado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["collection_id"] != null && Request.QueryString["status"] != null)
            {
                string collectionId = Request.QueryString["collection_id"];
                string status = Request.QueryString["status"];

                
            }
            else
            {
                // Handle the case where the response data is missing
            }
        }
    }
}