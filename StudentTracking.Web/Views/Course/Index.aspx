<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<StudentTracking.Data.Model.Course>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
  Courses
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h2>
    Courses</h2>
  <table>
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
        Tutor
      </th>
      <th>
        Verifier
      </th>
    </tr>
    <% foreach (var item in Model)
       { %>
    <tr>
      <td>
        <%= Html.ActionLink("Edit", "Edit", new { id=item.Id  }) %>
        |
        <%= Html.ActionLink("Details", "Details", new { id=item.Id })%>
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
      <td>
        <%= Html.Encode(item.TutorId) %>
      </td>
      <td>
        <%= Html.Encode(item.VerifierId) %>
      </td>
    </tr>
    <% } %>
  </table>
  <p>
    <%= Html.ActionLink("Create New", "Create") %>
  </p>
</asp:Content>