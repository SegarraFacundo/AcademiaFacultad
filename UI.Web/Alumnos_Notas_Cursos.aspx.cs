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

public partial class Alumnos_Notas_Cursos : System.Web.UI.Page
{

    AlumnoInscriptoLogic ail = new AlumnoInscriptoLogic();
    #region "propiedades"
    public TiposDatos.FormModes FormMode
    {
        get { return (TiposDatos.FormModes)this.ViewState["FormMode"]; }
        set { this.ViewState["FormMode"] = value; }
    }

    private AlumnoInscripto Entity
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

    private void SaveEntity(AlumnoInscripto inscripcion)
    {
        this.ail.Save(inscripcion);
    }

    #endregion



    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void editarLinkButton_Click(object sender, EventArgs e)
    {
        if (IsEntitySelected)
        {
            this.FormMode = TiposDatos.FormModes.Modificacion;
            this.PanelEditarNota.Visible = true;
            this.gridActionsPanel.Visible = false;
            AlumnoInscripto inscripcion = ail.GetOne(SelectedID);
            txtNota.Text = inscripcion.Nota.ToString();
            dgvAlumnosCurso.DataBind();
        }
       
    }
    protected void volverLinkButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("RegistroNotas.aspx");
    }
    protected void aceptarLinkButton_Click(object sender, EventArgs e)
    {
        this.Entity = new AlumnoInscripto();
        this.Entity.Nota = Convert.ToInt32(txtNota.Text);
        this.SaveEntity(Entity);
    }
    protected void cancelarLinkButton_Click(object sender, EventArgs e)
    {
        txtNota.Text = "";
        this.PanelEditarNota.Visible = false;
        this.gridActionsPanel.Visible = true;
    }
    protected void dgvAlumnosCurso_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectedID = (int)this.dgvAlumnosCurso.SelectedValue;
    }
}