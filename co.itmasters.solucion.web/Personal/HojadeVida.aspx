<%@ Page Title="" Language="C#" MasterPageFile="~/ITMasters.Master" AutoEventWireup="true" CodeBehind="HojadeVida.aspx.cs" Inherits="co.itmasters.solucion.web.Personal.HojadeVida" MaintainScrollPositionOnPostback="true" %>

<%@ MasterType VirtualPath="../ITMasters.Master" %>
<%@ Register Src="~/Components_UI/ModalUserControl.ascx" TagName="ModalUserControl" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">
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
                padding: 56px;
                border-radius: 10px;
                /contorno de la ventana/ background: -o-linear-gradient(#fff, #fff);
                background: -moz-linear-gradient(#fff, #fff);
                background: -webkit-linear-gradient(#fff, #fff);
                background: -o-linear-gradient(#fff, #fff);
                -webkit-transition: opacity 100ms ease-in;
                -moz-transition: opacity 100ms ease-in;
                transition: opacity 100ms ease-in;
            }

        @media and screen (min-width:500px) {
            .modalDialog > div {
                width: 100vw;
            }
        }

        .closed {
            position: absolute;
            top: 12px;
            right: 12px;
        }

            .closed:hover {
                background: white;
            }

        .auto-style1 {
            color: #FFFFFF;
            font-size: large;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanelform" runat="server" class="flex-center"  UpdateMode="Conditional">
        <ContentTemplate>

            <div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>

                        <uc:ModalUserControl runat="server" ID="ucModal"
                            ModalSize="medium" hasButton=" true" Visible="false" />

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>



            <section class="cv-wrapper" runat="server" id="WrpCv">

                <header class="cv-header">
                    <div runat="server" id="wrpPersonalInfo" class="cv-i-edit">
                        <asp:Label Text="" runat="server" ID="lblEditPersonalInfo" AssociatedControlID="btnEditPersonalInfo" CssClass="pointer flex">

                            <i class="flex" id="btnPersonalInfo" runat="server">
                                <svg xmlns="http://www.w3.org/2000/svg" class="color-green-400 icon-36" width="24px" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                    <path stroke-linecap="round" stroke-linejoin="round" d="M15.232 5.232l3.536 3.536m-2.036-5.036a2.5 2.5 0 113.536 3.536L6.5 21.036H3v-3.572L16.732 3.732z" />
                                </svg>
                            </i>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:Button Text="" runat="server" ID="btnEditPersonalInfo" OnClick="btnEditInformacionBasica_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Label>
                        <%-- Personal Info --%>
                    </div>
                    <div class="cv-userAvatar" runat="server" id="userAvatar">

                        <%-- Avatar --%>

                        <img src="." alt="Foto de perfil" runat="server" id="imgAvatar" />
                        <div>
                            <asp:Label ID="lblRutaAvatar" Text="" runat="server" CssClass="hidden"/>  
                        <asp:Label ID="lblEditPicture" Text="text" runat="server" CssClass="cv-btnAvatar cv-icon color-gray-100" 
                            AssociatedControlID="btnSubirAvatar">
                            <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                              <path stroke-linecap="round" stroke-linejoin="round" d="M3 9a2 2 0 012-2h.93a2 2 0 001.664-.89l.812-1.22A2 2 0 0110.07 4h3.86a2 2 0 011.664.89l.812 1.22A2 2 0 0018.07 7H19a2 2 0 012 2v9a2 2 0 01-2 2H5a2 2 0 01-2-2V9z" />
                              <path stroke-linecap="round" stroke-linejoin="round" d="M15 13a3 3 0 11-6 0 3 3 0 016 0z" />
                            </svg>
                        </asp:Label>
                            <asp:Button ID="btnSubirAvatar" Text="" runat="server" OnClick="btnSubirAvatar_Click"/>
                        </div>
                    </div>

                    <div>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div runat="server" id="containerModal">
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <ul class="cv-header-info">
                        <li class="cv-header-info-item text-section color-gray-100 text-semibold" runat="server" id="userName">
                            <%-- Nombre --%> 
                        </li>
                        <li class="cv-header-info-item text-normal text-regular color-gray-200" unat="server" id="userProfession">
                            <%-- Profesion  --%>
                        </li>
                        <li class='cv-header-info-item text-normal text-regular color-gray-500'>

                            <svg xmlns="http://www.w3.org/2000/svg" class="color-gray-500" width="24px" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                <path stroke-linecap="round" stroke-linejoin="round" d="M3 5a2 2 0 012-2h3.28a1 1 0 01.948.684l1.498 4.493a1 1 0 01-.502 1.21l-2.257 1.13a11.042 11.042 0 005.516 5.516l1.13-2.257a1 1 0 011.21-.502l4.493 1.498a1 1 0 01.684.949V19a2 2 0 01-2 2h-1C9.716 21 3 14.284 3 6V5z" />
                            </svg>
                            <asp:Literal runat="server" ID="userPhone">
                        <%-- Numero de Telefono --%>
                            </asp:Literal>
                        </li>

                        <li class='cv-header-info-item text-normal text-regular color-gray-300'>
                            <svg xmlns="http://www.w3.org/2000/svg" class="color-gray-300" width="24px" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                <path stroke-linecap="round" stroke-linejoin="round" d="M17.657 16.657L13.414 20.9a1.998 1.998 0 01-2.827 0l-4.244-4.243a8 8 0 1111.314 0z" />
                                <path stroke-linecap="round" stroke-linejoin="round" d="M15 11a3 3 0 11-6 0 3 3 0 016 0z" />
                            </svg>
                            <asp:Literal runat="server" ID="userHousingAddress">
                        <%-- Ciudad --%>
                            </asp:Literal>
                        </li>

                        <li class='cv-header-info-item text-small text-regular color-gray-500'>
                            <svg xmlns="http://www.w3.org/2000/svg" class="color-gray-500" width="24px" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                <path stroke-linecap="round" stroke-linejoin="round" d="M3 8l7.89 5.26a2 2 0 002.22 0L21 8M5 19h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v10a2 2 0 002 2z" />
                            </svg>
                            <asp:Literal runat="server" ID="userEmail">
                             <%-- Email --%>
                            </asp:Literal>

                        </li>

                    </ul>

                    <div class="cv-wave"></div>
                </header>

                <%-- Description --%>

                <section class="cv-section">

                    <div class="cv-title_i">

                        <h3 class="text-section color-gray-800">Description</h3>

                        <div class="flex cv-icons">

                            

                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>

                                    <asp:Label Text="" runat="server" ID="lblEditDescription" CssClass="flex pointer" AssociatedControlID="btnEditDescription">
                                        <i class='cv-icon'>
                                            <svg xmlns="http://www.w3.org/2000/svg" width="24px" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                                <path stroke-linecap="round" stroke-linejoin="round" d="M15.232 5.232l3.536 3.536m-2.036-5.036a2.5 2.5 0 113.536 3.536L6.5 21.036H3v-3.572L16.732 3.732z" />
                                            </svg>
                                            <asp:Button Text="" runat="server" ID="btnEditDescription" OnClick="btnEditDescription_Click" />
                                        </i>

                                    </asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>

                    </div>

                    <div class="container-text-area w-100per">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtPerfil" runat="server" placeholder="Decribe tu perfil profecional en menos de 2000 caractares"
                                    class="text-normal input-label w-100per" onpaste="return false;" >
                                </asp:TextBox>

                                
                                        <p runat="server" id="lblCuentaCaracteres" class="count-text-area" visible="false"></p>
                                  

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="flex w-100per flex-center-h">
                        <asp:UpdatePanel runat="server" class="flex-col gap-4 self-center-h">
                            <ContentTemplate>
                                <asp:RequiredFieldValidator ID="rfvPerfil" ValidationGroup="perfil" ErrorMessage="Ecribe un breve descripción de tu perfil"
                                    ControlToValidate="txtPerfil" runat="server" CssClass="required-field-validator"/>
                                <asp:RegularExpressionValidator ID="revUsuario" ValidationGroup="perfil" Runat="server" ErrorMessage="La descripción de tu perfil debe tener minimo 10 caracteres."
                                    ValidationExpression="^(?:.| ){10,}$" ControlToValidate="txtPerfil" Display="Dynamic"  CssClass="required-field-validator"/>
                                <asp:Button Text="Guardar" runat="server" CssClass="button" ID="btnSaveDescription"
                                    OnClick="btnSaveDescription_Click" Visible="false" ValidationGroup="perfil" />

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    

                </section>

                <%--Studies--%>

                <section class="cv-section">
                    <div class="cv-title_i">

                        <h3 class="text-section color-gray-800">Formación
                        </h3>
                    </div>


                    <div class="flex w-100per">


                        <asp:UpdatePanel runat="server" class="w-100per">
                            <ContentTemplate>
                                <asp:GridView runat="server" ID="grdPersonaAcademia" AutoGenerateColumns="false" CssClass="w-100per"
                                    OnRowCommand="grdPersonaAcademia_RowCommand">
                                    <Columns>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl" Text="" runat="server" />
                                                <asp:Label ID="lblidAcademia" runat="server" Text='<%# Eval("idPersonaAcademia") %>'></asp:Label>
                                                <asp:Label ID="lblidPersonaAcademia" runat="server" Text='<%# Eval("idPersona") %>'></asp:Label>
                                                <asp:Label ID="lblidCiudadFormacion" runat="server" Text='<%# Eval("idCiudadFormacion") %>'></asp:Label>
                                                <asp:Label ID="lblnomInstitucion" runat="server" Text='<%# Eval("nomInstitucion") %>'></asp:Label>
                                                <asp:Label ID="lblidNivelEducativo" runat="server" Text='<%# Eval("idNivelEducativo") %>'></asp:Label>
                                                <asp:Label ID="lblidOcupacion" runat="server" Text='<%# Eval("idOcupacion") %>'></asp:Label>
                                                <asp:Label ID="lblfechaFinFormacion" runat="server" Text='<%# Eval("fechaFinFormacion") %>'></asp:Label>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("fechaFinFormacion") %>'></asp:Label>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("fechaFinFormacion") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="true">
                                            <ItemTemplate>
                                                <article class="cv-item_info">
                                                    <header class="cv-item">
                                                        <div class="flex cv-item-title">
                                                            <i class="cv-icon" runat="server" id="itemIcon">

                                                                <svg xmlns='http://www.w3.org/2000/svg' class='h-6 w-6' fill='none'
                                                                    viewBox='0 0 24 24' stroke='currentColor'>
                                                                    <path d='M12 14l9-5-9-5-9 5 9 5z' />
                                                                    <path d='M12 14l6.16-3.422a12.083 12.083 0 01.665 6.479A11.952 11.952 0 0012 20.055a11.952 11.952 0 00-6.824-2.998 12.078 12.078 0 01.665-6.479L12 14z' />
                                                                    <path stroke-linecap='round' stroke-linejoin='round' d='M12 14l9-5-9-5-9 5 9 5zm0 0l6.16-3.422a12.083 12.083 0 01.665 6.479A11.952 11.952 0 0012 20.055a11.952 11.952 0 00-6.824-2.998 12.078 12.078 0 01.665-6.479L12 14zm-4 6v-7.5l4-2.222' />
                                                                </svg>
                                                            </i>
                                                            <asp:Label class="text-item color-gray-700 text-semibold" runat="server"
                                                                ID="grdEstudioTitle" Text='<%# Eval("tituloFormacionAcademica") %>'>

                                                            </asp:Label>
                                                        </div>


                                                    </header>
                                                    <div class="cv-item-info">
                                                        <p class='text-normal text-regular color-gray-600' runat="server" id="itemContent">
                                                            <%# Eval( "nomInstitucion") %>
                                                        </p>
                                                        <p class='text-normal text-regular color-gray-600' runat="server" id="itemDate">
                                                            <%#  String.Format("{0:yyyy-MM-dd}", Eval( "fechaFinFormacion")) %>
                                                        </p>
                                                    </div>
                                                </article>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="true" >
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgEditar" runat="Server" Style="height: 25px; width: 25px;"
                                                    CommandArgument="<% # Container.DataItemIndex %>" CommandName="UPD"
                                                    ImageUrl="~/Images/Editar.svg    " ToolTip="Editar Estudio." />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="true">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgBorrar" runat="Server" Style="height: 25px; width: 25px;"
                                                    CommandArgument="<% # Container.DataItemIndex %>" CommandName="DEL"
                                                    ImageUrl="~/Images/Eliminar.svg" ToolTip="Eliminar estudio." />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <div class="flex gap-4  p-y-16">
                                    <i class="cv-icon" runat="server" id="i1">
                                        <svg xmlns='http://www.w3.org/2000/svg' class='color-gray-700' fill='none'
                                            viewBox='0 0 24 24' stroke='currentColor'>
                                            <path d='M12 14l9-5-9-5-9 5 9 5z' />
                                            <path d='M12 14l6.16-3.422a12.083 12.083 0 01.665 6.479A11.952 11.952 0 0012 20.055a11.952 11.952 0 00-6.824-2.998 12.078 12.078 0 01.665-6.479L12 14z' />
                                            <path stroke-linecap='round' stroke-linejoin='round' d='M12 14l9-5-9-5-9 5 9 5zm0 0l6.16-3.422a12.083 12.083 0 01.665 6.479A11.952 11.952 0 0012 20.055a11.952 11.952 0 00-6.824-2.998 12.078 12.078 0 01.665-6.479L12 14zm-4 6v-7.5l4-2.222' />
                                        </svg>

                                    </i>
                                <asp:Button Text="Añadir más estudios" CssClass="button-link" runat="server" ID="btnAddAcademia" OnClick="btnAddAcademia_Click"/>

                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>



                </section>
                <%--Experience--%>

                <section class="cv-section">
                    <div class="cv-title_i">

                        <h3 class="text-section color-gray-800">Experiencia
                        </h3>
                    </div>

                    <div class="flex w-100per">

                        <asp:UpdatePanel runat="server" class="w-100per">
                            <ContentTemplate>
                                <asp:GridView runat="server" ID="grdPersonaExperienca" AutoGenerateColumns="false" CssClass="w-100per"
                                    OnRowCommand="grdPersonaExperienca_RowCommand">
                                    <Columns>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblidExperiencia" runat="server" Text='<%# Eval("idPersonaExperiencia") %>'></asp:Label>
                                                <asp:Label ID="lblidPersonaExperiencia" runat="server" Text='<%# Eval("idPersona") %>'></asp:Label>
                                                <asp:Label ID="lblnomCargo" runat="server" Text='<%# Eval("nomCargo") %>'></asp:Label>
                                                <asp:Label ID="lbldesCargo" runat="server" Text='<%# Eval("desCargo") %>'></asp:Label>
                                                <asp:Label ID="lblidCiudadCargo" runat="server" Text='<%# Eval("idCiudadCargo") %>'></asp:Label>
                                                <asp:Label ID="lblidNivelEducativoExperiencia" runat="server" Text='<%# Eval("idNivelEducativo") %>'></asp:Label>
                                                <asp:Label ID="lblidOcupacionExperiencia" runat="server" Text='<%# Eval("idOcupacion") %>'></asp:Label>
                                                <asp:Label ID="lbltiempoCargo" runat="server" Text='<%# Eval("tiempoCargo") %>'></asp:Label>
                                                <asp:Label ID="lblfechaIniCargo" runat="server" Text='<%# Eval("fechaIniCargo") %>'></asp:Label>
                                                <asp:Label ID="lblfechaFinCargo" runat="server" Text='<%# Eval("fechaFinCargo") %>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="true">
                                            <ItemTemplate>
                                                <article class="cv-item_info">
                                                    <header class="cv-item">
                                                        <div class="flex cv-item-title">
                                                            <i class="cv-icon" runat="server" id="itemIcon">
                                                                <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                                                    <path stroke-linecap="round" stroke-linejoin="round" d="M21 13.255A23.931 23.931 0 0112 15c-3.183 0-6.22-.62-9-1.745M16 6V4a2 2 0 00-2-2h-4a2 2 0 00-2 2v2m4 6h.01M5 20h14a2 2 0 002-2V8a2 2 0 00-2-2H5a2 2 0 00-2 2v10a2 2 0 002 2z" />
                                                                </svg>

                                                            </i>
                                                            <asp:Label class="text-item color-gray-700 text-semibold" runat="server"
                                                                 Text='<%# Eval("nomCargo") %>'>

                                                            </asp:Label>
                                                        </div>


                                                    </header>
                                                    <div class="cv-item-info">
                                                        <p class='text-normal text-regular color-gray-600' runat="server" id="itemContent">
                                                            <%# Eval( "desCargo") %>
                                                        </p>
                                                        <p class='text-normal text-regular color-gray-600' runat="server" id="itemDate">
                                                            <%# String.Format("{0:yyyy-MM-dd}", Eval("fechaIniCargo")) %> - <%# String.Format("{0:yyyy-MM-dd}", Eval("fechaFinCargo")) %>
                                                        </p>
                                                    </div>
                                                </article>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="true">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgEditar" runat="Server" Style="height: 25px; width: 25px;"
                                                    CommandArgument="<% # Container.DataItemIndex %>" CommandName="UPD"
                                                    ImageUrl="~/Images/Editar.svg    " ToolTip="Editar experiencia." />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="true">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgBorrar" runat="Server" Style="height: 25px; width: 25px;"
                                                    CommandArgument="<% # Container.DataItemIndex %>" CommandName="DEL"
                                                    ImageUrl="~/Images/Eliminar.svg" ToolTip="Borrar experiencia." />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <div class="flex gap-4  p-y-16">
                                    <i class="cv-icon" runat="server" id="itemIcon">
                                        <svg xmlns="http://www.w3.org/2000/svg" class="color-gray-700" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                            <path stroke-linecap="round" stroke-linejoin="round" d="M21 13.255A23.931 23.931 0 0112 15c-3.183 0-6.22-.62-9-1.745M16 6V4a2 2 0 00-2-2h-4a2 2 0 00-2 2v2m4 6h.01M5 20h14a2 2 0 002-2V8a2 2 0 00-2-2H5a2 2 0 00-2 2v10a2 2 0 002 2z" />
                                        </svg>

                                    </i>
                                    <asp:Button Text="Añadir nueva experiencia" runat="server" CssClass="button-link" ID="btnAddExperiencia" OnClick="btnAddExperiencia_Click" />

                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>


                </section>

                <%--Knowledge & Skills--%>

                <section class="cv-section">

                    <div class="cv-title_i">

                        <h3 class="text-section color-gray-800">Conocimiento y Habilidades
                        </h3>
                    </div>
                    <div class="w-100per item-center max-w-850px flex-col gap-4">
                        <asp:Label ID="lblSkill" runat="server" Text="Skill"
                            AssociatedControlID="cmbSkill"
                            CssClass="text-title-section text-medium color-gray-700 flex-col gap-4 w-100per item-center max-w-850px ">
                        </asp:Label>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="flex gap-4">
                                    <asp:DropDownList ID="cmbSkill" runat="server" CssClass="text-box"
                                        AutoPostBack="true">
                                        <asp:ListItem Selected="True" Value="-1">Seleccione</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Button ID="btnAddSkill" runat="server" Text="Añadir" CssClass="button"
                                        OnClick="btnAddSkill_Click" />
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
               
                        <asp:UpdatePanel  ID= "updSkill" runat="server" ClientIDMode="Predictable" UpdateMode="Conditional">
                            <ContentTemplate>
                        <ul runat="server" id="ulSkills" class="skills-ul border">



                            <li runat="server" id="tagSkill1" class="tag" visible="false">


                                <asp:Label ID="lblIdAptitud1" Text="" runat="server" CssClass="hidden" />
                                <asp:Label ID="lblIdPersonaAptitud1" Text="" runat="server" CssClass="hidden" />
                                <asp:Label ID="lblTagSkill1" runat="server" Text="" AssociatedControlID="btnRemoveSkill1"
                                    CssClass="pointer flex-inline">

                                    <svg xmlns="http://www.w3.org/2000/svg" class="icon-24" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                        <path stroke-linecap="round" stroke-linejoin="round" d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z" />
                                    </svg>
                                    <asp:Button Text="" ID="btnRemoveSkill1" runat="server" OnClick="btnRemoveSkill1_Click" />
                                </asp:Label>
                                <asp:Label ID="nameTagSkill" runat="server" Text=""></asp:Label>

                            </li>


                            <li runat="server" id="tagSkill2" class="tag" visible="false">
                                <asp:Label ID="lblIdAptitud2" Text="" runat="server" CssClass="hidden" />
                                <asp:Label ID="lblIdPersonaAptitud2" Text="" runat="server" CssClass="hidden" />
                                <asp:Label ID="lblTagSkill2" runat="server" Text="" AssociatedControlID="btnRemoveSkill2"
                                    CssClass="pointer flex-inline">

                                    <svg xmlns="http://www.w3.org/2000/svg" class="icon-24" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                        <path stroke-linecap="round" stroke-linejoin="round" d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z" />
                                    </svg>
                                    <asp:Button Text="" ID="btnRemoveSkill2" runat="server" OnClick="btnRemoveSkill2_Click" />


                                </asp:Label>
                                <asp:Label ID="nameTagSkill2" runat="server" Text=""></asp:Label>

                            </li>

                            <li runat="server" id="tagSkill3" class="tag" visible="false">
                                <asp:Label ID="lblIdAptitud3" Text="" runat="server" CssClass="hidden" />
                                <asp:Label ID="lblIdPersonaAptitud3" Text="" runat="server" CssClass="hidden" />
                                <asp:Label ID="lblTagSkill3" runat="server" Text="" AssociatedControlID="btnRemoveSkill3"
                                    CssClass="pointer flex-inline">

                                    <svg xmlns="http://www.w3.org/2000/svg" class="icon-24" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                        <path stroke-linecap="round" stroke-linejoin="round" d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z" />
                                    </svg>
                                    <asp:Button Text="" ID="btnRemoveSkill3" runat="server" OnClick="btnRemoveSkill3_Click" />

                                </asp:Label>
                                <asp:Label ID="nameTagSkill3" runat="server" Text=""></asp:Label>

                            </li>
                            


                            <li runat="server" id="tagSkill4" class="tag" visible="false">
                                <asp:Label ID="lblIdAptitud4" Text="" runat="server" CssClass="hidden" />
                                <asp:Label ID="lblIdPersonaAptitud4" Text="" runat="server" CssClass="hidden" />
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>

                                <asp:Label ID="lblTagSkill4" runat="server" Text="" AssociatedControlID="btnRemoveSkill4"
                                    CssClass="pointer flex-inline">

                                    <svg xmlns="http://www.w3.org/2000/svg" class="icon-24" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                        <path stroke-linecap="round" stroke-linejoin="round" d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z" />
                                    </svg>
                                    <asp:Button Text="" ID="btnRemoveSkill4" runat="server" OnClick="btnRemoveSkill4_Click" />
                                </asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:Label ID="nameTagSkill4" runat="server" Text=""></asp:Label>

                            </li>


                            <li runat="server" id="tagSkill5" class="tag" visible="false">
                                <asp:Label ID="lblIdAptitud5" Text="" runat="server" CssClass="hidden" />
                                <asp:Label ID="lblIdPersonaAptitud5" Text="" runat="server" CssClass="hidden" />
                                <asp:Label ID="lblTagSkill5" runat="server" Text="" AssociatedControlID="btnRemoveSkill5"
                                    CssClass="pointer flex-inline">

                                    <svg xmlns="http://www.w3.org/2000/svg" class="icon-24" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                        <path stroke-linecap="round" stroke-linejoin="round" d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z" />
                                    </svg>
                                    <asp:Button Text="" ID="btnRemoveSkill5" runat="server" OnClick="btnRemoveSkill5_Click" />
                                </asp:Label>
                                <asp:Label ID="nameTagSkill5" runat="server" Text=""></asp:Label>
                            </li>

                            <li runat="server" id="tagSkill6" class="tag" visible="false">

                                <asp:Label ID="lblTagSkill6" runat="server" Text="" AssociatedControlID="btnRemoveSkill6"
                                    CssClass="pointer flex-inline">

                                    <svg xmlns="http://www.w3.org/2000/svg" class="icon-24" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                        <path stroke-linecap="round" stroke-linejoin="round" d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z" />
                                    </svg>
                                    <asp:Button Text="" ID="btnRemoveSkill6" runat="server" OnClick="btnRemoveSkill6_Click" />
                                </asp:Label>
                                <asp:Label ID="nameTagSkill6" runat="server" Text=""></asp:Label>
                            </li>

                            <li runat="server" id="tagSkill7" class="tag" visible="false">

                                <asp:Label ID="lblTagSkill7" runat="server" Text="" AssociatedControlID="btnRemoveSkill7"
                                    CssClass="pointer flex-inline">

                                    <svg xmlns="http://www.w3.org/2000/svg" class="icon-24" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                        <path stroke-linecap="round" stroke-linejoin="round" d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z" />
                                    </svg>
                                    <asp:Button Text="" ID="btnRemoveSkill7" runat="server" OnClick="btnRemoveSkill7_Click" />
                                </asp:Label>
                                <asp:Label ID="nameTagSkill7" runat="server" Text=""></asp:Label>
                            </li>

                            <li runat="server" id="tagSkill8" class="tag" visible="false">

                                <asp:Label ID="lblTagSkill8" runat="server" Text="" AssociatedControlID="btnRemoveSkill8"
                                    CssClass="pointer flex-inline">

                                    <svg xmlns="http://www.w3.org/2000/svg" class="icon-24" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                        <path stroke-linecap="round" stroke-linejoin="round" d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z" />
                                    </svg>
                                    <asp:Button Text="" ID="btnRemoveSkill8" runat="server" OnClick="btnRemoveSkill8_Click" />
                                </asp:Label>
                                <asp:Label ID="nameTagSkill8" runat="server" Text=""></asp:Label>
                            </li>

                            <li runat="server" id="tagSkill9" class="tag" visible="false">

                                <asp:Label ID="lblTagSkill9" runat="server" Text="" AssociatedControlID="btnRemoveSkill9"
                                    CssClass="pointer flex-inline">

                                    <svg xmlns="http://www.w3.org/2000/svg" class="icon-24" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                        <path stroke-linecap="round" stroke-linejoin="round" d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z" />
                                    </svg>
                                    <asp:Button Text="" ID="btnRemoveSkill9" runat="server" OnClick="btnRemoveSkill9_Click" />
                                </asp:Label>
                                <asp:Label ID="nameTagSkill9" runat="server" Text=""></asp:Label>
                            </li>

                            <li runat="server" id="tagSkill10" class="tag" visible="false">

                                <asp:Label ID="lblTagSkill10" runat="server" Text="" AssociatedControlID="btnRemoveSkill10"
                                    CssClass="pointer flex-inline">

                                    <svg xmlns="http://www.w3.org/2000/svg" class="icon-24" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                        <path stroke-linecap="round" stroke-linejoin="round" d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z" />
                                    </svg>
                                    <asp:Button Text="" ID="btnRemoveSkill10" runat="server" OnClick="btnRemoveSkill10_Click" />
                                </asp:Label>
                                <asp:Label ID="nameTagSkill10" runat="server" Text=""></asp:Label>
                            </li>
                        </ul>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                </section>

                <%--Attachments--%>

                <section class="cv-section" runat="server" visible="false">
                    <div class="cv-title_i">
                        <h3 class="text-section color-gray-800">Documentos Adjuntos
                        </h3>
                    </div>
                    <div class="cv-item" id="fileUploadProfile" runat="server" visible="true">

                        <div class="flex cv-item-title" runat="server">

                            <i class="cv-icon">
                                <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                    <path stroke-linecap="round" stroke-linejoin="round" d="M7 21h10a2 2 0 002-2V9.414a1 1 0 00-.293-.707l-5.414-5.414A1 1 0 0012.586 3H7a2 2 0 00-2 2v14a2 2 0 002 2z" />
                                </svg>
                            </i>

                            <h4 class="text-item color-gray-700 text-semibold" runat="server" id="nameFile"></h4>
                        </div>
                        <div class="flex cv-icons">
                            <i class="cv-icon">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24px" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                    <path stroke-linecap="round" stroke-linejoin="round" d="M15.232 5.232l3.536 3.536m-2.036-5.036a2.5 2.5 0 113.536 3.536L6.5 21.036H3v-3.572L16.732 3.732z" />
                                </svg>
                            </i>
                            <i class="cv-icon">
                                <svg xmlns="http://www.w3.org/2000/svg" class="icon-8" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                    <path stroke-linecap="round" stroke-linejoin="round" d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16" />
                                </svg>
                            </i>
                        </div>

                    </div>
                    <div>

                        <asp:UpdatePanel runat="server" class="flex-col gap-8">
                            <ContentTemplate>


                                <asp:Label ID="lblFileUploadCv" runat="server" Text="" CssClass="file-upload"
                                    AssociatedControlID="FileUploadCv">
                                    <span>Seleccionar Archivo </span>
                                    <asp:FileUpload ID="FileUploadCv" runat="server" CssClass="" />
                                </asp:Label>



                                <div class="flex flex-center-v gap-8 hidden" runat="server" id="previewFile">

                                    <div class="flex flex-center-v gap-4">
                                        <p class="button-link" runat="server" id="namePreviewFile">
                                        </p>

                                        <asp:Label Text="" runat="server" CssClass="flex pointer" AssociatedControlID="btnRemoveFile">

                                    <svg xmlns="http://www.w3.org/2000/svg" class="icon-24 color-red-400" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                        <path stroke-linecap="round" stroke-linejoin="round" d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z" />
                                    </svg>
                                        </asp:Label>
                                        <asp:Button Text="" runat="server" ID="btnRemoveFile" OnClick="btnRemoveFile_Click" />
                                    </div>

                                    <asp:Label ID="Label5" runat="server" Text="" CssClass="file-upload"
                                        AssociatedControlID="btnUploadDocs">
                                        <span>
                                            <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                                <path stroke-linecap="round" stroke-linejoin="round" d="M4 16v1a3 3 0 003 3h10a3 3 0 003-3v-1m-4-8l-4-4m0 0L8 8m4-4v12" />
                                            </svg>
                                        </span>
                                        <asp:Button Text="" runat="server" ID="btnUploadDocs" OnClick="btnUploadDocs_Click" />
                                    </asp:Label>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                </section>



                <div>

                    <asp:Panel class="modalDialog" id="modalSinDatosBasicos"  runat="server" Visible="false" >
                    <div id="messageUsuarioSinDatosBasicos" runat="server" class="flex-col flex-center-h" >
                        <h1 class="text-subtitle color-gray-800 p-16" >
                            ¡Bienvenido a Mi<span class="text-subtitle color-green-500" > Empleo</span>!
                            <br />
                            <br />
                            Para postular a ofertas y encontrar su 
                            <span class="text-subtitle color-green-500" > empleo ideal </span> 
                            complete sus datos básicos.
                        </h1>

                        <asp:Button Text="Completar" runat="server" CssClass="button" OnClick="btnEditInformacionBasica_Click"/>
                    </div>
                     </asp:Panel>
                </div>

                <div id="wrapperHidden" class="hidden flex-col gap-16">

                    </div>

                <div id="messageAvatar" runat="server" class="hidden flex-col flex-center p-32">
                    <h1 class="text-subtitle color-gray-800 p-16">Seleccione una imagen</h1>
                    <div>
                    <asp:Label Text="" runat="server" CssClass="file-upload" AssociatedControlID="fuAvatar">
                        <span>Seleccionar</span>
                        <asp:FileUpload runat="server" id="fuAvatar"/>
                    </asp:Label>
                        <asp:Label ID="lblFuAvatar" Text="" runat="server" />
                    </div>
                    </div>

                    <div id="messageEliminarEstudios" runat="server" class="hidden">
                        <asp:Label ID="lblIdAcademiaEliminar" Text="" runat="server" CssClass="hidden" />
                        <asp:Label ID="lblIdPersonaAcademiaEliminar" Text="" runat="server" CssClass="hidden" />
                        <h1 class="text-subtitle color-gray-800 p-16">Estas a punto de <span class="text-subtitle color-green-500">eleminiar</span> un estudio ¿Quieres continuar?
                        </h1>
                    </div>


                    <div id="messageEliminarExperiencia" runat="server" class="hidden">
                        <asp:Label ID="lblIdExperienciaEliminar" Text="" runat="server" CssClass="hidden" />
                        <asp:Label ID="lblIdPersonaExperienciaEliminar" Text="" runat="server" CssClass="hidden" />
                        <h1 class="text-subtitle color-gray-800 p-16">Estas a punto de <span class="text-subtitle color-green-500">eleminiar</span> una experiencia ¿Quieres continuar?
                        </h1>
                    </div>

                    <div class="flex-col hidden" runat="server" id="formPersonalInfo">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="flex-col gap-16">
                                    <asp:Label Text="" runat="server" ID="lblIdPersona" Visible="false" />
                                    <div class="flex-col gap-4">
                                        <asp:Label ID="lblTipoIdentificacion" runat="server" Text="Tipo de Identificación" CssClass="text-item text-semibold text-gray-700 text-center" />
                                        <asp:DropDownList ID="cmbTipoIdentificacion" runat="server" CssClass="text-box text-center" />
                                    </div>

                                    <div class="flex-col gap-4">
                                        <asp:Label ID="lblNumeroIdentificacion" runat="server" Text="Número de identificación" CssClass="text-item text-semibold text-gray-700 text-center" />
                                        <asp:Label ID="txtNumeroIdentificacion" runat="server" CssClass="text-box text-center" />
                                    </div>

                                    <div class="flex-col gap-4">
                                        <asp:Label ID="lblCorreoElectronico" runat="server" Text="Correo Electrónico" CssClass="text-item text-semibold text-gray-700 text-center" />
                                        <asp:Label ID="txtCorreoElectronico" runat="server" CssClass="text-box text-center" />
                                        <br />
                                    </div>
                                </div>

                                <div class="flex-col gap-4">
                                    <asp:Label ID="lblNombres" runat="server" Text="Nombres" CssClass="text-item text-semibold text-gray-700 text-center" />
                                    <asp:TextBox ID="txtNombres" runat="server" CssClass="text-box" />
                                    <asp:RequiredFieldValidator ID="rfvNombres" ValidationGroup="formDatosBasicos" runat="server" ControlToValidate="txtNombres" ErrorMessage="Ingrese Nombres" CssClass="required-field-validator" />
                                </div>

                                <div class="flex-col gap-4">
                                    <asp:Label ID="lblApellidos" runat="server" Text="Apellidos" CssClass="text-item text-semibold text-gray-700 text-center" />
                                    <asp:TextBox ID="txtApellidos" runat="server" CssClass="text-box" />
                                    <asp:RequiredFieldValidator ValidationGroup="formDatosBasicos" ID="rfvApellidos" runat="server" ControlToValidate="txtApellidos" ErrorMessage="Ingrese Apellidos" CssClass="required-field-validator" />
                                </div>

                                <div class="flex-col gap-4">
                                    <asp:Label ID="lblSexo" runat="server" Text="Sexo" CssClass="text-item text-semibold text-gray-700 text-center" />
                                    <asp:DropDownList ID="cmbSexo" runat="server" CssClass="text-box dropdown" />
                                    <asp:RequiredFieldValidator ValidationGroup="formDatosBasicos" ID="rfvSexo" runat="server" ControlToValidate="cmbSexo" InitialValue="0" ErrorMessage="Seleccione Sexo" CssClass="required-field-validator" />
                                </div>

                                <div class="flex-col gap-4">
                                    <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento" CssClass="text-item text-semibold text-gray-700 text-center" />
                                    <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date" CssClass="text-box" />
                                    <asp:RequiredFieldValidator ValidationGroup="formDatosBasicos" ID="rfvFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="Ingrese la fecha de nacimiento" CssClass="required-field-validator" />
                                </div>

                                <div class="flex-col gap-4">
                                    <asp:Label ID="lblNumeroTelefonico" runat="server" Text="Número Telefónico" CssClass="text-item text-semibold text-gray-700 text-center" />
                                    <asp:TextBox ID="txtNumeroTelefonico" runat="server" TextMode="Number" CssClass="text-box" />
                                    <asp:RequiredFieldValidator ValidationGroup="formDatosBasicos" ID="rfvNumeroTelefonico" runat="server" ControlToValidate="txtNumeroTelefonico" ErrorMessage="Ingrese el número telefónico" CssClass="required-field-validator" />
                                </div>


                                <asp:UpdatePanel runat="server" class=" flex-col gap-16">
                                    <ContentTemplate>
                                        <div class="flex-col gap-4">
                                            <asp:Label ID="lblPaisResidencia" runat="server" Text="País de Residencia" CssClass="text-item text-semibold text-gray-700 text-center" />
                                            <asp:DropDownList ID="cmbPaisResidencia" runat="server" CssClass="text-box dropdown" AutoPostBack="true" OnSelectedIndexChanged="cmbPaisResidencia_SelectedIndexChanged" />
                                        </div>

                                        <div class="flex-col gap-4">
                                            <asp:Label ID="lblDepartamentoResidencia" runat="server" Text="Departamento de Residencia" CssClass="text-item text-semibold text-gray-700 text-center" />
                                            <asp:DropDownList ID="cmbDepartamentoResidencia" runat="server" CssClass="text-box dropdown" AutoPostBack="true" OnSelectedIndexChanged="cmbDepartamentoResidencia_SelectedIndexChanged" />
                                        </div>

                                        <div class="flex-col gap-4">
                                            <asp:Label ID="lblMunicipioResidencia" runat="server" Text="Municipio de Residencia" CssClass="text-item text-semibold text-gray-700 text-center" />
                                            <asp:DropDownList ID="cmbMunicipioResidencia" runat="server" CssClass="text-box dropdown" AutoPostBack="true" OnSelectedIndexChanged="cmbMunicipioResidencia_SelectedIndexChanged" />
                                            <br />
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <asp:UpdatePanel runat="server" class=" flex-col gap-16">
                                    <ContentTemplate>

                                        <div class="flex-col gap-4">
                                            <asp:Label ID="lblPaisNacimiento" runat="server" Text="País de Nacimiento" CssClass="text-item text-semibold text-gray-700 text-center" />
                                            <asp:DropDownList ID="cmbPaisNacimiento" runat="server" CssClass="text-box dropdown" AutoPostBack="true" OnSelectedIndexChanged="cmbPaisNacimiento_SelectedIndexChanged" />
                                            <asp:RequiredFieldValidator ValidationGroup="formDatosBasicos" ID="rfvPaisNacimiento" runat="server" ControlToValidate="cmbPaisNacimiento" InitialValue="0" ErrorMessage="Seleccione el país de Nacimiento" CssClass="required-field-validator" />
                                        </div>

                                        <div class="flex-col gap-4">
                                            <asp:Label ID="lblDepartamentoNacimiento" runat="server" Text="Departamento de Nacimiento" CssClass="text-item text-semibold text-gray-700 text-center" />
                                            <asp:DropDownList ID="cmbDepartamentoNacimiento" runat="server" CssClass="text-box dropdown" AutoPostBack="true" OnSelectedIndexChanged="cmbDepartamentoNacimiento_SelectedIndexChanged" />
                                            <asp:RequiredFieldValidator ValidationGroup="formDatosBasicos" ID="rfvDepartamentoNacimiento" runat="server" ControlToValidate="cmbDepartamentoNacimiento" InitialValue="0" ErrorMessage="Seleccione el departamento de Nacimiento" CssClass="required-field-validator" />
                                        </div>

                                        <div class="flex-col gap-4">
                                            <asp:Label ID="lblMunicipioNacimiento" runat="server" Text="Municipio de Nacimiento" CssClass="text-item text-semibold text-gray-700 text-center" />
                                            <asp:DropDownList ID="cmbMunicipioNacimiento" runat="server" CssClass="text-box dropdown" AutoPostBack="true" OnSelectedIndexChanged="cmbMunicipioNacimiento_SelectedIndexChanged" />
                                            <asp:RequiredFieldValidator ValidationGroup="formDatosBasicos" ID="rfvMunicipioNacimiento" runat="server" ControlToValidate="cmbMunicipioNacimiento" InitialValue="0" ErrorMessage="Seleccione el municipio de Nacimiento" CssClass="required-field-validator" />
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>


                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="flex-col hidden" runat="server" id="formEstudios" visible="true">
                        <asp:UpdatePanel runat="server" ID="udpEstudios" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:Label Text="" ID= "lblTypeModifyAcademia" runat="server" CssClass="hidden" />
                                        <asp:Label Text="" ID= "lblIdAcademia" runat="server" CssClass="hidden" />
                                        <asp:Label Text="" ID= "lblIdPersonaAcademia" runat="server" CssClass="hidden"/>

                                        <div class="flex-col gap-4">
                                            <asp:Label ID="lblTituloEstudios" runat="server" Text="Título de Estudios" CssClass="text-item text-semibold text-gray-700 text-center" />
                                            <asp:TextBox ID="txtTituloEstudios" runat="server" CssClass="text-box" />
                                            <asp:RequiredFieldValidator ValidationGroup="formEstudio" ID="rfvTituloEstudios" runat="server" ControlToValidate="txtTituloEstudios" ErrorMessage="Ingrese el Título de Estudios" CssClass="required-field-validator" />
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>


                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="flex-col gap-4">
                                            <asp:Label ID="lblPaisEstudios" runat="server" Text="País donde Estudiaste" CssClass="text-item text-semibold text-gray-700 text-center" />
                                            <asp:DropDownList ID="cmbPaisEstudios" runat="server" CssClass="text-box dropdown" AutoPostBack="true" OnSelectedIndexChanged="cmbPaisEstudios_SelectedIndexChanged" />
                                            <asp:RequiredFieldValidator ValidationGroup="formEstudio" ID="rfvPaisEstudios" runat="server" ControlToValidate="cmbPaisEstudios" InitialValue="0" ErrorMessage="Seleccione la País donde estudiaste" CssClass="required-field-validator" />
                                        </div>

                                        <div class="flex-col gap-4">
                                            <asp:Label ID="lblDepartamentoEstudios" runat="server" Text="Departamento donde Estudiaste" CssClass="text-item text-semibold text-gray-700 text-center" />
                                            <asp:DropDownList ID="cmbDepartamentoEstudios" runat="server" CssClass="text-box dropdown" AutoPostBack="true" OnSelectedIndexChanged="cmbDepartamentoEstudios_SelectedIndexChanged" />
                                            <asp:RequiredFieldValidator ValidationGroup="formEstudio" ID="rfvDepartamentoEstudios" runat="server" ControlToValidate="cmbDepartamentoEstudios" InitialValue="0" ErrorMessage="Seleccione la Departamento donde estudiaste" CssClass="required-field-validator" />
                                        </div>

                                        <div class="flex-col gap-4">
                                            <asp:Label ID="lblMunicipioEstudios" runat="server" Text="Ciudad donde Estudiaste" CssClass="text-item text-semibold text-gray-700 text-center" />
                                            <asp:DropDownList ID="cmbMunicipioEstudios" runat="server" CssClass="text-box dropdown" AutoPostBack="true" OnSelectedIndexChanged="cmbMunicipioEstudios_SelectedIndexChanged" />
                                            <asp:RequiredFieldValidator ValidationGroup="formEstudio" ID="rfvMunicipioEstudios" runat="server" ControlToValidate="cmbMunicipioEstudios" InitialValue="0" ErrorMessage="Seleccione la ciudad donde estudiaste" CssClass="required-field-validator" />
                                        </div>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="flex-col gap-4">
                                            <asp:Label ID="lblInstitucionEstudios" runat="server" Text="Institución Educativa" CssClass="text-item text-semibold text-gray-700 text-center" />
                                            <asp:TextBox ID="txtInstitucionEstudios" runat="server" CssClass="text-box" />
                                            <asp:RequiredFieldValidator ValidationGroup="formEstudio" ID="rfvInstitucionEstudios" runat="server" ControlToValidate="txtInstitucionEstudios" ErrorMessage="Ingrese la institución educativa" CssClass="required-field-validator" />
                                        </div>


                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>

                                        <div class="flex-col gap-4">
                                            <asp:Label ID="lblNivelEducativoEstudio" runat="server" Text="Nivel Educativo" CssClass="text-item text-semibold text-gray-700 text-center" />
                                            <asp:DropDownList ID="cmbNivelEducativoEstudio" runat="server" CssClass="text-box dropdown" AutoPostBack="true" OnSelectedIndexChanged="cmbNivelEducativoEstudio_SelectedIndexChanged" />
                                            <asp:RequiredFieldValidator ValidationGroup="formEstudio" ID="rfvNivelEducativoEstudio" runat="server" ControlToValidate="cmbNivelEducativoEstudio" InitialValue="0" ErrorMessage="Seleccione el Nivel Educativo" CssClass="required-field-validator" />
                                        </div>

                                        <div class="flex-col gap-4">
                                            <asp:Label ID="lblOcupacionEstudio" runat="server" Text="Ocupación" CssClass="text-item text-semibold text-gray-700 text-center" />
                                            <asp:DropDownList ID="cmbOcupacionEstudio" runat="server" CssClass="text-box dropdown" AutoPostBack="true" OnSelectedIndexChanged="cmbOcupacionEstudio_SelectedIndexChanged" />
                                            <asp:RequiredFieldValidator ValidationGroup="formEstudio" ID="rfvOcupacionEstudio" runat="server" ControlToValidate="cmbOcupacionEstudio" InitialValue="0" ErrorMessage="Seleccione la Ocupación" CssClass="required-field-validator" />
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="flex-col gap-4">
                                            <asp:Label ID="lblFechaGraduacion" runat="server" Text="Fecha de Graduación" CssClass="text-item text-semibold text-gray-700 text-center" />
                                            <asp:TextBox ID="txtFechaGraduacion" runat="server" TextMode="Date" CssClass="text-box" />
                                            <asp:RequiredFieldValidator ValidationGroup="formEstudio" ID="rfvFechaGraduacion" runat="server" ControlToValidate="txtFechaGraduacion" ErrorMessage="Ingrese la fecha de Graduación" CssClass="required-field-validator" />
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>

                    <div class="flex-col hidden" runat="server" id="formExperiencias">
                        <asp:UpdatePanel runat="server" >
                            <ContentTemplate>



                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:Label Text="" runat="server" ID="lblIdExperiencia"  CssClass="hidden"/>
                                        <asp:Label Text="text" ID="lblTypeModifyExperiencia" CssClass="hidden" runat="server" />
                                        <asp:Label Text="" runat="server" ID="lblIdPersonaExperiencia" CssClass="hidden" />

                                        <div class="flex-col gap-4">
                                            <asp:Label ID="lblNombreCargo" runat="server" Text="Nombre del Cargo" CssClass="text-item text-semibold text-gray-700 text-center" />
                                            <asp:TextBox ID="txtNombreCargo" runat="server" CssClass="text-box" />
                                            <asp:RequiredFieldValidator ValidationGroup="formExperiencia" ID="rfvNombreCargo" runat="server" ControlToValidate="txtNombreCargo" ErrorMessage="Ingrese el Nombre del Cargo" CssClass="required-field-validator" />
                                        </div>

                                        <div class="flex-col gap-4">
                                            <asp:Label ID="lblPerfilProfecional" runat="server" Text="Perfil Profecional" CssClass="text-item text-semibold text-gray-700 text-center" />
                                            <asp:TextBox ID="txtPerfilProfecional" runat="server" TextMode="MultiLine" CssClass="text-area" />
                                            <asp:RequiredFieldValidator ValidationGroup="formExperiencia" ID="rfvPerfilProfecional" runat="server" ControlToValidate="txtPerfilProfecional" ErrorMessage="Ingrese el Perfil Profecional" CssClass="required-field-validator" />
                                        </div>


                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>

                                        <div class="flex-col gap-4">
                                            <asp:Label ID="lblPaisExperiencia" runat="server" Text="Pais" CssClass="text-item text-semibold text-gray-700 text-center" />
                                            <asp:DropDownList ID="cmbPaisExperiencia" runat="server" CssClass="text-box dropdown"  AutoPostBack="true"
                                                OnSelectedIndexChanged="cmbPaisExperiencia_SelectedIndexChanged"    />
                                            <asp:RequiredFieldValidator ValidationGroup="formExperiencia" ID="rfvPaisExperiencia" runat="server" ControlToValidate="cmbPaisExperiencia" InitialValue="0" ErrorMessage="Seleccione la Pais donde trabajaste" CssClass="required-field-validator" />
                                        </div>

                                        <div class="flex-col gap-4">
                                            <asp:Label ID="lblDepartamentoExperiencia" runat="server" Text="Departamento" CssClass="text-item text-semibold text-gray-700 text-center" />
                                            <asp:DropDownList ID="cmbDepartamentoExperiencia" runat="server" CssClass="text-box dropdown" 
                                                AutoPostBack="true" OnSelectedIndexChanged="cmbDepartamentoExperiencia_SelectedIndexChanged"/>
                                            <asp:RequiredFieldValidator ValidationGroup="formExperiencia" ID="rfvDepartamentoExperiencia" runat="server" ControlToValidate="cmbDepartamentoExperiencia" InitialValue="0" ErrorMessage="Seleccione la Departamento donde trabajaste" CssClass="required-field-validator" />
                                        </div>

                                        <div class="flex-col gap-4">
                                            <asp:Label ID="lblMunicipioExperiencia" runat="server" Text="Municipio" CssClass="text-item text-semibold text-gray-700 text-center" />
                                            <asp:DropDownList ID="cmbMunicipioExperiencia" runat="server" CssClass="text-box dropdown" AutoPostBack="true"/>
                                            <asp:RequiredFieldValidator ValidationGroup="formExperiencia" ID="rfvMunicipioExperiencia" runat="server" ControlToValidate="cmbMunicipioExperiencia" InitialValue="0" ErrorMessage="Seleccione la Municipio donde trabajaste" CssClass="required-field-validator" />
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>

                                        <div class="flex-col gap-4">
                                            <asp:Label ID="lblNivelEducativoExperiencia" runat="server" Text="Nivel Educativo" CssClass="text-item text-semibold text-gray-700 text-center" />
                                            <asp:DropDownList ID="cmbNivelEducativoExperiencia" runat="server" CssClass="text-box dropdown" 
                                                AutoPostBack ="true" OnSelectedIndexChanged="cmbNivelEducativoExperiencia_SelectedIndexChanged"   />
                                            <asp:RequiredFieldValidator ValidationGroup="formExperiencia" ID="rfvNivelEducativoExperiencia" runat="server" ControlToValidate="cmbNivelEducativoExperiencia" InitialValue="0" ErrorMessage="Seleccione el Nivel Educativo" CssClass="required-field-validator" />
                                        </div>

                                        <div class="flex-col gap-4">
                                            <asp:Label ID="lblOcupacionExperiencia" runat="server" Text="Ocupación" CssClass="text-item text-semibold text-gray-700 text-center" />
                                            <asp:DropDownList ID="cmbOcupacionExperiencia" runat="server" CssClass="text-box dropdown"  AutoPostBack="true"/>
                                            <asp:RequiredFieldValidator ValidationGroup="formExperiencia" ID="rfvOcupacionExperiencia" runat="server" ControlToValidate="cmbOcupacionExperiencia" InitialValue="0" ErrorMessage="Seleccione la Ocupación" CssClass="required-field-validator" />
                                        </div>


                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel runat="server" ID="updFechas" >
                                    <ContentTemplate>

                                        <div class="flex-col gap-4">
                                            <asp:Label ID="lblTiempoCargo" runat="server" Text="Tiempo Cargo" CssClass="text-item text-semibold text-gray-700 text-center" />
                                            <asp:TextBox ID="txtTiempoCargo" runat="server" CssClass="text-box" />
                                            <asp:RequiredFieldValidator ValidationGroup="formExperiencia" ID="rfvTiempoCargo" runat="server" ControlToValidate="txtPerfilProfecional" ErrorMessage="Ingrese el Tiempo del cargo" CssClass="required-field-validator" />
                                        </div>


                                        <div class="flex-col gap-4">
                                            <asp:Label ID="lblFechaIniExperiencia" runat="server" Text="Fecha de Inicio" CssClass="text-item text-semibold text-gray-700 text-center" />
                                            <asp:TextBox ID="txtFechaIniExperiencia" runat="server" TextMode="Date" CssClass="text-box" />
                                            <asp:RequiredFieldValidator ValidationGroup="formExperiencia" ID="rfvFechaIniExperiencia" runat="server" ControlToValidate="txtFechaIniExperiencia" ErrorMessage="Ingrese la fecha de Inicio" CssClass="required-field-validator" />
                                        </div>

                                        <div class="flex-col gap-4">
                                            <asp:Label ID="lblFechaFinExperiencia" runat="server" Text="Fecha de Fin" CssClass="text-item text-semibold text-gray-700 text-center" />
                                            <asp:TextBox ID="txtFechaFinExperiencia" runat="server" TextMode="Date" CssClass="text-box" />
                                            <asp:RequiredFieldValidator ValidationGroup="formExperiencia" ID="rfvFechaFinExperiencia" runat="server" ControlToValidate="txtFechaFinExperiencia" ErrorMessage="Ingrese la fecha de Fin" CssClass="required-field-validator" />
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
      





                <script type="module">

                    let prm = Sys.WebForms.PageRequestManager.getInstance();
                    function executeScripts() {
                        contadorTexto(<%= txtPerfil.ClientID %>, <%= lblCuentaCaracteres.ClientID %>, 2000);
                        showNameFileUpload(<%= FileUploadCv.ClientID %>, <%=namePreviewFile.ClientID %>);
                        showNameFileUpload('<%= fuAvatar.ClientID %>', '<%= lblFuAvatar.ClientID %>');
                        showContainer(<%= FileUploadCv.ClientID%>, "input", <%= previewFile.ClientID%>);
                    }

                    executeScripts()

                    prm.add_endRequest(function () {
                        executeScripts()
                    });

                </script>

                

        <script type="text/javascript">
                    function showModal(nameForm) {


                        const modal = document.getElementById('Main_openModal')
                        const bmodal = document.querySelector(".modal-body")
                        modal.style.display = 'flex';
                        const form = document.querySelector("#" + nameForm)
                        if (nameForm !== null)
                            form.classList.remove("hidden")
                        bmodal.appendChild(form);

                    }
                    function CloseModal() {
                        const bmodal = document.querySelector(".modal-body")
                        const modal = document.getElementById('Main_openModal');
                        const wrapperHidden = document.querySelector('#wrapperHidden');
                        bmodal.childNodes[1].classList.add("hidden")
                        wrapperHidden.appendChild(bmodal.childNodes[1])

                        modal.style.display = 'none';
                        
                    }
                </script>    </section>

           

            <asp:UpdatePanel id="openModal" class="modalDialog overflow-y-scroll" runat="server" MaintainScrollPositionOnPostback="true" UpdateMode="Conditional">
                <ContentTemplate>
                <div class="flex-col flex-center">
                    <svg xmlns="http://www.w3.org/2000/svg" onclick="javascript:CloseModal();" class="icon-24 pointer color-gray-700 closed" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                        <path stroke-linecap="round" stroke-linejoin="round" d="M6 18L18 6M6 6l12 12" />
                    </svg>
                    <asp:Panel runat="server" ID="modalCV" CssClass="modal-body flex flex-center max-w-850px">
                    </asp:Panel>

                    <div class="flex-center flex-wrap gap-16">
                        <asp:Button ID="btnModalCacel" Visible="true" runat="server" CssClass="button bg-red-500" Text="Cancelar" OnClick="btnModalCancel_Click" />
                        <asp:Button ID="btnModalAvatarSubmit" Visible="false" runat="server" CssClass="button" Text="Subir Foto" ValidationGroup="avatar" OnClick="btnModalAvatarSubmit_Click" />
                        <asp:Button ID="btnModalSubmmit" Visible="false" runat="server" CssClass="button " Text="Actualizar" ValidationGroup="formDatosBasicos" OnClick="btnModalSubmmit_Click" />
                        <asp:Button ID="btnModalEstudiosSubmit" Visible="false" runat="server" CssClass="button" Text="Actualizar" ValidationGroup="formEstudio" OnClick="btnModalEstudiosSubmit_Click" />
                        <asp:Button ID="btnModalExperienciaSubmit" Visible="false" runat="server" CssClass="button" Text="Actualizar" ValidationGroup="formExperiencia" OnClick="btnModalExperienciaSubmit_Click" />
                        <asp:Button ID="btnModalEliminarEstudio" Text="Si, eliminar" runat="server" CssClass="button" Visible = "false" OnClick="btnModalEliminarEstudio_Click"/>
                        <asp:Button ID="btnModalEliminarExperiencia" Text="Si, eliminar" runat="server" CssClass="button" Visible = "false" OnClick="btnModalEliminarExperiencia_Click"/>
                    </div>
                </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUploadDocs" />
            <asp:PostBackTrigger ControlID="btnModalAvatarSubmit" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
