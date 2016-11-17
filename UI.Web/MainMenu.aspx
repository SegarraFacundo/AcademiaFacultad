<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainMenu.aspx.cs" Inherits="MainMenu"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Academia</title>
</head>
<body>

    <form runat="server">
        <div class="container">
            <header>
        <h2>Menu</h2>
    </header>
    <div class="menu">
    <asp:LinkButton ID="linkMenuUsuarios" runat="server" OnClick="linkMenuUsuarios_Click">Usuarios</asp:LinkButton>    

    <asp:LinkButton ID="linkMenuAlumnos" runat="server" OnClick="linkMenuAlumnos_Click">Alumnos</asp:LinkButton>

    <asp:LinkButton ID="linkMenuDocentes" runat="server" OnClick="linkMenuDocentes_Click">Docentes</asp:LinkButton>

    <asp:LinkButton ID="linkMenuComisiones" runat="server" OnClick="linkMenuComisiones_Click">Comisiones</asp:LinkButton>
  
    <asp:LinkButton ID="linkMenuCursos" runat="server" OnClick="linkMenuCursos_Click">Cursos</asp:LinkButton>
  
    <asp:LinkButton ID="linkMenuEspecialidades" runat="server" OnClick="linkMenuEspecialidades_Click">Especialidades</asp:LinkButton>
     
    <asp:LinkButton ID="linkMenuMaterias" runat="server" OnClick="linkMenuMaterias_Click">Materias</asp:LinkButton>
 
    <asp:LinkButton ID="linkMenuPlanes" runat="server" OnClick="linkMenuPlanes_Click">Planes</asp:LinkButton>
     
     <asp:LinkButton ID="linkIngresarNotasAlumnos" runat="server" OnClick="linkIngresarNotas_Click">Ingresar Notas</asp:LinkButton>
  
    <asp:LinkButton ID="linkInscripcionCursado" runat="server" OnClick="linkInscripcionCursado_Click">Inscribir a cursado</asp:LinkButton>

    <asp:LinkButton ID="linkReportes" runat="server" OnClick="linkReportes_Click">Reportes</asp:LinkButton>
        </div>
    

    <asp:Label ID="lblError" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
