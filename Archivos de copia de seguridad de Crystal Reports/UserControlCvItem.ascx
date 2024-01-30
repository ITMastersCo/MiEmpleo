<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControlCvItem.ascx.cs" Inherits="co.itmasters.solucion.web.Components_UI.UserControlCvItem" %>


<article class="cv-item_info">
    <header class="cv-item">
        <div class="flex cv-item-title">
            <i class="cv-icon" runat="server" id="itemIcon">
                <%-- Icon Experience || Studies  --%>

            </i>
            <h4 class="text-item color-gray-700 text-semibold" runat="server" ID="itemTitle"></h4>
        </div>
        <div class="flex cv-icons">

          
                    <asp:Label Text="" runat="server" class="flex cv-icon" ID="lblEdit" AssociatedControlID="btnEdit">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24px" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                            <path stroke-linecap="round" stroke-linejoin="round" d="M15.232 5.232l3.536 3.536m-2.036-5.036a2.5 2.5 0 113.536 3.536L6.5 21.036H3v-3.572L16.732 3.732z" />
                        </svg>
                    <asp:Button Text="" runat="server" ID="btnEdit" OnClick="btnEdit_ServerClick" OnClientClick="<%# OnClientClickEdit %>" />
                    </asp:Label>

                    <asp:Label Text="" runat="server" class="cv-icon" ID="lblDelete" AssociatedControlID="btnDelete">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24px" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                          <path stroke-linecap="round" stroke-linejoin="round" d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16" />
                        </svg>
                    <asp:Button Text="" class="cv-icon" runat="server" ID="btnDelete" OnClick="btnBuscar_Click" />
                    </asp:Label>
            

        

            
        </div>
    </header>
    <div class="cv-item-info">
        <p class='text-normal text-regular color-gray-600' runat="server" ID="itemContent"></p>
        <p class='text-normal text-regular color-gray-600' runat="server" ID="itemDate"></p>
    </div>
</article>
