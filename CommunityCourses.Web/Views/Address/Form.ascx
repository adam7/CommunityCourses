<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CommunityCourses.Web.Model.Address>" %>
<fieldset>
  <legend>Address</legend>
  <p>
			<%= Html.Label("Address.FirstLine")%>
			<%= Html.TextBox("Address.FirstLine", Model.FirstLine)%>
			<%= Html.ValidationMessage("Address.FirstLine")%>
  </p>
  <p>
			<%= Html.Label("Address.City")%>
			<%= Html.TextBox("Address.City", Model.City)%>
			<%= Html.ValidationMessage("Address.City")%>
  </p>
  <p>
			<%= Html.Label("Address.Postcode")%>
			<%= Html.TextBox("Address.Postcode", Model.Postcode)%>
			<%= Html.ValidationMessage("Address.Postcode")%>
  </p>
</fieldset>
