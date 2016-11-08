<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Comisiones.aspx.cs" Inherits="Comisiones" MasterPageFile="site.Master" %>

<asp:Content ID="ComisionesContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <asp:GridView ID="dgvComisiones" runat="server" DataSourceID="obsComisiones" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="AnioEspecialidad" HeaderText="Año Especialidad" SortExpression="AnioEspecialidad" />
            <asp:BoundField DataField="IdPlan" HeaderText="IdPlan" SortExpression="IdPlan" Visible="False" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
            <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" Visible="False" />
        </Columns>
</asp:GridView>
    <asp:ObjectDataSource ID="obsComisiones" runat="server" SelectMethod="GetAll" TypeName="Data.Database.ComisionAdapter" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>

</asp:Content>

