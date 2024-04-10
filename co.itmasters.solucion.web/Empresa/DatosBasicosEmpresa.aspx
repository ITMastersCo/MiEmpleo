<%@ Page Title="" Language="C#" MasterPageFile="~/ITMasters.Master" AutoEventWireup="true" 
    CodeBehind="DatosBasicosEmpresa.aspx.cs" Inherits="co.itmasters.solucion.web.Empresa.DatosBasicosEmpresa" %>

<%@ MasterType VirtualPath="../ITMasters.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="Main" runat="server">
    <asp:UpdatePanel ID="InfEmpresa" runat="server">
        <ContentTemplate>
    <script type="text/javascript">
        function validateEmail() {

            // Get our input reference.
            var emailField = document.getElementById('TxtEmail');

            // Define our regular expression.
            var validEmail = /^\w+([.-_+]?\w+)*@\w+([.-]?\w+)*(\.\w{2,10})+$/;

            // Using test we can check if the text match the pattern
            if (validEmail.test(emailField.value)) {

                return true;
            } else {
                alert('El correo electrónico no es válido.');
                document.getElementById("TxtEmail").value = "";
                return false;
            }
        }

    </script>

    <asp:ValidationSummary ID="ValidationSummary" runat="server" ValidationGroup="DatosG" Font-Bold="True" ForeColor="#CC0000" CssClass="text-normal" />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="DatosRl" Font-Bold="True" ForeColor="#CC0000" CssClass="text-normal"/>
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="Subir" Font-Bold="True" ForeColor="#CC0000" CssClass="text-normal"/>

    <div class="h-group" style="align-items: center">
        <h1"><span class="text-subtitle text-highlighted" runat="server" id="titleFirstWord">Formulario </span> <span  class="text-subtitle" runat="server" id="titleSecondWord">de registro de empresas.</span></h1>
        <br />


    </div>

    <div id="divDatosGenerales" runat="server" style="display: block; align-content: center">
        <div class="gridContainer">
            <a href="#">
                <%-- Imagen Perfil o Registro --%>
                <img runat="server" id="imgDatosBasicosPage1" class="img" src="../images/empresas1_2.png" alt="" />

            </a>
        </div>
        <div class="h-group" style="align-items: center">
            <span class="text-bold text-highlighted">1. Datos Generales</span>
            <br />
            <br />
        </div>
        <section class="flex flex-col gap-16">

            <div class="grid-auto-cols">
                <div class ="grid-auto-cols " style="align-items:center;">
                <asp:Label ID="lblRazonSocial" runat="server" Text="Razón social / Persona Natural" CssClass="text-bold text-left items-center"></asp:Label>
                <asp:TextBox ID="txtRazonSocial" CssClass="text-box" runat="server" ToolTip="Digite el nombre de la empresa a registrar" placeholder="Nombre de la empresa a registrar"></asp:TextBox>
                </div>

                <div class ="grid-auto-cols">
                 <asp:Label ID="Label5" runat="server" Text="Foto de perfil"  CssClass="text-bold text-left">
                 </asp:Label>

                    <div class="flex flex-col gap-4 flex-center">

                <asp:Label ID="Label40" runat="server" Text="" ToolTip="Seleccione archivo a cargar, recuerde que tiene que ser un arhivo en jpg y que su tamaño no sea mayor  a 200 kb" CssClass="file-upload"
                    AssociatedControlID="FileUploadFoto">
                    <asp:FileUpload ID="FileUploadFoto" runat="server" CssClass="" onchange="setFileName(event)"/>
                    <span>Seleccionar
                     <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                         <path stroke-linecap="round" stroke-linejoin="round" d="M4 16v1a3 3 0 003 3h10a3 3 0 003-3v-1m-4-8l-4-4m0 0L8 8m4-4v12" />
                     </svg>
                    </span>
                </asp:Label>
                    <asp:Button ID="btnSubirFoto" runat="server" Text="Subir Foto de perfil   " CssClass="button text-bold" OnClick="subirfoto_Click"  />
                    </div>
                </div>
            </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="txtRazonSocial" ErrorMessage="Digite el nombre de la empresa a registrar." ValidationGroup="DatosG" ForeColor="#CC0000" CssClass="required-field-validator">*</asp:RequiredFieldValidator>
            <div class="gridContainer">
                <asp:Label ID="lblFoto" runat="server" CssClass="text-normal" Visible="false" Text="Foto cargada exitósamente" ForeColor="Green"></asp:Label>
            </div>
            <div class="grid-auto-cols">
                <asp:Label ID="lblTipDocu" runat="server" Text="Tipo de documento" CssClass="text-bold text-left items-center">
                    <asp:RangeValidator ID="RangeValidator" runat="server" ControlToValidate="cmbTipDocumento" ForeColor="#CC0000" CssClass="text" ErrorMessage="Seleccione el típo de documento de la empresa o persona natural" MaximumValue="10" MinimumValue="0" Type="Integer" ValidationGroup="DatosG">*</asp:RangeValidator></asp:Label>
                <asp:DropDownList ID="cmbTipDocumento" ToolTip="Seleccione el típo de documento de la empresa o persona natural" runat="server" CssClass="drop-down-list"></asp:DropDownList>
                <asp:Label ID="Label6" runat="server" Text="Número de documento" CssClass="text-bold text-left items-center">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumDocumento" ErrorMessage="Digite el documento de empresa / Persona natural" ValidationGroup="DatosG" ForeColor="#CC0000" CssClass="text">*</asp:RequiredFieldValidator></asp:Label>
                <asp:TextBox ID="txtNumDocumento" CssClass="text-box" runat="server" ToolTip="Documento de empresa / Persona natural" placeholder="Documento de empresa / Persona natural"></asp:TextBox>
            </div>


            <div class="grid-auto-cols">
                <asp:Label ID="LblDepartamento" runat="server" Text="Departamento" CssClass="text-bold text-left">
                    <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="cmbDepartamento" ErrorMessage="Seleccione el departamento donde se encuentra ubicada la sede principal de la empresa." ForeColor="#CC0000" CssClass="text" MaximumValue="10000000" MinimumValue="0" Type="Integer" ValidationGroup="DatosG">*</asp:RangeValidator></asp:Label>
                <updatepanel id="Updatepanel1" runat="server">
                    <contenttemplate>
                        <asp:DropDownList ID="cmbDepartamento" runat="server" ToolTip="Seleccione el departamento donde se encuentra ubicada la sede principal de la empresa" AutoPostBack="true" CssClass="drop-down-list" OnSelectedIndexChanged="cmbDepartamento_SelectedIndexChanged"></asp:DropDownList>
                    </contenttemplate>
                </updatepanel>
                <asp:Label ID="LblMunicipio" runat="server" Text="Municipio" CssClass="text-bold text-left">
                    <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="cmbMunicipio" ErrorMessage="Seleccione el municipio o ciudad donde se encuentra ubicada la sede principal de la empresa." ForeColor="#CC0000" CssClass="text" MaximumValue="170990773" MinimumValue="0" Type="Integer" ValidationGroup="DatosG">*</asp:RangeValidator></asp:Label>
                <UpdatePanel id="updateDepartamento" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbMunicipio" runat="server" ToolTip="Seleccione el municipio o ciudad donde se encuentra ubicada la sede principal de la empresa" CssClass="drop-down-list"></asp:DropDownList>
                    </ContentTemplate>
                </UpdatePanel>
            </div>



            <div class="grid-auto-cols">
                <asp:Label ID="Label1" runat="server" Text="Dirección de notificación" CssClass="text-bold text-left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDireccion" ErrorMessage="Digite la dirección de la sede principal de la empresa." ValidationGroup="DatosG" ForeColor="#CC0000" CssClass="text">*</asp:RequiredFieldValidator></asp:Label>
                <div>

                <asp:TextBox ID="txtDireccion" CssClass="text-box" ToolTip="Digite la dirección de la sede principal de la empresa" TextMode="SingleLine" placeholder="Dirección de notificación" runat="server"></asp:TextBox>
                </div>
                <asp:Label ID="Label2" runat="server" Text="Teléfono de contacto" CssClass="text-bold text-left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTelContacto" ErrorMessage="Digite el teléfono de contacto del representante legal." ValidationGroup="DatosG" ForeColor="#CC0000" CssClass="text">*</asp:RequiredFieldValidator></asp:Label>
                <div class ="flex flex-col gap-4">

                <asp:TextBox ID="txtTelContacto" CssClass="text-box" ToolTitxtTelContactop="Digite el teléfono de la sede principal de la empresa" TextMode="Number" placeholder="Teléfono de contacto" runat="server" ValidationGroup="DatosG"></asp:TextBox>
                <asp:RegularExpressionValidator ErrorMessage="Número no valido" 
                    ControlToValidate="txtTelContacto" 
                    runat="server" 
                    ValidationExpression="^[0-9]{7}$|^[0-9]{10}$" 
                    CssClass="required-field-validator"
                    ValidationGroup="DatosG"
                    />
                </div>
            </div>
            
            <div class="flex flex-col" >
                <asp:Label ID="LblSectoEco" runat="server" Text="Sector económico" CssClass="text-bold text-w text-left items-center" Style="width: 30%;">
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="CmbSectorEc"
                        ErrorMessage="Seleccione el sector económico a la  que pertenece la empresa."
                        ForeColor="#CC0000" CssClass="text" MaximumValue="10000000"
                        MinimumValue="0" Type="Integer" ValidationGroup="DatosG">*</asp:RangeValidator></asp:Label>
                <asp:DropDownList ID="CmbSectorEc"
                    ToolTip="Seleccione el sector económico a la  que pertenece la empresa" runat="server" CssClass="drop-down-list option-small"
                    OnSelectedIndexChanged="CmbSectorEc_SelectedIndexChanged" AutoPostBack="true" Style="grid-column: span 2 / span 2;">
                </asp:DropDownList>
            </div>
                <div class="flex flex-col">

                <asp:Label ID="LblActEco" runat="server" Text="Actividad económica" CssClass="text-bold text-left items-center" style ="width:30%;">
                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="CmbActEco" ErrorMessage="Seleccione la actividad principal en la  que pertenece la empresa." ForeColor="#CC0000" CssClass="text" MaximumValue="10000000" MinimumValue="0" Type="Integer" ValidationGroup="DatosG">*</asp:RangeValidator></asp:Label>
                <asp:DropDownList ID="CmbActEco"
                    runat="server" 
                    ToolTip="Seleccione la actividad principal en la  que pertenece la empresa" 
                    CssClass="drop-down-list option-small"  style="grid-column: span 2 / span 2;"></asp:DropDownList>
            </div>

            <div class="grid-auto-cols">
                <asp:Label ID="Label3" runat="server" Text="Correo de contacto" CssClass="text-bold text-left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtEmail" ErrorMessage="Digite un correo válido." ValidationGroup="DatosG" ForeColor="#CC0000" CssClass="text">*</asp:RequiredFieldValidator></asp:Label>

                <asp:TextBox ID="TxtEmail"  CssClass="text-box " ToolTip="Digite el correo electrónico de contacto de la empresa" TextMode="Email" placeholder="Correo" runat="server" onblur="validateEmail()"></asp:TextBox>


            </div>
            

            <div style="align-items: center">
                <asp:Button ID="btnSiguiente" runat="server" Text="Continuar" ValidationGroup="DatosG" CssClass="button text-normal" OnClick="btnSiguiente_Click"  />
            </div>
            <br />

        </section>
    </div>
    <div id="divRepresentanteL" runat="server" style="display: none">
        <a href="#">
            <img class="img" runat="server" id="imgDatosBasicosPage2" src="../images/empesas2_1.png" alt=""/>

        </a>
        <div class="h-group" style="align-items: center">
            <span class="text-bold text-highlighted">2. Datos de representante legal</span>
            <br />
            <br />

        </div>
        <div class="grid-auto-cols">
            <asp:Label ID="Label7" runat="server" Text="Tipo de documento" CssClass="text-bold text-left">
                <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="cmbTipDocRepl" ForeColor="#CC0000" CssClass="text" ErrorMessage="Seleccione el típo de documento del representante legal." MaximumValue="100" MinimumValue="0" Type="Integer" ValidationGroup="DatosRl">*</asp:RangeValidator></asp:Label>
            <asp:DropDownList ID="cmbTipDocRepl" ToolTip="Seleccione el típo de documento del representante legal" runat="server" CssClass="drop-down-list"></asp:DropDownList>
            <asp:Label ID="Label8" runat="server" Text="Número de documento" CssClass="text-bold text-left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtNumDocRepl" ErrorMessage="Digite el documento de empresa / Persona natural" ValidationGroup="DatosRl" ForeColor="#CC0000" CssClass="text">*</asp:RequiredFieldValidator></asp:Label>
            <asp:TextBox ID="txtNumDocRepl" CssClass="text-box" runat="server" TextMode="Number" ToolTip="Digite el número del documento del representante legal" placeholder="Número del documento del representante legal"></asp:TextBox>
        </div>
        <br />

        <div class="grid-auto-cols">
            <asp:Label ID="Label10" runat="server" Text="Nombre representante legal" CssClass="text-bold text-left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNomRepLegal" ErrorMessage="Digite el documento de empresa / Persona natural" ValidationGroup="DatosRl" ForeColor="#CC0000" CssClass="text">*</asp:RequiredFieldValidator></asp:Label>
            <asp:TextBox ID="txtNomRepLegal" CssClass="text-box" runat="server" ToolTip="Diligencie el nombre del respresentante legal" placeholder="Diligencie el nombre del respresentante legal"></asp:TextBox>
            <asp:Label ID="Label9" runat="server" Text="Número de contacto" CssClass="text-bold text-left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="NumContRepLegal" ErrorMessage="Digite el documento de empresa / Persona natural" ValidationGroup="DatosRl" ForeColor="#CC0000" CssClass="text">*</asp:RequiredFieldValidator></asp:Label>
            <asp:TextBox ID="NumContRepLegal" CssClass="text-box" runat="server" ToolTip="Diligencie el contacto del representante legal" TextMode="Number" placeholder="Contacto del representante legal"></asp:TextBox>
        </div>
        <br />

        <div style="align-items: center; align-content: center">
            <asp:Button ID="btnAtras" runat="server" Text="Atras" CssClass="button text-normal" OnClick="btnAtras_Click" />
            <asp:Button ID="btnSiguiente2" runat="server" Text="Continuar" ValidationGroup="DatosRl" CssClass="button text-normal" OnClick="btnSiguiente2_Click" />
        </div>
    </div>
    <div id="divAdjuntos" runat="server" style="display: none">
        <a href="#">
            <img class="img" runat="server" id="imgDatosBasicosPage3" src="../images/empresas3_1.png" alt=""></a>
        <div class="h-group" style="align-items: center">
            <span class="text-bold text-highlighted">3. Requisitos para aprobación</span>
            <br />
            <br />

        </div>

        <div class="grid-auto-cols">
            <asp:Label ID="lblSubirCaCo" runat="server" Text="Adjuntar documento de cámara de comercio" CssClass="text-bold text-left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TxtsubirCamaraComercio" ErrorMessage="Debe adjuntar documento de cámara de comercio" ValidationGroup="Subir" ForeColor="#CC0000" CssClass="text">*</asp:RequiredFieldValidator></asp:Label>
            <div class ="flex flex-col gap-4 flex-center">

            <asp:Label ID="lblSubirCamaraComercio" runat="server" Text="" ToolTip="Solo permite subir documentos en formato PDF mo mayor a 10MB" CssClass="file-upload"
                AssociatedControlID="FileUploadCamara">
                <asp:FileUpload ID="FileUploadCamara" runat="server" CssClass="" onchange="setFileName(event)" />
                <span>Seleccionar
                     <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
             <path stroke-linecap="round" stroke-linejoin="round" d="M4 16v1a3 3 0 003 3h10a3 3 0 003-3v-1m-4-8l-4-4m0 0L8 8m4-4v12" />
         </svg>
                </span>
            </asp:Label>

            <asp:Button ID="btnsubirCC" runat="server" Text="Subir documento" CssClass="button text-normal" OnClick="subirCC_Click" />
            </div>

            <asp:Label ID="lblSubirRUT" runat="server" Text="Adjuntar documento RUT " CssClass="text-bold text-left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TxtsubirRUT" ErrorMessage="Debe adjuntar documento RUT " ValidationGroup="Subir" ForeColor="#CC0000" CssClass="text">*</asp:RequiredFieldValidator></asp:Label>
            <div class="flex flex-col gap-4 flex-center">

            <asp:Label ID="LblRUT" runat="server" Text="" ToolTip="Solo permite subir documentos en formato PDF mo mayor a 10MB" CssClass="file-upload"
                AssociatedControlID="FileUploadRut">
                <asp:FileUpload ID="FileUploadRut" runat="server" CssClass="" onchange="setFileName(event)" />
                <span>Seleccionar
         <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
             <path stroke-linecap="round" stroke-linejoin="round" d="M4 16v1a3 3 0 003 3h10a3 3 0 003-3v-1m-4-8l-4-4m0 0L8 8m4-4v12" />
         </svg>
                </span>
            </asp:Label>
            <asp:Button ID="btnSubirRUT" runat="server" Text="Subir documento" CssClass="button text-normal" OnClick="subirRUT_Click" />
            </div>

        </div>
        <br />
        <div style="align-items: center; align-content: center">
            <asp:Button ID="btnAtras2" runat="server" Text="Atras" CssClass="button text-normal" OnClick="btnAtras2_Click" />
            <asp:Button ID="btnFinaliza" runat="server" Text="Finalizar" ValidationGroup="Subir" CssClass="button text-normal" OnClick="btnGuardar_Click" />
        </div>
        <div style="display: none">
            <asp:TextBox ID="TxtsubirRUT" runat="server" Text=""></asp:TextBox>
            <asp:TextBox ID="TxtsubirCamaraComercio" runat="server" Text=""></asp:TextBox>
            <asp:TextBox ID="txtFoto" runat="server" Text=""></asp:TextBox>
        </div>
    </div>
    <div id="divfinal" runat="server" style="display: none">
                <section class="banner"> 
            <div class="info-banner">
                <h2 class="text-title" runat="server" id="labelDivFinal">
                    ¡Gracias por completar los datos <span class="text-highlighted text-title"> estaremos  validando tus datos</span> para ser parte de miempleo.co!
                </h2>
                
            </div>
                        
        </section>
 

    </div>
</ContentTemplate>
         <Triggers>
            <asp:PostBackTrigger ControlID="btnSubirFoto" />
             <asp:PostBackTrigger ControlID="btnsubirCC" />
             <asp:PostBackTrigger ControlID="btnSubirRUT" />
        </Triggers>
        </asp:UpdatePanel>

    <script>
        function setFileName(e) {
            const file = e.target.files[0];
            const htmlSpan = e.target.parentNode.querySelector('span')
            htmlSpan.innerText= file?.name
        }
    </script>
</asp:Content>