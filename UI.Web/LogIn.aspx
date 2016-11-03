<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogIn.aspx.cs" Inherits="LogIn"  MasterPageFile="Site.master"%>

<asp:Content ID="ContentLogin" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Contraseña:"></asp:Label>
        <asp:TextBox ID="txtContraseña" runat="server"></asp:TextBox>
    </div>

    <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" />
    <div>
        <asp:Label ID="lblError" runat="server" Text="Error:" Visible="False"></asp:Label>
    </div>

</asp:Content>