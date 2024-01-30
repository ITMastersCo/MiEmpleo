<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RestaurarClave.aspx.cs" Inherits="co.itmasters.solucion.web.Home.RestaurarClave" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Academics - Restaurar Clave</title>
    <link href="../Images/logo_cabezote.ico" type="image/x-icon" rel="shortcut icon" />
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport' />
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="../css/SolicitarClave.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.3/css/all.css" integrity="sha384-UHRtZLI+pbxtHCWp1t77Bi1L4ZtiqrqD80Kn4Z8NTSRyMA2Fd33n5dQ8lWUE00s/" crossorigin="anonymous" />
    <script src="../Scripts/JRestaurarClave.js" type="text/javascript"></script>
    <script src='<%=ResolveClientUrl("~/Scripts/respond.min.js")%>' type="text/javascript"></script>
    <script src='<%=ResolveClientUrl("~/Scripts/jquery-1.7.js")%>' type="text/javascript"></script>
    <script src='<%=ResolveClientUrl("~/Scripts/jquery-Aplicacion.js")%>' type="text/javascript"></script>
    <script src='<%=ResolveClientUrl("~/Scripts/jquery-ui-1.8.16.custom.min.js")%>' type="text/javascript"></script>
    <script src='<%=ResolveClientUrl("~/Scripts/SHA1.js")%>' type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <script type="text/javascript">
            function changeMeClave() {
                parent.document.getElementById('txtClave').value = SHA1(parent.document.getElementById('txtClave').value);
            }

            function changeMeClaveConfirm() {
                parent.document.getElementById('TxtConfirmacion').value = SHA1(parent.document.getElementById('TxtConfirmacion').value);
            }
        </script>
        <nav class="navbar navbar-toggleable-md navbar-inverse fixed-top bg-inverse" role="navigation">
        <!--<button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarCollapse" aria-controls="navbarCollapse" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>-->
        <a class="navbar-brand" href="#"><img alt="xx" style="margin-left:550px" src="../Images/imgDiseño/logo.png" /></a>
        <!-- Collect the nav links, forms, and other content for toggling -->
        </nav>
        <div class="container">
            <div style="margin-top: 30px;" class="row">
                <div class="col-md-3">
                    <div class="card-base">
                        <div class="card-icon">
                            <a href="#" title="Usuario" id="widgetCardIcon" class="imagecard"><span class="fas fa-user-tie fa-2x"></span></a>
                            <div class="card-data widgetCardData">
                                <hr />
                                <h2 class="box-title">Restaurar clave</h2>
                                <h4 class="text-info">Usuario</h4>
                                <p>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Digite el nombre del usuario, funcionario del colegio (1254698745@dom.edu.co), padre de familia (pdf123@dom.edu.co)"
                                        ValidationGroup="Buscar" ControlToValidate="txtNombreUsuario">*</asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtNombreUsuario" Width="245" Height="30" placeholder="Eje: 1254698745@dom.edu.co" Style="border: 1px solid #000000; border-radius: 5px;" runat="server" ToolTip="Digite el nombre del usuario, funcionario del colegio (1254698745@dom.edu.co), padre de familia (pdf123@dom.edu.co)">
                                    </asp:TextBox>

                                </p>
                                <br />
                                <p>
                                    <asp:LinkButton ID="lnkBuscarPreguntas" CssClass="btn btn-success" ValidationGroup="Buscar" runat="server" Text="Buscar" ToolTip="El sistema le hará unas preguntas para permitir la regeneración de la clave."
                                        Enabled="true" OnClick="lnkBuscarPreguntas_Click" />
                                </p>
                                <p>
                                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="Buscar" ForeColor="" />
                                    <asp:Label ID="lblError" runat="server" CssClass="modo1" Text="" ForeColor="Red"></asp:Label>
                                </p>
                            </div>
                        </div>
                        <div class="space"></div>
                    </div>
                </div>
                <div class="col-md-9">
                    <div class="card-base">
                        <div class="card-icon">
                            <a href="#" title="Usuario" id="widgetCardIcon" class="imagecard"><span class="fa fa-question fa-2x"></span></a>
                            <div class="card-data widgetCardData">
                                <div runat="server" id="DivPreguntas" class="icons">
                                    <p class="text-info">
                                        <asp:Label Font-Bold="true" ID="lblPregunta1" runat="server"></asp:Label>
                                    </p>
                                    <div class="bg-info">
                                        <asp:RadioButtonList CellPadding="5" Width="100%" ID="rblPregunta1" runat="server" RepeatDirection="Horizontal">
                                        </asp:RadioButtonList>
                                    </div>

                                    <p class="text-warning">
                                        <asp:Label ID="lblPregunta2" Font-Bold="true" runat="server"></asp:Label>
                                    </p>
                                    <div class="bg-warning">
                                        <asp:RadioButtonList CellPadding="5" Width="100%" ID="rblPregunta2" runat="server" RepeatDirection="Horizontal">
                                        </asp:RadioButtonList>
                                    </div>
                                    <p class="text-success">
                                        <asp:Label ID="lblPregunta3" Font-Bold="true" runat="server"></asp:Label>
                                    </p>
                                    <div class="bg-success">
                                        <asp:RadioButtonList CellPadding="5" Width="100%" ID="rblPregunta3" runat="server" RepeatDirection="Horizontal">
                                        </asp:RadioButtonList>
                                    </div>
                                    <br />
                                    <asp:LinkButton ID="lnkEnviarRespuestas" CssClass="btn btn-info" runat="server" Text="Enviar Respuestas" ToolTip="Enviar respuestas para verificación."
                                        Enabled="true" OnClientClick="CargarPreguntas();"
                                        OnClick="lnkEnviarRespuestas_Click" />

                                </div>
                                <hr />

                                <div runat="server" id="DivRestaurar" class="row">
                                        <div class="col-md-4 col-md-offset-1 ">
                                            <asp:TextBox ID="txtClave" runat="server" CssClass="form-control TXT" placeholder="Digite nueva contraseña" TextMode="Password" ToolTip="Nueva contraseña" onblur="changeMeClave();"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="TxtConfirmacion" runat="server" CssClass="form-control TXT" placeholder="Comfrimación nueva contraseña" TextMode="Password" ToolTip="Comfrimación nueva contraseña" onblur="changeMeClaveConfirm();"></asp:TextBox>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:LinkButton ID="lnkRestaurarClave" runat="server" Text="Restaurar" ToolTip="Envíe para restaurar la clave."
                                                Enabled="true" OnClick="lnkRestaurarClave_Click" CssClass="btn btn-success" />
                                        </div>
                                        <input id="hdnAlert" runat="server" type="hidden" value="0" />
                                        <input id="hdnRespuestaPregunta1" runat="server" type="hidden" value="0" />
                                        <input id="hdnRespuestaPregunta2" runat="server" type="hidden" value="0" />
                                        <input id="hdnRespuestaPregunta3" runat="server" type="hidden" value="0" />
                                        <input id="hdnIdPregunta1" runat="server" type="hidden" value="0" />
                                        <input id="hdnIdPregunta2" runat="server" type="hidden" value="0" />
                                        <input id="hdnIdPregunta3" runat="server" type="hidden" value="0" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <footer class="footer">
        <div class="container">
            <div style="width: 40%; display: block; float: left; margin-top: 12px; text-align: center;
                vertical-align: middle; height: 53px; color:#ffffff">
                <b style="font-weight: 700">&#169 2002 - </b><strong id="fecha"></strong>

                <b style="font-weight: 700">
                    Todos los derechos reservados
                    Bogotá - Colombia
                </b>
            </div>
            <a href="http://www.itmasters.com.co/" target="_blank"><img width="200" alt="xxx" height="59" src="../Images/imgDiseño/itMasters_logo_blanco.png" /></a>  
            <ul class="social-icon animate pull-right">
                <li><a href="https://www.facebook.com/AcademicsCo/?ref=hl" title="facebook" target="_blank"> <span style="margin-top:8px" class="fab fa-facebook fa-2x"></span></a></li> <!-- change the link to social page and edit title-->
                <li><a href="https://twitter.com/academicsit" title="twitter" target="_blank"><i style="margin-top:8px" class="fab fa-twitter fa-2x"></i></a></li>
            </ul><small> <a href="http://www.freepik.com" target="_blank">Designed by Freepik</a> and <a href="http://getbootstrap.com/" target="_blank">Designed by Bootstrap</a> </small>
        </div>
        </footer>
        <script type="text/javascript" src="../js/bootstrap.js"></script>
        <script type="text/javascript" src="../js/bootstrap.min.js"></script>
    </form>
</body>
      <script type="text/javascript">
            $(document).ready(function () {
                    var fecha = new Date();
                    var anio = fecha.getFullYear();
                    $("#fecha").text(anio);
            });
        </script>
</html>
