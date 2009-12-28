<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<StudentTracking.Data.Model.TasterSession>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Taster Sessions
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Taster Sessions</h2>
    <table>
        <tr>
            <th></th>
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
                Date And Time
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new {  id=item.Id }) %> |
                <%= Html.ActionLink("Details", "Details", new { id=item.Id })%>
            </td>
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
            <td>
                <%= Html.Encode(item.CentreId) %>
            </td>
            <td>
                <%= Html.Encode(item.TutorId) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.DateAndTime)) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

