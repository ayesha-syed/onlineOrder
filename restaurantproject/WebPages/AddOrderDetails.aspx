<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Navigation.Master" CodeBehind="AddOrderDetails.aspx.cs" Inherits="restaurantproject.WebPages.AddOrderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="master" runat="server">
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
     <link rel="stylesheet" href="/Styles/Customer.css">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
<title>Add Details</title>
</head>
<body>
<form id="form1" runat="server">
<div>
<h1>Add Details</h1>
<%--    <br />
<asp:DropDownList ID="ddlOrder" runat="server" Width="300px" DataTextField="order_id" DataValueField="order_id"></asp:DropDownList>
<br />--%>
    <%--<asp:Label ID="Name" runat="server" Text="Name"></asp:Label>
<br />
<asp:TextBox ID="lblName" runat="server" Width="300px"></asp:TextBox>--%>

    <asp:Label ID="Item" runat="server" Text="Item:"></asp:Label>
<asp:DropDownList ID="ddlMenu" runat="server" Width="200px" DataTextField="item_id" DataValueField="item_id"></asp:DropDownList>
<br />
    <asp:Label ID="lblQuantity" runat="server" Text="Quantity:"></asp:Label>
<br />
<asp:TextBox ID="txtQuantity" runat="server" Width="300px"></asp:TextBox><br />
<p /><br />
<asp:Button ID="btnOK" runat="server" onClick="btnOK_Click" Text="OK" />
<asp:Button ID="btnCancel" runat="server" onClick="btnCancel_Click" Text="Cancel" />
</div>
</form>
</body>
</html>
    </asp:Content>