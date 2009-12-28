<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<StudentTracking.Model.Person>" %>
<% using (Html.BeginForm())
   { %>
<% Html.RenderPartial("~/Views/Person/List.ascx"); %>
<p>
  <%= Html.ActionLink("Create New", "Create") %>
</p>
<% } %>