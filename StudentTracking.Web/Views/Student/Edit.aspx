<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<StudentTracking.Data.Model.Student>" %>
<%@ Import Namespace="StudentTracking.Data.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
  Edit Student
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h2>
    Edit Student</h2>
  <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
  <% 
    using (Html.BeginForm())
    {
      Html.RenderPartial("~/Views/Person/Form.ascx", Model.Person ?? new Person());
    }
  %>
</asp:Content>
