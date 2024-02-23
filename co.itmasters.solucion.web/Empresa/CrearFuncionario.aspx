<%@ Page Title="" Language="C#" MasterPageFile="~/ITMasters.Master" AutoEventWireup="true" CodeBehind="CrearFuncionario.aspx.cs" Inherits="co.itmasters.solucion.web.Empresa.CrearFuncionario" %>

<%@ MasterType VirtualPath="../ITMasters.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

    <asp:UpdatePanel runat="server" class="m-auto flex flex-col flex-center-v gap-56">
        <ContentTemplate>
            <%--Fitulo--%>
            <h1 class="text-subtitle text-semibold color-gray-800 text-center">Crear 
                <span class="text-subtitle text-semibold color-500">Funcionario</span> 
            </h1>

            <asp:RegularExpressionValidator
                ErrorMessage="La contraseña debe tener al entre 8 y 16 caracteres,al menos un dígito, al menos una minúscula y al menos una mayúscula."
                ControlToValidate="txtClave" CssClass="required-field-validator text-item"
                runat="server" ValidationExpression="^(?=\w*\d)(?=\w*[A-Z])(?=\w*[a-z])\S{8,16}$" ValidationGroup="crearFuncionario" />

            <%--Formulario--%>
            <asp:Panel runat="server" class="flex flex-col gap-8 m-auto" DefaultButton="btnCrearFuncionario">
                <div class="flex flex-col">
                    <asp:TextBox runat="server" ID="txtCorreo" CssClass="text-box" TextMode="Email" placeholder="Correo" />
                    <asp:RequiredFieldValidator runat="server" CssClass="required-field-validator" 
                        ErrorMessage="Ingrese un correo valido" ControlToValidate="txtCorreo" ValidationGroup="crearFuncionario" />
                </div>
                <div class="flex flex-col">
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="text-box"  placeholder="Nombre Completo"/>
                    <asp:RequiredFieldValidator runat="server" CssClass="required-field-validator" 
                        ErrorMessage="Ingrese un nombre" ControlToValidate="txtNombre" ValidationGroup="crearFuncionario"  />
                </div>
                <div class="flex flex-col">
                    <asp:DropDownList runat="server" ID="cmbRol" CssClass="drop-down-list" />
                    <asp:RangeValidator ErrorMessage="Seleccione un rol" ControlToValidate="cmbRol" runat="server"
                         CssClass="required-field-validator"/>
                </div>
                <div class="flex flex-col">
                    <asp:TextBox runat="server" ID="txtClave" CssClass="text-box" TextMode="Password" placeholder="Contraseña"/>
                    <asp:RequiredFieldValidator runat="server" CssClass="required-field-validator" 
                        ErrorMessage="Ingrese una contraseña " ControlToValidate="txtClave"  ValidationGroup="crearFuncionario"/>
                    
                </div>
                <div class="flex flex-col">
                    <asp:TextBox runat="server" ID="txtConfirmaClave" CssClass="text-box" TextMode="Password" placeholder="Confirmar ontraseña"/>
                    <asp:RequiredFieldValidator runat="server" CssClass="required-field-validator" 
                        ErrorMessage="Ingrese una contraseña valida" ControlToValidate="txtConfirmaClave" ValidationGroup="crearFuncionario" />
                </div>
                
            </asp:Panel>

            <asp:Button Text="Crear Funcionario" runat="server" ID="btnCrearFuncionario" CssClass="button" ValidationGroup="crearFuncionario"/>

        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
