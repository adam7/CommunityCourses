<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<StudentTracking.Web.ViewModel.CentreViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            Name:
            <%= Html.Encode(Model.Name) %>
        </p>
        <p>
            Phone:
            <%= Html.Encode(Model.Phone) %>
        </p>
        <p>
            Address:
            <%= Html.Encode(Model.Address.FirstLine) %>
        </p>
        <%--<p>
            Contact:
            <%= Html.Encode(Model.ContactId) %>
        </p>--%>
    </fieldset>
    <p>
        <%=Html.ActionLink("Edit", "Edit", new { id = Model.Id }, new { @class = "st-button" })%>
        <%=Html.ActionLink("Back to List", "Index", null, new { @class = "st-back-button" })%>
    </p>

</asp:Content>

