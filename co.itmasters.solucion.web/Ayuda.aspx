<%@ Page Title="ITMasters - Ayuda" Language="C#" MasterPageFile="~/ITMasters.master" AutoEventWireup="true" CodeBehind="Ayuda.aspx.cs" Inherits="co.itmasters.solucion.web.Ayuda" %>
<%@ MasterType VirtualPath="~/ITMasters.master" %>

<asp:Content ID="DefaultMain" ContentPlaceHolderID="Main" runat="Server">      

    <script type="text/javascript">

                    

    </script>

    <asp:UpdatePanel ID="UpdatePanelAgenda" runat="server">
        <ContentTemplate>
            <div style="vertical-align: middle">
                <table class="tabla" width="100%">
                    <tr class="modo1">
                        <td colspan="4">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Clave" />
                        </td>
                    </tr>
                    <tr class="modo1">
                        <th align="left">
                            Instructivos
                        </th>                      
                    </tr>                                      
                    <tr class="modo1" >
                        <td colspan="4">
                            <a href="../Documentos/ManualAcademicsV2.pdf" style="font-size:large" target="_blank">Instructivo General</a>
                        </td>
                    </tr>                                          
                    <tr class="modo1" >
                        <td colspan="4">
                            <a href="../Documentos/AcademicsValoracion.pdf" style="font-size:large" target="_blank">Valoracion</a>
                        </td>
                    </tr>
                    <tr class="modo1" >
                        <td colspan="4">
                            <a href="../Documentos/AcademicsAlumnos.pdf" style="font-size:large"  target="_blank">Alumnos</a>
                        </td>
                    </tr>
                    <tr class="modo1" >
                        <td colspan="4">
                            <a href="../Documentos/AcademicsAspirantes.pdf" style="font-size:large"  target="_blank">Aspirantes</a>
                        </td>
                    </tr>                                                            
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>    
    
</asp:Content>

