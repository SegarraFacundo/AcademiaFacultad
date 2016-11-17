<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Alumnos_Notas_Cursos.aspx.cs" Inherits="Alumnos_Notas_Cursos" MasterPageFile="Site.master"%>

<asp:Content ID="alumnosNotasCursosContent" ContentPlaceHolderID ="bodyContentPlaceHolder" runat="server">

    <header>
        <h2>Notas de los alumnos</h2>
    </header>
    <asp:GridView ID="dgvAlumnosCurso" runat="server" AutoGenerateColumns="False" DataSourceID="odsAlumnosCurso"
        SelectedRowStyle-BackColor="Black"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="id_inscripcion" OnSelectedIndexChanged="dgvAlumnosCurso_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="id_inscripcion" HeaderText="ID" />
            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="apellido" HeaderText="Apellido" />
            <asp:BoundField DataField="legajo" HeaderText="Legajo" />
            <asp:BoundField DataField="condicion" HeaderText="Condicion" />
            <asp:BoundField DataField="nota" HeaderText="Nota" />
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
        </Columns>
    </asp:GridView>
     <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" >Editar</asp:LinkButton>
        <asp:LinkButton ID="volverLinkButton" runat="server" OnClick="volverLinkButton_Click" >Volver</asp:LinkButton>   
         
    </asp:Panel>
    <asp:Panel ID="PanelEditarNota" runat="server" Visible="False">

            <asp:Label ID="Label1" runat="server" Text="Nota:"></asp:Label>
            <asp:TextBox ID="txtNota" runat="server"></asp:TextBox>

            <br />
             <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" >Aceptar</asp:LinkButton>
             <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" >Cancelar</asp:LinkButton> 
         </asp:Panel>
    <asp:ObjectDataSource ID="odsAlumnosCurso" runat="server" SelectMethod="GetAlumnosCurso" TypeName="Data.Database.AlumnoInscripcionAdapter">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="id" SessionField="id_curso" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>






</asp:Content>

