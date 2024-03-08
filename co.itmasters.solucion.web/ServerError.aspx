<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServerError.aspx.cs" Inherits="co.itmasters.academics.web.ServerError" %>

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
                <a class="wrapper-logo" href="/Default.aspx">
                    <img class="logo" src="/Images/Academics-logo.webp" alt="Logo"/>
                </a>
            </nav>
        </header>
        <main>
            <section class="content">
                <div class="header-error">
                    <figure>
                        <img src="." class="img-error" id="imgError" runat="server" alt="Error Image"/>
                    </figure>
                    <h1 class="cod-error text-bold" id="codError" runat="server"></h1>
                </div>
                <article class="info-error">
                    <h2 class="title-error text-bold text-title" id="titleError" runat="server"></h2>
                    <p class="text-error text-bold text-regular" id="textError" runat="server"></p>
                </article>
                <a class="button text-bold text-normal" href="~/Default.aspx">Salir de aquí</a>
            </section>
        </main>
    </form>
</body>
</html>
