<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<StudentTracking.Data.Model.Centre>" %>
<%@ Import Namespace="xVal.Rules" %>
<%@ Import Namespace="StudentTracking.Data.Model" %>
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
    <%= Html.Hidden("Id") %>
    <p>
      <label for="Name">
        Name:</label>
      <%= Html.TextBox("Name") %>
    </p>
    <p>
      <label for="Phone">
        Phone:</label>
      <%= Html.TextBox("Phone") %>
    </p>
    <p>
      <label for="ContactId">
        ContactId:</label>
      <%= Html.TextBox("ContactId") %>
    </p>
  </fieldset>
  <% Html.RenderPartial("~/Views/Address/Form.ascx", Model.Address ?? new Address()); %>
  <p>
    <input type="submit" value="Save" />
  </p>
  <% } %>
  <%= Html.ClientSideValidation<Centre>()%>
  <div>
    <%=Html.ActionLink("Back to List", "Index") %>
  </div>
</asp:Content>
