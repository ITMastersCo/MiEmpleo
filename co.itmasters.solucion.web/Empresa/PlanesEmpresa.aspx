<%@ Page Title="" Language="C#" MasterPageFile="~/ITMasters.Master" AutoEventWireup="true" CodeBehind="PlanesEmpresa.aspx.cs" Inherits="co.itmasters.solucion.web.Empresa.PlanesEmpresa"
    Async="true" %>

<%@ MasterType VirtualPath="../ITMasters.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">
    <script src="https://sdk.mercadopago.com/js/v2"></script>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <h1 class="text-title text-semibold color-gray-800">Planes</h1>

            <div class="flex-center-v gap-16 p-16">

                <asp:Button ID="btnPublcarOferta" runat="server" Text="PulicarGratis" CssClass="button" OnClick="btnPublcarOferta_Click" />
                <p>*3 publicaciones disponibles</p>


            </div>
            <div class="w-100per flex flex-center p-16 relative" runat="server" id="divComparativo" visible="false">
                <asp:Label Text="text" runat="server" CssClass="pointer absolute" AssociatedControlID="btnCerrarComparativo"  style="top:0; right:10%;" >
                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6">
                     <path stroke-linecap="round" stroke-linejoin="round" d="m9.75 9.75 4.5 4.5m0-4.5-4.5 4.5M21 12a9 9 0 1 1-18 0 9 9 0 0 1 18 0Z" />
                    </svg>
                </asp:Label>
                <asp:Button Text="" runat="server" ID="btnCerrarComparativo" CssClass="hidden" OnClick="btnCerrarComparativo_Click"/>
                <img src="..\Images\image-23.jpg" style="width: 60vw; margin-bottom:16px; pointer-events:none; margin:auto;" runat="server"  id="imgComparativo">
            </div>
            <div class="flex-col gap-16 flex-center">

                <div class="bg-orange-400 rounded">
                    <h2 class="text-title-section text-semibold 
                      color-gray-800 p-16 text-center">Optimiza el alcance de tus ofertas laborales 
                         con alguno de nuestros paquetes
                         <asp:Button runat="server" class="text-title-section text-semibold bg-color-400 color-white pointer text-underline hover" Text="Ver comparativo de paquetes" ID="btnComparativo" OnClick="btnComparativo_Click" style="text-decoration:underline;"/>
                    </h2>
                </div>
                <p>
                    Los siguientes planes  incluyen Acceso a hojas de vida ilimitadas y  filtro de candidados, además de las demás caracteristicas descritas en cada uno:
                </p>
                <section runat="server" id="contenedorPlanes" class="planes-wrapper">
                </section>
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>

    <style>
        .hover:hover{
            color:var(--gray-500);
        }
    </style>

</asp:Content>
