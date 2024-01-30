<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleRegistro.aspx.cs" Inherits="co.itmasters.solucion.web.Administracion.DetalleRegistro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="~/css/Styles.css" />

    <%--<link href="../Estilos/jquery-ui-1.7.2.custom.css" rel="stylesheet" type="text/css" />--%>

    <script type="text/javascript" src="../Scripts/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-1.3.2-vsdoc.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.7.2.custom.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-Aplicacion.js"></script>
    

    <script type="text/javascript">

        function DesplegaCalendar(h) {
            var comp = h;
            $(function () {
                $(h).datepicker(
                    {
                        dateFormat: 'dd/mm/yy',
                        changeMonth: true,
                        changeYear: true,
                        numberOfMonths: 1,
                        dayNamesMin: ['Dom', 'Lun', 'Mar', 'Mie', 'Jue', 'Vie', 'Sab'],
                        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic']
                    });
            });
        }

    </script>
</head>

<body id="bodyEmergente">
    <form id="frmMantenimiento" runat="server" style="padding: 0;">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <div id="ventanaEmergente" class="h-group" style="width: 100%">
            <table width="100%">
                <tr>
                    <td valign="middle">
                        <h1 class="text-subtitle"><span class="text-normal text-highlighted" />
                            <asp:Label ID="lblTitulo" runat="server" Text="" Width="100%" Height="100%"></asp:Label>
                        </h1>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <h1 class="text-subtitle"><span class="text-normal text-highlighted" />
                            <asp:Label ID="lblSubtitulo" runat="server" Width="100%" Height="100%" Text=""></asp:Label>
                        </h1>
                    </td>
                </tr>
            </table>
        </div>


        <div style="border: 1px solid #808080; padding: 5px">
            <asp:UpdatePanel ID="upComponente" runat="server">
                <ContentTemplate>
                    <fieldset>
                        <%-- <legend style="font-size: medium"><span style="font-size: small"><b>INFORMACION</b>
                    </span></legend>--%>
                        <asp:Panel ID="pFiltros" runat="server" Width="100%">
                        </asp:Panel>

                        <table width="100%" class="tabla">
                            <tr class="modo1">
                                <td style="width: 90%" align="right">
                                    <asp:Label ID="lblEstado" runat="server" Text="Estado" Style="font-weight: 700;"></asp:Label>
                                </td>
                                <td style="width: 10%" align="center">
                                    <asp:CheckBox ID="chkEstado" runat="server" Checked="True" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div style="border: 1px solid #808080; padding: 5px">
            <asp:UpdatePanel ID="uAdd" runat="server">
                <ContentTemplate>
                    <center>
                        <table width="100%" class="tabla">
                            <tr class="modo1">
                                <td style="width: 50%" align="center">
                                    <asp:ImageButton ID="imgGuardar" CausesValidation="true" runat="server"
                                        ImageUrl="~/Images/Guardar.gif" ToolTip="Guardar"
                                        OnClick="imgGuardar_Click" Height="20px" />
                                </td>
                                <td style="width: 50%" align="center">
                                    <asp:ImageButton ID="imgCerrar" runat="server" ImageUrl="~/Images/Cancelar.gif"
                                        ToolTip="Cancelar" OnClick="imgCerrar_Click" CausesValidation="False"
                                        Height="20px" />
                                </td>
                            </tr>

                            <tr>
                                <td colspan = "2" style="width:100%">
                                    <asp:Label ID="lblError" runat="server" Text="" Visible="false"></asp:Label>
                                </td>
                            </tr>

                        </table>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
