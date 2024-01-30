<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="co.itmasters.solucion.web.Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/error.gif" 
                style="text-align: center" />
            <br />
            <br />
            <br />
            <asp:Label ID="lblMensaje" runat="server" Text="Mensaje" style="font-size: small; font-weight: 700"></asp:Label>
    
            <br />
            <br />
            <asp:LinkButton ID="lnkAtras" runat="server" onclick="lnkAtras_Click">Volver a ITMasters</asp:LinkButton>
            <br />
    
    </div>
    </form>
</body>
</html>


