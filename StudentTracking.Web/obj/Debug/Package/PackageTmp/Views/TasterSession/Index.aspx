<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<StudentTracking.Data.Model.TasterSession>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Taster Sessions
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		Taster Sessions</h2>
	<table class="st-table">
		<thead>
			<tr>
				<th>
				</th>
				<th>
					Name
				</th>
				<th>
					Centre
				</th>
				<th>
					Tutor
				</th>
				<th>
					Date
				</th>
			</tr>
		</thead>
		<tbody>
			<% foreach (var item in Model)
			{ %>
			<tr>
				<td>
					<%= Html.ActionLink("Edit", "Edit", new {  id=item.Id }) %>
					|
					<%= Ajax.ShowDetailsActionLink("TasterSession", item.Id, "DetailsDialog", "ShowDetailsDialog")%>
				</td>
				<td>
					<%= Html.Encode(item.Name) %>
				</td>
				<td>
					<%= Html.Encode(item.Centre.Name) %>
				</td>
				<td>
					<%= Html.Encode(item.Tutor.Person.Name) %>
				</td>
				<td>
					<%= Html.Encode(String.Format("{0:dd/MM/yyyy}", item.DateAndTime)) %>
				</td>
			</tr>
			<% } %>
		</tbody>
	</table>
	<div id="DetailsDialog">
	</div>
	<p>
		<%= Html.ActionLink("Create New", "Create", null, new { @class = "st-button" })%>
	</p>
</asp:Content>