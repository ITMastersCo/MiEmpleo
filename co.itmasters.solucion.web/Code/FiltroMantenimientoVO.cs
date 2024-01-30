using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace co.itmasters.solucion.web.Code
{
    public class FiltroMantenimientoVO
    {
        public String Label { get; set; }
        public String Combo { get; set; }
        public String Param { get; set; }
        public String Padre { get; set; }
        public Boolean FiltroColegio { get; set; }
        public Boolean esPadre { get; set; }
    }
}
