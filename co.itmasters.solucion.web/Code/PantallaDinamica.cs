using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using co.itmasters.solucion.web.ComunesService;
using co.itmasters.solucion.vo;

namespace co.itmasters.solucion.web.Code
{
    public class PantallaDinamica
    {
        private String _path;
        private XmlDocument _archivo;

        public PantallaDinamica(String ruta)
        {
            _path = ruta;
            _archivo = new XmlDocument();
            _archivo.Load(ruta);
        }

        public ReporteVO LeeParametros()
        {
            ReporteVO repo = new ReporteVO();

            repo.Titulo = this.AtributoReporte("Titulo", "Texto");
            repo.SubTitulo = this.AtributoReporte("Subtitulo", "Texto");

            repo.TextoFecIni = this.AtributoReporte("FechaInicio", "Texto");
            repo.VisibleFecIni = (this.AtributoReporte("FechaInicio", "Visible").Equals("True"))? true : false;
            repo.ParamFecIni = this.AtributoReporte("FechaInicio", "Parametro");

            repo.TextoFecFin = this.AtributoReporte("FechaFin", "Texto");
            repo.VisibleFecFin = (this.AtributoReporte("FechaFin", "Visible").Equals("True")) ? true : false;
            repo.ParamFecFin = this.AtributoReporte("FechaFin", "Parametro");

            repo.TextoActivo = this.AtributoReporte("Estado", "Texto");
            repo.VisibleActivo = (this.AtributoReporte("Estado", "Visible").Equals("True")) ? true : false;
            repo.ParamActivo = this.AtributoReporte("Estado", "Parametro");
            
            return repo;
        }

        public ReporteVO LeeParametros(String Tipo)
        {
            ReporteVO repo = new ReporteVO();

            repo.Titulo = this.AtributoReporte("Titulo", "Texto");
            repo.SubTitulo = this.AtributoReporte("Subtitulo", "Texto");
            repo.TextoActivo = this.AtributoReporte("Estado", "Texto");
            repo.VisibleActivo = (this.AtributoReporte("Estado", "Visible").Equals("True")) ? true : false;
            repo.ParamActivo = this.AtributoReporte("Estado", "Parametro");

            return repo;
        }


        protected String AtributoReporte(String nodoPrincipal, String nombreAtributo)
        {
            String retorno;
            XmlNodeList lstReports;
            XmlNodeList lstTitulo;
            XmlElement nodo;

            lstReports = _archivo.GetElementsByTagName("Pantalla");
            lstTitulo = ((XmlElement)lstReports[0]).GetElementsByTagName(nodoPrincipal);
            nodo = ((XmlElement)lstTitulo[0]);
            retorno = nodo.GetAttribute(nombreAtributo);

            return retorno;
        }

        public List<PadreVO> TraerPadresVO(XmlElement nodo)
        {
            List<PadreVO> Padres = new List<PadreVO>();

            XmlNodeList lstPadre = nodo.GetElementsByTagName("Padre");
            if (lstPadre.Count > 0)
            {
                for (int i = 0; i < lstPadre.Count; ++i)
                {
                    XmlElement padre = (XmlElement)lstPadre[i];
                    PadreVO Padre = new PadreVO();
                    Padre.Padre = padre.GetAttribute("Padre");
                    Padre.Filtro = padre.GetAttribute("Filtro");
                    Padres.Add(Padre);

                }
            }
            else
            {
                PadreVO Padre = new PadreVO();
                Padre.Padre = "";
                Padre.Filtro = "";
                Padres.Add(Padre);
            }

            return Padres;
        }

        public List<ComponenteVO> LeerComponentes()
        {
            ComponenteVO item;
            List<ComponenteVO> lista = new List<ComponenteVO>();
            List<PadreVO> Padres = null;
            XmlNodeList lstReports;
            XmlNodeList lstComponentes;
            
            lstReports = _archivo.GetElementsByTagName("Pantalla");
            lstComponentes = ((XmlElement)lstReports[0]).GetElementsByTagName("Componente");

            foreach (XmlElement nodo in lstComponentes)
            {
                item = new ComponenteVO();
                item.Texto = nodo.GetAttribute("Texto");
                item.Parametro = nodo.GetAttribute("Parametro");
                item.Tipo = nodo.GetAttribute("Tipo");
                item.Tabla = nodo.GetAttribute("Tabla");
                item.Tamano = nodo.GetAttribute("Tamano").Equals("") ? 0 : Convert.ToInt16(nodo.GetAttribute("Tamano"));
                item.FiltroColegio = (nodo.GetAttribute("FiltroColegio").Equals("True")) ? true : false;
                item.EnableEdicion = (nodo.GetAttribute("EnableEdicion").Equals("False")) ? false : true;
                item.Hijo = nodo.GetAttribute("Hijo");
                item.Ancestro = nodo.GetAttribute("Ancestro");
                item.Busqueda = nodo.GetAttribute("Busqueda");
                item.Formato = nodo.GetAttribute("Formato");
                item.Requerido = (nodo.GetAttribute("Requerido").Equals("True"))? true : false;
                item.ConFiltro = (nodo.GetAttribute("ConFiltro").Equals("True")) ? true : false;

                Padres = this.TraerPadresVO(nodo);

                item.Padres = Padres;

                lista.Add(item);
            }
            return lista;
        }

