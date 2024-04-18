<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="co.itmasters.solucion.web.Index"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Home</title>
    <link href="~/Images/imgInicio/MiEmpleo.ico" type="image/x-icon" rel="shortcut icon" />
    <link rel="stylesheet" href="./css/home.css" />
    <style type="text/css" >
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

  
        @media screen and (max-width:800px){
             .modalDialog > div {
                width: 100vw;
                }
            .detalleOferta .flex{
                flex-direction:column;
            }
            .detalleOferta .details{
                align-items:flex-start;
                & span{
                          font-size:var(--font-size-small);
                      }
            }
            .detalleOferta .lblOfferUserWhoPublished{
                text-align:center;
                font-size:var(--font-size-small);
            }
            .detalleOferta .icon-lblOfferUserWhoPublished{
                display:none;
            }
            .detalleOferta .lblOfferTitle{
                justify-content:center;
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
    <style media="screen" >

    </style>
</head>
<body>

    <form id="frmIndex" runat="server">

        <div>


            <asp:UpdatePanel runat="server" style="display: flex; flex-direction: column; gap: 32px;">
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
                            <img src="./images/ImgInicio/Logo-horizontal.webp" alt="" />
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

                     <asp:ScriptManager ID="ScriptManagerIndex" runat="server" EnablePageMethods="true" OnAsyncPostBackError="ScriptManager1_AsyncPostBackError">

 </asp:ScriptManager>

                    <!--Banner -->
                    <section class="banner" style="height:min-content;">
                        <%--<div class="info-banner">
                            <h1 class="text-title">¡Busca ahora la <span class="text-highlighted text-title">oferta de empleo</span> que se adapte a tu perfil!
                            </h1>
                            <div class="form">

                                <input type="text" name="" class="input" placeholder="Cargo u ocupación" id="" />
                                <input type="text" name="" class="input" placeholder="Ciudad" id="" />
                                <a href="./Home/LogIn.aspx" class="button text-normal color-white">Buscar Oferta
                                </a>


                            </div>
                        </div>--%>
                        <div>

                            <div class="flex-col flex-center-h w-100per">
                                <asp:UpdatePanel runat="server" class=" flex-col  p-x-16  gap-40 w-100per">
                                    <ContentTemplate>
                                        <h1 id="titleDisplay" style="margin: auto;" class="text-subtitle text-center max-w-850px">¡Busca ahora la <span class="text-subtitle color-500">oferta de empleo </span>que se adapte a tu perfil!
                                        </h1>

                                        <div>

                                            <div id="buscardor" class="flex-col p-16 flex-center-v bg-color-100 gap-16 rounded max-w-850px m-5" 
                                                style="margin:0 32px;"
                                                >
                                                <div class="flex flex-center-v  gap-8 md-800:flex-col">

                                                    <div class="w-100per flex-col flex-center-v">

                                                        <div class="flex relative w-100per input-i-l text-box">
                                                            <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                                                <path stroke-linecap="round" stroke-linejoin="round" d="M21 13.255A23.931 23.931 0 0112 15c-3.183 0-6.22-.62-9-1.745M16 6V4a2 2 0 00-2-2h-4a2 2 0 00-2 2v2m4 6h.01M5 20h14a2 2 0 002-2V8a2 2 0 00-2-2H5a2 2 0 00-2 2v10a2 2 0 002 2z" />
                                                            </svg>
                                                            <asp:TextBox runat="server" ID="txtBuscarCargo" CssClass="truncate" autocomplete="off"
                                                                placeholder="Cargo u Ocupación" oninput="validatAndShowAutoComplete(event,showAutocompleteOcupations);" />
                                                            <asp:TextBox ID="txtIdOcupacion" Text="" runat="server" CssClass="hidden" />

                                                            <select size="4" id="selAutocompletadoOcupations" runat="server" style="display: none" class="list-autofill"
                                                                onchange="seleccionarAutocomplete(event)" onmouseleave="ocultarAutocomplete(event)">
                                                            </select>
                                                        </div>

                                                        <asp:TextBox ID="txtSearch" runat="server" CssClass="hidden" />

                                                    </div>

                                                    <div class="w-100per flex-col flex-center-v">
                                                        <div class="flex-col w-100per">

                                                            <div class="flex relative w-100per input-i-l text-box">
                                                                <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                                                    <path stroke-linecap="round" stroke-linejoin="round" d="M17.657 16.657L13.414 20.9a1.998 1.998 0 01-2.827 0l-4.244-4.243a8 8 0 1111.314 0z" />
                                                                    <path stroke-linecap="round" stroke-linejoin="round" d="M15 11a3 3 0 11-6 0 3 3 0 016 0z" />
                                                                </svg>
                                                                <asp:TextBox runat="server" ID="txtCiudadBuscar" class="truncate" autocomplete="off"
                                                                    oninput="validatAndShowAutoComplete(event,showAutocompleteCitys)" placeholder="Ciudad" ValidationGroup="search">
                                                                </asp:TextBox>
                                                                <asp:TextBox ID="txtIdCiudadBuscar" Text="" runat="server" CssClass="hidden" />

                                                                <select size="4" id="selAutocompletado" runat="server" style="display: none" class="list-autofill"
                                                                    onchange="seleccionarAutocomplete(event)" onmouseleave="ocultarAutocomplete(event)">
  </select>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <asp:Label Text="Buscar" runat="server" ID="lblBuscarOferta" CssClass="button"
                                                        AssociatedControlID="btnBuscarOferta"
                                                        OnClientClick="showSearcher(event)" />

                                                    <asp:Button Text="Buscar" runat="server" ID="btnBuscarOferta" CssClass="hidden"
                                                        OnClick="btnBuscarOferta_Click" ValidationGroup="search" />
                                                </div>
                                                <asp:RequiredFieldValidator ErrorMessage="Agrega una Ciudad un cargo u ocupacion"
                                                    ControlToValidate="txtSearch" CssClass="required-field-validator" runat="server" ValidationGroup="search" />
                                            </div>

                                            <div runat="server" id="containerOfertas" class=" containerOfertas flex flex-center bg-gray-100 overflow-y-scroll rounded relative"
                                                style="height: 70vh;" visible="false">
                                                <div class="absolute" style="top: 0;">
                                                    <asp:GridView ID="grdOfertas" runat="server" AutoGenerateColumns="false" class="flex-col gap-4 " PageSize="9999">
                                                        <Columns>
                                                            <asp:TemplateField Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="idOferta" runat="server" Text='<%# Eval("idOferta") %>'></asp:Label>

                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" class="card_offer space-between pointer"
                                                                        AssociatedControlID="btnViewOffer" Style="border: none; margin-bottom: 8px;  width: 100%; ">
                                                                        <div class="flex-center-v gap-4">
                                                                            <div class="flex-col ">
                                                                                <div class="line">
                                                                                </div>
                                                                                <div class="avatar-rectangle">

                                                                                    <img src="<%# Eval("rutaAvatar") %>" alt="Alternate Text" />
                                                                                </div>
                                                                            </div>

                                                                            <div class="flex-col gap-8">
                                                                                <div class="flex-center-v gap-16 max-w-300">
                                                                                    <h4 runat="server" id="offerTitle" class="text-item color-gray-800 text-semibold truncate">
                                                                                        <%#  Eval("tituloVacante")%>
                                                                                    </h4>
                                                                                    <%-- <span class="flex-center-v gap-4">

                                                                                           <svg class="icon-16 color-gray-700" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                                                                               <pah stroke-linecap="round" stroke-linejoin="round" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
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
                                                                                CommandArgument="<%# Container.DataItemIndex %>" CommandName="GET" ToolTip="Ver" OnCommand="btnViewOffer_Command" />
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
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>



                                                </div>
                                                <div runat="server" id="noResultsShare" class="p-32" visible="false">
                                                    <h3 class="text-center text-item text-regular color-gray-500 p-32">*No se encontraron ofertas ralcionadas a la busqueda.
                                                    </h3>
                                                </div>
                                            </div>
                                        </div>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                        </div>
                        <img runat="server"  id="imgBanner" src ="./images/ImgInicio/mujer-entrevista 1.png" class="desktop" alt="" style="height:70dvh;"/>
                    </section>

                    <!-- Offers -->

                    <div class="wrapper offers">
                        <h2 class="text-subtitle"><span class="text-highlighted text-subtitle">Ofertas</span>  destacadas</h2>


                        <asp:GridView ID="grdOfertasDestacadas" runat="server" AutoGenerateColumns="false" PageSize="9999"
                            >
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="idOferta" runat="server" Text='<%# Eval("idOferta") %>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label runat="server" class="card_offer space-between pointer" AssociatedControlID="btnViewOfferFeatured"
                                            Style="margin-bottom: 8px;  width: 100%; "
                                            >
                                            <div class="flex-center-v gap-4">
                                                <div class="flex-col ">
                                                    <div class="line">
                                                    </div>
                                                    <div class="avatar-rectangle">
                                                        <img src="<%# Eval("rutaAvatar") %>" alt="Alternate Text" />

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
                                                <asp:Button Text="" runat="server" ID="btnViewOfferFeatured"
                                                    CommandArgument="<%# Container.DataItemIndex %>" CommandName="GET" ToolTip="Ver" OnCommand="btnViewOfferFeatured_Command" />
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
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
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
                        <article runat="server" id="detalleOferta" class="flex-col gap-8 hidden detalleOferta">


                            <div runat="server" class="flex flex-center-v gap-4 pointer">
                                <div class="flex-col ">
                                    <div class="line">
                                    </div>
                                    <div class="avatar-rectangle-80">
                                        <img runat="server" id="imgAvatarOffer" src="." alt="Alternate Text" />

                                    </div>
                                </div>

                                <div class="flex-col gap-8">
                                    <div class="flex-center-v gap-16 lblOfferTitle">
                                        <asp:Label runat="server" ID="lblOfferTitle" class="text-item color-gray-800 text-semibold">

                                        </asp:Label>
                                    </div>
                                    <div class="flex flex-center-v gap-16">
                                        <span class="flex-center-v gap-4">
                                            <svg xmlns="http://www.w3.org/2000/svg" class="icon-16 color-gray-700 icon-lblOfferUserWhoPublished" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                                <path stroke-linecap="round" stroke-linejoin="round" d="M19 21V5a2 2 0 00-2-2H7a2 2 0 00-2 2v16m14 0h2m-2 0h-5m-9 0H3m2 0h5M9 7h1m-1 4h1m4-4h1m-1 4h1m-5 10v-5a1 1 0 011-1h2a1 1 0 011 1v5m-4 0h4" />
                                            </svg>

                                            <asp:Label runat="server" ID="lblOfferUserWhoPublished" class="text-normal text-regular color-gray-700 lblOfferUserWhoPublished">
                                                    
                                            </asp:Label>
                                        </span>
                                    </div>
                                    <div class="flex flex-center-v gap-16 details">



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

                                <asp:Button Text="Postular a Oferta" ID="btnPostularOferta" CssClass="button" runat="server" OnClick="btnPostularOferta_Click" />

                            </div>
                            <div class="flex space-between">
                                <h4 class="color-gray-600 text-regular">Fecha de Creación:
                                    <asp:Label ID="lblDateCrateOffer" Text="" runat="server" />
                                </h4>
                                <h4 class="color-gray-600 text-regular">Fecha de Vencimiento:
                                    <asp:Label ID="lblDateRemoveOffer" Text="" runat="server" />
                                </h4>
                            </div>
                            <div>
                                <h1>Descripión</h1>
                                <asp:Label Text="" runat="server" ID="lblDescriptioOffer" style="white-space:break-spaces;"/>
                            </div>
                        </article>

                    </div>
                    <asp:UpdatePanel ID="openModal" class="modalDialog overflow-y-scroll" runat="server" MaintainScrollPositionOnPostback="true" UpdateMode="Conditional">
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
        <script type="text/javascript">



            PageMethods.GetCiudades(onCity, onError);
            PageMethods.GetOcupaciones(onOcupation, onError);

            const beforeTextOcupations = "OCUPACIÓN"

            function writerBeforeOption(beforeText) {
                if (beforeText !== null) {
                    // Crear una nueva hoja de estilo
                    var styleSheet = document.createElement('style');
                    document.body.appendChild(styleSheet);

                    // Definir el nuevo contenido del pseudo-elemento :before
                    var newContent = `${beforeText}`;

                    // Agregar una regla CSS para el pseudo-elemento :before
                    styleSheet.innerHTML = `.option-label.${beforeText}:before { content:'${newContent}'}`
                }
            }


            let listCityes;
            function onCity(result) { listCityes = result }

            let listOcupations;
            function onOcupation(result) {
                listOcupations = result
                writerBeforeOption(beforeTextOcupations)
            }


            function showAutocompleteOcupations(event) {
                const listAutocompleteOcupations = listOcupations


                showAutocomplete(event, listAutocompleteOcupations, beforeTextOcupations)

            }

            function showAutocompleteCitys(event) {

                const listAutocompleteCity = listCityes



                showAutocomplete(event, listAutocompleteCity, null)
            }

            function showAutocomplete(event, listAutocomplete, beforeText) {
                const parent = event.target.parentNode
                const select = parent.querySelector("select")

                let resultFiltered = listAutocomplete.filter(e => e.Nombre.toLowerCase().includes(event.target.value.toLowerCase()))

                let resultSorted = resultFiltered.sort((a, b) => {
                    const charPositionA = a.Nombre.indexOf(event.target.value.toUpperCase());
                    const charPositionB = b.Nombre.indexOf(event.target.value.toUpperCase());

                    if (charPositionB === -1) {
                        return -1;
                    }

                    if (charPositionA === -1) {
                        return 1;
                    }

                    return charPositionA < charPositionB ? -1 : (charPositionA > charPositionB ? 1 : 0);
                });

                resultSorted.length > 0
                    ? onSuccess(resultSorted, event, beforeText) : select.style.display = 'none';
            }



            function onSuccess(result, event, beforeText) {
                const parent = event.target.parentNode
                const select = parent.querySelector("select")

                select.innerHTML = '';


                // Crear la clase para el Option
                const cssClass = beforeText = null ? "truncate" : `option-label ${beforeText} truncate`

                // Iterar sobre la lista filtrada y mostrar los resultados

                for (let i = 0; i < result.length; i++) {
                    let option = document.createElement('option');

                    option.setAttribute("class", cssClass);
                    option.text = result[i].Nombre;
                    option.value = result[i].Id;
                    select.add(option);
                }

                // Mostrar la lista de autocompletado
                select.style.display = 'block';
            }

            function onError(result) {
                console.log(result);
            }


            function seleccionarAutocomplete(event) {
                const parent = event.target.parentNode
                const select = parent.querySelector("select")
                const inputSearch = (Array.from(parent.children).filter(e => e.localName === "input")[0]);
                const txtIdSearch = (Array.from(parent.children).filter(e => e.localName === "input")[1]);
                let selectedText = select.options[select.selectedIndex].text;
                let selectedValue = select.options[select.selectedIndex].value;
                inputSearch.value = selectedText;
                txtIdSearch.value = selectedValue;
                validateShare(event)
                // Ocultar la lista de autocompletado después de seleccionar un elemento

                select.style.display = 'none';
            }
            function ocultarAutocomplete(event) {
                const parent = event.target.parentNode
                const select = parent.querySelector("select")
                select.style.display = 'none';
            }
            function validatAndShowAutoComplete(event, showAutocomplete) {
                validateShare(event)
                clearAfterQuery(event)
                showAutocomplete(event)

            }
            function clearAfterQuery(event) {
                const parent = event.target.parentNode
                const select = parent.querySelector("select")
                const txtIdSearch = (Array.from(parent.children).filter(e => e.localName === "input")[1]);
                txtIdSearch.value = null;
            }
            function validateShare(event) {
                const txtValidate = document.getElementById('<%= txtSearch.ClientID %>')
                const txtCargo = document.getElementById('<%= txtBuscarCargo.ClientID %>')
                const txtCiudad = document.getElementById('<%= txtCiudadBuscar.ClientID %>')

                txtValidate.value = txtCargo.value + txtCiudad.value
            }
            function showSearcher(event) {
                const title = document.getElementById('titleDisplay')
                title.remove()
                const wrapper = document.getElementById('Main_wraShare')
                const share = document.getElementById('buscador')

                wrapper.style.width = "100%"
                share.classList.remove("max-w-860px")
                share.classList.add("w-100-per")

            }

            


        </script>
    </form>
</body>
</html>
