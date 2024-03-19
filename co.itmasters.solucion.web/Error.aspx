<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="co.itmasters.solucion.web.Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=, initial-scale=1.0" />
    <title>Error</title>
    <link rel="stylesheet" href="~/css/error-pages.css" />
</head>
<body>
    <form id="form1" runat="server">
        <header class="header">
            <nav class="nav">
                <a class="wrapper-logo" href="~/Home/Default.aspx">
                    <asp:Image runat="server" class="logo" ImageUrl="~/Images/ImgInicio/LOGO.webp" AlternateText = "Logo" />
                </a>
            </nav>
        </header>
        <main>
            <section class="content">
                <div class="header-error">
                    <figure>
                        <asp:Image ImageUrl="~/Images/ErrorGenerico.webp" runat="server" CssClass="img-error" ID="imgError"  AlternateText="Error Image"/>
                    </figure>
                    <h1 class="cod-error text-bold" id="codError" runat="server"></h1>
                </div>
                <article class="info-error">
                    <h2 class="title-error text-bold text-title" id="titleError" runat="server"></h2>
                    <p class="text-error text-bold text-regular" id="textError" runat="server"></p>
                </article>
                <a runat="server" class="button text-bold text-normal" href="~/Home/Default.aspx">Salir de aquí</a>
            </section>
        </main>
    </form>
</body>
</html>


