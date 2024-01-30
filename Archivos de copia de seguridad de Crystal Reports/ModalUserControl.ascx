<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModalUserControl.ascx.cs" Inherits="co.itmasters.solucion.web.Components_UI.ModalUserControl" %>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <div>
            <div class="<%# GetContainerCssClass() %>" runat="server" id="modalContainer">
                <div class="modal-content flex-col flex-center-h space-around">
                    <button class="close btn-close pointer" runat="server" id="btnClose" onserverclick="btnClose_Click">
                        <svg xmlns="http://www.w3.org/2000/svg" class="icon-24 color-gray-700" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                            <path stroke-linecap="round" stroke-linejoin="round" d="M6 18L18 6M6 6l12 12" />
                        </svg>
                    </button>
                    <h2 class="text-section text-semibold color-gray-800 text-center" runat="server" id="titleModal"></h2>

                    <asp:Panel runat="server" ID="contentPanel" CssClass="overflow-scroll">
                    </asp:Panel>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="buttonPanel" CssClass="flex-center gap-8" Visible="<%# GetHasButton() %>">
                                <asp:Button Text="Cancelar" runat="server" ID="btnCancel" OnClick="btnCancel_Click" CssClass="button bg-red-500" UseSubmitBehavior="false" />
                                <asp:Button Text="Aceptar" runat="server" ID="btnAccept" OnClick="btnAccept_Click" CssClass="button" UseSubmitBehavior="false" />
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

    </ContentTemplate>
</asp:UpdatePanel>
