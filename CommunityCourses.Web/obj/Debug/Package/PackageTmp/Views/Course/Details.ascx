<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CommunityCourses.Web.ViewModel.CourseViewModel>" %>
<%@ Import Namespace="CommunityCourses.Web.Model" %>
<fieldset>
	<p>
		Name:
		<%: Model.Name %>
	</p>
	<p>
		Unit:
		<%: Model.Unit.Name%>
	</p>
	<p>
		Centre:
		<%: Model.Centre.Name %>
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
		<%: Model.Tutor.Name %>
	</p>
	<p>
		Verifier:
		<%: Model.Verifier.Name %>
	</p>
	<h3>Students</h3>
	<ul>
	<% foreach (Person student in Model.Students)
		{ %>
			<li><%: student.Name %></li>
	<%} %>
	</ul>
</fieldset>
