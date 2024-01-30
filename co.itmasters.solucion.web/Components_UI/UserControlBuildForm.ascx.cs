using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using co.itmasters.solucion.web.Code;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace co.itmasters.solucion.web.Components_UI
{
    public partial class UserControlBuildForm : System.Web.UI.UserControl
    {
        private CargaCombos _carga = new CargaCombos();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataBind();
            ResetBuilder();
            btnAccept.Click += btnAccpet_Click;
        }

        private void ResetBuilder()
        {
            hasButtons = false;
        }
        public bool hasButtons { get; set; }

        protected bool GetHasButtons()
        {
            return hasButtons;
        }
        public void AddRow(string labelText, string inputType, object inputValue = null, string placeholder = null,
            string cmb = null, string cmbFiltro = null,
             object min = null, object max = null

            )
        {
            // Crea un nuevo Label
            Label label = new Label();
            label.Text = labelText;
            label.CssClass = "text-item text-semibold text-gray-700";

            // Crea un nuevo control según el tipo especificado
            Control inputControl = new Control();

            switch (inputType.ToLower())
            {
                case "text":
                    TextBox textBox = new TextBox();
                    textBox.TextMode = TextBoxMode.SingleLine;
                    textBox.CssClass = "text-box";
                    if (inputValue != null)
                    { textBox.Attributes["value"] = inputValue?.ToString(); }
                    inputControl = textBox;
                    break;
                case "dropdown":
                    DropDownList dropdown = new DropDownList();
                    dropdown.CssClass = "drop-down-list";
                    //ListItem itemUno = new ListItem("Seleccione un elemento", "-1");
                    //dropdown.Items.Add(itemUno);
                    if (cmb != null && cmbFiltro != null)
                    { _carga.Cargar(dropdown, cmb, cmbFiltro); }
                    else if (cmb != null)
                    { _carga.Cargar(dropdown, cmb); }

                    if (inputValue != null)
                    { dropdown.SelectedValue = inputValue.ToString(); }
                    //else { dropdown.SelectedValue = "-1"; }
                    inputControl = dropdown;
                    break;
                case "dropdown-label":
                    DropDownList dropdownLabel = new DropDownList();
                    dropdownLabel.CssClass = "inputLabel text-item text-semibold text-gray-700 text-center";
                    //ListItem itemUno = new ListItem("Seleccione un elemento", "-1");
                    //dropdown.Items.Add(itemUno);
                    if (cmb != null && cmbFiltro != null)
                    { _carga.Cargar(dropdownLabel, cmb, cmbFiltro); }
                    else if (cmb != null)
                    { _carga.Cargar(dropdownLabel, cmb); }
                    if (inputValue != null)
                    { dropdownLabel.SelectedValue = inputValue.ToString(); }
                    //else { dropdown.SelectedValue = "-1"; }
                    dropdownLabel.Enabled = false;
                    inputControl = dropdownLabel;
                    break;
                case "checkbox":
                    CheckBox checkBox = new CheckBox();
                    if (inputValue != null)
                    { checkBox.Attributes["value"] = inputValue.ToString(); }
                    inputControl = checkBox;
                    break;
                case "radio":
                    RadioButton radioButton = new RadioButton();
                    radioButton.GroupName = "radioGroup"; // Asigna un nombre al grupo de radio buttons
                    if (inputValue != null)
                    { radioButton.Attributes["value"] = inputValue.ToString(); }
                    inputControl = radioButton;
                    break;
                case "textarea":
                    TextBox textarea = new TextBox();
                    textarea.TextMode = TextBoxMode.MultiLine;
                    textarea.CssClass = "text-area";
                    if (inputValue != null)
                    { textarea.Text = inputValue.ToString(); }
                    inputControl = textarea;
                    break;
                case "file":
                    FileUpload fileUpload = new FileUpload();
                    if (inputValue != null)
                    { fileUpload.Attributes["value"] = inputValue.ToString(); }
                    inputControl = fileUpload;
                    break;
                case "password":
                    TextBox passwordTextBox = new TextBox();
                    passwordTextBox.TextMode = TextBoxMode.Password;
                    if (inputValue != null)
                    { passwordTextBox.Attributes["value"] = inputValue.ToString(); }
                    inputControl = passwordTextBox;
                    break;
                case "date":
                    TextBox dateTextBox = new TextBox();
                    dateTextBox.TextMode = TextBoxMode.Date;
                    dateTextBox.CssClass = "text-box";


                    string dateMax = String.Format("{0:yyyy-MM-dd}", max);
                    string dateMin = String.Format("{0:yyyy-MM-dd}", min);
                    dateTextBox.Attributes["max"] = dateMax.ToString();
                    dateTextBox.Attributes["min"] = dateMin.ToString();
                    if (inputValue != null)
                    {
                        DateTime dateconvert = Convert.ToDateTime(inputValue);
                        string dateValue = String.Format("{0:yyyy-MM-dd}", dateconvert);
                        dateTextBox.Attributes["value"] = dateValue.ToString();
                    }
                    inputControl = dateTextBox;
                    break;
                case "number":
                    TextBox numberTextBox = new TextBox();
                    numberTextBox.TextMode = TextBoxMode.Number;
                    numberTextBox.CssClass = "text-box";
                    if (inputValue != null)
                    { numberTextBox.Attributes["value"] = inputValue.ToString(); }
                    inputControl = numberTextBox;
                    break;
                case "label":
                    Label labelTexBox = new Label();
                    labelTexBox.CssClass = "text-item text-semibold text-gray-700 text-center";
                    if (inputValue != null)
                    { labelTexBox.Text = inputValue.ToString(); }
                    inputControl = labelTexBox;
                    break;
                // Agrega más casos según los tipos que necesites
                default:
                    break;
            }

            // Asigna un ID único al control
            inputControl.ID = $"dynamicControl_{dynamicFieldsPanel.Controls.Count}";



            // Agrega los controles al PlaceHolder
            dynamicFieldsPanel.Controls.Add(label);
            dynamicFieldsPanel.Controls.Add(inputControl);

        }
        public class FormData
        {
            public string TextValue { get; set; }
            public string DropdownValue { get; set; }
            public bool CheckBoxValue { get; set; }
            public string RadioButtonValue { get; set; }
            public string TextAreaValue { get; set; }
            public HttpPostedFile FileUploadValue { get; set; }
            public DateTime? DateValue { get; set; }
            public int NumberValue { get; set; }
            // Agrega más propiedades según sea necesario para otros tipos de controles

            // Constructor para inicializar las propiedades si es necesario
            public FormData()
            {
                TextValue = string.Empty;
                DropdownValue = string.Empty;
                CheckBoxValue = false;
                RadioButtonValue = string.Empty;
                TextAreaValue = string.Empty;
                FileUploadValue = null;
                DateValue = null;
                NumberValue = 0;
                // Inicializa más propiedades según sea necesario
            }
        }

        public FormData GetFormValues()
        {
            FormData formData = new FormData();

            // Recorre los controles en dynamicFieldsPanel y asigna los valores a las propiedades de FormData
            foreach (Control control in dynamicFieldsPanel.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    if (textBox.ID == "txtTextValue")
                    {
                        formData.TextValue = textBox.Text;
                    }
                    // Agrega más condiciones según sea necesario para otros controles de texto
                }
                else if (control is DropDownList)
                {
                    DropDownList dropdown = (DropDownList)control;
                    if (dropdown.ID == "ddlDropdown")
                    {
                        formData.DropdownValue = dropdown.SelectedValue;
                    }
                    // Agrega más condiciones según sea necesario para otros controles desplegables
                }
                else if (control is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)control;
                    if (checkBox.ID == "chkCheckBox")
                    {
                        formData.CheckBoxValue = checkBox.Checked;
                    }
                    // Agrega más condiciones según sea necesario para otros controles CheckBox
                }
                else if (control is RadioButton)
                {
                    RadioButton radioButton = (RadioButton)control;
                    if (radioButton.ID == "rbRadioButton" && radioButton.Checked)
                    {
                        formData.RadioButtonValue = radioButton.Text;
                    }
                    // Agrega más condiciones según sea necesario para otros controles RadioButton
                }
                else if (control is TextBox && control.ClientID.EndsWith("txtTextArea"))
                {
                    TextBox textarea = (TextBox)control;
                    formData.TextAreaValue = textarea.Text;
                }
                else if (control is FileUpload)
                {
                    FileUpload fileUpload = (FileUpload)control;
                    if (fileUpload.HasFile)
                    {
                        formData.FileUploadValue = fileUpload.PostedFile;
                    }
                    // Agrega más condiciones según sea necesario para otros controles FileUpload
                }
                else if (control is TextBox && control.ClientID.EndsWith("txtDate"))
                {
                    TextBox dateTextBox = (TextBox)control;
                    DateTime dateValue;
                    if (DateTime.TryParse(dateTextBox.Text, out dateValue))
                    {
                        formData.DateValue = dateValue;
                    }
                }
                else if (control is TextBox && control.ClientID.EndsWith("txtNumber"))
                {
                    TextBox numberTextBox = (TextBox)control;
                    int numberValue;
                    if (int.TryParse(numberTextBox.Text, out numberValue))
                    {
                        formData.NumberValue = numberValue;
                    }
                }
                // Agrega más casos según los tipos de controles que estés utilizando
            }
            // Puedes devolver el objeto formData o realizar alguna acción adicional con él
            return formData;
        }
        public object paramAccept;
        public delegate void ExternalFunctionAccept(object parameter);
        public event ExternalFunctionAccept OnSubmitAccept;
        public ExternalFunctionAccept FunctionAccept { get; set; }

        public delegate void ExternalFunctionCancel(object parameter);
        public event ExternalFunctionCancel OnSubmitCancel;
        public ExternalFunctionCancel FunctionCancel { get; set; }
        public object paramCancel;
        protected void btnAccpet_Click(object sender, EventArgs e)
        {
            paramAccept = GetFormValues();
            OnSubmitAccept?.Invoke(paramAccept);
            FunctionAccept?.Invoke(paramAccept);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            OnSubmitCancel?.Invoke(paramCancel);
            FunctionCancel?.Invoke(paramCancel);
        }
    }
}