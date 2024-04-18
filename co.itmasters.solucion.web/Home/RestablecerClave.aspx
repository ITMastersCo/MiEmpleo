<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RestablecerClave.aspx.cs" Inherits="co.itmasters.solucion.web.Home.RestablecerClave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Mi empleo | Restablece contraseña</title>
    <link href="~/Images/imgInicio/MiEmpleo.ico" type="image/x-icon" rel="shortcut icon" />
    <link rel="stylesheet" href="../css/Restablecer.css" />
    <link rel="stylesheet" href="../css/Sesion.css" />

    <script src="https://www.google.com/recaptcha/api.js" async="async" defer="defer"></script>
    <script src="../Scripts/jquery-1.9.1.min.js"></script>


    <script type="text/javascript">
        function showModal() {
            document.getElementById('openModal').style.display = 'block';
        }
        function CloseModal() {
            document.getElementById('openModal').style.display = 'none';
        }
    </script>
</head>
<body>
    <div class="wrapper-sesion">

        <header class="headerSesion">
            <a href="../index.aspx">
                <img src="../images/ImgInicio/Logo-horizontal-dark.webp" width="280px" alt="Inicio" />
            </a>
            
        </header>


        <main class="wrapper">

            
              
           
            <!-- Asp -->
            <form id="form" runat="server" class="form-column">
                <asp:ScriptManager runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>

                        <div style="text-align: center;  display: none" id="nuevaClave" runat="server">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPw1" ErrorMessage="" ValidationGroup="Contrasena" ForeColor="#CC0000" CssClass="text">la contraseña debe ser alfanumérica y un caracter especial.</asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtPw1" TextMode="Password" runat="server" placeholder="Nueva contraseña" CssClass="input" onblur="validarContrasena()"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPw2" ErrorMessage="" ValidationGroup="Contrasena" ForeColor="#CC0000" CssClass="text">la contraseña debe ser igual a la nueva contraseña.</asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtPw2" TextMode="Password" runat="server" placeholder="Confirmar contraseña" CssClass="input"></asp:TextBox>
                            <br />
                            <br />
                            <h2>
                                <asp:LinkButton ID="Linkactualizar" runat="server" CssClass="button item-center" OnClientClick="validarPassword();" OnClick="lnkActualizarPW_Click" ValidationGroup="Contrasena"> Actualizar Contraseña</asp:LinkButton></h2>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel" runat="server">
                    <ContentTemplate>
                        <div id="divValida" runat="server" style="display: block">
                            <asp:ValidationSummary ID="ValidationSummary" runat="server" ValidationGroup="Restablece" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Token" />
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="contrasena" />
                            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="cmbTipPersona" ErrorMessage="" MaximumValue="10" MinimumValue="0" Type="Integer" ValidationGroup="Restablece" ForeColor="#CC0000" CssClass="text">Seleccione el tipo de usuario</asp:RangeValidator>
                            <asp:DropDownList ID="cmbTipPersona" runat="server" CssClass="drop-down-list cmbTipPersona">
                                <asp:ListItem Selected="True" Value="-1">Seleccione un tipo de usuario</asp:ListItem>
                                <asp:ListItem Value="2">Candidato</asp:ListItem>
                                <asp:ListItem Value="1">Empresa</asp:ListItem>
                            </asp:DropDownList>
                            <p class="text-small text-regular gray-500">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumIdentificacion" ErrorMessage="" ValidationGroup="Restablece" ForeColor="#CC0000" CssClass="text">Digite número de identificación válido</asp:RequiredFieldValidator>
                            </p>
                            <asp:TextBox ID="txtNumIdentificacion" TextMode="Number" placeholder="NIT / Num.identificación" runat="server" CssClass="input"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtMail" ErrorMessage="" ValidationGroup="Restablece" ForeColor="#CC0000" CssClass="text">Digite un correo válido</asp:RequiredFieldValidator>
                            <asp:TextBox ID="TxtMail" TextMode="Email" runat="server" placeholder="Correo" CssClass="input"></asp:TextBox>
                            <p class="text-small text-regular gray-500" id="texto" runat="server">
                                <asp:Label ID="lbltexto" runat="server" Text=" *Los datos de registro como número de identificación y correo
					            electrónico, deben ser de acuerdo a los registrados en la base de datos, asegúrese
					            de diligenciar la información correctamente.">
                                </asp:Label>

                            </p>
                            <br />
                            <%--<div class="g-recaptcha" data-sitekey="your_site_key"></div>--%>
                            <p class="text-small text-regular gray-300">
                            <asp:LinkButton ID="lnkRetablecer" runat="server" CssClass="button item-center" OnClick="lnkRetablecer_Click" ValidationGroup="Restablece"> Restablecer Contraseña</asp:LinkButton>
                            </p>
                            <br />
                            <p class="text-small text-regular red-700">
                                <asp:Label runat="server" ID="LblMensajeError" Text="" ForeColor="#CC0000"></asp:Label>
                            </p>
                            <div class="form-column" style="display: block" id="inicio" runat="server">
                                <p class="text-small text-semibold item-center">
                                    ¡Volver a inicio de sesión!
                                    <a href="../Index.aspx" class="text-small text-semibold text-highlighted text-underline pointer">Volver</a>
                                </p>
                            </div>
                        </div>
                       
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                         <div id="openModal" class="modalDialog" runat="server" style="display: none">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
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
                                            <asp:LinkButton ID="LnkValidar" runat="server" CssClass="button item-center" OnClick="lnkValidar_Click" ValidationGroup="Token"> Validar Token</asp:LinkButton>
                                        </p>
                                        <br />
                                        <br />
                                        <p>
                                            <a href="../Home/RestablecerClave.aspx" id="volver" runat="server" class="text-small-14 text-600 text-highlighted text-underline
                                                pointer">Volver a generar token
                                            </a>
                                        </p>

                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        </ContentTemplate>
                </asp:UpdatePanel>
            </form>
        </main>
        <aside class="info">
            <img src="../images/ImgInicio/restablecer.png" alt="" />
        </aside>
    </div>
    <script type="text/javascript">
        function validarContrasena() {
            var contrasena = document.getElementById("txtPw1").value

            const expresionRegular = /^(?=.*[a-zA-Z0-9])(?=.*[\W_]).{8,}$/;

            if (contrasena != "") {
                if (expresionRegular.test(contrasena)) {
                    return true;
                }
                else {
                    alert("La contraseña debe contener mínimo 8 caracteres, de los cuales deben incluir al menos una mayúscula, números y un carácter especial.");
                    document.getElementById("txtPw1").value = "";
                }
            }


        }
        function validarPassword() {

            var p1 = document.getElementById("txtPw1").value;
            var p2 = document.getElementById("txtPw2").value;
            var espacios = false;
            var cont = 0;

            // Este bucle recorre la cadena para comprobar
            // que no todo son espacios
            while (!espacios && (cont < p1.length)) {
                if (p1.charAt(cont) == " ")
                    espacios = true;
                cont++;
            }

            if (espacios) {
                alert("La contraseña no puede contener espacios en blanco");
                return false;
            }

            if (p1.length == 0 || p2.length == 0) {
                alert("Los campos de la contraseñas no pueden quedar vacios");
                return false;
            }

            if (p1 != p2) {
                alert("Las contraseñas deben de coincidir");
                return false;
            } else {
                //alert("Todo esta correcto");
                var clickButton = document.getElementById("<%= Linkactualizar.ClientID %>");
                clickButton.click();
                return true



            }
        }
        function confirmaRegistro() {
            const tipoUsuario = document.querySelector(".cmbTipPersona")

            
            alert('Su contraseña se recupero con exito.')

            switch (tipoUsuario?.value) {
                case 1:
                    window.location.href = "../Home/LoginEmpresa.aspx";
                    break;
                case 2:
                    window.location.href = "../Home/Login.aspx";
                    break;
                default:
                    window.location.href = "../Home/Login.aspx";
                    break;
            }

            
        }
    </script>
</body>

</html>
