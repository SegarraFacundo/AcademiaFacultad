using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;
using Util;
using Util.CustomException;

public partial class CambiarPassword : System.Web.UI.Page
{
    UsuarioLogic userLogic = new UsuarioLogic();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void aceptarLinkButton_Click(object sender, EventArgs e)
    {

        int idUsuario = Convert.ToInt32(Session["idUsuario"]);
        if (txtNuevoPass.Text == txtNuevoPass2.Text)
        {
            try
            {
                Usuario currentUser = userLogic.GetOne(idUsuario);
                currentUser.CambiaClave = true;
                if (userLogic.VerificarClaves(currentUser, txtNuevoPass.Text))
                {
                    currentUser.Clave = txtNuevoPass.Text;
                    currentUser.State = TiposDatos.States.Modified;
                    userLogic.Save(currentUser);
                }
                else
                {
                    labelError.Text = "Error, verifique la clave anterior y que la nueva clave cumpla con las requerimientos solicitados.";
                }
            }
            catch (Exception ex)
            {
                labelError.Text = "Error: " + ex.Message;
            }
        }

      

    }


    protected void cancelarLinkButton_Click(object sender, EventArgs e)
    {
        txtNuevoPass.Text = "";
        txtNuevoPass2.Text = "";
        txtPassAnterior.Text = "";
        Response.Redirect("MainMenu.aspx");
    }
}