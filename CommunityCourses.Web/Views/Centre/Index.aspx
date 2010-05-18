<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<CommunityCourses.Data.Model.Centre>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Centres
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		Centres</h2>
	<table class="st-table">
		<thead>
			<tr>
				<th>
				</th>
				<th>
					Name
				</th>
				<th>
					Phone
				</th>
				<th>
					Address
				</th>
				<th>
					Contact
				</th>
			</tr>
		</thead>
		<tbody>
			<% foreach (var item in Model)
			{ %>
			<tr>
				<td>
					<%= Html.ActionLink("Edit", "Edit", new { id=item.Id }) %>
					|
					<%= Ajax.ShowDetailsActionLink("Centre", item.Id, "DetailsDialog", "ShowDetailsDialog")%>
				</td>
				<td>
					<%= Html.Encode(item.Name) %>
				</td>
				<td>
					<%= Html.Encode(item.Phone) %>
				</td>
				<td>
					<%= Html.Encode(item.Address.ToSingleLine()) %>
				</td>
				<td>
					<%= Html.Encode(item.ContactId) %>
				</td>
			</tr>
			<% } %>
		</tbody>
	</table>
	<div id="DetailsDialog">
	</div>
	<p>
		<%= Html.ActionLink("Create New", "Create", null, new { @class = "st-button" }) %>
	</p>
</asp:Content>
