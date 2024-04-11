using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using co.itmasters.solucion.web.Code;
using co.itmasters.solucion.web.EmpresaService;
using co.itmasters.solucion.vo;
using System.IO;
using System.Web.Services;

namespace co.itmasters.solucion.web.Empresa
{
    public partial class DatosBasicosEmpresa : PageBase
    {
        private CargaCombos _carga = new CargaCombos();
        private EmpresaServiceClient _ActoresService;
        private UserVO user;
        protected void Page_Load(object sender, EventArgs e)
        {

            user = ((UserVO)Session["UsuarioAutenticado"]);
            if (!Page.IsPostBack)
            {
                this.CargaCombos();
                this.CargaDatosBasicos();
            }

        }

        protected void CargaCombos()
        {
            _carga.Cargar(cmbTipDocumento, TipoCombo.CMBTIPIDENTIFICACION);
            _carga.Cargar(cmbTipDocRepl, TipoCombo.CMBTIPIDENTIFICACION);
            _carga.Cargar(CmbSectorEc, TipoCombo.CMBSECTORECONOMICO);
            _carga.Cargar(cmbDepartamento, TipoCombo.CMBDEPRTAMENTO, ("170"));
        }

        protected void CargaDatosBasicos()
        {
            user = ((UserVO)Session["UsuarioAutenticado"]);
            try
            {
                EmpresaVO datosEmpresa = new EmpresaVO();
                datosEmpresa.idUsuario = user.IdUsuario;
                _ActoresService = new EmpresaServiceClient();
                EmpresaVO _resultado = _ActoresService.DatosEmpresa(datosEmpresa);
                _ActoresService.Close();
               
                cmbTipDocumento.SelectedValue = _resultado.idTipoIde.ToString();
                txtNumDocumento.Text = _resultado.numeroIde.ToString();
                txtRazonSocial.Text = _resultado.nomEmpresa.ToString();
                txtDireccion.Text = _resultado.direccion.ToString();
                txtTelContacto.Text = _resultado.telefono.ToString();
                TxtEmail.Text = _resultado.correoElectronico.ToString();
                //Datos del Repsresentante legal
                txtNumDocRepl.Text = _resultado.numIdeRepLegal.ToString();
                txtNomRepLegal.Text = _resultado.nomRepLegal.ToString();
                NumContRepLegal.Text = _resultado.telRepLegal.ToString();


                //VALIDAMOS CAMPOS DE TIPO INT DEPARTAMENTO
                if (_resultado.idDepartamentoEmpresa == null)
                {
                    cmbDepartamento.SelectedValue = "-1";
                }
                else
                {
                    cmbDepartamento.SelectedValue = _resultado.idDepartamentoEmpresa.ToString();
                    this.cmbDepartamento_SelectedIndexChanged(null, null);
                }
                //VALIDAMOS CAMPOS DE TIPO INT CIUDAD
                if (_resultado.idCiudadEmpresa == null)
                {
                    cmbMunicipio.SelectedValue = "-1";
                }
                else
                {
                    cmbMunicipio.SelectedValue = _resultado.idCiudadEmpresa.ToString();
                }
                //VALIDAMOS SECTOR ECONOMICO DE TIPO INT
                if (_resultado.idSectorEconomico == null)
                {
                    CmbSectorEc.SelectedValue = "-1";
                }
                else
                {
                    CmbSectorEc.SelectedValue = _resultado.idSectorEconomico.ToString();
                    this.CmbSectorEc_SelectedIndexChanged(null,null);
                }
                //VALIDAMOS ACTIVIDAD ECONÓMICA DE TIPO INT
                if (_resultado.idActividadEconomica == null)
                {
                    CmbActEco.SelectedValue = "-1";
                }
                else
                {
                    CmbActEco.SelectedValue = _resultado.idActividadEconomica.ToString();
                }
                //VALIDAMOS TIPO DOC REPRESENTANTE LEGAL DE TIPO INT
                if (_resultado.idTipoIdeRepLegal == null)
                {
                    cmbTipDocRepl.SelectedValue = "-1";
                }
                else
                {
                    cmbTipDocRepl.SelectedValue = _resultado.idTipoIdeRepLegal.ToString();
                }
                //deshabilitamos campos de primer registro
                cmbTipDocumento.Enabled = false;
                txtNumDocumento.Enabled = false;
                TxtEmail.Enabled = false;
                if (_resultado.completaDatos == true && user.diligenciaFormulario == 0 )
                {
                    divRepresentanteL.Style["display"] = "none";
                    divDatosGenerales.Style["display"] = "none";
                    divAdjuntos.Style["display"] = "none";
                    divfinal.Style["display"] = "block";

                } else if (_resultado.completaDatos == true && user.diligenciaFormulario == 1)
                {
                    //Estado modificacion de ususario
                    titleFirstWord.InnerText = "Datos";
                    titleSecondWord.InnerText = "básicos empresa";

                    imgDatosBasicosPage1.Src = $".{user.Avatar}";
                    imgDatosBasicosPage1.Attributes.Add("class","avatar");
                    imgDatosBasicosPage2.Visible = false;
                    imgDatosBasicosPage3.Visible = false;
                    
                    btnSiguiente.Visible = false;
                    txtRazonSocial.ReadOnly = true;
                    txtRazonSocial.Enabled = false;
                    
                    
                    btnAtras.Visible = false;
                    btnSiguiente2.Visible = false;

                    btnAtras2.Visible = false;
                    btnFinaliza.Text = "Guardar";

                    divRepresentanteL.Style["display"] = "block";
                    divAdjuntos.Style["display"] ="block" ;
                    labelDivFinal.InnerText = "Datos actualizados exsitosamente";
                    divfinal.Style["display"] = "none";

                    txtRazonSocial.ValidationGroup = "formBasicos";
                    txtRazonSocial.ValidationGroup = "formBasicos";
                    txtNumDocumento.ValidationGroup = "formBasicos";
                    txtNumDocumento.ValidationGroup = "formBasicos";
                    txtDireccion.ValidationGroup = "formBasicos";
                    txtDireccion.ValidationGroup = "formBasicos";
                    txtTelContacto.ValidationGroup = "formBasicos";
                    txtTelContacto.ValidationGroup = "formBasicos";
                    txtTelContacto.ValidationGroup = "formBasicos";
                    txtNumDocRepl.ValidationGroup = "formBasicos";
                    txtNumDocRepl.ValidationGroup = "formBasicos";
                    txtNomRepLegal.ValidationGroup = "formBasicos";
                    txtNomRepLegal.ValidationGroup = "formBasicos";
                    txtFoto.ValidationGroup = "formBasicos";
                    RangeValidator.ValidationGroup = "formBasicos";
                    RangeValidator3.ValidationGroup = "formBasicos";
                    RangeValidator4.ValidationGroup = "formBasicos";
                    RangeValidator1.ValidationGroup = "formBasicos";
                    RangeValidator2.ValidationGroup = "formBasicos";
                    RangeValidator5.ValidationGroup = "formBasicos";
                    RequiredFieldValidator.ValidationGroup = "formBasicos";
                    RequiredFieldValidator1.ValidationGroup = "formBasicos";
                    RequiredFieldValidator2.ValidationGroup = "formBasicos";
                    RequiredFieldValidator3.ValidationGroup = "formBasicos";
                    RequiredFieldValidator4.ValidationGroup = "formBasicos";
                    RequiredFieldValidator5.ValidationGroup = "formBasicos";
                    RequiredFieldValidator6.ValidationGroup = "formBasicos";
                    RequiredFieldValidator7.ValidationGroup = "formBasicos";
                    RequiredFieldValidator8.ValidationGroup = "formBasicos";
                    RequiredFieldValidator9.ValidationGroup = "formBasicos";
                    TxtsubirCamaraComercio.ValidationGroup = "formBasicos";
                    TxtsubirRUT.ValidationGroup = "formBasicos";
                    txtSubirFoto.ValidationGroup = "formBasicos";
                    btnFinaliza.ValidationGroup = "formBasicos";
                }

                if (_resultado.camaraComercio == true)
                {
                    TxtsubirCamaraComercio.Text = "Archivo Cargado";
                    TxtsubirCamaraComercio.Enabled = false;
                }
                if(_resultado.rut == true)
                {
                    TxtsubirRUT.Text = "Archivo Cargado";
                    TxtsubirRUT.Enabled = false;
                }if (user.Avatar.Contains(_resultado.numeroIde.ToString()))
                {
                    txtSubirFoto.Text = "Archivo Cargado";
                    txtSubirFoto.Enabled = false;
                }
                
                
            }
            catch (Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);

            }


        }


