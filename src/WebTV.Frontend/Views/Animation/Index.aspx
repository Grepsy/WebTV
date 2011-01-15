<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<WebTV.Model.Animation>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <ul class="breadcrumps">
        <li>
            <%: Html.ActionLink("Mijn fotosets", "Index", new { controller = "MediaSet" })%>
        </li>
        <li>
            Animaties
        </li>
    </ul>

    <div class="actiontext">
        Maak <%: Html.ActionLink("een nieuwe animatie", "Create", "Animation")%>.
    </div>

    <%: Html.Grid(Model).Columns(col => {
            col.For(a => a.Name).Named("Naam");
            col.For(a => a.MediaSets.Count).Named("Actieve fotosets");
            col.For(a => Html.ActionLink("bewerken", "Edit", new { id = a.AnimationId }));
        }) 
    %>
</asp:Content>