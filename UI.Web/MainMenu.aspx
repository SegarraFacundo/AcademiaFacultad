<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainMenu.aspx.cs" Inherits="MainMenu" MasterPageFile="Site.master"%>

<asp:Content ID="MainManuContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    
    <asp:LinkButton ID="linkMenuUsuarios" runat="server" OnClick="linkMenuUsuarios_Click">Usuarios</asp:LinkButton>    
        <br />
    <asp:LinkButton ID="linkMenuAlumnos" runat="server" OnClick="linkMenuAlumnos_Click">Alumnos</asp:LinkButton>
        <br />
    <asp:LinkButton ID="linkMenuDocentes" runat="server" OnClick="linkMenuDocentes_Click">Docentes</asp:LinkButton>
        <br />
    <asp:LinkButton ID="linkMenuComisiones" runat="server" OnClick="linkMenuComisiones_Click">Comisiones</asp:LinkButton>
        <br />
    <asp:LinkButton ID="linkMenuCursos" runat="server" OnClick="linkMenuCursos_Click">Cursos</asp:LinkButton>
        <br />
    <asp:LinkButton ID="linkMenuEspecialidades" runat="server" OnClick="linkMenuEspecialidades_Click">Especialidades</asp:LinkButton>
        <br />
    <asp:LinkButton ID="linkMenuMaterias" runat="server" OnClick="linkMenuMaterias_Click">Materias</asp:LinkButton>
        <br />
    <asp:LinkButton ID="linkMenuPlanes" runat="server" OnClick="linkMenuPlanes_Click">Planes</asp:LinkButton>
        <br />
     <asp:LinkButton ID="linkIngresarNotasAlumnos" runat="server" OnClick="linkIngresarNotas_Click">Ingresar Notas</asp:LinkButton>
        <br />
    <asp:LinkButton ID="linkInscripcionCursado" runat="server" OnClick="linkInscripcionCursado_Click">Inscribir a cursado</asp:LinkButton>
        <br />
    <asp:LinkButton ID="linkReportes" runat="server" OnClick="linkReportes_Click">Reportes</asp:LinkButton>
        <br />

    <asp:Label ID="lblError" runat="server"></asp:Label>

</asp:Content>
