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

public partial class Planes : System.Web.UI.Page
{
    //El comentario mas inutil del universo
    PlanLogic planLogic = new PlanLogic();
    MateriaLogic materiaLogic = new MateriaLogic();
    #region "propiedades"
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
    public TiposDatos.FormModes FormMode
    {
        get { return (TiposDatos.FormModes)this.ViewState["FormMode"]; }
        set { this.ViewState["FormMode"] = value; }
    }

    private Plan Entity
    {
        get;
        set;
    }

    #endregion

    #region "metodos"

    private bool IsEntitySelected
    {
        get
        {
            return (this.SelectedID != 0);
        }
    }

    private void SaveEntity(Plan plan)
    {
        try
        {
            if (this.planLogic.Save(plan))
            {

            }
            else
            {
                lblError.Text = "Atencion: No se puede modificar las materias del plan porque ya tiene cursos, comisiones o alumnos asignados";
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("Error500.aspx");
        }
      

    }

    private List<Materia> getListaMateriasSeleccionadas()
    {
        List<Materia> listaMaterias = new List<Materia>();

        foreach (GridViewRow row in dgvMaterias.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("chkSelect");
            if (cb != null && cb.Checked)
            {
                int materiaID = Convert.ToInt32(dgvMaterias.DataKeys[row.RowIndex].Values["Id"]);
                Materia currentMateria = new Materia();
                currentMateria = materiaLogic.GetOne(materiaID);
                currentMateria.IdPlan = Entity.Id;
                listaMaterias.Add(currentMateria);
            }
        }
        return listaMaterias;

    }
    #endregion

    #region "metodos controles"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack)
        {
            dgvPlanes.DataBind();
            lblError.Text = "";
        }

    }
    protected void dgvEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectedID = (int)this.dgvPlanes.SelectedValue;
        this.formActionsPanel.Visible = false;
    }
    protected void nuevoLinkButton_Click(object sender, EventArgs e)
    {
        this.ABMPanel.Visible = true;
        this.FormMode = TiposDatos.FormModes.Alta;
        this.EnabledForm(true);
        this.ClearForm();
        this.formActionsPanel.Visible = true;

    }
    protected void editarLinkButton_Click(object sender, EventArgs e)
    {
        if (IsEntitySelected)
        {

            this.formActionsPanel.Visible = true;
            this.ABMPanel.Visible = true;
            this.gridActionsPanel.Visible = false;
            this.FormMode = TiposDatos.FormModes.Modificacion;
            this.EnabledForm(true);
            this.LoadForm(SelectedID);
        }
        

    }
    protected void eliminarLinkButton_Click(object sender, EventArgs e)
    {
        if (IsEntitySelected)
        {

            this.ABMPanel.Visible = true;
            this.gridActionsPanel.Visible = false;
            this.formActionsPanel.Visible = true;
            this.FormMode = TiposDatos.FormModes.Baja;
            this.EnabledForm(false);
            this.LoadForm(SelectedID);
            

        }
    }
    protected void aceptarLinkButton_Click(object sender, EventArgs e)
    {
        switch (this.FormMode)
        {
            case TiposDatos.FormModes.Alta:
                this.Entity = new Plan();
                this.Entity.Descripcion = txtDescripcion.Text;
                this.Entity.IdEspecialidad = Convert.ToInt32(cbEspecialidades.SelectedValue); 
                this.Entity.State = TiposDatos.States.New;
                this.Entity.ListaMaterias = getListaMateriasSeleccionadas();
                this.SaveEntity(Entity);
                break;
            case TiposDatos.FormModes.Modificacion:
                this.Entity = planLogic.GetOne(SelectedID);
                this.Entity.State = TiposDatos.States.Modified;
                this.Entity.Descripcion = txtDescripcion.Text;
                this.Entity.IdEspecialidad = Convert.ToInt32(cbEspecialidades.SelectedValue);
                this.Entity.ListaMaterias = getListaMateriasSeleccionadas();
                this.SaveEntity(Entity);
                break;
            case TiposDatos.FormModes.Baja:
                this.Entity = new Plan();
                this.Entity.Id = this.SelectedID;
                this.Entity.State = TiposDatos.States.Deleted;
                this.Entity.ListaMaterias = materiaLogic.GetMateriasPorPlan(Entity.Id);
                this.SaveEntity(Entity);
                break;
            default:
                break;
        }
        
        this.ABMPanel.Visible = false;
        this.gridActionsPanel.Visible = true;
        this.dgvPlanes.DataBind();
        this.ClearForm();
    }
    protected void cancelarLinkButton_Click(object sender, EventArgs e)
    {
        this.ClearForm();
        this.ABMPanel.Visible = false;
        this.gridActionsPanel.Visible = true;
    }
    #endregion
    private void ClearForm()
    {
        txtDescripcion.Text = "";
        dgvMaterias.DataBind();
    }
    private void EnabledForm(bool v)
    {
        txtDescripcion.Enabled = v;
        cbEspecialidades.Enabled = v;
        dgvMaterias.Enabled = v;
    }

    private void LoadForm(int id)
    {
        Plan p = planLogic.GetOne(id);
        txtDescripcion.Text = p.Descripcion;
        cbEspecialidades.SelectedValue = p.IdEspecialidad.ToString();
        p.ListaMaterias = materiaLogic.GetMateriasPorPlan(p.Id);
        //tildamos las materias que tenga el plan
        foreach (GridViewRow row in dgvMaterias.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("chkSelect");
            foreach (Materia m in p.ListaMaterias)
            {
                if (m.Descripcion == (dgvMaterias.DataKeys[row.RowIndex].Values["Descripcion"]).ToString())
                {
                    cb.Checked = true;
                }
            }
            
        }
    }
    protected void dgvMaterias_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}