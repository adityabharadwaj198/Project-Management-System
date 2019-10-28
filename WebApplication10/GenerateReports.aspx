<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GenerateReports.aspx.cs" Inherits="WebApplication10.GenerateReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Functionalities" runat="server">
    <br />
&nbsp;&nbsp;&nbsp;
    </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
    <asp:Label ID="Label7" runat="server" Text="Specify title"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false">
        <Columns>
                <asp:BoundField DataField="Id" HeaderText="Project ID" />
                <asp:BoundField DataField="title" HeaderText="Title" />
            <asp:BoundField DataField="duration" HeaderText="Project duration" />
            <asp:BoundField DataField="client" HeaderText="Client" />
            </Columns>
    </asp:GridView>
    <asp:Button ID="Button1" runat="server" Text="Generate" OnClick="Button1_Click" />
    <asp:BulletedList ID="BulletedList1" runat="server">
    </asp:BulletedList>
    </asp:Content>
