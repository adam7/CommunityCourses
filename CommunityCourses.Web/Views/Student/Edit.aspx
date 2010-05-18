<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CommunityCourses.Web.ViewModel.StudentViewModel>" %>

<%@ Import Namespace="CommunityCourses.Web.ViewModel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit Student
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		Edit Student</h2>
	<%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
	<% 
		using (Html.BeginForm())
		{
			Html.RenderPartial("~/Views/Person/Form.ascx", Model.Person ?? new PersonViewModel());
			Html.RenderPartial("~/Views/Address/Form.ascx", Model.Address ?? new AddressViewModel());
	%>
	<p>
		<input type="submit" value="Save" class="st-button" />
		<%=Html.ActionLink("Back to List", "Index", null, new { @class = "st-back-button" })%>
	</p>
	<%}%>	
</asp:Content>
