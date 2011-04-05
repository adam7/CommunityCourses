<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CommunityCourses.Web.Model.TasterSession>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
  Edit Taster Session
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h2>
    Edit Taster Session</h2>
  <% using (Html.BeginForm())
     {%>
	<% Html.EnableClientValidation(); %>
  <fieldset>
    <p>
			<%= Html.LabelFor(m => m.Name) %>
			<%= Html.TextBoxFor(m => m.Name) %>
			<%= Html.ValidationMessageFor(m => m.Name) %>
    </p>
    <p>
			<%= Html.LabelFor(m => m.CentreId)%>
			<%= Html.DropDownListFor(m => m.CentreId, new SelectList(ViewData.GetCentres(), "Id", "Name"), "Please choose") %>
			<%= Html.ValidationMessageFor(m => m.CentreId)%>
    </p>
    <p>
			<%= Html.LabelFor(m => m.TutorId)%>
			<%= Html.DropDownListFor(m => m.TutorId, new SelectList(ViewData.GetTutors(), "Id", "Name"), "Please choose")%>
			<%= Html.ValidationMessageFor(m => m.TutorId)%>
    </p>
    <p>
			<%= Html.LabelFor(m => m.DateAndTime) %>
			<%= Html.TextBoxFor(m => m.DateAndTime, new { @class = "st-date" })%>
			<%= Html.ValidationMessageFor(m => m.DateAndTime) %>
    </p>
    <p>
      <input type="submit" value="Save" class="st-button" />
    </p>
  </fieldset>
  <% }
		 if (Model.Id != null)
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
		<%foreach (Person student in Model.Students)
		{ %>
		<tr>
			<td>
				<%= Ajax.ShowDetailsActionLink("Student", student.Id, "DetailsDialog", "ShowDetailsDialog") %>
			</td>
			<td>
				<%: student.Name %>
			</td>
			<td>
				<%: student.Address.ToSingleLine() %>
			</td>
			<td>
				<%: student.Phone %>
			</td>
			<td>
				<%: student.Mobile %>
			</td>
			<td>
				<%: student.Email %>
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
			<%= Html.DropDownList("StudentId", new SelectList(ViewData.GetPotentialStudents(), "Id", "Name"), "Please choose")%>
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
