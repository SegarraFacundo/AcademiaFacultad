<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error404.aspx.cs" Inherits="Error404" %>


<form id="form1" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Size="Large" Text="Ups! Algo salió mal. No se supone que usted este aquí."></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Font-Size="Medium" Text="Si no es la primera vez que ve este mensaje, comuníquese con su proveedor."></asp:Label>
    <br />
    <br />
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Clickeame para volver a Login</asp:LinkButton>
</form>



