<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Especialidades.aspx.cs" Inherits="Especialidades" MasterPageFile="site.Master"%>

<asp:Content ID="EspecialiadesContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <asp:GridView ID="dgvEspecialidades" runat="server" AutoGenerateColumns="False" DataSourceID="obsEspecialidades" 
        SelectedRowStyle-BackColor="Black"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="ID" OnSelectedIndexChanged="dgvEspecialidades_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
                <asp:BoundField DataField="State" HeaderText="Estado" SortExpression="State" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="obsEspecialidades" runat="server" SelectMethod="GetAll" TypeName="Data.Database.EspecialidadAdapter"></asp:ObjectDataSource>
     <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" >Nuevo</asp:LinkButton>
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" >Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" >Eliminar</asp:LinkButton>        
    </asp:Panel>

    <asp:Panel ID="ABMPanel" Visible="false" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Descripción:"></asp:Label>
        <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
    </asp:Panel>
    <asp:Panel ID="formActionsPanel" runat="server" Visible="False">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            
    </asp:Panel>
    <br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
</asp:Content>
