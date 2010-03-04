<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<StudentTracking.Web.ViewModel.PersonViewModel>" %>
<fieldset>
	<legend>Person</legend>
	<p>
		Name:
		<%= Html.Encode(Model.FirstName + " " + Model.LastName) %>
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
		<%= Html.Encode(String.Format("{0:d}", Model.DateOfBirth)) %>
	</p>
	<p>
		Disabilities:
		<ul>
		<% foreach(string disability in Model.Disabilities) { %>
		<li><%= Html.Encode(disability) %></li>
		<%} %>
		</ul>
	</p>
	<p>
		Ethnicity:
		<%= Html.Encode(Model.EthnicityName) %>
	</p>
	<%--<p>
		Gender:
		<%= Html.Encode(Model.Gender.Name) %>
	</p>
	--%>
</fieldset>
