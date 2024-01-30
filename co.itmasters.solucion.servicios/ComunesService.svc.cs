using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using co.itmasters.solucion.negocio;
using co.itmasters.solucion.vo;
using System.Data;


namespace co.itmasters.solucion.servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ComunesService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ComunesService.svc o ComunesService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ComunesService : IComunesService, IDisposable
    {
        private ComunesNegocio _comunes;


        public List<ListaVO> ObtenerLista(String nombre)
        {
            _comunes = new ComunesNegocio();
            try
            {
                return _comunes.ObtenerLista(nombre);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }

        public List<ListaVO> ObtenerListaFiltro(String nombre, String idFiltro)
        {
            _comunes = new ComunesNegocio();
            try
            {
                return _comunes.ObtenerLista(nombre, idFiltro);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }

        public List<ListaVO> ObtenerListaFiltros(String nombre, String[] filtro)
        {
            _comunes = new ComunesNegocio();
            try
            {
                return _comunes.ObtenerLista(nombre, filtro);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }

        //Para utilizar la tabla de lista, pero retornando un datatable.
        public DataTable ObtenerListaTablaFiltro(String nombre, String filtro)
        {
            _comunes = new ComunesNegocio();
            try
            {
                return _comunes.ObtenerListaTabla(nombre, filtro);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }

        //Para utilizar la tabla de lista con varios parametros, pero retornando un datatable.
        public DataTable ObtenerListaTablaFiltros(String nombre, String[] filtro)
        {
            _comunes = new ComunesNegocio();
            try
            {
                return _comunes.ObtenerListaTabla(nombre, filtro);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }

        public void InsertDinamico(String procedimiento, Parametro[] parametros)
        {
            _comunes = new ComunesNegocio();
            try
            {
                _comunes.InsertDinamico(procedimiento, parametros);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }

        public void RelacionListaInsertaList(List<RelacionParamVO> list)
        {
            _comunes = new ComunesNegocio();
            _comunes.RelacionListaInserta(list);
        }

        public void RelacionInserta(RelacionParamVO inserta)
        {
            _comunes = new ComunesNegocio();
            _comunes.RelacionInserta(inserta);
        }

        /// <summary>
        /// Metodo que ofrece la consulta para armar un reporte
        /// </summary>
        /// <param name="procedimiento"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public DataSet ObtenerConsultaReporte(String procedimiento, Parametro[] parametros)
        {
            _comunes = new ComunesNegocio();

            try
            {
                return _comunes.ObtenerConsultaReporte(procedimiento, parametros);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }

        /// <summary>
        /// Libera la memoria usada por el objeto, y los objetos internos que se utilicen
        /// </summary>
        public virtual void Dispose()
        {

        }
    }
}
