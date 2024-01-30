using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace co.itmasters.solucion.web.Components_UI
{
    public partial class ModalUserControl : System.Web.UI.UserControl
    {

        

        
        public string ModalTitle {
            set { titleModal.InnerText = value; }
        }
        public string ModalSize { get; set; }
        public bool hasButton { get; set; }
        public string textBtnAccept
        {
            set { btnAccept.Text = value; }
        }
        public string textBtnCancel
        {
            set { btnCancel.Text = value; }
        }
        protected bool GetHasButton()
        {
            return hasButton;
        }

        protected string GetSize()
        {
            return ModalSize;
        }
        protected string GetContainerCssClass()
        {
            return $"modal {GetSize()}";
        }
        public void SetContent(Control contentControl)
        {
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(contentControl);
        }


        public class ModalEventArgs : EventArgs
        {
            public object Parameter { get; set; }

            public ModalEventArgs(object parameter)
            {
                Parameter = parameter;
            }
        }


        public object paramCancel{ get; set; }
        public delegate void ExternalFunctionCancel();
        public event ExternalFunctionCancel OnSubmitCancel;
        public ExternalFunctionCancel FunctionCancel { get; set; }
        public object paramAccept { get; set; }
        public delegate void ExternalFunctionAccept();
        public event ExternalFunctionAccept OnSubmitAccept ;
        public ExternalFunctionAccept FunctionAccept { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            DataBind();

            hasButton = false;
            btnCancel.Click += btnCancel_Click;
            btnAccept.Click += btnAccept_Click;
        }
        public void btnCancel_Click(object sender, EventArgs e)
        {
            // Lógica a ejecutar cuando se hace clic en el botón "Submit"
            // Invoca la función externa si está asignada
            OnSubmitCancel?.Invoke();

            // O invoca la función externa desde la propiedad si está asignada
            FunctionCancel?.Invoke();
            this.Visible = false;
        }

        public void btnAccept_Click(object sender, EventArgs e)
        {
            // Lógica a ejecutar cuando se hace clic en el botón "Submit"
            // Invoca la función externa si está asignada

            OnSubmitAccept?.Invoke();

            // O invoca la función externa desde la propiedad si está asignada
            FunctionAccept?.Invoke();
            this.Visible = false;

        }
        public void btnClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}