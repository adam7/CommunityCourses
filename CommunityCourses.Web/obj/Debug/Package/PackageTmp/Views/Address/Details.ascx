<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CommunityCourses.Web.Model.Address>" %>
<fieldset>
  <legend>Address</legend>
  <p>
    First Line:
    <%: Model.FirstLine %>
  </p>
  <p>
    City:
    <%: Model.City %>
  </p>
  <p>
    Postcode:
    <%: Model.Postcode %>
  </p>
</fieldset>
