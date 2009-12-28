<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<StudentTracking.Data.Model.TasterSession>" %>

<%@ Import Namespace="xVal.Rules" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
  Edit Taster Session
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h2>
    Edit Taster Session</h2>
  <% using (Html.BeginForm())
     {%>
  <fieldset>
    <%= Html.Hidden("Id", Model.Id) %>
    <p>
      <label for="Name">
        Name:</label>
      <%= Html.TextBox("Name", Model.Name) %>
    </p>
    <p>
      <label for="CentreId">
        Centre:</label>
      <%= Html.DropDownList("CentreId", new SelectList(ViewData.GetCentres(), "Id", "Name"), "Please choose") %>
    </p>
    <p>
      <label for="TutorId">
        Tutor:</label>
      <%= Html.DropDownList("TutorId", new SelectList(ViewData.GetTutors(), "Id", "Person.Name"), "Please choose") %>
    </p>
    <p>
      <label for="DateAndTime">
        Date And Time:</label>
      <%= Html.TextBox("DateAndTime", String.Format("{0:g}", Model.DateAndTime)) %>
    </p>
    <p>
      <input type="submit" value="Save" />
    </p>
  </fieldset>
  <% } %>
  <%= Html.ClientSideValidation<StudentTracking.Data.Model.TasterSession>() %>
	<fieldset>
		<legend>Students</legend>
		<% Html.RenderPartial("~/Views/Student/List.ascx", Model.Students); %>
		<% using (Html.BeginForm("AddStudent", "TasterSession"))
		 { %>
		<%= Html.Hidden("Id", Model.Id) %>
		<p>
			<label for="AddStudentId">
				Student:</label>
			<%= Html.DropDownList("StudentId", new SelectList(ViewData.GetPotentialStudents(), "Id", "Person.Name"), "Please choose")%>
			<input type="submit" value="Add" />
		</p>
		<%} %>
	</fieldset>
	<div>
		<%=Html.ActionLink("Back to List", "Index") %>
		| <a href="">Add Student</a>
	</div>
</asp:Content>
