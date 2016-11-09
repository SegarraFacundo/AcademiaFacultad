using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Util;

public partial class Docentes : System.Web.UI.Page
{
    private Docente currentDocente = new Docente();
    private DocenteLogic docenteLogic = new DocenteLogic();
    private Plan currentAlumnoPlan = new Plan();

    #region "Propiedades"
    public TiposDatos.FormModes FormMode
    {
        get { return (TiposDatos.FormModes)this.ViewState["FormMode"]; }
        set { this.ViewState["FormMode"] = value; }
    }


    private Docente Entity
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
    private void LoadEntity(Docente docente)
    {

        docente.Nombre = txtNombre.Text;
        docente.Apellido = txtApellido.Text;
        docente.Email = txtEmail.Text;
        docente.FechaNacimiento = DateTime.ParseExact(txtFecNac.Text, "yyyy-mm-dd", null);
        docente.Telefono = txtTelefono.Text;
        docente.Legajo = Int32.Parse(txtLegajo.Text);
        docente.Direccion = txtDireccion.Text;
    }

    private void SaveEntity(Docente docente)
    {
        docenteLogic.Save(docente);
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
        currentDocente = docenteLogic.GetOne(id);
        txtApellido.Text = currentDocente.Apellido;
        txtDireccion.Text = currentDocente.Direccion;
        txtEmail.Text = currentDocente.Email;
        txtNombre.Text = currentDocente.Nombre;
        txtFecNac.Text = currentDocente.FechaNacimiento.ToString();
        txtLegajo.Text = currentDocente.Legajo.ToString();
        txtTelefono.Text = currentDocente.Telefono;

    }
    #endregion

    #region "Controles Metodos"
    protected void aceptarLinkButton_Click(object sender, EventArgs e)
    {
        switch (this.FormMode)
        {
            case TiposDatos.FormModes.Alta:
                Entity = new Docente();

                LoadEntity(Entity);
                currentDocente.State = TiposDatos.States.New;
                SaveEntity(Entity);
                currentDocente = Entity;
                break;
            case TiposDatos.FormModes.Consulta:
                this.currentDocente.State = TiposDatos.States.Unmodified;
                LoadForm(SelectedID);
                break;
            case TiposDatos.FormModes.Modificacion:
                Entity = new Docente();
                LoadEntity(Entity);
                Entity.Id = this.SelectedID;
                Entity.State = TiposDatos.States.Modified;
                SaveEntity(Entity);
                currentDocente = Entity;
                break;
            case TiposDatos.FormModes.Baja:
                currentDocente.Id = this.SelectedID;
                currentDocente.State = TiposDatos.States.Deleted;
                SaveEntity(currentDocente);
                break;
            default:
                this.currentDocente.State = TiposDatos.States.Unmodified;
                break;
        }
        this.ABMPanel.Visible = false;
        dgvDocentes.DataBind();
    }
    protected void nuevoLinkButton_Click(object sender, EventArgs e)
    {
        this.ABMPanel.Visible = true;
        this.ClearForm();
        txtLegajo.Text = docenteLogic.obtenerProximoLegajo().ToString();
        this.FormMode = TiposDatos.FormModes.Alta;
        this.EnableForm(true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void editarLinkButton_Click(object sender, EventArgs e)
    {
        if (this.IsEntitySelected)
        {
            this.ABMPanel.Visible = true;
            this.FormMode = TiposDatos.FormModes.Modificacion;
            this.EnableForm(true);
            this.LoadForm(this.SelectedID);
        }
    }
    protected void eliminarLinkButton_Click(object sender, EventArgs e)
    {
        if (this.IsEntitySelected)
        {
            this.FormMode = TiposDatos.FormModes.Baja;
            this.ABMPanel.Visible = true;
            this.EnableForm(false);
            this.LoadForm(SelectedID);
        }
    }
    protected void cancelarLinkButton_Click(object sender, EventArgs e)
    {
        this.ClearForm();
        this.ABMPanel.Visible = false;       
    }
    protected void dgvDocentes_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectedID = (int)this.dgvDocentes.SelectedValue;
        this.ABMPanel.Visible = false;
    }

    #endregion
}