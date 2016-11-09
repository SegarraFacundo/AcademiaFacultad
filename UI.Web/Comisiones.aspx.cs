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

public partial class Comisiones : System.Web.UI.Page
{


    ComisionLogic comisionLogic = new ComisionLogic();

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

    private Comision Entity
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

    private void SaveEntity(Comision comision)
    {
        this.comisionLogic.Save(comision);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (this.IsPostBack)
        {
            dgvComisiones.DataBind();           
        }
        //Verificamos los permisos que tenga el usuario
        int idUsuario = Convert.ToInt32(Session["idUsuario"]);
        //Obtenemos los permisos del usuario
        ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
        ModuloUsuario moduloUser = mul.getPermisosUsuario(idUsuario);

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
        }
        
            

    }
    protected void nuevoLinkButton_Click(object sender, EventArgs e)
    {
        this.ABMPanel.Visible = true;
        this.gridActionsPanel.Visible = false;
        this.FormMode = TiposDatos.FormModes.Alta;
        this.EnabledForm(true);
        this.ClearForm();
        this.formActionsPanel.Visible = true;
    }
    protected void editarLinkButton_Click(object sender, EventArgs e)
    {
        if (IsEntitySelected)
        {
            this.ABMPanel.Visible = true;
            this.gridActionsPanel.Visible = false;
            this.formActionsPanel.Visible = true;
            this.EnabledForm(true);
            this.FormMode = TiposDatos.FormModes.Modificacion;
            this.LoadForm(SelectedID);

        }
    }
    protected void eliminarLinkButton_Click(object sender, EventArgs e)
    {
        if (IsEntitySelected)
        {
            this.gridActionsPanel.Visible = false;
            this.ABMPanel.Visible = true;
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
                this.Entity = new Comision();
                this.Entity.State = TiposDatos.States.New;
                this.LoadEntity(Entity);
                this.SaveEntity(Entity);
                break;
            case TiposDatos.FormModes.Modificacion:
                this.Entity = new Comision();
                this.Entity.Id = this.SelectedID;
                this.Entity.State = TiposDatos.States.Modified;
                this.LoadEntity(Entity);
                this.SaveEntity(Entity);
                break;
            case TiposDatos.FormModes.Baja:
                this.Entity = new Comision();
                this.Entity.Id = this.SelectedID;
                this.Entity.State = TiposDatos.States.Deleted;
                this.SaveEntity(Entity);
                break;
            default:
                break;
        }
        this.formActionsPanel.Visible = false;
        this.ABMPanel.Visible = false;
        this.ClearForm();
        this.gridActionsPanel.Visible = true;
        this.dgvComisiones.DataBind();
    }
    protected void cancelarLinkButton_Click(object sender, EventArgs e)
    {
        this.ClearForm();
        this.ABMPanel.Visible = false;
        this.gridActionsPanel.Visible = true;
    }

    private void EnabledForm(bool v)
    {
        txtAñoEspecialidad.Enabled = v;
        txtDescripcion.Enabled = v;
        cbPlanes.Enabled = v;
    }
    private void ClearForm()
    {
        txtAñoEspecialidad.Text = "";
        txtDescripcion.Text = ""; 
    }

    private void LoadForm(int id)
    {
        Comision c = comisionLogic.GetOne(id);
        txtAñoEspecialidad.Text = c.AnioEspecialidad.ToString();
        txtDescripcion.Text = c.Descripcion;
        cbPlanes.SelectedValue = c.IdPlan.ToString();
    }

    protected void dgvEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectedID = (int)this.dgvComisiones.SelectedValue;
        this.formActionsPanel.Visible = false;
    }
    private void LoadEntity(Comision c)
    {
        this.Entity.Descripcion = txtDescripcion.Text;
        this.Entity.AnioEspecialidad = Convert.ToInt32(txtAñoEspecialidad.Text);
        this.Entity.IdPlan = Convert.ToInt32(cbPlanes.SelectedValue);
    }
}