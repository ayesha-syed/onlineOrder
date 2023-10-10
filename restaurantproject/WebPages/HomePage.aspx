<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
     <link rel="stylesheet" href="/Styles/Customer.css">
    <title>Home</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Home</h1>
            <br />
        </div>
         <p>
            <asp:Button ID="btnCustomers" runat="server" Text="View Customers" onClick="btnCustomer_Click" style="margin-bottom: 0px" />
        </p>
         <p>
    <asp:Button ID="btnOrders" runat="server" Text="View Orders" onClick="btnOrder_Click" style="margin-bottom: 0px" />
</p>
<p>
    <asp:Button ID="btnCategory" runat="server" Text="View Category" onClick="btnCategory_Click" style="margin-bottom: 0px" />
</p>
        <p>
    <asp:Button ID="btnMenu" runat="server" Text="View Menu" onClick="btnMenu_Click" style="margin-bottom: 0px" />
</p>
                <p>
    <asp:Button ID="btnOrderDetails" runat="server" Text="View Order Details" onClick="btnOrderDetails_Click" style="margin-bottom: 0px" />
</p>

    </form>
</body>
</html>
