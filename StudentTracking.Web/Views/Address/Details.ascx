<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<StudentTracking.Data.Model.Address>" %>
<fieldset>
  <legend>Address</legend>
  <p>
    First Line:
    <%= Html.Encode(Model.FirstLine) %>
  </p>
  <p>
    City:
    <%= Html.Encode(Model.City) %>
  </p>
  <p>
    Postcode:
    <%= Html.Encode(Model.Postcode) %>
  </p>
</fieldset>
