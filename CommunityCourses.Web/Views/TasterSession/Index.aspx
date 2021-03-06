<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<CommunityCourses.Web.Model.TasterSession>>" %>

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
					<%: item.Name %>
				</td>
				<td>
					<%: item.CentreName %>
				</td>
				<td>
					<%: item.TutorName %>
				</td>
				<td>
					<%: String.Format("{0:d}", item.DateAndTime) %>
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
		<%= Html.ActionLink("Create New", "Create", null, new { @class = "st-button" })%>
	</p>
</asp:Content>
