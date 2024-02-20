using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using co.itmasters.solucion.web.Code;
using co.itmasters.solucion.web.ComunesService;

namespace co.itmasters.solucion.web.Administracion
{
    public partial class DetallePagina : PageBase
    {
        
        private ComunesServiceClient _comunesService;
        protected CargaCombos _carga = new CargaCombos();
        private DropDownList[] _combos;

        //Propiedad usada para aplicar filtros de admon
        private Boolean ConFiltro = false;

        //Propiedades para abrir la ventana Modal.
        private string Titulo;
        private int Alto;
        private int Ancho;
        private UserVO user;


        protected void Page_Load(object sender, EventArgs e)
        {

            //_comunesService = new ComunesServiceClient();
            user = ((UserVO)Session["UsuarioAutenticado"]);
            
            if (!Page.IsPostBack)
            {
                CargarComboPaginas();
                Session["Padre"] = "-1";
                Session["Padres"] = null;
            }

            //Si no llega parametro, muestra el combo de items.
            if (Request.QueryString["Seleccion"] != null)
            {
                uConsulta.Visible = false;
                cmbTipo.SelectedValue = Request.QueryString["Seleccion"];
            }

            CrearControlesPagina();
        }

        protected void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {         
            grvDatos.DataSource = null;
            grvDatos.DataBind();

            if (cmbTipo.SelectedIndex > 0)
                CrearControlesPagina();
            else
                pAlma.Visible = false;
        }
        /**
         * Metodo que se encarga de crear los controles que se necesitan en la pagina.
         **/
        private void CrearControlesPagina()
        {
            if (cmbTipo.SelectedIndex > 0)
            {
                //Cargamos la pagina del item seleccionado en el combo
                AdminVO lsi = this.CargaLista().Where(p => p.Valor == cmbTipo.SelectedValue).First();

                //Parametros para utilizar el tamanio de la ventana
                ConFiltro = lsi.ConFiltro;
                Titulo = lsi.Titulo;
                Alto = lsi.Alto;
                Ancho = lsi.Ancho;

                //Si No hay filtros para la pagina seleccionada, traemos todos los datos.
                if (lsi.Filtro.Count > 0)
                {
                    //Si HAY filtros, solo habilitamos el Div del filtro y cargamos los filtros.
                    pAlma.Visible = true;
                    this.CrearyCargarFiltros(lsi.Filtro);
                }
                else
                {
                    //Si no Hay filtros solicitamos actualizar la grilla con la info.
                    pAlma.Visible = false;
                    ActualizaDatos(-1);
                }
            }
        }


        protected void grvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Actualizamos la grilla de datos, y nos ubicamos en la pagina seleccionada.
            ActualizaDatos(e.NewPageIndex);
        }

