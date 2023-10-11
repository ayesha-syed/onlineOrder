<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewOrder.aspx.cs" MasterPageFile="Navigation.Master" Inherits="restaurantproject.WebPages.ViewCustomerOrder" %>


<asp:Content ID="Content1" ContentPlaceHolderID="master" runat="server">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
     <link rel="stylesheet" href="/Styles/Customer.css">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
    <title>View Order</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>View Order
                <asp:LinkButton runat="server" class="btn btn-success float-end" OnClick="btnNewOrder_Click">
    <span class="glyphicon glyphicon-plus"></span> 
</asp:LinkButton>
            </h1>
         <asp:HiddenField ID="hdnOrderID" runat="server" />
            <asp:GridView ID="gridViewOrderList" runat="server"  AutoGenerateColumns="false" DataKeyNames="customer_id" CssClass="table-bordered" >
    <Columns>
   

        <asp:BoundField DataField="item_name" HeaderText="Item" ItemStyle-CssClass="gridview-cell" />
        <asp:BoundField DataField="category_name" HeaderText="Category" ItemStyle-CssClass="gridview-cell"/>
         <asp:BoundField DataField="price" HeaderText="Price" ItemStyle-CssClass="gridview-cell"/>
        <asp:BoundField DataField="quantity" HeaderText="Quantity" ItemStyle-CssClass="gridview-cell"/>
    <%--    <asp:BoundField DataField="order_date" HeaderText="Order Date" ItemStyle-CssClass="gridview-cell"/>--%>
     <%--  <asp:BoundField DataField="delivery_status" HeaderText="Delivery Status" ItemStyle-CssClass="gridview-cell"/>--%>
<%--                        <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="gridview-cell">
    <ItemTemplate>
     <asp:Button ID="btnEditOrder" runat="server"  CommandName="EditOrderDetails" CommandArgument='<%# Eval("order_id") %>' Text="Edit" />
    </ItemTemplate>
</asp:TemplateField> 

            <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="gridview-cell">
    <ItemTemplate>
     <asp:Button ID="btnDeleteOrder" runat="server"  CommandName="DeleteOrderDetails" CommandArgument='<%# Eval("order_details_id") %>' Text="Delete" />
    </ItemTemplate>
</asp:TemplateField> --%>
 
    </Columns>
         
</asp:GridView>

<%--            <button id="btnBack" runat="server" onClick="btnBack_Click"></button>--%>
            
    
</div>

    </form>
              <script>
                  function add() {
                      window.location.href = "AddOrderDetails.aspx";
                  }
              </script>
</body>
    
</html>
</asp:Content>