<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication10.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Email&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <br />
            Password&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Password1" TextMode ="Password" runat="server" OnTextChanged="Password1_TextChanged"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Password must be 8 characters long with at least one digit from 0-9,</br>one upper case character, one lower case and one special character (@#$%*/\)" ForeColor ="Red" ValidationExpression ="((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%&*\/]).{8,8})" ControlToValidate ="Password1"></asp:RegularExpressionValidator>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" OnSelecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        &nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Already a member?</asp:LinkButton>
        </div>
    </form>
</body>
</html>
