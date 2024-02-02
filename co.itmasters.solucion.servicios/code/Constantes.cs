﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace co.itmasters.solucion.servicios.code
{
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
