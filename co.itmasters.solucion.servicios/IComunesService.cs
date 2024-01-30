using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using co.itmasters.solucion.vo;
using System.Data;
using System.Text;

namespace co.itmasters.solucion.servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IComunesService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IComunesService
    {
        [OperationContract]
        List<ListaVO> ObtenerLista(String nombre);

        [OperationContract]
        List<ListaVO> ObtenerListaFiltro(String nombre, String idFiltro);

        [OperationContract]
        List<ListaVO> ObtenerListaFiltros(String nombre, String[] filtro);

        [OperationContract]
        DataTable ObtenerListaTablaFiltro(String nombre, String filtro);

        [OperationContract]
        DataTable ObtenerListaTablaFiltros(String nombre, String[] filtro);

        [OperationContract]
        void InsertDinamico(String procedimiento, Parametro[] parametros);

        [OperationContract]
        void RelacionListaInsertaList(List<RelacionParamVO> list);

        [OperationContract]
        void RelacionInserta(RelacionParamVO inserta);

        [OperationContract]
        DataSet ObtenerConsultaReporte(String procedimiento, Parametro[] parametros);
    }
}
