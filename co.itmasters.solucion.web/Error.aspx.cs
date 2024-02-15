using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using co.itmasters.solucion.web.Code;

namespace co.itmasters.solucion.web
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ERROR = Server.GetLastError();
            HttpException lastError = (HttpException)Server.GetLastError();
            if (lastError != null)
            {
                string error = lastError.InnerException != null ? lastError.InnerException.Message : lastError.Message;
                lblMensaje.Text = error;
                LogWeb.Write(error, LogWeb.ERROR);
            }

        }

        protected void lnkAtras_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/default.aspx");
            Server.Transfer("~/Index.aspx");
        }


    }
}
