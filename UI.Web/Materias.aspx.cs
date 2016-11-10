using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util.CustomException;
using Util;
using Business.Entities;
using Business.Logic;
public partial class Materias : System.Web.UI.Page
{
    MateriaLogic materiaLogic = new MateriaLogic();
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

    private void LoadEntity(Materia materia)
    {
        materia.HsSemanales = Convert.ToInt32(txtHorasSemales.Text);
        materia.HsTotales = Convert.ToInt32(txtHorasTotales.Text);
        materia.Descripcion = txtDescripcion.Text;
        materia.IdPlan = cbPlanes.SelectedIndex + 1;
    }

    private void SaveEntity(Materia materia)
    {
        this.materiaLogic.Save(materia);
    }

    public TiposDatos.FormModes FormMode
    {
        get { return (TiposDatos.FormModes)this.ViewState["FormMode"]; }
        set { this.ViewState["FormMode"] = value; }
    }

    private Materia Entity
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            dgvMaterias.DataBind();
        }
        //Verificamos los permisos que tenga el usuario
        int idUsuario = Convert.ToInt32(Session["idUsuario"]);
        //Obtenemos los permisos del usuario5
        /*ModuloUsuario moduloUser = mul.getPermisosUsuario(idUsuario);

        if (!moduloUser.PermiteAlta)
        {
            nuevoLinkButton.Visible = false;
        }
        if (!moduloUser.PermiteBaja)
        {
            eliminarLinkButton.Visible = false;
        }
        if (!moduloUser.PermiteModificacion)
        {
            editarLinkButton.Visible = false;
        }*/
    }
    protected void nuevoLinkButton_Click(object sender, EventArgs e)
    {
        this.EnabledForm(true);
        this.ABMPanel.Visible = true;
        this.FormMode = TiposDatos.FormModes.Alta;
        this.formActionsPanel.Visible = true;
    }
    protected void editarLinkButton_Click(object sender, EventArgs e)
    {
        if (this.IsEntitySelected)
        {
            this.EnabledForm(true);
            this.ABMPanel.Visible = true;
            this.FormMode = TiposDatos.FormModes.Modificacion;
            this.LoadForm(SelectedID);
            this.formActionsPanel.Visible = true;
        }
    }

    private void LoadForm(int id)
    {
        Materia m = materiaLogic.GetOne(id);
        txtDescripcion.Text = m.Descripcion;
        txtHorasSemales.Text = m.HsSemanales.ToString();
        txtHorasTotales.Text = m.HsTotales.ToString();
    }
    protected void eliminarLinkButton_Click(object sender, EventArgs e)
    {
        if (this.IsEntitySelected)
        {
            this.EnabledForm(false);
            this.ABMPanel.Visible = true;
            this.formActionsPanel.Visible = true;
            this.FormMode = TiposDatos.FormModes.Baja;
            this.LoadForm(this.SelectedID);
        }
    }
    protected void aceptarLinkButton_Click(object sender, EventArgs e)
    {
        switch (this.FormMode)
        {
            case TiposDatos.FormModes.Alta:
                this.Entity = new Materia();
                this.Entity.State = TiposDatos.States.New;
                this.LoadEntity(Entity);
                this.SaveEntity(Entity);
                break;
            case TiposDatos.FormModes.Modificacion:
                this.Entity = new Materia();
                this.Entity.Id = this.SelectedID;
                this.Entity.State = TiposDatos.States.Modified;
                this.LoadEntity(Entity);
                this.SaveEntity(Entity);
                break;
            case TiposDatos.FormModes.Baja:
                this.Entity = new Materia();
                this.Entity.Id = this.SelectedID;
                this.Entity.State = TiposDatos.States.Deleted;
                this.SaveEntity(Entity);
                break;
            default:
                break;
        }
        this.ABMPanel.Visible = false;        
        this.ClearForm();        
        this.dgvMaterias.DataBind();
    }
    protected void cancelarLinkButton_Click(object sender, EventArgs e)
    {
        this.ClearForm();
        this.ABMPanel.Visible = false;
        this.formActionsPanel.Visible = false;
    }
    protected void dgvMaterias_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectedID = (int)this.dgvMaterias.SelectedValue;
        this.formActionsPanel.Visible = false;
    }

    private void ClearForm()
    {
        txtDescripcion.Text = "";
        txtHorasSemales.Text = "";
        txtHorasTotales.Text = "";
    }
    private void EnabledForm(bool v)
    {
        txtHorasTotales.Enabled = v;
        txtHorasSemales.Enabled = v;
        txtDescripcion.Enabled = v;
        cbPlanes.Enabled = v;
    }
}