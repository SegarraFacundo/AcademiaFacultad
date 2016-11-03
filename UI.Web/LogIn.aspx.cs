using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;
using Util;


public partial class LogIn : System.Web.UI.Page
{

    UsuarioLogic user;
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        user = new UsuarioLogic();
        Usuario currentUser = new Usuario();
        try
        {
            currentUser = user.LogIn(txtUsuario.Text, txtContraseña.Text);
            if (currentUser != null)
            {
                Response.Redirect("MainMenu.aspx");
            }
            else
            {
                lblError.Visible = true;
                lblError.Text += "Usuario no encontrado. Compruebe que las credenciales sean correctas";
            }
        }
        catch (Util.CustomException.NotFoundException ex)
        {
            lblError.Visible = true;
            lblError.Text += ex.Message;
        }
        catch (Util.CustomException.CustomException ex)
        {
            lblError.Visible = true;
            lblError.Text += ex.Message;
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text += ex.Message;
        }
    }
}