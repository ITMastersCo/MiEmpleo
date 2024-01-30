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
using System.Web.Services;
using System.Collections.Generic;
using co.itmasters.solucion.web.SeguridadService;
using co.itmasters.solucion.web.PersonaService;
using co.itmasters.solucion.vo;
using co.itmasters.solucion.web.Code;


namespace co.itmasters.solucion.web.Home
{
    public partial class RestaurarClave : PageBase
    {
        /// <summary>
        /// Orden de los eventos disparados.
        /// 1.LoggingIn event
        /// 2.Authenticate event. (Membership.ValidateUser)
        /// Si esta Ok validacion
        /// 3.LoggedIn event
        /// No Ok
        /// 4.LoginError event 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.DivRestaurar.Visible = false;
                this.DivPreguntas.Visible = false;
            }
        }

        private void CargarPreguntas(List<UsuarioVO> _resultado)
        {
            if (_resultado != null)
            {
                if (_resultado[0].numRespuestasIncorrectas == 3)
                {
                    this.DivPreguntas.Visible = false;
                    this.lblError.Text = "Ya ha realizado 3 intentos fallidos. Comuníquese con el colegio para el cambio de clave.";
                }
                else
                {
                    this.rblPregunta1.Items.Clear();
                    this.rblPregunta2.Items.Clear();
                    this.rblPregunta3.Items.Clear();

                    this.lblPregunta1.Text = _resultado[0].desPregunta;
                    this.lblPregunta2.Text = _resultado[1].desPregunta;
                    this.lblPregunta3.Text = _resultado[2].desPregunta;

                    this.hdnIdPregunta1.Value = _resultado[0].idPregunta.ToString();
                    this.hdnIdPregunta2.Value = _resultado[1].idPregunta.ToString();
                    this.hdnIdPregunta3.Value = _resultado[2].idPregunta.ToString();

                    this.rblPregunta1.Items.Add(new ListItem(_resultado[0].respuesta1, "1"));
                    this.rblPregunta1.Items.Add(new ListItem(_resultado[0].respuesta2, "2"));
                    this.rblPregunta1.Items.Add(new ListItem(_resultado[0].respuesta3, "3"));
                   // this.rblPregunta1.Items.Add(new ListItem(_resultado[0].respuesta4, "4"));

                    this.rblPregunta2.Items.Add(new ListItem(_resultado[1].respuesta1, "1"));
                    this.rblPregunta2.Items.Add(new ListItem(_resultado[1].respuesta2, "2"));
                    this.rblPregunta2.Items.Add(new ListItem(_resultado[1].respuesta3, "3"));
                   // this.rblPregunta2.Items.Add(new ListItem(_resultado[1].respuesta4, "4"));

                    this.rblPregunta3.Items.Add(new ListItem(_resultado[2].respuesta1, "1"));
                    this.rblPregunta3.Items.Add(new ListItem(_resultado[2].respuesta2, "2"));
                    this.rblPregunta3.Items.Add(new ListItem(_resultado[2].respuesta3, "3"));
                   // this.rblPregunta3.Items.Add(new ListItem(_resultado[2].respuesta4, "4"));

                    if (_resultado[0].valorRespuesta1 == 1)
                    {
                        this.hdnRespuestaPregunta1.Value = "1";
                    }
                    else if (_resultado[0].valorRespuesta2 == 1)
                    {
                        this.hdnRespuestaPregunta1.Value = "2";
                    }
                    else if (_resultado[0].valorRespuesta3 == 1)
                    {
                        this.hdnRespuestaPregunta1.Value = "3";
                    }
                    //else if (_resultado[0].valorRespuesta4 == 1)
                    //{
                    //    this.hdnRespuestaPregunta1.Value = "4";
                    //}

                    if (_resultado[1].valorRespuesta1 == 1)
                    {
                        this.hdnRespuestaPregunta2.Value = "1";
                    }
                    else if (_resultado[1].valorRespuesta2 == 1)
                    {
                        this.hdnRespuestaPregunta2.Value = "2";
                    }
                    else if (_resultado[1].valorRespuesta3 == 1)
                    {
                        this.hdnRespuestaPregunta2.Value = "3";
                    }
                    //else if (_resultado[1].valorRespuesta4 == 1)
                    //{
                    //    this.hdnRespuestaPregunta2.Value = "4";
                    //}

                    if (_resultado[2].valorRespuesta1 == 1)
                    {
                        this.hdnRespuestaPregunta3.Value = "1";
                    }
                    else if (_resultado[2].valorRespuesta2 == 1)
                    {
                        this.hdnRespuestaPregunta3.Value = "2";
                    }
                    else if (_resultado[2].valorRespuesta3 == 1)
                    {
                        this.hdnRespuestaPregunta3.Value = "3";
                    }
                    //else if (_resultado[2].valorRespuesta4 == 1)
                    //{
                    //    this.hdnRespuestaPregunta3.Value = "4";
                    //}

                    this.DivPreguntas.Visible = true;

                    this.lnkBuscarPreguntas.Enabled = false;
                    this.txtNombreUsuario.Enabled = false;

                    Int32 numIntentosRestantes = 3 - _resultado[0].numRespuestasIncorrectas;

                    if (_resultado[0].numRespuestasIncorrectas > 0)
                    {
                        this.lblError.Text = "Recuerde que solo tiene " + numIntentosRestantes.ToString() + " Intentos más";
                    }
                }
            }
            else
            {
                this.DivPreguntas.Visible = false;
                this.lblError.Text = "No se encontraron preguntas. por favo contacte con el administrador";
            }
        }

        protected void lnkBuscarPreguntas_Click(object sender, EventArgs e)
        {
            try
            {
                // Cargamos los datos de acuerdo con los parametros seleccionados
                SeguridadServiceClient _SeguridadService = null;
                UsuarioVO _persona = new UsuarioVO();
                _persona.NomUsuario = this.txtNombreUsuario.Text;
                _SeguridadService = new SeguridadServiceClient();
                List<UsuarioVO> _resultado = _SeguridadService.buscarPreguntas(_persona).ToList<UsuarioVO>();
                _SeguridadService.Close();
                if (_resultado != null)
                {
                    CargarPreguntas(_resultado);
                    this.rblPregunta1.Enabled = true;
                    this.rblPregunta2.Enabled = true;
                    this.rblPregunta3.Enabled = true;
                    this.lnkEnviarRespuestas.Enabled = true;
                }
            }
            catch (Exception err)
            {
                this.lblError.Text = err.Message;
            }
        }

        protected void lnkEnviarRespuestas_Click(object sender, EventArgs e)
        {
            try
            {
                if (rblPregunta1.SelectedItem == null || rblPregunta2.SelectedItem == null || rblPregunta3.SelectedItem == null)
                {
                    this.lblError.Text = "Por favor, Seleccione por lo menos una opción en cada pregunta";
                }
                else
                {
                    SeguridadServiceClient _SeguridadService = null;
                    UsuarioVO _persona = new UsuarioVO();
                    _persona.NomUsuario = this.txtNombreUsuario.Text;

                    _persona.idPregunta1Retornar = Convert.ToInt32(this.hdnIdPregunta1.Value);
                    _persona.idPregunta2Retornar = Convert.ToInt32(this.hdnIdPregunta2.Value);
                    _persona.idPregunta3Retornar = Convert.ToInt32(this.hdnIdPregunta3.Value);

                    //_persona.idPregunta1Retornar = Convert.ToInt32(this.hdnIdPregunta1.Value);
                    //_persona.idPregunta2Retornar = Convert.ToInt32(this.hdnIdPregunta2.Value);
                    //_persona.idPregunta3Retornar = Convert.ToInt32(this.hdnIdPregunta3.Value);

                    _persona.respuesta1 = rblPregunta1.SelectedItem.Text;
                    _persona.respuesta2 = rblPregunta2.SelectedItem.Text;
                    _persona.respuesta3 = rblPregunta3.SelectedItem.Text;

                    if (rblPregunta1.SelectedValue == this.hdnRespuestaPregunta1.Value)
                        _persona.valorRespuesta1 = 1;
                    else
                        _persona.valorRespuesta1 = 0;

                    if (rblPregunta2.SelectedValue == this.hdnRespuestaPregunta2.Value)
                        _persona.valorRespuesta2 = 1;
                    else
                        _persona.valorRespuesta2 = 0;

                    if (rblPregunta3.SelectedValue == this.hdnRespuestaPregunta3.Value)
                        _persona.valorRespuesta3 = 1;
                    else
                        _persona.valorRespuesta3 = 0;



                    _SeguridadService = new SeguridadServiceClient();
                    List<UsuarioVO> _resultado = _SeguridadService.EnviarRespuestas(_persona).ToList<UsuarioVO>();
                    _SeguridadService.Close();


                    if (_resultado[0].resultadoEnvioRespuestas == 1)
                    {
                        this.DivRestaurar.Visible = true;
                        this.lblError.ForeColor = System.Drawing.Color.Green;
                        this.lblError.Text = "Sus respuestas han sido correctas; Ingrese su nueva clave";
                        this.rblPregunta1.Enabled = false;
                        this.rblPregunta2.Enabled = false;
                        this.rblPregunta3.Enabled = false;
                        this.lnkEnviarRespuestas.Enabled = false;
                    }
                    else
                    {
                        CargarPreguntas(_resultado);
                    }
                }
            }
            catch (Exception err)
            {
                this.lblError.Text = err.Message;
            }
        }

        protected void lnkRestaurarClave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtClave.Text == TxtConfirmacion.Text)
                {
                    lblError.Visible = false;
                    PersonaServiceClient _funcionarioservice;
                    FuncionarioVO _funcionario = new FuncionarioVO();
                    _funcionario.Usuario = txtNombreUsuario.Text;
                    _funcionario.ClaveActual = "-111";
                    _funcionario.ClaveNueva = this.txtClave.Text;

                    _funcionarioservice = new PersonaServiceClient();
                    _funcionarioservice.Guardar_CambiarClave(_funcionario);
                    _funcionarioservice.Close();
                    this.hdnAlert.Value = "1";
                }
                else
                {
                    lblError.Text = "Confirmacion contraseña incorrecta, intentelo nuevamente.";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    txtClave.Text = null;
                    TxtConfirmacion.Text = null;
                    lblError.Visible = true;
                }

                
            }
            catch (Exception err)
            {
                this.lblError.Text = err.Message;
            }
        }


        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (this.hdnAlert.Value == "1")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Prueba",
                    "window.location.replace('../Index.aspx'); alert('Clave actualizada con éxito'); ", true);
            }
        }

    }
}
