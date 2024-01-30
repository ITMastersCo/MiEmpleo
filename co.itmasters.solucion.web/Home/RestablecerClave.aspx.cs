using System;
using System.Web.UI;
using co.itmasters.solucion.web.Code;
using co.itmasters.solucion.vo;
using co.itmasters.solucion.web.SeguridadService;
using System.Text;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

namespace co.itmasters.solucion.web.Home
{
    public partial class RestablecerClave : System.Web.UI.Page
    {
        private CargaCombos _carga = new CargaCombos();
        private SeguridadServiceClient _Actores;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkRetablecer_Click(object sender, EventArgs e)
        {
            try
            {
                Random r = new Random();
                string a = Convert.ToString(r.Next(999999));
                LblMensajeError.Text = "";
                UsuarioVO _actor = new UsuarioVO();
                _actor.tipoUsuario = Convert.ToInt32(cmbTipPersona.SelectedValue);
                _actor.NumIdentificacion = txtNumIdentificacion.Text;
                _actor.NomUsuario = TxtMail.Text;
                _actor.Token = a;
                _Actores = new SeguridadServiceClient();
                _Actores.RestablecerContrasena(_actor);
                _Actores.Close();
               // inicio.Style["display"] = "block";
                //TxtMail.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", "showModal();", true);

            }
            catch(Exception err)
            {
                LblMensajeError.Text = err.Message.ToString();
            }
            

        }
        protected void lnkValidar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioVO _valida = new UsuarioVO();
                _valida.Token = txtToken.Text;
                _valida.tipoUsuario = Convert.ToInt32(cmbTipPersona.SelectedValue);
                _valida.NumIdentificacion = txtNumIdentificacion.Text;

                _Actores = new SeguridadServiceClient();
                
                 Boolean valido = _Actores.validarToken(_valida);
                _Actores.Close();
                if(valido == true)
                 {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", "CloseModal();", true);
                    divValida.Style["display"] = "none";
                    nuevaClave.Style["display"] = "block";
                    

                 }
                else
                {
                    lbltexto.Text = "El token no es válido o ya cumplio su limite de tiempo, por favor intente nuevamente.";
                    txtToken.Text = "";
                }


            }
            catch (Exception err)
            {
                lbltexto.Text = "Error al generar el token, por favor intente nuevamente.";
                txtToken.Text = "";
            }
        
        }

      
        protected void lnkActualizarPW_Click(object sender, EventArgs e)
        {
            try
            { 
                if (txtPw1.Text == txtPw2.Text)
                {
                    UsuarioVO _restablece = new UsuarioVO();
                    _restablece.pasword1 = GetSHA1(txtPw1.Text);
                    _restablece.pasword2 = GetSHA1(txtPw2.Text);
                    _restablece.tipoUsuario = Convert.ToInt32(cmbTipPersona.SelectedValue);
                    _restablece.NumIdentificacion = txtNumIdentificacion.Text;
                    _Actores = new SeguridadServiceClient();

                    _Actores.ActualizaContrasena(_restablece);
                    _Actores.Close();
                    
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Contraseña actualizada correctamente. " + "');", true);
                    if (cmbTipPersona.SelectedValue == "2")
                    {
                        Response.Redirect("../Home/Login.aspx");
                    }
                    else if (cmbTipPersona.SelectedValue == "1")
                    {
                        Response.Redirect("../Home/LoginEmpresa.aspx");
                    }
                    
                }

                
                // _Actores = new SeguridadServiceClient();
                // Boolean valido = _Actores.validarToken(txtToken.Text);
                // _Actores.Close();
                //if(valido == true)
                // {
                //     txtToken.Text = "";
                //     LnkValidar.Enabled = false;

                // }


            }
            catch (Exception err)
            {

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
    }
}