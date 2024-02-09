using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using co.itmasters.solucion.web.Code;
using co.itmasters.solucion.web.Components_UI;
using CrystalDecisions.CrystalReports.Engine;
using co.itmasters.solucion.vo;

namespace co.itmasters.solucion.web.Reportes
{
    public partial class VisorReportes : PageBase
    {
        protected CargaCombos _carga = new CargaCombos();
        private ReportDocument report;
        private ReporteVO _reporteParam;
        private List<ComponenteVO> _listaObejtos;
        private List<ListaVO> _listaReportes;
        private Hashtable lstDropDownList;
        private Hashtable lstDropDownBan;
        private Hashtable lstTextoFiltro;
        private Hashtable lstCompara;
        private Hashtable lstComparaTexto;
        private Hashtable lstComparaEntero;
        private ReportDocument presRepo;
        private UserVO user;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = ((UserVO)Session["UsuarioAutenticado"]);
            if (!IsPostBack)
            {
                
            }
           Master.OcultarBanda();
        }


        private void Page_Init(Object sender, System.EventArgs e)
        {
            try
            {
                user = ((UserVO)Session["UsuarioAutenticado"]);
                String reporte = Request.QueryString["Reporte"];
                String ruta = Request.PhysicalApplicationPath + Request.QueryString["Reportes"];
                //String ruta = Request.PhysicalApplicationPath + "Reportes\\Basicos\\Basicos.xml";

                AdmonReporte repoNegocio = new AdmonReporte(ruta);
                this.CargaListas();
                _reporteParam = repoNegocio.LeeParametros();
                _listaObejtos = repoNegocio.LeerComponentes();
                _listaReportes = repoNegocio.LeerReportes();
                this.ConstruyeForma();
                this.ConstruyeFiltro();
                if (!Page.IsPostBack)
                {
                    this.ConstruyeReportes();
                }
            }
            catch (Exception error)
            {
                Master.mostrarMensaje(error.Message, Master.ERROR);
            }
        }

        private void CargaListas()
        {
            lstComparaTexto = new Hashtable();
            lstComparaTexto.Add("=", "=");
            lstComparaTexto.Add("!=", "<>");
            lstComparaTexto.Add("like", "like");
            lstComparaEntero = new Hashtable();
            lstComparaEntero.Add("=", "=");
            lstComparaEntero.Add("!=", "!=");
            lstComparaEntero.Add(">", ">");
            lstComparaEntero.Add(">=", ">=");
            lstComparaEntero.Add("<", "<");
            lstComparaEntero.Add("<=", "<=");
        }

        private void ConstruyeForma()
        {
            lblTitulo.Text = _reporteParam.Titulo;
            lblSubtitulo.Text = _reporteParam.SubTitulo;
            if (_reporteParam.VisibleFecIni || _reporteParam.VisibleFecFin)
            {
                
                if (_reporteParam.VisibleFecIni)
                {
                    lblFecIni.Text = _reporteParam.TextoFecIni;
                    lblFecIni.Visible = true;
                    txtFecIni.Visible = true;
                }

                if (_reporteParam.VisibleFecFin)
                {
                    lblFecFin.Text = _reporteParam.TextoFecFin;
                    lblFecFin.Visible = true;
                    txtFecFin.Visible = true;
                }
            }
            else
            {
                this.ControlFechas.Style["display"] = "none";
            }

            if (_reporteParam.VisibleActivo)
            {
                this.lblEstado.Text = _reporteParam.TextoActivo;
                this.chkEstado.ID = _reporteParam.ParamActivo;
            }
            else
            {
                this.ControlEstado.Style["display"] = "none";
            }
        }

