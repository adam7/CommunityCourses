<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CommunityCourses.Web.Model.Person>" %>
<fieldset>
	<legend>Person</legend>
	<p>
		Name:
		<%: Model.Title + " " + Model.FirstName + " " + Model.LastName %>
	</p>
	<p>
		Phone:
		<%: Model.Phone %>
	</p>
	<p>
		Mobile:
		<%: Model.Mobile %>
	</p>
	<p>
		Email:
		<%: Model.Email %>
	</p>
	<p>
		Date Of Birth:
		<%: String.Format("{0:d}", Model.DateOfBirth) %>
	</p>
	<p>
		Disabilities:
	</p>
	<ul>
		<% foreach (string disability in Model.Disabilities)
		 { %>
		<li>
			<%: disability %></li>
		<%} %>
	</ul>
	<p>
		Ethnicity:
		<%: Model.Ethnicity %>
	</p>
	<p>
		Notes:
		<%: Model.Notes %>
	</p>
	<p>
		Roles:
		<% foreach(string role in Model.Roles){
					Response.Write(role + " ");}%>
	</p>
</fieldset>
<% Html.RenderPartial("~/Views/Address/Details.ascx", Model.Address); %>

