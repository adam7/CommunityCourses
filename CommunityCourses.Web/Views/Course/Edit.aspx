<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CommunityCourses.Web.ViewModel.CourseViewModel>" %>

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
			<%= Html.TextBoxFor(m => m.Name) %>
		</p>
		<p>
			<label for="UnitId">
				Unit:</label>
			<%= Html.DropDownListFor(m => m.UnitId, new SelectList(ViewData.GetUnits(), "Id", "Name", Model.UnitId), "Please choose")%>
		</p>
		<p>
			<label for="CentreId">
				Centre:</label>
			<%= Html.DropDownListFor(m => m.CentreId, new SelectList(ViewData.GetCentres(), "Id", "Name", Model.CentreId), "Please choose")%>
		</p>
		<p>
			<label for="StartDate">
				Start Date:</label>
			<%= Html.TextBox("StartDate", String.Format("{0:d}", Model.StartDate), new { @class = "st-date" })%>
		</p>
		<p>
			<label for="EndDate">
				End Date:</label>
			<%= Html.TextBox("EndDate", String.Format("{0:d}", Model.EndDate), new { @class = "st-date" })%>
		</p>
		<p>
			<label for="TutorId">
				Tutor:</label>
			<%= Html.DropDownListFor(m => m.TutorId, new SelectList(ViewData.GetTutors(), "Id", "Person.Name", Model.TutorId), "Please choose")%>
		</p>
		<p>
			<label for="VerifierId">
				Verifier:</label>
			<%= Html.DropDownListFor(m => m.VerifierId, new SelectList(ViewData.GetVerifiers(), "Id", "Person.Name", Model.VerifierId), "Please choose")%>
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
		<div id="Accordion">
			<% foreach (CourseStudentViewModel student in Model.Students)
			{ %>
			<h3>
				<a href="#">
					<%= student.Name + " - " + student.Address%></a></h3>
			<div>
				<div style="float: left">
					<table class="st-table">
						<tr>
							<th>
								Sessions
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
								Html.CheckBox("CheckBox", studentSession.Completed, new { onClick = "updateSessionComplete(" + Model.Id + "," + student.Id + "," + studentSession.SessionId + "," + (!studentSession.Completed).ToString().ToLowerInvariant() + ");" })%>
							</td>
						</tr>
						<%} %>
						<tr>
							<th>
								Modules
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
								Html.CheckBox("CheckBox", studentModule.Completed, new { onClick = "updateModuleComplete(" + Model.Id + "," + student.Id + "," + studentModule.ModuleId + "," + (!studentModule.Completed).ToString().ToLowerInvariant() + ");" })%>
							</td>
						</tr>
						<%} %>
					</table>
				</div>
				<div style="float: left">
					<ul>
						<li>
							<%= Ajax.ShowDetailsActionLink("Student", student.Id, "DetailsDialog", "ShowDetailsDialog")%>
						</li>
					</ul>
				</div>
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
			<input type="submit" value="Add" class="st-button" />
		</p>
		<%} %>
	</fieldset>
	<% } %>
	<p>
		<%=Html.ActionLink("Back to List", "Index", null, new { @class = "st-back-button" })%>
	</p>
	<div id="DetailsDialog">
	</div>
	<script type="text/javascript">
		function updateSessionComplete(courseId, studentId, sessionId, complete) {
			$.ajax(
			{
				type: "POST",
				url: "/Course/UpdateSessionComplete",
				data: "courseId=" + courseId + "&studentId=" + studentId + "&sessionId=" + sessionId + "&complete=" + complete,
				success: function (result) { /* Should do something here */ }
			});
		}
		function updateModuleComplete(courseId, studentId, moduleId, complete) {
			$.ajax(
			{
				type: "POST",
				url: "/Course/UpdateModuleComplete",
				data: "courseId=" + courseId + "&studentId=" + studentId + "&moduleId=" + moduleId + "&complete=" + complete,
				success: function (result) { /* Should do something here */ }
			});
		}
	</script>
</asp:Content>
