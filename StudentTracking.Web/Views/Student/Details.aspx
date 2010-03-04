<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<StudentTracking.Web.ViewModel.StudentViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		Details</h2>
	<% Html.RenderPartial("~/Views/Person/Details.ascx", Model.Person); %>
	<% Html.RenderPartial("~/Views/Address/Details.ascx", Model.Address); %>
	<p>
		<%=Html.ActionLink("Edit", "Edit", new { id = Model.Id }, new { @class = "st-button" })%>
		<%=Html.ActionLink("Back to List", "Index", null, new { @class = "st-back-button" })%>
	</p>
</asp:Content>
