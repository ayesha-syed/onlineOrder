<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Navigation.Master" CodeBehind="Category.aspx.cs" Inherits="CategoryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="master" runat="server">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
     <link rel="stylesheet" href="/Styles/Customer.css">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
    <title>Category</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Category

                                     <a href="#" class="btn btn-success float-end"  onclick="addCategory();">
        <span class="glyphicon glyphicon-plus"></span> 
    </a>
            </h1>
               <asp:HiddenField ID="hdnCategoryID" runat="server" />

            <asp:GridView ID="gridCategoryList" runat="server" OnRowCommand="gridCategoryList_RowCommand" AutoGenerateColumns="false" DataKeyNames="category_id" CssClass="table-bordered">
    <Columns>
   
         <asp:BoundField DataField="category_name" HeaderText="Name" ItemStyle-CssClass="gridview-cell"/>
        <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="gridview-cell">
            <ItemTemplate>
                <asp:Button ID="btnEditCategory" runat="server" CommandName="EditCategory" CommandArgument='<%# Eval("category_id") %>' Text="Edit" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="gridview-cell">
    <ItemTemplate>
      <asp:Button ID="btnDeleteCategory" runat="server" CommandName="DeleteCategory" CommandArgument='<%# Eval("category_id") %>' Text="Delete" />
    </ItemTemplate>
</asp:TemplateField>
 
    </Columns>
</asp:GridView>
    
</div>

          <script>
              function addCategory() {
                  window.location.href = "AddCategory.aspx";
              }
          </script>

    </form>
</body>
</html>
</asp:Content>