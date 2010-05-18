<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<StudentTracking.Data.Model.Address>" %>
<%@ Import Namespace="xVal.Rules"%>
<%@ Import Namespace="StudentTracking.Data.Model"%>
<fieldset>
  <legend>Address</legend>
  <p>
    <label for="AddressX">
      First Line:</label>
    <%= Html.TextArea("FirstLine", Model.FirstLine, new { rows = "4" })%>
  </p>
  <p>
    <label for="City">
      City:</label>
    <%= Html.TextBox("City", Model.City) %>
  </p>
  <p>
    <label for="PostCode">
      Postcode:</label>
    <%= Html.TextBox("Postcode", Model.Postcode) %>
  </p>
</fieldset>
<%= Html.ClientSideValidation<Address>() %>
