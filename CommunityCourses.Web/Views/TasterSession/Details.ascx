<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CommunityCourses.Web.Model.TasterSession>" %>
<fieldset>
	<p>
		Name:
		<%: Model.Name %>
	</p>
	<p>
		Centre:
		<%: Model.CentreName %>
	</p>
	<p>
		Tutor:
		<%: Model.TutorName %>
	</p>
	<p>
		Date:
		<%: String.Format("{0:d}", Model.DateAndTime) %>
	</p>
</fieldset>
