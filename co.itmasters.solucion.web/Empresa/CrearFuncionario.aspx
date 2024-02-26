﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ITMasters.Master" AutoEventWireup="true" CodeBehind="CrearFuncionario.aspx.cs" Inherits="co.itmasters.solucion.web.Empresa.CrearFuncionario" %>

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
                ControlToValidate="txtPassword" CssClass="required-field-validator text-item"
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
                <div runat="server"  class="flex flex-col">

                    <asp:DropDownList runat="server" ID="cmbRol" CssClass="drop-down-list" />
                    <asp:RangeValidator ErrorMessage="" ControlToValidate="cmbRol" runat="server" Type="Integer"
                         CssClass="required-field-validator" MinimumValue="1" MaximumValue="20" ValidationGroup="crearFuncionario" >
                        Seleccione un rol
                    </asp:RangeValidator>

                </div>
                <div runat="server" id="divClave" class="hidden flex flex-col gap-8">

                <div class="flex flex-col">
                    <asp:TextBox runat="server" ID="txtPassword" CssClass="text-box" TextMode="Password" placeholder="Contraseña"/>
                    <asp:RequiredFieldValidator runat="server" CssClass="required-field-validator" 
                        ErrorMessage="Ingrese una contraseña " ControlToValidate="txtPassword"  ValidationGroup="crearFuncionario"/>
                    
                </div>
                <div class="flex flex-col">
                    <asp:TextBox runat="server" ID="txtPassword2" CssClass="text-box" TextMode="Password" placeholder="Confirmar ontraseña"/>
                    <asp:RequiredFieldValidator runat="server" CssClass="required-field-validator" 
                        ErrorMessage="Ingrese una contraseña valida" ControlToValidate="txtPassword2" ValidationGroup="crearFuncionario" />
                </div>

                </div>
                <asp:Label ID="lblError" runat="server" Text="err" CssClass="text" Visible="false" ForeColor="Red"></asp:Label>
            </asp:Panel>
            <asp:Button Text="Siguiente" runat="server" ID="btnValidaCorreo" Visible="true"
                CssClass="button" ValidationGroup="validaFuncionario" OnClick="btnValidaCorreo_Click"/>
            <asp:Button Text="Crear Funcionario" runat="server" ID="btnCrearFuncionario" Visible="false"
                CssClass="button" ValidationGroup="crearFuncionario" OnClick="btnCrearFuncionario_Click"/>

            <asp:UpdatePanel ID="openModal" class="modal-dialog overflow-y-scroll" runat="server" MaintainScrollPositionOnPostback="true" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="flex-col flex-center">
                        <asp:Label ID="lblCloseModal" Text="" runat="server" AssociatedControlID="btnCloseModal">
                            <svg xmlns="http://www.w3.org/2000/svg" class="icon-24 pointer color-gray-700 closed" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                <path stroke-linecap="round" stroke-linejoin="round" d="M6 18L18 6M6 6l12 12" />
                            </svg>
                            <asp:Button ID="btnCloseModal" Text="" runat="server" CssClass="hidden" OnClick="btnCloseModal_Click" />
                        </asp:Label>
                        <asp:Panel runat="server" ID="modalCV" CssClass="modal-body flex flex-center max-w-850px">
                        </asp:Panel>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <div id="wrapperHidden" class="hidden">


                <div id="valida" runat="server" class="flex-col flex-center gap-16 hidden">
                    <p class="text-item text-semibold item-center">
                        ¡ESTIMADO(A) USUARIO(A)! 
                    </p>
                    <p class="text-medium text-semibold item-center">
                        Se ha enviado un token al correo registrado. Es importante destacar que este token tiene una validez de tan solo 10 minutos. En caso de que se solicite la generación de un nuevo token antes de que transcurra este período de tiempo, el token anterior será anulado automáticamente, y se generará uno nuevo para su uso.
                    </p>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtToken" ErrorMessage="" ValidationGroup="Token" ForeColor="#CC0000" CssClass="text">Digite el token enviado al correo registrado.</asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtToken" Width="280px" TextMode="Number" placeholder="Número de token" runat="server" CssClass="text-box"></asp:TextBox>

                    <asp:LinkButton ID="LnkValidar" runat="server" CssClass="button item-center" OnClick="lnkValidar_Click" ValidationGroup="Token"> Validar Token</asp:LinkButton>

                    <a href="../Home/RegisroEmpresa.aspx" id="volver" runat="server" class="text-small-14 text-600 text-highlighted text-underline
                       pointer">Volver a generar token
                    </a>

                </div>


            </div>

        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
