using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Util;
using Util.CustomException;

public partial class MainMenu : System.Web.UI.Page
{
    Usuario currentUsuario;
    UsuarioLogic usuarioLogic;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        this.usuarioLogic = new UsuarioLogic();

        if ( Session["idUsuario"] == null )
        {
            Response.Redirect("LogIn.aspx");
        }

        this.CleanMenu();

        try
        {
            int idUsuario = Convert.ToInt32(Session["idUsuario"]);
            this.currentUsuario = this.usuarioLogic.GetOne(idUsuario);

            bool noTienePermisos = true;

            foreach(Permiso p in this.currentUsuario.Permisos)
            {
                switch( p.Ejecuta )
                {
                    case "usuarios":
                        noTienePermisos = false;
                        linkMenuUsuarios.Visible = true;
                        break;
                    case "personas":
                        noTienePermisos = false;
                        linkMenuAlumnos.Visible = true;
                        linkMenuDocentes.Visible = true;
                        break;
                    case "comisiones":
                        noTienePermisos = false;
                        linkMenuComisiones.Visible = true;
                        break;
                    case "cursos":
                        noTienePermisos = false;
                        linkMenuCursos.Visible = true;
                        break;
                    case "especialidades":
                        noTienePermisos = false;
                        linkMenuEspecialidades.Visible = true;
                        break;
                    case "alumnos_inscripciones":
                        noTienePermisos = false;
                        break;
                    case "materias":
                        noTienePermisos = false;
                        linkMenuMaterias.Visible = true;
                        break;
                    case "planes":
                        noTienePermisos = false;
                        linkMenuPlanes.Visible = true;
                        break;
                    case "docentes_cursos":
                        break;
                    case "permisos":
                        break;
                    case "notas":
                        break;
                }
            }

            if(noTienePermisos)
            {
                Session["idUsuario"] = null;
                Response.Redirect("Error404.aspx");
            }
        }
        catch (NotFoundException)
        {
            Session["idUsuario"] = null;
            Response.Redirect("Error404.aspx");
        }
        catch (Exception)
        {
            Session["idUsuario"] = null;
            Response.Redirect("Error500.aspx");
        }
    }
    #region "Metodos"
    protected void CleanMenu()
    {
        linkMenuUsuarios.Visible = false;
        linkMenuAlumnos.Visible = false;
        linkMenuDocentes.Visible = false;
        linkMenuComisiones.Visible = false;
        linkMenuCursos.Visible = false;
        linkMenuEspecialidades.Visible = false;
        linkMenuMaterias.Visible = false;
        linkMenuPlanes.Visible = false;
    }
    #endregion
    #region "LinkButtons"
    protected void linkMenuPlanes_Click(object sender, EventArgs e)
    {
        Response.Redirect("Planes.aspx");
    }
    protected void linkMenuUsuarios_Click(object sender, EventArgs e)
    {
        Response.Redirect("Usuarios.aspx");
    }
    protected void linkMenuAlumnos_Click(object sender, EventArgs e)
    {
        Response.Redirect("Alumnos.aspx");
    }
    protected void linkMenuDocentes_Click(object sender, EventArgs e)
    {
        Response.Redirect("Docentes.aspx");
    }
    protected void linkMenuComisiones_Click(object sender, EventArgs e)
    {
        Response.Redirect("Comisiones.aspx");
    }
    protected void linkMenuCursos_Click(object sender, EventArgs e)
    {
        Response.Redirect("Cursos.aspx");
    }
    protected void linkMenuEspecialidades_Click(object sender, EventArgs e)
    {
        Response.Redirect("Especialidades.aspx");
    }
    protected void linkMenuMaterias_Click(object sender, EventArgs e)
    {
        Response.Redirect("Materias.aspx");
    }
    protected void linkIngresarNotas_Click(object sender, EventArgs e)
    {        
        Response.Redirect("RegistroNotas.aspx");
    }
    #endregion

}