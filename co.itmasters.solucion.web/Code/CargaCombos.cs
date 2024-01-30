using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections;
using System.Globalization;
using System.Web.Services;
using co.itmasters.solucion.web.ComunesService;
using co.itmasters.solucion.vo;

namespace co.itmasters.solucion.web.Code
{
    public class CargaCombos
    {
        private ComunesServiceClient _comunesService;

        public CargaCombos()
        {
            
        }

        public void Cargar(DropDownList combo, List<AdminVO> lista)
        {
            String clave = "valor";
            String valor = "texto";
            ListItem itemUno = new ListItem("Seleccione un elemento", "-1");
            combo.DataSource = lista;
            combo.DataValueField = clave;
            combo.DataTextField = valor;
            combo.DataBind();
            combo.Items.Insert(0, itemUno);
        }

        public void Cargar(DropDownList combo, List<ListaVO> lista)
        {
            String clave = "id";
            String valor = "nombre";
            ListItem itemUno = new ListItem("Seleccione un elemento", "-1");
            combo.DataSource = lista;
            combo.DataValueField = clave;
            combo.DataTextField = valor;
            combo.DataBind();
            combo.Items.Insert(0, itemUno);
        }

        public void Cargar(CheckBoxList combo, List<ListaVO> lista)
        {
            String clave = "id";
            String valor = "nombre";
            combo.DataSource = lista;
            combo.DataValueField = clave;
            combo.DataTextField = valor;
            combo.DataBind();
        }

        public void Cargar(RadioButtonList combo, List<ListaVO> lista)
        {
            String clave = "id";
            String valor = "nombre";
            combo.DataSource = lista;
            combo.DataValueField = clave;
            combo.DataTextField = valor;
            combo.DataBind();
        }

        public void Cargar(DropDownList combo, String tipo, String filtro)
        {
            List<ListaVO> lista = null;
            String clave = "id";
            String valor = "nombre";
            lista = this.TablasBasicas(tipo,filtro);
            ListItem itemUno = new ListItem("Seleccione un elemento", "-1");
            combo.DataSource = lista;
            combo.DataValueField = clave;
            combo.DataTextField = valor;
            combo.DataBind();
            combo.Items.Insert(0, itemUno);
        }

        public void Cargar(DropDownList combo, String tipo)
        {
            List<ListaVO> lista = null;
            String clave = "id";
            String valor = "nombre";
            lista = this.TablasBasicas(tipo);
            ListItem itemUno = new ListItem("Seleccione un elemento", "-1");
            combo.DataSource = lista;
            combo.DataValueField = clave;
            combo.DataTextField = valor;
            combo.DataBind();
            combo.Items.Insert(0, itemUno);
        }

        public void CargarVacio(DropDownList combo)
        {
            combo.Items.Clear();
            ListItem itemUno = new ListItem("Seleccione un elemento", "-1");
            combo.Items.Insert(0, itemUno);
        }

        public List<ListaVO> TablasBasicas(String tipo)
        {
            _comunesService = new ComunesServiceClient();
            List<ListaVO> res = _comunesService.ObtenerLista(tipo).ToList<ListaVO>();
            _comunesService.Close();
            return res;
        }

        public List<ListaVO> TablasBasicas(String tipo, String filtro)
        {
            _comunesService = new ComunesServiceClient();
            List<ListaVO> res = _comunesService.ObtenerListaFiltro(tipo, filtro).ToList<ListaVO>();
            _comunesService.Close();
            return res;
        }

        public List<ListaVO> TablasBasicas(String tipo, String[] filtro)
        {
            _comunesService = new ComunesServiceClient();
            List<ListaVO> res = _comunesService.ObtenerListaFiltros(tipo, filtro).ToList<ListaVO>();
            _comunesService.Close();
            return res;
        }


        public void Cargar(DropDownList combo, String tipo, String filtro, Int32 selected)
        {
            List<ListaVO> lista = null;
            String clave = "id";
            String valor = "nombre";
            lista = this.TablasBasicas(tipo, filtro);
            ListItem itemUno = new ListItem("Seleccione un elemento", "-1");
            combo.DataSource = lista;
            combo.DataValueField = clave;
            combo.DataTextField = valor;
            combo.DataBind();
            combo.Items.Insert(0, itemUno);
            combo.SelectedValue = selected.ToString();
        }
    }
}
