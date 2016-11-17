<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Materias.aspx.cs" Inherits="Materias" MasterPageFile="Site.master"%>

<asp:Content ID="materiasContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:GridView ID="dgvMaterias" runat="server" AutoGenerateColumns="False" DataSourceID="obsMaterias"
        SelectedRowStyle-BackColor="Black"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="ID" 
        OnSelectedIndexChanged="dgvMaterias_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
            <asp:BoundField DataField="HsSemanales" HeaderText="HsSemanales" SortExpression="HsSemanales" />
            <asp:BoundField DataField="HsTotales" HeaderText="HsTotales" SortExpression="HsTotales" />
            <asp:BoundField DataField="IdPlan" HeaderText="IdPlan" SortExpression="IdPlan" />
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
            <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
        </Columns>

<SelectedRowStyle BackColor="Black" ForeColor="White"></SelectedRowStyle>
    </asp:GridView>

    <asp:ObjectDataSource ID="obsMaterias" runat="server" SelectMethod="GetAllSinPlan" TypeName="Data.Database.MateriaAdapter"></asp:ObjectDataSource>
    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" >Nuevo</asp:LinkButton>
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" >Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" >Eliminar</asp:LinkButton>        
    </asp:Panel>

    <asp:Panel ID="ABMPanel" runat="server" Visible="False">
        <asp:Label ID="Label1" runat="server" Text="Descripcion: "></asp:Label>
        <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Horas Semanales: "></asp:Label>
        <asp:TextBox ID="txtHorasSemales" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Horas Totales:"></asp:Label>
        <asp:TextBox ID="txtHorasTotales" runat="server"></asp:TextBox>
        <br />
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>

</asp:Content>


