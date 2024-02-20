using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using co.itmasters.solucion.web.Code;
using co.itmasters.solucion.web.ComunesService;
using co.itmasters.solucion.vo;
using Microsoft.Ajax.Utilities;

namespace co.itmasters.solucion.web.Administracion
{
    public partial class DetalleRegistro : PageBase
    {
        private ComunesServiceClient _comunesService;
        protected CargaCombos _carga = new CargaCombos();
        private List<ComponenteVO> _listaObejtos;
        private Hashtable lstDropDownList;
        private ReporteVO _reporteParam;
        private UserVO user;
        
        //Objeto temporal para buscar los Id de los padres para el refresco.
        private String tipo;
        private String _procedimiento;
        private String _lista;
        private Int32 filtro;
        private DataTable valorConsulta;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void Page_Init(Object sender, System.EventArgs e) 
        {
            user = ((UserVO)Session["UsuarioAutenticado"]);

            String ruta = Request.PhysicalApplicationPath + "Administracion\\XML\\" + Request.QueryString["Administracion"] + ".xml";
            tipo = Request.QueryString["Tipo"];
            filtro = Int32.Parse(Request.QueryString["ID"]);
            _procedimiento = "sp" + Request.QueryString["Administracion"];
            _lista = Request.QueryString["Administracion"] + "_Id";

            PantallaDinamica repoNegocio = new PantallaDinamica(ruta);
            _reporteParam = repoNegocio.LeeParametros("Admin");
            _listaObejtos = repoNegocio.LeerComponentes();
            chkEstado.Visible = lblEstado.Visible = repoNegocio.RevisarEstado(); ;

            //Construye la forma con todos los componentes.
            this.ConstruyeForma();
        }

        private void ConstruyeForma()
        {
            lblTitulo.Text = _reporteParam.Titulo;
            lblSubtitulo.Text = _reporteParam.SubTitulo;
            List<ComponenteVO> lstCombo = _listaObejtos.Where(p => p.Tipo == "Combo").ToList();

            //Si existen componentes los pintamos.
            if (_listaObejtos.Count > 0)
            {
                pFiltros.Controls.Add(new LiteralControl("<table width=100% cellpadding=\"2px\">"));
                lstDropDownList = new Hashtable();
                //Pintar Componentes
                PintarComponentes();
                this.CargaCombos(lstCombo);

                pFiltros.Controls.Add(new LiteralControl("</table>"));

                if (tipo.Equals("Edita"))
                {
                    _comunesService = new ComunesServiceClient();
                    valorConsulta = _comunesService.ObtenerListaTablaFiltro(_lista, Convert.ToString(filtro));
                    //Cerrar el servicio.
                    _comunesService.Close();
                    //valorConsulta = comunes.ObtenerListaTabla(_lista, Convert.ToString(filtro));
                    CargaInformacion(valorConsulta.Rows[0]);
                }
            }
        }

