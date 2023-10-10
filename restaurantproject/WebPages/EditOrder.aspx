<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Navigation.Master" CodeBehind="EditOrder.aspx.cs" Inherits="restaurantproject.WebPages.EditOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="master" runat="server">
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
     <link rel="stylesheet" href="/Styles/Customer.css">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
<title>Edit Order</title>
</head>
<body>
<form id="form1" runat="server">
<div>
<h1>Edit Order</h1>
    <asp:HiddenField ID="hdnOrderID" runat="server" />
<br />
<asp:Label ID="lblCustomer" runat="server" Text="Name:"></asp:Label>
<br />
<asp:Label ID="txtCustomer" runat="server" Width="400px"></asp:Label>
<br />
<asp:Label ID="lblDate" runat="server" Text="Order Date:"></asp:Label>
<br />
<asp:Label ID="txtDate" runat="server" Width="400px"></asp:Label>
<%--<br />
  <asp:DropDownList ID="ddldelivery" runat="server" >  

    <asp:ListItem Value="">Select Delivery Status</asp:ListItem>

    <asp:ListItem>Order Pending</asp:ListItem>

    <asp:ListItem>Out For Delivery</asp:ListItem>

    <asp:ListItem>Delivered</asp:ListItem>

</asp:DropDownList>--%>

    <br />
          <asp:DropDownList ID="ddlpayment" runat="server" >  

            <asp:ListItem Value="">Select Payment Method</asp:ListItem>

            <asp:ListItem>COD</asp:ListItem>

            <asp:ListItem>Credit Card</asp:ListItem>

            <asp:ListItem>Debit Card</asp:ListItem>

        </asp:DropDownList>
<br /><br />
<p />
<asp:Button ID="btnOK" runat="server" onClick="btnOK_Click" Text="OK" />
<asp:Button ID="btnCancel" runat="server" onClick="btnCancel_Click" Text="Cancel" />
</div>
</form>
</body>
</html>
    </asp:Content>