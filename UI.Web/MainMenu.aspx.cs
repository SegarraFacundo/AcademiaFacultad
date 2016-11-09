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
    UsuarioLogic userLogic = new UsuarioLogic();
    AlumnoLogic alumnoLogic = new AlumnoLogic();
    DocenteLogic docenteLogic = new DocenteLogic();
    AdministradorLogic adminLogic = new AdministradorLogic();
    Usuario currentUser;
    Alumno currentAlumno;
    Docente currentDocente;
    Administrador currentAdministrador;
    
    protected void Page_Load(object sender, EventArgs e)
    {

        ModuloUsuarioLogic mul = new ModuloUsuarioLogic();

        lblError.Text = "";
        if (Session["idUsuario"] != null && Session["id_persona"] != null)
        {
            int idUsuario = Convert.ToInt32(Session["idUsuario"]);
            currentUser = userLogic.GetOne(idUsuario);
            //Tenemos que ver que tipo de usuario es para darle los permisos
            int idPersona = Convert.ToInt32(Session["id_persona"]);

            try
            {
                currentAlumno = alumnoLogic.GetOne(idPersona);
                currentDocente = docenteLogic.GetOne(idPersona);
                currentAdministrador = adminLogic.GetOne(idPersona);           


                if (currentAlumno != null)
                {
                    //Es alumno
                    //Mostramos solo las opciones para los alumnos
                    Session["tipo_persona"] = "alumno";
                    linkMenuUsuarios.Visible = false;
                    linkMenuAlumnos.Visible = false;
                    linkMenuComisiones.Visible = true;
                    linkMenuDocentes.Visible = false;
                    linkMenuCursos.Visible = false;
                    linkMenuEspecialidades.Visible = false;
                    linkMenuInscripcion.Visible = false;
                    linkMenuMaterias.Visible = true;
                    linkMenuPlanes.Visible = false;
                    linkMenuNotas.Visible = true;
                }
                else if (currentDocente != null)
                {
                    //Es docente
                    //Mostramos solo las opciones para los docentes
                    Session["tipo_persona"] = "docente";
                    linkMenuUsuarios.Visible = false;
                    linkMenuAlumnos.Visible = false;
                    linkMenuComisiones.Visible = false;
                    linkMenuDocentes.Visible = false;
                    linkMenuCursos.Visible = false;
                    linkMenuEspecialidades.Visible = false;
                    linkMenuInscripcion.Visible = false;
                    linkMenuMaterias.Visible = true;
                    linkMenuPlanes.Visible = false;
                    linkMenuNotas.Visible = true;

                }
                else if(currentAdministrador !=null)
                {
                    //Es admin
                    //Mostramos solo las opciones para los admin
                    Session["tipo_persona"] = "admin";
                    linkMenuUsuarios.Visible = true;
                    linkMenuAlumnos.Visible = true;
                    linkMenuComisiones.Visible = true;
                    linkMenuDocentes.Visible = true;
                    linkMenuCursos.Visible = true;
                    linkMenuEspecialidades.Visible = true;
                    linkMenuInscripcion.Visible = true;
                    linkMenuMaterias.Visible = true;
                    linkMenuPlanes.Visible = true;
                    linkMenuNotas.Visible = false;
                }
                else
                {
                    Response.Redirect("ErrorPage.aspx");
                }
            }
            catch (Exception Ex)
            {
                lblError.Text = "Error: " + Ex.Message;
            }
        }
        else
        {
            Response.Redirect("ErrorPage.aspx");
        }
    }
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
    protected void linkMenuInscripcion_Click(object sender, EventArgs e)
    {
        Response.Redirect("InscripcionCursado.aspx");

    }
    protected void linkMenuMaterias_Click(object sender, EventArgs e)
    {
        Response.Redirect("Materias.aspx");

    }
    protected void linkMenuNotas_Click(object sender, EventArgs e)
    {
        Response.Redirect("RegistroNotas.aspx");

    }
    protected void linkCambiarContraseña_Click(object sender, EventArgs e)
    {
        Response.Redirect("CambiarPassword.aspx");
    }
    #endregion


}