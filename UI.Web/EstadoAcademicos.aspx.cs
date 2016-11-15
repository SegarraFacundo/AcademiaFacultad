using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Util.CustomException;
using Util;

public partial class VerInscripciones : System.Web.UI.Page
{

    UsuarioLogic UsuarioLogic = new UsuarioLogic();
    AlumnoLogic alumnoLogic = new AlumnoLogic();
    AlumnoInscriptoLogic ail = new AlumnoInscriptoLogic();
    Usuario currentUser;
    Alumno currentAlumno;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            
        }
        currentUser = UsuarioLogic.GetOne(Convert.ToInt32(Session["idUsuario"]));
        if (currentUser != null)
        {
            currentAlumno = alumnoLogic.GetOne(currentUser.IdPersona);
            if (currentAlumno != null)
            {
                this.LoadDGV();
            }
        }
    }
    private void LoadDGV()    {
        this.dgvInscripciones.DataSource = ail.GetInscripto(currentAlumno.Id); 
        this.dgvInscripciones.DataBind();
    }
}