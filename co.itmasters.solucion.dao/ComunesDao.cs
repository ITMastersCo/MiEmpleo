using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using co.itmasters.solucion.vo;
using System.Collections;

namespace co.itmasters.solucion.dao
{
    public class ComunesDao : BaseDao
    {
        #region [Constants]

        //DECLARA PROCEDIMIENTOS 

        //*********  CARGAR COMBOS *********//
        private const String COMUNES_CARGARCOMBOS = "spCargarCombos";
        private const String RELACION_INSERTA = "spInsertaRelacion";

        //*********    CONSTANTES *********//
        public const string LISTA_id = "Id";
        public const string LISTA_nombre = "Nombre";

        #endregion

        public List<ListaVO> ObtenerLista(String nombre)
        {
            try
            {
                List<ListaVO> listaObjetos = new List<ListaVO>();
                DataTable w = this.EjecutarConsultaDataTable(ObtenerSQL(nombre));
                for (int i = 0; i < w.Rows.Count; i++)
                {
                    DataRow dr = w.Rows[i];
                    ListaVO item = this.CargaListaVO(dr);
                    listaObjetos.Add(item);
                }
                return listaObjetos;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<ListaVO> ObtenerLista(String nombre, String idFiltro)
        {
            try
            {
                List<ListaVO> listaObjetos = new List<ListaVO>();
                String SQL = ObtenerSQL(nombre);
                SQL = SQL.Replace("?", idFiltro);
                DataTable w = this.EjecutarConsultaDataTable(SQL);
                for (int i = 0; i < w.Rows.Count; i++)
                {
                    DataRow dr = w.Rows[i];
                    ListaVO item = this.CargaListaVO(dr);
                    listaObjetos.Add(item);
                }
                return listaObjetos;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public List<ListaVO> ObtenerLista(String nombre, String[] filtro)
        {
            try
            {
                List<ListaVO> listaObjetos = new List<ListaVO>();
                String SQL = ObtenerSQL(nombre);
                for (int i = 0; i < filtro.Length; i++)
                {
                    SQL = SQL.Replace("?" + (i + 1), filtro[i]);
                }
                for (int i = 0; i < filtro.Length; i++)
                {
                    SQL = SQL.Replace("?", filtro[i]);
                }
                DataTable w = this.EjecutarConsultaDataTable(SQL);
                for (int i = 0; i < w.Rows.Count; i++)
                {
                    DataRow dr = w.Rows[i];
                    ListaVO item = this.CargaListaVO(dr);
                    listaObjetos.Add(item);
                }
                return listaObjetos;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public DataTable ObtenerListaTabla(String nombre, String filtro)
        {
            try
            {
                String SQL = ObtenerSQL(nombre);
                if(!filtro.Equals(""))
                    SQL = SQL.Replace("?", filtro);
                DataTable w = this.EjecutarConsultaDataTable(SQL);
                return w;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public DataTable ObtenerListaTabla(String nombre, String[] filtro)
        {
            try
            {
                string SQL = ObtenerSQL(nombre);
                for (int i = 0; i < filtro.Length; i++)
                {
                    SQL = SQL.Replace("?"+(i+1), filtro[i]);
                }
                DataTable w = this.EjecutarConsultaDataTable(SQL);
                return w;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private String ObtenerSQL(String nombre)
        {
            try
            {
                Parametro valParam = new Parametro("nombre", nombre, DbType.String);
                DataRow dr = this.EjecutarStoredProcedureDataRow(COMUNES_CARGARCOMBOS, valParam);
                return dr[0].ToString();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private ListaVO CargaListaVO(DataRow dr)
        {
            //  Generando Metodo
            if (dr == null)
                return null;

            ListaVO retorno = new ListaVO();

            retorno.Id = (Object)dr[LISTA_id];
            //retorno.Nombre = (String)dr[LISTA_nombre];
            retorno.Nombre = dr[LISTA_nombre].ToString();
            return retorno;
        }

        public List<ListaVO> ObtenerListaBySp(String sp)
        {
            try
            {
                List<ListaVO> listaObjetos = new List<ListaVO>();
                DataTable w = this.EjecutarStoredProcedureDataTable(sp);
                for (int i = 0; i < w.Rows.Count; i++)
                {
                    DataRow dr = w.Rows[i];
                    ListaVO item = this.CargaListaVO(dr);
                    listaObjetos.Add(item);
                }
                return listaObjetos;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void RelacionInsert(RelacionParamVO inserta)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                   { 
                         new Parametro("PARAMETRO", inserta.Parametro, DbType.String),
                         new Parametro("TIPO", inserta.Inserta, DbType.Boolean),
                         new Parametro("VAL_LIST1", inserta.ValorCombo, DbType.Int32),
                         new Parametro("VAL_LIST2", inserta.ValorLista, DbType.Int32),
                         new Parametro("USUARIO", inserta.Usuario, DbType.String),
                         new Parametro("FECHA", inserta.Fecha, DbType.DateTime)
                   };
                this.EjecutarStoredProcedure(RELACION_INSERTA, valParam);

            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        //public DataSet ObtenerConsultaReporte(String procedimiento, Parametro[] parametros)
        //{
        //    try
        //    {
        //        DataSet ds = this.EjecutarStoredProcedureDataSet(procedimiento, parametros);
        //        return ds;
        //    }
        //    catch (System.Data.SqlClient.SqlException e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

    }
}



