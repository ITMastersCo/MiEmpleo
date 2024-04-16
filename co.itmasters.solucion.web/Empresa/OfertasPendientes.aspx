<%@ Page Title="Ofertas pendientes" Language="C#" MasterPageFile="~/ITMasters.Master" AutoEventWireup="true" CodeBehind="OfertasPendientes.aspx.cs" Inherits="co.itmasters.solucion.web.Empresa.OfertasPendientes" %>

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
            <div class="flex-center">
                <asp:Label ID="lblFilter" runat="server" ToolTip="Filtrar" class="flex-inline pointer" AssociatedControlID="btnFilter">
               <svg class="icon-24 color-gray-600 " xmlns="http://www.w3.org/2000/svg"fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                   <path stroke-linecap="round" stroke-linejoin="round" d="M3 4a1 1 0 011-1h16a1 1 0 011 1v2.586a1 1 0 01-.293.707l-6.414 6.414a1 1 0 00-.293.707V17l-4 4v-6.586a1 1 0 00-.293-.707L3.293 7.293A1 1 0 013 6.586V4z" />
               </svg>
                </asp:Label>
                <asp:Button ID="btnFilter" runat="server" Text="" OnClick="btnFilter_Click" />
                <asp:DropDownList ID="cmbFiltros" Width="200px" runat="server" CssClass="drop-down-list" OnSelectedIndexChanged="cmbFiltros_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <asp:DropDownList ID="cmbOcupacionOfertaEmpresa" Width="400px" CssClass="drop-down-list" OnSelectedIndexChanged="cmbOcupacionOfertaEmpresa_SelectedIndexChanged" runat="server" AutoPostBack="true" Visible="false"></asp:DropDownList>
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
                    <asp:GridView ID="GrdOfertas" runat="server" CssClass="grid-view" AutoGenerateColumns="false" OnRowCommand="GrdOfertas_RowCommand" PageSize="9999">
                        <Columns>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblidOferta" runat="server" Text='<%# Eval("idOferta") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblnomOferta" ToolTip="Hola" CssClass="text-item text-semibold color-gray-900" runat="server" Text='<%# Eval("tituloVacante") %>'></asp:Label>
                                    <asp:ImageButton ID="btnViewDetailOffer" runat="Server" Style="height: 25px; width: 25px;"
                                        CommandArgument="<% # Container.DataItemIndex %>"
                                        CommandName="VerDatos"
                                        OnCommand="btnViewDetailOffer_Command"
                                        ImageUrl="~/Images/ver.png"
                                        ToolTip="Ver oferta." />
                                    <br />
                                    <asp:Label ID="lblEstadoOferta" runat="server" Text='<%# Eval("estado") %>'></asp:Label>
                                    <br />
                                    <asp:Label ID="lblCiudad" runat="server" Text='<%# Eval("nomCiudad") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblFechaVacante" ToolTip="Hola" CssClass="text-item text-semibold color-gray-900" runat="server" Text='<%# Eval("fechaPublicacion","{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true" FooterStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lbltotalhv" CssClass="text-item text-semibold color-gray-900" runat="server" Text='<%# Eval("totHv") %>'></asp:Label>
                                    <br />
                                    <asp:Label ID="lblHvVistas" CssClass="text-item text-semibold color-orange-500" runat="server" Text='<%# Eval("hvVista") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEditar" runat="Server" Style="height: 25px; width: 25px;" CommandArgument="<% # Container.DataItemIndex %>" CommandName="Editar" ImageUrl="~/Images/Editar.svg    " ToolTip="No disponible." />
                                    <asp:ImageButton ID="ImgBorrar" runat="Server" Style="height: 25px; width: 25px;" CommandArgument="<% # Container.DataItemIndex %>" CommandName="Eliminar" ImageUrl="~/Images/Eliminar.svg" ToolTip="Eliminar oferta." />
                                    <br />
                                    <asp:ImageButton ID="ImgRenovar" runat="Server" Style="height: 25px; width: 25px;" CommandArgument="<% # Container.DataItemIndex %>" CommandName="Renovar" ImageUrl="~/Images/Actualizar.svg" ToolTip="No disponible." />
                                    <asp:ImageButton ID="ImgDuplicar" runat="Server" Style="height: 25px; width: 25px;" CommandArgument="<% # Container.DataItemIndex %>" CommandName="Duplicar" ImageUrl="~/Images/Duplicar.svg" ToolTip="No disponible." />

                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>
            </div>

            <%-- Modal de confirmacion borrar ofertas --%>
            <asp:UpdatePanel runat="server" ID="ModalBorrarOferta" class="hidden" UpdateMode="Conditional">
                <ContentTemplate>
                    <div>
                        <h3 class="text-subtitle">¡Estimado usuario! <span class="text-highlighted text-subtitle">una vez  elimine esta oferta perderá el cupo dentro de su paquete.</span> ¿Desea continuar?
                        </h3>

                        <div class="flex-center">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="Button1" Visible="true" runat="server" CssClass="button bg-red-400" Text="No estoy seguro" OnClick="Cancerlar_Click" />
                                    <asp:Button ID="Anular" Visible="true" runat="server" CssClass="button" Text="Continuar" OnClick="Anular_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>

                    </div>
                    <div id="variable" runat="server" class="hidden">
                        <asp:Label ID="lblIdOfertaDelete" runat="server" Text=""></asp:Label>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

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
                            <div class="flex flex-center-v gap-4">

                                <svg xmlns="http://www.w3.org/2000/svg" class="icon-24 color-400" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                    <path stroke-linecap="round" stroke-linejoin="round" d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z" />
                                </svg>
                                <h4 class="color-400 text-regular">Creación:
                         <asp:Label ID="lblDateCrateOffer" Text="" runat="server" />
                                </h4>
                            </div>
                            <div class="flex flex-center-v gap-">
                                <svg xmlns="http://www.w3.org/2000/svg" class="icon-24 color-red-500" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                    <path stroke-linecap="round" stroke-linejoin="round" d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z" />
                                </svg>
                                <h4 class="color-red-500 text-regular">Vence:
                            <asp:Label ID="lblDateRemoveOffer" Text="" runat="server" />
                                </h4>
                            </div>
                        </div>
                        <div class="bg-gray-100 rounded p-16">
                            <asp:Label Text="" runat="server" ID="lblDescriptioOffer" style="white-space:break-spaces;" />
                        </di>
                    </article>



                    <%-- Lista de candidatos postulados --%>
                    <h2 class="text-item color-gray-800 text-semibold" runat="server" id="titleGrdPostulados">Candidatos postulados</h2>
                    <div runat="server" id="containerCandidatos" class="flex flex-center bg-gray-100 overflow-y-scroll rounded relative"
                        style="height: 70vh;">
                        <div class="absolute" style="top: 0;">
                            <asp:GridView ID="grdCandidatos" runat="server" AutoGenerateColumns="false" class="flex-col gap-4 flex-center" PageSize="99999">
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdPersona" runat="server" Text='<%# Eval("idPersona") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label runat="server" class="card_offer space-between pointer"
                                                AssociatedControlID="btnViewCandidato" Style="border: none; margin-bottom: 8px;" ToolTip="Descargar hoja de vida">
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
                                                            <asp:Label runat="server" ID="offerTitle" class="text-item color-gray-800 text-semibold truncate" ToolTip='<%# Eval("nomPersona") %>'>
                                        <%#  Eval("nomPersona")%>
                                                            </asp:Label>
                                                            <%-- Iconos auxicliares ej: favoritos o marcadores
                                            
                                              <span class="flex-center-v gap-4">
                                      
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
                                                                <svg xmlns="http://www.w3.org/2000/svg" class="icon-16 color-green-500" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
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

                                                        <svg xmlns="http://www.w3.org/2000/svg" class="icon-16 color-gray-700" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                                            <path stroke-linecap="round" stroke-linejoin="round" d="M21 15.546c-.523 0-1.046.151-1.5.454a2.704 2.704 0 01-3 0 2.704 2.704 0 00-3 0 2.704 2.704 0 01-3 0 2.704 2.704 0 00-3 0 2.704 2.704 0 01-3 0 2.701 2.701 0 00-1.5-.454M9 6v2m3-2v2m3-2v2M9 3h.01M12 3h.01M15 3h.01M21 21v-7a2 2 0 00-2-2H5a2 2 0 00-2 2v7h18zm-3-9v-2a2 2 0 00-2-2H8a2 2 0 00-2 2v2h12z" />
                                                        </svg>

                                                        <asp:Label runat="server" ID="offerAppications" class="text-normal text-medium color-gray-700"
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
                                    id="msgNoResults">*No se encontraron candidatos relacionados a la ofeta.
                                </h3>
                                <p runat="server" id="msgObservacion" class="text-center text-normal text-gray-600" visible="false">
                                </p>
                                </h3>
                            </div>
                        </div>
                    </div>
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
