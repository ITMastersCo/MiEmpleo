<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroEmpresa.aspx.cs" Inherits="co.itmasters.solucion.web.Home.RegistroEmpresa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Mi empleo | Registro Empresa</title>
    <link href="~/Images/imgInicio/MiEmpleo.ico" type="image/x-icon" rel="shortcut icon" />
    <link rel="stylesheet" href="../css/Empresa.css" />
    <link rel="stylesheet" href="../css/Sesion.css" />

</head>
<body>
    <div class="wrapper-sesion">
        <header class="headerSesion">
            <a href="../index.aspx">
                <img src="../images/ImgInicio/Logo-horizontal-dark.webp" width="280px" alt="Inicio" />
            </a>
        </header>


        <main class="wrapper">
            <div class="h-group">
                <h1 class="text-subtitle"><span class="text-subtitle text-highlighted">Crea </span>tu cuenta</h1>

            </div>

            <!-- Asp -->
            <form id="form" runat="server" class="form-column ">
                <asp:ScriptManager runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanelform" runat="server">
                    <ContentTemplate>
                        <asp:ValidationSummary ID="ValidationSummary" runat="server" ValidationGroup="Registro" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ValidaRegistro" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="txtNumIdentificacion" ErrorMessage="" ValidationGroup="ValidaRegistro" ForeColor="#CC0000" CssClass="text">Digite el nít de identificación válido</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtNumIdentificacion" TextMode="Number" placeholder="NIT / Id de la empresa" runat="server" CssClass="input"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtEmail" ErrorMessage="" ValidationGroup="ValidaRegistro" ForeColor="#CC0000" CssClass="text">Debe registrar un correo válido</asp:RequiredFieldValidator>
                        <asp:TextBox ID="TxtEmail" TextMode="Email" onblur="validateEmail()" placeholder="Correo" runat="server" CssClass="input"></asp:TextBox>

                        <div id="divClave" runat="server" style="display: none">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"   ControlToValidate="txtPassword" ErrorMessage="" ValidationGroup="Registro" ForeColor="#CC0000" CssClass="text">La contraseña debe ser alfanumérica y un caracter especial.</asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtPassword" TextMode="Password" placeholder="Contraseña" onchange="validarPassword()" runat="server" CssClass="input"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  ControlToValidate="TxtPassword2" ErrorMessage="" ValidationGroup="Registro" ForeColor="#CC0000" CssClass="text">la contraseña debe ser igual a la nueva contraseña.</asp:RequiredFieldValidator>
                            <asp:TextBox ID="TxtPassword2" TextMode="Password" placeholder="Confirmar contraseña" onchange="validarPassword()" runat="server" CssClass="input"></asp:TextBox>
                        </div>

                        <p class="text-small text-regular gray-500">
                            *Los datos de registro como número de identificación y correo
                    electrónico, no podrán ser modificados mas adelante, asegúrese
                    de diligenciar la información correctamente.
                        </p>
                        <asp:Label ID="lblError" runat="server" Text="err" CssClass="text" Visible="false" ForeColor="Red"></asp:Label>
                        <span>
                            <input type="checkbox" id="chkConditions" runat="server" name="chkConditions" required="required" />
                            <label for="chkConditions" class="text-small gray-900 text-semibold">
                                Acepto
                        <a href="<%= UrlTerminos  %>" class="text-small text-highlighted text-underline pointer">términos y condiciones.
                        </a>
                            </label>

                        </span>
                        <div class="g-recaptcha" data-sitekey="your_site_key"></div>
                                                    <div runat="server" id="divCapcha">

                            <div id="html_element">

                            </div>
                            </div>

                          <br />
                        <br />
                        <div class="flex flex-col gap-8">

                        <asp:LinkButton ID="lnkRegistroValida" runat="server" Visible="true" CssClass="button item-center" ValidationGroup="ValidaRegistro" OnClick="lnkRegistro_Click"> Valida Cuenta</asp:LinkButton>
              
                                <asp:LinkButton ID="lnkRegistro" runat="server" CssClass="button item-center"  Visible="false" ValidationGroup="Registro" OnClick="lnkAutRegistro_Click">Crear Cuenta</asp:LinkButton>
                        
                        <p class="text-small text-semibold item-center">
                            ¿Ya tienes una?
                    <a href="./LoginEmpresa.aspx" class="text-small text-semibold text-highlighted text-underline
                pointer">Ingresa
                    </a>
                        </p>

                        </div>

                        <div id="openModal" class="modalDialog" runat="server" style="display: none">

                            <div style="text-align: center; display: block" id="valida" runat="server">
                                <p class="text-medium text-semibold item-center">
                                    ¡ESTIMADO(A) USUARIO(A)! 
                                </p>
                                <p class="text-medium text-semibold item-center">
                                    Se ha enviado un token al correo registrado. Es importante destacar que este token tiene una validez de tan solo 10 minutos. En caso de que se solicite la generación de un nuevo token antes de que transcurra este período de tiempo, el token anterior será anulado automáticamente, y se generará uno nuevo para su uso.
                                </p>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtToken" ErrorMessage="" ValidationGroup="Token" ForeColor="#CC0000" CssClass="text">Digite el token enviado al correo registrado.</asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtToken" Width="280px" TextMode="Number" placeholder="Número de token" runat="server" CssClass="input"></asp:TextBox>
                                <br />
                                <br />
                                <p>
                                    <asp:LinkButton ID="LnkValidar" runat="server" CssClass="button item-center" OnClick="lnkValidar_Click" ValidationGroup="Token" > Validar Token</asp:LinkButton>
                                </p>
                                <br />
                                <br />
                                <p>
                                    <a href="../Home/RegisroEmpresa.aspx" id="volver" runat="server" class="text-small-14 text-600 text-highlighted text-underline
                                                pointer">Volver a generar token
                                    </a>
                                </p>

                            </div>

                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </form>


        </main>

        <aside class="info">
            <img src="../images/ImgInicio/login-empresa.webp" alt="" />
        </aside>
    </div>

    <script type="text/javascript">
        document.getElementById("txtNumIdentificacion").focus();
        var inuput1 = document.getElementById("txtPassword");
        var inuput2 = document.getElementById("TxtPassword2");
        function validarPassword() {
            var p1 = document.getElementById("txtPassword").value;
            var p2 = document.getElementById("TxtPassword2").value;

            var espacios = false;
            var cont = 0;

            // Este bucle recorre la cadena para comprobar
            // que no todo son espacios
            while (!espacios && (cont < p1.length)) {
                if (p1.charAt(cont) == " ")
                    espacios = true;
                cont++;
            }
            validarContrasena();
            if (espacios) {
                alert("La contraseña no puede contener espacios en blanco");
                inuput1.value = "";
                inuput2.value = "";
                return false;
            }



            if (p1 != p2) {
                alert("Las contraseñas deben de coincidir");

                inuput2.value = "";
                return false;
            } else {
                //alert("Todo esta correcto");

                return true
            }
        }
        function validateEmail() {

            // Get our input reference.
            var emailField = document.getElementById('TxtEmail');

            // Define our regular expression.
            var validEmail = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

            // Using test we can check if the text match the pattern
            if (validEmail.test(emailField.value)) {

                return true;
            } else {
                alert('El correo electrónico no es válido.');
                document.getElementById("TxtEmail").value = "";
                return false;
            }
        }
        function validarContrasena() {
            var contrasena = document.getElementById("txtPassword").value

            const expresionRegular = /^(?=.*[a-zA-Z0-9])(?=.*[\W_]).{8,}$/;

            if (contrasena != "") {
                if (expresionRegular.test(contrasena)) {
                    return true;
                }
                else {
                    alert("La contraseña debe contener mínimo 8 caracteres, de los cuales deben incluir al menos una mayúscula, números y un carácter especial.");
                    inuput1.value = "";
                    inuput2.value = "";
                }
            }
        }
        var onloadCallback = function () {
            const recaptchaPlaceholder = document.getElementById('html_element');
            if (recaptchaPlaceholder) {
                grecaptcha.render(recaptchaPlaceholder, {
                    'sitekey': '<%= SiteKeyCaptcha %>'
                });
            } else {
                console.error('El elemento de marcador de posición de reCAPTCHA no es válido.');
            }
        };
        function confirmaRegistro() {
            alert('Su cuenta fue creada con exito.')
            window.location.href = "../Home/LoginEmpresa.aspx";
        }
    </script>
        <script src="https://www.google.com/recaptcha/api.js?onload=onloadCallback&render=explicit"
    async defer>
</script>
</body>

</html>
