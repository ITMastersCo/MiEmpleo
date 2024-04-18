using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;
using co.itmasters.solucion.vo;
using co.itmasters.solucion.web.Code;
using co.itmasters.solucion.web.EmpresaService;
using co.itmasters.solucion.web.SeguridadService;
namespace co.itmasters.solucion.web.Home
{
    public partial class LoginEmpresa : System.Web.UI.Page
    {
        SeguridadServiceClient _SeguridadService;
        private EmpresaServiceClient _EmpresasService;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
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

        protected void cLogin_LoggedIn(object sender, EventArgs e)
        {
            UserVO user = (UserVO)Membership.GetUser(cLogin.UserName + "/1");
            Session["UsuarioAutenticado"] = user;

            _SeguridadService = new SeguridadServiceClient();
            List<CredencialesVO> credenciales = _SeguridadService.GetCredenciales(user.IdUsuario).ToList();
            _SeguridadService.Close();

            var AccesToken = credenciales.Find(element => element.nombre.Contains("AccesToken")).valor;
            var PublicToken = credenciales.Find(element => element.nombre.Contains("PublicToken")).valor;

            Session["AccesToken"] = AccesToken;
            Session["PublicToken"] = PublicToken;

            var Empresa = new EmpresaVO { idUsuario = user.IdUsuario };

            _EmpresasService = new EmpresaServiceClient();
            EmpresaVO CurrentEmpresa = _EmpresasService.DatosEmpresa(Empresa);
            _EmpresasService.Close();
            Session["Empresa"] = CurrentEmpresa;

        }

        protected void cLogin_Authenticate(object sender, AuthenticateEventArgs e)
        {
            try
            {

                if (Membership.ValidateUser(cLogin.UserName + "/1", cLogin.Password))
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