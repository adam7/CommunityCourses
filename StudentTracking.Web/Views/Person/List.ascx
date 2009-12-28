<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<StudentTracking.Data.Person>>" %>

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
      <%= Html.ActionLink("Edit", "Edit", new { id=item.Id }) %>
      |<%= Html.ActionLink("Details", "Details", new { id=item.Id }) %>
    </td>
    <td>
      <%= Html.Encode(item.Name) %>
    </td>
    <td>
      <%= Html.Encode(item.Address.ToSingleLine()) %>
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
      <%= Html.Encode(String.Format("{0:d}", item.DateOfBirth)) %>
    </td>
  </tr>
  <% } %>
</table>
