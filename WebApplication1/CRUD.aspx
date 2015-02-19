<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="WebApplication1.CRUD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>


      <%--  <asp:ListView ID="ListView1" runat="server" >
            <LayoutTemplate>
                <table id="table1" runat="server">
                    <tr id="tr1" runat="server">
                        <td id="td1" runat="server">
                            <table id="itemPlaceContainer" runat="server" border="5" style="background-color:ButtonFace">
                                <tr id="tr2" runat="server" style="border-color:aliceblue">
                                    <th id="th1" runat="server">
                                         Edit/Cancel
                                    </th>
                                    <th id="th2" runat="server">
                                        ID
                                    </th>
                                    <th id="th3" runat="server">
                                        Title
                                    </th>
                                    <th id="th4" runat="server">
                                        Author
                                    </th>
                                    <th id="th5" runat="server">
                                        Year
                                    </th>
                                    <th id="th6" runat="server">
                                        Price
                                    </th>
                                    <th id="th7" runat="server">
                                        Email
                                    </th>
                                </tr>
                                <tr id="itemplace" runat="server">
                                </tr>
                            </table>
                         </td>
                    </tr>
                    <tr id="tr3" runat="server">
                        <td id="td2" runat="server">
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>--%>
    <asp:ListView ID="lvBook" runat="server" InsertItemPosition="LastItem" OnItemInserting="lvBook_ItemInserting"
            OnItemDeleting="lvBook_ItemDeleting" OnItemEditing="lvBook_ItemEditing"
            OnItemCanceling="lvBook_ItemCanceling" >
        <LayoutTemplate>
                <table id="Table1" runat="server">
                    <tr id="Tr1" runat="server">
                        <td id="Td1" runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                <tr id="Tr2" runat="server" style="">
                                    <th id="th1" runat="server">
                                         Edit/Cancel
                                    </th>
                                    <th id="th2" runat="server">
                                        ID
                                    </th>
                                    <th id="th3" runat="server">
                                        Title
                                    </th>
                                    <th id="th4" runat="server">
                                        Author
                                    </th>
                                    <th id="th5" runat="server">
                                        Year
                                    </th>
                                    <th id="th6" runat="server">
                                        Price
                                    </th>
                                    <th id="th7" runat="server">
                                        Email
                                    </th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="Tr3" runat="server">
                        <td id="Td2" runat="server" style="">
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td>
                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("Title") %>' />
                    </td>
                     <td>
                        <asp:Label ID="lblAuthor" runat="server" Text='<%# Bind("Author") %>' />
                    </td>
                     <td>
                        <asp:Label ID="lblYear" runat="server" Text='<%# Bind("Year") %>' />
                    </td>
                     <td>
                        <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("Price") %>' />
                    </td>
                      <td>
                        <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    </td>
                    <td>
                         
                    </td>
                    <td>
                        <asp:TextBox ID="txtID" runat="server" Text='<%# Bind("ID") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("Title") %>' />
                    </td>
                     <td>
                        <asp:TextBox ID="txtAuthor" runat="server" Text='<%# Bind("Author") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="txtYear" runat="server" Text='<%# Bind("Year") %>' />
                    </td>
                      <td>
                        <asp:TextBox ID="txtPrice" runat="server" Text='<%# Bind("Price") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("Email") %>' />
                    </td>
                    <td>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                    </td>
                </tr>
            </InsertItemTemplate>
        </asp:ListView>


    </div>
    </form>
</body>
</html>
