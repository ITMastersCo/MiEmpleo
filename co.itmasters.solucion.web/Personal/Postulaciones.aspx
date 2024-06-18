<%@ Page Title="" Language="C#" MasterPageFile="~/ITMasters.Master" AutoEventWireup="true" CodeBehind="Postulaciones.aspx.cs" Inherits="co.itmasters.solucion.web.Personal.Postulaciones" %>
<%@ MasterType VirtualPath="../ITMasters.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="flex-end">
                <a href="../Empresa/PanelEmpresa.aspx" class="text-lg-end text-600 text-highlighted text-underline
                   pointer">Volver
                </a>
            </div>

            <%-- Filtros ofertas --%>
            <div class="flex-center filters gap-4">
                <asp:Label ID="lblFilter" runat="server" ToolTip="Filtrar" class="flex-inline pointer" AssociatedControlID="btnFilter">
               <svg class="icon-24 color-gray-600 " xmlns="http://www.w3.org/2000/svg"fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                   <path stroke-linecap="round" stroke-linejoin="round" d="M3 4a1 1 0 011-1h16a1 1 0 011 1v2.586a1 1 0 01-.293.707l-6.414 6.414a1 1 0 00-.293.707V17l-4 4v-6.586a1 1 0 00-.293-.707L3.293 7.293A1 1 0 013 6.586V4z" />
               </svg>
                </asp:Label>
                <asp:Button ID="btnFilter" runat="server" Text="" OnClick="btnFilter_Click" />
                <asp:DropDownList ID="cmbFiltros" Width="360px" runat="server" CssClass="drop-down-list" OnSelectedIndexChanged="cmbFiltros_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <asp:DropDownList ID="cmbOcupacionOfertaEmpresa" Width="360px" CssClass="drop-down-list" OnSelectedIndexChanged="cmbOcupacionOfertaEmpresa_SelectedIndexChanged" runat="server" AutoPostBack="true" Visible="false"></asp:DropDownList>
                <br />
                <asp:TextBox ID="txtFecha1" Visible="false" Width="200px" TextMode="Date" CssClass="text-box" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtFecha2" Visible="false" Width="200px" TextMode="Date" CssClass="text-box" runat="server"></asp:TextBox>
                <asp:Button ID="btnBuscar" Visible="false" runat="server" CssClass="button" Text="Buscar" OnClick="btnBuscar_Click" />
                <%--<div runat="server" id="containerOffers" class="m-auto">
                </div>--%>
            </div>

            <%-- Lista de Ofertas --%>
            <div class="flex gap-16 flex-center m-auto">
                <div class="flex-center">
               


       <asp:GridView ID="GrdOfertas" runat="server" AutoGenerateColumns="false" PageSize="9999" >
    <Columns>
        <asp:TemplateField Visible="false">
            <ItemTemplate>
                <asp:Label ID="idOferta" runat="server" Text='<%# Eval("idOferta") %>'></asp:Label>

            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField>
            <ItemTemplate>
                <asp:Label runat="server" class="card_offer space-between pointer" AssociatedControlID="btnViewDetailOffer"
                    Style="margin-bottom: 8px; "
                    >
                    

                    <div class="flex-center-v gap-4">
                        <div class="flex-col hidden" >
                            <asp:Label id="isFeatured" Text='<%# Eval("esDestacada") %>' runat="server"  />
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
                                <span class="flex-center-v gap-4">

                                    <%-- informacion al lado del titulo
    <
    svg class="icon-16 color-gray-700" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                        <path stroke-linecap="round" stroke-linejoin="round" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
                                        <path stroke-linecap="round" stroke-linejoin="round" d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z" />
                                    </svg>


                                    <asp:Label runat="server" ID="offerViews" class="text-small text-medium color-gray-700">
                        <%#  Eval("HvVista")%>
                                    </asp:Label>--%>
                                </span>
                            </div>
                            <div class="flex-center-v gap-16">
                                <span class="flex-center-v gap-4">
                                    <svg xmlns="http://www.w3.org/2000/svg" class="icon-16 color-gray-700" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                        <path stroke-linecap="round" stroke-linejoin="round" d="M6 5c7.18 0 13 5.82 13 13M6 11a7 7 0 017 7m-6 0a1 1 0 11-2 0 1 1 0 012 0z" />
                                    </svg>

                                    <asp:Label ToolTip='<%# Eval("nomEmpresa") %>' Text='<%# Eval("nomEmpresa") %>' runat="server" ID="state"
                                        class="text-small text-regular color-gray-700 truncate max-w-148px">
                          
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
                        <asp:Button Text="" runat="server" ID="btnViewDetailOffer"
                            CommandArgument="<%# Container.DataItemIndex %>" CommandName="GET" ToolTip="Ver" OnCommand="btnViewDetailOffer_Command" />
                    </div>



                    <div class=" flex-col gap-32">

                        <div class="flex-center-v gap-4">

                            <%-- Botonnes o controles de mas --%>
                            <asp:Label ID="lblOfferDelete" runat="server" Text="" AssociatedControlID="btnOfferDelete" ToolTip="Renovar" Visible="false">
                                <asp:Button ID="btnOfferDelete" runat="server" Text="Button"  CssClass="hidden"  CommandArgument="<% # Container.DataItemIndex %>" CommandName="Eliminar"  />
                               <svg xmlns="http://www.w3.org/2000/svg" class="icon-24 pointer color-gray-500" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                  <path stroke-linecap="round" stroke-linejoin="round" d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16" />
                                </svg>
                            </asp:Label>

                        </div>
                        
                        <div class="flex-center-v gap-4 justify-end">

                            <svg class="icon-24 pointer color-gray-500" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                <path stroke-linecap="round" stroke-linejoin="round" d="M12 4.354a4 4 0 110 5.292M15 21H3v-1a6 6 0 0112 0v1zm0 0h6v-1a6 6 0 00-9-5.197M13 7a4 4 0 11-8 0 4 4 0 018 0z" />
                            </svg>

                            <asp:Label runat="server" id="offerAppications" class="text-normal text-medium color-gray-700">
                                <%# Eval("totHv") %>
                            </asp:Label>

                        </div>

                    </div>
                        
                </asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

                </div>
            </div>

            
            

            <%-- Contenedor oculto para trabajar diferentes contenidos en la modal --%>
            <div id="wrapperHidden" class="hidden">


                <%-- Contenido de Modal para ver el detalle de las ofertas --%>
                <div runat="server" id="detalleOferta" class="flex-col gap-32 w-100per">

                    <article class="flex-col gap-32">
                        <div class="hidden">
                            <asp:Label Text="" ID="lblIdOferta" runat="server" />
                            <asp:Label Text="" ID="lblIdPersona" runat="server" />
                        </div>

                        <div runat="server" class="flex-center-v gap-4 pointer">
                            <div class="flex-col ">
                                <div class="line">
                                </div>
                                <div class="avatar-rectangle-80">

                                    <img runat="server" id="imgAvatarEmpresa" src="." alt="Avatar Empresa" />

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



                        </div>
                        <div class="flex space-between w-100per flex-center-v">
                                <%-- Oculto disponible para dos datos infromativso como fechas u otros --%>
                            <div class="flex flex-center-v gap-4 hidden">

                                <svg xmlns="http://www.w3.org/2000/svg" class="icon-24 color-400" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                    <path stroke-linecap="round" stroke-linejoin="round" d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z" />
                                </svg>
                                <h4 class="color-400 text-regular">Creación:
                         <asp:Label ID="lblDateCrateOffer" Text="" runat="server" />
                                </h4>
                            </div>

                            <div class="flex flex-center-v gap-4 hidden">
                                <svg xmlns="http://www.w3.org/2000/svg" class="icon-24 color-red-500" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                    <path stroke-linecap="round" stroke-linejoin="round" d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z" />
                                </svg>
                                <h4 class="color-red-500 text-regular">Vence:
                            <asp:Label ID="lblDateRemoveOffer" Text="" runat="server" />
                                </h4>
                            </div>


                        </div>
                        <div class="bg-gray-100 rounded p-16">
                            <asp:Label Text="" runat="server" ID="lblDescriptioOffer" Style="white-space: break-spaces;" />
                        </di>
                    </article>


                </div>


            </div>

            <%-- Contenedor de la modal --%>
            <asp:UpdatePanel ID="openModal" class="modal-dialog overflow-y-scroll" runat="server" MaintainScrollPositionOnPostback="true" UpdateMode="Conditional">
                <ContentTemplate>

                    <div class="flex-col flex-center">
                        <asp:Label ID="lblCloseModal" Text="" runat="server" AssociatedControlID="btnCloseModal">
                            <svg xmlns="http://www.w3.org/2000/svg" class="icon-24 pointer color-gray-700 closed" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                <path stroke-linecap="round" stroke-linejoin="round" d="M6 18L18 6M6 6l12 12" />
                            </svg>
                            <asp:Button ID="btnCloseModal" Text="" runat="server" CssClass="hidden" OnClick="btnCloseModal_Click" />
                        </asp:Label>
                        <asp:Panel runat="server" ID="modalCV" CssClass="modal-body flex flex-center w-100per max-w-850px">
                        </asp:Panel>

          </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </ContentTemplate>

    </asp:UpdatePanel>




    <style>
        .card_offer {
            max-width: 600px;
            width: 600px;
        }

        @media screen and (max-width: 600px) {
            .card_offer {
                width: 100%;
            }

            .max-w-300 {
                max-width: 280px;
            }
        }

        .filters {
            flex-direction: column;
            align-items: center;
        }
    </style>


</asp:Content>
