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
using co.itmasters.solucion.web.ComunesService;
using co.itmasters.solucion.web.PersonaService;
using co.itmasters.solucion.vo;
using co.itmasters.solucion.web.Code;
using System.Collections.Generic;

namespace co.itmasters.solucion.web
{
    public partial class Ayuda : PageBase
    {
        private int Alto = 600;
        private int Ancho = 1000;
        private string Titulo = "Agregar Reunión";
        protected PersonaServiceClient _PersonaService = null;
        private UserVO user;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

            }

        }

    }
}
