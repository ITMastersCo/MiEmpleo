using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace co.itmasters.solucion.web.Components_UI
{
    public partial class UserControlCvItem : System.Web.UI.UserControl
    {
        public string OnClientClickEdit { get; set; }
        public object Param { get; set; }
        public string IdItem { get; set; }
        public string idItemPersona { get; set; }
        public string idItemUsuario { get; set; }
        public string Title
        {
            set { itemTitle.InnerText = value; }
        }
        public Control RederContainer { get; set; }
        public string Content
        {
            set { itemContent.InnerText = value; }
        }
        public string Date
        {
            set { itemDate.InnerText = value; }
        } public string Icon
        {
            set { itemIcon.InnerHtml = value; }
        }

        private Control form { get; set; }

        public string TitleFrom { get; set; }
        public void SetForm(Control control)
        {
            this.form = control;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            DataBind();
        }

        public delegate void FunctionEdit(string id, string idPersona, string idUsuario);

        public event FunctionEdit OnEditClicked;
        public FunctionEdit ExternalFunctionEdit { get; set; }

        public delegate void FunctionDelete();

        public event FunctionDelete OnDeleteClicked;

        public FunctionDelete ExternalFunctionDelete { get; set; }

        public event EventHandler AceptarClicked;

        protected virtual void OnClick(object sender)

        {

            if (this.AceptarClicked != null)

            {

                this.AceptarClicked(sender, new EventArgs());

            }

        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {//Hardcode para simular una búsquedathis.resultados = new


            //Se invoca el evento público una vez la función del control ha terminado
            
            OnClick(sender);
            //ExternalFunctionEdit?.Invoke(IdItem, idItemPersona, idItemUsuario);

        }
        protected void btnEdit_ServerClick(object sender, EventArgs e)
        {   

            OnEditClicked?.Invoke(IdItem, idItemPersona, idItemUsuario);

            ExternalFunctionEdit?.Invoke(IdItem, idItemPersona, idItemUsuario);

        }

        protected void btnDelete_ServerClick(object sender, EventArgs e)
        {


            OnDeleteClicked?.Invoke();
            ExternalFunctionDelete?.Invoke();

            //Logic for delete element in page and server
            
        }
    }
}