<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.DateTime?>" %>
<%: Html.TextBox("",  String.Format("{0:dd-MM-yyyy}", Model.HasValue ? Model : DateTime.Today), new { @class = "datetime"})%>

