<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<StudentTracking.Data.Model.Course>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Courses
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		Courses</h2>
	<table class="st-table">
		<tr>
			<th>
			</th>
			<th>
				Name
			</th>
			<th>
				Unit
			</th>
			<th>
				Centre
			</th>
			<th>
				Start Date/Time
			</th>
		</tr>
		<% foreach (var item in Model)
		 { %>
		<tr>
			<td>
				<%= Html.ActionLink("Edit", "Edit", new { id=item.Id  }) %>
				|
				<%= Ajax.ShowDetailsActionLink("Course", item.Id, "DetailsDialog", "ShowDetailsDialog")%>
			</td>
			<td>
				<%= Html.Encode(item.Name) %>
			</td>
			<td>
				<%= Html.Encode(item.Unit.Name) %>
			</td>
			<td>
				<%= Html.Encode(item.Centre.Name) %>
			</td>
			<td>
				<%= Html.Encode(String.Format("{0:g}", item.StartDate)) %>
			</td>
		</tr>
		<% } %>
	</table>
	<div id="DetailsDialog">
	</div>
	<p>
		<%= Html.ActionLink("Create New", "Create", null, new { @class = "st-button" })%>
	</p>
</asp:Content>
