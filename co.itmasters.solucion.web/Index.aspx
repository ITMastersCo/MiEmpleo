<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="co.itmasters.solucion.web.Index"
    EnableEventValidation="false"
      %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Home</title>
    <link href="~/Images/imgInicio/MiEmpleo.ico" type="image/x-icon" rel="shortcut icon" />
    <link rel="stylesheet" href="./css/home.css" />
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
</head>
<body>

    <form id="frmIndex" runat="server">

        <div>


            <asp:UpdatePanel runat="server" style="display: flex;flex-direction: column; gap: 32px;" >
                <ContentTemplate>

                <header class="header">

                    <!-- OpenMenu -->

                    <label class="iconMenu center pointer" for="chkOpenMenu" id="LblMenu">
                        <img src="./images/ImgInicio/menu-bars.svg" alt="" />
                    </label>
                    <input class="chkOpenMenu" type="checkbox" id="chkOpenMenu" />
                    <nav class="wrapper-menu-main" id="main-menu">
                        <ul class="content-menu">
                            <li><a class="item-menu" href="#">Sobre Nosotros</a></li>
                            <li><a class="item-menu" href="#">Contenido de Valor</a></li>
                            <li><a class="item-menu" href="./InternaEmpresa.aspx">Empresa / Publicar oferta gratis</a></li>
                            <li><a class="item-menu" href="#">Centro de Ayuda</a></li>
                        </ul>
                    </nav>
                    <a href="#" class="logo center">
                        <img src="./images/ImgInicio/LOGO.png" alt="" />
                    </a>

                    <a href="./InternaEmpresa.aspx" class="tech text-bold center">Empresa / Publicar oferta gratis
                    </a>
                    <a class="loginIcon center" href="./Home/Login.aspx">
                        <img src="./images/ImgInicio/user.svg" alt="Inicia Sesión" />
                    </a>
                    <a href="./Home/Login.aspx" class="loginIconDesktop button-ghost">
                        <p class="text-normal">Acceder</p>
                        <img src="./images/ImgInicio/user.svg" alt="" />
                    </a>
                    <a href="./Home/RegistroCandidato.aspx">
                        <p class="button text-normal">Crear mi hoja de vida </p>
                    </a>
                </header>
                <%--<main>--%>

                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                    <!--Banner -->
                    <section class="banner">
                        <div class="info-banner">
                            <h1 class="text-title">¡Busca ahora la <span class="text-highlighted text-title">oferta de empleo</span> que se adapte a tu perfil!
                            </h1>
                            <div class="form">

                                <input type="text" name="" class="input" placeholder="Cargo u ocupación" id="" />
                                <input type="text" name="" class="input" placeholder="Ciudad" id="" />
                                <a href="#">
                                    <button class="button text-normal">Buscar Oferta</button></a>


                            </div>
                        </div>
                        <img src="./images/ImgInicio/mujer-entrevista 1.png" class="desktop" alt="" />
                    </section>

                    <!-- Offers -->

                    <div class="wrapper offers">
                        <h2 class="text-subtitle"><span class="text-highlighted text-subtitle">Ofertas</span>  destacadas</h2>


                        <asp:GridView ID="grdOfertasDestacadas" runat="server" AutoGenerateColumns="false"
                            OnRowCommand="grdOfertasDestacadas_RowCommand" >
                            <columns>
                                <asp:TemplateField Visible="false">
                                    <itemtemplate>
                                        <asp:Label ID="idOferta" runat="server" Text='<%# Eval("idOferta") %>'></asp:Label>

                                    </itemtemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <itemtemplate>
                                        <asp:Label runat="server" class="card_offer space-between pointer" AssociatedControlID="btnViewOffer">
                                            <div class="flex-center-v gap-4">
                                            <div class="flex-col ">
                                                <div class="line">
                                                </div>
                                                <div class="avatar-rectangle">
                                                    <img src="Images/ImgInicio/AvatarEmpresa.jpg" alt="Alternate Text" />

                                                </div>
                                            </div>

                                            <div class="flex-col gap-8">
                                                <div class="flex-center-v gap-16 max-w-300">
                                                    <h4 runat="server" id="offerTitle" class="text-item color-gray-800 text-semibold truncate">
                                                        <%#  Eval("tituloVacante")%>
                                                    </h4>
                                                    <%-- <span class="flex-center-v gap-4">

                                            <svg class="icon-16 color-gray-700" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                                <path stroke-linecap="round" stroke-linejoin="round" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
                                                <path stroke-linecap="round" stroke-linejoin="round" d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z" />
                                            </svg>


                                            <span runat="server" id="offerViews" class="text-small text-medium color-gray-700">2

                                            </span>
                                        </span>--%>
                                                </div>
                                                <div class="flex-center-v gap-16">
                                                    <span class="flex-center-v gap-4">
                                                        <svg xmlns="http://www.w3.org/2000/svg" class="icon-16 color-gray-700" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                                            <path stroke-linecap="round" stroke-linejoin="round" d="M19 21V5a2 2 0 00-2-2H7a2 2 0 00-2 2v16m14 0h2m-2 0h-5m-9 0H3m2 0h5M9 7h1m-1 4h1m4-4h1m-1 4h1m-5 10v-5a1 1 0 011-1h2a1 1 0 011 1v5m-4 0h4" />
                                                        </svg>

                                                        <asp:Label ToolTip='<%# Eval("nomEmpresa") %>' runat="server" ID="offerUserWhoPublished" 
                                                            class="text-small text-regular color-gray-700 truncate max-w-148px">
                                                    <%# Eval("nomEmpresa") %>
                                                        </asp:Label>
                                                    </span>
                                                    <p runat="server" id="offerDate" class="text-small  text-regular color-gray-500">
                                                        <%# String.Format("{0:yyyy-MM-dd}", Eval("fechaPublicacion")) %>
                                                    </p>
                                                </div>
                                                <div class=" flex-center-v gap-16">



                                                    <span class="flex-center-v gap-4">
                                                        <svg class="icon-16 color-green-500" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor">
                                                            <path stroke-linecap="round" stroke-linejoin="round" d="M2.25 18.75a60.07 60.07 0 0115.797 2.101c.727.198 1.453-.342 1.453-1.096V18.75M3.75 4.5v.75A.75.75 0 013 6h-.75m0 0v-.375c0-.621.504-1.125 1.125-1.125H20.25M2.25 6v9m18-10.5v.75c0 .414.336.75.75.75h.75m-1.5-1.5h.375c.621 0 1.125.504 1.125 1.125v9.75c0 .621-.504 1.125-1.125 1.125h-.375m1.5-1.5H21a.75.75 0 00-.75.75v.75m0 0H3.75m0 0h-.375a1.125 1.125 0 01-1.125-1.125V15m1.5 1.5v-.75A.75.75 0 003 15h-.75M15 10.5a3 3 0 11-6 0 3 3 0 016 0zm3 0h.008v.008H18V10.5zm-12 0h.008v.008H6V10.5z" />
                                                        </svg>

                                                        <span runat="server" id="offerSalaryRange" class="text-small text-medium color-green-500">
                                                            <%# Eval("RangoSalario")%>
                                                        </span>
                                                    </span>
                                                    <span class="flex-center-v gap-4">
                                                        <svg class="icon-16 color-gray-500" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor">
                                                            <path stroke-linecap="round" stroke-linejoin="round" d="M15 10.5a3 3 0 11-6 0 3 3 0 016 0z" />
                                                            <path stroke-linecap="round" stroke-linejoin="round" d="M19.5 10.5c0 7.142-7.5 11.25-7.5 11.25S4.5 17.642 4.5 10.5a7.5 7.5 0 1115 0z" />
                                                        </svg>

                                                        <span runat="server" id="offerLocation" class="text-small text-regular color-gray-500">
                                                            <%# Eval("nomCiudad")%>
                                                        </span>
                                                    </span>

                                                </div>
                                            </div>
                                        <asp:Button Text="" runat="server" ID="btnViewOffer" 
                                            CommandArgument="<%# Container.DataItemIndex %>" CommandName="GET" ToolTip="Ver" OnCommand="btnViewOffer_Command"  />
                                            </div>



                                            <div class=" flex-col gap-32">

                                                <div class="flex-center-v gap-4">

                                                    <asp:Label ID="lblOfferEdit" runat="server" Text="" AssociatedControlID="btnOfferEdit">
                                                        <asp:Button ID="btnOfferEdit" runat="server" Text="Button" Visible="false" />
                                                        <svg class="icon-24 pointer color-white" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                                            <path stroke-linecap="round" stroke-linejoin="round" d="M15.232 5.232l3.536 3.536m-2.036-5.036a2.5 2.5 0 113.536 3.536L6.5 21.036H3v-3.572L16.732 3.732z" />
                                                        </svg>
                                                    </asp:Label>

                                                </div>

                                                <div class="flex-center-v gap-4 justify-end">

                                                    <svg class="icon-16 color-gray-700" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                                        <path stroke-linecap="round" stroke-linejoin="round" d="M12 4.354a4 4 0 110 5.292M15 21H3v-1a6 6 0 0112 0v1zm0 0h6v-1a6 6 0 00-9-5.197M13 7a4 4 0 11-8 0 4 4 0 018 0z" />
                                                    </svg>

                                                    <span runat="server" id="offerAppications" class="text-normal text-medium color-gray-700">
                                                        <%# Eval("cantidadVacantes") %>
                                                    </span>

                                                </div>

                                            </div>

                                        </asp:Label>
                                    </itemtemplate>
                                </asp:TemplateField>
                            </columns>
                        </asp:GridView>
                        


                    </div>

                    <!-- Benefit -->
                    <section class="wrapper benefit">


                        <h2 class="text-subtitle">Beneficios  de <span class="text-highlighted text-subtitle">miempleo.co</span>  </h2>

                        <div class="wrapper benefit-content">

                            <div class="benefit-main">
                                <img src="./images/ImgInicio/mujer-entrevista-3.png" class="mobile" alt="mujer-entrevista-" />
                                <img src="./images/ImgInicio/mujer-entrevista 1.png" class="desktop" alt="" />
                                <p class="text-normal">
                                    En <span class="text-highlighted text-normal">Miempleo.co</span>  te ayudamos a conseguir 
                        el trabajo de tus sueños, tenemos ofertas 
                        de trabajo que mejoran tu perfil laboral 
                        y se ajustan a tus necesidades.
                                </p>
                                <a href="#">
                                    <button class="button text-normal">Quiero Saber Más</button></a>
                            </div>

                        </div>


                    </section>


                    <!-- Customers -->
                    <section class="customers wrapper">
                        <h2 class="text-subtitle"><span class="text-subtitle text-highlighted">Nuestros</span> Clientes</h2>
                        <div class="slider">
                            <span>
                                <img class="arrowLeft" src="./images/ImgInicio/flecha-candidato.svg" alt="" /></span>
                            <div class="carousel">
                                <article class="customers-content">
                                    <img src="./images/ImgInicio/userComment.png" alt="" />
                                    <h3 class="text-highlighted text-title-section">Diego Ramirez</h3>
                                    <p class="text-normal">Gracias a ellos consegi un empleo en lo que me fguata y puedo tener un trabajo remunerado</p>
                                    <img src="./images/ImgInicio/Calificacion.png" alt="" />
                                </article>
                            </div>
                            <span>
                                <img class="arrowRight" src="./images/ImgInicio/flecha-candidato.svg" alt="" /></span>
                        </div>
                    </section>

                <%--</main>--%>


                <footer>
                    <div class="wrapper footer mobile">

                        <img src="./images/ImgInicio/LOGO-2.png" alt="" />
                        <p class="text-title-section text-bold">
                            Mi <span class="text-highlighted text-title-section">Empleo </span>
                            tueherramienta perfecta para encontrar trabjo en poco tiempo
                        </p>
                        <a href="#">
                            <button class="button text-normal">Crear Hoja de vida</button></a>
                        <span>
                            <ul class="social">
                                <li><a href="#">
                                    <img src="./images/ImgInicio/facebook.svg" alt="" /></a></li>
                                <li><a href="#">
                                    <img src="./images/ImgInicio/group.svg" alt="" /></a></li>
                                <li><a href="#">
                                    <img src="./images/ImgInicio/gmiail.svg" alt="" /></a></li>
                                <li><a href="#">
                                    <img src="./images/ImgInicio/whatsapp.svg" alt="" /></a></li>
                            </ul>
                        </span>
                    </div>
                    <div>
                        <nav class="footer desktop">

                            <a href="#">
                                <img src="./images/ImgInicio/LOGO-2.png" alt="" /></a>
                            <ul class="menu-footer ">
                                <li><a href="#">Inicio</a></li>
                                <li><a href="#">Contenido de Valor</a></li>
                                <li><a href="#">Sobre Nosotros</a></li>
                                <li><a href="#">Empresa/Publicar vacante gratis</a></li>

                            </ul>
                            <ul class="menu-footer ">
                                <li><a href="#">Dirección</a></li>
                                <li><a href="#">Contactenos</a></li>
                                <li><a href="#">Registrate</a></li>
                                <li><a href="#">PQRF</a></li>

                            </ul>
                            <span class="footer-social">
                                <a href="#">
                                    <button class="button text-normal">¡Siguenos!</button></a>
                                <ul class="social">
                                    <li><a href="#">
                                        <img src="./images/ImgInicio/facebook.svg" alt="" /></a></li>
                                    <li><a href="#">
                                        <img src="./images/ImgInicio/group.svg" alt="" /></a></li>
                                    <li><a href="#">
                                        <img src="./images/ImgInicio/gmiail.svg" alt="" /></a></li>
                                    <li><a href="#">
                                        <img src="./images/ImgInicio/whatsapp.svg" alt="" /></a></li>
                                </ul>
                            </span>
                        </nav>
                    </div>
                </footer>
        <script type="module" src="./Scripts/Index.js"></script>

                    <div id="wrapperHidden" class="hidden">
                        <article runat="server" id="detalleOferta" class="flex-col gap-8 hidden">


                        <div runat="server" class="flex-center-v gap-4 pointer" >
                            <div class="flex-col ">
                                <div class="line">
                                </div>
                                <div class="avatar-rectangle-80">
                                    <img src="Images/ImgInicio/AvatarEmpresa.jpg" alt="Alternate Text" />

                                </div>
                            </div>

                            <div class="flex-col gap-8">
                                <div class="flex-center-v gap-16">
                                    <asp:Label runat="server" ID="lblOfferTitle" class="text-item color-gray-800 text-semibold">

                                    </asp:Label>
                                  </div>
                                <div class="flex-center-v gap-16">
                                    <span class="flex-center-v gap-4">
                                        <svg xmlns="http://www.w3.org/2000/svg" class="icon-16 color-gray-700" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                            <path stroke-linecap="round" stroke-linejoin="round" d="M19 21V5a2 2 0 00-2-2H7a2 2 0 00-2 2v16m14 0h2m-2 0h-5m-9 0H3m2 0h5M9 7h1m-1 4h1m4-4h1m-1 4h1m-5 10v-5a1 1 0 011-1h2a1 1 0 011 1v5m-4 0h4" />
                                        </svg>

                                        <asp:Label runat="server" ID="lblOfferUserWhoPublished" class="text-normal text-regular color-gray-700">
                                                    
                                        </asp:Label>
                                    </span>
                                </div>
                                <div class=" flex-center-v gap-16">



                                    <span class="flex-center-v gap-4">
                                        <svg class="icon-16 color-green-500" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor">
                                            <path stroke-linecap="round" stroke-linejoin="round" d="M2.25 18.75a60.07 60.07 0 0115.797 2.101c.727.198 1.453-.342 1.453-1.096V18.75M3.75 4.5v.75A.75.75 0 013 6h-.75m0 0v-.375c0-.621.504-1.125 1.125-1.125H20.25M2.25 6v9m18-10.5v.75c0 .414.336.75.75.75h.75m-1.5-1.5h.375c.621 0 1.125.504 1.125 1.125v9.75c0 .621-.504 1.125-1.125 1.125h-.375m1.5-1.5H21a.75.75 0 00-.75.75v.75m0 0H3.75m0 0h-.375a1.125 1.125 0 01-1.125-1.125V15m1.5 1.5v-.75A.75.75 0 003 15h-.75M15 10.5a3 3 0 11-6 0 3 3 0 016 0zm3 0h.008v.008H18V10.5zm-12 0h.008v.008H6V10.5z" />
                                        </svg>

                                        <asp:Label runat="server" ID="lblOfferSalaryRange" class="text-normal text-medium color-green-500">
                                                            
                                        </asp:Label>
                                    </span>
                                    <span class="flex-center-v gap-4">
                                        <svg class="icon-16 color-gray-500" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor">
                                            <path stroke-linecap="round" stroke-linejoin="round" d="M15 10.5a3 3 0 11-6 0 3 3 0 016 0z" />
                                            <path stroke-linecap="round" stroke-linejoin="round" d="M19.5 10.5c0 7.142-7.5 11.25-7.5 11.25S4.5 17.642 4.5 10.5a7.5 7.5 0 1115 0z" />
                                        </svg>

                                        <asp:Label runat="server" ID="lblOfferLocation" class="text-normal text-regular color-gray-500">
                                                            
                                        </asp:Label>
                                    </span>

                                </div>
                            </div>

                            <div class=" flex-col gap-32">

                                <div class="flex-center-v gap-4">

                                    <asp:Label ID="lblOfferEdit" runat="server" Text="" AssociatedControlID="btnOfferEdit">
                                        <asp:Button ID="btnOfferEdit" runat="server" Text="Button" Visible="false" />
                                        <svg class="icon-24 pointer color-white" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                            <path stroke-linecap="round" stroke-linejoin="round" d="M15.232 5.232l3.536 3.536m-2.036-5.036a2.5 2.5 0 113.536 3.536L6.5 21.036H3v-3.572L16.732 3.732z" />
                                        </svg>
                                    </asp:Label>
                                </div>
                            </div>

                            <asp:Button Text="Postular a Oferta" ID="btnPostularOferta" CssClass="button" runat="server" OnClick="btnPostularOferta_Click"/>
                            
                        </div>
                            <div class="flex space-between">
                                <h4 class="color-gray-600 text-regular">
                                    Fecha de Creación: <asp:Label ID="lblDateCrateOffer" Text="" runat="server" />
                                </h4>
                                <h4 class="color-gray-600 text-regular">
                                    Fecha de Vencimiento: <asp:Label ID="lblDateRemoveOffer"  Text="" runat="server" />
                                </h4> 
                            </div>
                        <div>
                            <asp:Label Text="" runat="server" ID="lblDescriptioOffer" />
                        </div>
                        </article>

                     </div>
            <asp:UpdatePanel id="openModal" class="modalDialog overflow-y-scroll" runat="server" MaintainScrollPositionOnPostback="true" UpdateMode="Conditional">
                <ContentTemplate>
                <div class="flex-col flex-center">
                    <svg xmlns="http://www.w3.org/2000/svg" onclick="javascript:CloseModal();" class="icon-24 pointer color-gray-700 closed" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                        <path stroke-linecap="round" stroke-linejoin="round" d="M6 18L18 6M6 6l12 12" />
                    </svg>
                    <asp:Panel runat="server" ID="modalCV" CssClass="modal-body flex flex-center max-w-850px">
                    </asp:Panel>

                    <%--<div class="flex-center flex-wrap gap-16">
                        <asp:Button ID="btnModalCacel" Visible="false" runat="server" CssClass="button bg-red-500" Text="Cancelar" OnClick="btnModalCancel_Click" />
                        <asp:Button ID="btnModalSubmmit" Visible="false" runat="server" CssClass="button " Text="Actualizar" ValidationGroup="formDatosBasicos" OnClick="btnModalSubmmit_Click" />
                        <asp:Button ID="btnModalEstudiosSubmit" Visible="false" runat="server" CssClass="button" Text="Actualizar" ValidationGroup="formEstudio" OnClick="btnModalEstudiosSubmit_Click" />
                        <asp:Button ID="btnModalExperienciaSubmit" Visible="false" runat="server" CssClass="button" Text="Actualizar" ValidationGroup="formExperiencia" OnClick="btnModalExperienciaSubmit_Click" />
                        <asp:Button ID="btnModalEliminarEstudio" Text="Si, eliminar" runat="server" CssClass="button" Visible = "false" OnClick="btnModalEliminarEstudio_Click"/>
                        <asp:Button ID="btnModalEliminarExperiencia" Text="Si, eliminar" runat="server" CssClass="button" Visible = "false" OnClick="btnModalEliminarExperiencia_Click"/>
                    </div>--%>
                </div>
                </ContentTemplate>
            </asp:UpdatePanel>
                </ContentTemplate>
            </asp:UpdatePanel>

            </div>

         <script type="text/javascript">
                    function showModal(nameForm) {


                        const modal = document.getElementById('openModal')
                        const bmodal = document.querySelector(".modal-body")
                        modal.style.display = 'flex';
                        const form = document.querySelector("#" + nameForm)
                        if (nameForm !== null)
                            form.classList.remove("hidden")
                        bmodal.appendChild(form);

                    }
                    function CloseModal() {
                        const bmodal = document.querySelector(".modal-body")
                        const modal = document.getElementById('openModal');
                        const wrapperHidden = document.querySelector('#wrapperHidden');
                        bmodal.childNodes[1].classList.add("hidden")
                        wrapperHidden.appendChild(bmodal.childNodes[1])

                        modal.classList.add('hidden')
                    }
         </script>
    </form>
</body>
</html>