<%@ Page Title="Mi Empleo - Admon tablas básicas" Language="C#" MasterPageFile="~/ITMasters.Master"
    AutoEventWireup="true" EnableEventValidation="false" CodeBehind="DetallePagina.aspx.cs"
    Inherits="co.itmasters.solucion.web.Administracion.DetallePagina" %>

<%@ MasterType VirtualPath="~/ITMasters.master" %>
<asp:Content ID="idListaValor" ContentPlaceHolderID="Main" runat="server">
    <!-- DIV PARA SELECCIONAR LA TABLA A LA QUE SE LE HACE EL MANTENIMIENTO -->
    <div>
        <asp:UpdatePanel ID="uConsulta" runat="server">
            <ContentTemplate>
                <h1 class="text-subtitle"><span class="text-normal text-highlighted">Administración tablas básicas</h1>
                <asp:Panel ID="Panel1" runat="server" Visible="true">
                    <div class="h-group" style="align-items: center">
                        <h3 class="text-normal  text-highlighted">Archivo</h3>
                        <asp:DropDownList ID="cmbTipo" runat="server" Width="50%" AutoPostBack="true"
                            OnSelectedIndexChanged="cmbTipo_SelectedIndexChanged" CssClass="drop-down-list">
                        </asp:DropDownList>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <!-- DIV PARA FILTROS -->
    <div id="DivFiltro" style="width: 100%">
        <asp:UpdatePanel ID="uFiltro" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pAlma" runat="server" Visible="false">
                    <h1 class="text-subtitle"><span class="text-normal text-highlighted">Aplicar filtros</h1>
                    <asp:Panel ID="pFiltro" runat="server">
                    </asp:Panel>
                        <%--Aqui van los combos de los filtros--%>
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="cmbTipo" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

    <!-- DIV PARA VISUALIZAR DETALLES DE LA TABLA SELECCIONADA -->
    <div style="width: 100%" runat="server" id="divDatos">
        <asp:UpdatePanel ID="uDatos" runat="server">
            <ContentTemplate>

                <table class="tabla" width="100%">
                    <tr>
                        <th width="95%">
                            <h1 class="text-subtitle"><span class="text-normal text-highlighted">Detalle de información</h1>
                        </th>
                        <th width="5%">
                            <asp:ImageButton ID="imgNuevo" runat="server" ImageUrl="~/Images/Nuevo1.gif" ToolTip="Agregar registro"
                                Style="height: 25px; width: 25px; cursor: pointer;" OnClick="imgNuevo_Click"
                                Height="20px" Width="20px" />
                        </th>
                    </tr>

                    <tr class="modo1">
                        <td colspan="2" align="left">
                            <asp:GridView ID="grvDatos" runat="server" OnPageIndexChanging="grvDatos_PageIndexChanging"
                                AllowPaging="True" OnRowCreated="grvDatos_RowCreated" BorderStyle="Solid" ForeColor="Gray"
                                GridLines="Vertical" Width="100%" BorderColor="Gray" BorderWidth="1px" CellPadding="0" CssClass="grid-view" >

                                <PagerSettings FirstPageImageUrl="~/Images/page-first.gif" FirstPageText="" LastPageImageUrl="~/Images/page-last.gif"
                                    LastPageText="" Mode="NextPreviousFirstLast" NextPageImageUrl="~/Images/page-next.gif"
                                    NextPageText="" PreviousPageImageUrl="~/Images/page-prev.gif" PreviousPageText="" />

                                <RowStyle BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Editar">
                                        <ItemStyle Width="8%" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgDetalle" runat="server" ImageUrl="~/Images/Editar.gif" ToolTip="Editar registro"
                                                Style="height: 20px; width: 20px; cursor: pointer;" OnCommand="OnSelectRow" CommandName="Select"
                                                CommandArgument='<%#  DataBinder.Eval(Container.DataItem, "ID")  %>' ImageAlign="Baseline" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <p>
                        </td>
                    </tr>

                    <tr>
                        <th width="95%">
                        </th>
                        <th width="5%"></th>
                    </tr>
                    <tr class="modo1">
                        <td align="center" style="width: 90%">
                            <asp:Label ID="lblInformacion2" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>

                </table>
                <asp:Button ID="btnRecalcular" runat="server" Text="Recalcular" OnClick="btnRecalcular_Click"
                    Style="display: none;" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="cmbTipo" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
