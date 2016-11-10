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
    private bool IsEntitySelected
    {
        get
        {
            return (this.SelectedID != 0);
        }
    }
    private void ClearForm()
    {
        txtApellido.Text = "";
        txtNombre.Text = "";
        txtEmail.Text = "";
        txtFecNac.Text = "";
        txtLegajo.Text = "";
        txtDireccion.Text = "";
    }
    private void EnableForm(bool valor)
    {
        txtApellido.Enabled = valor;
        txtNombre.Enabled = valor;
        txtEmail.Enabled = valor;
        txtFecNac.Enabled = valor;        
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
        alumno.IdPlan = Convert.ToInt32(cbPlan.SelectedValue);
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

    private void LoadForm(int id)
    {
        currentAlumno = alumnoLogic.GetOne(id);
        txtApellido.Text = currentAlumno.Apellido;
        txtDireccion.Text = currentAlumno.Direccion;
        txtEmail.Text = currentAlumno.Email;
        txtNombre.Text = currentAlumno.Nombre;
        txtFecNac.Text = currentAlumno.FechaNacimiento.ToString();
        txtLegajo.Text = currentAlumno.Legajo.ToString();
        txtTelefono.Text = currentAlumno.Telefono;
        cbPlan.SelectedValue = currentAlumno.IdPlan.ToString();
        
      
    }
    #endregion

    #region "Controles Metodos"
    protected void aceptarLinkButton_Click(object sender, EventArgs e)
    {
        switch (this.FormMode)
        {
            case TiposDatos.FormModes.Alta:
                Entity = new Alumno();
                LoadEntity(Entity);
                currentAlumno.State = TiposDatos.States.New;    
                SaveEntity(Entity);
                currentAlumno = Entity;
                break;
            case TiposDatos.FormModes.Consulta:
                this.currentAlumno.State = TiposDatos.States.Unmodified;
                LoadForm(SelectedID);
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
                currentAlumno = alumnoLogic.GetOne(this.SelectedID);
                currentAlumno.State = TiposDatos.States.Deleted;
                SaveEntity(currentAlumno);
                break;
            default:
                this.currentAlumno.State = TiposDatos.States.Unmodified;
                break;
        }
        this.ABMPanel.Visible = false;
        this.gridActionsPanel.Visible = true;
        this.formActionsPanel.Visible = false;
        dgvAlumnos.DataBind();
    }
    protected void nuevoLinkButton_Click(object sender, EventArgs e)
    {
        this.ABMPanel.Visible = true;
        this.gridActionsPanel.Visible = false;
        this.formActionsPanel.Visible = true;
        this.ClearForm();
        txtLegajo.Text = alumnoLogic.obtenerProximoLegajo().ToString();
        this.FormMode = TiposDatos.FormModes.Alta;
        this.EnableForm(true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["idUsuario"] == null)
        {
            Response.Redirect("LogIn.aspx");
        }
    }
    protected void dgvAlumnos_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectedID = (int)this.dgvAlumnos.SelectedValue;
        this.ABMPanel.Visible = false;
    }
    protected void editarLinkButton_Click(object sender, EventArgs e)
    {
        if (this.IsEntitySelected)
        {
            this.ABMPanel.Visible = true;
            this.FormMode = TiposDatos.FormModes.Modificacion;
            this.EnableForm(true);
            this.LoadForm(this.SelectedID);
            this.formActionsPanel.Visible = true;
            
        }
    }
    protected void eliminarLinkButton_Click(object sender, EventArgs e)
    {
        if (this.IsEntitySelected)
        {
            this.FormMode = TiposDatos.FormModes.Baja;
            this.ABMPanel.Visible = true;
            this.EnableForm(false);
            this.gridActionsPanel.Visible = false;
            this.formActionsPanel.Visible = true;

        }
    }
    protected void cancelarLinkButton_Click(object sender, EventArgs e)
    {
        this.ClearForm();
        this.ABMPanel.Visible = false;
        this.gridActionsPanel.Visible = true;
    }
    #endregion
}