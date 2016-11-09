<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainMenu.aspx.cs" Inherits="MainMenu" MasterPageFile="Site.master"%>

<asp:Content ID="MainManuContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    
    <asp:LinkButton ID="linkMenuUsuarios" runat="server" OnClick="linkMenuUsuarios_Click">Menu Usuarios</asp:LinkButton>    
        <br />
    <asp:LinkButton ID="linkMenuAlumnos" runat="server" OnClick="linkMenuAlumnos_Click">Menu Alumnos</asp:LinkButton>
        <br />
    <asp:LinkButton ID="linkMenuDocentes" runat="server" OnClick="linkMenuDocentes_Click">Menu Docentes</asp:LinkButton>
        <br />
    <asp:LinkButton ID="linkMenuComisiones" runat="server" OnClick="linkMenuComisiones_Click">Menu Comisiones</asp:LinkButton>
        <br />
    <asp:LinkButton ID="linkMenuCursos" runat="server" OnClick="linkMenuCursos_Click">Menu Cursos</asp:LinkButton>
        <br />
    <asp:LinkButton ID="linkMenuEspecialidades" runat="server" OnClick="linkMenuEspecialidades_Click">Menu Especialidades</asp:LinkButton>
        <br />
    <asp:LinkButton ID="linkMenuInscripcion" runat="server" OnClick="linkMenuInscripcion_Click">Inscripción a Cursado</asp:LinkButton>
        <br />
    <asp:LinkButton ID="linkMenuMaterias" runat="server" OnClick="linkMenuMaterias_Click">Menu Materias</asp:LinkButton>
        <br />
    <asp:LinkButton ID="linkMenuPlanes" runat="server" OnClick="linkMenuPlanes_Click">Menu Planes</asp:LinkButton>
        <br />
    <asp:LinkButton ID="linkMenuNotas" runat="server" OnClick="linkMenuNotas_Click">Menu Notas</asp:LinkButton>        
        <br />
    <asp:LinkButton ID="linkCambiarContraseña" runat="server" OnClick="linkCambiarContraseña_Click">Cambiar Contraseña</asp:LinkButton>
    <br />

    <asp:Label ID="lblError" runat="server"></asp:Label>

</asp:Content>
