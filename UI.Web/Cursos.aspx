<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cursos.aspx.cs" Inherits="Cursos" MasterPageFile="Site.master"%>
<asp:Content ID="cursosContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <asp:GridView ID="dgvCursos" runat="server" AutoGenerateColumns="False" DataSourceID="obsCursos"
        SelectedRowStyle-BackColor="Black"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="ID" OnSelectedIndexChanged="dgvCursos_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
            <asp:BoundField DataField="AnioCalendario" HeaderText="Año Calendario" SortExpression="AnioCalendario" />
            <asp:BoundField DataField="Cupo" HeaderText="Cupo" SortExpression="Cupo" />
            <asp:BoundField DataField="IdComision" HeaderText="IdComision" SortExpression="IdComision" Visible="False" />
            <asp:BoundField DataField="IdMateria" HeaderText="IdMateria" SortExpression="IdMateria" Visible="False" />
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
            <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" Visible="False" />
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
        </Columns>        
    </asp:GridView>
    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="inscribirLinkButton" runat="server" OnClick="inscribirLinkButton_Click" >Inscribir a curso</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" >Nuevo</asp:LinkButton>
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" >Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" >Eliminar</asp:LinkButton>        
   </asp:Panel>
   <asp:ObjectDataSource ID="obsCursos" runat="server" SelectMethod="GetAll" TypeName="Data.Database.CursoAdapter"></asp:ObjectDataSource>

    <asp:Panel ID="ABMPanel" runat="server" Visible="False">
        <asp:Label ID="Label1" runat="server" Text="Descripción:"></asp:Label>
        <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Año Calendario:"></asp:Label>
        <asp:TextBox ID="txtAñoCalendario" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Cupo:"></asp:Label>
        <asp:TextBox ID="txtCupo" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Comision: "></asp:Label>
        <asp:DropDownList ID="cbComisiones" runat="server" DataSourceID="odsComisiones" DataTextField="Descripcion" DataValueField="Id">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="odsComisiones" runat="server" SelectMethod="GetAll" TypeName="Data.Database.ComisionAdapter"></asp:ObjectDataSource>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Materia: "></asp:Label>
        <asp:DropDownList ID="cbMaterias" runat="server" DataSourceID="odsMaterias" DataTextField="Descripcion" DataValueField="Id">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="odsMaterias" runat="server" SelectMethod="GetAllSinPlan" TypeName="Data.Database.MateriaAdapter"></asp:ObjectDataSource>
        <br />

        <asp:Panel ID="formActionsPanel" runat="server" Visible="False">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="aceptarLinkButton_Click" >Aceptar</asp:LinkButton>
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="cancelarLinkButton_Click" >Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
</asp:Content>

