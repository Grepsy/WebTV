<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebTV.Model.Account.AccountModel>" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Gebruikers overzicht
</asp:Content>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Gebruikers die aangemaakt zijn:</h2>
    <table>
    <thead>
        <tr><th>Naam</th><th>Is Admin</th><th>Actief</th></tr>
    </thead>
        <tbody>
        <% foreach(WebTV.Model.Customer customer in Model.getAllCustomers())
           {%>
            <tr>
                <td><%=customer.Name %></td>
                <td>
                <% if (customer.IsAdmin)
                   {%>
                    Ja
                 <%}else{ %> 
                    Nee 
                <%} %>
                </td>
                <td>
                 <%if (customer.Enabled){%>
                    <%=Html.ActionLink("Ja", "DeleteUser", "Account", new {username = customer.Name },null)%>
                 <%}else{ %>
                    <%=Html.ActionLink("Nee", "DeleteUser", "Account", new { username = customer.Name}, null)%>
                 <%}%>
                 </td>
            </tr>
        <% }%>
        </tbody>
    </table>
</asp:Content>
