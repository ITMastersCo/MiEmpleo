<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GrdCardOffer.ascx.cs" Inherits="co.itmasters.solucion.web.Components_UI.WebUserControl1" %>
<asp:GridView ID="grdOfertasDestacadas" runat="server" AutoGenerateColumns="false"
                            OnRowCommand="grdOfertasDestacadas_RowCommand" >
                            <columns>
                                <asp:TemplateField Visible="false">
                                    <itemtemplate>
                                        <asp:Label ID="idOferta" runat="server" Text='<%# Eval("idOferta") %>'></asp:Label>

                                    </itemtemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <itemtemplate>
                                        <asp:Label runat="server" class="card_offer space-between pointer" AssociatedControlID="btnViewOffer">
                                            <div class="flex-center-v gap-4">
                                            <div class="flex-col ">
                                                <div class="line">
                                                </div>
                                                <div class="avatar-rectangle">
                                                    <img src="Images/ImgInicio/AvatarEmpresa.jpg" alt="Alternate Text" />

                                                </div>
                                            </div>

                                            <div class="flex-col gap-8">
                                                <div class="flex-center-v gap-16 max-w-300">
                                                    <h4 runat="server" id="offerTitle" class="text-item color-gray-800 text-semibold truncate">
                                                        <%#  Eval("tituloVacante")%>
                                                    </h4>
                                                    <%-- <span class="flex-center-v gap-4">

                                            <svg class="icon-16 color-gray-700" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                                <path stroke-linecap="round" stroke-linejoin="round" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
                                                <path stroke-linecap="round" stroke-linejoin="round" d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z" />
                                            </svg>


                                            <span runat="server" id="offerViews" class="text-small text-medium color-gray-700">2

                                            </span>
                                        </span>--%>
                                                </div>
                                                <div class="flex-center-v gap-16">
                                                    <span class="flex-center-v gap-4">
                                                        <svg xmlns="http://www.w3.org/2000/svg" class="icon-16 color-gray-700" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                                            <path stroke-linecap="round" stroke-linejoin="round" d="M19 21V5a2 2 0 00-2-2H7a2 2 0 00-2 2v16m14 0h2m-2 0h-5m-9 0H3m2 0h5M9 7h1m-1 4h1m4-4h1m-1 4h1m-5 10v-5a1 1 0 011-1h2a1 1 0 011 1v5m-4 0h4" />
                                                        </svg>

                                                        <asp:Label ToolTip='<%# Eval("nomEmpresa") %>' runat="server" ID="offerUserWhoPublished" 
                                                            class="text-small text-regular color-gray-700 truncate max-w-148px">
                                                    <%# Eval("nomEmpresa") %>
                                                        </asp:Label>
                                                    </span>
                                                    <p runat="server" id="offerDate" class="text-small  text-regular color-gray-500">
                                                        <%# String.Format("{0:yyyy-MM-dd}", Eval("fechaPublicacion")) %>
                                                    </p>
                                                </div>
                                                <div class=" flex-center-v gap-16">



                                                    <span class="flex-center-v gap-4">
                                                        <svg class="icon-16 color-green-500" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor">
                                                            <path stroke-linecap="round" stroke-linejoin="round" d="M2.25 18.75a60.07 60.07 0 0115.797 2.101c.727.198 1.453-.342 1.453-1.096V18.75M3.75 4.5v.75A.75.75 0 013 6h-.75m0 0v-.375c0-.621.504-1.125 1.125-1.125H20.25M2.25 6v9m18-10.5v.75c0 .414.336.75.75.75h.75m-1.5-1.5h.375c.621 0 1.125.504 1.125 1.125v9.75c0 .621-.504 1.125-1.125 1.125h-.375m1.5-1.5H21a.75.75 0 00-.75.75v.75m0 0H3.75m0 0h-.375a1.125 1.125 0 01-1.125-1.125V15m1.5 1.5v-.75A.75.75 0 003 15h-.75M15 10.5a3 3 0 11-6 0 3 3 0 016 0zm3 0h.008v.008H18V10.5zm-12 0h.008v.008H6V10.5z" />
                                                        </svg>

                                                        <span runat="server" id="offerSalaryRange" class="text-small text-medium color-green-500">
                                                            <%# Eval("RangoSalario")%>
                                                        </span>
                                                    </span>
                                                    <span class="flex-center-v gap-4">
                                                        <svg class="icon-16 color-gray-500" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor">
                                                            <path stroke-linecap="round" stroke-linejoin="round" d="M15 10.5a3 3 0 11-6 0 3 3 0 016 0z" />
                                                            <path stroke-linecap="round" stroke-linejoin="round" d="M19.5 10.5c0 7.142-7.5 11.25-7.5 11.25S4.5 17.642 4.5 10.5a7.5 7.5 0 1115 0z" />
                                                        </svg>

                                                        <span runat="server" id="offerLocation" class="text-small text-regular color-gray-500">
                                                            <%# Eval("nomCiudad")%>
                                                        </span>
                                                    </span>

                                                </div>
                                            </div>
                                        <asp:Button Text="" runat="server" ID="btnViewOffer" 
                                            CommandArgument="<%# Container.DataItemIndex %>" CommandName="GET" ToolTip="Ver" OnCommand="btnViewOffer_Command"  />
                                            </div>



                                            <div class=" flex-col gap-32">

                                                <div class="flex-center-v gap-4">

                                                    <asp:Label ID="lblOfferEdit" runat="server" Text="" AssociatedControlID="btnOfferEdit">
                                                        <asp:Button ID="btnOfferEdit" runat="server" Text="Button" Visible="false" />
                                                        <svg class="icon-24 pointer color-white" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                                            <path stroke-linecap="round" stroke-linejoin="round" d="M15.232 5.232l3.536 3.536m-2.036-5.036a2.5 2.5 0 113.536 3.536L6.5 21.036H3v-3.572L16.732 3.732z" />
                                                        </svg>
                                                    </asp:Label>

                                                </div>

                                                <div class="flex-center-v gap-4 justify-end">

                                                    <svg class="icon-16 color-gray-700" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                                        <path stroke-linecap="round" stroke-linejoin="round" d="M12 4.354a4 4 0 110 5.292M15 21H3v-1a6 6 0 0112 0v1zm0 0h6v-1a6 6 0 00-9-5.197M13 7a4 4 0 11-8 0 4 4 0 018 0z" />
                                                    </svg>

                                                    <span runat="server" id="offerAppications" class="text-normal text-medium color-gray-700">
                                                        <%# Eval("cantidadVacantes") %>
                                                    </span>

                                                </div>

                                            </div>

                                        </asp:Label>
                                    </itemtemplate>
                                </asp:TemplateField>
                            </columns>
                        </asp:GridView>