<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CommunityCourses.Web.ViewModel.CentreViewModel>" %>

<%@ Import Namespace="xVal.Rules" %>
<%@ Import Namespace="CommunityCourses.Web.ViewModel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit centre
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		Edit centre</h2>
	<% using (Html.BeginForm())
		{%>
	<fieldset>
		<legend>Centre</legend>
		<p>
			<label for="Name">
				Name:</label>
			<%= Html.TextBox("Name", Model.Name) %>
		</p>
		<p>
			<label for="Phone">
				Phone:</label>
			<%= Html.TextBox("Phone", Model.Phone) %>
		</p>
		<%--    <p>
      <label for="ContactId">
        ContactId:</label>
      <%= Html.TextBox("ContactId") %>
    </p>--%>
	</fieldset>
	<%= Html.ClientSideValidation<CentreViewModel>()%>
	<% Html.RenderPartial("~/Views/Address/Form.ascx", Model.Address ?? new AddressViewModel()); %>
	<p>
		<input type="submit" value="Save" class="st-button" />		
	</p>
	<p>
		<%=Html.ActionLink("Back to List", "Index", null, new { @class = "st-back-button" }) %>
	</p>
	<% } %>
</asp:Content>
