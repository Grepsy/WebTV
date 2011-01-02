<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<li>
    <%: Html.ActionLink("Mijn fotosets", "Index", "MediaSet")%>
</li>
<li>
    <%: Html.ActionLink("Gebruike aanmaken", "Register", "Account")%>
</li>
<li>
    <%: Html.ActionLink("Overzicht gebruikers", "ListUsers", "Account")%>
</li>