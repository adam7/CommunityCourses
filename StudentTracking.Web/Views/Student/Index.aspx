<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<StudentTracking.Data.Model.Student>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Students
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		Students</h2>
	<table class="st-table">
		<tr>
			<th>
			</th>
			<th>
				Name
			</th>
			<th>
				Address
			</th>
			<th>
				Phone
			</th>
			<th>
				Mobile
			</th>
			<th>
				Email
			</th>
		</tr>
		<% foreach (var item in Model)
		 { %>
		<tr>
			<td>
				<%= Html.RouteLink("Edit", new { controller="Student", action="Edit", id=item.Id }) %>
				|
				<%= Ajax.ShowDetailsActionLink("Student", item.Id, "DetailsDialog", "ShowDetailsDialog")%>
			</td>
			<td>
				<%= Html.Encode(item.Person.Name) %>
			</td>
			<td>
				<%= Html.Encode(item.Person.Address.ToSingleLine())%>
			</td>
			<td>
				<%= Html.Encode(item.Person.Phone)%>
			</td>
			<td>
				<%= Html.Encode(item.Person.Mobile)%>
			</td>
			<td>
				<%= Html.Encode(item.Person.Email)%>
			</td>
		</tr>
		<% } %>
	</table>
	<div id="DetailsDialog">
	</div>
	<p>
		<%= Html.ActionLink("Create New", "Create", null, new { @class = "st-back-button" })%>
	</p>
</asp:Content>
