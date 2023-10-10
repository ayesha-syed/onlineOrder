<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Navigation.Master"  CodeBehind="EditCategory.aspx.cs" Inherits="restaurantproject.WebPages.EditCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="master" runat="server">
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
     <link rel="stylesheet" href="/Styles/Customer.css">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
<title>Edit Category</title>
</head>
<body>
<form id="form1" runat="server">
<div>
<h1>Edit Category</h1>
<asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
<br />
<asp:TextBox ID="txtName" runat="server" Width="400px"></asp:TextBox>
<br />

<p />
<asp:Button ID="btnOK" runat="server" onClick="btnOK_Click" Text="OK" />
<asp:Button ID="btnCancel" runat="server" onClick="btnCancel_Click" Text="Cancel" />
</div>
</form>
</body>
</html>
    </asp:Content>