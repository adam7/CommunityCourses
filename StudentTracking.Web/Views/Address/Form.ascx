<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<StudentTracking.Web.ViewModel.AddressViewModel>" %>
<%@ Import Namespace="xVal.Rules"%>
<%@ Import Namespace="StudentTracking.Web.ViewModel"%>
<fieldset>
  <legend>Address</legend>
  <p>
    <label for="FirstLine">
      First Line:</label>
    <%= Html.TextBox("Address.FirstLine", Model.FirstLine)%>
  </p>
  <p>
    <label for="City">
      City:</label>
    <%= Html.TextBox("Address.City", Model.City)%>
  </p>
  <p>
    <label for="PostCode">
      Postcode:</label>
    <%= Html.TextBox("Address.Postcode", Model.Postcode)%>
  </p>
</fieldset>
<%= Html.ClientSideValidation<AddressViewModel>("Address") %>
