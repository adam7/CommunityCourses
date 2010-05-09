<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<StudentTracking.Web.ViewModel.CourseViewModel>" %>
<fieldset>
	<p>
		Name:
		<%: Model.Name %>
	</p>
	<p>
		Unit:
		<%: Model.UnitName%>
	</p>
	<p>
		Centre:
		<%: Model.CentreName %>
	</p>
	<p>
		Start Date:
		<%: String.Format("{0:d}", Model.StartDate) %>
	</p>
	<p>
		End Date:
		<%: String.Format("{0:d}", Model.EndDate) %>
	</p>
	<p>
		Status:
		<%: Model.Status %>
	</p>
	<p>
		Tutor:
		<%: Model.TutorPersonName %>
	</p>
	<p>
		Verifier:
		<%: Model.VerifierPersonName %>
	</p>
<%--	<h3>Students</h3>
	<ul>
	<% foreach (CourseStudentViewModel student in Model.Students)
		{ %>
			<li><%: student.Name %></li>
	<%} %>
	</ul>--%>
</fieldset>
