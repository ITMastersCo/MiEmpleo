using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace co.itmasters.solucion.web.Code
{
    [Serializable]
    public class ComponenteVO
    {
        public string Texto { get; set; }
        public string Parametro { get; set; }
        public string Tipo { get; set; }
        public string Tabla { get; set; }
        public int Tamano { get; set; }
        public bool FiltroColegio { get; set; }
        public bool EnableEdicion { get; set; }
        public string Hijo { get; set; }
        //public string Padre { get; set; }
        public string Ancestro { get; set; }
        //public string Filtro { get; set; }
        public string Formato { get; set; }
        public bool Requerido { get; set; }
        public string Busqueda { get; set; }
        public bool ConFiltro { get; set; }
        public List<PadreVO> Padres { get; set; }
    }
}
