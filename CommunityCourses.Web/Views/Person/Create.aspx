<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CommunityCourses.Data.Person>" %>

<%@ Import Namespace="xVal.Rules" %>
<%@ Import Namespace="CommunityCourses.Web.ViewModel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
  Create person
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h2>
    Create person</h2>
  <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
  <% using (Html.BeginForm())
     {%>
  <fieldset>
    <legend>Fields</legend>
    <p>
      <label for="Id">
        Id:</label>
      <%= Html.TextBox("Id") %>
    </p>
    <p>
      <label for="Title">
        Title:</label>
      <%= Html.TextBox("Title") %>
    </p>
    <p>
      <label for="FirstName">
        FirstName:</label>
      <%= Html.TextBox("FirstName") %>
    </p>
    <p>
      <label for="LastName">  
        LastName:</label>
      <%= Html.TextBox("LastName") %>
    </p>
    <p>
      <label for="AddressId">
        AddressId:</label>
      <%= Html.TextBox("AddressId") %>
    </p>
    <p>
      <label for="Phone">
        Phone:</label>
      <%= Html.TextBox("Phone") %>
    </p>
    <p>
      <label for="Mobile">
        Mobile:</label>
      <%= Html.TextBox("Mobile") %>
    </p>
    <p>
      <label for="Email">
        Email:</label>
      <%= Html.TextBox("Email") %>
    </p>
    <p>
      <label for="Notes">
        Notes:</label>
      <%= Html.TextBox("Notes") %>
    </p>
    <p>
      <label for="DateOfBirth">
        DateOfBirth:</label>
      <%= Html.TextBox("DateOfBirth") %>
    </p>
    <p>
      <label for="DisabilityId">
        DisabilityId:</label>
      <%= Html.TextBox("DisabilityId") %>
    </p>
    <p>
      <label for="EthnicityId">
        EthnicityId:</label>
      <%= Html.TextBox("EthnicityId") %>
    </p>
    <p>
      <label for="GenderId">
        GenderId:</label>
      <%= Html.TextBox("GenderId") %>
    </p>
    <p>
      <input type="submit" value="Create" />
    </p>
  </fieldset>
  <% } %>
  <%= Html.ClientSideValidation<PersonViewModel>() %>
  <div>
    <%=Html.ActionLink("Back to List", "Index", null, new { @class = "st-back-button" })%>
  </div>
</asp:Content>