        private void UploadFoto()
        {
            try
            {

                if (FileUploadFoto.HasFile)
                {

                    EmpresaVO _empresa = new EmpresaVO();
                    string filename = Path.GetFileName(FileUploadFoto.FileName);
                    FileInfo Info = new FileInfo(filename);
                    int size = (FileUploadFoto.FileBytes).Length;
                    if (Info.Extension == ".jpg" && size < 220000 || Info.Extension == ".JPG" && size < 220000)
                    {

                        if (!System.IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "/Fotos/" + "Empresas"))
                        {
                            System.IO.Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "Fotos\\" + "\\Empresas" + "\\");
                        }
                        FileUploadFoto.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory + "/Fotos/" + "\\Empresas\\" + filename);
                        System.IO.File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "/Fotos/" + "\\Empresas\\" + (txtNumDocumento.Text).TrimStart().TrimEnd() + ".jpg");
                        System.IO.File.Move(System.AppDomain.CurrentDomain.BaseDirectory + "/Fotos/" + "\\Empresas\\" + filename, System.AppDomain.CurrentDomain.BaseDirectory + "/Fotos/" + "\\Empresas\\" + (txtNumDocumento.Text).TrimStart().TrimEnd() + ".jpg");
                        //imgFoto.Src = "../Fotos/" + "/Empresas/" + (txtNumDocumento.Text).TrimStart().TrimEnd() + ".jpg";
                        txtFoto.Text = "/Fotos/Empresas/" + (txtNumDocumento.Text).TrimStart().TrimEnd() + ".jpg";
                        lblFoto.Visible = true;
                    }
                    else
                    {
                        Master.mostrarMensaje("La foto no cumple con los parametros establecidos, debe ser formato jpg y no mayor a  200Kb", Master.ERROR);
                    }


                }
                else if(txtSubirFoto.Text == "")
                {
                    Master.mostrarMensaje("Archivo no existe, por favor intente nuevamente.", Master.ERROR);

                }
            }
            catch (Exception)
            {
                Master.mostrarMensaje("Error cargando la foto, por favor intente nuevamente.", Master.ERROR);
            }
        }
        private void UploadCC()
        {
            try
            {

                if (FileUploadCamara.HasFile)
                {
                    EmpresaVO _empresa = new EmpresaVO();
                    string filename = Path.GetFileName(FileUploadCamara.FileName);
                    FileInfo Info = new FileInfo(filename);
                    int size = (FileUploadCamara.FileBytes).Length;
                    if (Info.Extension == ".pdf" && size < 5200000)
                    {
                        if (!System.IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "/DocsEmpresa/" + "Legalizacion"))
                        {
                            System.IO.Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "DocsEmpresa\\" + "\\Legalizacion" + "\\");
                        }
                        FileUploadCamara.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory + "/DocsEmpresa/" + "\\Legalizacion\\" + filename);
                        System.IO.File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "/DocsEmpresa/" + "\\Legalizacion\\" + (txtNumDocumento.Text).TrimStart().TrimEnd() + "_CC.pdf");
                        System.IO.File.Move(System.AppDomain.CurrentDomain.BaseDirectory + "/DocsEmpresa/" + "\\Legalizacion\\" + filename, System.AppDomain.CurrentDomain.BaseDirectory + "/DocsEmpresa/" + "\\Legalizacion\\" + (txtNumDocumento.Text).TrimStart().TrimEnd() + "_CC.pdf");
                        lblSubirCaCo.Text = "Documento Camara de Comercio cargado exitósamente";
                        TxtsubirCamaraComercio.Text = "Archivo Cargado exitosamente";
                        lblSubirCaCo.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        Master.mostrarMensaje("El documento CAMARA Y COMERCIO no cumple con los parametros establecidos, debe ser formato pdf y no mayor a  30Mb", Master.ERROR);
                        lblSubirCaCo.Text = "Adjuntar documento de cámara de comercio";
                        TxtsubirCamaraComercio.Text = "";
                        lblSubirCaCo.ForeColor = System.Drawing.Color.Black;

                    }
                }
                else if(TxtsubirCamaraComercio.Text == null)

                {
                    Master.mostrarMensaje("Archivo no existe, por favor intente nuevamente.", Master.ERROR);
                    lblSubirCaCo.Text = "Adjuntar documento de cámara de comercio";
                    TxtsubirCamaraComercio.Text = "";
                    lblSubirCaCo.ForeColor = System.Drawing.Color.Black;
                }
            }
            catch
            {

                lblSubirCaCo.Text = "Adjuntar documento de cámara de comercio";
                TxtsubirCamaraComercio.Text = "";
                lblSubirCaCo.ForeColor = System.Drawing.Color.Black;
                throw new Exception("Error cargando el archivo de Camara de Comercio, intentelo nuevamente");

            }
        }
        private void UploadRUT()
        {
            try
            {
                if (FileUploadRut.HasFile)
                {
                    EmpresaVO _empresa = new EmpresaVO();
                    string filename = Path.GetFileName(FileUploadRut.FileName);
                    FileInfo Info = new FileInfo(filename);
                    int size = (FileUploadRut.FileBytes).Length;
                    if (Info.Extension == ".pdf" && size < 5200000)
                    {
                        if (!System.IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "/DocsEmpresa/" + "Legalizacion"))
                        {
                            System.IO.Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "DocsEmpresa\\" + "\\Legalizacion" + "\\");
                        }
                        FileUploadRut.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory + "/DocsEmpresa/" + "\\Legalizacion\\" + filename);
                        System.IO.File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "/DocsEmpresa/" + "\\Legalizacion\\" + (txtNumDocumento.Text).TrimStart().TrimEnd() + "_RUT.pdf");
                        System.IO.File.Move(System.AppDomain.CurrentDomain.BaseDirectory + "/DocsEmpresa/" + "\\Legalizacion\\" + filename, System.AppDomain.CurrentDomain.BaseDirectory + "/DocsEmpresa/" + "\\Legalizacion\\" + (txtNumDocumento.Text).TrimStart().TrimEnd() + "_RUT.pdf");
                        lblSubirRUT.Text = "Documento RUT cragado Exitósamente";
                        TxtsubirRUT.Text = "Documento Cargado";
                        lblSubirRUT.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        Master.mostrarMensaje("El documento RUT no cumple con los parametros establecidos, debe ser formato pdf y no mayor a  30Mb", Master.ERROR);
                        lblSubirRUT.Text = "Adjuntar documento RUT";
                        TxtsubirRUT.Text = "";
                        lblSubirRUT.ForeColor = System.Drawing.Color.Black;
                    }
                }
                else if(TxtsubirRUT.Text == "")
                {
                    Master.mostrarMensaje("Archivo no existe, por favor intente nuevamente.", Master.ERROR);
                    lblSubirRUT.Text = "Adjuntar documento RUT";
                    TxtsubirRUT.Text = "";
                    lblSubirRUT.ForeColor = System.Drawing.Color.Black;
                }


            }
            catch (Exception)
            {
                lblSubirRUT.Text = "Adjuntar documento RUT";
                TxtsubirRUT.Text = "";
                lblSubirRUT.ForeColor = System.Drawing.Color.Black;
                throw new Exception("Error cargando el RUT, por favor intentelo nuevamente");
            }
        }

        protected void guardadatosempresa(int fase)
        {
            user = ((UserVO)Session["UsuarioAutenticado"]);
            try
            {
                EmpresaVO datosEmpresa = new EmpresaVO();
                datosEmpresa.idUsuario = user.IdUsuario;
                datosEmpresa.fase = fase;
                datosEmpresa.nomEmpresa = txtRazonSocial.Text;
                datosEmpresa.idTipoIde = Convert.ToInt32(cmbTipDocumento.SelectedValue);
                datosEmpresa.numeroIde = txtNumDocumento.Text;
                datosEmpresa.idSectorEconomico = Convert.ToInt32(CmbSectorEc.SelectedValue);
                datosEmpresa.idActividadEconomica = Convert.ToInt32(CmbActEco.SelectedValue);
                datosEmpresa.idDepartamentoEmpresa = Convert.ToInt32(cmbDepartamento.SelectedValue);
                datosEmpresa.idCiudadEmpresa = Convert.ToInt32(cmbMunicipio.SelectedValue);
                datosEmpresa.direccion = txtDireccion.Text;
                datosEmpresa.telefono = txtTelContacto.Text;
                //datos Representante legal
                if (fase == 1 && user.diligenciaFormulario == 0)
                {
                    datosEmpresa.idTipoIdeRepLegal = null;
                    datosEmpresa.numIdeRepLegal = null;
                    datosEmpresa.nomRepLegal = null;
                    datosEmpresa.telRepLegal = null;
                }
                else
                {
                    datosEmpresa.idTipoIdeRepLegal = Convert.ToInt32(cmbTipDocRepl.SelectedValue);
                    datosEmpresa.numIdeRepLegal = Convert.ToInt32(txtNumDocRepl.Text);
                    datosEmpresa.nomRepLegal = txtNomRepLegal.Text;
                    datosEmpresa.telRepLegal = NumContRepLegal.Text;

                }
                //datos Representante legal
                if (fase == 1 && user.diligenciaFormulario == 0 || fase == 2 && user.diligenciaFormulario == 0)
                {
                    datosEmpresa.camaraComercio = false;
                    datosEmpresa.rut = false;

                }
                else
                {
                    datosEmpresa.camaraComercio = true;
                    datosEmpresa.rut = true;

                }
                datosEmpresa.rutaAvatar = txtFoto.Text;
                _ActoresService = new EmpresaServiceClient();
                _ActoresService.GuardarDatosEmpresa(datosEmpresa);
                _ActoresService.Close();

            }
            catch (Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);

            }
        }
        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            divRepresentanteL.Style["display"] = "block";
            divDatosGenerales.Style["display"] = "none";
            divAdjuntos.Style["display"] = "none";
            UploadFoto();
            this.guardadatosempresa(1);


        }
        protected void btnSiguiente2_Click(object sender, EventArgs e)
        {
            divRepresentanteL.Style["display"] = "none";
            divDatosGenerales.Style["display"] = "none";
            divAdjuntos.Style["display"] = "block";
            this.guardadatosempresa(2);
        }
        protected void btnAtras_Click(object sender, EventArgs e)
        {
            divRepresentanteL.Style["display"] = "none";
            divDatosGenerales.Style["display"] = "block";
        }
        protected void btnAtras2_Click(object sender, EventArgs e)
        {
            divRepresentanteL.Style["display"] = "block";
            divDatosGenerales.Style["display"] = "none";
            divAdjuntos.Style["display"] = "none";
            divfinal.Style["display"] = "none";
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            divRepresentanteL.Style["display"] = "none";
            divDatosGenerales.Style["display"] = "none";
            divAdjuntos.Style["display"] = "none";
            titleFirstWord.Style["display"] = "none";
            titleSecondWord.Style["display"] = "none";
            this.guardadatosempresa(3);
            Master.OcultarBanda();
            try
            {
                UploadCC();
                UploadRUT();
            }
            catch (Exception err)
            {
                Master.mostrarMensaje(err.Message, Master.ERROR);
            }
            divfinal.Style["display"] = "block";
        }

        protected void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            _carga.Cargar(cmbMunicipio, TipoCombo.CMBPROVINCIA, (cmbDepartamento.SelectedValue));
        }
        protected void CmbSectorEc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbSectorEc.SelectedValue != "-1")
            {
                //_carga.Cargar(cmbMunicipio, TipoCombo.CMBPROVINCIA, (cmbDepartamento.SelectedValue));
                _carga.Cargar(CmbActEco, TipoCombo.CMBACTIVIDADECONOMICA, (CmbSectorEc.SelectedValue));
            }
            else
            {
                CmbActEco.SelectedValue = "-1";
            }

        }

    
       
    }
}