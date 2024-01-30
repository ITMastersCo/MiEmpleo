﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ITMasters.Master" AutoEventWireup="true" CodeBehind="PlanesEmpresa.aspx.cs" Inherits="co.itmasters.solucion.web.Empresa.PlanesEmpresa" %>
<%@ MasterType VirtualPath="../ITMasters.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">
    <h1 class="text-title text-semibold color-gray-800">Planes</h1>

    <div class="flex-center-v gap-16 p-16" >

        <asp:Button ID="btnPublcarOferta" runat="server" Text="PulicarGratis" CssClass="button"/>
        <p>*3 publicaciones disponibles</p>
        <asp:Label ID="Lbl1" runat="server" Text=""></asp:Label>
        <asp:Label ID="Lbl2" runat="server" Text=""></asp:Label>
        <asp:Label ID="lbl3" runat="server" Text=""></asp:Label>
        <asp:Label ID="lbl4" runat="server" Text=""></asp:Label>

    </div>

    <div class="flex-col gap-16 flex-center">

    <div class="bg-orange-400 rounded">
        <h2 class="text-title-section text-semibold 
            color-gray-800 p-16 text-center"
            >Optimiza el alcance de tus ofertas laborales 
            con alguno de nuestros paquetes
            <span class="text-title-section text-semibol 
                color-gray-100 text-underline"
                >Ver comparativo de paquetes
            </span>
        </h2>
    </div>
    <p>
        Los siguientes planes  incluyen Acceso a hojas de vida ilimitadas y  filtro de candidados, además de las demás caracteristicas descritas en cada uno:
    </p>
    <section runat="server" ID="contenedorPlanes" class="planes-wrapper">

    </section>
    </div>


</asp:Content>
