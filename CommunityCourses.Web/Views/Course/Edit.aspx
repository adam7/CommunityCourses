<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CommunityCourses.Web.ViewModel.CourseViewModel>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		Edit Course</h2>
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
			<label>
				Unit:&nbsp;<%: Model.Unit.Name %></label>
			<%: Html.HiddenFor(m => m.UnitId) %>
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
	<% for (int count = 0; count < Model.StudentIds.Count; count++)
		{ %>
	<%= Html.Hidden(string.Format("StudentIds[{0}]", count), Model.StudentIds[count]) %>
	<% } %>
	<% } %>
	<fieldset>
		<legend>Students</legend>
		<div id="Accordion">
			<% foreach (Person student in Model.Students)
			{ %>
			<h3>
				<a href="#">
					<%= student.Name + " - " + student.Address.ToSingleLine() %></a></h3>
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
						<% foreach (CourseSession studentSession in student.CourseSessions.Where(session => session.CourseId == Model.Id))
				 { %>
						<tr>
							<td>
								<%= studentSession.Name%>
							</td>
							<td>
								<%= 
								Html.CheckBox("CheckBox", studentSession.Complete, new { onClick = "updateSessionComplete('" + Model.Id + "','" + student.Id + "','" + studentSession.Name + "'," + (!studentSession.Complete).ToString().ToLower() + ");" })%>
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
						<% foreach (CourseModule studentModule in student.CourseModules.Where(module => module.CourseId == Model.Id))
				 { %>
						<tr>
							<td>
								<%= studentModule.Name%>
							</td>
							<td>
								<%= 
								Html.CheckBox("CheckBox", studentModule.Complete, new { onClick = "updateModuleComplete('" + Model.Id + "','" + student.Id + "','" + studentModule.Name + "'," + (!studentModule.Complete).ToString().ToLower() + ");" })%>
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
			<%= Html.DropDownList("StudentId", new SelectList(ViewData.GetPotentialStudents(), "Id", "Name"), "Please choose")%>
			<input type="submit" value="Add" class="st-button" />
		</p>
		<%} %>
	</fieldset>
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