        public void ConstruyeFiltro()
        {
            if (_listaObejtos.Count > 0)
            {
                List<ComponenteVO> lstCombo = _listaObejtos.Where(p => p.Tipo == "Combo").ToList();
                List<ComponenteVO> lstTexto = _listaObejtos.Where(p => p.Tipo == "Caja").ToList();
                List<ComponenteVO> lstCajaTexto = _listaObejtos.Where(p => p.Tipo == "CajaTexto").ToList();
                List<ComponenteVO> lstCajaTextoMulti = _listaObejtos.Where(p => p.Tipo == "CajaTextoMultilinea").ToList();
                List<ComponenteVO> lstCajaTextoBusqueda = _listaObejtos.Where(p => p.Tipo == "CajaTextoBusqueda").ToList();
                List<ComponenteVO> lstComboUsuario = _listaObejtos.Where(p => p.Tipo == "ComboUsuario").ToList();

                pFiltros.Controls.Add(new LiteralControl("<table width=80% cellpadding=\"2px\">"));

                if (lstCombo.Count > 0)
                {
                    lstDropDownList = new Hashtable();
                    lstDropDownBan = new Hashtable();
                    this.ConstruyeCombo(lstCombo);
                    this.CargaCombos(lstCombo);
                }

                if (lstComboUsuario.Count > 0)
                {
                    lstDropDownList = new Hashtable();
                    lstDropDownBan = new Hashtable();
                    this.ConstruyeCombo(lstComboUsuario);
                    this.CargaCombosUsuario(lstComboUsuario);
                }

                if (lstTexto.Count > 0 || lstCajaTexto.Count > 0|| lstCajaTextoBusqueda.Count > 0||lstCajaTextoMulti.Count > 0)
                {
                     lstTextoFiltro = new Hashtable();
                }
                if (lstTexto.Count > 0)
                {
                    //lstTextoFiltro = new Hashtable();
                    lstCompara = new Hashtable();
                    this.ConstruyeCaja(lstTexto);
                    this.CargaComboCompara(lstTexto);
                }
                
                if (lstCajaTexto.Count > 0)
                {
                    //lstTextoFiltro = new Hashtable();
                    this.ConstruyeCajaTexto(lstCajaTexto);
                }
                if (lstCajaTextoBusqueda.Count > 0)
                {
                    //lstTextoFiltro = new Hashtable();
                    this.ConstruyeCajaTextoBusqueda(lstCajaTextoBusqueda);
                }

                if (lstCajaTextoMulti.Count > 0)
                {
                    //lstTextoFiltro = new Hashtable();
                    this.ConstruyeCajaTextoMulti(lstCajaTextoMulti);
                }
              

                pFiltros.Controls.Add(new LiteralControl("</table>"));
            }
            else
            {
                //this.ListaFiltro.Style["display"] = "none";
            }
        }

        

        public void ConstruyeCombo(List<ComponenteVO> lstCombo)
        {
            ComponenteVO item;

            for (int i = 0; i < lstCombo.Count; i++)
            {
                item = lstCombo[i];
                pFiltros.Controls.Add(new LiteralControl("<tr><div class=\" flex-col gap-4 \" >"));

                Label etiqueta = new Label();
                etiqueta.Text = item.Texto;
                etiqueta.CssClass = "text-medium color-gray-700";
                pFiltros.Controls.Add(etiqueta);

                DropDownList filtro = new DropDownList();
                filtro.ID = item.Parametro;
                filtro.CssClass = "drop-down-list";



                lstDropDownList.Add(item.Parametro, filtro);
                pFiltros.Controls.Add(filtro);
                if (item.Requerido)
                {
                    RequiredFieldValidator validador = new RequiredFieldValidator();
                    validador.ID = "RFV" + filtro.ID;
                    validador.InitialValue = "-1";
                    validador.Enabled = true;
                    validador.SetFocusOnError = true;
                    validador.ValidationGroup = "Exportar";
                    validador.CssClass = "required-field-validator";
                    validador.Text = "Seleccione una opción";
                    validador.ControlToValidate = filtro.ID;
                    pFiltros.Controls.Add(validador);

                }     
                
                if (item.Padres[0].Padre == String.Empty)
                {
                    filtro.AutoPostBack = false;
                }
                else
                {
                    filtro.AutoPostBack = true;
                    filtro.SelectedIndexChanged += new EventHandler(ComboFiltrar);
                    //TextBox ban = new TextBox();
                    //ban.ID = "T" + item.Parametro;
                    //ban.Style["width"] = "10%";
                    //ban.Style["display"] = "none";
                    //pFiltros.Controls.Add(ban);
                    //lstDropDownBan.Add(item.Parametro, ban);
                }


                if (item.Requerido)
                {
                  
                }



                pFiltros.Controls.Add(new LiteralControl("</div></tr>"));


            }
        }


