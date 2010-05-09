<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<StudentTracking.Web.ViewModel.StudentViewModel>" %>
<% Html.RenderPartial("~/Views/Person/Details.ascx", Model.Person); %>
<% Html.RenderPartial("~/Views/Address/Details.ascx", Model.Address); %>

