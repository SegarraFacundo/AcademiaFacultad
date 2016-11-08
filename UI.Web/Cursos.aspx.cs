using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Util;
using Util.CustomException;

public partial class Cursos : System.Web.UI.Page
{

    CursoLogic cursoLogic = new CursoLogic();

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

    private Curso Entity
    {
        get;
        set;
    }

    private bool IsEntitySelected
    {
        get
        {
            return (this.SelectedID != 0);
        }
    }

    private void SaveEntity(Curso curso)
    {
        this.cursoLogic.Save(curso);
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            dgvCursos.DataBind();
        }
    }
    protected void nuevoLinkButton_Click(object sender, EventArgs e)
    {
        this.formActionsPanel.Visible = true;
        this.ABMPanel.Visible = true;
        this.gridActionsPanel.Visible = false;
        this.FormMode = TiposDatos.FormModes.Alta;
        this.EnabledForm(true);

    }
    protected void editarLinkButton_Click(object sender, EventArgs e)
    {
        if (IsEntitySelected)
        {
            this.EnabledForm(true);
            this.LoadForm(SelectedID);
            this.formActionsPanel.Visible = true;
            this.ABMPanel.Visible = true;
            this.gridActionsPanel.Visible = false;
            this.FormMode = TiposDatos.FormModes.Modificacion;            
        }
    }
    protected void eliminarLinkButton_Click(object sender, EventArgs e)
    {
        if (IsEntitySelected)
        {
            this.EnabledForm(false);
            this.LoadForm(SelectedID);
            this.formActionsPanel.Visible = true;
            this.ABMPanel.Visible = true;
            this.gridActionsPanel.Visible = false;
            this.FormMode = TiposDatos.FormModes.Baja;
        }
    }
    protected void aceptarLinkButton_Click(object sender, EventArgs e)
    {
        switch (this.FormMode)
        {
            case TiposDatos.FormModes.Alta:
                this.Entity = new Curso();
                this.Entity.State = TiposDatos.States.New;
                this.LoadEntity(Entity);
                this.SaveEntity(Entity);
                break;
            case TiposDatos.FormModes.Modificacion:
                this.Entity = new Curso();
                this.Entity.Id = this.SelectedID;
                this.Entity.State = TiposDatos.States.Modified;
                this.LoadEntity(Entity);
                this.SaveEntity(Entity);
                break;
            case TiposDatos.FormModes.Baja:
                this.Entity = new Curso();
                this.Entity.Id = this.SelectedID;
                this.Entity.State = TiposDatos.States.Deleted;
                this.SaveEntity(Entity);
                break;
            default:
                break;
        }

        this.ABMPanel.Visible = false;
        this.gridActionsPanel.Visible = true;
        this.formActionsPanel.Visible = false;
        this.dgvCursos.DataBind();
        this.ClearForm();
    }
    protected void cancelarLinkButton_Click(object sender, EventArgs e)
    {
        this.ClearForm();
        this.ABMPanel.Visible = false;
        this.gridActionsPanel.Visible = true;
    }
    private void ClearForm()
    {
        txtAñoCalendario.Text = "";
        txtCupo.Text = "";
        txtDescripcion.Text = "";
    }

    private void EnabledForm(bool v)
    {
        txtDescripcion.Enabled = v;
        txtCupo.Enabled = v;
        txtAñoCalendario.Enabled = v;
        cbComisiones.Enabled = v;
        cbMaterias.Enabled = v;
    }

    private void LoadForm(int id)
    {
        Curso c = cursoLogic.GetOne(id);
        txtAñoCalendario.Text = c.AnioCalendario.ToString();
        txtCupo.Text = c.Cupo.ToString();
        txtDescripcion.Text = c.Descripcion;        
        cbComisiones.SelectedValue = c.IdComision.ToString();
    }
    protected void dgvEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectedID = (int)this.dgvCursos.SelectedValue;
        this.formActionsPanel.Visible = false;
    }
    protected void LoadEntity(Curso c)
    {

        c.Descripcion = txtDescripcion.Text;
        c.Cupo = Convert.ToInt32(txtCupo.Text);
        c.AnioCalendario = Convert.ToInt32(txtAñoCalendario.Text);
        c.IdComision = Convert.ToInt32(cbComisiones.SelectedValue);
        
        //Deberiamos asignarle la materia que tenga el mismo plan que la comision
        //La que muestra el DropDownList no es mas que la materia sin id_plan asignado que sirve de muestra
        //Podriamos encararlo a travez de la comision, sacando su id_plan y el nombre del DropDownList

        ComisionLogic cl = new ComisionLogic();
        Comision comision = cl.GetOne(c.IdComision);

        MateriaLogic ml = new MateriaLogic();
        Materia materia = ml.SearchByName(comision.IdPlan, cbMaterias.SelectedItem.Text);
        if (materia != null)
        {
            c.IdMateria = materia.Id;
        }
    }
}