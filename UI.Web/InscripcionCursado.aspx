<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InscripcionCursado.aspx.cs" Inherits="InscripcionCursado" MasterPageFile="Site.master" %>

<asp:Content ID="inscripcionCursadoContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">







    <asp:GridView ID="dgvCursos" runat="server" AutoGenerateColumns="False" DataSourceID="odsCursos"
        SelectedRowStyle-BackColor="Black"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="ID"
         OnSelectedIndexChanged="dgvCursos_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
            <asp:BoundField DataField="AnioCalendario" HeaderText="Año" SortExpression="AnioCalendario" />
            <asp:BoundField DataField="Cupo" HeaderText="Cupo" SortExpression="Cupo" Visible="False" />
            <asp:BoundField DataField="IdComision" HeaderText="IdComision" SortExpression="IdComision" Visible="False" />
            <asp:BoundField DataField="IdMateria" HeaderText="IdMateria" SortExpression="IdMateria" Visible="False" />
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
            <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" Visible="False" />
            <asp:CommandField SelectText="Inscribirse" ShowSelectButton="true" />

        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="odsCursos" runat="server" SelectMethod="GetAll" TypeName="Data.Database.CursoAdapter"></asp:ObjectDataSource>   
    <asp:Label ID="lblError" runat="server"></asp:Label>
</asp:Content>
