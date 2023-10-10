<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Navigation.Master" CodeBehind="EditCustomer.aspx.cs" Inherits="restaurantproject.WebPages.EditCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="master" runat="server">
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
     <link rel="stylesheet" href="/Styles/Customer.css">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
<title>Edit Customer</title>
</head>
<body>
<form id="form1" runat="server">
<div>
<h1>Edit Customer</h1>
    <br />
<asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
<br />
<asp:TextBox ID="txtName" runat="server" Width="400px"></asp:TextBox>
<br />
<asp:Label ID="LblAddress" runat="server" Text="Address:"></asp:Label>
<br />
<asp:TextBox ID="txtAddress" runat="server" Width="400px"></asp:TextBox>
<br />
<asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
<br />
<asp:TextBox ID="txtEmail" runat="server" Width="400px"></asp:TextBox>
<br />
<asp:Label ID="lblPhone" runat="server" Text="Phone:"></asp:Label>
<br />
<asp:TextBox ID="txtPhone" runat="server" Width="400px"></asp:TextBox>
<br />
        <asp:Label ID="errorMessageLabel" runat="server" ForeColor="Red"  Text=""></asp:Label>
<br /><br />
<p />
<asp:Button ID="btnOK" runat="server" onClick="btnOK_Click" Text="OK" />
<asp:Button ID="btnCancel" runat="server" onClick="btnCancel_Click" Text="Cancel" />
</div>
</form>
</body>
</html>
    </asp:Content>