        public bool RevisarEstado()
        {
            XmlNodeList lstReports;
            XmlNodeList lstComponentes;

            lstReports = _archivo.GetElementsByTagName("Pantalla");
            lstComponentes = ((XmlElement)lstReports[0]).GetElementsByTagName("Estado");
            XmlElement nodo = (XmlElement)lstComponentes[0];
            return nodo.GetAttribute("ConFiltro").Equals("True");
        }

        public List<ListaVO> LeerReportes()
        {
            ListaVO item;
            List<ListaVO> lista = new List<ListaVO>();
            XmlNodeList lstReports;
            XmlNodeList lstComponentes;

            lstReports = _archivo.GetElementsByTagName("Reporte");
            lstComponentes = ((XmlElement)lstReports[0]).GetElementsByTagName("RPT");

            foreach (XmlElement nodo in lstComponentes)
            {
                item = new ListaVO();
                item.Id = nodo.GetAttribute("Url");
                item.Nombre= nodo.GetAttribute("Texto");
                lista.Add(item);
            }
            return lista;
        }

        public List<AdminVO> LeerAdministracion()
        {
            AdminVO item;
            List<FiltroMantenimientoVO> lisFiltro;
            FiltroMantenimientoVO itemFiltro;
            List<AdminVO> lista = new List<AdminVO>();
             
            XmlNodeList lstPrincipal;
            XmlNodeList lstMantenimiento;
            XmlNodeList lstFiltros;


            lstPrincipal = _archivo.GetElementsByTagName("MANTENIMIENTOS");
            lstMantenimiento = ((XmlElement)lstPrincipal[0]).GetElementsByTagName("TABLA");

            foreach (XmlElement nodo in lstMantenimiento)
            {
                item = new AdminVO();
                item.Valor = nodo.GetAttribute("VALUE");
                item.Texto = nodo.GetAttribute("TEXT");
                item.ConFiltro = Convert.ToBoolean(nodo.GetAttribute("CONFILTRO"));
                item.Alto = Convert.ToInt32(nodo.GetAttribute("ALTO"));
                item.Ancho = Convert.ToInt32(nodo.GetAttribute("ANCHO"));
                item.Titulo = nodo.GetAttribute("TITULO");
                lisFiltro = new List<FiltroMantenimientoVO>();
                lstFiltros = nodo.GetElementsByTagName("FILTRO");
                foreach (XmlElement nodoFiltro in lstFiltros)
                {
                    itemFiltro = new FiltroMantenimientoVO();
                    itemFiltro.Label = nodoFiltro.GetAttribute("LABEL");
                    itemFiltro.Combo = nodoFiltro.GetAttribute("COMBO");
                    itemFiltro.Param = nodoFiltro.GetAttribute("PARAM");
                    itemFiltro.Padre = nodoFiltro.GetAttribute("PADRE");
                    itemFiltro.FiltroColegio = (nodoFiltro.GetAttribute("FILTROCOLEGIO").Equals("True")) ? true : false;
                    itemFiltro.esPadre = (nodoFiltro.GetAttribute("ESPADRE").Equals("True")) ? true : false;
                    lisFiltro.Add(itemFiltro);
                }

                item.Filtro = lisFiltro;
                lista.Add(item);
            }
            return lista;
        }

        public List<RelacionVO> LeerRelaciones()
        {
            RelacionVO item;
            List<RelacionVO> lista = new List<RelacionVO>();

            XmlNodeList lstPrincipal;
            XmlNodeList lstRelaciones;

            lstPrincipal = _archivo.GetElementsByTagName("Relaciones");
            lstRelaciones = ((XmlElement)lstPrincipal[0]).GetElementsByTagName("Relacion");

            foreach (XmlElement nodo in lstRelaciones)
            {
                item = new RelacionVO();
                item.Valor = nodo.GetAttribute("Value");
                item.Texto = nodo.GetAttribute("Texto");
                item.ComboTexto = nodo.GetAttribute("CTexto");
                item.AsociadoTexto = nodo.GetAttribute("ATexto");
                item.PendienteTexto = nodo.GetAttribute("PTexto");

                lista.Add(item);
            }
            return lista;
        }
    }
}
