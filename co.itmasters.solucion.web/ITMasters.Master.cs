﻿using System;
using System.Diagnostics;
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
using System.Windows.Forms;

using System.Xml.Linq;
using co.itmasters.solucion.web.Code;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace co.itmasters.solucion.web
{
    public partial class ITMasters : System.Web.UI.MasterPage
    {
        public String INFORMACION = "info";
        public String EXITO = "exito";
        public String ERROR = "error";
        private UserVO user;
        protected void Page_Load(object sender, EventArgs e)
        {
            //InsertLogOut();
            if (this.IsPostBack)
            {
                return;
            }
            if (Session["UsuarioAutenticado"] != null)
            {
                this.dibujarMenu();
                user = ((UserVO)Session["UsuarioAutenticado"]);
                
                if (user.tipoUsuario == 1 || user.tipoUsuario ==3)
                {
                    imgMaster.Src = "~/images/ImgInicio/LOGO-dark.png";
                    lblButton.Text = "Publicar oferta";
                    btnLink.HRef = "~/Empresa/PublicarOfertas.aspx";
                }
                else 
                {
                    imgMaster.Src = "~/images/ImgInicio/LOGO.png";
                    lblButton.Text = "Imprimir hoja de vida";
                    btnLink.HRef = "~/Index.aspx";
                }

                //lblCorreo.Text = ConfigurationManager.AppSettings.Get("Correo");
                //lblTelefono.Text = ConfigurationManager.AppSettings.Get("Telefono");
                //lblUsuario.Text = "" + ((UserVO)Session["UsuarioAutenticado"]).Nombre1 + " " + ((UserVO)Session["UsuarioAutenticado"]).Nombre2 + " " + ((UserVO)Session["UsuarioAutenticado"]).Apellido1 + " " + ((UserVO)Session["UsuarioAutenticado"]).Apellido2;
                //lblColegio1.Text = "" + ((UserVO)Session["UsuarioAutenticado"]).NomColegio;
                //lblColegio2.Text = "" + ((UserVO)Session["UsuarioAutenticado"]).NomColegio2;
            }
            else
            {
                Server.Transfer("~/Index.aspx");
            }
        }
        


        protected void ScriptManager1_AsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e)
        {
            String dir = ((ScriptManager)sender).Page.AppRelativeVirtualPath;
            //Response.Redirect("~/Error.aspx);
            Server.Transfer("~/Error.aspx");
        }

        //---------------------------
        // Pinta menu para el usuario
        public string dibujarMenu()
        {
            UserVO user = (UserVO)Session["UsuarioAutenticado"];

            if (user != null)
            {
                GeneraMenu _menu = new GeneraMenu();
                //return _menu.generarMenu(user);
                return _menu.getMenu(user);
            }
            else
                return string.Empty;
        }

        //------------------
        // Banda de mensajes
        public void mostrarMensaje(string mensaje, string tipo)
        {
            this.BandaMensaje.Style["Display"] = "block";
            lblDesplegar.Text = mensaje;

            if (tipo.Equals(INFORMACION))
            {
                this.BandaMensaje.Style["color"] = "#00529B";
                this.BandaMensaje.Style["background-color"] = "#BDE5F8";
                this.BandaMensaje.Style["background-image"] = "url('~/Images/info.gif')";
            }
            else if (tipo.Equals(EXITO))
            {
                this.BandaMensaje.Style["color"] = "#4F8A10";
                this.BandaMensaje.Style["background-color"] = "#DFF2BF";
                this.BandaMensaje.Style["background-image"] = "url('~/Images/exito.gif')";
            }
            
            else if (tipo.Equals(ERROR))
            {
                this.BandaMensaje.Style["color"] = "#D8000C";
                this.BandaMensaje.Style["background-color"] = "#FFBABA";
                this.BandaMensaje.Style["background-image"] = "url('~/Images/Error.gif')";
            }


        }

        //--------------------------
        // Ocultar banda de mensajes
        public void OcultarBanda()
        {
            this.BandaMensaje.Style["Display"] = "none";
            lblDesplegar.Text = "";
        }


        protected void ImgAyuda_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Ayuda.aspx");
        }


  
        protected void ImgInicio_Click(object sender, ImageClickEventArgs e)
        {
            Server.Transfer("~/default.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
        protected void InsertLogOut()
        {

            string HtmlLogOut = "<svg xmlns='http://www.w3.org/2000/svg' class='menu-logOut' fill='none' viewBox='0 0 24 24' stroke='currentColor' stroke-width='2'>";
            HtmlLogOut += "<path stroke-linecap='round' stroke-linejoin='round' d='M17 16l4-4m0 0l-4-4m4 4H7m6 4v1a3 3 0 01-3 3H6a3 3 0 01-3-3V7a3 3 0 013-3h4a3 3 0 013 3v1' />";
            HtmlLogOut += "</svg>";

            ContainerBtnCerrar.InnerHtml = HtmlLogOut;

            System.Web.UI.WebControls.Label label = new System.Web.UI.WebControls.Label();


            label.ID = "lblCerrar";
            label.AssociatedControlID = "btnCerrar";
            label.Controls.Add(ContainerBtnCerrar);

          
        }

        
        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            HttpContext.Current.Session.Clear();
            FormsAuthentication.SignOut();
            Response.Redirect("~/Index.aspx", true);
        }
    }
}
