<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogIn.aspx.cs" Inherits="LogIn"  MasterPageFile="Site.master"%>

<asp:Content ID="ContentLogin" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ErrorMessage="El campo usuario es obligatorio" ControlToValidate="txtUsuario" Font-Names="Arial" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
        <asp:RangeValidator ID="rvUsuario" runat="server" MinimumValue="30" MaximumValue="4" ErrorMessage="El campo usuario esta fuera de rango" ControlToValidate="txtUsuario" Font-Names="Arial" ForeColor="Red" SetFocusOnError="True">*</asp:RangeValidator>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Contraseña:"></asp:Label>
        <asp:TextBox ID="txtContraseña" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPass" runat="server" ErrorMessage="El campo contraseña es obligatorio" ControlToValidate="txtContraseña" Font-Names="Arial" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
        <asp:RangeValidator ID="rvPass" runat="server" MinimumValue="30" MaximumValue="8" ControlToValidate="txtContraseña" ErrorMessage="El campo contraseña esta fuera de rango" Font-Names="Arial" ForeColor="Red" SetFocusOnError="True">*</asp:RangeValidator>
    </div>

    <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" />
    <div>
        <asp:ValidationSummary ID="vsUsuario" runat="server" ForeColor="Red" Font-Names="Calibri" HeaderText="Cambiar los campos con *" />
    </div>

</asp:Content>