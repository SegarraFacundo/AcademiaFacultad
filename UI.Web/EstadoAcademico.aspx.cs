using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
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
        try
        {
            currentUser = UsuarioLogic.GetOne(Convert.ToInt32(Session["idUsuario"]));
            if(currentUser !=null){
                currentAlumno = alumnoLogic.GetOne(currentUser.IdPersona);
                if (currentAlumno != null)
                {
                    this.LoadGrid();
                }                
            }
        }
        catch(Exception ex)
        {
            lblError.Text = "Atención: " + ex.Message;
        }
        
    }
    private void LoadGrid()
    {
        this.dgvInscripcones.DataSource = ail.GetAllByIdAlumno(currentAlumno.Id);
        this.dgvInscripcones.DataBind();
    }
}