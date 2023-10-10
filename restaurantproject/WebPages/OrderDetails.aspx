<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Navigation.Master" CodeBehind="OrderDetails.aspx.cs" Inherits="OrderDetailsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="master" runat="server">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
       <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
     <link rel="stylesheet" href="/Styles/Customer.css">
    <title>Orders Details</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Orders Details
                                 <a href="#" class="btn btn-success float-end"  onclick="addOrderDetails();">
    <span class="glyphicon glyphicon-plus"></span> 
</a>
            </h1>



            <asp:GridView ID="gridOrderDetailsList" runat="server"></asp:GridView>
            <br />
        </div>
         <p>
            <asp:Button ID="btnNewOrderDetails" runat="server" Text="Add Details" onClick="btnNewOrderDetails_Click" style="margin-bottom: 0px" />
        </p>
         <p>
    <asp:Button ID="btnEditOrderDetails" runat="server" Text="Edit Details" onClick="btnEditOrderDetails_Click" style="margin-bottom: 0px" />
</p>
                 <p>
    <asp:Button ID="btnDeleteOrderDetails" runat="server" Text="Delete Details" onClick="btnDeleteOrderDetails_Click" style="margin-bottom: 0px" />
</p>
                  <script>
              function addOrderDetails() {
                  window.location.href = "AddOrderDetails.aspx";
              }
                  </script>
    </form>
</body>
</html>
</asp:Content>