        public void PintarComponentes()
        {
            ComponenteVO item;
            List<TextBox> fechas = new List<TextBox>();

            for (int i = 0; i < _listaObejtos.Count; i++)
            {
                //Se obtiene el componente
                item = _listaObejtos[i];
                //pFiltros.Controls.Add(new LiteralControl("<tr class=\"modo1\"><td style=\"width: 30%;\" align=\"Left\">"));

                //Si se trata de una caja de Texto.
                if (item.Tipo.Equals("CajaAmplia") || item.Tipo.Equals("Caja") || item.Tipo.Equals("Fecha"))
                {
                    pFiltros.Controls.Add(new LiteralControl("<tr><td style=\"width: 30%;\" align=\"Left\">"));
                    Boolean amplia = item.Tipo.Equals("CajaAmplia") ? true : false;
                    Label etiqueta = new Label();
                    //etiqueta.Font.Size = 10;
                    etiqueta.Text = item.Texto;
                    pFiltros.Controls.Add(etiqueta);
                 

                    pFiltros.Controls.Add(new LiteralControl("</td><td style=\"width: 70%;\" align=\"Left\" >"));

                    TextBox textoFiltro = new TextBox();
                    textoFiltro.CssClass = "text-box";
                    //Tamaniio de la Caja de Texto, si no se define en el XML llega 0.
                    if(item.Tamano > 0)
                        textoFiltro.MaxLength = item.Tamano;

                    if (amplia)
                    {
                        textoFiltro.Style["width"] = "80%";
                        textoFiltro.TextMode = TextBoxMode.MultiLine;
                        textoFiltro.Height = Unit.Pixel(80);
                    }
                    else
                    {
                        textoFiltro.Style["width"] = "90%";
                    }

                    //Si esta deshabilitada para editar, se cambio y no se deja pegar.
                    if (tipo.Equals("Edita") && !item.EnableEdicion)
                    {
                        textoFiltro.Enabled = false;
                    }

                    //Si se trata de adicionar, y no esta habilitada para edicion, no se muestra
                    else if (tipo.Equals("Inserta") && !item.EnableEdicion)
                    {
                        textoFiltro.Visible = false;
                        etiqueta.Visible = false;
                    }

                    //Adicionamos las cajas de tipo fecha en una coleccion.
                    if(item.Tipo.Equals("Fecha"))
                        fechas.Add(textoFiltro);

                    textoFiltro.ID = item.Parametro;
                    pFiltros.Controls.Add(textoFiltro);
                    //lstTextoFiltro.Add(item.Parametro, textoFiltro);


                    if (item.Requerido)
                    {
                        RequiredFieldValidator validador = new RequiredFieldValidator();
                        validador.CssClass = "required-field-validator";
                        validador.ID = "RFV" + textoFiltro.ID;
                        validador.SetFocusOnError = true;
                        validador.Enabled = true;
                        validador.Style["Width"] = "10%";
                        //validador.ValidationGroup = "Exportar";
                        validador.Text = "<img alt=\"\" src=\"" + this.UrlBasePath() + "Images/exclamation.gif\" />";
                        validador.ControlToValidate = textoFiltro.ID;
                        pFiltros.Controls.Add(validador);
                    }

                    if (item.Busqueda != String.Empty)
                    {
                        ImageButton imgBusqueda = new ImageButton();
                        imgBusqueda.ImageUrl = this.UrlBasePath() + "Images/Buscar.gif";
                        imgBusqueda.ToolTip = "Busqueda avanzada";
                        imgBusqueda.ID = "img" + item.Parametro;
                        imgBusqueda.Width = 20;
                        imgBusqueda.Height = 20;
                        imgBusqueda.Click += new ImageClickEventHandler(this.Calculate);
                        pFiltros.Controls.Add(imgBusqueda);
                    }

                    pFiltros.Controls.Add(new LiteralControl("</td></tr>"));

                    

                }
                else if (item.Tipo.Equals("Combo"))
                {
                    pFiltros.Controls.Add(new LiteralControl("<tr class=\"modo1\"><td style=\"width: 12%;\" align=\"Left\">"));

                    Label etiqueta = new Label();
                    
                    etiqueta.Text = item.Texto;
                    pFiltros.Controls.Add(etiqueta);
                    
                  
                    pFiltros.Controls.Add(new LiteralControl("</td><td style=\"width: 88%;\" align=\"Left\" >"));

                    DropDownList filtro = new DropDownList();
                    filtro.CssClass = "drop-down-list";
                    filtro.ID = item.Parametro;
                    filtro.Style["width"] = "90%";

                    if (item.Padres[0].Padre == String.Empty)
                    {
                        filtro.AutoPostBack = false;
                    }
                    else
                    {
                        filtro.AutoPostBack = true;
                        filtro.SelectedIndexChanged += new EventHandler(filtro_SelectedIndexChanged);
                    }
                    lstDropDownList.Add(item.Parametro, filtro);
                    pFiltros.Controls.Add(filtro);

                    //Si esta deshabilitada para editar, se cambio y no se deja pegar.
                    if (tipo.Equals("Edita") && !item.EnableEdicion)
                    {
                        filtro.Enabled = false;
                    }

                    //Si se trata de adicionar, y no esta habilitada para edicion, no se muestra
                    else if (tipo.Equals("Inserta") && !item.EnableEdicion)
                    {
                        filtro.Visible = false;
                        etiqueta.Visible = false;
                    }


                    if (item.Requerido)
                    {
                        RequiredFieldValidator validador = new RequiredFieldValidator();
                        validador.CssClass = "required-field-validator";
                        validador.ID = "RFV" + filtro.ID;
                        validador.CssClass = "required-field-validator";
                        validador.InitialValue = "-1";
                        validador.Enabled = true;
                        validador.SetFocusOnError = true;
                        //validador.ValidationGroup = "Exportar";
                        validador.Style["Width"] = "10%";
                        validador.ControlToValidate = filtro.ID;
                        pFiltros.Controls.Add(validador);
                    }

                    pFiltros.Controls.Add(new LiteralControl("</td></tr>"));
                }
            }

            //Cargar Fechas
            cargarFechas(fechas);
        }

