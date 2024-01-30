<%@ Page Title="" Language="C#" MasterPageFile="~/ITMasters.Master" 
    AutoEventWireup="true" CodeBehind="Pagar.aspx.cs" Inherits="co.itmasters.solucion.web.Pagos.Pagar" 
    Async="true"%>
<%@ MasterType VirtualPath="../ITMasters.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">
    

<%-- SDK MercadoPago.js--%>
<script type="text/javascript" src="https://sdk.mercadopago.com/js/v2"></script>

     <div id="wallet_container"></div>
    <div id="button-checkout" ></div>

    <%--<script type="text/javascript" >

        const mp = new MercadoPago('APP_USR-d97cfe7f-43dd-4dd6-8966-900082c8bd905', {
            locale: 'es-CO'
        });
        const bricksBuilder = mp.bricks();



        mp.bricks().create("wallet", "wallet_container", {
              initialization: {
                preferenceId: "1234",
              },
              customization: {
                  texts: {
                      valueProp: 'smart_option',
                  },
              },
            });

    </script>--%>
</asp:Content>
