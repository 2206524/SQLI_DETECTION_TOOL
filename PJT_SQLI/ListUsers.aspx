<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListUsers.aspx.cs" Inherits="PJT_SQLI.ListUsers" %>

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
    <form id="frmListUsers" runat="server" title="List User(s)">
        <div>
            <table id="tblMain" width="57%" border="0">
                <tr>
                    <td>
                        <h1>SQL Injection Detection Tool Test Results</h1>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h1>View Contacts</h1>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table id="tblSearch" width="100%"  border="0">
                            <tr>
                                <td>
                                    <asp:Label ID="lblFirstname" runat="server" Text="First Name" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFname" runat="server"></asp:TextBox><asp:Label ID="lblValidateFName" runat="server" Text="" Font-Bold="True" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:Label ID="lblLastName" runat="server" Text="Last Name" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtLname" runat="server"></asp:TextBox><asp:Label ID="lblValidateLName" runat="server" Text="" Font-Bold="True" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                 <td>
                                     &nbsp;
                                 </td>
                                <td>
                                     <div style="text-align: right; width: 24%;">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" BorderStyle="Solid" OnClick="btnSearch_Click" Font-Bold="True" />
                                    </div>                                     
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="grdContacts" runat="server" AutoGenerateColumns="false" CellPadding="6">  
                                        <Columns>  
                                            <asp:HyperLinkField DataTextField="RW_NUM" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="~/Users.aspx?Id={0}" HeaderText="S No"/>
                                            <asp:BoundField DataField="FIRSTNAME" HeaderText="First Name" />  
                                            <asp:BoundField DataField="LASTNAME" HeaderText="Last Name" />  
                                            <asp:BoundField DataField="PHONE" HeaderText="Phone" />  
                                            <asp:BoundField DataField="EMAIL" HeaderText="Email" />  
                                            <asp:BoundField DataField="Address" HeaderText="Address" />  
                                            <asp:BoundField DataField="COUNTRYNAME" HeaderText="Country" />  
                                            <asp:BoundField DataField="POSTALCODE" HeaderText="Postal Code" />
                                        </Columns>  
                                        <HeaderStyle BackColor="#0066cc" Font-Bold="true" ForeColor="White" />  
                                        <RowStyle BackColor="#bfdfff" ForeColor="Black" />  
                                    </asp:GridView>  
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
