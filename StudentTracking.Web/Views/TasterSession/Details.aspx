<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<StudentTracking.Data.Model.TasterSession>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		Details</h2>
	<fieldset>
		<legend>Fields</legend>
		<p>
			Name:
			<%= Html.Encode(Model.Name) %>
		</p>
		<p>
			Centre:
			<%= Html.Encode(Model.Centre.Name) %>
		</p>
		<p>
			TutorId:
			<%= Html.Encode(Model.Tutor.Person.Name) %>
		</p>
		<p>
			DateAndTime:
			<%= Html.Encode(String.Format("{0:g}", Model.DateAndTime)) %>
		</p>
	</fieldset>
	<p>
		<%=Html.ActionLink("Edit", "Edit", new { id = Model.Id }, new { @class = "st-button" })%>
		<%=Html.ActionLink("Back to List", "Index", null, new { @class = "st-back-button" })%>
	</p>
</asp:Content>
