<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<CommunityCourses.Web.Model.Centre>>" %>

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
					<%: item.Name %>
				</td>
				<td>
					<%: item.Phone %>
				</td>
				<td>
					<%: item.Address.ToSingleLine() %>
				</td>
				<td>
					<%--<%: Html.Encode(item.ContactName) %>--%>
				</td>
			</tr>
			<% } %>
		</tbody>
	</table>
	<div id="DetailsDialog">
	</div>
	<p>
		<%= Html.PageLinks(ViewData.GetPageNumber(), ViewData.GetTotalPages(), x => Url.Action("Index", new { page = x })) %>
	</p>
    <p>
        <a href="/Centre/Download/Page<%: ViewData.GetPageNumber() %>" class="st-button">Download</a>
    </p>
	<p>
		<%= Html.ActionLink("Create New", "Create", null, new { @class = "st-button" }) %>
	</p>
</asp:Content>
