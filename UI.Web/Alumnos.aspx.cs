using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;
using Business.Entities;
using Business.Logic;
public partial class Alumnos : System.Web.UI.Page
{
    private Alumno currentAlumno = new Alumno();
    private AlumnoLogic alumnoLogic = new AlumnoLogic();
    private Plan currentAlumnoPlan = new Plan();
    private PlanLogic planLogic;
    private Especialidad currentAlumnoEspecialidad;
    private EspecialidadLogic especialidadLogic;

    #region "Propiedades"
    public TiposDatos.FormModes FormMode
    {
        get { return (TiposDatos.FormModes)this.ViewState["FormMode"]; }
        set { this.ViewState["FormMode"] = value; }
    }


    private Alumno Entity
    {
        get;
        set;
    }

    #endregion

    #region "Metodos"
    private void ClearForm()
    {
        txtApellido.Text = "";
        txtNombre.Text = "";
        txtEmail.Text = "";
        txtFecNac.Text = "";
        txtLegajo.Text = "";
        txtDireccion.Text = "";
    }
    private void EnableForm(bool valor, TiposDatos.FormModes modo)
    {
        txtApellido.Enabled = valor;
        txtNombre.Enabled = valor;
        txtEmail.Enabled = valor;
        txtFecNac.Enabled = valor;
        txtLegajo.Enabled = valor;
        txtDireccion.Enabled = valor; 
    }

    private void LoadEntity(Alumno alumno)
    {
        alumno.Nombre = txtNombre.Text;
        alumno.Apellido = txtApellido.Text;
        alumno.Email = txtEmail.Text;
        alumno.FechaNacimiento = DateTime.ParseExact(txtFecNac.Text, "yyyy-mm-dd", null);
        alumno.Telefono = txtTelefono.Text;
        alumno.Legajo = Int32.Parse(txtLegajo.Text);
        alumno.Direccion = txtDireccion.Text;
    }

    private void SaveEntity(Alumno alumno)
    {
        alumnoLogic.Save(alumno);
    }
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
    #endregion

    #region "Controles Metodos"
    protected void aceptarLinkButton_Click(object sender, EventArgs e)
    {
        planLogic = new PlanLogic();
        especialidadLogic = new EspecialidadLogic();
        switch (this.FormMode)
        {
            case TiposDatos.FormModes.Alta:
                Entity = new Alumno();
                LoadEntity(Entity);
                currentAlumno.State = TiposDatos.States.New;

                //Le asignamos el plan que tenga esa especialidad               
                especialidadLogic = new EspecialidadLogic();
                currentAlumnoEspecialidad = especialidadLogic.GetOne(cbEspecialidad.SelectedIndex +1); //Le sumo 1 porque el primero es indice 0
                currentAlumnoPlan = planLogic.getLastByEspecialidad(currentAlumnoEspecialidad.Id);
                Entity.IdPlan = currentAlumnoPlan.Id;
                SaveEntity(Entity);
                currentAlumno = Entity;
                break;
            case TiposDatos.FormModes.Consulta:
                this.currentAlumno.State = TiposDatos.States.Unmodified;
                break;
            case TiposDatos.FormModes.Modificacion:
                Entity = new Alumno();
                LoadEntity(Entity);
                Entity.Id = this.SelectedID;
                Entity.State = TiposDatos.States.Modified;
                SaveEntity(Entity);
                currentAlumno = Entity;
                break;
            case TiposDatos.FormModes.Baja:
                Entity = new Alumno();
                Entity.Id = this.SelectedID;
                SaveEntity(Entity);
                this.currentAlumno.State = TiposDatos.States.Deleted;
                break;
            default:
                this.currentAlumno.State = TiposDatos.States.Unmodified;
                break;
        }
    }
    protected void nuevoLinkButton_Click(object sender, EventArgs e)
    {
        this.formPanel.Visible = true;
        this.cbPlan.Visible = false; this.lblPlan.Visible = false;
        this.ClearForm();
        txtLegajo.Text = alumnoLogic.obtenerProximoLegajo().ToString();
        this.FormMode = TiposDatos.FormModes.Alta;
        this.EnableForm(true, this.FormMode);
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #endregion
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectedID = (int)this.GridView1.SelectedValue;
        this.formPanel.Visible = false;
    }
}