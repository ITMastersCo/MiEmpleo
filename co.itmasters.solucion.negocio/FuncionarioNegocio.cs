using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using co.itmasters.solucion.dao;
using co.itmasters.solucion.vo;

namespace co.itmasters.solucion.negocio
{
    public class FuncionarioNegocio
    {
        FuncionarioDao _funcionario;

        public FuncionarioNegocio() 
        {
            _funcionario = new FuncionarioDao();
        }

        public void Guardar_Funcionario(FuncionarioVO pFuncionario)
        {
            _funcionario.Guardar_Funcionario(pFuncionario);
        }

        public FuncionarioVO Buscar_Funcionario(FuncionarioVO funcionario)
        {
            return _funcionario.Buscar_Funcionario(funcionario);
        }

       


    }
}
