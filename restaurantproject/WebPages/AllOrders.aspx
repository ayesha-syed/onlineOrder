
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllOrders.aspx.cs" MasterPageFile="Navigation.Master" Inherits="AllOrdersList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="master" runat="server">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
     <link rel="stylesheet" href="/Styles/Customer.css">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
    <title>All Orders</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>All Orders
                  <asp:LinkButton runat="server" class="btn btn-success float-end" OnClick="btnNewOrder_Click">
    <span class="glyphicon glyphicon-plus"></span> 
</asp:LinkButton>
            </h1>

        <asp:HiddenField ID="hdnDetailsID" runat="server" />
            <h2 id="customerName" runat="server"></h2>
            <asp:GridView ID="gridAllOrdersList" runat="server" OnRowCommand="gridDetailsList_RowCommand" AutoGenerateColumns="false" DataKeyNames="order_id" CssClass="table-bordered">
    <Columns>
   
         <asp:BoundField DataField="order_id" HeaderText="Order Number" ItemStyle-CssClass="gridview-cell"/>
                <asp:BoundField DataField="order_date" HeaderText="Order Date" ItemStyle-CssClass="gridview-cell" />
<%--         <asp:BoundField DataField="delivery_status" HeaderText="Delivery Status" ItemStyle-CssClass="gridview-cell"/>--%>
        <asp:BoundField DataField="payment_method" HeaderText="Payment Method" ItemStyle-CssClass="gridview-cell"/>
           <asp:BoundField DataField="total_amount" HeaderText="Total Amount" ItemStyle-CssClass="gridview-cell"/>
    <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="gridview-cell">
    <ItemTemplate>
     <asp:Button ID="btnViewOrder" runat="server"  CommandName="ViewDetails" CommandArgument='<%# Eval("order_id") %>' Text="View Order" />
    </ItemTemplate>
</asp:TemplateField> 
                    <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="gridview-cell">
    <ItemTemplate>
     <asp:Button ID="btnEditOrder" runat="server"  CommandName="EditOrder" CommandArgument='<%# Eval("order_id") %>' Text="Edit" />
    </ItemTemplate>
</asp:TemplateField> 

            <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="gridview-cell">
    <ItemTemplate>
     <asp:Button ID="btnDeleteOrder" runat="server"  CommandName="DeleteOrder" CommandArgument='<%# Eval("order_id") %>' Text="Delete" />
    </ItemTemplate>
</asp:TemplateField> 
    </Columns>
</asp:GridView>
    
</div>

    </form>
              <script>
              function addOrder() {
                  window.location.href = "AddOrder.aspx";
              }
              </script>
</body>
    
</html>
</asp:Content>
