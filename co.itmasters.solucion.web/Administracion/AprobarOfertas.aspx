<%@ Page Title="Aprobar Ofertas" Language="C#" MasterPageFile="~/ITMasters.Master" AutoEventWireup="true" CodeBehind="AprobarOfertas.aspx.cs" Inherits="co.itmasters.solucion.web.Administracion.AprobarOfertas" %>

<%@ MasterType VirtualPath="../ITMasters.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">
    
    <style type="text/css">
        .modalDialog {
            position: fixed;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            background: rgba(153,153,153,0.8);
            z-index: 99999;
            display: none;
            -webkit-transition: opacity 100ms ease-in;
            -moz-transition: opacity 100ms ease-in;
            transition: opacity 100ms ease-in;
            pointer-events: auto;
            overflow-y:scroll;
        }

            .modalDialog > div {
                Width: 60%;
                height: max-content;
                position: relative;
                margin: 10% auto;
                padding: 10px 10px 10px 10px;
                border-radius: 10px;
                /*contorno de la ventana*/
                background: -o-linear-gradient(#fff, #fff);
                background: -moz-linear-gradient(#fff, #fff);
                background: -webkit-linear-gradient(#fff, #fff);
                background: -o-linear-gradient(#fff, #fff);
                -webkit-transition: opacity 100ms ease-in;
                -moz-transition: opacity 100ms ease-in;
                transition: opacity 100ms ease-in;
            }

      

            .closed:hover {
                background: #E73232;
            }

        .auto-style1 {
            color: #FFFFFF;
            font-size: large;
        }
    </style>
    <asp:ValidationSummary ID="ValidationSummary" runat="server" ValidationGroup="Nit" Font-Bold="True" ForeColor="#CC0000" CssClass="text-normal" />
    <asp:UpdatePanel runat="server" ID="Oferta" class="flex-col gap-32 flex-center">
        <ContentTemplate>
            <a id="home" runat="server" ></a>
            <h1 class="text-subtitle color-gray-800">Validación 
                <span class="text-subtitle color-orange-500 ">de Ofertas</span>
                por aprobar
            </h1>
            <section class="flex-col gap-32 align-self-center" id="Formulario" runat="server">
                <div class="flex gap-8">
                    <asp:Label ID="lblTituloVacante" runat="server" Text="Consulta por Nit:"  
                        AssociatedControlID="txtNit"
                        CssClass="text-title-section text-medium color-gray-700 flex gap-4 item-center  ">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="txtNit" ErrorMessage="Busque Ofertas  por nombre o NIT" ValidationGroup="Nit" ForeColor="#CC0000" CssClass="text">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtNit" runat="server" CssClass="text-box" 
                            placeholder="Busque Ofertas  por nombre o NIT">
                        </asp:TextBox>
                    </asp:Label>
                    <asp:Button ID="btnBuscar" Visible="true" runat="server" CssClass="button" Text="Buscar" OnClick="btnBuscar_Click" ValidationGroup="Nit" />
                </div>
                <asp:UpdatePanel runat="server" ID="UpdatePanel1" class="flex-col  w-100per ">
                    <ContentTemplate>
                        <div class="align-self-center">
                            <asp:GridView ID="GrdOferta" runat="server" CssClass=" gap-32 w-100per" RowStyle-CssClass="p-16" AutoGenerateColumns="false" OnRowCommand="GrdOferta_RowCommand">
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblidOferta" runat="server" Text='<%# Eval("idOferta") %>'></asp:Label>
                                            <asp:Label ID="lblnomOferta" runat="server" Text='<%# Eval("tituloVacante") %>'></asp:Label>
                                            <asp:Label ID="lblDescripcionVacante" runat="server" Text='<%# Eval("descripcionVacante") %>'></asp:Label>
                                            <asp:Label ID="lbltiempoExperiencia" runat="server" Text='<%# Eval("tiempoExperiencia") %>'></asp:Label>
                                            <asp:Label ID="lblnomEmpresa" runat="server" Text='<%# Eval("nomEmpresa") %>'></asp:Label>
                                            <asp:Label ID="lblRangoSalario" runat="server" Text='<%# Eval("RangoSalario") %>'></asp:Label>
                                            <asp:Label ID="lblNomCiudad" runat="server" Text='<%# Eval("nomCiudad") %>'></asp:Label>
                                            <asp:Label ID="lblcantidadVacantes" runat="server" Text='<%# Eval("cantidadVacantes") %>'></asp:Label>
                                            <asp:Label ID="lblcargo" runat="server" Text='<%# Eval("cargo") %>'></asp:Label>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="true">
                                        <ItemTemplate>
                                            <article class="cv-item_info p-r-5rem p-16">
                                                <header class="cv-item">
                                                    <div class="flex cv-item-title">
                                                        <i class="cv-icon" runat="server" id="itemIcon">
                                                            <%-- Icon Experience || Studies  --%>
                                                            <svg xmlns="http://www.w3.org/2000/svg" class="icon-24" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                                                <path stroke-linecap="round" stroke-linejoin="round" d="M21 13.255A23.931 23.931 0 0112 15c-3.183 0-6.22-.62-9-1.745M16 6V4a2 2 0 00-2-2h-4a2 2 0 00-2 2v2m4 6h.01M5 20h14a2 2 0 002-2V8a2 2 0 00-2-2H5a2 2 0 00-2 2v10a2 2 0 002 2z" />
                                                            </svg>
                                                        </i>
                                                        <h4 class="text-item color-gray-700 text-semibold" runat="server" id="itemTitle">
                                                            <%# Eval("tituloVacante") %>
                                                        </h4>
                                                    </div>
                                                </header>
                                                <div class="cv-item-info">
                                                    <p class='text-normal text-regular color-gray-600' runat="server" id="itemContent"><%# Eval("descripcionVacante") %></p>
                                                    <p class='text-normal text-regular color-gray-600' runat="server" id="itemDate"><%# String.Format("{0:yyyy-MM-dd}", Eval("fechaPublicacion")) %></p>
                                                    <p class='text-normal text-regular color-gray-600' runat="server" id="P1"><%# Eval("nomEmpresa") %></p>
                                                </div>
                                            </article>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="true">
                                        <ItemTemplate>

                                            <asp:ImageButton ID="imgVerOferta" runat="Server" Style="height: 25px; width: 25px;" CommandArgument="<% # Container.DataItemIndex %>" CommandName="VerDatos" ImageUrl="~/Images/ver.png" ToolTip="Detalles de la Oferta." />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </section>

            <div id="openModal" class="modalDialog" runat="server" style="display: none">
                <div>
                    <a href="#close" title="Cerrar sin grabar" class="closed" onclick="javascript:CloseModal2(); " >Cerrar</a>
                    <br />
                    <br />
                      <div style="display:none">
                        <asp:Label ID="LabelIdOferta" runat="server" ></asp:Label>
                        <asp:Label ID="nombreOferta" runat="server" ></asp:Label>
                    </div>

                    <div class="flex-col gap-16 p-16">
                        <asp:Label  runat="server" Text="" CssClass="text-item text-semibold text-gray-700 text-left">
                            <h3 class="text-semibold color-500 text-item"> Empresa: 
                                <span class="text-semibold color-gray-700" runat="server" id="empresa"  >

                                </span>
                            </h3>
                        </asp:Label>
                        <asp:Label  runat="server" Text="" CssClass="text-item text-semibold text-gray-700 text-left">
                            <h3 class="text-semibold color-500 text-item"> Oferta: 
                                <span class="text-semibold color-gray-700" runat="server" id="lblNomOferta2"  >

                                </span>
                            </h3>
                        </asp:Label>
                        <asp:Label  runat="server" TLabelTelRepLegalext="" CssClass="text-item text-semibold text-gray-700 text-left">
                             <h3 class="text-semibold color-500 text-item"> Descripción: 
                                <span class="text-semibold color-gray-700" runat="server" id="labelDescripcionVacante"  >

                                </span>
                            </h3>

                        </asp:Label>
                        <asp:Label runat="server" Text="" CssClass="text-item text-semibold text-gray-700 text-left">
                            <h3 class="text-semibold color-500 text-item"> Tiempo experiencia: 
                                <span class="text-semibold color-gray-700" runat="server" id="labeltiempoExperiencia"  >

                                </span>
                            </h3>
                        </asp:Label>
                        <asp:Label  runat="server" Text="" CssClass="text-item text-semibold text-gray-700 text-left">
                            <h3 class="text-semibold color-500 text-item"> Ciudad: 
                                <span class="text-semibold color-gray-700" runat="server" id="LabelNmonCiudad2"  >

                                </span>
                            </h3>
                        </asp:Label>
                        <asp:Label runat="server" Text="" CssClass="text-item text-semibold text-gray-700 text-left">
                            <h3 class="text-semibold color-500 text-item"> Rango Salario: 
                                <span class="text-semibold color-gray-700" runat="server" id="laberRango"  >

                                </span>
                            </h3>

                        </asp:Label>
                        <asp:Label  runat="server" Text="" CssClass="text-item text-semibold text-gray-700 text-left">
                              <h3 class="text-semibold color-500 text-item"> cargo: 
                                <span class="text-semibold color-gray-700" runat="server" id="cargo"  >

                                </span>
                            </h3>
                        </asp:Label>
                        <asp:Label runat="server" Text="" CssClass="text-item text-semibold text-gray-700 text-left">
                            <h3 class="text-semibold color-500 text-item"> Vacantes: 
                                <span class="text-semibold color-gray-700" runat="server" id="vacantes"  >

                                </span>
                            </h3>
                        </asp:Label>
                        
                        <div id="divObservacion" runat="server" style="display:none">
                            <asp:Label runat="server" id="lbleObservacion" CssClass="label-info">Observación:</asp:Label>
                            <asp:TextBox ID="txtObservacion" runat="server" CssClass="text-area" placeholder="Ingrese el motivo del rechazo de la Oferta." TextMode="MultiLine" Width="100%"></asp:TextBox>
                            <asp:Label runat="server" id="lblError" CssClass="label-info" ForeColor="Red"></asp:Label>
                        </div>
                      
                    </div>
                

                    <div class="flex-center flex-wrap gap-8 p-16">
                        <asp:Button ID="Nuevo" Visible="true" runat="server" CssClass="button bg-red-400" Text="Rechazar Oferta" OnClick="Volver_Click" />
                        <asp:Button ID="Panel" Visible="true" runat="server" CssClass="button" Text="Aprobar Oferta" OnClick="Aprobar_Click" />
                    </div>
                </div>
                <div id="variable" runat="server" style="display: none">
                    <asp:Label ID="lblIdOfertaDelete" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblEstadoOferta" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">

        function showModal() {
            document.getElementById('Main_openModal').style.display = 'flex';
        }
        function CloseModal2() {
            document.getElementById('Main_openModal').style.display = 'none';
        }

    </script>
</asp:Content>
