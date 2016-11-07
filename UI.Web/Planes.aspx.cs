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

    private void SaveEntity(Plan plan)
    {
        this.planLogic.Save(plan);
    }

    private List<Materia> getListaMateriasSeleccionadas()
    {
        List<Materia> listaMaterias = new List<Materia>();

        foreach (GridViewRow row in dgvMaterias.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("chkSelect");
            if (cb != null && cb.Checked)
            {
                int materiaID = Convert.ToInt32(dgvMaterias.DataKeys[row.RowIndex].Value);
                Materia currentMateria = new Materia();
                currentMateria = materiaLogic.GetOne(materiaID);
                listaMaterias.Add(currentMateria);
            }
        }
        return listaMaterias;

    }
    #endregion

    #region "metodos controles"
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void dgvEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void nuevoLinkButton_Click(object sender, EventArgs e)
    {
        this.ABMPanel.Visible = true;
        this.FormMode = TiposDatos.FormModes.Alta;

    }
    protected void editarLinkButton_Click(object sender, EventArgs e)
    {

    }
    protected void eliminarLinkButton_Click(object sender, EventArgs e)
    {

    }
    protected void aceptarLinkButton_Click(object sender, EventArgs e)
    {
        //Primero guardamos el plan y desp las materias
        switch (this.FormMode)
        {
            case TiposDatos.FormModes.Alta:
                this.Entity = new Plan();
                this.Entity.Descripcion = txtDescripcion.Text;
                this.Entity.IdEspecialidad = cbEspecialidades.SelectedIndex + 1; //Como arranca de 0
                this.Entity.State = TiposDatos.States.New;
                this.Entity.ListaMaterias = getListaMateriasSeleccionadas();
                this.SaveEntity(Entity);
                break;
            case TiposDatos.FormModes.Modificacion:
                this.Entity = new Plan();
                this.Entity.Id = this.SelectedID;
                this.Entity.State = TiposDatos.States.Modified;
                this.Entity.Descripcion = txtDescripcion.Text;
                this.Entity.IdEspecialidad = cbEspecialidades.SelectedIndex + 1; //Como arranca de 0
                this.SaveEntity(Entity);
                break;
            case TiposDatos.FormModes.Baja:
                this.Entity = new Plan();
                this.Entity.Id = this.SelectedID;
                this.Entity.State = TiposDatos.States.Deleted;
                this.SaveEntity(Entity);
                break;
            default:
                break;
        }
        
        this.ABMPanel.Visible = false;
        this.dgvPlanes.DataBind();
    }
    protected void cancelarLinkButton_Click(object sender, EventArgs e)
    {

    }
    #endregion

    protected void dgvMaterias_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}