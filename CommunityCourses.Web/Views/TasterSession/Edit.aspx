<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CommunityCourses.Data.Model.TasterSession>" %>
<%@ Import Namespace="CommunityCourses.Data.Model" %>
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
        Date:</label>
      <%= Html.TextBox("DateAndTime", String.Format("{0:d}", Model.DateAndTime), new { @class = "st-date" })%>
    </p>
    <p>
      <input type="submit" value="Save" class="st-button" />
    </p>
  </fieldset>
  <%= Html.ClientSideValidation<TasterSession>()%>
  <% }
		 if (Model.Id != 0)
		 { %>
	<fieldset>
		<legend>Students</legend>
		<table class="st-table">		
		<tr>
			<th>
			</th>
			<th>
				Name
			</th>
			<th>
				Address
			</th>
			<th>
				Phone
			</th>
			<th>
				Mobile
			</th>
			<th>
				Email
			</th>
		</tr>
		<%foreach (Student student in Model.Students)
		{ %>
		<tr>
			<td>
				<%= Ajax.ShowDetailsActionLink("Student", student.Id, "DetailsDialog", "ShowDetailsDialog")%>
			</td>
			<td>
				<%= Html.Encode(student.Person.Name)%>
			</td>
			<td>
				<%= Html.Encode(student.Person.Address.ToSingleLine())%>
			</td>
			<td>
				<%= Html.Encode(student.Person.Phone)%>
			</td>
			<td>
				<%= Html.Encode(student.Person.Mobile)%>
			</td>
			<td>
				<%= Html.Encode(student.Person.Email)%>
			</td>
		</tr>
		<%
		} %>
		</table>
		<% using (Html.BeginForm("AddStudent", "TasterSession"))
		 { %>
		<%= Html.Hidden("Id", Model.Id)%>
		<p>
			<label for="AddStudentId">
				Student:</label>
			<%= Html.DropDownList("StudentId", new SelectList(ViewData.GetPotentialStudents(), "Id", "Person.Name"), "Please choose")%>
			<input type="submit" value="Add" class="st-button" />
		</p>
		<%} %>
	</fieldset>
	<%} %>	
	<div id="DetailsDialog">
	</div>
	<p>
		<%=Html.ActionLink("Back to List", "Index", null, new { @class = "st-back-button" })%>
	</p>
</asp:Content>
