<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="HVAC_Planning_WebApp.Pages.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
</head>
<body>
    <form id="Register" runat="server">
        <div>
            <h1>REGISTRATION PAGE</h1>
            
            <div>
                <h2>Register Here</h2>
                <asp:Label ID="StatusLabel" runat="server" Text=" "></asp:Label>
                <p>Enter Username</p>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                <p>Enter Password</p>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

                <p>Enter Email Address</p>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>

                <!-- Add the OnClick attribute to wire the button click to the event handler -->
                <asp:Button ID="RegisterButton" runat="server" Text="Button" OnClick="RegisterButton_Click" />

                <p>Already a registered user?</p> <a href="Login.aspx">Login</a>
            </div>
        </div>
    </form>
</body>
</html>
