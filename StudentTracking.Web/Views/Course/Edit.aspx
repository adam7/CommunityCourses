<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<StudentTracking.Web.ViewModel.CourseViewModel>" %>

<%@ Import Namespace="xVal.Rules" %>
<%@ Import Namespace="StudentTracking.Web.ViewModel" %>
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
			<input type="submit" value="Save" class="st-button" />
		</p>
	</fieldset>
	<% } %>
	<%= Html.ClientSideValidation<CourseViewModel>() %>
	<% if (Model.Id != 0)
		{ %>
	<fieldset>
		<legend>Students</legend>
		<div id="accordion">
			<% foreach (CourseStudentViewModel student in Model.Students)
			{ %>
			<h3>
				<a href="#">
					<%= student.Name + " - " + student.Address%></a></h3>
			<div>
				<%= Html.ActionLink("Details", "Details", "Student", new { id = student.Id }, new { @class = "st-button" })%>
				<h4>
					Sessions</h4>
				<table class="st-table">
					<tr>
						<th>
							Name
						</th>
						<th>
							Completed
						</th>
					</tr>
					<% foreach (StudentCourseSessionViewModel studentSession in Model.Sessions.Where(module => module.StudentId == student.Id))
				{ %>
					<tr>
						<td>
							<%= studentSession.SessionName%>
						</td>
						<td>
							<%= 
								Html.CheckBox("CheckBox", studentSession.Completed, new { onClick = "updateSessionComplete(" + Model.Id + "," + student.Id + "," + studentSession.SessionId + ",'" + !studentSession.Completed + "');" })%>
						</td>
					</tr>
					<%} %>
				</table>
				<h4>
					Modules</h4>
				<table class="st-table">
					<tr>
						<th>
							Name
						</th>
						<th>
							Completed
						</th>
					</tr>
					<% foreach (StudentCourseModuleViewModel studentModule in Model.Modules.Where(module => module.StudentId == student.Id))
				{ %>
					<tr>
						<td>
							<%= studentModule.ModuleName%>
						</td>
						<td>
							<%= 
								Html.CheckBox("CheckBox", studentModule.Completed, new { onClick = "updateModuleComplete(" + Model.Id + "," + student.Id + "," + studentModule.ModuleId + ",'" + !studentModule.Completed + "');" })%>
						</td>
					</tr>
					<%} %>
				</table>
			</div>
			<%} %>
		</div>
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
	<% } %>
	<p>
		<%=Html.ActionLink("Back to List", "Index", null, new { @class = "st-back-button" })%>
	</p>

	<script type="text/javascript">
		$('#accordion').accordion({ collapsible: true, active: false });
		function updateSessionComplete(courseId, studentId, courseSessionId, complete)
		{
			$.ajax(
			{
				type: "POST",
				url: "/Course/UpdateSessionComplete",
				data: "courseId=" + courseId + "&studentId=" + studentId + "&courseSessionId=" + courseSessionId + "&complete=" + complete.toString().toLowerCase(),
				success: function(result) { /* Should do something here */ }
			});
		}
		function updateModuleComplete(courseId, studentId, courseModuleId, complete) {
			$.ajax(
			{
				type: "POST",
				url: "/Course/UpdateModuleComplete",
				data: "courseId=" + courseId + "&studentId=" + studentId + "&courseModuleId=" + courseModuleId + "&complete=" + complete.toString().toLowerCase(),
				success: function(result) { /* Should do something here */ }
			});
		}
	</script>

</asp:Content>
