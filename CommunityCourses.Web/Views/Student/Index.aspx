<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<CommunityCourses.Data.Model.Student>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Students
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		Students</h2>
	<table class="st-table">
		<thead>
			<tr>
				<th>
				</th>
				<th>
					First Name
				</th>
				<th>
					Last Name
				</th>
				<th>
					Postcode
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
				<th>
					CRB Number
				</th>
			</tr>
		</thead>
		<tbody>
			<% foreach (var item in Model)
			{ %>
			<tr>
				<td>
					<%= Html.RouteLink("Edit", new { controller="Student", action="Edit", id=item.Id }) %>
					|
					<%= Ajax.ShowDetailsActionLink("Student", item.Id, "DetailsDialog", "ShowDetailsDialog")%>
				</td>
				<td>
					<%: item.Person.FirstName %>
				</td>
				<td>
					<%: item.Person.LastName %>
				</td>
				<td>
					<%: item.Person.Address.Postcode %>
				</td>
				<td>
					<%: item.Person.Phone %>
				</td>
				<td>
					<%: item.Person.Mobile %>
				</td>
				<td>
					<%: item.Person.Email %>
				</td>
				<td>
					<%: item.Person.CriminalRecordsBureauReferenceNumber %>
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
