<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CommunityCourses.Data.Model.TasterSession>" %>
<fieldset>
	<p>
		Name:
		<%= Html.Encode(Model.Name) %>
	</p>
	<p>
		Centre:
		<%= Html.Encode(Model.Centre.Name) %>
	</p>
	<p>
		Tutor:
		<%= Html.Encode(Model.Tutor.Person.Name) %>
	</p>
	<p>
		Date And Time:
		<%= Html.Encode(String.Format("{0:g}", Model.DateAndTime)) %>
	</p>
</fieldset>
