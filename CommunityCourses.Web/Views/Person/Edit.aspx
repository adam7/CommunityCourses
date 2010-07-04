<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CommunityCourses.Web.Model.Person>" %>

<%@ Import Namespace="CommunityCourses.Web.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit Student
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		Edit Student</h2>
	<% Html.EnableClientValidation(); %>
	<% 
		using (Html.BeginForm())
		{
			Html.RenderPartial("Form");
			Html.RenderPartial("~/Views/Address/Form.ascx", Model.Address);
	%>
	<p>
		<input type="submit" value="Save" class="st-button" />
		<%=Html.ActionLink("Back to List", "Index", null, new { @class = "st-back-button" })%>
	</p>
	<%}%>
</asp:Content>
