<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebTV.Model.Account.RegisterModel>" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Gebruiker aanmaken
</asp:Content>
<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <ul class="breadcrumps">
        <li>
            <%: Html.ActionLink("Mijn fotosets", "Index", new { controller = "MediaSet" })%>
        </li>
        <li>
            <%: Html.ActionLink("Gebruikers", "ListUsers", "Account")%>
        </li>
        <li>
            <%: Html.ActionLink("Gebruiker aanmaken", "Register", "Account")%>
        </li>
    </ul>
    <div class="actiontext">
        Maak een nieuwe gebruiker aan of bekijk het <%: Html.ActionLink("overzicht van gebruikers", "ListUsers", "Account")%> welke reeds aangemaakt zijn.
    </div>
    <div>
        <% using (Html.BeginForm()) { %>
            <%: Html.ValidationSummary(true, "Het aanmaken van de gebruiker is mislukt probeer het opnieuw") %>
            <div>
                <fieldset>
                    <div class="editor-label">
                        <%: Html.LabelFor(m => m.UserName) %>
                    </div>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(m => m.UserName) %>
                        <%: Html.ValidationMessageFor(m => m.UserName) %>
                    </div>
                              
                    <div class="editor-label">
                        <%: Html.LabelFor(m => m.Password) %>*
                    </div>
                    <div class="editor-field">
                        <%: Html.PasswordFor(m => m.Password) %>
                        <%: Html.ValidationMessageFor(m => m.Password) %>
                    </div>
                
                    <div class="editor-label">
                        <%: Html.LabelFor(m => m.ConfirmPassword) %>
                    </div>
                    <div class="editor-field">
                        <%: Html.PasswordFor(m => m.ConfirmPassword) %>
                        <%: Html.ValidationMessageFor(m => m.ConfirmPassword) %>
                    </div>
                
                    <p>
                        <input type="submit" value="Aanmaken" />
                    </p>
                </fieldset>
                <p>* Wachtwoorden moeten minimaal <%: ViewData["PasswordLength"] %> karakters lang zijn</p>
            </div>
        <% } %>
    </div>
</asp:Content>