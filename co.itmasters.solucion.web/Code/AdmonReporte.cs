using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using co.itmasters.solucion.web.ComunesService;

using co.itmasters.solucion.vo;
using System.Collections.Generic;

namespace co.itmasters.solucion.web.Code
{
    public class AdmonReporte : PageBase
    {
        private String _path;
        private XmlDocument _archivo;
        public UserVO user;

        public AdmonReporte(String ruta)
        {
            if (ruta != "")
            {
                _path = ruta;
                _archivo = new XmlDocument();
                _archivo.Load(ruta);
            }
        }

        public ReporteVO LeeParametros()
        {
            ReporteVO repo = new ReporteVO();

            repo.Titulo = this.AtributoReporte("Titulo", "Texto");
            repo.SubTitulo = this.AtributoReporte("Subtitulo", "Texto");

            repo.TextoFecIni = this.AtributoReporte("FechaInicio", "Texto");
            repo.VisibleFecIni = (this.AtributoReporte("FechaInicio", "Visible").Equals("True")) ? true : false;
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

            lstReports = _archivo.GetElementsByTagName("Reporte");
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

            lstReports = _archivo.GetElementsByTagName("Reporte");
            lstComponentes = ((XmlElement)lstReports[0]).GetElementsByTagName("Componente");

            foreach (XmlElement nodo in lstComponentes)
            {
                item = new ComponenteVO();
                item.Texto = nodo.GetAttribute("Texto");
                item.Parametro = nodo.GetAttribute("Parametro");
                item.Tipo = nodo.GetAttribute("Tipo");
                item.Tabla = nodo.GetAttribute("Tabla");
                item.Hijo = nodo.GetAttribute("Hijo");
                item.Ancestro = nodo.GetAttribute("Ancestro");
                item.Busqueda = nodo.GetAttribute("Busqueda");
                item.Formato = nodo.GetAttribute("Formato");
                item.Requerido = (nodo.GetAttribute("Requerido").Equals("True")) ? true : false;
                item.ConFiltro = (nodo.GetAttribute("ConFiltro").Equals("True")) ? true : false;
                item.FiltroColegio = (nodo.GetAttribute("FiltroColegio").Equals("True")) ? true : false;

                Padres = this.TraerPadresVO(nodo);

                item.Padres = Padres;

                lista.Add(item);

            }
            return lista;
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
                item.Nombre = nodo.GetAttribute("Texto");
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
                item.FiltroColegio = (nodo.GetAttribute("FiltroColegio").Equals("True")) ? true : false;
                lista.Add(item);
            }
            return lista;
        }
        public void GuardaReporte(String datosReporte, Parametro[] valParam, String formato, String ruta, String Nombre)
        {

            ReportDocument presRepo = new ReportDocument();
            ComunesServiceClient _comunes = null;
            DataSet data = null;
            String DataName = "", DataNumber = "";
            string[] reportPath = datosReporte.Split(':');
            try
            {
                _comunes = new ComunesServiceClient();
                data = _comunes.ObtenerConsultaReporte(reportPath[1], valParam);
                _comunes.Close();
            }
            catch (Exception err)
            {
                LogWeb.Write("AdmonReporte-ImprimeReporte :" + err.Message, LogWeb.ERROR);
                throw;
                if (_comunes != null) _comunes.Close();
                data = null;
            }
            if (data == null)
                return;

            String rutaLogo = data.Tables[0].Rows[0].Field<String>("LOGOREPORTES");
            byte[] imgbyte = CargarLogo(rutaLogo);
            data.Tables[0].Rows[0].SetField<Byte[]>("LOGO", imgbyte);
            data.Tables[0].Rows[0].SetField<String>("LOGOREPORTES", Context.Request.PhysicalApplicationPath + rutaLogo);

            if (data.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow row in data.Tables[1].Rows)
                {
                    foreach (DataColumn Column in row.Table.Columns)
                    {
                        if (Column.ColumnName.ToString().Contains("Foto"))
                        {
                            String rutaFoto = "Fotos/" + Column.ColumnName.ToString().Replace("Foto", "");
                            if (rutaFoto.Contains("Empresas"))
                            {
                                rutaFoto += "/" + Convert.ToString(row.Field<Int32>("NUMIDENTIFICACION")).Trim();
                            }
                            else if (rutaFoto.Contains("Candidatos"))
                            {
                                rutaFoto += "/" + Convert.ToString(row.Field<Int32>("NUMIDENTIFICACION")).Trim();
                            }
                            else if (rutaFoto.Contains("QR"))
                            {
                                rutaFoto += "/" + row.Field<String>("NUMIDENTIFICACION").Trim();
                            }
                            rutaFoto += ".JPG";
                            byte[] imgbyteFoto = (CargarFoto(rutaFoto) == null) ? CargarFoto("Fotos/" + "Candidatos/AvatarDefault.JPG") : CargarFoto(rutaFoto);
                            row.SetField<Byte[]>(Column.ColumnName.ToString(), imgbyteFoto);
                            break;
                        }
                    }

                }
            }

