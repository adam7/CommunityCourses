<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<StudentTracking.Data.Model.Person>" %>
<%@ Import Namespace="xVal.Rules" %>
<%@ Import Namespace="StudentTracking.Data.Model" %>
<fieldset>
	<legend>Person</legend>
	<p>
		<label for="Title">
			Title:</label>
		<%= Html.TextBox("Title", Model.Title) %>
	</p>
	<p>
		<label for="GenderId">
			Gender:</label>
		<%= Html.DropDownList("GenderId", new SelectList(ViewData.GetGenders(), "Id", "Name"), "Please choose") %>
	</p>
	<p>
		<label for="FirstName">
			First Name:</label>
		<%= Html.TextBox("FirstName", Model.FirstName) %>
	</p>
	<p>
		<label for="LastName">
			Last Name:</label>
		<%= Html.TextBox("LastName", Model.LastName) %>
	</p>
	<p>
		<label for="DateOfBirth">
			Date Of Birth:</label>
		<%= Html.TextBox("DateOfBirth", String.Format("{0:d}", Model.DateOfBirth)) %>
	</p>
	<p>
		<label for="Phone">
			Phone:</label>
		<%= Html.TextBox("Phone", Model.Phone) %>
	</p>
	<p>
		<label for="Mobile">
			Mobile:</label>
		<%= Html.TextBox("Mobile", Model.Mobile) %>
	</p>
	<p>
		<label for="Email">
			Email:</label>
		<%= Html.TextBox("Email", Model.Email) %>
	</p>
	<p>
		<label for="EthnicityId">
			Ethnicity:</label>
		<%= Html.DropDownList("EthnicityId", new SelectList(ViewData.GetEthnicities(), "Id", "Name"), "Please choose") %>
	</p>
	<p>
		<label for="DisabilityId">
			Disability:</label>
		<%= Html.DropDownList("DisabilityId", new SelectList(ViewData.GetDisabilities(), "Id",  "Name"), "Please choose") %>
	</p>
	<p>
		<label for="CriminalRecordsBureauReferenceNumber">
			CRB Reference Number</label>
		<%= Html.TextBox("CriminalRecordsBureauReferenceNumber", Model.CriminalRecordsBureauReferenceNumber)%>	
	</p>
	<p>
		<label for="Notes">
			Notes:</label>
		<%= Html.TextArea("Notes", Model.Notes, new { rows = "8" })%>
	</p>
</fieldset>
<%= Html.ClientSideValidation<Person>() %>
<% Html.RenderPartial("~/Views/Address/Form.ascx", Model.Address ?? new Address()); %>
<p>
	<input type="submit" value="Save" />
</p>
