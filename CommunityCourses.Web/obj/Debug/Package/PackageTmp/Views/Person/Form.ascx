<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CommunityCourses.Web.Model.Person>" %>
<%@ Import Namespace="CommunityCourses.Web.Model" %>
<fieldset>
	<legend>Person</legend>
	<p>
			<%= Html.LabelFor(m => m.Title)%>
			<%= Html.TextBoxFor(m => m.Title)%>
			<%= Html.ValidationMessageFor(m => m.Title)%>
	</p>
	<p>
			<%= Html.LabelFor(m => m.Gender)%>
			<%= Html.DropDownListFor(m => m.Gender, new SelectList(Genders.All() , Model.Gender), "Please choose")%>
			<%= Html.ValidationMessageFor(m => m.Gender)%>
	</p>
	<p>
			<%= Html.LabelFor(m => m.FirstName)%>
			<%= Html.TextBoxFor(m => m.FirstName)%>
			<%= Html.ValidationMessageFor(m => m.FirstName)%>
	</p>
	<p>
			<%= Html.LabelFor(m => m.LastName)%>
			<%= Html.TextBoxFor(m => m.LastName)%>
			<%= Html.ValidationMessageFor(m => m.LastName)%>
	</p>
	<p>
		<label for="Roles">Roles</label>
		<%= Html.CheckBoxList(Model.Roles, CommunityCourses.Web.Model.Roles.All(), "Roles")%>
	</p>
	<p>
			<%= Html.LabelFor(m => m.DateOfBirth)%>
			<%= Html.TextBoxFor(m => m.DateOfBirth, new { @class = "st-date" })%>
			<%= Html.ValidationMessageFor(m => m.DateOfBirth)%>
	</p>
	<p>
			<%= Html.LabelFor(m => m.Phone)%>
			<%= Html.TextBoxFor(m => m.Phone)%>
			<%= Html.ValidationMessageFor(m => m.Phone)%>
	</p>
	<p>
			<%= Html.LabelFor(m => m.Mobile)%>
			<%= Html.TextBoxFor(m => m.Mobile)%>
			<%= Html.ValidationMessageFor(m => m.Mobile)%>
	</p>
	<p>
			<%= Html.LabelFor(m => m.Email)%>
			<%= Html.TextBoxFor(m => m.Email)%>
			<%= Html.ValidationMessageFor(m => m.Email)%>
	</p>
	<p>
			<%= Html.LabelFor(m => m.Ethnicity)%>
			<%= Html.DropDownListFor(m => m.Ethnicity, new SelectList(Ethnicities.All(), Model.Ethnicity), "Please choose")%>
			<%= Html.ValidationMessageFor(m => m.Ethnicity)%>
	</p>
	<p>
		<label>
			Disabilities:</label>
		<%= Html.CheckBoxList(Model.Disabilities, Disabilities.All(), "Disabilities")%>
	</p>
	<p>
			<%= Html.LabelFor(m => m.CriminalRecordsBureauReferenceNumber)%>
			<%= Html.TextBoxFor(m => m.CriminalRecordsBureauReferenceNumber)%>
			<%= Html.ValidationMessageFor(m => m.CriminalRecordsBureauReferenceNumber)%>
	</p>
	<p>
			<%= Html.LabelFor(m => m.CriminalRecordsBureauExpiryDate)%>
			<%= Html.TextBoxFor(m => m.CriminalRecordsBureauExpiryDate, new { @class = "st-date" })%>
			<%= Html.ValidationMessageFor(m => m.CriminalRecordsBureauExpiryDate)%>
	</p>
	<p>
			<%= Html.LabelFor(m => m.Notes)%>
			<%= Html.TextAreaFor(m => m.Notes, new { rows = "8" })%>
			<%= Html.ValidationMessageFor(m => m.Notes)%>
	</p>
</fieldset>
