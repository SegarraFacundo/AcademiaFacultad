<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Comisiones.aspx.cs" Inherits="Comisiones" MasterPageFile="site.Master" %>

<asp:Content ID="ComisionesContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <asp:GridView ID="dgvComisiones" runat="server" DataSourceID="obsComisiones" AutoGenerateColumns="False"
        SelectedRowStyle-BackColor="Black"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="ID" OnSelectedIndexChanged="dgvEspecialidades_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="AnioEspecialidad" HeaderText="Año Especialidad" SortExpression="AnioEspecialidad" />
            <asp:BoundField DataField="IdPlan" HeaderText="IdPlan" SortExpression="IdPlan" Visible="False" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
            <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" Visible="False" />
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
        </Columns>
</asp:GridView>
    <asp:ObjectDataSource ID="obsComisiones" runat="server" SelectMethod="GetAll" TypeName="Data.Database.ComisionAdapter" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" >Nuevo</asp:LinkButton>
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" >Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" >Eliminar</asp:LinkButton>        
    </asp:Panel>
    <asp:Panel ID="ABMPanel" runat="server" Visible="False">
        <asp:Label ID="Label1" runat="server" Text="Descripción:"></asp:Label>
        <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Año Especialidad:"></asp:Label>
        <asp:TextBox ID="txtAñoEspecialidad" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Plan: "></asp:Label>
        <asp:DropDownList ID="cbPlanes" runat="server" DataSourceID="odsPlanes" DataTextField="Descripcion" DataValueField="Id">
        </asp:DropDownList>
        <br />
        <asp:Panel ID="formActionsPanel" runat="server" Visible="False">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="aceptarLinkButton_Click" >Aceptar</asp:LinkButton>
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="cancelarLinkButton_Click" >Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>

    <asp:ObjectDataSource ID="odsPlanes" runat="server" SelectMethod="GetAll" TypeName="Data.Database.PlanAdapter"></asp:ObjectDataSource>

    <asp:Label ID="lblError" runat="server"></asp:Label>

</asp:Content>

