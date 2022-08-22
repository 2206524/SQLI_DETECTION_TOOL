<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="PJT_SQLI.Users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SQLI Test Website</title>
        <style>
         body {
            background-image: url("Blue1.jpg");
            background-repeat: no-repeat;
            background-color: #cccccc;
           background-size: 1100px 700px;
         }
      </style>
</head>
<body>
    <form id="frmUser" runat="server" title ="User Detail(s)">
        <div>
             <div>
            <table id="tblMain" width="75%">
                <tr>
                    <td>
                        <h1>SQL Injection Detection Tool Test Results</h1>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h1>View Contact Details</h1>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table id="tblSearch" width="50%" border="0">
                            <tr>
                                <td>
                                    <asp:Label ID="lblFName" Text="First Name" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFname" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblLName" Text="Last Name" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLname" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                               <tr>
                                <td>
                                    <asp:Label ID="lblPhone" Text="Phone" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox><asp:Label ID="lblValidateLPhone" runat="server" Text="" Font-Bold="True" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                               <tr>
                                <td>
                                    <asp:Label ID="lblEmail" Text="Email" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><asp:Label ID="lblValidateLEmail" runat="server" Text="" Font-Bold="True" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                               <tr>
                                <td>
                                    <asp:Label ID="lblHseNo" Text="House No" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHseNo" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblAddress" Text="Address" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAddress" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCountry" Text="Country" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCountry" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPostalCode" Text="Postal Code" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPostalCode" runat="server" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                     &nbsp;
                                </td>
                                <td>
                                    <div style="text-align: right; width: 37%;">
                                    <asp:Button ID="btn_Submit" runat="server" Text="Update" OnClick="btn_Submit_Click" BorderStyle="Solid" Font-Bold="True"/>
                                    </div>
                                    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                          </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
