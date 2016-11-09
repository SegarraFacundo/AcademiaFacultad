<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Docentes.aspx.cs" Inherits="Docentes" MasterPageFile="Site.master" %>

<asp:Content ID="AlumnosContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:GridView ID="dgvDocentes" runat="server" AutoGenerateColumns="False" DataSourceID="odsDocentes"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID" OnSelectedIndexChanged="dgvDocentes_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
            <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
            <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
            <asp:BoundField DataField="Legajo" HeaderText="Legajo" SortExpression="Legajo" />
            <asp:BoundField DataField="FechaNacimiento" HeaderText="FechaNacimiento" SortExpression="FechaNacimiento" />
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
            <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" Visible="False" />
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
        </Columns>
    </asp:GridView>
    <asp:Panel ID="gridActionsPanel" runat="server">
        
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" >Nuevo</asp:LinkButton>
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" >Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" >Eliminar</asp:LinkButton>
        <asp:ObjectDataSource ID="odsDocentes" runat="server" SelectMethod="GetAll" TypeName="Data.Database.DocenteAdapter"></asp:ObjectDataSource>
    </asp:Panel>
    <asp:Panel ID="ABMPanel" Visible="false" runat="server">
            <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <br />
            <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
            <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
        <br />
             <asp:Label ID="lblDireccion" runat="server" Text="Dirección: "></asp:Label>
            <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
        <br />
            <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
            <asp:Label ID="lblTelefono" runat="server" Text="Teléfono: "></asp:Label>
            <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
         <br />
            <asp:Label ID="lblFecNac" runat="server" Text="Fecha de Nacimiento: "></asp:Label>        
            <asp:TextBox ID="txtFecNac" runat="server" type="date"></asp:TextBox>        
        <br />
        <asp:Label ID="lblLegajo" runat="server" Text="Legajo: "></asp:Label>
        <asp:TextBox ID="txtLegajo" runat="server" Enabled="False"></asp:TextBox>      
        <br />
        <br />
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" >Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
</asp:Content>