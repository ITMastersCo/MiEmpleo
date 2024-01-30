<%@ Page Title="Ofertas pendientes" Language="C#" MasterPageFile="~/ITMasters.Master" AutoEventWireup="true" CodeBehind="OfertasPendientes.aspx.cs" Inherits="co.itmasters.solucion.web.Empresa.OfertasPendientes" %>

<%@ MasterType VirtualPath="../ITMasters.Master" %>
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
                width: 750px;
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
            color: red;
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
    <script type="text/javascript">
        function showModal() {
            document.getElementById('Main_openModal').style.display = 'block';
        }
        function CloseModal() {
            document.getElementById('Main_openModal').style.display = 'none';
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="flex-end">
                <a href="../Empresa/PanelEmpresa.aspx" class="text-lg-end text-600 text-highlighted text-underline
                   pointer">Volver
                </a>
            </div>
            <div class="flex-center">
                <asp:Label ID="lblFilter" runat="server" ToolTip="Filtrar" class="flex-inline pointer" AssociatedControlID="btnFilter">
               <svg class="icon-24 color-gray-600 " xmlns="http://www.w3.org/2000/svg"fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                   <path stroke-linecap="round" stroke-linejoin="round" d="M3 4a1 1 0 011-1h16a1 1 0 011 1v2.586a1 1 0 01-.293.707l-6.414 6.414a1 1 0 00-.293.707V17l-4 4v-6.586a1 1 0 00-.293-.707L3.293 7.293A1 1 0 013 6.586V4z" />
               </svg>
                </asp:Label>
                <asp:Button ID="btnFilter" runat="server" Text="" OnClick="btnFilter_Click" />
                <asp:DropDownList ID="cmbFiltros" Width="200px" runat="server" CssClass="drop-down-list" OnSelectedIndexChanged="cmbFiltros_SelectedIndexChanged" AutoPostBack="true" Visible="false"></asp:DropDownList>
                <asp:DropDownList ID="cmbOcupacionOfertaEmpresa" Width="400px" CssClass="drop-down-list" OnSelectedIndexChanged="cmbOcupacionOfertaEmpresa_SelectedIndexChanged" runat="server" AutoPostBack="true" Visible="false"></asp:DropDownList>
                <br />
                <asp:TextBox ID="txtFecha1" Visible="false" Width="200px" TextMode="Date" CssClass="text-box" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtFecha2" Visible="false" Width="200px" TextMode="Date" CssClass="text-box" runat="server"></asp:TextBox>
                <asp:Button ID="btnBuscar" Visible="false" runat="server" CssClass="button" Text="Buscar" OnClick="btnBuscar_Click" />
                <%--<div runat="server" id="containerOffers" class="m-auto">
                </div>--%>
            </div>
            <div class="flex gap-16 flex-center m-auto">
                <div class="flex-center">
                    <asp:GridView ID="GrdOfertas" runat="server" CssClass="grid-view" AutoGenerateColumns="false" OnRowCommand="GrdOfertas_RowCommand">
                        <Columns>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblidOferta" runat="server" Text='<%# Eval("idOferta") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblnomOferta" ToolTip="Hola" CssClass="text-item text-semibold color-gray-900" runat="server" Text='<%# Eval("tituloVacante") %>'></asp:Label>
                                    <asp:ImageButton ID="imgVer" runat="Server" Style="height: 25px; width: 25px;" CommandArgument="<% # Container.DataItemIndex %>" CommandName="VerDatos" ImageUrl="~/Images/ver.png" ToolTip="Ver oferta." />
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
                                    <br />
                                    <asp:Label ID="Label2" runat="server" AssociatedControlID="CheckBox1" CssClass="check-box">
                                        <p>Destacada</p>
                                        <span>
                                            <asp:CheckBox ID="CheckBox1" runat="server" Enabled="true" CssClass="" />
                                            <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                                <path stroke-linecap="round" stroke-linejoin="round" d="M5 13l4 4L19 7" />
                                            </svg>
                                        </span>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>
            </div>
            <div id="openModal" class="modalDialog" runat="server" style="display: none">
                <div>
                    
                    <h3 class="text-subtitle">¡Estimado usuario! <span class="text-highlighted text-subtitle">una vez  elimine esta oferta perderá el cupo dentro de su paquete.</span> ¿Desea continuar?
                    </h3>

                    <div class="flex-center">
                        <asp:Button ID="Button1" Visible="true" runat="server" CssClass="button bg-red-400" Text="No estoy seguro" OnClick="Cancerlar_Click" />
                        <asp:Button ID="Anular" Visible="true" runat="server" CssClass="button" Text="Continuar" OnClick="Anular_Click" />
                    </div>
                </div>
                <div id="variable" runat="server" style="display:none">
                    <asp:Label ID="lblIdOfertaDelete" runat="server" Text=""></asp:Label>

                </div>
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>




</asp:Content>