        public void ComboFiltrar(object sender, EventArgs e)
        {

            DropDownList cbPadre = sender as DropDownList;
            ComponenteVO compPadre = (ComponenteVO)_listaObejtos.Where(p => p.Parametro == cbPadre.ID).First(); //Combo Seleccionado
            List<ComponenteVO> compHijos = new List<ComponenteVO>();
            List<ComponenteVO> compAllPadres = new List<ComponenteVO>();
            bool Bandera = true;
            int indice = 0;

            for (int i = 0; i < compPadre.Padres.Count; i++)
            {
                ComponenteVO compHijo = new ComponenteVO();
                compHijo = (ComponenteVO)_listaObejtos.Where(p => p.Parametro == compPadre.Padres[i].Padre).First();
                compHijos.Add(compHijo);
            }

            //ComponenteVO compHijo = (ComponenteVO)_listaObejtos.Where(p => p.Parametro == compPadre.Padres[0].Padre).First();

            TextBox banT = (TextBox)lstDropDownBan[cbPadre.ID];

            //if (banT.Text == String.Empty)
            //{
            for (int i = 0; i < compHijos.Count; i++)
            {
                indice = 0;

                DropDownList cbHijo = (DropDownList)lstDropDownList[compPadre.Padres[i].Padre];

                string[] Filtro = {};

                if (compHijos[i].FiltroColegio)
                {
                    Array.Resize(ref Filtro, Filtro.Length + 1);
                    Filtro[indice] = user.IdUsuario.ToString();
                }

                for (int y = 0; y < _listaObejtos.Count; y++)
                {
                    for (int p = 0; p < _listaObejtos[y].Padres.Count; p++)
                    {
                        if (_listaObejtos[y].Padres[p].Padre == cbHijo.ID)
                        {
                            DropDownList cbPadres = (DropDownList)lstDropDownList[_listaObejtos[y].Parametro];
                            if (cbPadres.SelectedValue.Equals("-1"))
                            {
                                Bandera = false;                                
                            }
                            Array.Resize(ref Filtro, Filtro.Length + 1);
                            Filtro[indice+1] = cbPadres.SelectedValue;                            
                            indice++;

                        }
                    }
                }

                //ComponenteVO compPadre = (ComponenteVO)_listaObejtos.Where(p => p.Parametro == cbPadre.ID);



                if (Bandera)
                {
                    cbHijo.Enabled = true;
                    List<ListaVO> lista;
                    if (compPadre.Padres[i].Filtro == String.Empty)
                    {
                        if (compHijos[i].FiltroColegio)
                            lista = _carga.TablasBasicas(compHijos[i].Tabla, Filtro);
                        else
                            lista = _carga.TablasBasicas(compHijos[i].Tabla, Filtro);
                    }
                    else
                    {
                        lista = _carga.TablasBasicas(compHijos[i].Tabla, " AND " + compPadre.Padres[i].Filtro + " = " + cbPadre.SelectedValue);
                    }

                    cbHijo.DataSource = null;
                    cbHijo.DataSource = lista;
                    cbHijo.DataValueField = "Id";
                    cbHijo.DataTextField = "Nombre";
                    cbHijo.DataBind();
                    ListItem itemUno = new ListItem("Seleccione un elemento", "-1");
                    cbHijo.Items.Insert(0, itemUno);
                }
                else
                {
                    //cbHijo.Enabled = false;
                    //cbHijo.Items.Clear();
                    //cbHijo.SelectedIndex = 0;
                    _carga.CargarVacio(cbHijo);
                }

                //lstDropDownList.Remove(cbHijo.ID);
                //lstDropDownList.Add(cbHijo.ID, cbHijo);
                //    banT.Text = "Cargado";
                //}
                
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
                        _carga.Cargar(cb, item.Tabla,user.IdUsuario.ToString());
                    else
                        _carga.Cargar(cb, item.Tabla);
                }
                else
                {
                    cb.Enabled = false;
                    ListItem itemUno = new ListItem("Seleccione un elemento", "-1");
                    cb.Items.Insert(0, itemUno);
                }
            }
        }
        public void CargaCombosUsuario(List<ComponenteVO> lstComboUsuario)
        {
            DropDownList cb;
            Int32 i = 0;

            foreach (ComponenteVO item in lstComboUsuario)
            {
                cb = (DropDownList)lstDropDownList[item.Parametro];
                i++;
                if (item.Hijo == String.Empty)
                {
                    string[] par = new string[] { user.IdUsuario.ToString() };
                    List<ListaVO> asiglist = _carga.TablasBasicas(item.Tabla, par);
                    if (item.FiltroColegio)
                        _carga.Cargar(cb, asiglist);
                    else
                        _carga.Cargar(cb, item.Tabla);
                }
                else
                {
                    cb.Enabled = false;
                    ListItem itemUno = new ListItem("Seleccione un elemento", "-1");
                    cb.Items.Insert(0, itemUno);
                }
            }
        }

        public void ConstruyeCaja(List<ComponenteVO> lstCajas)
        {
            ComponenteVO item;

            for (int i = 0; i < lstCajas.Count; i++)
            {
                item = lstCajas[i];
                pFiltros.Controls.Add(new LiteralControl("<tr><td style=\"width: 20%;\" align=\"Left\">"));

                Label etiqueta = new Label();
                etiqueta.CssClass = "text-medium color-gray-700";
                etiqueta.Text = item.Texto;
                pFiltros.Controls.Add(etiqueta);
                DropDownList compara = new DropDownList();
                compara.ID = "C" + item.Parametro;
                if (item.Requerido)
                {
                    //pFiltros.Controls.Add(new LiteralControl("<img alt=\"\" src=\"" + this.UrlBasePath() + "Images/Obligatorio.gif\" />"));
                    RequiredFieldValidator validador = new RequiredFieldValidator();
                    validador.SetFocusOnError = true;
                    validador.Style["Width"] = "10%";
                    validador.CssClass = "required-field-validator";
                    validador.Text = "Filtro Requerido";
                    validador.ControlToValidate = compara.ID;
                    pFiltros.Controls.Add(validador);
                }

                pFiltros.Controls.Add(new LiteralControl("</td><td style=\"width: 80%;\" align=\"Left\" >"));

              
                compara.Style["width"] = "10%";
                compara.CssClass = "drop-down-list";
                pFiltros.Controls.Add(compara);
                lstCompara.Add(item.Parametro, compara);

                TextBox textoFiltro = new TextBox();
                textoFiltro.Style["width"] = "60%";
                textoFiltro.ID = item.Parametro;
                textoFiltro.CssClass = "text-box";
                pFiltros.Controls.Add(textoFiltro);
                lstTextoFiltro.Add(item.Parametro, textoFiltro);

                if (item.Requerido)
                {
                    RequiredFieldValidator validador = new RequiredFieldValidator();
                    validador.SetFocusOnError = true;
                    validador.Style["Width"] = "10%";
                    validador.CssClass = "required-field-validator";
                    validador.Text = "Filtro Requerido";
                    validador.ControlToValidate = textoFiltro.ID;
                    pFiltros.Controls.Add(validador);
                }

                pFiltros.Controls.Add(new LiteralControl("</td></tr>"));
            }
        }        

        public void ConstruyeCajaTexto(List<ComponenteVO> lstCajas)
        {
            ComponenteVO item;

            for (int i = 0; i < lstCajas.Count; i++)
            {
                item = lstCajas[i];
                pFiltros.Controls.Add(new LiteralControl("<tr><div class=\" flex-col gap-4 \" >"));

                Label etiqueta = new Label();
                etiqueta.CssClass = "text-medium color-gray-700";
                etiqueta.Text = item.Texto;
                pFiltros.Controls.Add(etiqueta);
                
                          
                TextBox textoFiltro = new TextBox();
                textoFiltro.ID = item.Parametro;
                textoFiltro.CssClass = "text-box";
                pFiltros.Controls.Add(textoFiltro);
                lstTextoFiltro.Add(item.Parametro, textoFiltro);

                if (item.Requerido)
                {
                    
                    RequiredFieldValidator validador = new RequiredFieldValidator();
                    validador.ID = "RFV" + textoFiltro.ID;
                    validador.InitialValue = "-1";
                    validador.Enabled = true;
                    validador.SetFocusOnError = true;
                    validador.ValidationGroup = "Exportar";
                    validador.CssClass = "required-field-validator";
                    validador.Text = "Campo requerido";
                    validador.ControlToValidate = textoFiltro.ID;
                    pFiltros.Controls.Add(validador);
                }

                pFiltros.Controls.Add(new LiteralControl("</div></tr>"));
            }
        }

        //TextMode="MultiLine"
        public void ConstruyeCajaTextoMulti(List<ComponenteVO> lstCajas)
        {
            ComponenteVO item;

            for (int i = 0; i < lstCajas.Count; i++)
            {
                item = lstCajas[i];
                pFiltros.Controls.Add(new LiteralControl("<tr><div class=\" flex-col gap-4 \" >"));

                Label etiqueta = new Label();
                etiqueta.CssClass = "text-medium color-gray-700";
                etiqueta.Text = item.Texto;
                pFiltros.Controls.Add(etiqueta);

                TextBox textoFiltro = new TextBox();
                textoFiltro.ID = item.Parametro;
                textoFiltro.CssClass = "text-area";
                textoFiltro.TextMode = TextBoxMode.MultiLine;
                pFiltros.Controls.Add(textoFiltro);
                lstTextoFiltro.Add(item.Parametro, textoFiltro);

                if (item.Requerido)
                {
                    RequiredFieldValidator validador = new RequiredFieldValidator();
                    validador.ID = "RFV" + textoFiltro.ID;
                    validador.InitialValue = "-1";
                    validador.Enabled = true;
                    validador.SetFocusOnError = true;
                    validador.ValidationGroup = "Exportar";
                    validador.CssClass = "required-field-validator";
                    validador.Text = "Seleccione una opción";
                    validador.ControlToValidate = textoFiltro.ID;
                    pFiltros.Controls.Add(validador);

                }

                pFiltros.Controls.Add(new LiteralControl("</div></tr>"));
            }
        }

        private void ConstruyeCajaTextoBusqueda(List<ComponenteVO> lstCajaTextoBusqueda)
        {
            ComponenteVO item;

            for (int i = 0; i < lstCajaTextoBusqueda.Count; i++)
            {
                item = lstCajaTextoBusqueda[i];
                pFiltros.Controls.Add(new LiteralControl("<tr><div class=\" flex-col gap-4 \" >"));

                Label etiqueta = new Label();
                etiqueta.CssClass = "text-medium color-gray-700";
                etiqueta.Text = item.Texto;
                pFiltros.Controls.Add(etiqueta);

                TextBox textoFiltro = new TextBox();
                textoFiltro.ID = item.Parametro;
                textoFiltro.CssClass = "text-box";
                textoFiltro.Attributes.Add("placeholder", "Digite ID");
                
                if (item.Requerido)
                {

                    RequiredFieldValidator validador = new RequiredFieldValidator();
                    validador.ID = "RFV" + textoFiltro.ID;
                    validador.InitialValue = "-1";
                    validador.Enabled = true;
                    validador.SetFocusOnError = true;
                    validador.ValidationGroup = "Exportar";
                    validador.CssClass = "required-field-validator";
                    validador.Text = "Seleccione una opción";
                    validador.ControlToValidate = textoFiltro.ID;
                    pFiltros.Controls.Add(validador);
                }

                pFiltros.Controls.Add(textoFiltro);
                lstTextoFiltro.Add(item.Parametro, textoFiltro);
                if (item.Busqueda == String.Empty)
                {
                    ImageButton imgBusqueda = new ImageButton();
                    imgBusqueda.ImageUrl = this.UrlBasePath() + "Images/BuscarNombres.gif";
                    imgBusqueda.ToolTip = "Busqueda avanzada";
                    imgBusqueda.ID = "img1" + item.Parametro;
                    imgBusqueda.Width = 20;
                    imgBusqueda.Height = 20;
                    imgBusqueda.CausesValidation = false;
                    imgBusqueda.Click += new ImageClickEventHandler(this.Calculate);
                    pFiltros.Controls.Add(imgBusqueda);
                }
                pFiltros.Controls.Add(new LiteralControl("</div></tr>"));
            }
        }

        protected void Calculate(object sender, System.EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            String varNombre = btn.ID.Replace("img1", "");

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", "escribirLinkDimenDatosBasicos('../Alumno/AlumnoBuscar.aspx?Tipo=NumDoc&Valor=ctl00_Main_TXT0',400,600, 'Buscar Alumno')", true);

        }

        private void CargaComboCompara(List<ComponenteVO> lstTexto)
        {
            foreach (ComponenteVO item in lstTexto)
            {
                DropDownList h = (DropDownList)lstCompara[item.Parametro];
                h.DataSource = (item.Formato.Equals("Str")) ? lstComparaTexto : lstComparaEntero;
                h.DataValueField = "key";
                h.DataTextField = "value";
                h.DataBind();
            }
        }

        public void ConfiguraReporte(String Tipo)
        {
            AdmonReporte _reporte = new AdmonReporte("");

            string datosReporte = rblReportes.SelectedValue;

            try
            {
                _reporte.ImprimeReporte(datosReporte, CargarParametrosConsultaReporte().ToArray<Parametro>(), Tipo);            
            }
            catch (Exception err)
            {
               
                LogWeb.Write(err.Message, LogWeb.ERROR);
                throw;
            }
        }

        public List<Parametro> CargarParametrosConsultaReporte()
        {
            List<Parametro> parametros = new List<Parametro>();
            Parametro parm;

            //Se setea el colegio
            parm = new Parametro();
            parm.Name = "idUsuario";
            parm.Type = DbType.Int32;
            parm.Data = user.IdUsuario;
            parametros.Add(parm);

            

            //Se verifica si la fecha Inicial esta habilitada para enviarla.
            if (txtFecIni.Visible)
            {
                if (txtFecIni.Text != String.Empty)
                {
                    parm = new Parametro();
                    parm.Name = txtFecIni.ID;
                    parm.Type = DbType.DateTime;
                    parm.Data = Convert.ToDateTime(txtFecIni.Text);
                    parametros.Add(parm);
                }
                else
                {
                    parm = new Parametro();
                    parm.Name = txtFecIni.ID;
                    parm.Type = DbType.DateTime;
                    parm.Data = Convert.ToDateTime("01/01/1990");
                    parametros.Add(parm);
                }
            }

            //Se verifica si la fecha Final esta habilitada para enviarla.
            if (txtFecFin.Visible)
            {
                if (txtFecFin.Text != String.Empty)
                {
                    parm = new Parametro();
                    parm.Name = txtFecFin.ID;
                    parm.Type = DbType.DateTime;
                    parm.Data = Convert.ToDateTime(txtFecFin.Text);
                    parametros.Add(parm);
                }
                else
                {
                    parm = new Parametro();
                    parm.Name = txtFecFin.ID;
                    parm.Type = DbType.DateTime;
                    parm.Data = Convert.ToDateTime("01/01/2030");
                    parametros.Add(parm);
                }
            }

            
            if (lstDropDownList != null)
            {
                if (lstDropDownList.Count > 0)
                {
                    foreach (DictionaryEntry item in lstDropDownList)
                    {
                        DropDownList cmp = (DropDownList)lstDropDownList[item.Key.ToString()];
                       
                        parm = new Parametro();
                        parm.Name = cmp.ID;
                        parm.Type = DbType.Int32;
                        parm.Data = Int32.Parse(cmp.SelectedValue);
                        parametros.Add(parm);
                    }
                }
            }

            if (lstTextoFiltro != null)
            {
                if (lstTextoFiltro.Count > 0)
                {
                    int i = 0;
                    foreach (DictionaryEntry item in lstTextoFiltro)
                    {

                        //DropDownList cmp = (DropDownList)lstCompara[item.Key.ToString()];
                        TextBox val = (TextBox)lstTextoFiltro[item.Key.ToString()];

                        parm = new Parametro();
                        //parm.Name = "txt" + i;
                        parm.Name = item.Key.ToString().Trim();
                        parm.Type = DbType.String;
                        parm.Data = val.Text.Trim();
                        parametros.Add(parm);
                        i++;
                        //if (val.Text.Trim() != String.Empty)
                        //{
                        //    ParameterValueKind param;
                        //    param = presRepo.ParameterFields[val.ID].ParameterValueType;
                        //    presRepo.SetParameterValue(val.ID, val.Text);
                        //}
                        //else
                        //{
                        //    ParameterValueKind param;
                        //    param = presRepo.ParameterFields[val.ID].ParameterValueType;
                        //    presRepo.SetParameterValue(val.ID, "''");
                        //}
                    }
                }
            }

            return parametros;
        }
        public void GuardarReporte(String Tipo, String ruta, String nombre)
        {
            AdmonReporte _reporte = new AdmonReporte("");
            string datosReporte = rblReportes.SelectedValue;

            try
            {
                _reporte.GuardaReporte(datosReporte, CargarParametrosConsultaReporte().ToArray<Parametro>(), Tipo, ruta, nombre);
            }
            catch (Exception err)
            {

                LogWeb.Write(err.Message, LogWeb.ERROR);
                throw;
            }
        }
        public void ConstruyeReportes()
        {
            rblReportes.DataSource = null;
            rblReportes.DataSource = _listaReportes;
            rblReportes.DataValueField = "Id";
            rblReportes.DataTextField = "Nombre";
            rblReportes.DataBind();
            rblReportes.Items[0].Selected = true;
        }

        protected void imgReport_Click(object sender, ImageClickEventArgs e)
        {
        }


        protected void imgGuardaPDF_Click(object sender, ImageClickEventArgs e)
        {
            Master.OcultarBanda();
            try
            {
                if (!System.IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "/DocsEmpresa/" + user.IdUsuario.ToString()))
                {
                    System.IO.Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "/DocsEmpresa/" + user.IdUsuario.ToString());

                }
                string ruta = System.AppDomain.CurrentDomain.BaseDirectory + "/DocsEmpresa/" + user.IdUsuario.ToString() + "/";
                this.GuardarReporte("GPDF", ruta, "Reporte.pdf");
            }
            catch (Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);
            }
        }

        protected void btnExportWord_Click(object sender, EventArgs e)
        {
            Master.OcultarBanda();
            try
            {

                this.ConfiguraReporte("WORD");

            }
            catch (Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);
            }
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            Master.OcultarBanda();
            try
            {

                this.ConfiguraReporte("EXCEL");
            }
            catch(Exception err) { 
                Master.mostrarMensaje(err.Message, Master.ERROR);
            }
        }

        protected void btnExportPdf_Click(object sender, EventArgs e)
        {
            Master.OcultarBanda();
            try
            {

                this.ConfiguraReporte("PDF");
            }
            catch (Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);
            }
        }
    }
}
