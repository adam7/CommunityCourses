<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CommunityCourses.Web.ViewModel.AddressViewModel>" %>
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
