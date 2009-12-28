<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<StudentTracking.Data.Model.Student>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
  List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h2>
    Students</h2>
  <% using (Html.BeginForm())
     {
       Html.RenderPartial(MVC.Student.Views.List);
       %>
  <p>
    <%= Html.ActionLink("Create New", "Create") %>
  </p>
  <% } %>
</asp:Content>
