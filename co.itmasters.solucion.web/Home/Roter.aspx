<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Roter.aspx.cs" Inherits="co.itmasters.solucion.web.Home.Roter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Document</title>
    <link href="~/Images/imgInicio/MiEmpleo.ico" type="image/x-icon" rel="shortcut icon" />
    <link rel="stylesheet" href="../css/Router.css"/>
</head>
<body>
    <main class="place-center">
        <a href="../index.aspx"><img src="../Images/imgInicio/LOGO.png" alt=""/></a>
        <div class="place-center">

            <h1 class="title">
                ¿Como quieres ingresar?
            </h1>
            <a  href="../Home/LoginCandidato.aspx" class="button text-big employee"> Soy <span class="text-big">Candidato</span></a>
            <a  href="../Home/LoginEmpresa.aspx" class="button text-big tech">Soy <span class="text-big">Empresa</span></a>
        </div>
    </main>

</body>
</html>
