<%@ Page Title="ITMasters - Inicio" Language="C#" MasterPageFile="~/ITMasters.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="co.itmasters.solucion.web._Default" %>

<%@ MasterType VirtualPath="~/ITMasters.master" %>

<asp:Content ID="DefaultMain" ContentPlaceHolderID="Main" runat="Server">

    <div class="flex-col flex-center-h">

        <section class="flex-col flex-center-h">

            <asp:UpdatePanel ID="wraShare" runat="server">
                <ContentTemplate>
                    
                    <div class="flex-col flex-center-h w-100per">
                        <asp:UpdatePanel runat="server" class=" flex-col gap-40 w-100per">
                            <ContentTemplate>
                                <h1 id="titleDisplay" class="text-subtitle text-center max-w-850px">¡Busca ahora la <span class="text-subtitle color-500">oferta de empleo </span>que se adapte a tu perfil!
                                </h1>

                                <div>

                                    <div id="buscardor" class="flex-col p-16 flex-center-v bg-color-100 gap-16 rounded max-w-850px">
                                        <div class="flex flex-center-v  gap-8 md-800:flex-col">

                                            <div class="w-100per flex-col flex-center-v">

                                                <div class="flex relative w-100per input-i-l text-box">
                                                    <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                                        <path stroke-linecap="round" stroke-linejoin="round" d="M21 13.255A23.931 23.931 0 0112 15c-3.183 0-6.22-.62-9-1.745M16 6V4a2 2 0 00-2-2h-4a2 2 0 00-2 2v2m4 6h.01M5 20h14a2 2 0 002-2V8a2 2 0 00-2-2H5a2 2 0 00-2 2v10a2 2 0 002 2z" />
                                                    </svg>
                                                    <asp:TextBox runat="server" ID="txtBuscarCargo" CssClass="truncate"
                                                        placeholder="Cargo u Ocupación" oninput="validateShare(event)" />
                                                </div>

                                                <asp:TextBox ID="txtSearch" runat="server" CssClass="hidden" />

                                            </div>

                                            <div class="w-100per flex-col flex-center-v">
                                                <div class="flex-col w-100per">

                                                    <div class="flex relative w-100per input-i-l text-box">
                                                        <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                                            <path stroke-linecap="round" stroke-linejoin="round" d="M17.657 16.657L13.414 20.9a1.998 1.998 0 01-2.827 0l-4.244-4.243a8 8 0 1111.314 0z" />
                                                            <path stroke-linecap="round" stroke-linejoin="round" d="M15 11a3 3 0 11-6 0 3 3 0 016 0z" />
                                                        </svg>
                                                        <asp:TextBox runat="server" ID="txtCiudadBuscar" class="truncate" autocomplete="off"
                                                            oninput="validatAndShowAutoComplete(event)" placeholder="Ciudad" ValidationGroup="search">
                                                        </asp:TextBox>
                                                        <asp:TextBox ID="txtIdCiudadBuscar" Text="" runat="server" CssClass="hidden" />

                                                        <select size="4" id="selAutocompletado" runat="server" style="display: none" class="list-autofill"
                                                            onchange="seleccionarCiudad(event)" onmouseleave="ocultarAutocomplete(event)">
                                                        </select>
                                                    </div>
                                                </div>
                                            </div>

                                            <asp:Label Text="Buscar" runat="server" ID="lblBuscarOferta" CssClass="button"
                                                AssociatedControlID="btnBuscarOferta"
                                                OnClientClick="showSearcher(event)" />

                                            <asp:Button Text="Buscar" runat="server" ID="btnBuscarOferta" CssClass="hidden"
                                                OnClick="btnBuscarOferta_Click" ValidationGroup="search" />
                                        </div>
                                        <asp:RequiredFieldValidator ErrorMessage="Agrega una Ciudad un cargo u ocupacion"
                                            ControlToValidate="txtSearch" CssClass="required-field-validator" runat="server" ValidationGroup="search" />
                                    </div>

                                    <div runat="server" id="containerOfertas" class="flex flex-center bg-gray-100 overflow-y-scroll rounded relative" 
                                        style="height:70vh;" visible="false">
                                        <div class="absolute" style="top :0;" >
                                            <asp:GridView ID="grdOfertasDestacadas" runat="server" AutoGenerateColumns="false" class="flex-col gap-4 " >
                                                <Columns>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="idOferta" runat="server" Text='<%# Eval("idOferta") %>'></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" class="card_offer space-between pointer" 
                                                                AssociatedControlID="btnViewOffer" style="border:none; margin-bottom:8px;">
                                                                <div class="flex-center-v gap-4">
                                                                    <div class="flex-col ">
                                                                        <div class="line">
                                                                        </div>
                                                                        <div class="avatar-rectangle">

                                                                            <img src=".<%# Eval("rutaAvatar") %>"" alt="Alternate Text" />
                                                                        </div>
                                                                    </div>

                                                                    <div class="flex-col gap-8">
                                                                        <div class="flex-center-v gap-16 max-w-300">
                                                                            <h4 runat="server" id="offerTitle" class="text-item color-gray-800 text-semibold truncate">
                                                                                <%#  Eval("tituloVacante")%>
                                                                            </h4>
                                                                            <%-- <span class="flex-center-v gap-4">

                                            <svg class="icon-16 color-gray-700" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                                <pah stroke-linecap="round" stroke-linejoin="round" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
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
                                                                        CommandArgument="<%# Container.DataItemIndex %>" CommandName="GET" ToolTip="Ver" OnCommand="btnViewOffer_Command" />
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
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                    

                                      
                                        </div>
                                            <div runat="server" ID="noResultsShare" class="p-32" visible="false" >
                                                <h3 class="text-center text-item text-regular color-gray-500 p-32">*No se encontraron ofertas ralcionadas a la busqueda.
                                                </h3>
                                            </div>
                                    </div>
                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div id="wrapperHidden" class="hidden">
                        <article runat="server" id="detalleOferta" class="flex-col gap-8 hidden">
                            <div class ="hidden">
                                <asp:Label Text="" ID="lblIdOferta" runat="server" />
                                <asp:Label Text="" ID="lblIdPersona" runat="server" />
                            </div>

                            <div runat="server" class="flex-center-v gap-4 pointer">
                                <div class="flex-col ">
                                    <div class="line">
                                    </div>
                                    <div class="avatar-rectangle-80">
                                        <img runat="server" id="imgRutaAvatar" src="." alt="Alternate Text" />

                                    </div>
                                </div>

                                <div class="flex-col gap-8">
                                    <div class="flex-center-v gap-16">
                                        <asp:Label runat="server" ID="lblOfferTitle" class="text-item color-gray-800 text-semibold">

                                        </asp:Label>
                                    </div>
                                    <div class="flex-center-v gap-16">
                                        <span class="flex-center-v gap-4">
                                            <svg xmlns="http://www.w3.org/2000/svg" class="icon-16 color-gray-700" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                                                <path stroke-linecap="round" stroke-linejoin="round" d="M19 21V5a2 2 0 00-2-2H7a2 2 0 00-2 2v16m14 0h2m-2 0h-5m-9 0H3m2 0h5M9 7h1m-1 4h1m4-4h1m-1 4h1m-5 10v-5a1 1 0 011-1h2a1 1 0 011 1v5m-4 0h4" />
                                            </svg>

                                            <asp:Label runat="server" ID="lblOfferUserWhoPublished" class="text-normal text-regular color-gray-700">
                                                    
                                            </asp:Label>
                                        </span>
                                    </div>
                                    <div class=" flex-center-v gap-16">



                                        <span class="flex-center-v gap-4">
                                            <svg class="icon-16 color-green-500" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor">
                                                <path stroke-linecap="round" stroke-linejoin="round" d="M2.25 18.75a60.07 60.07 0 0115.797 2.101c.727.198 1.453-.342 1.453-1.096V18.75M3.75 4.5v.75A.75.75 0 013 6h-.75m0 0v-.375c0-.621.504-1.125 1.125-1.125H20.25M2.25 6v9m18-10.5v.75c0 .414.336.75.75.75h.75m-1.5-1.5h.375c.621 0 1.125.504 1.125 1.125v9.75c0 .621-.504 1.125-1.125 1.125h-.375m1.5-1.5H21a.75.75 0 00-.75.75v.75m0 0H3.75m0 0h-.375a1.125 1.125 0 01-1.125-1.125V15m1.5 1.5v-.75A.75.75 0 003 15h-.75M15 10.5a3 3 0 11-6 0 3 3 0 016 0zm3 0h.008v.008H18V10.5zm-12 0h.008v.008H6V10.5z" />
                                            </svg>

                                            <asp:Label runat="server" ID="lblOfferSalaryRange" class="text-normal text-medium color-green-500">
                                                            
                                            </asp:Label>
                                        </span>
                                        <span class="flex-center-v gap-4">
                                            <svg class="icon-16 color-gray-500" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor">
                                                <path stroke-linecap="round" stroke-linejoin="round" d="M15 10.5a3 3 0 11-6 0 3 3 0 016 0z" />
                                                <path stroke-linecap="round" stroke-linejoin="round" d="M19.5 10.5c0 7.142-7.5 11.25-7.5 11.25S4.5 17.642 4.5 10.5a7.5 7.5 0 1115 0z" />
                                            </svg>

                                            <asp:Label runat="server" ID="lblOfferLocation" class="text-normal text-regular color-gray-500">
                                                            
                                            </asp:Label>
                                        </span>

                                    </div>
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
                                </div>

                                <asp:Button Text="Postular a Oferta" ID="btnPostularOferta" CssClass="button" runat="server" OnClick="btnPostularOferta_Click" />

                            </div>
                            <div class="flex space-between">
                                <h4 class="color-gray-600 text-regular">Fecha de Creación:
                                    <asp:Label ID="lblDateCrateOffer" Text="" runat="server" />
                                </h4>
                                <h4 class="color-gray-600 text-regular">Fecha de Vencimiento:
                                    <asp:Label ID="lblDateRemoveOffer" Text="" runat="server" />
                                </h4>
                            </div>
                            <div>
                                <asp:Label Text="" runat="server" ID="lblDescriptioOffer" />
                            </div>
                        </article>

                    </div>

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

                                <%--<div class="flex-center flex-wrap gap-16">
                        <asp:Button ID="btnModalCacel" Visible="false" runat="server" CssClass="button bg-red-500" Text="Cancelar" OnClick="btnModalCancel_Click" />
                        <asp:Button ID="btnModalSubmmit" Visible="false" runat="server" CssClass="button " Text="Actualizar" ValidationGroup="formDatosBasicos" OnClick="btnModalSubmmit_Click" />
                        <asp:Button ID="btnModalEstudiosSubmit" Visible="false" runat="server" CssClass="button" Text="Actualizar" ValidationGroup="formEstudio" OnClick="btnModalEstudiosSubmit_Click" />
                        <asp:Button ID="btnModalExperienciaSubmit" Visible="false" runat="server" CssClass="button" Text="Actualizar" ValidationGroup="formExperiencia" OnClick="btnModalExperienciaSubmit_Click" />
                        <asp:Button ID="btnModalEliminarEstudio" Text="Si, eliminar" runat="server" CssClass="button" Visible = "false" OnClick="btnModalEliminarEstudio_Click"/>
                        <asp:Button ID="btnModalEliminarExperiencia" Text="Si, eliminar" runat="server" CssClass="button" Visible = "false" OnClick="btnModalEliminarExperiencia_Click"/>
                    </div>--%>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </section>
     

        <section class="flex-col gap-16 ">
            <h2 class="text-subtitle color-gray-800 max-w-850px">Avance de <span class="text-subtitle color-500">Mi perfil</span>
            </h2>

            <a href="../Personal/HojadeVida.aspx" id="loaderContainer" runat="server" class="loader-container pointer">

                <div class="loader">
                    <div class="progress" id="progress">

                        <div class="circle text-normal text-semibold" id="circle">0%</div>
                    </div>
                </div>
            </a>
        </section>
    </div>
        <script type="text/javascript">
           
            
            PageMethods.GetCiudades(on, onError);

            let listCityes;
            function on(result) { listCityes = result }


            function showAutocompleteCitys(event) {
                const listAutocomplete = listCityes

                showAutocomplete(event , listAutocomplete)


            }

            function showAutocomplete(event, listAutocomplete) {
                let resultFiltered = listAutocomplete.filter(e => e.Nombre.toLowerCase().includes(event.target.value.toLowerCase()))

                let resultSorted = resultFiltered.sort((a, b) => {
                    const charPositionA = a.Nombre.indexOf(event.target.value.toUpperCase());
                    const charPositionB = b.Nombre.indexOf(event.target.value.toUpperCase());

                    if (charPositionB === -1) {
                        return -1;
                    }

                    if (charPositionA === -1) {
                        return 1;
                    }

                    return charPositionA < charPositionB ? -1 : (charPositionA > charPositionB ? 1 : 0);
                });

                onSuccess(resultSorted,event)
            }
            
            
            
            function onSuccess(result, event) {
                const parent = event.target.parentNode
                const select = parent.querySelector("select")
                 
                select.innerHTML = '';

                // Iterar sobre la lista filtrada y mostrar los resultados

                for (let i = 0; i < result.length; i++) {
                    let option = document.createElement('option');
                    option.text = result[i].Nombre;
                    option.value = result[i].Id;
                    select.add(option);
                }

                // Mostrar la lista de autocompletado
                select.style.display = 'block';
            }

            function onError(result) {
                console.log(result);
            }

            function seleccionarCiudad(event) {
                const parent = event.target.parentNode
                const select = parent.querySelector("select")
                const inputSearch = (Array.from(parent.children).filter(e => e.localName === "input")[0]);
                const txtIdSearch = (Array.from(parent.children).filter(e => e.localName === "input")[1]);
                let selectedText = select.options[select.selectedIndex].text;
                let selectedValue = select.options[select.selectedIndex].value;
                inputSearch.value = selectedText;
                txtIdSearch.value = selectedValue;

                // Ocultar la lista de autocompletado después de seleccionar un elemento

                select.style.display = 'none';
            }
            function ocultarAutocomplete(event) {
                const parent = event.target.parentNode
                const select = parent.querySelector("select")
                select.style.display = 'none';
            }
            function validatAndShowAutoComplete(event) {
                validateShare(event)
                showAutocompleteCitys(event)
            }
            function validateShare(event) {
                const txtValidate = document.getElementById('<%= txtSearch.ClientID %>')
                const txtCargo = document.getElementById('<%= txtBuscarCargo.ClientID %>')
                const txtCiudad = document.getElementById('<%= txtCiudadBuscar.ClientID %>')
                console.log(txtValidate)

                txtValidate.value = txtCargo.value + txtCiudad.value
            }
            function showSearcher(event) {
                const title = document.getElementById('titleDisplay')
                title.remove()
                const wrapper = document.getElementById('Main_wraShare')
                const share = document.getElementById('buscador')

                wrapper.style.width = "100%"
                share.classList.remove("max-w-860px")
                share.classList.add("w-100-per")

            }

            document.addEventListener("DOMContentLoaded", function () {
                let progress = document.getElementById("progress");
                let circle = document.getElementById("circle");

                let width = 0;
                let percent = 0;
                let num = <%# GetPorcentaje()%>;
                 function updateProgress() {
                     if (width < num) {
                         width += 1;
                         percent = Math.round(width) + "%";
                         progress.style.width = percent;
                         circle.textContent = percent;
                         requestAnimationFrame(updateProgress);
                     }
                 }

                 updateProgress();
            });


        </script>


</asp:Content>
