<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<StudentTracking.Data.Model.Person>" %>
<fieldset>
  <legend>Person</legend>
  <p>
    Name:
    <%= Html.Encode(Model.Name) %>
  </p>
  <p>
    Phone:
    <%= Html.Encode(Model.Phone) %>
  </p>
  <p>
    Mobile:
    <%= Html.Encode(Model.Mobile) %>
  </p>
  <p>
    Email:
    <%= Html.Encode(Model.Email) %>
  </p>
  <p>
    Notes:
    <%= Html.Encode(Model.Notes) %>
  </p>
  <p>
    Date Of Birth:
    <%= Html.Encode(String.Format("{0:g}", Model.DateOfBirth)) %>
  </p>
  <p>
    Disability:
    <%= Html.Encode(Model.DisabilityId) %>
  </p>
  <p>
    Ethnicity:
    <%= Html.Encode(Model.EthnicityId) %>
  </p>
  <p>
    Gender:
    <%= Html.Encode(Model.GenderId) %>
  </p>
</fieldset>
<% Html.RenderPartial("~/Views/Address/Details.ascx", Model.Address); %>
<p>
  <%=Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %>
  |
  <%=Html.ActionLink("Back to List", "Index") %>
</p>
