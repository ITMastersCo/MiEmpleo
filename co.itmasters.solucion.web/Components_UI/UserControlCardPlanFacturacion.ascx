<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControlCardPlanFacturacion.ascx.cs" Inherits="co.itmasters.solucion.web.Components_UI.UserControlCardPlanFacturacion" %>
<article runat="server" id="containerPlan" class=" flex gap-72 flex-center-h flex-wrap">
    <div class="flex-col p-16 gap-32">

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

            <div class="flex flex-center-v w-100per flex-row-reverse justify-end">
                <p class="text-small plan-detailName">*Acceso ofertas destcadas ($50.000 c/u)</p>


                <div runat="server" id="a">
                    <%-- Estado de Oferta Destacada --%>
                </div>

                <i runat="server" id="stateOfertaDestacad"></i>

            </div>
            <div class="flex flex-center-v w-100per flex-row-reverse justify-end">
                <p class="text-small plan-detailName">* Ofertas confidenciales</p>


                <div runat="server" id="stateOfertasConfidenciales">
                    <%-- Estado de Oferta Confidenciales --%>
                </div>
            </div>
            <div class="flex flex-center-v w-100per flex-row-reverse justify-end">
                <p class="text-small plan-detailName">* Preguntas de filtro</p>


                <div runat="server" id="statePreguntaFiltro">
                    <%-- Estado de Pregunstas Filtro--%>
                </div>
            </div>
            <div class="flex flex-center-v w-100per flex-row-reverse justify-end">
                <p class="text-small plan-detailName">*Programación de entrevistas por zoom</p>


                <div runat="server" id="stateProgramacionZoom">
                    <%-- Estado de Programación de entrevistas por zoom --%>
                </div>
            </div>
            <div class="flex flex-center-v w-100per flex-row-reverse justify-end">
                <p class="text-small plan-detailName">* Multiusuarios con roles determinados por la empresa</p>


                <div runat="server" id="stateMultiUsuario">
                    <%-- Estado de MultiUsuario --%>
                </div>
            </div>
            <div class="flex flex-center-v w-100per flex-row-reverse justify-end">
                <p class="text-small plan-detailName">*Capacitaciones empresariales</p>


                <div runat="server" id="stateCapacitacion">
                    <%-- Estado de Capacitaciona Empresas --%>
                </div>
            </div>
            <div class="flex flex-center-v w-100per ext-small text-semibold color-gray-800 gap-4">
                <p class="text-small plan-detailName">*Tiempo de publicación</p>

                (<p runat="server" id="stateTiempoPublicacion" class="text-small text-semibold color-gray-800">
                    <%-- Estado de Tiempo de Publicacion --%>
                </p>
                )
            </div>
            <div class="flex flex-center-v w-100per ext-small text-semibold color-gray-800 gap-4">
                <p class="text-small plan-detailName">*Vigencia del plan a partir de la compra</p>

                (<p runat="server" id="stateVigenciaPlan" class="text-small text-semibold color-gray-800">
                    <%-- Estado de Detalle --%>
                </p>
                )

            </div>


        </div>
        <asp:Button ID="btnGetPlan" runat="server" Text="" class="button self-start-y" OnClick="btnGetPlan_Click" />
    </div>
    <article class="card card_plan">
        <h4 class="text-title-item text-semibold color-gray-700">Próxima factura</h4>
        <h5 class="text-title-item text-semibold color-gray-600">Resumen</h5>
        <div runat="server" id="detailsFact" class="details_fact">
                                                          
        </div>
        <p runat="server" id="priceFac" class="text-title-item">

        </p>

    </article>



</article>
