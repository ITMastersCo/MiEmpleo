using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace co.itmasters.solucion.web.Code
{
    public static class TipoUsuario
    {

        public const int USUARIO_EMPRESA = 1;
        public const int USUARIO_CANDIDATO = 2;
        public const int USUARIO_ADMINISTRADOR = 3;

    }
    public static class TipoConsulta
    {

        public const string MODIFY_TYPE = "modifyType";
        public const string GET = "GET";
        public const string MODIFY_INSERT = "INS";
        public const string MODIFY_UPDATE = "UPD";
        public const string MODIFY_DELETE = "DEL";

    }
    public static class EstadoPago
    {
        public const string ESTADO_CONSOLIDADO = "CON";
        public const string ESTADO_PENDIENTE = "PEN";
        public const string ESTADO_RECHAZADO = "REC";
        public const string MECADOPAGO_APROBADO = "approved";
        public const string MECADOPAGO_PENDIENTE = "in_process";
        public const string MECADOPAGO_RECHAZADO = "rejected";
        }
}


