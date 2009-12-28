<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<StudentTracking.Model.Person>" %>
<%@ Import Namespace="StudentTracking.Web.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="Id">Id:</label>
                <%= Html.TextBox("Id", Model.Id) %>
                <%= Html.ValidationMessage("Id", "*") %>
            </p>
            <p>
                <label for="Title">Title:</label>
                <%= Html.TextBox("Title", Model.Title) %>
                <%= Html.ValidationMessage("Title", "*") %>
            </p>
            <p>
                <label for="FirstName">FirstName:</label>
                <%= Html.TextBox("FirstName", Model.FirstName) %>
                <%= Html.ValidationMessage("FirstName", "*") %>
            </p>
            <p>
                <label for="LastName">LastName:</label>
                <%= Html.TextBox("LastName", Model.LastName) %>
                <%= Html.ValidationMessage("LastName", "*") %>
            </p>
            <p>
                <label for="AddressId">AddressId:</label>
                <%= Html.TextBox("AddressId", Model.AddressId) %>
                <%= Html.ValidationMessage("AddressId", "*") %>
            </p>
            <p>
                <label for="Phone">Phone:</label>
                <%= Html.TextBox("Phone", Model.Phone) %>
                <%= Html.ValidationMessage("Phone", "*") %>
            </p>
            <p>
                <label for="Mobile">Mobile:</label>
                <%= Html.TextBox("Mobile", Model.Mobile) %>
                <%= Html.ValidationMessage("Mobile", "*") %>
            </p>
            <p>
                <label for="Email">Email:</label>
                <%= Html.TextBox("Email", Model.Email) %>
                <%= Html.ValidationMessage("Email", "*") %>
            </p>
            <p>
                <label for="Notes">Notes:</label>
                <%= Html.TextBox("Notes", Model.Notes) %>
                <%= Html.ValidationMessage("Notes", "*") %>
            </p>
            <p>
                <label for="DateOfBirth">DateOfBirth:</label>
                <%= Html.TextBox("DateOfBirth", String.Format("{0:g}", Model.DateOfBirth)) %>
                <%= Html.ValidationMessage("DateOfBirth", "*") %>
            </p>
            <p>
                <label for="DisabilityId">Disability:</label>
                <%= Html.DropDownList("DisabilityId", ViewData[ViewDataHelper.Disabilities] as SelectList, "Please choose") %>
                <%= Html.ValidationMessage("DisabilityId", "*") %>
            </p>
            <p>
                <label for="EthnicityId">EthnicityId:</label>
                <%= Html.DropDownList("EthnicityId", ViewData[ViewDataHelper.Ethnicities] as SelectList, "Please choose") %>
                <%= Html.ValidationMessage("EthnicityId", "*") %>
            </p>
            <p>
                <label for="GenderId">Gender:</label>
                <%= Html.DropDownList("GenderId", ViewData[ViewDataHelper.Genders] as SelectList, "Please choose") %>
                <%= Html.ValidationMessage("GenderId", "*") %>
            </p>
        </fieldset>
        <% Html.RenderPartial("~/Views/Address/Edit.ascx", Model.Address); %>

            <p>
                <input type="submit" value="Save" />
            </p>
    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

