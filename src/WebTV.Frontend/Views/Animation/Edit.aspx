<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebTV.Model.Animation>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Animatie bewerken</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Ani-fucking-matie</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Name) %>
                <%: Html.ValidationMessageFor(model => model.Name) %>
            </div>
            
            <p>
                <input type="submit" value="Opslaan" />
            </p>
        </fieldset>

        <ul title="Media">
            <% foreach (var media in Model.Media) { %>
                <li><% Html.RenderPartial("Media", media); %></li>
            <% } %>
        </ul>

    <% } %>

    <div>
        <%: Html.ActionLink("Terug naar lijst", "Index") %>
    </div>

</asp:Content>

