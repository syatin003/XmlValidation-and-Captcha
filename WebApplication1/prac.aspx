<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prac.aspx.cs" Inherits="WebApplication1.prac" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <form id="form1" runat="server">
    <div>
    Title:
        <asp:TextBox ID="txttitle" runat="server" ></asp:TextBox><br />
    Author:
        <asp:TextBox ID="txtauthor" runat="server"></asp:TextBox><br />
    Year:
        <asp:TextBox ID="txtyear" runat="server"></asp:TextBox><br />
    Price:
        <asp:TextBox ID="txtprice" runat="server"></asp:TextBox><br />
    Email:
        <asp:TextBox ID="txtemail" runat="server"></asp:TextBox><br />

        <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" /><br />
          <asp:GridView ID="GridView1" runat="server">

        </asp:GridView><br />

          <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
