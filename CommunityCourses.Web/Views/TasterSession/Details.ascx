<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CommunityCourses.Web.Model.TasterSession>" %>
<fieldset>
	<p>
		Name:
		<%: Model.Name %>
	</p>
	<p>
		Centre:
		<%: Model.Centre.Name %>
	</p>
	<p>
		Tutor:
		<%: Model.Tutor.Name %>
	</p>
	<p>
		Date And Time:
		<%: String.Format("{0:g}", Model.DateAndTime) %>
	</p>
</fieldset>
