<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<CommunityCourses.Web.ViewModel.CourseViewModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Courses
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		Courses</h2>
	<table class="st-table">
		<thead>
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
					Start Date
				</th>
				<th>
					End Date
				</th>
				<th>
					Status
				</th>
			</tr>
		</thead>
		<tbody>
			<% foreach (var item in Model)
			{ %>
			<tr>
				<td>
					<%= Html.ActionLink("Edit", "Edit", new { id=item.Id  }) %>
					|
					<%= Ajax.ShowDetailsActionLink("Course", item.Id, "DetailsDialog", "ShowDetailsDialog")%>
				</td>
				<td>
					<%: item.Name %>
				</td>
				<td>
					<%: item.Unit.Name %>
				</td>
				<td>
					<%: item.Centre != null ? item.Centre.Name : string.Empty %>
				</td>
				<td>
					<%: String.Format("{0:d}", item.StartDate) %>
				</td>
				<td>
					<%: String.Format("{0:d}", item.EndDate) %>
				</td>
				<td class="<%: item.Status.ToString().ToLower() %>">
					<%: item.Status %>
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
        <a href="/Course/Download/Page<%: ViewData.GetPageNumber() %>" class="st-button">Download</a>
    </p>
	<p>
		<%= Html.ActionLink("Create New", "Create", null, new { @class = "st-button" })%>
	</p>
</asp:Content>
