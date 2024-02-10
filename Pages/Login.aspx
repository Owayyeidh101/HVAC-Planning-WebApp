<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HVAC_Planning_WebApp.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="Login" runat="server">
        <div>
            <h1>LOGIN PAGE</h1>

            <div>
                <h2>Login Here</h2>
                <asp:Label ID="StatusLabel" runat="server" Text=""></asp:Label>
                <p>Username</p>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                <p>Password</p>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

                <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
                <p>Don't have an account?</p>
                <a href="Register.aspx">Register Here!</a>
            </div>
        </div>
    </form>
</body>
</html>
