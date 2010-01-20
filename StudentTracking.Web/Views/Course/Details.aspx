<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<StudentTracking.Data.Model.Course>" %>

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
            Unit:
            <%= Html.Encode(Model.Unit.Name) %>
        </p>
        <p>
            Centre:
            <%= Html.Encode(Model.Centre.Name) %>
        </p>
        <p>
            Start Date:
            <%= Html.Encode(String.Format("{0:g}", Model.StartDate)) %>
        </p>
        <p>
            Tutor:
            <%= Html.Encode(Model.Tutor.Person.Name) %>
        </p>
        <p>
            Verifier:
            <%= Html.Encode(Model.Verifier.Person.Name) %>
        </p>
    </fieldset>
    <p>
        <%=Html.ActionLink("Edit", "Edit", new {  id=Model.Id }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

