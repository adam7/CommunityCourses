<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CommunityCourses.Web.ViewModel.CentreViewModel>" %>
<fieldset>
	<p>
		Name:
		<%= Html.Encode(Model.Name) %>
	</p>
	<p>
		Phone:
		<%= Html.Encode(Model.Phone) %>
	</p>
	<p>
		Address:
		<%= Html.Encode(Model.Address.FirstLine) %>
	</p>
<%--	<p>
      Contact:
      <%= Html.Encode(Model.ContactId) %>
  </p>--%>
</fieldset>
