<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Planes.aspx.cs" Inherits="Planes" MasterPageFile="~/Site.master"%>

<asp:Content ID="PlanesConent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">


    <asp:GridView ID="dgvPlanes" runat="server" AutoGenerateColumns="False" DataSourceID="odsPlanes"
        SelectedRowStyle-BackColor="Black"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="ID" OnSelectedIndexChanged="dgvEspecialidades_SelectedIndexChanged"> 
            <Columns>
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                <asp:BoundField DataField="IdEspecialidad" HeaderText="IdEspecialidad" SortExpression="IdEspecialidad" Visible="False" />
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
                <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" Visible="False" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>

<SelectedRowStyle BackColor="Black" ForeColor="White"></SelectedRowStyle>
    </asp:GridView>
    <asp:ObjectDataSource ID="odsPlanes" runat="server" SelectMethod="GetAll" TypeName="Data.Database.PlanAdapter"></asp:ObjectDataSource>
    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" >Nuevo</asp:LinkButton>
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" >Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" >Eliminar</asp:LinkButton>        
    </asp:Panel>
    
    <asp:Panel ID="ABMPanel" Visible="false" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Descripción:"></asp:Label>
        <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
        <br/>
        <asp:Label ID="Label2" runat="server" Text="Especialidad:"></asp:Label>
        <asp:DropDownList ID="cbEspecialidades" runat="server" DataSourceID="odsEspecialiades" DataTextField="Descripcion" DataValueField="Id">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="odsEspecialiades" runat="server" SelectMethod="GetAll" TypeName="Data.Database.EspecialidadAdapter"></asp:ObjectDataSource>
        <br /><br />
        <asp:Label ID="Label3" runat="server" Text="Materias del Plan:"></asp:Label>
        <asp:GridView ID="dgvMaterias" runat="server" AutoGenerateColumns="False" DataSourceID="odsMaterias" DataKeyNames="Id, Descripcion" OnSelectedIndexChanged="dgvMaterias_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                <asp:BoundField DataField="HsSemanales" HeaderText="Hs Semanales" SortExpression="HsSemanales" />
                <asp:BoundField DataField="HsTotales" HeaderText="Hs Totales" SortExpression="HsTotales" />
                <asp:BoundField DataField="IdPlan" HeaderText="IdPlan" SortExpression="IdPlan" Visible="False" />
                <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" Visible="False" />
                <asp:templatefield HeaderText="Seleccionar">
                    <itemtemplate>
                         <asp:checkbox ID="chkSelect" runat="server"></asp:checkbox>
                    </itemtemplate>
                </asp:templatefield>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odsMaterias" runat="server" SelectMethod="GetAllSinPlan" TypeName="Data.Database.MateriaAdapter"></asp:ObjectDataSource>
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            
        </asp:Panel>
        <br />
        
    </asp:Panel>

    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

</asp:Content>