        protected void grvDatos_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
                e.Row.Cells[1].Visible = false;
        }

        /**
         * Metodo que Cargar el Combo inicial donde aparecen las tablas que pueden ser administradas
         * 
         * */
        protected void CargarComboPaginas()
        {
            _carga.Cargar(cmbTipo, this.CargaLista());
        }

        protected List<AdminVO> CargaLista()
        {
            String ruta = Request.PhysicalApplicationPath + "Administracion\\XML\\Administracion.xml";
            PantallaDinamica repNeg = new PantallaDinamica(ruta);
            return repNeg.LeerAdministracion();
        }

        protected void CrearyCargarFiltros(List<FiltroMantenimientoVO> lisMan)
        {
            _combos = new DropDownList[lisMan.Count];

            pFiltro.Controls.Clear();
            pFiltro.Controls.Add(new LiteralControl("<div id=\"DivFiltro1\" style=\"width: 100%\">"));
            List<string> padres = new List<string>();
            for (int i = 0; i < lisMan.Count; i++)
            {               
                pFiltro.Controls.Add(new LiteralControl("<h3 class=\"text-normal  text-highlighted\">"));
                Label etiqueta = new Label();
                etiqueta.Width = 40;
                etiqueta.Text = lisMan[i].Label;
                etiqueta.ID = "lblEtiqueta_" + i.ToString();
                pFiltro.Controls.Add(etiqueta);
                pFiltro.Controls.Add(new LiteralControl("</h3><div id=\"DivFiltro1\" style=\"width: 100%\">"));

                DropDownList paramFil = new DropDownList();
                paramFil.ID = lisMan[i].Param;
                paramFil.Style["Width"] = "50%";
                paramFil.CssClass = "drop-down-list";
                paramFil.AutoPostBack = true;


                //Verificamos si hay que enviarle codigo del colegio para cargar el combo del filtro
                if (lisMan[i].FiltroColegio)
                {
                    _carga.Cargar(paramFil, lisMan[i].Combo, "1");
                }
                else if (lisMan[i].Padre != "")
                {
                    DropDownList comp = new DropDownList();
                    for (int a = 0; a < _combos.Count(); a++)
                    {
                        if (_combos[a] != null)
                        {
                            if (_combos[a].ID == lisMan[i].Padre)
                            {
                                comp = _combos[a];
                            }
                        }
                    }
                    padres.Add("-1");
                    _carga.Cargar(paramFil, lisMan[i].Combo, Session["Padre"].ToString());
                }
                else
                {
                    _carga.Cargar(paramFil, lisMan[i].Combo);
                }

                _combos[i] = paramFil;

                paramFil.SelectedIndexChanged += new EventHandler(cmb_SelectedIndexChanged);
                pFiltro.Controls.Add(paramFil);
                //pFiltro.Controls.Add(new LiteralControl("</h3>"));

            }
            if (Session["Padres"] == null)
            {
                Session["Padres"] = padres.ToArray();
            }
            pFiltro.Controls.Add(new LiteralControl("</div>"));
        }

        protected void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {            
            this.ActualizaDatos(-1);
            //Cargamos la pagina del item seleccionado en el combo
            AdminVO lsi = this.CargaLista().Where(p => p.Valor == cmbTipo.SelectedValue).First();
            
            //Si No hay filtros para la pagina seleccionada, traemos todos los datos.
            if (lsi.Filtro.Count > 0)
            {
                this.CargarCombosConPadres(lsi.Filtro);
            }
        }

        protected void CargarCombosConPadres(List<FiltroMantenimientoVO> lisMan)
        {
            DropDownList compCarga = new DropDownList();
            DropDownList compValor = new DropDownList();
            string[] arregloPadres = (string[])Session["Padres"];
            int index = 0;
            for (int i = 0; i < lisMan.Count; i++)
            {
                if (lisMan[i].Padre != "")
                {
                    for (int a = 0; a < _combos.Count(); a++)
                    {
                        if (_combos[a].ID == lisMan[i].Param)
                        {
                            compCarga = _combos[a];
                        }
                    }

                    for (int a = 0; a < lisMan.Count; a++)
                    {
                        if (lisMan[i].Padre == lisMan[a].Param)
                        {
                            for (int b = 0; b < _combos.Count(); b++)
                            {
                                if (_combos[b].ID == lisMan[a].Param)
                                {
                                    compValor = _combos[b];
                                }
                            }
                        }
                    }

                    //AdminVO lsi = this.CargaLista().Where(p => p.Valor == cmbTipo.SelectedValue).First();
                    string ValorSeleccionado = compCarga.SelectedValue;
                    if (arregloPadres[index] != compValor.SelectedValue)
                    {
                        ValorSeleccionado = "-1";
                        arregloPadres[index] = compValor.SelectedValue;
                    }
                    _carga.Cargar(compCarga, lisMan[i].Combo, compValor.SelectedValue);
                    compCarga.SelectedValue = ValorSeleccionado;
                }
            }
            Session["Padres"] = arregloPadres;
        }


        protected void ActualizaDatos(int PageIndex)
        {
            if (_combos != null)
            {
                DropDownList comp;
                String sqlFiltro = " ";

                for (int i = 0; i < _combos.Count(); i++)
                {
                    comp = _combos[i];
                    if (!comp.SelectedValue.Equals("-1"))
                    {
                        sqlFiltro += " AND " + comp.ID + " = " + comp.SelectedValue;
                        Session["Padre"] = comp.SelectedValue;
                    }

                }

                String[] param = new String[2];
                param[0] = "1"; /*user.IdColegio.ToString();*/
                param[1] = sqlFiltro;

                grvDatos.DataSource = null;
                _comunesService = new ComunesServiceClient();
                grvDatos.DataSource = _comunesService.ObtenerListaTablaFiltros(cmbTipo.SelectedValue, param);
                //Cerrar el servicio.
                _comunesService.Close();
                grvDatos.PageIndex = (PageIndex == -1) ? grvDatos.PageIndex : PageIndex;
                grvDatos.DataBind();
            }
            else
            {
                grvDatos.DataSource = null;
                _comunesService = new ComunesServiceClient();
                grvDatos.DataSource = _comunesService.ObtenerListaTablaFiltro(cmbTipo.SelectedValue, "1");
                //Cerrar el servicio.
                _comunesService.Close();
                grvDatos.PageIndex = (PageIndex == -1) ? grvDatos.PageIndex : PageIndex;
                grvDatos.DataBind();
            }
        }

        protected void OnSelectRow(object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals("Select"))
            {
                Int32 val = Convert.ToInt32(e.CommandArgument);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", "escribirLinkDimen('../Administracion/DetalleRegistro.aspx?Tipo=Edita&Administracion=" + cmbTipo.SelectedValue + "&ID=" + val.ToString() + "', " + Alto + "," + Ancho + ", '" + Titulo + "');", true);
              
            }
        }

        protected void imgNuevo_Click(object sender, ImageClickEventArgs e)
        {
            if (cmbTipo.SelectedIndex >0)
            {
                 ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", "escribirLinkDimen('../Administracion/DetalleRegistro.aspx?Tipo=Inserta&Administracion=" + cmbTipo.SelectedValue + "&ID=0', " + Alto + "," + Ancho + ", '" + Titulo + "');", true);
            }
        }

        protected void btnRecalcular_Click(object sender, EventArgs e)
        {
            this.ActualizaDatos(-1);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", $"closeEmergente('simplemodal-overlay')", true);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", $"closeEmergente('simplemodal-container')", true);
        }
    }
}
