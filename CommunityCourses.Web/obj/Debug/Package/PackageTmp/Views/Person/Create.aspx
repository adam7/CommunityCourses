<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CommunityCourses.Web.Model.Person>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		Create</h2>
	<% Html.EnableClientValidation(); %>
	<% 
    using (Html.BeginForm())
    {
			Html.RenderPartial("Form");
			Html.RenderPartial("~/Views/Address/Form.ascx", Model.Address);
    } 
	%>
</asp:Content>
