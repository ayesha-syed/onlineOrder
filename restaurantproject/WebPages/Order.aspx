<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Navigation.Master" CodeBehind="Order.aspx.cs" Inherits="OrderList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="master" runat="server">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
     <link rel="stylesheet" href="/Styles/Customer.css">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">

    <title>Orders</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Orders
                 <a href="#" class="btn btn-success float-end"  onclick="addOrder();">
                    <span class="glyphicon glyphicon-plus"></span> 
                </a>
            </h1>
             <asp:HiddenField ID="hdnOrderID" runat="server" />
                        <asp:GridView ID="gridOrderList" runat="server" OnRowCommand="gridOrderList_RowCommand" AutoGenerateColumns="false" DataKeyNames="order_id" CssClass="table-bordered">
    <Columns>
   
         <asp:BoundField DataField="customer_name" HeaderText="Name" ItemStyle-CssClass="gridview-cell"/>
        <asp:BoundField DataField="order_date" HeaderText="Order Date" ItemStyle-CssClass="gridview-cell" />
  <%--       <asp:BoundField DataField="delivery_status" HeaderText="Delivery Status" ItemStyle-CssClass="gridview-cell"/>--%>
        <asp:BoundField DataField="payment_method" HeaderText="Payment Method" ItemStyle-CssClass="gridview-cell"/>

        <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="gridview-cell">
            <ItemTemplate>
                <asp:Button ID="btnEditOrder" runat="server" CommandName="EditOrder" CommandArgument='<%# Eval("order_id") %>' Text="Edit" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="gridview-cell">
    <ItemTemplate>
      <asp:Button ID="btnDeleteOrder" runat="server" CommandName="DeleteOrder" CommandArgument='<%# Eval("order_id") %>' Text="Delete" />
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