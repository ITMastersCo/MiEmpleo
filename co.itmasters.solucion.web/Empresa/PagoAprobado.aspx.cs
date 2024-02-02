using co.itmasters.solucion.vo;
using co.itmasters.solucion.web.Code;
using co.itmasters.solucion.web.EmpresaService;
using co.itmasters.solucion.web.OfertaService;
using CrystalDecisions.ReportAppServer.DataDefModel;
using MercadoPago.Resource.User;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace co.itmasters.solucion.web.Empresa
{
    public partial class PagoAprobado : System.Web.UI.Page
    {
        EmpresaServiceClient _Empresa;
        OfertaServiceClient _OfertaService;
        UserVO user;
        protected void Page_Load(object sender, EventArgs e)
        {
               
            if (!IsPostBack) {
                user = ((UserVO)Session["UsuarioAutenticado"]);
                ProcesarPago();


            }
            
        }
        protected void ProcesarPago()
        {
            if (Request.QueryString["preference_id"] != null && Request.QueryString["status"] != null)
            {
                string preferenceId = Request.QueryString["preference_id"];
                string status = Request.QueryString["status"];
                switch (status)
                {
                    case EstadoPago.MECADOPAGO_APROBADO:
                        UpdatePlanAdquirido(preferenceId, EstadoPago.ESTADO_CONSOLIDADO);
                        break;
                    case EstadoPago.MECADOPAGO_PENDIENTE:
                        UpdatePlanAdquirido(preferenceId, EstadoPago.ESTADO_PENDIENTE);
                        break;
                    case EstadoPago.MECADOPAGO_RECHAZADO:
                        UpdatePlanAdquirido(preferenceId, EstadoPago.ESTADO_RECHAZADO);
                        break;
                    default:
                        break;
                }
            }
            else
            {

            }
        }
        protected object UpdatePlanAdquirido(string preferenceId, string estado)
        {
            user = ((UserVO)Session["UsuarioAutenticado"]);
            try
            {
                EmpresaVO newEmpresa = new EmpresaVO();
                OfertaVO newPlan = new OfertaVO();

                newEmpresa.typeModify = TipoConsulta.MODIFY_UPDATE;
                newEmpresa.idUsuario = user.IdUsuario;
                newEmpresa.estado = estado;
                newPlan.preference_id = preferenceId;
                newEmpresa.Oferta = newPlan;

                _Empresa = new EmpresaServiceClient();
                _Empresa.CreatePlanAdquirido(newEmpresa);
                _Empresa.Close();
                return newEmpresa;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}