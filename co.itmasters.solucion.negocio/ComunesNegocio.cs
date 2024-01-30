using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using co.itmasters.solucion.dao;
using co.itmasters.solucion.vo;
using System.Data;


namespace co.itmasters.solucion.negocio
{
    public class ComunesNegocio
    {
        private ComunesDao comunes;
        
        private Hashtable hashCache;


        public ComunesNegocio() 
        {
            comunes = new ComunesDao();
            hashCache = new Hashtable();
          

        }
             
      

        public List<ListaVO> ObtenerLista(String nombre) 
        {
            List<ListaVO> lista;
            if (hashCache.ContainsKey(nombre))
            {
                lista = (List<ListaVO>)hashCache[nombre];
            }
            else
            {
                lista = comunes.ObtenerLista(nombre);
                hashCache.Add(nombre, lista);
            }
            return lista;
        }

        public List<ListaVO> ObtenerLista(String nombre, String idFiltro) 
        {
            return comunes.ObtenerLista(nombre, idFiltro);
        }

        public List<ListaVO> ObtenerLista(String nombre, String[] filtro)
        {
            return comunes.ObtenerLista(nombre, filtro);
        }

        //Para utilizar la tabla de lista, pero retornando un datatable.
        public DataTable ObtenerListaTabla(String nombre, String filtro) 
        {
            return comunes.ObtenerListaTabla(nombre, filtro);
        }

        //Para utilizar la tabla de lista con varios parametros, pero retornando un datatable.
        public DataTable ObtenerListaTabla(String nombre, String[] filtro)
        {
            return comunes.ObtenerListaTabla(nombre, filtro);
        }

        public void InsertDinamico(String procedimiento, Parametro[] parametros)
        {
            comunes.EjecutarStoredProcedure(procedimiento, parametros);
        }

        public void RelacionListaInserta(List<RelacionParamVO> list)
        {
            foreach (RelacionParamVO item in list)
            {
                this.RelacionInserta(item);
            }
        }

        public void RelacionInserta(RelacionParamVO inserta)
        {
            comunes.RelacionInsert(inserta);
        }


        public DataSet ObtenerConsultaReporte(String procedimiento, Parametro[] parametros)
        {
            return comunes.EjecutarStoredProcedureDataSet(procedimiento, parametros);
        }
    }
}
