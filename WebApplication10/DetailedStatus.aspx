<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DetailedStatus.aspx.cs" Inherits="WebApplication10.DetailedStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Functionalities" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
            <asp:BoundField DataField="duration" HeaderText="duration" SortExpression="duration" />
            <asp:BoundField DataField="client" HeaderText="client" SortExpression="client" />
            <asp:BoundField DataField="commentsID" HeaderText="commentsID" InsertVisible="False" ReadOnly="True" SortExpression="commentsID" />
            <asp:BoundField DataField="employeeID" HeaderText="employeeID" SortExpression="employeeID" />
            <asp:BoundField DataField="projectID" HeaderText="projectID" SortExpression="projectID" />
            <asp:BoundField DataField="projectTitle" HeaderText="projectTitle" SortExpression="projectTitle" />
            <asp:BoundField DataField="comment" HeaderText="comment" SortExpression="comment" />
            <asp:BoundField DataField="timestamp" HeaderText="timestamp" SortExpression="timestamp" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Projects.Id, Projects.title, Projects.duration, Projects.client, Comments.commentsID, Comments.employeeID, Comments.projectID, Comments.projectTitle, Comments.comment, Comments.timestamp FROM Projects RIGHT OUTER JOIN Comments ON Projects.Id = Comments.projectID WHERE (Comments.projectID = @ProjectID)">
        <SelectParameters>
            <asp:QueryStringParameter DbType="Int32" Name="ProjectID" QueryStringField="ProjectID" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
