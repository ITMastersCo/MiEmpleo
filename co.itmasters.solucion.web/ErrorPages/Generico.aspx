<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Generico.aspx.cs" Inherits="co.itmasters.academics.web.Generico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=, initial-scale=1.0"/>
    <title>Error</title>
    <link rel="stylesheet" href="~/css/error-pages.css"/>
</head>
<body>
    <form id="formServerError" runat="server">
        <header class="header">
            <nav class="nav">
                <a runat="server" class="wrapper-logo" href="~/Home/Default.aspx">
                    <asp:Image runat="server" class="logo" ImageUrl="~/Images/ImgInicio/LOGO.png" AlternateText = "Logo" />
                </a>
            </nav>
        </header>
        <main>
            <section class="content">
                <div class="header-error">
                    <figure>
                        <asp:Image ImageUrl="~/Images/ErrorGenerico.webp" runat="server" class="img-error" id="imgError"  alt="Error Image"/>
                    </figure>
                    <h1 class="cod-error text-bold" id="codError" runat="server"></h1>
                </div>
                <article class="info-error">
                <h2 class="title-error text-bold text-title">  Error</h2>
                <p class="text-error text-bold text-regular">
                   Se ha producido un error inesperado. Por favor, inténtalo de nuevo más tarde.
                </p>
                </article>
                <a runat="server" class="button text-bold text-normal" href="~/Home/Default.aspx">
                    Salir de aquí
                </a>
                
            </section>
        </main>
    </form>
</body>
</html>
