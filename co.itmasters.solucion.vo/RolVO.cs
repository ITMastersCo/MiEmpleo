using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace co.itmasters.solucion.vo
{
    [Serializable]
    public class RolVO
    {
        public Int32 IdRol { get; set; }
        public String Nombre { get; set; }
        public int tipoUsuario { get; set; }
    }
}