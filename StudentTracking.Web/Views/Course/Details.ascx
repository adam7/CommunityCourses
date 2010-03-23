<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<StudentTracking.Web.ViewModel.CourseViewModel>" %>
<fieldset>
	<p>
		Name:
		<%= Html.Encode(Model.Name) %>
	</p>
	<p>
		Unit:
		<%= Html.Encode(Model.UnitName) %>
	</p>
	<p>
		Centre:
		<%= Html.Encode(Model.CentreName) %>
	</p>
	<p>
		Start Date:
		<%= Html.Encode(String.Format("{0:d}", Model.StartDate)) %>
	</p>
	<p>
		Tutor:
		<%= Html.Encode(Model.TutorPersonName) %>
	</p>
	<p>
		Verifier:
		<%= Html.Encode(Model.VerifierPersonName) %>
	</p>
</fieldset>
