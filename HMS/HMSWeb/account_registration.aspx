<%@ Page Language="C#" AutoEventWireup="true" CodeFile="account_registration.aspx.cs" Inherits="AccountRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Account Registration Page</h1>
            Company:<asp:TextBox ID="txtCompany" runat="server"></asp:TextBox><br />
            Contact Person:<asp:TextBox ID="txtContactPerson" runat="server"></asp:TextBox><br />
            Email:<asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox><br />
            Phone:<asp:TextBox ID="txtPhone" runat="server" TextMode="Number"></asp:TextBox><br />
            Adress:<asp:TextBox ID="txtAdress" runat="server" TextMode="MultiLine" Columns="20" Rows="5" Wrap="true"></asp:TextBox>
            Website:<asp:TextBox ID="txtWebsite" runat="server" TextMode="Url"></asp:TextBox>
            <h3>Features:</h3>
            <asp:CheckBox ID="chkBoxFullPackage" runat="server" Text="Full Package" /><br />
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
        </div>
    </form>
</body>
</html>
