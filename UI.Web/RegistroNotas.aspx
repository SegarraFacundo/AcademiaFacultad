<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegistroNotas.aspx.cs" Inherits="RegistroNotas" MasterPageFile="Site.master"%>

<asp:Content ID="registroNotasContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <header>
        <h2>Registro de notas</h2>
    </header>
    <asp:GridView ID="dgvDocentesCursos" runat="server" AutoGenerateColumns="False" DataKeyNames="id_curso" OnSelectedIndexChanged="dgvDocentesCursos_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="id_dictado" HeaderText="ID" Visible="False" />
            <asp:BoundField DataField="id_materia" HeaderText="id_materia" Visible="False" />
            <asp:BoundField DataField="id_curso" HeaderText="id_curso" Visible="False" />
            <asp:BoundField DataField="desc_materia" HeaderText="Materia" />
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
        </Columns>
    </asp:GridView>
    
    <asp:LinkButton ID="linkVolver" runat="server" OnClick="linkVolver_Click">Volver</asp:LinkButton>
    <br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
</asp:Content>

