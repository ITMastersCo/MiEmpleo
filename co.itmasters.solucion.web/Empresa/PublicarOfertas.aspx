<%@ Page Title="Publicar Ofertas" Language="C#" MasterPageFile="~/ITMasters.Master" AutoEventWireup="true" CodeBehind="PublicarOfertas.aspx.cs" Inherits="co.itmasters.solucion.web.Empresa.PublicarOfertas" %>

<%@ MasterType VirtualPath="../ITMasters.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">
          <script type="text/javascript">
              function showModal2() {
                  document.getElementById('Main_openModal2').style.display = 'flex';
              }
              function CloseModal2() {
                  document.getElementById('Main_openModal2').style.display = 'none';
              }
              function showModal() {
                  document.getElementById('Main_openModal').style.display = 'flex';
              }
              function CloseModal() {
                  document.getElementById('Main_openModal').style.display = 'none';
              }

          </script>
    <style type="text/css">
        .modalDialog {
            position: fixed;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            background: rgba(153,153,153,0.8);
            z-index: 99999;
            display: none;
            -webkit-transition: opacity 100ms ease-in;
            -moz-transition: opacity 100ms ease-in;
            transition: opacity 100ms ease-in;
            pointer-events: auto;
        }

            .modalDialog > div {
                width: 80%;
                height: max-content;
                position: relative;
                margin: 10% auto;
                padding: 10px 10px 10px 10px;
                border-radius: 10px;
                /*contorno de la ventana*/
                background: -o-linear-gradient(#fff, #fff);
                background: -moz-linear-gradient(#fff, #fff);
                background: -webkit-linear-gradient(#fff, #fff);
                background: -o-linear-gradient(#fff, #fff);
                -webkit-transition: opacity 100ms ease-in;
                -moz-transition: opacity 100ms ease-in;
                transition: opacity 100ms ease-in;
            }

        .closed {
            /*background: red;*/
            line-height: 20px;
            position: center;
            bottom: 12px;
            left: 60px;
            text-align: center;
            width: 44px;
            height: 20px;
            font-size: large;
            opacity: 1;
        }

            .closed:hover {
                background: white;
            }

        .auto-style1 {
            color: #FFFFFF;
            font-size: large;
        }
    </style>
 
    <asp:ValidationSummary ID="ValidationSummary" runat="server" ValidationGroup="Oferta" Font-Bold="True" ForeColor="#CC0000" CssClass="text-normal" />
    <asp:UpdatePanel runat="server" ID="Oferta">
        <ContentTemplate>

            <a id="home" runat="server"></a>
            <h1 class="text-subtitle color-gray-800">Formulario de
                <span class="text-subtitle color-orange-500">oferta</span>
                laboral
            </h1>
            <div class="form-column min-w-80per flex-col flex-center " id="Formulario" runat="server">
                <asp:Label ID="lblTituloVacante" runat="server" Text="Título de la vacante"
                    AssociatedControlID="txtTituloVacante"
                    CssClass="text-title-section text-medium color-gray-700 flex-col gap-4 w-100per item-center max-w-850px ">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="txtTituloVacante" ErrorMessage="Digite el título de la vacante." ValidationGroup="Oferta" ForeColor="#CC0000" CssClass="text">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator 
                        ErrorMessage="Demasiados caracteres. Maxímo 100." 
                        ControlToValidate="txtTituloVacante" 
                        runat="server" 
                        CssClass="required-field-validator"    
                        ValidationGroup ="Oferta"
                        ValidationExpression="^.{0,100}$" />
                        
                    <asp:TextBox ID="txtTituloVacante" runat="server" CssClass="text-box"
                        placeholder="Breve denominación del puesto de trabajo">
                    </asp:TextBox>
                </asp:Label>
                <asp:Label ID="lblDescripcionVacante" runat="server" Text="Descripción de vacante"
                    AssociatedControlID="txtDescripcionVacante"
                    CssClass="text-title-section text-medium color-gray-700 flex-col gap-4 w-100per item-center max-w-850px ">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescripcionVacante" ErrorMessage="Digite la descripción de la vacante." ValidationGroup="Oferta" ForeColor="#CC0000" CssClass="text">*</asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator 
                      ErrorMessage="Demasiados caracteres. Maxímo 6000" 
                      ControlToValidate="txtDescripcionVacante" 
                      runat="server" 
                      CssClass="required-field-validator"    
                      ValidationGroup ="Oferta"
                      ValidationExpression="^.{0,6000}$" />
                    <asp:TextBox ID="txtDescripcionVacante" runat="server" TextMode="MultiLine" CssClass="text-area" Height="150px"
                        placeholder="Información detallada del perfil de la vacante">
                    </asp:TextBox>
                </asp:Label>
                <asp:Label ID="lblTiempoExperiencia" runat="server" Text="Tiempo de experiencia"
                    AssociatedControlID="cmbTiempoExperiencia"
                    CssClass="text-title-section text-medium color-gray-700 flex-col gap-4 w-100per item-center max-w-850px ">
                    <asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="cmbTiempoExperiencia" ForeColor="#CC0000" CssClass="text" ErrorMessage="Seleccione el tiempo de experiencia a la oferta." MaximumValue="10000000" MinimumValue="0" Type="Integer" ValidationGroup="Oferta">*</asp:RangeValidator>
                    <asp:DropDownList ID="cmbTiempoExperiencia" runat="server" CssClass="text-box"></asp:DropDownList>
                </asp:Label>
                <asp:Label ID="lblCantidadVacantes" runat="server" Text="Cantidad de vacantes"
                    AssociatedControlID="txtCantidadVacantes"
                    CssClass="text-title-section text-medium color-gray-700 flex-col gap-4 w-100per item-center max-w-850px ">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCantidadVacantes" ErrorMessage="Digite la cantidades de vacantes." ValidationGroup="Oferta" ForeColor="#CC0000" CssClass="text">*</asp:RequiredFieldValidator>

                    <asp:TextBox ID="txtCantidadVacantes" runat="server" CssClass="text-box" TextMode="Number"
                        placeholder="Número de vacantes de desea suplir">
                    </asp:TextBox>
                </asp:Label>
                <asp:Label ID="lblCargo" runat="server" Text="Cargo"
                    AssociatedControlID="txtCargo"
                    CssClass="text-title-section text-medium color-gray-700 flex-col gap-4 w-100per item-center max-w-850px ">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCargo" ErrorMessage="Digite la descripción del cargo." ValidationGroup="Oferta" ForeColor="#CC0000" CssClass="text">*</asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator 
                     ErrorMessage="Demasiados caracteres. Maxímo 100." 
                     ControlToValidate="txtCargo" 
                     runat="server" 
                     CssClass="required-field-validator"    
                     ValidationGroup ="Oferta"
                     ValidationExpression="^.{0,100}$" />
                    <asp:TextBox ID="txtCargo" runat="server" CssClass="text-box" 
                        placeholder="Digite el cargo que va a desempeñar el candidato." >
                    </asp:TextBox>
                </asp:Label>
                
                <asp:Label ID="lblFechaPublicación" runat="server" Text="Fecha de Publicación"
                    AssociatedControlID="txtFechaPublicacion" 
                    CssClass="text-title-section text-medium color-gray-700 flex-col gap-4 w-100per item-center max-w-850px  ">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFechaPublicacion" ErrorMessage="Seleccione la fecha de publicación" ValidationGroup="Oferta" ForeColor="#CC0000" CssClass="text">*</asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtFechaPublicacion" runat="server" CssClass="text-box" AutoPostBack="true"
                         TextMode="Date" OnTextChanged="txtFechaPublicacion_TextChanged" > 
                    </asp:TextBox>
                    <asp:RangeValidator CssClass="required-field-validator" runat="server" ID="rvFechaPublicacion"  errormessage="No puede superar la fecha de vencimiento del plan" Type="Date"
                        controltovalidate="txtFechaPublicacion" />
                </asp:Label>
                <asp:Label Text="" runat="server" ID="lblDiasOferta" Visible="false"/>
                <asp:Label ID="lblFechaVencimiento" runat="server" Text="Fecha de Vencimiento"
                    AssociatedControlID="txtFechaVencimiento"
                    CssClass="text-title-section text-medium color-gray-700 flex-col gap-4 w-100per item-center max-w-850px ">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFechaVencimiento" ErrorMessage="Seleccione la fecha de vencimiento." ValidationGroup="Oferta" ForeColor="#CC0000" CssClass="text">*</asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtFechaVencimiento" runat="server" CssClass="text-box"
                        TextMode="Date" >
                    </asp:TextBox>
                     <asp:RangeValidator CssClass="required-field-validator" runat="server" ID="rvFechaVencimiento" errormessage="No puede superar la fecha de vencimiento del plan" Type="Date"
                        controltovalidate="txtFechaVencimiento"  />
                </asp:Label>
                <asp:Label ID="lblNivelEstudiosRequeridos" runat="server" Text="Nivel de estudios requeridos"
                    AssociatedControlID="cmbNivelEstudiosRequeridos"
                    CssClass="text-title-section text-medium color-gray-700 flex-col gap-4 w-100per item-center max-w-850px ">
                    <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="cmbNivelEstudiosRequeridos" ForeColor="#CC0000" CssClass="text" ErrorMessage="Seleccione el nivel de estudios a la oferta." MaximumValue="10000000" MinimumValue="0" Type="Integer" ValidationGroup="Oferta">*</asp:RangeValidator>
                    <asp:DropDownList ID="cmbNivelEstudiosRequeridos" runat="server" CssClass="text-box"
                        AutoPostBack="true" OnSelectedIndexChanged="cmbNivelEstudiosRequeridos_SelectedIndexChanged">
                    </asp:DropDownList>
                </asp:Label>
                <div class="w-100per item-center max-w-850px flex-col gap-4">
                    <asp:Label ID="lblOcupación" runat="server" Text="Ocupación"
                        AssociatedControlID="cmbOcupacion"
                        CssClass="text-title-section text-medium color-gray-700 flex-col gap-4 w-100per item-center max-w-850px ">
                    </asp:Label>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="flex gap-4">
                                <asp:DropDownList ID="cmbOcupacion" runat="server" CssClass="text-box"
                                    AutoPostBack="true">
                                    <asp:ListItem Selected="True" Value="-1">Seleccione</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Button ID="btnAddOcupacion" runat="server" Text="Añadir" CssClass="button"
                                    OnClick="btnAddOcupacion_Click" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <ul runat="server" id="ulSkills" class="skills-ul border">
                        <li runat="server" id="tagOcupacion1" class="tag" visible="false">
                            <asp:Label ID="lblTagOcupacion1" runat="server" Text="" AssociatedControlID="btnRemoveOcupacion1"
                                CssClass="pointer flex-inline">
                                <svg xmlns="http://www.w3.org/2000/svg" class="icon-24" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                    <path stroke-linecap="round" stroke-linejoin="round" d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z" />
                                </svg>
                                <asp:Button Text="" ID="btnRemoveOcupacion1" runat="server" OnClick="btnRemoveOcupacion1_Click" />
                            </asp:Label>
                            <asp:Label ID="nameTagOcupacion" runat="server" Text=""></asp:Label>
                            <asp:Label ID="idTagOcupacion" runat="server" CssClass="hidden" Text=""></asp:Label>
                        </li>
                        <li runat="server" id="tagOcupacion2" class="tag" visible="false">
                            <asp:Label ID="lblTagOcupacion2" runat="server" Text="" AssociatedControlID="btnRemoveOcupacion2"
                                CssClass="pointer flex-inline">
                                <svg xmlns="http://www.w3.org/2000/svg" class="icon-24" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                    <path stroke-linecap="round" stroke-linejoin="round" d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z" />
                                </svg>
                                <asp:Button Text="" ID="btnRemoveOcupacion2" runat="server" OnClick="btnRemoveOcupacion2_Click" />
                            </asp:Label>
                            <asp:Label ID="nameTagOcupacion2" runat="server" Text=""></asp:Label>
                            <asp:Label ID="idTagOcupacion2" runat="server" CssClass="hidden" Text=""></asp:Label>

                        </li>
                        <li runat="server" id="tagOcupacion3" class="tag" visible="false">
                            <asp:Label ID="lblTagOcupacion3" runat="server" Text="" AssociatedControlID="btnRemoveOcupacion3"
                                CssClass="pointer flex-inline">
                                <svg xmlns="http://www.w3.org/2000/svg" class="icon-24" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                    <path stroke-linecap="round" stroke-linejoin="round" d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z" />
                                </svg>
                                <asp:Button Text="" ID="btnRemoveOcupacion3" runat="server" OnClick="btnRemoveOcupacion3_Click" />
                            </asp:Label>
                            <asp:Label ID="nameTagOcupacion3" runat="server" Text=""></asp:Label>
                            <asp:Label ID="idTagOcupacion3" runat="server" CssClass="hidden" Text=""></asp:Label>

                        </li>
                        <li runat="server" id="tagOcupacion4" class="tag" visible="false">
                            <asp:Label ID="lblTagOcupacion4" runat="server" Text="" AssociatedControlID="btnRemoveOcupacion4"
                                CssClass="pointer flex-inline">
                                <svg xmlns="http://www.w3.org/2000/svg" class="icon-24" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                    <path stroke-linecap="round" stroke-linejoin="round" d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z" />
                                </svg>
                                <asp:Button Text="" ID="btnRemoveOcupacion4" runat="server" OnClick="btnRemoveOcupacion4_Click" />
                            </asp:Label>
                            <asp:Label ID="nameTagOcupacion4" runat="server" Text=""></asp:Label>
                            <asp:Label ID="idTagOcupacion4" runat="server" CssClass="hidden" Text=""></asp:Label>
                        </li>
                        <li runat="server" id="tagOcupacion5" class="tag" visible="false">
                            <asp:Label ID="lblTagOcupacion5" runat="server" Text="" AssociatedControlID="btnRemoveOcupacion5"
                                CssClass="pointer flex-inline">
                                <svg xmlns="http://www.w3.org/2000/svg" class="icon-24" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                    <path stroke-linecap="round" stroke-linejoin="round" d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z" />
                                </svg>
                                <asp:Button Text="" ID="btnRemoveOcupacion5" runat="server" OnClick="btnRemoveOcupacion5_Click" />
                            </asp:Label>
                            <asp:Label ID="nameTagOcupacion5" runat="server" Text=""></asp:Label>
                            <asp:Label ID="idTagOcupacion5" runat="server" CssClass="hidden" Text=""></asp:Label>
                        </li>
                    </ul>
                </div>
                <asp:Label ID="lblRangoSalarial" runat="server" Text="Rango Salarial"
                    AssociatedControlID="cmbRangoSalarial"
                    CssClass="text-title-section text-medium color-gray-700 flex-col gap-4 w-100per item-center max-w-850px ">
                    <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="cmbRangoSalarial" ForeColor="#CC0000" CssClass="text" ErrorMessage="Seleccione el rango salarial de la oferta." MaximumValue="10000000" MinimumValue="0" Type="Integer" ValidationGroup="Oferta">*</asp:RangeValidator>
                    <asp:DropDownList ID="cmbRangoSalarial" runat="server" CssClass="text-box"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </asp:Label>
                <asp:Label ID="lblModalidadEmpleo" runat="server" Text="Modalidad De Empleo"
                    AssociatedControlID="cmbModalidadEmpleo"
                    CssClass="text-title-section text-medium color-gray-700 flex-col gap-4 w-100per item-center max-w-850px ">
                    <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="cmbModalidadEmpleo" ForeColor="#CC0000" CssClass="text" ErrorMessage="Seleccione la modalidad de empleo de la oferta." MaximumValue="10000000" MinimumValue="0" Type="Integer" ValidationGroup="Oferta">*</asp:RangeValidator>
                    <asp:DropDownList ID="cmbModalidadEmpleo" runat="server" CssClass="text-box"
                        AutoPostBack="true">
                        <asp:ListItem Selected="True" Value="-1">Seleccione</asp:ListItem>
                    </asp:DropDownList>
                </asp:Label>
                <asp:Label ID="lblDepartamento" runat="server" Text="Departamento"
                    AssociatedControlID="cmbDepartamento"
                    CssClass="text-title-section text-medium color-gray-700 flex-col gap-4 w-100per item-center max-w-850px ">
                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="cmbDepartamento" ForeColor="#CC0000" CssClass="text" ErrorMessage="Seleccione el departamento a la oferta." MaximumValue="10000000" MinimumValue="0" Type="Integer" ValidationGroup="Oferta">*</asp:RangeValidator>
                    <asp:DropDownList ID="cmbDepartamento" runat="server" CssClass="text-box"
                        AutoPostBack="true" OnSelectedIndexChanged="cmbDepartamento_SelectedIndexChanged">
                    </asp:DropDownList>
                </asp:Label>
                <asp:Label ID="lblMunicipio" runat="server" Text="Municipio"
                    AssociatedControlID="cmbMunicipio"
                    CssClass="text-title-section text-medium color-gray-700 flex-col gap-4 w-100per item-center max-w-850px ">
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="cmbMunicipio" ForeColor="#CC0000" CssClass="text" ErrorMessage="Seleccione el municipio o ciudad a la oferta." MaximumValue="1000000000" MinimumValue="0" Type="Integer" ValidationGroup="Oferta">*</asp:RangeValidator>
                    <asp:DropDownList ID="cmbMunicipio" runat="server" CssClass="text-box"
                        AutoPostBack="true">
                        <asp:ListItem Selected="True" Value="-1">Seleccione</asp:ListItem>
                    </asp:DropDownList>
                </asp:Label>
                <asp:Label ID="lblSectorEconomico" runat="server" Text="Sector Economico"
                    AssociatedControlID="cmbSectorEconomico"
                    CssClass="text-title-section text-medium color-gray-700 flex-col gap-4 w-100per item-center max-w-850px ">
                    <asp:RangeValidator ID="RangeValidator" runat="server" ControlToValidate="cmbSectorEconomico" ForeColor="#CC0000" CssClass="text" ErrorMessage="Seleccione el sector económico" MaximumValue="10000000" MinimumValue="0" Type="Integer" ValidationGroup="Oferta">*</asp:RangeValidator>
                    <asp:DropDownList ID="cmbSectorEconomico" runat="server" CssClass="text-box" Enabled="false" 
                        AutoPostBack="true">
                    </asp:DropDownList>
                </asp:Label>
                <asp:Label ID="lblConfidencial" runat="server" AssociatedControlID="ChkConfidencial" CssClass="check-box" >
                    <p>Es confidencial </p>
                    <span>
                        <asp:CheckBox ID="ChkConfidencial" runat="server" CssClass="" />
                        <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                            <path stroke-linecap="round" stroke-linejoin="round" d="M5 13l4 4L19 7" />
                        </svg>
                    </span>
                </asp:Label>


                <asp:Button ID="btnPublicarOferta" runat="server" Text="Publicar Oferta" ValidationGroup="Oferta" CssClass="button" OnClick="btnPublicarOferta_Click" />
            </div>
            <div id="openModal" class="modal-dialog" runat="server" >
                <div class="flex-col flex-center">
                   
                    <asp:Panel runat="server" ID="modalCV" CssClass="modal-body flex flex-center max-w-850px">

</asp:Panel>
                    <div runat="server" ID="modalOfertaCreada" >


                        <div class="flex flex-col gap-32">
                            <h3 class="text-subtitle">¡Estimado usuario! <span class="text-highlighted text-subtitle">Su oferta fue creada exitósamente, mi empleo revisará su oferta para ser publicada.</span> Gracias por contar con nosotros
                            </h3>

                            <div class="flex-center gap-8">
                                <asp:Button ID="Nuevo" Visible="true" runat="server" CssClass="button" Text="Crear una nueva Oferta" OnClick="Volver_Click" />
                                <asp:Button ID="Panel" Visible="true" runat="server" CssClass="button bg-gray-500" Text="Volver al Panel Empresa" OnClick="Panel_Click" />
                            </div>
                        </div>
                        <div id="variable" runat="server" style="display: none">
                            <asp:Label ID="lblIdOfertaDelete" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblEstadoOferta" runat="server" Text=""></asp:Label>

                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanelModal2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div id="openModal2" class="modalDialog" runat="server" style="display: none" >
                        <div>
                            
                            <h3 class="text-subtitle">¡Estimado usuario! <span class="text-highlighted text-subtitle">Actualmente no cuenta con paquetes disponibles. </span>Le recomendamos adquirir uno para poder publicar sus ofertas
                            </h3>
                            <div class="flex-center">

                                <asp:Button ID="Button2" Visible="true" runat="server" CssClass="button" Text="Adquirir Plan" OnClick="Adquirir_Click" />
                            </div>
                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </ContentTemplate>

    </asp:UpdatePanel>
   
 
</asp:Content>
