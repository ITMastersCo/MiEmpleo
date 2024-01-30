<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControlCardOfferTech.ascx.cs" Inherits="co.itmasters.solucion.web.Components_UI.UserControlCardOfferTech" %>

<article class="card_offer flex-center-v">
    <div class="flex-col">
    <div class="flex-center-v gap-16">
        <h4 runat="server" id="offerTitle" class="text-item color-gray-800 text-semibold">

           Diseñador UX
            <%-- Title of  offer--%>
        </h4>
        <span class="flex-center-v gap-4">

            <svg class="icon-16 color-gray-700" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                <path stroke-linecap="round" stroke-linejoin="round" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
                <path stroke-linecap="round" stroke-linejoin="round" d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z" />
            </svg>


            <span runat="server" id="offerViews" class="text-small text-medium color-gray-700">
                2
                <%-- Numbers of views --%>
            </span>
        </span>
    </div>  
    <div class="flex-center-v gap-16">
        <span class="flex-center-v gap-4">
            <svg class="icon-16 color-gray-700" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" >
                <path stroke-linecap="round" stroke-linejoin="round" d="M17.982 18.725A7.488 7.488 0 0012 15.75a7.488 7.488 0 00-5.982 2.975m11.963 0a9 9 0 10-11.963 0m11.963 0A8.966 8.966 0 0112 21a8.966 8.966 0 01-5.982-2.275M15 9.75a3 3 0 11-6 0 3 3 0 016 0z" />
            </svg>

            <span runat="server" id="offerUserWhoPublished" class="text-normal text-regular color-gray-700">
                Diego Ramirez
                <%-- User who published the offer --%>
            </span>
        </span>
        <p runat="server" id="offerDate" class="text-small  text-regular color-gray-500">
                Hace 3 Dias
                <%-- Dato of publication to offer --%>
        </p>
   </div>
    <div class=" flex-center-v gap-16">

    
        
            <span class="flex-center-v gap-4">
                <svg class="icon-16 color-orange-500" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" >
                    <path stroke-linecap="round" stroke-linejoin="round" d="M2.25 18.75a60.07 60.07 0 0115.797 2.101c.727.198 1.453-.342 1.453-1.096V18.75M3.75 4.5v.75A.75.75 0 013 6h-.75m0 0v-.375c0-.621.504-1.125 1.125-1.125H20.25M2.25 6v9m18-10.5v.75c0 .414.336.75.75.75h.75m-1.5-1.5h.375c.621 0 1.125.504 1.125 1.125v9.75c0 .621-.504 1.125-1.125 1.125h-.375m1.5-1.5H21a.75.75 0 00-.75.75v.75m0 0H3.75m0 0h-.375a1.125 1.125 0 01-1.125-1.125V15m1.5 1.5v-.75A.75.75 0 003 15h-.75M15 10.5a3 3 0 11-6 0 3 3 0 016 0zm3 0h.008v.008H18V10.5zm-12 0h.008v.008H6V10.5z" />
                </svg>

                <span runat="server" id="offerSalaryRange" class="text-normal text-medium color-orange-500">
                    1 SLMV - 2 SLMV
                    <%-- Salary Range --%>
                </span>
            </span>
            <span class="flex-center-v gap-4">
                <svg class="icon-16 color-gray-500" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" >
                    <path stroke-linecap="round" stroke-linejoin="round" d="M15 10.5a3 3 0 11-6 0 3 3 0 016 0z" />
                    <path stroke-linecap="round" stroke-linejoin="round" d="M19.5 10.5c0 7.142-7.5 11.25-7.5 11.25S4.5 17.642 4.5 10.5a7.5 7.5 0 1115 0z" />
                </svg>

                <span runat="server" id="offerLocation" class="text-normal text-regular color-gray-500">
                    Soacha/Cundina
                    <%-- Location of offer --%>
                </span>
            </span>
        
 </div>
    </div>

    <div class=" flex-col gap-32">

     <div class="flex-center-v gap-4">

        <asp:Label ID="lblOfferEdit" runat="server" Text="" AssociatedControlID="btnOfferEdit">
            <asp:Button ID="btnOfferEdit" runat="server" Text="Button" Visible="false" />
            <svg class="icon-24 pointer color-gray-700" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                <path stroke-linecap="round" stroke-linejoin="round" d="M15.232 5.232l3.536 3.536m-2.036-5.036a2.5 2.5 0 113.536 3.536L6.5 21.036H3v-3.572L16.732 3.732z" />
            </svg>
        </asp:Label>

        <asp:Label ID="lblOfferCopy" runat="server" AssociatedControlID="btnOfferCopy">
            <asp:Button ID="btnOfferCopy" runat="server" Text="Button" Visible="false" />
            <svg class="icon-24 pointer color-gray-700" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                <path stroke-linecap="round" stroke-linejoin="round" d="M8 7v8a2 2 0 002 2h6M8 7V5a2 2 0 012-2h4.586a1 1 0 01.707.293l4.414 4.414a1 1 0 01.293.707V15a2 2 0 01-2 2h-2M8 7H6a2 2 0 00-2 2v10a2 2 0 002 2h8a2 2 0 002-2v-2" />
            </svg>
        </asp:Label>

        <asp:Label ID="lblOfferReload" runat="server" AssociatedControlID="btnOfferReload">
            <asp:Button ID="btnOfferReload" runat="server" Text="Button" Visible="false" />
            <svg class="icon-24 pointer color-gray-700" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                <path stroke-linecap="round" stroke-linejoin="round" d="M4 4v5h.582m15.356 2A8.001 8.001 0 004.582 9m0 0H9m11 11v-5h-.581m0 0a8.003 8.003 0 01-15.357-2m15.357 2H15" />
            </svg>
        </asp:Label>

        <asp:Label ID="lblOfferDelete" runat="server" AssociatedControlID="btnOfferDelete">
            <asp:Button ID="btnOfferDelete" runat="server" Text="Button" Visible="false" />
            <svg class="icon-24 pointer color-gray-700" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                <path stroke-linecap="round" stroke-linejoin="round" d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16" />
            </svg>
        </asp:Label>

        </div>

    <div class="flex-center-v gap-4 justify-end">

        <svg class="icon-16 color-gray-700" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
            <path stroke-linecap="round" stroke-linejoin="round" d="M12 4.354a4 4 0 110 5.292M15 21H3v-1a6 6 0 0112 0v1zm0 0h6v-1a6 6 0 00-9-5.197M13 7a4 4 0 11-8 0 4 4 0 018 0z" />
        </svg>

        <span runat="server" id="offerAppications" class="text-normal text-medium color-gray-700">34</span>
        
    </div>

    </div>  

</article>

