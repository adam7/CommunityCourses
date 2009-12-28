<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<StudentTracking.Data.Model.Student>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
  Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h2>
    Create</h2>
  <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
  <% 
    using (Html.BeginForm())
    {
      Html.RenderPartial("~/Views/Person/Form.ascx", Model.Person);
    } 
  %>
</asp:Content>
