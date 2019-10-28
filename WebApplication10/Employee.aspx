<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="WebApplication10.Employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label5" runat="server" Text="Project ID"></asp:Label>
<asp:TextBox ID="TextBox3" runat="server" Height="22px" style="margin-bottom: 0px" Width="131px"></asp:TextBox>
<asp:Label ID="Label7" runat="server" Text="Comment"></asp:Label>
<asp:TextBox ID="TextBox5" runat="server" Width="278px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="Signout" runat="server" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>
&nbsp;<p>
    <asp:Label ID="Label4" runat="server" Text="Employee ID"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <asp:Label ID="Label6" runat="server" Text="Project Title"></asp:Label>
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    <asp:Label ID="Label8" runat="server" Text="Time Stamp"></asp:Label>
    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save Comment" />
</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="Label9" runat="server" Text="Enter Project ID to view comments:"></asp:Label>
        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
</p>
    <p>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Show comments" />
</p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="employeeID" HeaderText="Employee ID" />
                <asp:BoundField DataField="comment" HeaderText="Comment" />
            </Columns>
        </asp:GridView>
</p>
    <p>
        &nbsp;</p>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" ID ="content3" runat ="server">

    <asp:Label ID="Label10" runat="server" Text="Number of times project revised"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
</asp:Content>
