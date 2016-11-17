using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;
using Business.Entities;
using Business.Logic;

public partial class Especialidades : System.Web.UI.Page
{
    Especialidad currentEspecialidad = new Especialidad();
    EspecialidadLogic especialidadLogic = new EspecialidadLogic();

    #region "propiedades"
    public TiposDatos.FormModes FormMode
    {
        get { return (TiposDatos.FormModes)this.ViewState["FormMode"]; }
        set { this.ViewState["FormMode"] = value; }
    }

    private Especialidad Entity
    {
        get;
        set;
    }
    #endregion
    #region "metodos"

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
    
    private void SaveEntity(Especialidad especialidad)
    {
        try
        {
            this.especialidadLogic.Save(especialidad);
        }
        catch (Exception ex)
        {
            lblError.Text = "Error: " + ex.Message;
        }
        
    }

    #endregion
    #region "metodos controles"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            lblError.Text = "";
        }
    }
    protected void nuevoLinkButton_Click(object sender, EventArgs e)
    {
        this.ABMPanel.Visible = true;
        this.gridActionsPanel.Visible = false;
        this.formActionsPanel.Visible = true;
        this.FormMode = TiposDatos.FormModes.Alta;
    }
    protected void editarLinkButton_Click(object sender, EventArgs e)
    {
        if (this.IsEntitySelected)
        {
            this.ABMPanel.Visible = true;
            this.gridActionsPanel.Visible = false;
            this.formActionsPanel.Visible = true;
            this.FormMode = TiposDatos.FormModes.Modificacion;
            currentEspecialidad = especialidadLogic.GetOne(this.SelectedID);
            txtDescripcion.Text = currentEspecialidad.Descripcion;
            currentEspecialidad.State = TiposDatos.States.Modified;

        }
    }
    protected void eliminarLinkButton_Click(object sender, EventArgs e)
    {
        if (this.IsEntitySelected)
        {
            this.FormMode = TiposDatos.FormModes.Baja;
            this.ABMPanel.Visible = true;
            this.gridActionsPanel.Visible = false;
            this.formActionsPanel.Visible = true;
            currentEspecialidad = especialidadLogic.GetOne(this.SelectedID);
            this.txtDescripcion.Text = currentEspecialidad.Descripcion;
            this.txtDescripcion.Enabled = false;
            currentEspecialidad.State = TiposDatos.States.Deleted;

        }
    }
    protected void dgvEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectedID = (int)this.dgvEspecialidades.SelectedValue;
        this.gridActionsPanel.Visible = true;
        this.ABMPanel.Visible = false;
        this.formActionsPanel.Visible = false;
    }
    protected void cancelarLinkButton_Click(object sender, EventArgs e)
    {
        this.txtDescripcion.Text = "";
        this.ABMPanel.Visible = false;
    }

    protected void aceptarLinkButton_Click(object sender, EventArgs e)
    {
        switch (this.FormMode)
        {
            case TiposDatos.FormModes.Alta:
                this.Entity = new Especialidad();
                this.Entity.Descripcion = txtDescripcion.Text;
                this.Entity.State = TiposDatos.States.New;
                this.SaveEntity(Entity);
                break;
            case TiposDatos.FormModes.Modificacion:

                this.Entity = new Especialidad();
                this.Entity.Id = this.SelectedID;
                this.Entity.State = TiposDatos.States.Modified;
                this.Entity.Descripcion = txtDescripcion.Text;
                this.SaveEntity(Entity);
                break;
            case TiposDatos.FormModes.Baja:
                this.Entity = new Especialidad();
                this.Entity.Id = this.SelectedID;
                this.Entity.State = TiposDatos.States.Deleted;
                this.SaveEntity(Entity);
                break;
            default:
                break;
        }
        this.ABMPanel.Visible = false;
        this.gridActionsPanel.Visible = true;
        this.txtDescripcion.Enabled = true;
        this.txtDescripcion.Text = "";
        this.formActionsPanel.Visible = false;
        dgvEspecialidades.DataBind();

    }
    #endregion


}