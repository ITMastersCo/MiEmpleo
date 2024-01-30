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
//using SpeechLib;


namespace co.itmasters.solucion.web.Home
{
    public partial class Login : System.Web.UI.Page
    {
        /// <summary>
        /// Orden de los eventos disparados.
        /// 1.LoggingIn event
        /// 2.Authenticate event. (Membership.ValidateUser)
        /// Si esta Ok validacion
        /// 3.LoggedIn event
        /// No Ok
        /// 4.LoginError event 
        /// 5. "/2" identifica qes es un candidato
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //SpVoice Voz = new SpVoice();

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void cLogin_LoggedIn(object sender, EventArgs e)
        {
            UserVO user = (UserVO)Membership.GetUser(cLogin.UserName+"/2");
            Session["UsuarioAutenticado"] = user;
        }

        protected void cLogin_Authenticate(object sender, AuthenticateEventArgs e)
        {
            try
            {

                if (Membership.ValidateUser(cLogin.UserName + "/2", cLogin.Password))
                {
                    e.Authenticated = true;
                }
                else
                {
                    e.Authenticated = false;
                }
            }
            catch (Exception err)
            {
                e.Authenticated = false;
                cLogin.FailureText = err.Message;
            }
        }
    }
}
