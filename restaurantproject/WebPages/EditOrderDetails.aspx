
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Navigation.Master" CodeBehind="EditOrderDetails.aspx.cs" Inherits="restaurantproject.WebPages.EditOrderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="master" runat="server">
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
     <link rel="stylesheet" href="/Styles/Customer.css">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
<title>Add Or Remove Items</title>
</head>
<body>
<form id="form1" runat="server">
<div>
<h1>Add Or Remove Items</h1>
        <asp:HiddenField ID="hdnOrderID" runat="server" />
<br />
<asp:DropDownList ID="ddlItem" runat="server" Width="300px" DataTextField="item_name" DataValueField="item_id"></asp:DropDownList>
<br />
<asp:Label ID="lblQuantity" runat="server" Text="Quantity:"></asp:Label>
<br />
<asp:Label ID="txtQuantity" runat="server" Width="300px"></asp:Label>
<%--<br />
  <asp:DropDownList ID="ddldelivery" runat="server" >  

    <asp:ListItem Value="">Select Delivery Status</asp:ListItem>

    <asp:ListItem>Order Pending</asp:ListItem>

    <asp:ListItem>Out For Delivery</asp:ListItem>

    <asp:ListItem>Delivered</asp:ListItem>

</asp:DropDownList>--%>
<br />
<p />
<asp:Button ID="btnOK" runat="server" onClick="btnOK_Click" Text="OK" />
<asp:Button ID="btnCancel" runat="server" onClick="btnCancel_Click" Text="Cancel" />
</div>
</form>
</body>
</html>
    </asp:Content>