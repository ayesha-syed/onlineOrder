<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Navigation.Master" CodeBehind="Menu.aspx.cs" Inherits="MenuList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="master" runat="server">

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
              <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
     <link rel="stylesheet" href="/Styles/Customer.css">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
    <title>Menu</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Menu
                                 <a href="#" class="btn btn-success float-end"  onclick="addMenu();">
    <span class="glyphicon glyphicon-plus"></span> 
</a>
            </h1>
        <asp:HiddenField ID="hdnMenuID" runat="server" />
            <asp:GridView ID="gridMenuList" runat="server" OnRowCommand="gridMenuList_RowCommand" AutoGenerateColumns="false" DataKeyNames="item_id" CssClass="table-bordered">
    <Columns>
   
         <asp:BoundField DataField="item_name" HeaderText="Name" ItemStyle-CssClass="gridview-cell"/>
        <asp:BoundField DataField="price" HeaderText="Price" ItemStyle-CssClass="gridview-cell" />
        <asp:BoundField DataField="category_name" HeaderText="Category" ItemStyle-CssClass="gridview-cell" />
<%--                <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="gridview-cell">
    <ItemTemplate>
      <asp:Button ID="btnEditItem" runat="server" CommandName="UpdateMenu" CommandArgument='<%# Eval("item_id") %>' Text="Edit" />
    </ItemTemplate>
</asp:TemplateField>--%>
        <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="gridview-cell">
            <ItemTemplate>
                <asp:Button ID="btnDeleteItem" runat="server" CommandName="DeleteItem" CommandArgument='<%# Eval("item_id") %>' Text="Delete" />
            </ItemTemplate>
        </asp:TemplateField>
        
    </Columns>
</asp:GridView>

</div>
    </form>
              <script>
              function addMenu() {
                  window.location.href = "AddMenu.aspx";
              }
              </script>
</body>
</html>
</asp:Content>