using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace co.itmasters.solucion.web.Code
{
    public class AdminVO
    {
        public String Valor { get; set; }
        public String Texto { get; set; }
        public Boolean ConFiltro { get; set; }
        public String Titulo { get; set; }
        public Int32 Alto { get; set; }
        public Int32 Ancho { get; set; }
        public List<FiltroMantenimientoVO> Filtro { get; set; }
    }
}
