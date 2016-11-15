<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegistroNotas.aspx.cs" Inherits="RegistroNotas" MasterPageFile="Site.master"%>

<asp:Content ID="registroNotasContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:GridView ID="dgvDocentesCursos" runat="server" AutoGenerateColumns="False" 
        SelectedRowStyle-BackColor="Black"
        SelectedRowStyle-ForeColor="White"
        DataSourceID="odsDocentesCursos" Width="231px" OnSelectedIndexChanged="dgvDocentesCursos_SelectedIndexChanged">

        <Columns>
            <asp:BoundField DataField="IdCurso" HeaderText="IdCurso" SortExpression="IdCurso" />
            <asp:BoundField DataField="IdDocente" HeaderText="IdDocente" SortExpression="IdDocente" />
            <asp:BoundField DataField="Cargo" HeaderText="Cargo" SortExpression="Cargo" />
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
            <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
        </Columns>

<SelectedRowStyle BackColor="Black" ForeColor="White"></SelectedRowStyle>
    </asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:LinkButton ID="linkVolver" runat="server" OnClick="linkVolver_Click">Volver</asp:LinkButton>




</asp:Content>

