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
        
        currentUser = user.LogIn(txtUsuario.Text, txtContraseña.Text);
        if (currentUser != null)
        {
            Response.Redirect("MainMenu.aspx");
        }
    }
}