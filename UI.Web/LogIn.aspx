<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogIn.aspx.cs" Inherits="LogIn"  MasterPageFile="Site.master"%>

<asp:Content ID="ContentLogin" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">
        <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
                </td>
                <td>
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
    </div>

    <div>
        <asp:ValidationSummary ID="vsUsuario" runat="server" ForeColor="Red" Font-Names="Calibri" HeaderText="Cambiar los campos con *" />
    </div>

</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
    .auto-style1 {
        width: 134px;
    }
    .auto-style2 {
        width: 134px;
        height: 29px;
    }
    .auto-style3 {
        height: 29px;
    }
</style>
</asp:Content>
