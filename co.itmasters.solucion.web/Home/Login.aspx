﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="co.itmasters.solucion.web.Home.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
 <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Mi empleo | Inicio sesión candidato</title>
     <link href="~/Images/imgInicio/MiEmpleo.ico" type="image/x-icon" rel="shortcut icon" />
    <link rel="stylesheet" href="../css/Empleado.css"/>
    <%--se agerga porque SHA1.js utiliza esta libreria ajax--%>
    <script src="../Scripts/jquery-1.9.1.min.js"></script>
    <script src='<%=ResolveClientUrl("../Scripts/SHA1.js")%>' type="text/javascript">
    </script>
</head>
<body>
                   
   <div class="wrapper-sesion">
    <header class="headerSesion">
        <a href="../index.aspx">
            <img src="../images/ImgInicio/LOGO.png" width="280px" alt="Inicio">
        </a>
    </header>

        <main class="wrapper">
            <div class="h-group">
                <h1 class="text-subtitle"><span class="text-subtitle text-highlighted">Inicia </span>Sesión</h1>
                <h4 class="text-small">Y encuentra el empleo ideal</h4>
            </div>
        <form  runat="server" id="idform" class="form-column LogIn">
            <script type="text/javascript">

                $(document).ready(function () {
                    $('#cLogin_Password').change(function () {
                        $('#cLogin_Password').val(SHA1($('#cLogin_Password').val()));
                        var fecha = new Date();
                        var anio = fecha.getFullYear();
                        $("#fecha").text(anio);
                    });
                });
            </script>
            <div class="form-column ">
                <asp:Login ID="cLogin" runat="server" DisplayRememberMe="False" DestinationPageUrl="./Default.aspx"
                    FailureText="Usuario o clave incorrectas" OnLoggedIn="cLogin_LoggedIn" LoginButtonStyle-Height="45px"
                    LoginButtonStyle-CssClass="button item-center" PasswordRequiredErrorMessage="Password Requerido."
                    UserNameRequiredErrorMessage="Usuario Requerido." LoginButtonText="Iniciar Sesión" LoginButtonStyle-Width="200px"
                    TitleText="" UserNameLabelText="" Font-Bold="True"
                    ForeColor="#266886" Width="100%"
                    Height="186px" BorderStyle="Ridge" BorderPadding="0"
                    Font-Names="Inter" BorderColor="Black" BorderWidth="0px" FailureAction="Refresh"
                    OnAuthenticate="cLogin_Authenticate" Font-Size="Small" PasswordLabelText=""
                    TextBoxStyle-CssClass="input">
                    <LoginButtonStyle CssClass="button item-center" Height="45px" Width="200px"></LoginButtonStyle>
                    <TextBoxStyle CssClass="input" />
                </asp:Login>

                <p class="text-small-14 text-600">
                    ¿Olvidaste tu contraseña?
                    <a href="../Home/RestablecerClave.aspx" class="text-small-14 text-600 text-highlighted text-underline
                    pointer">
                    Restablecer
                </a>
            </p>
        </div>
        
        <div class="form-column">
            
            
            <p class="text-small-14 text-600 item-center">
                ¿Aún no tienes una cuenta? 
                <a href="../Home/RegistroCandidato.aspx" class="text-small-14 text-600 text-highlighted text-underline
                   pointer">
                    Registrate
                   </a>
                </p>
            </div>
        </form>
    </main>
    <aside class="info">
        <img src="../images/ImgInicio/mujer-entrevista 1.png" alt=""/>
    </aside>
</div>
<script type="text/javascript">
    const inputUserName = document.getElementById('cLogin_UserName')
    inputUserName.setAttribute('placeholder', 'Usuario')
    const inputUserPW = document.getElementById('cLogin_Password')
    inputUserPW.setAttribute('placeholder', 'Contraseña')
    const inputSubmmit = document.querySelector('#cLogin_LoginButton')
    const parentinputSubmmit = inputSubmmit.parentNode
    parentinputSubmmit.setAttribute('align','center')
    
</script>
    
</body>

</html>
