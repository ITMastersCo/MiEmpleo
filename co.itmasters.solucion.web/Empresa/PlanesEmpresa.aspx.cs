﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using co.itmasters.solucion.web.Components_UI;
using System.Web.UI.WebControls;
using co.itmasters.solucion.web.Code;
using co.itmasters.solucion.web.OfertaService;
using co.itmasters.solucion.vo;
using System.Web.Services;
using System.IO;
using co.itmasters.solucion.web.EmpresaService;
using System.Globalization;
using MercadoPago.Client.Preference;
using MercadoPago.Config;
using MercadoPago.Resource.Preference;
using System.Threading.Tasks;
using MercadoPago.Client.Common;
using System.Windows.Forms;
using Microsoft.Ajax.Utilities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using co.itmasters.solucion.vo.constantes;
using System.CodeDom;


namespace co.itmasters.solucion.web.Empresa
{
    public partial class PlanesEmpresa : PageBase
    {
        private OfertaServiceClient _OfertaService;
        private EmpresaServiceClient _Empresa;
        private UserVO user;
        private EmpresaVO newPlan;
        private OfertaVO planGratis;

        public string PreferenceID {get; set;}
        protected void Page_Load(object sender, EventArgs e)
        {
            user = ((UserVO)Session["UsuarioAutenticado"]);
            List<OfertaVO> listaOfertas = GetOffers();  // Obtiene una lista de ofertas desde la base de datos.
            planGratis =  listaOfertas.Find(o => o.idPlan == 1);
            if (!Page.IsPostBack)
            {
                DataBind();
            }
                ShowPlans(listaOfertas); // Renderiza un lista de Ofertas
        }

     
        protected List<OfertaVO> GetOffers()
        {
            user = ((UserVO)Session["UsuarioAutenticado"]);
            Master.OcultarBanda();
            try
            {
                OfertaVO datosConsulta = new OfertaVO();
                datosConsulta.idUsuario = user.IdUsuario;

                _OfertaService = new OfertaServiceClient();
                List<OfertaVO> resultado = _OfertaService.TraeEstadoOferta(datosConsulta).ToList<OfertaVO>();
                _OfertaService.Close();
                return resultado;
            }
            catch (Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);
                return null;
            }

        }
        protected List<OfertaVO> traeOfertas()
        {
            OfertaVO datosConsulta = new OfertaVO();
            datosConsulta.idUsuario = user.IdUsuario;
            
            _OfertaService = new OfertaServiceClient();
            List<OfertaVO> resultado = _OfertaService.TraeEstadoOferta(datosConsulta).ToList<OfertaVO>();
            _OfertaService.Close();
            return resultado;
            

        }
        protected void AddPlanToContainer(OfertaVO plan)
        {
            UserControlCardPlan ucCardPlan = (UserControlCardPlan)LoadControl("~/Components_UI/UserControlCardPlan.ascx");
            ucCardPlan.ID = plan.idPlan.ToString();
            ucCardPlan.idPlan = plan.idPlan.ToString();
            ucCardPlan.IdEmpresa = 0;
            ucCardPlan.Name = plan.nomPlan;
            ucCardPlan.Price = plan.valorPlan;
            ucCardPlan.OffersFeatured = Convert.ToBoolean(plan.ofertaDestacada);
            ucCardPlan.OffersConfidential = Convert.ToBoolean(plan.ofertaConfidencial);
            ucCardPlan.QuestionsFilter = Convert.ToBoolean(plan.preguntasDeFiltro);
            ucCardPlan.ProgrammingMeetZoom = Convert.ToBoolean(plan.entrevistaZoom);
            ucCardPlan.MultiUser = Convert.ToBoolean(plan.multiusuario);
            ucCardPlan.TrainingTech = Convert.ToBoolean(plan.capacitaciones);
            ucCardPlan.TimePublication = $"{plan.diasPublicacionOferta} días";
            ucCardPlan.PlanValidity = Convert.ToString(plan.vigenciaPlan);
            ucCardPlan.TextBtnPlan = "Aquirir Plan";

            contenedorPlanes.Controls.Add(ucCardPlan);
        }
        protected void ShowPlans(List<OfertaVO> plans)
        {
            foreach (OfertaVO plan in plans)
            {
                if (plan.idPlan != 1 )
                AddPlanToContainer(plan);
            }
        }
        protected string CreaPlanAdquirido()
        {
            user = ((UserVO)Session["UsuarioAutenticado"]);
            try
            {
                EmpresaVO newEmpresa = new EmpresaVO();
                OfertaVO newPlan = new OfertaVO();

                newEmpresa.typeModify = TipoConsulta.MODIFY_INSERT;
                newEmpresa.idUsuario = user.IdUsuario;
                newPlan.idPlan = planGratis.idPlan;
                newPlan.vigenciaPlan = planGratis.vigenciaPlan;
                newPlan.numeroOfertas = planGratis.nroOfertas;
                newPlan.valorPlan = planGratis.valorPlan;
                newEmpresa.Oferta = newPlan;

                _Empresa = new EmpresaServiceClient();
                string idPlanAdquirido = _Empresa.CreatePlanAdquirido(newEmpresa);
                _Empresa.Close();
                return idPlanAdquirido;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        protected void  btnPublcarOferta_Click(object sender, EventArgs e)
        {
            if(planGratis != null )
            {
                try
                {
                    CreaPlanAdquirido();
                }catch (Exception err)
                {
                    Master.mostrarMensaje(err.Message, Master.ERROR);
                }
                    Response.Redirect("~/Empresa/PublicarOfertas.aspx");
            }
            else 
            {
                Master.mostrarMensaje("Ya has consumido todas la ofertas gratis, compra un plan y sigue publicando ofertas.", Master.INFORMACION);
            }
        }

        protected void btnComparativo_Click(object sender, EventArgs e)
        {
            divComparativo.Visible = true;
        }

        protected void btnCerrarComparativo_Click(object sender, EventArgs e)
        {
            divComparativo.Visible=false;
        }
    }
}