            if (reportPath[1] == "Alumno_ImprimirUsuarioPDF")
            {
                data.Tables[2].Rows[0].SetField<Byte[]>("LOGO", imgbyte);
                data.Tables[2].Rows[0].SetField<String>("LOGOREPORTES", Context.Request.PhysicalApplicationPath + rutaLogo);
                data.Tables[3].Rows[0].SetField<Byte[]>("LOGO", imgbyte);
                data.Tables[3].Rows[0].SetField<String>("LOGOREPORTES", Context.Request.PhysicalApplicationPath + rutaLogo);
            }

            if (reportPath[1] == "Rpt_pagCtaCobro")
            {
                data.Tables[2].Rows[0].SetField<Byte[]>("LOGO", imgbyte);
                data.Tables[2].Rows[0].SetField<String>("LOGOREPORTES", Context.Request.PhysicalApplicationPath + rutaLogo);
            }

            try
            {
                //throw new Exception(Context.Request.PhysicalApplicationPath + reportPath[0]);
                //presRepo.Load(Request.PhysicalApplicationPath + reportPath[0]);
                presRepo.FileName = Context.Request.PhysicalApplicationPath + reportPath[0];
                presRepo.Subreports["EncabezadoBasicos.rpt"].SetDataSource(data.Tables[0]);
                presRepo.Subreports["PieBasicos.rpt"].SetDataSource(data.Tables[0]);
                //presRepo.SetDataSource(data.Tables[1]);

                // Aqui van los demas select de supreportes
                try
                {
                    for (int k = 2; k < data.Tables.Count; k++)
                    {
                        if (presRepo.Subreports[data.Tables[k].Rows[0][0].ToString()] != null)
                        {
                            presRepo.Subreports[data.Tables[k].Rows[0][0].ToString()].SetDataSource(data.Tables[k]);
                        }
                    }
                }
                catch (Exception err)
                {
                    LogWeb.Write(err.Message + " : Error en subreporte ", LogWeb.ERROR);
                }

                presRepo.SetDataSource(data.Tables[1]);
            }
            catch (Exception err)
            {
                // throw;
                LogWeb.Write("ImprimeReporte :" + err.Message, LogWeb.ERROR);
                return;
            }

