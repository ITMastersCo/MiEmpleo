﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControlCardPlan.ascx.cs" Inherits="co.itmasters.solucion.web.Components_UI.UserControlCardPlan" %>
     


<asp:UpdatePanel runat="server" ID="containerPlan" class="card card_plan flex-col flex-center-h gap-32">
        <ContentTemplate>  


    <div class="flex-col gap-8 flex-center-h">

        <h4 runat="server" id="namePlan" class="text-title-section text-semibold color-orange-500 text-center">Plan
            <%-- Nombre plan --%>
        </h4>
        <p runat="server" id="pricePlan" class="text-normal text-semibold">
            <%-- Precio del plan --%>
        </p>
    </div>

    <div runat="server" id="benefitsPlan" class="flex-col w-100per gap-8">
        <%-- Lista de beneficios --%>

        <div class="flex flex-center-v w-100per space-between">
            <p class="text-small plan-detailName">*Acceso ofertas destcadas ($50.000 c/u)</p>


            <div runat="server" id="a">
                <%-- Estado de Oferta Destacada --%>
            </div>
            
            <i runat="server" id="stateOfertaDestacad">

            </i>
            
        </div>
        <div class="flex flex-center-v w-100per space-between">
            <p class="text-small plan-detailName">* Ofertas confidenciales</p>


            <div runat="server" id="stateOfertasConfidenciales">
                <%-- Estado de Oferta Confidenciales --%>
            </div>
        </div>
        <div class="flex flex-center-v w-100per space-between">
            <p class="text-small plan-detailName">* Preguntas de filtro</p>


           <div runat="server" id="statePreguntaFiltro">
                <%-- Estado de Pregunstas Filtro--%>
            </div>
        </div>
        <div class="flex flex-center-v w-100per space-between">
            <p class="text-small plan-detailName">*Programación de entrevistas por zoom</p>


            <div runat="server" id="stateProgramacionZoom">
                <%-- Estado de Programación de entrevistas por zoom --%>
            </div>
        </div>
        <div class="flex flex-center-v w-100per space-between">
            <p class="text-small plan-detailName">* Multiusuarios con roles determinados por la empresa</p>


            <div runat="server" id="stateMultiUsuario">
                <%-- Estado de MultiUsuario --%>
            </div>
        </div>
        <div class="flex flex-center-v w-100per space-between">
            <p class="text-small plan-detailName">*Capacitaciones empresariales</p>


           <div runat="server" id="stateCapacitacion">
                <%-- Estado de Capacitaciona Empresas --%>
            </div>
        </div>
        <div class="flex flex-center-v w-100per space-between">
            <p class="text-small plan-detailName">*Tiempo de publicación</p>


            <p runat="server" id="stateTiempoPublicacion" class="text-small text-semibold color-gray-800">
                <%-- Estado de Tiempo de Publicacion --%>
            </p>
        </div>
        <div class="flex flex-center-v w-100per space-between">
            <p class="text-small plan-detailName">*Vigencia del plan a partir de la compra</p>

            <p runat="server" id="stateVigenciaPlan" class="text-nowrap text-small text-semibold color-gray-800">
                <%-- Estado de Detalle --%>
            </p>
            
        </div>
        

    </div>
    <asp:UpdatePanel runat="server" class="flex flex-center-h">
        <ContentTemplate>

            <asp:Button ID="btnGetPlan" runat="server" Text="" class="button" OnClick="btnGetPlan_ClickAsync"/>
            
        </ContentTemplate>
    </asp:UpdatePanel>
        <div runat="server" ID="wallet_container"></div>
         <asp:Button Text="" runat="server" ID="btnSubmitPay" CssClass="hidden" OnClick="btnSubmitPay_Click"/>
            <label runat="server" id="lblPreferenceID" class="hidden"></label>
 </ContentTemplate>

</asp:UpdatePanel>
    <script type="text/javascript">


        // Call the CreatePreference method and pass the reference ID

            
        window[`payMercadoPago_<%= this.ClientID%>`] = function (PreferenceId, walletContainer,publicKey) {
                // Pass the preference ID to the Mercado Pago button
            const mp = new MercadoPago(publicKey);
                const bricksBuilder = mp.bricks();
                
                const renderComponent = () => {
                    //if (windows.checkoutButton) window.checkoutButton.unmount();
                    bricksBuilder.create("wallet", walletContainer, {
                        initialization: {
                            preferenceId: PreferenceId,
                            redirectMode: "blank",
                        },
                        callbacks: {
                            onReady: () => {
                                const lblPreferenceID = document.getElementById('<%= this.lblPreferenceID.ClientID%>');
                                lblPreferenceID.innerText = PreferenceId;
                            },
                            onSubmit: () => { AddPlan(PreferenceId)},
                             onError: (error) => { console.error(error) }
                         }
                     });
                }
                renderComponent();
                
            };
        
        
        function AddPlan(preferenceId) {
            const btnSubmitPay = document.getElementById('<%= this.btnSubmitPay.ClientID%>');
            //btnSubmitPay.click();
        }


    </script>

 
