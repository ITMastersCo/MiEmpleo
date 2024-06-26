﻿using System;
using System.Web;
using co.itmasters.solucion.vo;
using co.itmasters.solucion.web.Code;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using co.itmasters.solucion.web.PersonaService;
using co.itmasters.solucion.web.OfertaService;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using System.Web.Management;
using System.Web.Razor.Generator;
using System.Data;
using co.itmasters.solucion.vo.constantes;
using System.Runtime.Remoting.Messaging;

namespace co.itmasters.solucion.web
{
    public partial class _Default : System.Web.UI.Page
    {
        private UserVO user;
        private PersonaServiceClient _ActoresService;
        private CargaCombos _carga = new CargaCombos();
        private OfertaServiceClient _OfertaService;
        private static List<ListaVO> listaCiudad;
        private static List<ListaVO> listaOcupacion;

        protected void Page_Load(object sender, EventArgs e)
        {

            listaCiudad = _carga.TablasBasicas(TipoLista.LISTACIUDADESTADOPAIS);
            listaOcupacion = _carga.TablasBasicas(TipoLista.LISTAOCUPACIONES_EN_USO);
            user = ((UserVO)Session["UsuarioAutenticado"]);
            if (!IsPostBack)
            {
                Redirec();
                
            }


        }



        private void Redirec()
        {
            if (user != null)
            {
                switch (user.tipoUsuario)
                {
                    case 1:
                         if (user.diligenciaFormulario == 0)
                         {
                             Response.Redirect("~/Empresa/DatosBasicosEmpresa.aspx", true);
                         }
                         else
                         {
                             Response.Redirect("~/Empresa/PanelEmpresa.aspx", true);
                         }
                    break;
                    case 2:
                        DataBind();
                        PersonaVO persona = GetPersona();
                        if (persona.diligenciaBasicos == 0){Response.Redirect("~/Personal/HojadeVida.aspx");}
                        break;
                     case 3:
                        DataBind();
                        break;
                    case 4:
                        {
                            Response.Redirect("~/Empresa/PanelEmpresa.aspx", true);
                        }
                        break;
                        
                }
                
            }else
            {
                Response.Redirect("~/Index.aspx");
            }
        }
        private PersonaVO GetPersona()
        {
            PersonaVO personaVo = new PersonaVO();
            try
            {
                personaVo.idUsuario = user.IdUsuario;
                _ActoresService = new PersonaServiceClient();
                PersonaVO persona = _ActoresService.Buscar_Persona(personaVo);
                _ActoresService.Close();
                return persona;

            }
            catch (Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);
                return null;
            }


        }
        protected int GetPorcentaje()
        {
            try
            {
                PersonaVO persona = GetPersona();
                if(persona != null)
                {

                int porcentaje
                    = Convert.ToInt32(persona.diligenciaAptitud)
                    + Convert.ToInt32(persona.diligenciaPerfil)
                    + Convert.ToInt32(persona.diligenciaExperiencia)
                    + Convert.ToInt32(persona.diligenciaBasicos)
                    + Convert.ToInt32(persona.diligenciaAcademia);
                return porcentaje;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
        protected void LlenarGrdOfertas()
        {


            OfertaVO ofertaSearch = new OfertaVO();
            ofertaSearch.idUsuario = user.IdUsuario;
            ofertaSearch.tituloVacante = txtBuscarCargo.Text;

            _ = txtIdCiudadBuscar.Text != ""
                ? ofertaSearch.idCiudadVacante = Convert.ToInt32(txtIdCiudadBuscar.Text)
                : ofertaSearch.idCiudadVacante = null;

            _ = txtIdOcupacion.Text != ""
                ? ofertaSearch.idOcupacion = Convert.ToInt32(txtIdOcupacion.Text)
                : ofertaSearch.idOcupacion = null;



            _OfertaService = new OfertaServiceClient();

            List<OfertaVO> listOffer = _OfertaService.GetOfertaPersona(ofertaSearch).ToList();
            _OfertaService.Close();

            if (listOffer.Count > 0)
            {
                containerOfertas.Visible = true;
                grdOfertasDestacadas.DataSource = listOffer;
                grdOfertasDestacadas.DataBind();
                noResultsShare.Visible = false;
            }
            else
            {
                noResultsShare.Visible = true;
                containerOfertas.Visible = true;
                grdOfertasDestacadas.DataBind();
            }

        }
        protected void btnBuscarOferta_Click(object sender, EventArgs e)
        {
            Master.OcultarBanda();
            LlenarGrdOfertas();

        }

        protected void btnPostularOferta_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", $"CloseModal('{detalleOferta.ClientID}', '{openModal.ClientID}')", true);
            try
            {
                OfertaVO postulacion = new OfertaVO();

                postulacion.idOferta = Convert.ToInt32(lblIdOferta.Text);
                postulacion.idPersona = Convert.ToInt32(lblIdPersona.Text);
                postulacion.typeModify = TipoConsulta.MODIFY_INSERT;
                postulacion.estado = null;



                OfertaServiceClient _OfertaService = new OfertaServiceClient();
                _OfertaService.Postulacion(postulacion);
                _OfertaService.Close();

                Master.mostrarMensaje($"Postulacion a hecha exitosamente", Master.EXITO);

            }
            catch
            {
                Master.mostrarMensaje("Usted ya ha postulado a esta oferta", Master.INFORMACION);
            }
        }


        protected void btnViewOffer_Command(object sender, CommandEventArgs e)
        {

            Master.OcultarBanda();

            if (e.CommandName == "GET")
            {
                Int32 index = Convert.ToInt32(e.CommandArgument) % grdOfertasDestacadas.PageSize;
                GridViewRow row = grdOfertasDestacadas.Rows[index];
                Int32 Id = Convert.ToInt32(((Label)row.FindControl("idOferta")).Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", $"OpenModal('{detalleOferta.ClientID}','{openModal.ClientID}')", true);
                try
                {

                OfertaVO oferta = new OfertaVO();
                oferta.idOferta = Convert.ToInt32(Id);
                OfertaServiceClient _OfertaService = new OfertaServiceClient();
                OfertaVO viewOferta = _OfertaService.GetOfertaPersonaDetalle(oferta);
                _OfertaService.Close();
                lblIdOferta.Text = viewOferta.idOferta.ToString();
                lblIdPersona.Text = GetPersona().idPersona.ToString();
                imgRutaAvatar.Src = $".{viewOferta.rutaAvatar}";
                lblOfferTitle.Text = viewOferta.tituloVacante;
                lblOfferSalaryRange.Text = viewOferta.RangoSalario;
                lblDateCrateOffer.Text = String.Format("{0:yyyy-MM-dd}", viewOferta.fechaPublicacion);
                lblDateRemoveOffer.Text = String.Format("{0:yyyy-MM-dd}", viewOferta.fechaVencimiento);
                lblOfferUserWhoPublished.Text = viewOferta.nomEmpresa;
                lblOfferLocation.Text = viewOferta.nomCiudad;
                lblDescriptioOffer.Text = viewOferta.descripcionVacante;
                }catch(Exception err)
                {
                    Master.mostrarMensaje(err.Message, Master.ERROR);
                }

            }

        }

        protected void btnCloseModal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Prueba", $"CloseModal('{detalleOferta.ClientID}', '{openModal.ClientID}')", true);
        }

        protected void txtCiudadBuscar_TextChanged(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<ListaVO> GetCiudades()
        {
            try
            {

                // Filtrar la lista de ciudades
                return listaCiudad;
            }
            catch
            {
                List<ListaVO> list = new List<ListaVO>();
                return list;
            }
        }
        [WebMethod]
        public static List<ListaVO> GetOcupaciones()
        {
            try
            {

                // Filtrar la lista de ocupaciones
                return listaOcupacion;
            }
            catch
            {
                List<ListaVO> list = new List<ListaVO>();
                return list;
            }
        }
       

     
    }
}
