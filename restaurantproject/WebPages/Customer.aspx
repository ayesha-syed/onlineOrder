<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" MasterPageFile="Navigation.Master" Inherits="CustomerList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="master" runat="server">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
     <link rel="stylesheet" href="/Styles/Customer.css">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
    <title>Customers</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Customers
                <h2> <a href="#" class="btn btn-success float-end"  onclick="addCustomer();">
                    <span class="glyphicon glyphicon-plus"></span> 
                    </a></h2>  
            </h1>
            <br />
        <asp:HiddenField ID="hdnCustomerID" runat="server" />

            <asp:TextBox ID="txtSearch" runat="server" placeholder="Search By Phone Number"></asp:TextBox>

            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            <br />
            <br />
             <asp:TextBox ID="txtSearchEmail" runat="server" placeholder="Search By Email"></asp:TextBox>

 <asp:Button ID="btnSearchEmail" runat="server" Text="Search" OnClick="btnSearchEmail_Click" />
 <br /><br />
                          
            <asp:GridView ID="gridCustomerList" runat="server" OnRowCommand="gridCustomerList_RowCommand" AutoGenerateColumns="false" DataKeyNames="customer_id" CssClass="table-bordered">
    <Columns>
   
         <asp:BoundField DataField="customer_name" HeaderText="Name" ItemStyle-CssClass="gridview-cell"/>
        
        <asp:BoundField DataField="customer_address" HeaderText="Address" ItemStyle-CssClass="gridview-cell" />
         <asp:BoundField DataField="customer_email" HeaderText="Email" ItemStyle-CssClass="gridview-cell"/>
        <asp:BoundField DataField="customer_phone" HeaderText="Phone" ItemStyle-CssClass="gridview-cell"/>
        <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="gridview-cell">
            <ItemTemplate>
                <asp:Button ID="btnDeleteCustomer" runat="server" CommandName="DeleteCustomer" CommandArgument='<%# Eval("customer_id") %>' Text="Delete" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="gridview-cell">
    <ItemTemplate>
      <asp:Button ID="btnEditCustomer" runat="server" CommandName="UpdateCustomer" CommandArgument='<%# Eval("customer_id") %>' Text="Edit" />
    </ItemTemplate>
</asp:TemplateField>
                        <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="gridview-cell">
    <ItemTemplate>
     <asp:Button ID="btnViewOrd" runat="server" CommandName="ViewOrd" CommandArgument='<%# Eval("customer_id") %>' Text="View Orders" />
    </ItemTemplate>
</asp:TemplateField>
                <%--<asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="gridview-cell">
    <ItemTemplate>
     <asp:Button ID="btnView" runat="server" CommandName="ViewCustomerOrder" CommandArgument='<%# Eval("customer_id") %>' Text="View Orders" />
    </ItemTemplate>
</asp:TemplateField> --%>
    </Columns>
</asp:GridView>
   
</div>

    </form>
          <script>
              function addCustomer() {
                  window.location.href = "AddCustomer.aspx";
              }
          </script>
</body>
    
</html>
</asp:Content>
