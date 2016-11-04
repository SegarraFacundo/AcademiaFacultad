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
    public TiposDatos.FormModes FormMode
    {
        get { return (TiposDatos.FormModes)this.ViewState["FormMode"]; }
        set { this.ViewState["FormMode"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.FormMode == TiposDatos.FormModes.Alta)
        {

        }
    }

    protected void nuevoLinkButton_Click(object sender, EventArgs e)
    {
        this.formPanel.Visible = true;
        this.FormMode = TiposDatos.FormModes.Alta;
        this.ClearForm();
        this.EnableForm(true);
    }


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
    private void EnableForm(bool valor)
    {
        txtApellido.Enabled = valor;
        txtNombre.Enabled = valor;
        txtEmail.Enabled = valor;
        txtFecNac.Enabled = valor;
        txtLegajo.Enabled = valor;
        txtDireccion.Enabled = valor;
    }
    protected void aceptarLinkButton_Click(object sender, EventArgs e)
    {
        switch (this.FormMode)
        {
            case TiposDatos.FormModes.Alta:
                Alumno alumno = new Alumno();
                alumno.IdPlan = Int32.Parse(this.cbPlan.SelectedValue.ToString());
                alumno.Nombre = this.txtNombre.Text;
                alumno.Apellido = this.txtApellido.Text;
                alumno.Email = this.txtEmail.Text;
                alumno.Direccion = this.txtDireccion.Text;
                alumno.Legajo = Int32.Parse(this.txtLegajo.Text);
                alumno.Telefono = this.txtTelefono.Text;
                alumno.FechaNacimiento = Convert.ToDateTime(this.txtFecNac.Text);
                alumno.State = TiposDatos.States.New;

                this.currentAlumno = alumno;
                break;
            case TiposDatos.FormModes.Consulta:
                this.currentAlumno.State = TiposDatos.States.Unmodified;
                break;
            case TiposDatos.FormModes.Modificacion:
                this.currentAlumno.Nombre = this.txtNombre.Text;
                this.currentAlumno.Apellido = this.txtApellido.Text;
                this.currentAlumno.Email = this.txtEmail.Text;
                this.currentAlumno.Direccion = this.txtDireccion.Text;
                this.currentAlumno.Legajo = Int32.Parse(this.txtLegajo.Text);
                this.currentAlumno.Telefono = this.txtTelefono.Text;
                this.currentAlumno.FechaNacimiento = Convert.ToDateTime(this.txtFecNac.Text);
                if (this.cbPlan.SelectedValue != null)
                {
                    this.currentAlumno.IdPlan = Int32.Parse(this.cbPlan.SelectedValue.ToString());
                }
                this.currentAlumno.State = TiposDatos.States.Modified;
                break;
            case TiposDatos.FormModes.Baja:
                this.currentAlumno.State = TiposDatos.States.Deleted;
                break;
            default:
                this.currentAlumno.State = TiposDatos.States.Unmodified;
                break;
        }
    }
    #endregion
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        {
            if (this.cbEspecialidad.SelectedValue != null)
            {
                int idEspecialidad = Int32.Parse(this.cbEspecialidad.SelectedValue.ToString());

                try
                {
                    this.cbPlan.DataSource = new PlanLogic().GetByEspecialidad(idEspecialidad);
                }
                catch (Util.CustomException.NotFoundException ex)
                {
                }
                catch (Util.CustomException.CustomException ex)
                {
                }
                catch (Exception ex)
                {
                }

                this.cbPlan.Visible = true;
                this.lblPlan.Visible = true;
            }
        }
    }
}