        private void cargarFechas(List<TextBox> fechas) 
        {
            string varJs = "$(document).ready(function(){";
            foreach(var item in fechas)
            {
                //Asociamos el script a las cajas de fecha
                varJs += "DesplegaCalendar('#" + item.ID + "');";
            }
            varJs += "});";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Generar", varJs, true);
        }
        
        protected void filtro_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList cbActual = sender as DropDownList;

            //Objecto que representa el combo
            ComponenteVO compActual = (ComponenteVO)_listaObejtos.Where(p => p.Parametro == cbActual.ID).First();

            if (!compActual.Padres[0].Padre.Equals(String.Empty))
            {
                //Objecto Hijo del elemento Anterior
                ComponenteVO compHijo = (ComponenteVO)_listaObejtos.Where(p => p.Parametro == compActual.Padres[0].Padre).First();
                DropDownList cbHijo = (DropDownList)lstDropDownList[compActual.Padres[0].Padre];
                
                //Si se selecciono un item del elemento actual, actualizo su hijo
                if (!cbActual.SelectedValue.Equals("-1"))
                {
                    _carga.Cargar(cbHijo, compHijo.Tabla, cbActual.SelectedValue);
                }
                else
                {
                    _carga.CargarVacio(cbHijo);
                }
            }
        }

        public void CargaCombos(List<ComponenteVO> lstCombo)
        {
            DropDownList cb;
            Int32 i = 0;

            foreach (ComponenteVO item in lstCombo)
            {
                cb = (DropDownList)lstDropDownList[item.Parametro];
                i++;
                if (item.Hijo == String.Empty)
                {
                    if(item.FiltroColegio)
                        _carga.Cargar(cb, item.Tabla, "1");
                    else
                        _carga.Cargar(cb, item.Tabla);
                }
                else
                {
                    _carga.CargarVacio(cb);
                }
            }
        }

        protected void Calculate(object sender, System.EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            String varNombre = btn.ID.Replace("img", "");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", "escribirLinkDimen('../Comunes/AlumnoBuscar.aspx?Tipo=Codigo&Valor=ctl00_Main_" + varNombre + "&TipoDoc=null', 400,600, 'Buscar Alumno');", true);
        }

        protected void CargaInformacion(DataRow dr)
        {
            if (!Page.IsPostBack)
            {
                if (dr != null)
                {
                    ControlCollection listacontroles = pFiltros.Controls;
                    foreach (Control item in listacontroles)
                    {
                        if (item is TextBox)
                        {
                            ((TextBox)item).Text = dr[((TextBox)item).ID].ToString();
                        }
                        else if (item is DropDownList)
                        {
                            ComponenteVO h = (ComponenteVO)_listaObejtos.Where(p => p.Tipo == "Combo" && p.Parametro == item.ID).First();
                            
                            //Si NO es vacio es porque tiene un papa, y hay que cargar los items antes de posicionarlo.
                            if(!h.Ancestro.Equals(String.Empty))
                            {
                                _carga.Cargar((DropDownList)item, h.Tabla, ((DropDownList)lstDropDownList[h.Ancestro]).SelectedItem.Value.ToString());
                            }

                            DropDownList cb = (DropDownList)item;
                            cb.SelectedValue = dr[((DropDownList)item).ID].ToString();
                        }
                    }
                    chkEstado.Checked = (dr["prm_Activo"].ToString().Equals("True") ? true : false);
                }
            }
        }

