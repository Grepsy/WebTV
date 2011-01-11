<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebTV.Model.Animation>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ul class="breadcrumps">
        <li>
            <%: Html.ActionLink("Mijn fotosets", "Index", new { controller = "MediaSet" })%>
        </li>
        <li>
            <%: Html.ActionLink("Animaties", "Index", new { controller = "Animation" })%>
        </li>
        <li>
            Nieuwe animatie
        </li>
    </ul>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <div class="editor-label">Naam</div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Name) %>
                <%: Html.ValidationMessageFor(model => model.Name) %>
            </div>
            
            <div class="editor-label">Fotos groeperen per</div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.MediaGroupedBy) %>
                <%: Html.ValidationMessageFor(model => model.MediaGroupedBy) %>
            </div>

            <div class="editor-label">Toegekend aan</div>
            <div class="editor-field">
                <%: Html.DropDownList("CustomerId", (IEnumerable<SelectListItem>)ViewData["Customers"]) %>
                <%: Html.ValidationMessageFor(model => model.Customer) %>
            </div>
                        
            <p>
                <input type="submit" value="Nieuwe animatie maken" />
            </p>
        </fieldset>

    <% } %>
</asp:Content>

