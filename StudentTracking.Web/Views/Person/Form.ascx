<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<StudentTracking.Web.ViewModel.PersonViewModel>" %>
<%@ Import Namespace="xVal.Rules" %>
<%@ Import Namespace="StudentTracking.Web.ViewModel" %>
<fieldset>
	<legend>Person</legend>
	<p>
		<label for="Title">
			Title:</label>
		<%= Html.TextBox("Person.Title", Model.Title) %>
	</p>
	<%--	<p>
		<label for="GenderId">
			Gender:</label>
		<%= Html.DropDownList("GenderId", Gender.ToSelectList(), "Please choose") %>
	</p>--%>
	<p>
		<label for="FirstName">
			First Name:</label>
		<%= Html.TextBox("Person.FirstName", Model.FirstName)%>
	</p>
	<p>
		<label for="LastName">
			Last Name:</label>
		<%= Html.TextBox("Person.LastName", Model.LastName)%>
	</p>
	<p>
		<label for="DateOfBirth">
			Date Of Birth:</label>
		<%= Html.TextBox("Person.DateOfBirth", String.Format("{0:d}", Model.DateOfBirth))%>
	</p>
	<p>
		<label for="Phone">
			Phone:</label>
		<%= Html.TextBox("Person.Phone", Model.Phone)%>
	</p>
	<p>
		<label for="Mobile">
			Mobile:</label>
		<%= Html.TextBox("Person.Mobile", Model.Mobile)%>
	</p>
	<p>
		<label for="Email">
			Email:</label>
		<%= Html.TextBox("Person.Email", Model.Email)%>
	</p>
	<p>
		<label for="EthnicityId">
			Ethnicity:</label>
		<%= Html.DropDownList("Person.EthnicityId", new SelectList(ViewData.GetEthnicities(), "Id", "Name", Model.EthnicityId), "Please choose")%>
	</p>
	<p>
		<label>
			Disabilities:</label>
		<%= Html.CheckBoxList(Model.Disabilities, ViewData.GetDisabilities(), "Person.Disabilities") %>
	</p>
	<p>
		<label for="CriminalRecordsBureauReferenceNumber">
			CRB Reference Number</label>
		<%= Html.TextBox("Person.CriminalRecordsBureauReferenceNumber", Model.CriminalRecordsBureauReferenceNumber)%>
	</p>
	<p>
		<label for="Notes">
			Notes:</label>
		<%= Html.TextArea("Person.Notes", Model.Notes, new { rows = "8" })%>
	</p>
</fieldset>
<%= Html.ClientSideValidation<PersonViewModel>("Person") %>
