<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CommunityCourses.Web.Model.Centre>" %>
<fieldset>
	<p>
		Name:
		<%: Model.Name %>
	</p>
	<p>
		Phone:
		<%: Model.Phone %>
	</p>
	<p>
		Address:
		<%: Model.Address.ToSingleLine() %>
	</p>
<%--	<p>
      Contact:
      <%: Model.ContactName %>
  </p>--%>
</fieldset>
