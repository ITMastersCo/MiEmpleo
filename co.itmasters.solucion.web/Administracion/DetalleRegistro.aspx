<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleRegistro.aspx.cs" Inherits="co.itmasters.solucion.web.Administracion.DetalleRegistro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="~/css/Styles.css" />
    <link rel="stylesheet" href="~/css/Empresa.css" />

    <%--<link href="../Estilos/jquery-ui-1.7.2.custom.css" rel="stylesheet" type="text/css" />--%>

    <script type="text/javascript" src="../Scripts/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-1.3.2-vsdoc.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.7.2.custom.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-Aplicacion.js"></script>
    <script type="text/javascript" src="../Scripts/MiEmpleo.js"></script>
    

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



        <div id="ventanaEmergente" class="flex flex-col  p-32 gap-16" >
            <div class="flex flex-col flex-center gap-4">
            <asp:Label ID="lblTitulo" CssClass="text-item color-gray-900 text-semibold" runat="server" Text="" ></asp:Label>
            <asp:Label ID="lblSubtitulo" CssClass="color-gray-600 text-semibold" runat="server" Text=""></asp:Label>
            </div>
            <asp:UpdatePanel ID="upComponente" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pFiltros" runat="server" Width="100%">

                    </asp:Panel>

                    <asp:Label ID="lblEstado" runat="server" Text="Estado" Style="font-weight: 700;"></asp:Label>
                    <asp:CheckBox ID="chkEstado" runat="server" Checked="True" />
                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:UpdatePanel ID="uAdd" runat="server">
                <ContentTemplate>
                    <div class="flex flex-center gap-8">

                    <asp:Label Text="Guardar" CssClass="button" runat="server" AssociatedControlID="btnGuardar" />
                    <asp:Button id="btnGuardar" Text="text" runat="server" OnClick="btnGuardar_Click" CssClass="hidden" CausesValidation="true" />
                 
                    <asp:Label Text="Cancelar" runat="server" class="button bg-red-400" AssociatedControlID="btnCerrar"/>
                    <asp:Button Text="" ID="btnCerrar" runat="server" CssClass="hidden" OnClick="btnCerrar_Click" CausesValidation="False"/>
                    </div>

                    <asp:Label ID="lblError" runat="server" Text="" Visible="false"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>


    </form>
</body>
</html>
