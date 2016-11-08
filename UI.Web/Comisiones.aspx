<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Comisiones.aspx.cs" Inherits="Comisiones" MasterPageFile="site.Master" %>

<asp:Content ID="ComisionesContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <asp:GridView ID="dgvComisiones" runat="server" DataSourceID="obsComisiones">
</asp:GridView>
    <asp:ObjectDataSource ID="obsComisiones" runat="server" SelectMethod="GetAll" TypeName="Data.Database.ComisionAdapter"></asp:ObjectDataSource>

</asp:Content>

