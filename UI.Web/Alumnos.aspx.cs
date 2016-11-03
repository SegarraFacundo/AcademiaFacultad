using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;


public partial class Alumnos : System.Web.UI.Page
{
    public TiposDatos.FormModes FormMode
    {
        get { return (TiposDatos.FormModes)this.ViewState["FormMode"]; }
        set { this.ViewState["FormMode"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

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
        txtApellido.Text = "";
        txtNombre.Text = "";
        txtEmail.Text = "";
        txtFecNac.Text = "";
        txtLegajo.Text = "";
        txtDireccion.Text = "";
    }
    private void EnableForm(bool valor)
    {
        txtApellido.Enabled = valor;
        txtNombre.Enabled = valor;
        txtEmail.Enabled = valor;
        txtFecNac.Enabled = valor;
        txtLegajo.Enabled = valor;
        txtDireccion.Enabled = valor;
    }
}