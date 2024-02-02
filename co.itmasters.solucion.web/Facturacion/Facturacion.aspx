<%@ Page Title="Facturacion" Language="C#" MasterPageFile="~/ITMasters.Master" AutoEventWireup="true" CodeBehind="Facturacion.aspx.cs" Inherits="co.itmasters.solucion.web.Facturacion.Facturacion" %>

<%@ MasterType VirtualPath="../ITMasters.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">


    <section class="flex-col gap-24">
        <h1 class="text-title text-semibold color-gray-800">Facturación
        </h1>




        <asp:UpdatePanel ID="UpdatePanelLashes" runat="server">
            <ContentTemplate>
                <asp:PlaceHolder ID="containerLashe" runat="server">
                    <div class="flex w-100per gap-8 flex-center wrapper-pestanas">

                        <span id="lashPaquetes" class="pestana" >
                            <h3 class="text-title-item text-semibold">Suscripción 
                            </h3>
                        </span>
                        <span id="lashFacturas" class="pestana" >
                            <h3 class="text-title-item text-semibold ">Tus Facturas
                            </h3>
                        </span>
                    </div>

                </asp:PlaceHolder>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="flex">

                    <section runat="server" id="containerPlans" class="flex-col flex-center w-100per gap-56" visible="true">

                    </section>

                    <section runat="server" id="containerFacturas" class="flex-col gap-16" vible="true">
                    </section>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </section>





</asp:Content>
