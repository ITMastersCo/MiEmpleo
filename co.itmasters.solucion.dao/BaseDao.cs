using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using co.itmasters.solucion.vo;

namespace co.itmasters.solucion.dao
{
    public class BaseDao
    {
        protected DbConnection connection = null;
        protected Database database = null;
        protected String sqlCommand = "";
        protected DbCommand command;
        
        public int? intNull = null;
        public Boolean? boolNull = null;
        public decimal? decimalNull = null;
        public DateTime? dateNull = null;
        
        public BaseDao()
        {
            this.database = DatabaseFactory.CreateDatabase(); 
        }

        private void LlenarParametros(params Parametro[] param)
        {
            database = DatabaseFactory.CreateDatabase();

            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    database.AddInParameter(command, param[i].Name, param[i].Type, param[i].Data);
                }
            }
        }

        // Ejecutar Stored Procedure Data Set
        public DataSet EjecutarStoredProcedureDataSet(String procedure, params Parametro[] param)
        {
            DataSet retorna = null;

            sqlCommand = procedure;
            command = database.GetStoredProcCommand(sqlCommand);
            LlenarParametros(param);

            retorna = database.ExecuteDataSet(command);
            
            return retorna;
        }

        // Ejecutar Strored Procedure Data Table
        public DataTable EjecutarStoredProcedureDataTable(String procedure, params Parametro[] param)
        {
            DataSet retorna = null;

            sqlCommand = procedure;
            command = database.GetStoredProcCommand(sqlCommand);
            LlenarParametros(param);

            retorna = database.ExecuteDataSet(command);

            return retorna.Tables[0];
        }

        // Ejecutar Consulta Data Table
        public DataTable EjecutarConsultaDataTable(String procedure, params Parametro[] param)
        {
            DataSet retorna = null;

            sqlCommand = procedure;
            command = database.GetSqlStringCommand(sqlCommand);
            LlenarParametros(param);
 
            retorna = database.ExecuteDataSet(command);
 
            return retorna.Tables[0];
        }


        // Ejecutar Stored Procedure Data Row
        public DataRow EjecutarStoredProcedureDataRow(String procedure, params Parametro[] param)
        {
            DataRow rw;
            DataTable valor = new DataTable();
            sqlCommand = procedure;
            command = database.GetStoredProcCommand(sqlCommand);
            LlenarParametros(param);
                using (DataSet ds = database.ExecuteDataSet(command))
                {
                    if (ds.Tables[0].Rows.Count > 0)
                        rw = ds.Tables[0].Rows[0];
                    else
                        rw = null;

                }
 
            return rw;
        }

        // Ejecutar Stored Procedure Retorna Valor
        public Object EjecutarStoredProcedureRetornaValor(String procedure, params Parametro[] param)
        {
            Object retorna = null;

            sqlCommand = procedure;
            command = database.GetStoredProcCommand(sqlCommand);
            LlenarParametros(param);

            retorna = database.ExecuteScalar(command);

            return retorna;
        }


        // Ejecutar Strored Procedure
        public void EjecutarStoredProcedure(String procedure, params Parametro[] param)
        {
            sqlCommand = procedure;
            command = database.GetStoredProcCommand(sqlCommand);
            LlenarParametros(param);

            database.ExecuteNonQuery(command);
            
        }

        // Validar campos nulos 
        public bool validarNulo(object objeto)
        {
            if (objeto == Convert.DBNull)
            {
                return true;
            }
            return false;
        }


    }
}
