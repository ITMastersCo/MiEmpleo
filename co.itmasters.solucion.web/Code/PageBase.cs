using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using co.itmasters.solucion.vo;
using System.IO;
using System.Configuration;



namespace co.itmasters.solucion.web.Code
{
    public class PageBase: Page
    {
        private static String pageUrlBase;

        public PageBase()
        {
            Page.Load += new System.EventHandler(validarAccesoPagina_Handler);
            String urlSuffix = Context.Request.Url.Host + ":" + Context.Request.Url.Port + Context.Request.ApplicationPath;
            //pageUrlBase = @"http://" + urlSuffix;
            //pageUrlBase = @"" + urlSuffix;
            pageUrlBase = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath;
        }

        protected void validarAccesoPagina_Handler(object sender, System.EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                UserVO user = ((UserVO)Session["UsuarioAutenticado"]);
                //UsuarioVO user = (UsuarioVO)Membership.GetUser(User.Identity.Name);
                String page = Context.Request.Url.AbsolutePath;
                String aplicacion = Context.Request.ApplicationPath;

                string server = ConfigurationManager.AppSettings["ConfigServidor"]??"";

                if (server == "DEV")
                {
                    page = page.Substring(1, page.Length - 1);      // Valida para Desarrollo
                }
                else
                {
                    page = page.Replace(aplicacion, "");          // valida para servidor
                    page = page.Substring(1, page.Length - 1);    // valida para servidor
                }

                if (user != null && !validarPermisos(user.Formulario, page))
                {
                    //HttpContext.Current.Response.Redirect(this.UrlBase() + "Error.aspx?Msg=No tiene privilegios para acceder esta pagina:" + page);
                    throw new Exception("( " + user.NomUsuario + " ) No tiene privilegios para acceder la pagina: " + page);
                }
            }
        }


        private bool validarPermisos(List<FormularioVO> formularios, string page) 
        {
            bool res = false;
            try
            {
                foreach (FormularioVO formul in formularios)
                {
                    if (formul.Direccion.Equals(page))
                        return true;
                    else
                        res = false;
                }
                return res;
            }
            catch (Exception err)
            {
                Console.Write(err.Message);
                throw new Exception("( " + err.Message + " ) No tiene privilegios para acceder la pagina: " + page);
                return true;
            }
        }


        public static string partialURL()
        {
            Uri fullUri = HttpContext.Current.Request.Url;
            var applicationDirectory = fullUri.AbsoluteUri.Replace(fullUri.AbsolutePath, String.Empty);
            return applicationDirectory;

        }

        public String UrlBase()
        {
             return pageUrlBase; 
        }

        public string UrlBasePath()
        {
            string h = pageUrlBase.Substring(pageUrlBase.Length - 1, 1);

            if (!h.Equals("/"))
                pageUrlBase = pageUrlBase + "/";

            return pageUrlBase;
        }

        protected void GuardaError(String mensaje, String url)
        {
            String msj = "Usuario: " + User.Identity.Name + "\n";
            msj += "Direccion: " + url + "\n";
            msj += "Error: " + mensaje + "\n";
            //Log.Write(msj);
        }

        public String ExisteArchivo(String Ruta)
        {
            if (File.Exists(Server.MapPath(Ruta)))
                return Ruta;
            return "";
        }

        //protected void Error_Handler(object sender, System.EventArgs e)
        //{
        //    Response.Write("<br><b>An Error was raised</b>");
        //}

        //protected override void OnError(EventArgs e)
        //{
        //    String h = "asdfa";
        //    base.OnError(e);
        //}
        
    }
}
