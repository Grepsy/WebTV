﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        Ingelogd als <b><%: Page.User.Identity.Name %></b>
        <% if(HttpContext.Current.User.IsInRole("Administrator")){ %>
            (Administrator)
        <%} %>
        <%: Html.ActionLink("Uitloggen", "LogOff", "Account") %>
<%
    }
    else {
%> 
        [ <%: Html.ActionLink("Inloggen", "LogOn", "Account") %> ]
<%
    }
%>
