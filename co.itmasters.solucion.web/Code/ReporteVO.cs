using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace co.itmasters.solucion.web.Code
{
    public class ReporteVO
    {
        public String Titulo { get; set; }
        public String SubTitulo { get; set; }
        
        public String TextoFecIni { get; set; }
        public Boolean VisibleFecIni { get; set; }
        public String ParamFecIni { get; set; }

        public String TextoFecFin { get; set; }
        public Boolean VisibleFecFin { get; set; }
        public String ParamFecFin { get; set; }

        public String TextoActivo { get; set; }
        public Boolean VisibleActivo { get; set; }
        public String ParamActivo { get; set; }

    }
}
