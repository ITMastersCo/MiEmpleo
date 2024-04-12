<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisorReportes.aspx.cs" Inherits="co.itmasters.solucion.web.Reportes.VisorReportes"
    MasterPageFile="~/ITMasters.master" %>

<%@ MasterType VirtualPath="~/ITMasters.master" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
     

    <div class="flex flex-center ">
        <table style="border-collapse: unset; border-spacing: 0;" class="flex flex-center w-100per border-solid border border-color-gray-500 rounded overflow-hidden max-w-850px ">
            <tbody style="width: 100%;">
                <tr class="bg-gray-500 flex-col gap-16 p-16 w-100per">
                    <th>
                        <asp:Label ID="lblTitulo" runat="server" CssClass="text-subtitle color-white " Text=""></asp:Label>
                    </th>

                    <td >
                        <asp:Label ID="lblSubtitulo" CssClass="text-sectiontext-center color-gray-100" runat="server" Text=" "></asp:Label>
                    </td>
                </tr>
                <tr class="flex-col p-16 gap-32">
                    <td id="ControlFechas" runat="server" class="flex p-16 flex-center gap-8 md:flex-col">
                        <div class="flex-col flex-center-v">
                            <div class="flex relative w-100per input-i-l  input-field">
                                <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                    <path stroke-linecap="round" stroke-linejoin="round" d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z" />
                                </svg>
                                <asp:TextBox ID="txtFecIni" runat="server" TextMode="Date" Visible="False"
                                    placeholder=" " oninput="hasContent(event)"></asp:TextBox>
                                <asp:Label ID="lblFecIni" runat="server" Text="Desde:"
                                    Visible="False" AssociatedControlID="txtFecIni"></asp:Label>
                            </div>
                        </div>
                        <div class="flex ">
                            <svg xmlns="http://www.w3.org/2000/svg" class="icon-24 color-gray-400 md:rotate-90deg " fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                <path stroke-linecap="round" stroke-linejoin="round" d="M17 8l4 4m0 0l-4 4m4-4H3" />
                            </svg>
                        </div>
                        <div class="flex-col flex-center-v">
                            <div class="flex relative w-100per input-i-l input-field">

                                <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                    <path stroke-linecap="round" stroke-linejoin="round" d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z" />
                                </svg>
                                <asp:TextBox ID="txtFecFin" runat="server" TextMode="Date" Visible="False"
                                    placeholder=" " oninput="hasContent(event)"></asp:TextBox>
                                <asp:Label ID="lblFecFin" runat="server" Text="Hasta:"
                                    Visible="False" AssociatedControlID="txtFecFin"></asp:Label>
                            </div>
                        </div>

                    </td>

                    <td>
                        <asp:UpdatePanel ID="upComponente" runat="server">
                            <ContentTemplate>
                                <fieldset class="flex-col gap-16 ">
                                    <div class="flex flex-center-v gap-4 border-solid border-0 border-b border-color-gray-600 ">
                                        <span class="text-semibold text-item color-gray-800">Filtros
                                        </span>
                                        <svg xmlns="http://www.w3.org/2000/svg" class="icon-24 color-gray-800" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                            <path stroke-linecap="round" stroke-linejoin="round" d="M12 6V4m0 2a2 2 0 100 4m0-4a2 2 0 110 4m-6 8a2 2 0 100-4m0 4a2 2 0 110-4m0 4v2m0-6V4m6 6v10m6-2a2 2 0 100-4m0 4a2 2 0 110-4m0 4v2m0-6V4" />
                                        </svg>
                                    </div>
                                    <asp:Panel ID="pFiltros" runat="server" CssClass="flex-col gap-8 w-100per">

                                    </asp:Panel>
                                </fieldset>
                                <input id="btnLimpiar" type="button" value="Limpiar" style="display: none;" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>

                    <td class="flex-col gap-16">
                        <div class="flex flex-center-v gap-4 border-solid border-0 border-b border-color-gray-600 ">
                            <span class="text-smibold text-item color-gray-800">Reportes
                            </span>
                            <svg xmlns="http://www.w3.org/2000/svg" class="icon-24  color-gray-800" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                <path stroke-linecap="round" stroke-linejoin="round" d="M9 17v-2m3 2v-4m3 4v-6m2 10H7a2 2 0 01-2-2V5a2 2 0 012-2h5.586a1 1 0 01.707.293l5.414 5.414a1 1 0 01.293.707V19a2 2 0 01-2 2z" />
                            </svg>
                        </div>

                        <asp:RadioButtonList ID="rblReportes" runat="server" CssClass="text-medium color-gray-500 flex">
                        </asp:RadioButtonList>
                    </td>

                    <td>
                        <div id="ControlEstado" runat="server">
                            <asp:Label ID="lblEstado" runat="server" Text="Estado" Style="font-size: small; font-weight: 700;"></asp:Label>
                            <asp:CheckBox ID="chkEstado" runat="server" Checked="True" />
                        </div>
                    </td>

                    <td class="flex flex-center gap-8">

                        <div>

                            <asp:Label Text="text" runat="server" AssociatedControlID="btnExportWord" ToolTip="Exportar a Word" CssClass="flex pointer">

                                <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 48 48" width="48px" height="48px">
                                    <linearGradient id="Q7XamDf1hnh~bz~vAO7C6a" x1="28" x2="28" y1="14.966" y2="6.45" gradientUnits="userSpaceOnUse">
                                        <stop offset="0" stop-color="#42a3f2" />
                                        <stop offset="1" stop-color="#42a4eb" />
                                    </linearGradient>
                                    <path fill="url(#Q7XamDf1hnh~bz~vAO7C6a)" d="M42,6H14c-1.105,0-2,0.895-2,2v7.003h32V8C44,6.895,43.105,6,42,6z" /><linearGradient id="Q7XamDf1hnh~bz~vAO7C6b" x1="28" x2="28" y1="42" y2="33.054" gradientUnits="userSpaceOnUse"><stop offset="0" stop-color="#11408a" /><stop offset="1" stop-color="#103f8f" /></linearGradient><path fill="url(#Q7XamDf1hnh~bz~vAO7C6b)" d="M12,33.054V40c0,1.105,0.895,2,2,2h28c1.105,0,2-0.895,2-2v-6.946H12z" /><linearGradient id="Q7XamDf1hnh~bz~vAO7C6c" x1="28" x2="28" y1="-15.46" y2="-15.521" gradientUnits="userSpaceOnUse"><stop offset="0" stop-color="#3079d6" /><stop offset="1" stop-color="#297cd2" /></linearGradient><path fill="url(#Q7XamDf1hnh~bz~vAO7C6c)" d="M12,15.003h32v9.002H12V15.003z" /><linearGradient id="Q7XamDf1hnh~bz~vAO7C6d" x1="12" x2="44" y1="28.53" y2="28.53" gradientUnits="userSpaceOnUse"><stop offset="0" stop-color="#1d59b3" /><stop offset="1" stop-color="#195bbc" /></linearGradient><path fill="url(#Q7XamDf1hnh~bz~vAO7C6d)" d="M12,24.005h32v9.05H12V24.005z" /><path d="M22.319,13H12v24h10.319C24.352,37,26,35.352,26,33.319V16.681C26,14.648,24.352,13,22.319,13z" opacity=".05" /><path d="M22.213,36H12V13.333h10.213c1.724,0,3.121,1.397,3.121,3.121v16.425 C25.333,34.603,23.936,36,22.213,36z" opacity=".07" /><path d="M22.106,35H12V13.667h10.106c1.414,0,2.56,1.146,2.56,2.56V32.44C24.667,33.854,23.52,35,22.106,35z" opacity=".09" /><linearGradient id="Q7XamDf1hnh~bz~vAO7C6e" x1="4.744" x2="23.494" y1="14.744" y2="33.493" gradientUnits="userSpaceOnUse"><stop offset="0" stop-color="#256ac2" /><stop offset="1" stop-color="#1247ad" /></linearGradient><path fill="url(#Q7XamDf1hnh~bz~vAO7C6e)" d="M22,34H6c-1.105,0-2-0.895-2-2V16c0-1.105,0.895-2,2-2h16c1.105,0,2,0.895,2,2v16 C24,33.105,23.105,34,22,34z" /><path fill="#fff" d="M18.403,19l-1.546,7.264L15.144,19h-2.187l-1.767,7.489L9.597,19H7.641l2.344,10h2.352l1.713-7.689 L15.764,29h2.251l2.344-10H18.403z" />
                                </svg>
                            </asp:Label>
                            <asp:Button ID="btnExportWord" Text="text" runat="server" CssClass="hidden" OnClick="btnExportWord_Click" ValidationGroup="Exportar"/>
                        </div>
                        <div>

                            <asp:Label Text="text" runat="server" AssociatedControlID="btnExportExcel" ToolTip="Exportar a Excel" CssClass="flex pointer">
                                <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 48 48" width="48px" height="48px">
                                    <rect width="16" height="9" x="28" y="15" fill="#21a366" />
                                    <path fill="#185c37" d="M44,24H12v16c0,1.105,0.895,2,2,2h28c1.105,0,2-0.895,2-2V24z" />
                                    <rect width="16" height="9" x="28" y="24" fill="#107c42" />
                                    <rect width="16" height="9" x="12" y="15" fill="#3fa071" />
                                    <path fill="#33c481" d="M42,6H28v9h16V8C44,6.895,43.105,6,42,6z" />
                                    <path fill="#21a366" d="M14,6h14v9H12V8C12,6.895,12.895,6,14,6z" />
                                    <path d="M22.319,13H12v24h10.319C24.352,37,26,35.352,26,33.319V16.681C26,14.648,24.352,13,22.319,13z" opacity=".05" />
                                    <path d="M22.213,36H12V13.333h10.213c1.724,0,3.121,1.397,3.121,3.121v16.425 C25.333,34.603,23.936,36,22.213,36z" opacity=".07" />
                                    <path d="M22.106,35H12V13.667h10.106c1.414,0,2.56,1.146,2.56,2.56V32.44C24.667,33.854,23.52,35,22.106,35z" opacity=".09" />
                                    <linearGradient id="flEJnwg7q~uKUdkX0KCyBa" x1="4.725" x2="23.055" y1="14.725" y2="33.055" gradientUnits="userSpaceOnUse">
                                        <stop offset="0" stop-color="#18884f" />
                                        <stop offset="1" stop-color="#0b6731" />
                                    </linearGradient><path fill="url(#flEJnwg7q~uKUdkX0KCyBa)" d="M22,34H6c-1.105,0-2-0.895-2-2V16c0-1.105,0.895-2,2-2h16c1.105,0,2,0.895,2,2v16 C24,33.105,23.105,34,22,34z" /><path fill="#fff" d="M9.807,19h2.386l1.936,3.754L16.175,19h2.229l-3.071,5l3.141,5h-2.351l-2.11-3.93L11.912,29H9.526 l3.193-5.018L9.807,19z" /></svg>
                            </asp:Label>
                            <asp:Button ID="btnExportExcel" Text="text" runat="server" CssClass="hidden" OnClick="btnExportExcel_Click" ValidationGroup="Exportar"/>

                        </div>
                        <div>

                            <asp:Label Text="text" runat="server" AssociatedControlID="btnExportPdf" ToolTip="Exportar archivo PDF" CssClass="flex pointer">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="42px" height="42px" viewBox="0 0 459 512" fill="none">
                                      <path d="M68 65C68 29.1015 97.1015 0 133 0H306L459 153V447C459 482.899 429.899 512 394 512H133C97.1015 512 68 482.899 68 447V65Z" fill="#E5252A"/>
                                      <path d="M306 0L459 153H322C313.163 153 306 145.837 306 137V0Z" fill="#B71D21"/>
                                      <path d="M0 216C0 207.716 6.71573 201 15 201H366C374.284 201 381 207.716 381 216V344C381 352.284 374.284 359 366 359H15C6.71572 359 0 352.284 0 344V216Z" fill="#B71D21"/>
                                      <path d="M67.5421 313C66.8352 313 66.2569 312.775 65.8071 312.325C65.3573 311.876 65.1324 311.297 65.1324 310.59V247.941C65.1324 247.234 65.3573 246.655 65.8071 246.206C66.2569 245.756 66.8352 245.531 67.5421 245.531H93.855C99.0598 245.531 103.558 246.334 107.349 247.941C111.204 249.547 114.192 251.989 116.313 255.266C118.497 258.479 119.59 262.495 119.59 267.314C119.59 272.197 118.497 276.245 116.313 279.458C114.192 282.607 111.204 284.952 107.349 286.494C103.558 288.036 99.0598 288.807 93.855 288.807H80.9395V310.59C80.9395 311.297 80.7146 311.876 80.2648 312.325C79.815 312.775 79.2367 313 78.5299 313H67.5421ZM80.6503 276.856H93.3731C96.6502 276.856 99.1883 276.053 100.987 274.446C102.851 272.84 103.783 270.43 103.783 267.217C103.783 264.39 102.947 262.077 101.277 260.278C99.6702 258.479 97.0357 257.579 93.3731 257.579H80.6503V276.856Z" fill="#ECECEC"/>
                                      <path d="M160.745 313C160.038 313 159.46 312.775 159.01 312.325C158.56 311.876 158.335 311.297 158.335 310.59V247.941C158.335 247.234 158.56 246.655 159.01 246.206C159.46 245.756 160.038 245.531 160.745 245.531H184.938C191.363 245.531 196.729 246.559 201.034 248.615C205.339 250.607 208.616 253.563 210.865 257.483C213.178 261.338 214.399 266.125 214.528 271.844C214.592 274.671 214.624 277.145 214.624 279.265C214.624 281.386 214.592 283.828 214.528 286.591C214.335 292.567 213.146 297.514 210.961 301.434C208.777 305.354 205.564 308.277 201.323 310.205C197.082 312.068 191.781 313 185.419 313H160.745ZM173.661 300.566H184.938C188.15 300.566 190.785 300.084 192.841 299.121C194.897 298.157 196.407 296.647 197.371 294.591C198.399 292.47 198.945 289.739 199.01 286.398C199.074 284.534 199.106 282.864 199.106 281.386C199.17 279.908 199.17 278.43 199.106 276.952C199.106 275.474 199.074 273.836 199.01 272.037C198.881 267.217 197.628 263.683 195.251 261.434C192.937 259.121 189.339 257.964 184.456 257.964H173.661V300.566Z" fill="#ECECEC"/>
                                      <path d="M257.995 313C257.289 313 256.71 312.775 256.261 312.325C255.811 311.876 255.586 311.297 255.586 310.59V247.941C255.586 247.234 255.811 246.655 256.261 246.206C256.71 245.756 257.289 245.531 257.995 245.531H300.983C301.69 245.531 302.268 245.756 302.718 246.206C303.168 246.655 303.393 247.234 303.393 247.941V256.133C303.393 256.84 303.168 257.418 302.718 257.868C302.268 258.318 301.69 258.543 300.983 258.543H270.622V274.832H299.055C299.762 274.832 300.34 275.057 300.79 275.506C301.24 275.956 301.465 276.535 301.465 277.241V285.434C301.465 286.077 301.24 286.623 300.79 287.073C300.34 287.522 299.762 287.747 299.055 287.747H270.622V310.59C270.622 311.297 270.397 311.876 269.947 312.325C269.497 312.775 268.919 313 268.212 313H257.995Z" fill="#ECECEC"/>
                                    </svg>
                            </asp:Label>
                            <asp:Button ID="btnExportPdf" Text="" runat="server" CssClass="hidden" OnClick="btnExportPdf_Click" ValidationGroup="Exportar"/>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>





    </div>

    <section id="wrapperUC" runat="server" class="flex-col gap-72">
    </section>
    <script type="text/javascript">
        function hasContent(event) {
            console.log(event.target.value)
            if (event.target.value) {
                event.target.classList.add('has-content');
            } else {
                event.target.classList.remove('has-content');
            }
        }
    </script>
</asp:Content>
