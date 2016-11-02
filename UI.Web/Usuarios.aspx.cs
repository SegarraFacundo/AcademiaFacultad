﻿using System;
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
        this.nombreTextBox.Text = this.Entity.Nombre;
        this.apellidoTextBox.Text = this.Entity.Apellido;
        this.emailTextBox.Text = this.Entity.Email;
        this.habilidadoCheckBox.Checked = this.Entity.Habilitado;
        this.nombreUsuarioTextBox.Text = this.Entity.NombreUsuario;
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
        usuario.Nombre = this.nombreTextBox.Text;
        usuario.Apellido = this.apellidoTextBox.Text;
        usuario.Email = this.emailTextBox.Text;
        usuario.NombreUsuario = this.nombreUsuarioTextBox.Text;
        usuario.Clave = this.claveTextBox.Text;
        usuario.Habilitado = this.habilidadoCheckBox.Checked;
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
        this.nombreTextBox.Enabled = enable;
        this.apellidoTextBox.Enabled = enable;
        this.nombreUsuarioTextBox.Enabled = enable;
        this.emailTextBox.Enabled = enable;
        this.habilidadoCheckBox.Enabled = enable;
        this.claveTextBox.Visible = enable;
        this.repetirClaveTextBox.Visible = enable;
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
        this.nombreTextBox.Text = string.Empty;
        this.apellidoTextBox.Text = string.Empty;
        this.emailTextBox.Text = string.Empty;
        this.habilidadoCheckBox.Checked = false;
        this.nombreUsuarioTextBox.Text = string.Empty;
    }

    protected void cancelarLinkButton_Click(object sender, EventArgs e)
    {
        this.ClearForm();
        this.formPanel.Visible = false;
    }
}