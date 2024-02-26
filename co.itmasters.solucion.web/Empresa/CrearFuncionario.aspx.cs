using co.itmasters.solucion.vo;
using co.itmasters.solucion.web.Code;
using co.itmasters.solucion.web.SeguridadService;
using CrystalDecisions.ReportAppServer.CommonControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace co.itmasters.solucion.web.Empresa
{
    public partial class CrearFuncionario : PageBase
    {
        private UserVO user;
        private SeguridadServiceClient _Actores;
        private CargaCombos _cargaCombos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                user = ((UserVO)Session["UsuarioAutenticado"]);
                CargarCombos();
                
                
            }
        }
        private void CargarCombos()
        {
            _cargaCombos = new CargaCombos();
            _cargaCombos.Cargar(cmbRol, TipoCombo.CMBROLESEMPRESA);
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
                _valida.tipoUsuario = 4;
                _valida.NomUsuario = txtCorreo.Text;

                _Actores = new SeguridadServiceClient();

                Boolean valido = _Actores.validarToken(_valida);
                _Actores.Close();
                if (valido == true)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", $"CloseModal('{valida.ClientID}', '{openModal.ClientID}')", true);
                    btnCrearFuncionario.Enabled = true;
                    btnCrearFuncionario.Visible = true;
                    btnValidaCorreo.Visible = false;
                    btnValidaCorreo.Enabled = false;
                    divClave.Attributes["class"] = divClave.Attributes["class"].Replace("hidden", "");
                    txtCorreo.Enabled = false;
                    txtNombre.Enabled = false;
                    cmbRol.Enabled = false;
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

        protected void btnValidaCorreo_Click(object sender, EventArgs e)
        {
            try


            {
                Random r = new Random();

                string a = Convert.ToString(r.Next(999999));
                lblError.Text = "";
                lblError.Visible = false;

                UsuarioVO _registro = new UsuarioVO();
                _registro.NomUsuario = (txtCorreo.Text);
                _registro.tipoUsuario = 2;
                _registro.Token = a;
                //_registro.pasword1 = GetSHA1(txtPassword.Text);
                //_registro.pasword2 = GetSHA1(txtPassword2.Text);
                _Actores = new SeguridadServiceClient();
                _Actores.RegistroUsuarioTokenEmpresa(_registro);
                _Actores.Close();

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", $"OpenModal('{valida.ClientID}','{openModal.ClientID}')", true);

                btnValidaCorreo.Enabled = false;



            }
            catch (Exception err)
            {
                lblError.Text = err.Message.ToString();
                lblError.Visible = true;
            }


        }


        protected void btnCrearFuncionario_Click(object sender, EventArgs e)
        {
            try

            {
                {

                    lblError.Text = "";
                    lblError.Visible = false;
                    if (txtPassword.Text == txtPassword2.Text)
                    {
                        user = ((UserVO)Session["UsuarioAutenticado"]);
                        UsuarioVO _registro = new UsuarioVO();
                        _registro.IdUsuario = user.IdUsuario;
                        _registro.tipoUsuario = 4;
                        _registro.NombreCompleto = txtNombre.Text;
                        _registro.NomUsuario = (txtCorreo.Text);
                        _registro.idRol = Convert.ToInt32(cmbRol.SelectedValue);
                        _registro.pasword1 = GetSHA1(txtPassword.Text);
                        _registro.pasword2 = GetSHA1(txtPassword2.Text);
                        _Actores = new SeguridadServiceClient();
                        _Actores.RegistroUsuarioFuncionario(_registro);
                        _Actores.Close();

                        txtPassword.Text = "";
                        txtPassword2.Text = "";
//                        Response.Redirect("../Home/Login.aspx");
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", "showModal();", true);

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
        protected void btnCloseModal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", $"CloseModal('{valida.ClientID}', '{openModal.ClientID}')", true);
        }
    }
}