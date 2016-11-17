<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogIn.aspx.cs" Inherits="LogIn"%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Academia</title>
</head>
<body>
    <form runat="server">
        <div class="container">
                   <header>
            <h2>Login</h2>
        </header>
        <table>
            <tr>
                <td class="auto-style1">
        <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
                </td>
                <td aling="center">
        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ErrorMessage="El campo usuario es obligatorio" ControlToValidate="txtUsuario" Font-Names="Arial" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
        <asp:Label ID="Label2" runat="server" Text="Contraseña:"></asp:Label>
                </td>
                <td class="auto-style3">
        <asp:TextBox ID="txtContraseña" TextMode="Password" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPass" runat="server" ErrorMessage="El campo contraseña es obligatorio" ControlToValidate="txtContraseña" Font-Names="Arial" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>

    <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" />
                </td>
            </tr>
        </table>
        <asp:ValidationSummary ID="vsUsuario" runat="server" ForeColor="Red" Font-Names="Calibri" HeaderText="Cambiar los campos con *" />

        </div>
    </form>
</body>
</html>

