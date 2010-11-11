<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        Ingelogd als <b><%: Page.User.Identity.Name %></b>
        [ <%: Html.ActionLink("Uitloggen", "LogOff", "Account") %> ]
<%
    }
    else {
%> 
        [ <%: Html.ActionLink("Inloggen", "LogOn", "Account") %> ]
<%
    }
%>
