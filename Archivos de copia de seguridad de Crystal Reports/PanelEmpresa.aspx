<%@ Page Title="Panel/Perfil Empresa" Language="C#" MasterPageFile="~/ITMasters.Master" AutoEventWireup="true" CodeBehind="PanelEmpresa.aspx.cs" Inherits="co.itmasters.solucion.web.Empresa.PanelEmpresa" %>

<%@ MasterType VirtualPath="../ITMasters.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">
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
               <a href="" class="card-col2 bg-white"  >
                   <asp:Label ID="Label1" CssClass="text-item text-semibold color-orange-500" runat="server" Text="Hojas de vida recibidas" AssociatedControlID="btnHvRecibidas">
                   </asp:Label>
                   <asp:Label ID="lblPorcentajeHv" CssClass="text-item text-semibold " runat="server" Text="" AssociatedControlID="btnHvRecibidas">
                   </asp:Label>
                   <asp:Button CssClass="rectangle2 bg-white text-item text-semibold color-gray-900" ID="btnHvRecibidas" runat="server" Text="" />
               </a>

           </div>
                 
             <div class="flex gap-16 flex-center m-auto">
                <asp:Label ID="lbldetalleOferta" CssClass="text-item text-semibold color-gray-900" runat="server" Text="Detalle Ofertas">
                   </asp:Label>
                 </div>
           <div class="flex-center">
             
               <asp:GridView ID="GrdOfertas" runat="server" CssClass="grid-view" AutoGenerateColumns="false" OnRowCommand="GrdOfertas_RowCommand">
                   <Columns>
                       <asp:TemplateField Visible="false">
                           <ItemTemplate>
                               <asp:Label ID="lblidOferta"  runat="server" Text='<%# Eval("idOferta") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField Visible="true" >
                           <ItemTemplate>
                               <asp:Label ID="lblnomOferta" ToolTip="nombre de la oferta" CssClass="text-item text-semibold color-gray-900" runat="server" Text='<%# Eval("tituloVacante") %>'></asp:Label>
                               <br/>
                               <asp:Label ID="lblEstadoOferta" runat="server" Text='<%# Eval("estado") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                        <asp:TemplateField Visible="true">
                           <ItemTemplate>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField Visible="true" FooterStyle-HorizontalAlign="Center">
                           <ItemTemplate>
                               <asp:Label ID="lbltotalhv"  CssClass="text-item text-semibold color-gray-900" runat="server" Text='<%# Eval("totHv") %>'></asp:Label>
                               <br/>
                               <asp:Label ID="lblHvVistas"  CssClass="text-item text-semibold color-orange-500" runat="server" Text='<%# Eval("hvVista") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField Visible="true">
                           <ItemTemplate>
                                <asp:ImageButton ID="imgDetalleAsg" runat="Server" Style="height: 25px; width: 25px;" CommandArgument="<% # Container.DataItemIndex %>" CommandName="VerDatos" ImageUrl="~/Images/ver.png" ToolTip="Detalles de la oferta." />
                           </ItemTemplate>
                       </asp:TemplateField>
                   </Columns>
               </asp:GridView>

           </div>
             <div id="openModal" class="modalDialog" runat="server" style="display: none">
                <div>
                    <a href="#close" title="Cerrar sin grabar" class="closed" onclick="javascript:CloseModal();">Cerrar</a>
                    <div class="flex-center">
                       
                    </div>
                </div>
            </div>
       </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
