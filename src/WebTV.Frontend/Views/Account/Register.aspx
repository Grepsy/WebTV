<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebTV.Model.Account.RegisterModel>" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Gebruiker aanmaken
</asp:Content>
<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <ul class="breadcrumps">
        <% Html.RenderPartial("UsersMenu"); %>
    </ul>
    <div class="actiontext">
        Maak een nieuwe gebruiker aan.
    </div>
    <div>
        <p>Wachtwoorden moeten minimaal <%: ViewData["PasswordLength"] %> karakters lang zijn</p>
        <% using (Html.BeginForm()) { %>
            <%: Html.ValidationSummary(true, "Het aanmaken van de gebruiker is mislukt probeer het opnieuw") %>
            <div>
                <fieldset>
                    <legend>Account Informatie</legend>
                
                    <div class="editor-label">
                        <%: Html.LabelFor(m => m.UserName) %>
                    </div>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(m => m.UserName) %>
                        <%: Html.ValidationMessageFor(m => m.UserName) %>
                    </div>
                              
                    <div class="editor-label">
                        <%: Html.LabelFor(m => m.Password) %>
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
            </div>
        <% } %>
    </div>
</asp:Content>