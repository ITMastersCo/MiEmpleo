<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="403.aspx.cs" Inherits="co.itmasters.academics.web._403" %>

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
                        <asp:Image ImageUrl="~/Images/Error403.webp" runat="server" class="img-error" id="imgError"  alt="Error Image"/>
                    </figure>
                    <h1 class="cod-error text-bold" id="codError" runat="server">403</h1>
                </div>
                <article class="info-error">
                <h2 class="title-error text-bold text-title">Acceso denegado</h2>
                <p class="text-error text-bold text-regular">
                    Usted <span class="color-red text-error text-bold text-regular"> no </span> tiene permiso para acceder a esta página.
                    El acceso está  prohibido y cualquier intento de acceso no autorizado puede tener implicaciones
                    <span class="color-red text-error text-bold text-regular">legales</span>. Por  favor, asegrese de que tiene los permisos adecuados antes de intentar acceder a este recurso. Si cree que esto es un error, contacta al administrador del sitio.Recuerde que intentar acceder a recursos restringidos puede ser una violación de las <span class="color-red text-error text-bold text-regular">leyes</span> de privacidad y seguridad. Si no está autorizado para acceder a este contenido, abtengase de volver a intentarlo.
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
