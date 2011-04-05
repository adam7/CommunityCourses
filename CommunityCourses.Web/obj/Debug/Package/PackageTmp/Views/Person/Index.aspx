<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<CommunityCourses.Web.Model.Person>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	People
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		People</h2>
	<table class="st-table">
		<thead>
			<tr>
				<th>
				</th>
				<th>
					First name
				</th>
				<th>
					Last name
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
				<th>Roles</th>
			</tr>
		</thead>
		<tbody>
			<% foreach (var item in Model)
			{ %>
			<tr>
				<td>
					<%= Html.ActionLink("Edit", "Edit" , new { id=item.Id  }) %>
					|
					<%= Ajax.ShowDetailsActionLink("Person", item.Id, "DetailsDialog", "ShowDetailsDialog")%>
				</td>
				<td>
					<%: item.FirstName %>
				</td>
				<td>
					<%: item.LastName %>
				</td>
				<td>
					<%: item.Address.Postcode %>
				</td>
				<td>
					<%: item.Phone %>
				</td>
				<td>
					<%: item.Mobile %>
				</td>
				<td>
					<%: item.Email %>
				</td>
				<td>
					<%: item.CriminalRecordsBureauReferenceNumber %>
				</td>
				<td>
					<% foreach(string role in item.Roles){
					Response.Write(role + " ");}%>
				</td>
			</tr>
			<% } %>
		</tbody>
	</table>
	<div id="DetailsDialog">
	</div>
	<p>
		<%=Html.PageLinks(ViewData.GetPageNumber(), ViewData.GetTotalPages(), x => Url.Action("Index", new { page = x })) %>
	</p>
    <p>
        <a href="/Person/Download/Page<%: ViewData.GetPageNumber() %>" class="st-button">Download</a>
    </p>
	<p>
		<%= Html.ActionLink("Create New", "Create", null, new { @class = "st-button" })%>
		<button type="button" value="Search" class="st-button" id="Search" disabled="disabled" />
	</p>
</asp:Content>
