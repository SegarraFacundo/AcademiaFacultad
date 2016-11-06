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
        dgvEspecialidades.DataBind();

    }
    private void SaveEntity(Especialidad especialidad)
    {
        this.especialidadLogic.Save(especialidad);
    }

    #endregion
    #region "metodos controles"
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void nuevoLinkButton_Click(object sender, EventArgs e)
    {
        this.ABMPanel.Visible = true;
        this.FormMode = TiposDatos.FormModes.Alta;
        txtDescripcion.Text = "";
    }
    protected void editarLinkButton_Click(object sender, EventArgs e)
    {
        if (this.IsEntitySelected)
        {
            this.ABMPanel.Visible = true;
            this.FormMode = TiposDatos.FormModes.Modificacion;
            currentEspecialidad = especialidadLogic.GetOne(this.SelectedID);
            txtDescripcion.Text = currentEspecialidad.Descripcion;
        }
    }
    protected void eliminarLinkButton_Click(object sender, EventArgs e)
    {
        if (this.IsEntitySelected)
        {
            this.FormMode = TiposDatos.FormModes.Baja;
            currentEspecialidad = especialidadLogic.GetOne(this.SelectedID);
            currentEspecialidad.State = TiposDatos.States.Deleted;
            SaveEntity(currentEspecialidad);
            dgvEspecialidades.DataBind();

        }
    }
    protected void dgvEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectedID = (int)this.dgvEspecialidades.SelectedValue;
        this.ABMPanel.Visible = false;
    }
    protected void cancelarLinkButton_Click(object sender, EventArgs e)
    {
        this.txtDescripcion.Text = "";
        this.ABMPanel.Visible = false;
    }
    #endregion


}