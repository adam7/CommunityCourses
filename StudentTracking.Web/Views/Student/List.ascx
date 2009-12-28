<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<StudentTracking.Data.Model.Student>>" %>
<table>
  <tr>
    <th>
    </th>
    <th>
      Name
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
      Date Of Birth
    </th>
  </tr>
  <% foreach (var item in Model)
     { %>
  <tr>
    <td>
      <%= Html.RouteLink("Edit", new { controller="Student", action="Edit", id=item.Id }) %>
      |<%= Html.ActionLink("Details", "Details", new { id = item.Id })%>
    </td>
    <td>
      <%= Html.Encode(item.Person.Name) %>
    </td>
    <td>
      <%= Html.Encode(item.Person.Address.ToSingleLine())%>
    </td>
    <td>
      <%= Html.Encode(item.Person.Phone)%>
    </td>
    <td>
      <%= Html.Encode(item.Person.Mobile)%>
    </td>
    <td>
      <%= Html.Encode(item.Person.Email)%>
    </td>
    <td>
      <%= Html.Encode(item.Person.Notes)%>
    </td>
    <td>
      <%= Html.Encode(String.Format("{0:d}", item.Person.DateOfBirth))%>
    </td>
  </tr>
  <% } %>
</table>
