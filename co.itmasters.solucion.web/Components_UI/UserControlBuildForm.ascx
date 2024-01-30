<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControlBuildForm.ascx.cs" Inherits="co.itmasters.solucion.web.Components_UI.UserControlBuildForm" %>
<div>


    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Panel runat="server" ID="dynamicFieldsPanel" CssClass="flex-col w-100per gap-8 p-16">
            </asp:Panel>

        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Panel runat="server" ID="phButtons" CssClass="flex-center gap-16" Visible="<%# GetHasButtons()%>">
                <asp:Button runat="server" ID="btnAccept" Text="Add Field" OnClick="btnAccpet_Click" CssClass="button bg-red-500" />
                <asp:Button runat="server" ID="btnCancel" Text="Submit" OnClick="btnCancel_Click" CssClass="button bg-green-500" />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
