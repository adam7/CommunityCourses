<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<StudentTracking.Data.Model.Student>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>
    <% Html.RenderPartial("~/Views/Person/Details.ascx", Model.Person); %>
    <p>
        <%=Html.ActionLink("Edit", "Edit", new { id=Model.Id  }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>
