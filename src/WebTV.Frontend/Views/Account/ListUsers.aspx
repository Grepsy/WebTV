<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebTV.Model.Account.AccountModel>" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Gebruikers overzicht
</asp:Content>
<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <ul class="breadcrumps">
        <li>
            <%: Html.ActionLink("Mijn fotosets", "Index", new { controller = "MediaSet" })%>
        </li>
        <li>
            <%: Html.ActionLink("Gebruiker aanmaken", "Register", "Account")%>
        </li>
        <li>
            <%: Html.ActionLink("Overzicht gebruikers", "ListUsers", "Account")%>
        </li>
    </ul>
    <div class="actiontext">
        Hieronder staan alle gebruikers van het systeem. Een gebruiker kan hier onder uitgeschakeld worden (alle gebruikers informatie blijft behouden)
    </div>
    <div>
        <table>
            <thead>
                <tr>
                    <th>
                        Gebruikersnaam
                    </th>
                    <th>
                        Is een beheerder
                    </th>
                    <th>
                        Kan inloggen
                    </th>
                </tr>
            </thead>
            <tbody>
                <% foreach (WebTV.Model.Customer customer in Model.getAllCustomers())
                   {%>
                <tr>
                    <td>
                        <%=customer.Name %>
                    </td>
                    <td>
                        <% if (customer.IsAdmin)
                           {%>
                        Ja
                        <%}
                           else
                           { %>
                        Nee
                        <%} %>
                    </td>
                    <td>
                        <%if (customer.Enabled)
                          {%>
                        <%=Html.ActionLink("Ja", "DeleteUser", "Account", new {username = customer.Name },null)%>
                        <%}
                          else
                          { %>
                        <%=Html.ActionLink("Nee", "DeleteUser", "Account", new { username = customer.Name}, null)%>
                        <%}%>
                    </td>
                </tr>
                <% }%>
            </tbody>
        </table>
    </div>
</asp:Content>
