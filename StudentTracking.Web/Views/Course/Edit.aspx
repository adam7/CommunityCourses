<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<StudentTracking.Data.Model.Course>" %>

<%@ Import Namespace="xVal.Rules" %>
<%@ Import Namespace="StudentTracking.Data.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		Edit Course</h2>
	<% using (Html.BeginForm())
		{%>
	<fieldset>
		<legend>Course Details</legend>
		<%= Html.Hidden("Id", Model.Id) %>
		<p>
			<label for="Name">
				Name:</label>
			<%= Html.TextBox("Name", Model.Name) %>
		</p>
		<p>
			<label for="UnitId">
				Unit:</label>
			<%= Html.DropDownList("UnitId", new SelectList(ViewData.GetUnits(), "Id", "Name", Model.UnitId), "Please choose")%>
		</p>
		<p>
			<label for="CentreId">
				Centre:</label>
			<%= Html.DropDownList("CentreId", new SelectList(ViewData.GetCentres(), "Id", "Name", Model.CentreId), "Please choose")%>
		</p>
		<p>
			<label for="StartDate">
				Start Date:</label>
			<%= Html.TextBox("StartDate", String.Format("{0:g}", Model.StartDate)) %>
		</p>
		<p>
			<label for="TutorId">
				Tutor:</label>
			<%= Html.DropDownList("TutorId", new SelectList(ViewData.GetTutors(), "Id",  "Person.Name", Model.TutorId), "Please choose") %>
		</p>
		<p>
			<label for="VerifierId">
				Verifier:</label>
			<%= Html.DropDownList("VerifierId", new SelectList(ViewData.GetVerifiers(), "Id", "Person.Name", Model.VerifierId), "Please choose")%>
		</p>
		<p>
			<input type="submit" value="Save" />
		</p>
	</fieldset>
	<% } %>
	<%= Html.ClientSideValidation<Course>() %>
	<%
		if (Model.Id != 0)
		{ %>	
	<fieldset>
		<legend>Students</legend>
		<% Html.RenderPartial("~/Views/Student/List.ascx", Model.Students); %>
		<% using (Html.BeginForm("AddStudent", "Course"))
		 { %>
		<%= Html.Hidden("Id", Model.Id)%>
		<p>
			<label for="AddStudentId">
				Student:</label>
			<%= Html.DropDownList("StudentId", new SelectList(ViewData.GetPotentialStudents(), "Id", "Person.Name"), "Please choose")%>
			<input type="submit" value="Add" />
		</p>
		<%} %>
	</fieldset>
	<div>
		<%=Html.ActionLink("Back to List", "Index")%>
		| <a href="">Add Student</a>
	</div>
	<%} %>
</asp:Content>