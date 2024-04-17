<%@ Page Title="Panel/Perfil Empresa" Language="C#" MasterPageFile="~/ITMasters.Master" AutoEventWireup="true" CodeBehind="PanelEmpresa.aspx.cs" Inherits="co.itmasters.solucion.web.Empresa.PanelEmpresa" %>

<%@ MasterType VirtualPath="../ITMasters.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">
    <script src="https://sdk.mercadopago.com/js/v2"></script>
    <script type="module" src="../Scripts/MercadoPago.js"></script>
    <asp:UpdatePanel ID="UpdatePanelform" runat="server" class="flex-col gap-16 flex-center">
        <ContentTemplate>
            <div class="flex gap-16 flex-center m-auto">
                <asp:Label ID="Label3" CssClass="text-item text-semibold color-orange-500" runat="server" Text="Ofertas">
                </asp:Label>

            </div>
            <div class="flex gap-16 flex-wrap flex-center m-auto ">

                <a href="../Empresa/OfertasPendientes.aspx" class="card-col bg-white after-2/4">
                    <asp:Label ID="lblOfertasPendientes" CssClass="text-item text-semibold color-gray-800" runat="server" Text="Pendientes" AssociatedControlID="btnOfertasPendientes">
                    </asp:Label>
                    <asp:Button CssClass="rectangle bg-orange-400 text-item text-semibold color-gray-800" ID="btnOfertasPendientes" runat="server" Text="" />
                </a>
                <a href="../Empresa/OfertasActivas.aspx" class="card-col bg-white after-2/4">
                    <asp:Label ID="lblOfertasPublicadas" CssClass="text-item text-semibold color-gray-800" runat="server" Text="Publicadas" AssociatedControlID="btnOfertasPendientes">
                    </asp:Label>
                    <asp:Button CssClass="rectangle bg-green-400 text-item text-semibold color-gray-800" ID="btnOfertasPublicadas" runat="server" Text="" />
                </a>
                <a href="../Empresa/OfertasVencidas.aspx" class="card-col bg-white after-2/4">
                    <asp:Label ID="lblOfertasVencidas" CssClass="text-item text-semibold color-gray-800" runat="server" Text="Vencidas" AssociatedControlID="btnOfertasPendientes">
                    </asp:Label>
                    <asp:Button CssClass="rectangle bg-red-400 text-item text-semibold color-gray-800" ID="btnOfertasVencidas" runat="server" Text="" />
                </a>

            </div>
            <div class="flex gap-16 flex-wrap flex-center m-auto">
                <a href="" class="card-col2 bg-white">
                    <asp:Label ID="lblSeguidores" CssClass="text-item text-semibold color-orange-500" runat="server" Text="Seguidores" AssociatedControlID="btnSeguidores">
                    </asp:Label>
                    <asp:Label ID="lblPorcentajeSeg" CssClass="text-item text-semibold" runat="server" Text="" AssociatedControlID="btnHvRecibidas">
                    </asp:Label>
                    <asp:Button CssClass="rectangle2 bg-white text-item text-semibold color-gray-900" ID="btnSeguidores" runat="server" Text="" />
                </a>
                <a href="" class="card-col2 bg-white">
                    <asp:Label ID="Label1" CssClass="text-item text-semibold color-orange-500" runat="server" Text="Hojas de vida recibidas" AssociatedControlID="btnHvRecibidas">
                    </asp:Label>
                    <asp:Label ID="lblPorcentajeHv" CssClass="text-item text-semibold " runat="server" Text="" AssociatedControlID="btnHvRecibidas">
                    </asp:Label>
                    <asp:Button CssClass="rectangle2 bg-white text-item text-semibold color-gray-900" ID="btnHvRecibidas" runat="server" Text="" />
                </a>

            </div>

            <div class="flex gap-16 flex-center m-auto">
                <asp:Label ID="lbldetalleOferta" CssClass="text-item text-semibold color-gray-900 " runat="server" Text="Detalle Ofertas">
                </asp:Label>
            </div>

            <asp:GridView ID="GrdOfertas1" runat="server" CssClass="" AutoGenerateColumns="false" OnRowCommand="GrdOfertas_RowCommand">
                <Columns>
                    <asp:TemplateField Visible="true">
                        <ItemTemplate>
                            <div class="hidden">
                                <asp:Label ID="lblidOferta" runat="server" Text='<%# Eval("idOferta") %>'></asp:Label>
                            </div>
                            <asp:Label Text="" runat="server" ID="lblViewDetailOffer" CssClass="card_offer space-between pointer"
                                AssociatedControlID="btnViewDetailOffer">

                                <div>
                                    <asp:Label ID="lblnomOferta" ToolTip="nombre de la oferta" CssClass="text-item text-semibold color-gray-900" runat="server" Text='<%# Eval("tituloVacante") %>'></asp:Label>
                                    <br />
                                    <asp:Label ID="lblEstadoOferta" runat="server" Text='<%# Eval("estado") %>'></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="lbltotalhv" CssClass="text-item text-semibold color-gray-900" runat="server" Text='<%# Eval("totHv") %>'></asp:Label>
                                    <br />
                                    <asp:Label ID="lblHvVistas" CssClass="text-item text-semibold color-orange-500" runat="server" Text='<%# Eval("hvVista") %>'></asp:Label>
                                </div>
                            </asp:Label>
                            <asp:Button ID="btnViewDetailOffer" Text="" CssClass="hidden" runat="server" 
                                CommandArgument="<%# Container.DataItemIndex %>"
                                OnCommand="btnViewDetailOffer_Command" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                   <asp:GridView ID="GrdOfertas" runat="server" AutoGenerateColumns="false" PageSize="9999"
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
                               <div class="flex-col hidden" >
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

                           <svg class="icon-16 color-gray-700" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                               <path stroke-linecap="round" stroke-linejoin="round" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
                               <path stroke-linecap="round" stroke-linejoin="round" d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z" />
                           </svg>


                           <asp:Label runat="server" id="offerViews" class="text-small text-medium color-gray-700">
                               <%#  Eval("HvVista")%>
                           </asp:Label>
                       </span>
                                   </div>
                                   <div class="flex-center-v gap-16">
                                       <span class="flex-center-v gap-4">
                                           <svg xmlns="http://www.w3.org/2000/svg" class="icon-16 color-gray-700" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                              <path stroke-linecap="round" stroke-linejoin="round" d="M6 5c7.18 0 13 5.82 13 13M6 11a7 7 0 017 7m-6 0a1 1 0 11-2 0 1 1 0 012 0z" />
                                            </svg>

                                           <asp:Label ToolTip='<%# Eval("estado") %>' Text='<%# Eval("estado") %>' runat="server" ID="state"
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
                               <asp:Button Text="" runat="server" ID="btnViewOfferFeatured"
                                   CommandArgument="<%# Container.DataItemIndex %>" CommandName="GET" ToolTip="Ver" OnCommand="btnViewOfferFeatured_Command" />
                           </div>



                           <div class=" flex-col gap-32">

                               <div class="flex-center-v gap-4">

                                   <asp:Label ID="lblOfferEdit" runat="server" Text="" AssociatedControlID="btnOfferEdit">
                                       <asp:Button ID="btnOfferEdit" runat="server" Text="Button" Visible="false" />
                                       <svg class="icon-24 pointer color-gray-700" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                           <path stroke-linecap="round" stroke-linejoin="round" d="M15.232 5.232l3.536 3.536m-2.036-5.036a2.5 2.5 0 113.536 3.536L6.5 21.036H3v-3.572L16.732 3.732z" />
                                       </svg>
                                   </asp:Label>

                               </div>

                               <div class="flex-center-v gap-4 justify-end">

                                   <svg class="icon-16 color-gray-700" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                       <path stroke-linecap="round" stroke-linejoin="round" d="M12 4.354a4 4 0 110 5.292M15 21H3v-1a6 6 0 0112 0v1zm0 0h6v-1a6 6 0 00-9-5.197M13 7a4 4 0 11-8 0 4 4 0 018 0z" />
                                   </svg>

                                   <span runat="server" id="offerAppications" class="text-normal text-medium color-gray-700">
                                       <%# Eval("totHv") %>
                                   </span>

                               </div>

                           </div>

                       </asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
           </Columns>
       </asp:GridView>

            <div id="wrapperHidden" class="hidden">
                <div runat="server" id="detalleOferta" class="flex-col gap-32 w-100per detalleOferta">

                    <article class="flex flex-col gap-32">
                        <div class="hidden">
                            <asp:Label Text="" ID="lblIdOferta" runat="server" />
                            <asp:Label Text="" ID="lblIdPersona" runat="server" />
                        </div>

                        <div runat="server" class=" flex flex-center-v gap-4 pointer">
                            <div class="flex-col ">
                                <div class="line">
                                </div>
                                <div class="avatar-rectangle-80">

                                    <img runat="server" id="imgAvatarEmpresa" src="." alt="Avatar Empresa" />

                                </div>
                            </div>

                            <div class="flex-col gap-8">
                                <div class="flex-center-v gap-16 ">
                                    <asp:Label runat="server" ID="lblOfferTitle" class="text-item color-gray-800 text-semibold lblOfferTitle">

                                    </asp:Label>
                                </div>
                                <div class="flex flex-center-v gap-16">
                                    <span class="flex-center-v gap-4">
                                        <svg xmlns="http://www.w3.org/2000/svg" class="icon-16 color-gray-700" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
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



                        </div>
                        <div class="flex space-between w-100per flex-center-v details">
                            <div class=" flex-center-v gap-4">

                                <svg xmlns="http://www.w3.org/2000/svg" class="icon-24 color-400" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                    <path stroke-linecap="round" stroke-linejoin="round" d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z" />
                                </svg>
                            <h4 class="color-400 text-regular">Creación:
                         <asp:Label ID="lblDateCrateOffer" Text="" runat="server" />
                            </h4>
                            </div>
                            <div class=" flex-center-v gap-4">
                                <svg xmlns="http://www.w3.org/2000/svg" class="icon-24 color-red-500" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                    <path stroke-linecap="round" stroke-linejoin="round" d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z" />
                                </svg>
                            <h4 class="color-red-500 text-regular"> 
                                Vence:
                          <asp:Label ID="lblDateRemoveOffer" Text="" runat="server" />
                            </h4>
                            </div>
                        </div>
                        <div class="bg-gray-100 rounded p-16 lblDescriptioOffer" >
                            <asp:Label Text="" runat="server" ID="lblDescriptioOffer" style="white-space:break-spaces;" />
                        </di>
                    </article>


                    <h2 class="text-item color-gray-800 text-semibold" runat="server" id="titleGrdPostulados" >Candidatos postulados</h2>
                    <div runat="server" id="containerCandidatos" class="flex flex-center bg-gray-100 overflow-y-scroll rounded relative"
                        style="height: 70vh;">
                        <div class="absolute ansolute-cente-x"  style="top: 0;">
                          <asp:GridView ID="grdCandidatos" runat="server" AutoGenerateColumns="false" class="flex-col flex-center gap-4 ">
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdPersona" runat="server" Text='<%# Eval("idPersona") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label runat="server" class="card_offer space-between pointer"
                                                AssociatedControlID="btnViewCandidato" Style="border: none; margin-bottom: 8px;">
                                                <div class="flex-center-v gap-4">
                                                    <div class="flex-col ">
                                                        <div class="line">
                                                        </div>
                                                        <div class="avatar-rectangle border border-solid border-color-500">
                                                            <img src=".<%# Eval("rutaAvatar") %>" alt="Avatar" />
                                                        </div>
                                                    </div>

                                                    <div class="flex-col gap-8">
                                                        <div class="flex-center-v gap-16 max-w-300">
                                                            <asp:Label runat="server" id="offerTitle" class="text-item color-gray-800 text-semibold truncate" ToolTip='<%# Eval("nomPersona") %>'>
                                                                <%#  Eval("nomPersona")%>
                                                            </asp:Label>
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

                                                                <svg xmlns="http://www.w3.org/2000/svg"class="icon-16 color-gray-700" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                                                    <path stroke-linecap="round" stroke-linejoin="round" d="M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
                                                                </svg>

                                                                <asp:Label ToolTip='<%# Eval("Perfil") %>' runat="server" ID="offerUserWhoPublished"
                                                                    class="text-small text-regular color-gray-700 truncate max-w-148px">
                                                                   <%# Eval("perfil") %>
                                                                </asp:Label>
                                                            </span>
                                                            <p runat="server" id="offerDate" class="text-small  text-regular color-gray-500">
                                                                <%# String.Format("{0:yyyy-MM-dd}", Eval("fechaCrea")) %>
                                                            </p>
                                                        </div>
                                                        <div class=" flex-center-v gap-16">

                                                            <span class="flex-center-v gap-4">
                  <%--                                              <svg class="icon-16 color-green-500" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor">
                                                                    <path stroke-linecap="round" stroke-linejoin="round" d="M2.25 18.75a60.07 60.07 0 0115.797 2.101c.727.198 1.453-.342 1.453-1.096V18.75M3.75 4.5v.75A.75.75 0 013 6h-.75m0 0v-.375c0-.621.504-1.125 1.125-1.125H20.25M2.25 6v9m18-10.5v.75c0 .414.336.75.75.75h.75m-1.5-1.5h.375c.621 0 1.125.504 1.125 1.125v9.75c0 .621-.504 1.125-1.125 1.125h-.375m1.5-1.5H21a.75.75 0 00-.75.75v.75m0 0H3.75m0 0h-.375a1.125 1.125 0 01-1.125-1.125V15m1.5 1.5v-.75A.75.75 0 003 15h-.75M15 10.5a3 3 0 11-6 0 3 3 0 016 0zm3 0h.008v.008H18V10.5zm-12 0h.008v.008H6V10.5z" />
                                                                </svg>--%>
                                                                <svg xmlns="http://www.w3.org/2000/svg"  class="icon-16 color-green-500" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                                                    <path d="M12 14l9-5-9-5-9 5 9 5z" />
                                                                    <path d="M12 14l6.16-3.422a12.083 12.083 0 01.665 6.479A11.952 11.952 0 0012 20.055a11.952 11.952 0 00-6.824-2.998 12.078 12.078 0 01.665-6.479L12 14z" />
                                                                    <path stroke-linecap="round" stroke-linejoin="round" d="M12 14l9-5-9-5-9 5 9 5zm0 0l6.16-3.422a12.083 12.083 0 01.665 6.479A11.952 11.952 0 0012 20.055a11.952 11.952 0 00-6.824-2.998 12.078 12.078 0 01.665-6.479L12 14zm-4 6v-7.5l4-2.222" />
                                                                </svg>

                                                                <span runat="server" id="offerSalaryRange" class="text-small text-medium color-green-500">
                                                                    <%# Eval("nomMaxNivelEducativo")%>
                                                                </span>
                                                            </span>
                                                            <span class="flex-center-v gap-4">
                                                                <svg class="icon-16 color-gray-500" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor">
                                                                    <path stroke-linecap="round" stroke-linejoin="round" d="M15 10.5a3 3 0 11-6 0 3 3 0 016 0z" />
                                                                    <path stroke-linecap="round" stroke-linejoin="round" d="M19.5 10.5c0 7.142-7.5 11.25-7.5 11.25S4.5 17.642 4.5 10.5a7.5 7.5 0 1115 0z" />
                                                                </svg>

                                                                <span runat="server" id="offerLocation" class="text-small text-regular color-gray-500">
                                                                    <%# Eval("ciudadResidencia")%>
                                                                </span>
                                                            </span>

                                                        </div>
                                                    </div>

                                                    <asp:Button Text="" runat="server" ID="btnViewCandidato"
                                                        CommandArgument="<%# Container.DataItemIndex %>" CommandName="GET" ToolTip="Ver" OnCommand="btnViewCandidato_Command" />
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

                                                        <svg xmlns="http://www.w3.org/2000/svg" class="icon-16 color-gray-700"  fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                                            <path stroke-linecap="round" stroke-linejoin="round" d="M21 15.546c-.523 0-1.046.151-1.5.454a2.704 2.704 0 01-3 0 2.704 2.704 0 00-3 0 2.704 2.704 0 01-3 0 2.704 2.704 0 00-3 0 2.704 2.704 0 01-3 0 2.701 2.701 0 00-1.5-.454M9 6v2m3-2v2m3-2v2M9 3h.01M12 3h.01M15 3h.01M21 21v-7a2 2 0 00-2-2H5a2 2 0 00-2 2v7h18zm-3-9v-2a2 2 0 00-2-2H8a2 2 0 00-2 2v2h12z" />
                                                        </svg>

                                                        <asp:Label runat="server" id="offerAppications" class="text-normal text-medium color-gray-700" 
                                                            ToolTip='<%#  "Edad: " + Eval("edad") %>'>
                                                            <%# Eval("edad") %>
                                                        </asp:Label>

                                                    </div>

                                                </div>

                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <div runat="server" id="noResultsShare" class="p-32" visible="false">
                                <h3 class="text-center text-item text-regular color-gray-500 p-32" 
                                    runat="server"
                                    id="msgNoResults"
                                    >*No se encontraron candidatos relacionados a la ofeta.
                                </h3>
                                <p runat="server" ID="msgObservacion" class="text-center text-normal text-gray-600" visible="false">

                                </p>
                            </div>
                        </div>
                    </div>
                </div>


            </div>

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
            <Triggers>
        <asp:PostBackTrigger ControlID="grdCandidatos" />
    </Triggers>

    </asp:UpdatePanel>
</asp:Content>
