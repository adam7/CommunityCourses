<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CommunityCourses.Web.ViewModel.CourseViewModel>" %>

<%@ Import Namespace="CommunityCourses.Web.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create Course
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		Create Course</h2>
	<% Html.EnableClientValidation(); %>
	<% using (Html.BeginForm())
		{%>
	<fieldset>
		<legend>Course Details</legend>
		<p>
			<%= Html.LabelFor(m => m.Name) %>
			<%= Html.TextBoxFor(m => m.Name) %>
			<%= Html.ValidationMessageFor(m => m.Name) %>
		</p>
		<p>
			<%= Html.LabelFor(m => m.UnitId)%>
			<%= Html.DropDownListFor(m => m.UnitId, new SelectList(ViewData.GetUnits(), "Id", "Name", Model.UnitId), "Please choose")%>
			<%= Html.ValidationMessageFor(m => m.UnitId)%>
		</p>
		<p>
			<%= Html.LabelFor(m => m.CentreId)%>
			<%= Html.DropDownListFor(m => m.CentreId, new SelectList(ViewData.GetCentres(), "Id", "Name", Model.CentreId), "Please choose")%>
			<%= Html.ValidationMessageFor(m => m.CentreId)%>
		</p>
		<p>
			<%= Html.LabelFor(m => m.StartDate)%>
			<%= Html.TextBoxFor(m =>  m.StartDate, new { @class = "st-date" })%>
			<%= Html.ValidationMessageFor(m => m.StartDate)%>
		</p>
		<p>
			<%= Html.LabelFor(m => m.EndDate)%>
			<%= Html.TextBoxFor(m => m.EndDate, new { @class = "st-date" })%>
			<%= Html.ValidationMessageFor(m => m.EndDate)%>
		</p>
		<p>
			<%= Html.LabelFor(m => m.TutorId)%>
			<%= Html.DropDownListFor(m => m.TutorId, new SelectList(ViewData.GetTutors(), "Id", "Name", Model.TutorId), "Please choose")%>
			<%= Html.ValidationMessageFor(m => m.TutorId)%>
		</p>
		<p>
			<%= Html.LabelFor(m => m.VerifierId)%>
			<%= Html.DropDownListFor(m => m.VerifierId, new SelectList(ViewData.GetVerifiers(), "Id", "Name", Model.VerifierId), "Please choose")%>
			<%= Html.ValidationMessageFor(m => m.VerifierId)%>
		</p>
		<p>
			<input type="submit" value="Save" class="st-button" />
		</p>
	</fieldset>
	<% } %>
	<p>
		<%=Html.ActionLink("Back to List", "Index", null, new { @class = "st-back-button" })%>
	</p>
</asp:Content>