        protected void IngresaParametros()
        {

                ComponenteVO conItem;
                List<Parametro> parametros = new List<Parametro>();
                Parametro list = new Parametro();

                ControlCollection listacontroles = pFiltros.Controls;
                foreach (Control item in listacontroles)
                {
                    list = new Parametro();
                    if (item is TextBox)
                    {
                        if (((TextBox)item).Visible == true && ((TextBox)item).Enabled == true)
                        {
                            list.Name = item.ID;
                            conItem = _listaObejtos.Where(p => p.Parametro == item.ID).First();
                            list.Type = this.RetornaTipo(conItem.Formato);
                            list.Data = ((TextBox)item).Text;
                            //parametros[valCont++] = list;
                            parametros.Add(list);
                        }
                    }
                    else if (item is DropDownList)
                    {
                        if (((DropDownList)item).Visible == true && ((DropDownList)item).Enabled == true)
                        {
                            list.Name = item.ID;
                            conItem = _listaObejtos.Where(p => p.Parametro == item.ID).First();
                            list.Type = this.RetornaTipo(conItem.Formato);
                            list.Data = ((DropDownList)item).SelectedValue;
                            //parametros[valCont++] = list;
                            parametros.Add(list);
                        }
                    }

                }

                list = new Parametro();
                list.Name = "ID";
                list.Type = DbType.Int32;
                list.Data = filtro;
                parametros.Add(list);

                list = new Parametro();
                list.Name = "IDCOLEGIO";
                list.Type = DbType.Int32;
                list.Data = 1;
                parametros.Add(list);

                list = new Parametro();
                list.Name = "ACTIVO";
                list.Type = DbType.Boolean;
                list.Data = (chkEstado.Checked) ? true : false;
                parametros.Add(list);

                list = new Parametro();
                list.Name = "USUARIO";
                list.Type = DbType.String;
                list.Data = user.NomUsuario;
                parametros.Add(list);

                _comunesService = new ComunesServiceClient();
                _comunesService.InsertDinamico(_procedimiento, parametros.ToArray());

                //Cerrar el servicio.
                _comunesService.Close();

       

        }

        protected void imgGuardar_Click(object sender, ImageClickEventArgs e)
        {

            try
            {
                this.IngresaParametros();
                String varJs = "";
                //varJs += "var z = parent.document.getElementById('ctl00_Main_btnRecalcular'); z.click(); ";
                varJs += "var z = parent.document.getElementById('Main_btnRecalcular'); z.click(); ";
                varJs += "var b = parent.document.getElementById('btnele'); $(b).trigger('click');";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", varJs, true);
            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = err.Message;

            }

        }

        public DbType RetornaTipo(String Tipo)
        {
            switch (Tipo)
            {
                case "Str":
                    return DbType.String;
                    //break;
                case "Int":
                    return DbType.Int32;
                    //break;
                case "Dob":
                    return DbType.Double;
                    //break;
                case "Boo":
                    return DbType.Boolean;
                    //break;
                case "Dat":
                    return DbType.DateTime;
                    //break;
                default:
                    return DbType.Object;
                    //break;
            }

        }

        protected void imgCerrar_Click(object sender, ImageClickEventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", "var b = parent.document.getElementById('btnele'); $(b).trigger('click');", true);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.IngresaParametros();
                String varJs = "";
                //varJs += "var z = parent.document.getElementById('ctl00_Main_btnRecalcular'); z.click(); ";
                varJs += "var z = parent.document.getElementById('Main_btnRecalcular'); z.click(); ";
                varJs += "var b = parent.document.getElementById('btnele'); $(b).trigger('click');";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", varJs, true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", $"closeEmergente('simplemodal-container')", true);

            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = err.Message;

            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", $"closeEmergente('simplemodal-overlay')", true);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", $"closeEmergente('simplemodal-container')", true);
        }
    }
}
