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

public partial class InscripcionCursado : System.Web.UI.Page
{
    //La cosa es asi, tenemos un alumno
    //Tenemos un listado de cursos.
    //Debemos seleccionar un curso, y hacer el insert en alumno_inscripciones

    AlumnoInscriptoLogic inscripcionLogic = new AlumnoInscriptoLogic();

    private int SelectedID
    {
        get
        {
            if (this.ViewState["SelectedID"] != null)
            {
                return (int)this.ViewState["SelectedID"];
            }
            else
            {
                return 0;
            }
        }
        set
        {
            this.ViewState["SelectedID"] = value;
        }
    }
    private bool IsEntitySelected
    {
        get
        {
            return (this.SelectedID != 0);
        }
    }
    private void SaveEntity(AlumnoInscripto inscripcion)
    {
        this.inscripcionLogic.Save(inscripcion);
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void dgvCursos_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectedID = (int)this.dgvCursos.SelectedValue;
        //capturamos el alumno a travez del usuario

        int usuarioId = Convert.ToInt32(Session["idUsuario"]);
        try
        {
            UsuarioLogic userLogic = new UsuarioLogic();
            Usuario currentUser = userLogic.GetOne(usuarioId);

            if (currentUser != null)
            {
                AlumnoLogic alumnoLogic = new AlumnoLogic();
                Alumno currentAlumno = alumnoLogic.GetOne(currentUser.IdPersona);
                if (currentAlumno != null)
                {
                    //ahora que capturamos el alumno nos pasamos de capa para validar la inscripcion y hacerla 
                    CursoLogic cursoLogic = new CursoLogic();
                    Curso currentCurso = cursoLogic.GetOne(SelectedID);
                    string rta = inscripcionLogic.ValidarInscripcion(currentAlumno, currentCurso);
                    if (rta == "")
                    {
                        AlumnoInscripto currentInscripcion = new AlumnoInscripto();
                        currentInscripcion.IdAlumno = currentAlumno.Id;
                        currentInscripcion.IdCurso = currentCurso.Id;
                        currentInscripcion.State = TiposDatos.States.New;
                        currentInscripcion.Condicion = "inscripto";                        
                        inscripcionLogic.Save(currentInscripcion);                         
                    }
                    else
                    {
                        lblError.Text = "Error: " + rta;
                    }
                }
            }

        }
        catch (Exception ex)
        {
            lblError.Text = "Error: " + ex.Message;
        }

    }
}