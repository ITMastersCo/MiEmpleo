﻿using System;
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
using co.itmasters.academics.web.ComunesService;

using co.itmasters.academics.vo;
using System.Collections.Generic;

namespace co.itmasters.academics.web.Code
{
    public class AdmonReporte : PageBase
    {
        private String _path;
        private XmlDocument _archivo;

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

        public void ImprimeReporte(String datosReporte, Parametro[] valParam, String formato)
        {
            ReportDocument presRepo = new ReportDocument();
            ComunesServiceClient _comunes = null;
            DataSet data = null;

            string[] reportPath = datosReporte.Split(':');
            try
            {
                _comunes = new ComunesServiceClient();
                data = _comunes.ObtenerConsultaReporte(reportPath[1], valParam);
                _comunes.Close();
            }
            catch (Exception err)
            {
                //LogWeb.Write("AdmonReporte-ImprimeReporte :" + err.Message, LogWeb.ERROR);
                LogWeb.Write("AdmonReporte-ImprimeReporte :" + err.Message + " => " + err.StackTrace.ToString(), LogWeb.ERROR);
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

            if (reportPath[1] == "Rpt_ListadoFotos")
            {
                foreach(DataRow row in data.Tables[1].Rows)
                {
                    String rutaFoto = "Fotos/4/Alumnos/" + row.Field<String>("IDALUMNOCOL") + ".JPG";
                    byte[] imgbyteFoto = CargarFoto(rutaFoto);
                    row.SetField<Byte[]>("Foto", imgbyteFoto);
                }
            }

            if (reportPath[1] == "Alumno_ImprimirUsuarioPDF")
            {
                data.Tables[2].Rows[0].SetField<Byte[]>("LOGO", imgbyte);
                data.Tables[2].Rows[0].SetField<String>("LOGOREPORTES", Context.Request.PhysicalApplicationPath + rutaLogo);
                data.Tables[3].Rows[0].SetField<Byte[]>("LOGO", imgbyte);
                data.Tables[3].Rows[0].SetField<String>("LOGOREPORTES", Context.Request.PhysicalApplicationPath + rutaLogo);
            }
            LogWeb.Write("ImprimeReporte --> : antes de subreports"  , LogWeb.ERROR);
            try
            {
                //throw new Exception(Context.Request.PhysicalApplicationPath + reportPath[0]);
                //presRepo.Load(Request.PhysicalApplicationPath + reportPath[0]);
                presRepo.FileName = Context.Request.PhysicalApplicationPath + reportPath[0];
                LogWeb.Write("ImprimeReporte --> : antes de encabeza", LogWeb.ERROR);
                presRepo.Subreports["EncabezadoBasicos.rpt"].SetDataSource(data.Tables[0]);
                LogWeb.Write("ImprimeReporte --> : antes de pie basico", LogWeb.ERROR);
                presRepo.Subreports["PieBasicos.rpt"].SetDataSource(data.Tables[0]);
                //presRepo.SetDataSource(data.Tables[1]);

                // Aqui van los demas select de supreportes
                try
                {
                    LogWeb.Write("ImprimeReporte --> : total sub retportes" + (data.Tables.Count-1), LogWeb.ERROR);
                    for (int k = 2; k < data.Tables.Count; k++)
                    {
                        LogWeb.Write("ImprimeReporte --> : antes rub reporte#" + (k), LogWeb.ERROR);
          
                        // para avitar el error en subreportes que no existen
                        if (presRepo.Subreports[data.Tables[k].Rows[0][0].ToString()] != null)
                        {
                            presRepo.Subreports[data.Tables[k].Rows[0][0].ToString()].SetDataSource(data.Tables[k]);
                        }
                        LogWeb.Write("ImprimeReporte --> : despues rub reporte#" + k  + "subName=" + data.Tables[k].Rows[0][0].ToString(), LogWeb.ERROR);
                    }
                }
                catch (Exception err)
                {
                    throw;
                    LogWeb.Write(err.Message + " : Error en subreporte  => " + err.StackTrace.ToString(), LogWeb.ERROR);
                }

                presRepo.SetDataSource(data.Tables[1]);
            }
            catch (Exception err)
            {
                LogWeb.Write("ImprimeReporte --> : antes de lanzar exception", LogWeb.ERROR);
                 throw;
                LogWeb.Write("ImprimeReporte --> :" + err.Message + " => " + err.StackTrace.ToString(), LogWeb.ERROR);
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
                    default:
                        //presRepo.ExportToHttpResponse(ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "Reporte"); //Para PDF
                        try
                        {
                            LogWeb.Write("ImprimeReporte --> : antes de salvar pdf", LogWeb.ERROR);
                            presRepo.ExportToDisk(ExportFormatType.PortableDocFormat,Context.Request.PhysicalApplicationPath + "onlySaveXXX.pdf");
                            LogWeb.Write("ImprimeReporte --> : antes de imprimir pdf", LogWeb.ERROR);

                            //presRepo.Load(Server.MapPath(@"MyReport.rpt"));
                            System.IO.Stream oStream = null;
                            byte[] byteArray = null;
                            oStream = presRepo.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                            byteArray = new byte[oStream.Length];
                            oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));

                            //// este es solo un ejemplo para ver si al guardar el reporte genera error
                            FileStream fileStream = new FileStream(Context.Request.PhysicalApplicationPath + "xxx21.pdf", System.IO.FileMode.Create);
                            fileStream.Write(byteArray, 0, Convert.ToInt32(oStream.Length));
                            fileStream.Close();
                            LogWeb.Write("ImprimeReporte --> : despuesde escribir pdf", LogWeb.ERROR);

                            HttpContext.Current.Response.ClearContent();
                            HttpContext.Current.Response.ClearHeaders();
                            HttpContext.Current.Response.Clear();
                            HttpContext.Current.Response.Buffer = true;
                            HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf");
                            //HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + documentTitle + ".pdf");
                            HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" + "reportexxx" + ".pdf");
                            HttpContext.Current.Response.BinaryWrite(byteArray);
                            //HttpContext.Current.Response.End();

                            //HttpContext.Current.Response.ContentType = "application/pdf";
                            //HttpContext.Current.Response.BinaryWrite(byteArray);
                            //long byteCount;
                            //byte[] buffer = new byte[1024];
                            //while ((byteCount = oStream.Read(buffer, 0, buffer.Length)) > 0)
                            //{
                            //    if (Context.Response.IsClientConnected)
                            //    {
                            //        Context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                            //        Context.Response.Flush();
                            //    }
                            //}

                            HttpContext.Current.Response.Close();
                            oStream.Close();
                            presRepo.Close();
                            presRepo.Dispose();

                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message;
                        }

                        break;
                }
            }
            catch (Exception err)
            {
                //throw;
                LogWeb.Write("ImprimeReporte --> :" + err.Message + " => " + err.StackTrace.ToString(),LogWeb.ERROR);
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
                    LogoPath = "../Images/ImgInicio/Academics.jpg";
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
                LogWeb.Write("CargarLogo :" + err.Message,LogWeb.ERROR);
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
                    FotoPath = "../Fotos/4/Alumnos/Blanco.jpg";
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
