<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<CommunityCourses.Data.Person>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>List</h2>

    <table class="st-table">
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                Title
            </th>
            <th>
                FirstName
            </th>
            <th>
                LastName
            </th>
            <th>
                AddressId
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
                Notes
            </th>
            <th>
                DateOfBirth
            </th>
            <th>
                DisabilityId
            </th>
            <th>
                EthnicityId
            </th>
            <th>
                GenderId
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
            </td>
            <td>
                <%= Html.Encode(item.Id) %>
            </td>
            <td>
                <%= Html.Encode(item.Title) %>
            </td>
            <td>
                <%= Html.Encode(item.FirstName) %>
            </td>
            <td>
                <%= Html.Encode(item.LastName) %>
            </td>
            <td>
                <%= Html.Encode(item.Addres) %>
            </td>
            <td>
                <%= Html.Encode(item.Phone) %>
            </td>
            <td>
                <%= Html.Encode(item.Mobile) %>
            </td>
            <td>
                <%= Html.Encode(item.Email) %>
            </td>
            <td>
                <%= Html.Encode(item.Notes) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.DateOfBirth)) %>
            </td>
            <td>
                <%= Html.Encode(item.DisabilityId) %>
            </td>
            <td>
                <%= Html.Encode(item.EthnicityId) %>
            </td>
            <td>
                <%= Html.Encode(item.GenderId) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create", null, new { @class = "st-button" })%>
    </p>

</asp:Content>

