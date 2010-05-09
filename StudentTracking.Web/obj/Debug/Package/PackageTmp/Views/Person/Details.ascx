<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<StudentTracking.Web.ViewModel.PersonViewModel>" %>
<fieldset>
	<legend>Person</legend>
	<p>
		Name:
		<%= Html.Encode(Model.Title + " " + Model.FirstName + " " + Model.LastName) %>
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
		Date Of Birth:
		<%= Html.Encode(String.Format("{0:dd/MM/yyyy}", Model.DateOfBirth)) %>
	</p>
	<p>
		Disabilities:
	</p>
	<ul>
		<% foreach (string disability in Model.Disabilities)
		 { %>
		<li>
			<%= Html.Encode(disability) %></li>
		<%} %>
	</ul>
	<p>
		Ethnicity:
		<%= Html.Encode(Model.EthnicityName) %>
	</p>
	<p>
		Notes:
		<%= Html.Encode(Model.Notes) %>
	</p>
</fieldset>
