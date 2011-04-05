<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CommunityCourses.Web.Model.Centre>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit centre
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		Edit centre</h2>
	<% Html.EnableClientValidation(); %>
	<% using (Html.BeginForm())
		{%>
	<fieldset>
		<legend>Centre</legend>
		<p>
			<%= Html.LabelFor(m => m.Name) %>
			<%= Html.TextBoxFor(m => m.Name) %>
			<%= Html.ValidationMessageFor(m => m.Name) %>
		</p>
		<p>
			<%= Html.LabelFor(m => m.Phone) %>
			<%= Html.TextBoxFor(m => m.Phone)%>
			<%= Html.ValidationMessageFor(m => m.Phone)%>
		</p>
		<%--    <p>
      <label for="ContactId">
        ContactId:</label>
      <%= Html.TextBox("ContactId") %>
    </p>--%>
	</fieldset>
	<% Html.RenderPartial("~/Views/Address/Form.ascx", Model.Address ?? new CommunityCourses.Web.Model.Address()); %>
	<p>
		<input type="submit" value="Save" class="st-button" />
	</p>
	<p>
		<%=Html.ActionLink("Back to List", "Index", null, new { @class = "st-back-button" }) %>
	</p>
	<% } %>
</asp:Content>
