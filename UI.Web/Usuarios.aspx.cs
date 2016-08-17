﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

public partial class Usuarios : System.Web.UI.Page
{
    UsuarioLogic _logic;

    private UsuarioLogic Logic
    {
        get
        {
            if (_logic == null)
            {
                _logic = new UsuarioLogic();
            }
            return _logic;
        }
    }

    public enum FormModes
    {
        Alta,
        Baja,
        Modificacion
    }

    public FormModes FormMode
    {
        get { return (FormModes)this.ViewState["FormMode"]; }
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
        this.gridView.DataSource = this.Logic.GetAll();
        this.gridView.DataBind();
    }

    protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectedID = (int)this.gridView.SelectedValue;
        this.formPanel.Visible = false;
    }

    private void LoadForm(int id)
    {
        this.Entity = this.Logic.GetOne(id);
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
            this.FormMode = FormModes.Modificacion;
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
        this.Logic.Save(usuario);
    }

    protected void aceptarLinkButton_Click(object sender, EventArgs e)
    {
        switch(this.FormMode)
        {
            case FormModes.Modificacion:
                this.Entity = new Usuario();
                this.Entity.Id = this.SelectedID;
                this.Entity.State = BusinessEntity.States.Modified;
                this.LoadEntity(this.Entity);
                this.SaveEntity(this.Entity);
                this.LoadGrid();
                
                break;
            case FormModes.Baja:
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
            this.FormMode = FormModes.Baja;
            this.EnableForm(false);
            this.LoadForm(this.SelectedID);
        }
    }

    private void DeleteEntity(int id)
    {
        this.Logic.Delete(id);
    }
}