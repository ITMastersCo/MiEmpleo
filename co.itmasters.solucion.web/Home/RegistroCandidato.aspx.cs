using co.itmasters.solucion.vo;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using co.itmasters.solucion.web.Code;
using System.Security.Cryptography;
using System.Text;
using co.itmasters.solucion.web.SeguridadService;
using CsvHelper;
using System;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web.Configuration;

namespace co.itmasters.solucion.web.Home
{
   
    public partial class RegistroCandidato : System.Web.UI.Page
    {
        private SeguridadServiceClient _Actores;
        private CargaCombos _carga = new CargaCombos();
        protected string SiteKeyCaptcha = ConfigurationManager.AppSettings["SiteKeyCaptcha"];
        protected string UrlTerminos = ConfigurationManager.AppSettings["UrlTerminos"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                _carga.Cargar(cmbTipoIde, TipoCombo.CMBTIPIDENTIFICACION);
            }
        }
        private bool IsReCaptchValid()
        {
            var result = false;
            var captchaResponse = Request.Form["g-recaptcha-response"];
            var secretKey = ConfigurationManager.AppSettings["SecretKeyCaptcha"];
            var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
            var requestUri = string.Format(apiUrl, secretKey, captchaResponse);
            var request = (HttpWebRequest)WebRequest.Create(requestUri);

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    JObject jResponse = JObject.Parse(stream.ReadToEnd());
                    var isSuccess = jResponse.Value<bool>("success");
                    result = (isSuccess) ? true : false;
                }
            }
            return result;
        }

        protected void lnkRegistro_Click(object sender, EventArgs e)
        {
            if (IsReCaptchValid())
            {
                try


                {
                    Random r = new Random();

                    string a = Convert.ToString(r.Next(999999));
                    lblError.Text = "";
                    lblError.Visible = false;
                    if (chkConditions.Checked == true)
                    {
                        UsuarioVO _registro = new UsuarioVO();
                        _registro.NumIdentificacion = (txtNumIdentificacion.Text);
                        _registro.NomUsuario = (TxtEmail.Text);
                        _registro.tipoUsuario = 2;
                        _registro.Token = a;
                        //_registro.pasword1 = GetSHA1(txtPassword.Text);
                        //_registro.pasword2 = GetSHA1(TxtPassword2.Text);
                        _Actores = new SeguridadServiceClient();
                        _Actores.RegistroUsuarioTokenEmpresa(_registro);
                        _Actores.Close();

                        openModal.Style["display"] = "block";
                        lnkRegistroValida.Enabled = false;
                        divCapcha.Visible = false;
                        

                    }
                    else
                    {
                        lblError.Text = "Por favor acepte las condiciones.";
                        lblError.Visible = false;
                    }

                }
                catch (Exception err)
                {
                    lblError.Text = err.Message.ToString();
                    lblError.Visible = true;
                }
            }
            else
            {
                lblError.Text = "Por favor valide el captcha.";
                lblError.Visible = true;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", "onloadCallback();", true);
            }

        }

        protected void lnkAutRegistro_Click(object sender, EventArgs e)
        {

            try

            {
                {

                    lblError.Text = "";
                    lblError.Visible = false;
                    if (txtPassword.Text == TxtPassword2.Text && chkConditions.Checked == true)
                    {
                        UsuarioVO _registro = new UsuarioVO();
                        _registro.TipIdentificacion = Convert.ToInt32(cmbTipoIde.SelectedValue);
                        _registro.NumIdentificacion = (txtNumIdentificacion.Text);
                        _registro.tipoUsuario = 2;
                        _registro.NomUsuario = (TxtEmail.Text);
                        _registro.pasword1 = GetSHA1(txtPassword.Text);
                        _registro.pasword2 = GetSHA1(TxtPassword2.Text);
                        _Actores = new SeguridadServiceClient();
                        _Actores.RegistroUsuarioCandidato(_registro);
                        _Actores.Close();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", "confirmaRegistro();", true);
                        txtPassword.Text = "";
                        TxtPassword2.Text = "";
                    }
                    else
                    {
                        lblError.Text = "Por favor valide todos los campos obligatorios.";
                        lblError.Visible = true;
                    }
                }

            }
            catch (Exception err)
            {
                lblError.Text = err.Message.ToString();
                lblError.Visible = true;
            }


        }

        public static string GetSHA1(string str)
        {
            SHA1 sha1 = SHA1Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha1.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
        protected void lnkValidar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioVO _valida = new UsuarioVO();
                _valida.Token = txtToken.Text;
                _valida.tipoUsuario = 0;
                _valida.NumIdentificacion = txtNumIdentificacion.Text;

                _Actores = new SeguridadServiceClient();

                Boolean valido = _Actores.validarToken(_valida);
                _Actores.Close();
                if (valido == true)
                {
                    openModal.Style["display"] = "none";
                    lnkRegistro.Enabled = true;
                    lnkRegistro.Visible = true;
                    lnkRegistroValida.Visible = false;
                    lnkRegistroValida.Enabled = false;
                    divClave.Style["display"] = "block";
                    cmbTipoIde.Enabled = false;
                    TxtEmail.Enabled = false;
                    txtNumIdentificacion.Enabled = false;
                }
                else
                {
                    lblError.Text = "El token no es válido o ya cumplio su limite de tiempo, por favor intente nuevamente.";
                    txtToken.Text = "";
                    lblError.Visible = true;
                }
            }
            catch (Exception err)
            {
                lblError.Text = "Error al generar el token, por favor intente nuevamente.";
                txtToken.Text = "";
                lblError.Visible = true;
            }

        }
    }
}