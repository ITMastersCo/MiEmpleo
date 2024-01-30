using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace co.itmasters.solucion.vo
{
    [Serializable]
    public class PagosEnLineaVO
    {        
        public string TiendaPag { get; set; }
        public string CodServicioPag { get; set; }
        public string ClavePag { get; set; }
        public string RutaPag { get; set; }
        public string TelefonoPag { get; set; }
        public string EmailPag { get; set; }
        public bool BotonPag { get; set; }
        public String MsnPSEOut { get; set; }

    }
}