            try
            {
                switch (formato.ToUpper())
                {
                    case "WORD":
                        presRepo.ExportToHttpResponse(ExportFormatType.WordForWindows, HttpContext.Current.Response, true, "Reporte");
                        break;
                    case "EXCEL":
                        presRepo.ExportToHttpResponse(ExportFormatType.Excel, HttpContext.Current.Response, true, "Reporte");
                        break;
                    case "PDF":
                        presRepo.ExportToHttpResponse(ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "Reporte");
                        break;
                    case "GPDF":
                        {
                            //ReportDocument rFeporte = new ReportDocument();
                            //reporte.Load(@"C:\FUENTES ITMASTERS\AcademicsV2TEC\co.itmasters.solucion.web\DocsColegio\Certificados\"+"Reporte.rpt");

                            ExportFormatType tipo = ExportFormatType.PortableDocFormat;
                            ruta = ruta.Replace("/","\\");
                            presRepo.ExportToDisk(tipo,  ruta + Nombre);
                        }
                        break;
                    case "SPDF":
                        {
                            //ReportDocument rFeporte = new ReportDocument();
                            //reporte.Load(@"C:\FUENTES ITMASTERS\AcademicsV2TEC\co.itmasters.solucion.web\DocsColegio\Certificados\"+"Reporte.rpt");

                            ExportFormatType tipo = ExportFormatType.PortableDocFormat;
                            ruta = ruta.Replace("/", "\\");
                            presRepo.ExportToStream(tipo);
                            
                        }

                        break;

                    default:
                        presRepo.ExportToHttpResponse(ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "Reporte");
                        break;

                }
                presRepo.Close();
                presRepo.Dispose();

            }
            catch (Exception err)
            {
                //throw;
                presRepo.Close();
                presRepo.Dispose();
                LogWeb.Write("ImprimeReporte --> :" + err.Message, LogWeb.ERROR);
            }


        }
        public void ImprimeReporte(String datosReporte, Parametro[] valParam, String formato)
        {

            ReportDocument presRepo = new ReportDocument();
            ComunesServiceClient _comunes = null;
            DataSet data = null;
            String DataName = "", DataNumber = "";


            string[] reportPath = datosReporte.Split(':');
            try
            {
                _comunes = new ComunesServiceClient();
                data = _comunes.ObtenerConsultaReporte(reportPath[1], valParam);
                _comunes.Close();
            }
            catch (Exception err)
            {
                LogWeb.Write("AdmonReporte-ImprimeReporte :" + err.Message, LogWeb.ERROR);
                throw;
                if (_comunes != null) _comunes.Close();
                data = null;
            }
            if (data == null)
                return;

            String rutaLogo = data.Tables[0].Rows[0].Field<String>("LOGOREPORTES");
            byte[] imgbyte = CargarLogo(rutaLogo);
            data.Tables[0].Rows[0].SetField<Byte[]>("LOGO", imgbyte);
            data.Tables[0].Rows[0].SetField<String>("LOGOREPORTES", Context.Request.PhysicalApplicationPath + rutaLogo);

            if (data.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow row in data.Tables[1].Rows)
                {
                    foreach (DataColumn Column in row.Table.Columns)
                    {
                        if (Column.ColumnName.ToString().Contains("Foto"))
                        {
                            String rutaFoto = "Fotos/" + Column.ColumnName.ToString().Replace("Foto", "");
                            if (rutaFoto.Contains("Empresas"))
                            {
                                rutaFoto += "/" + Convert.ToString(row.Field<Int32>("NUMIDENTIFICACION")).Trim();
                            }
                            else if (rutaFoto.Contains("Candidatos"))
                            {
                                rutaFoto += "/" + Convert.ToString(row.Field<Int32>("NUMIDENTIFICACION")).Trim();
                            }
                            else if (rutaFoto.Contains("QR"))
                            {
                                rutaFoto += "/" + row.Field<String>("NUMIDENTIFICACION").Trim();
                            }
                            rutaFoto += ".JPG";
                            byte[] imgbyteFoto = (CargarFoto(rutaFoto) == null) ? CargarFoto("Fotos/" + "Candidatos/AvatarDefault.JPG") : CargarFoto(rutaFoto);
                            row.SetField<Byte[]>(Column.ColumnName.ToString(), imgbyteFoto);
                            break;
                        }
                    }

                }
            }

            if (reportPath[1] == "Alumno_ImprimirUsuarioPDF")
            {
                data.Tables[2].Rows[0].SetField<Byte[]>("LOGO", imgbyte);
                data.Tables[2].Rows[0].SetField<String>("LOGOREPORTES", Context.Request.PhysicalApplicationPath + rutaLogo);
                data.Tables[3].Rows[0].SetField<Byte[]>("LOGO", imgbyte);
                data.Tables[3].Rows[0].SetField<String>("LOGOREPORTES", Context.Request.PhysicalApplicationPath + rutaLogo);
            }

            if (reportPath[1] == "Rpt_pagCtaCobro")
            {
                data.Tables[2].Rows[0].SetField<Byte[]>("LOGO", imgbyte);
                data.Tables[2].Rows[0].SetField<String>("LOGOREPORTES", Context.Request.PhysicalApplicationPath + rutaLogo);
            }

            try
            {
                //throw new Exception(Context.Request.PhysicalApplicationPath + reportPath[0]);
                //presRepo.Load(Request.PhysicalApplicationPath + reportPath[0]);
                presRepo.FileName = Context.Request.PhysicalApplicationPath + reportPath[0];
                presRepo.Subreports["EncabezadoBasicos.rpt"].SetDataSource(data.Tables[0]);
                presRepo.Subreports["PieBasicos.rpt"].SetDataSource(data.Tables[0]);
                //presRepo.SetDataSource(data.Tables[1]);

                // Aqui van los demas select de supreportes
                try
                {
                    for (int k = 2; k < data.Tables.Count; k++)
                    {
                        if (presRepo.Subreports[data.Tables[k].Rows[0][0].ToString()] != null)
                        {
                            presRepo.Subreports[data.Tables[k].Rows[0][0].ToString()].SetDataSource(data.Tables[k]);
                        }
                    }
                }
                catch (Exception err)
                {
                    LogWeb.Write(err.Message + " : Error en subreporte ", LogWeb.ERROR);
                }

                presRepo.SetDataSource(data.Tables[1]);
            }
            catch (Exception err)
            {
                // throw;
                LogWeb.Write("ImprimeReporte :" + err.Message, LogWeb.ERROR);
                return;
            }

            try
            {
                switch (formato.ToUpper())
                {
                    case "WORD":
                        presRepo.ExportToHttpResponse(ExportFormatType.WordForWindows, HttpContext.Current.Response, true, "Reporte");
                        break;
                    case "EXCEL":
                        presRepo.ExportToHttpResponse(ExportFormatType.Excel, HttpContext.Current.Response, true, "Reporte");
                        break;
                    case "PDF":
                        presRepo.ExportToHttpResponse(ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "Reporte");
                        break;                                
                    default:
                        presRepo.ExportToHttpResponse(ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "Reporte");
                        break;

                }
                presRepo.Close();
                presRepo.Dispose();

            }
            catch (Exception err)
            {
                //throw;
                presRepo.Close();
                presRepo.Dispose();
                LogWeb.Write("ImprimeReporte --> :" + err.Message, LogWeb.ERROR);
            }
        }

        public byte[] CargarLogo(String LogoPath)
        {
            // define the filestream object to read the image 
            FileStream fs = null;
            // define te binary reader to read the bytes of image 
            BinaryReader br = null;

            try
            {
                // check the existance of image 
                if (!File.Exists(Context.Request.PhysicalApplicationPath + LogoPath))
                    LogoPath = "../Images/ImgInicio/LOGO-Empresas.png";
                // open image in file stream
                fs = new FileStream(Context.Request.PhysicalApplicationPath + LogoPath, FileMode.Open);

                // initialise the binary reader from file streamobject 
                br = new BinaryReader(fs);
                // define the byte array of filelength 
                byte[] imgbyte = new byte[fs.Length + 1];
                // read the bytes from the binary reader 
                imgbyte = br.ReadBytes(Convert.ToInt32((fs.Length)));

                // close the binary reader 
                br.Close();
                // close the file stream 
                fs.Close();

                return imgbyte;
            }
            catch (Exception err)
            {
                LogWeb.Write("CargarLogo :" + err.Message, LogWeb.ERROR);
                if (br != null) br.Close();
                if (fs != null) fs.Close();
                return null;
            }
        }

        public byte[] CargarFoto(String FotoPath)
        {

            // define the filestream object to read the image 
            FileStream fs = null;
            // define te binary reader to read the bytes of image 
            BinaryReader br = null;

            try
            {
                // check the existance of image 
                if (!File.Exists(Context.Request.PhysicalApplicationPath + FotoPath))
                    FotoPath = "../Images/AvatarDefault.png";
                // open image in file stream
                fs = new FileStream(Context.Request.PhysicalApplicationPath + FotoPath, FileMode.Open);

                // initialise the binary reader from file streamobject 
                br = new BinaryReader(fs);
                // define the byte array of filelength 
                byte[] imgbyte = new byte[fs.Length + 1];
                // read the bytes from the binary reader 
                imgbyte = br.ReadBytes(Convert.ToInt32((fs.Length)));

                // close the binary reader 
                br.Close();
                // close the file stream 
                fs.Close();

                return imgbyte;
            }
            catch (Exception err)
            {
                LogWeb.Write("CargarLogo :" + err.Message, LogWeb.ERROR);
                if (br != null) br.Close();
                if (fs != null) fs.Close();
                return null;
            }
        }



    }
}
