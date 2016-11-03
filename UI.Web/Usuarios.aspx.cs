using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Util;

public partial class Usuarios : System.Web.UI.Page
{
    UsuarioLogic _usuarioLogic;

    private UsuarioLogic UsuarioLogic
    {
        get
        {
            if (_usuarioLogic == null)
            {
                _usuarioLogic = new UsuarioLogic();
            }
            return _usuarioLogic;
        }
    }

    public TiposDatos.FormModes FormMode
    {
        get { return (TiposDatos.FormModes)this.ViewState["FormMode"]; }
        set { this.ViewState["FormMode"] = value; }
    }

    private Usuario Entity
    {
        get;
        set;
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

    private bool IsEntitySelected
    {
        get
        {
            return (this.SelectedID != 0);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if ( ! this.IsPostBack )
        {
            this.LoadGrid();
        }
    }

    private void LoadGrid()
    {
        this.gridView.DataSource = this.UsuarioLogic.GetAll();
        this.gridView.DataBind();
    }

    protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectedID = (int)this.gridView.SelectedValue;
        this.formPanel.Visible = false;
    }

    private void LoadForm(int id)
    {
        this.Entity = this.UsuarioLogic.GetOne(id);
        this.txtNombre.Text = this.Entity.Nombre;
        this.txtApellido.Text = this.Entity.Apellido;
        this.txtEmail.Text = this.Entity.Email;
        this.chkHabilitado.Checked = this.Entity.Habilitado;
        this.txtNombreUsuario.Text = this.Entity.NombreUsuario;
    }

    protected void editarLinkButton_Click(object sender, EventArgs e)
    {
        if (this.IsEntitySelected)
        {
            this.formPanel.Visible = true;
            this.FormMode = TiposDatos.FormModes.Modificacion;
            this.EnableForm(true);
            this.LoadForm(this.SelectedID);
        }
    }

    private void LoadEntity(Usuario usuario)
    {
        usuario.Nombre = this.txtNombre.Text;
        usuario.Apellido = this.txtApellido.Text;
        usuario.Email = this.txtEmail.Text;
        usuario.NombreUsuario = this.txtNombreUsuario.Text;
        usuario.Clave = this.txtClave.Text;
        usuario.Habilitado = this.chkHabilitado.Checked;
    }

    private void SaveEntity(Usuario usuario)
    {
        this.UsuarioLogic.Save(usuario);
    }

    protected void aceptarLinkButton_Click(object sender, EventArgs e)
    {
        switch(this.FormMode)
        {
            case TiposDatos.FormModes.Alta:
                this.Entity = new Usuario();
                this.LoadEntity(this.Entity);
                this.SaveEntity(this.Entity);
                this.LoadGrid();
                break;
            case TiposDatos.FormModes.Modificacion:
                this.Entity = new Usuario();
                this.Entity.Id = this.SelectedID;
                this.Entity.State = TiposDatos.States.Modified;
                this.LoadEntity(this.Entity);
                this.SaveEntity(this.Entity);
                this.LoadGrid();
                
                break;
            case TiposDatos.FormModes.Baja:
                this.DeleteEntity(this.SelectedID);
                this.LoadGrid();
                break;
            default:
                break;
        }
        this.formPanel.Visible = false;
    }

    private void EnableForm(bool enable)
    {
        this.txtNombre.Enabled = enable;
        this.txtApellido.Enabled = enable;
        this.txtNombreUsuario.Enabled = enable;
        this.txtEmail.Enabled = enable;
        this.chkHabilitado.Enabled = enable;
        this.txtClave.Visible = enable;
        this.txtRepetirClave.Visible = enable;
        this.claveLabel.Visible = enable;
        this.repetirClaveLabel.Visible = enable;
    }

    protected void eliminarLinkButton_Click(object sender, EventArgs e)
    {
        if (this.IsEntitySelected)
        {
            this.formPanel.Visible = true;
            this.FormMode = TiposDatos.FormModes.Baja;
            this.EnableForm(false);
            this.LoadForm(this.SelectedID);
        }
    }

    private void DeleteEntity(int id)
    {
        this.UsuarioLogic.Delete(id);
    }

    protected void nuevoLinkButton_Click(object sender, EventArgs e)
    {
        this.formPanel.Visible = true;
        this.FormMode = TiposDatos.FormModes.Alta;
        this.ClearForm();
        this.EnableForm(true);
    }

    private void ClearForm()
    {
        this.txtNombre.Text = string.Empty;
        this.txtApellido.Text = string.Empty;
        this.txtEmail.Text = string.Empty;
        this.chkHabilitado.Checked = false;
        this.txtNombreUsuario.Text = string.Empty;
    }

    protected void cancelarLinkButton_Click(object sender, EventArgs e)
    {
        this.ClearForm();
        this.formPanel.Visible = false;
    }
}