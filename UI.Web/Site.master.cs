using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Util.CustomException;

public partial class Site : System.Web.UI.MasterPage
{
    Usuario currentUsuario;
    UsuarioLogic usuarioLogic;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.isLogged();
    }
    protected void linkVolverMenu_Click(object sender, EventArgs e)
    {
        Response.Redirect("MainMenu.aspx");
    }

     public void isLogged() {

        this.usuarioLogic = new UsuarioLogic();

        if (Session["idUsuario"] == null)
        {
            Response.Redirect("LogIn.aspx");
        }

        try
        {
            int idUsuario = Convert.ToInt32(Session["idUsuario"]);
            this.currentUsuario = this.usuarioLogic.GetOne(idUsuario);

            bool noTienePermisos = true;

            if (noTienePermisos)
            {
                Session["idUsuario"] = null;
                Response.Redirect("Error404.aspx");
            }
        }
        catch (NotFoundException)
        {
            Session["idUsuario"] = null;
            Response.Redirect("Error404.aspx");
        }
        catch (Exception)
        {
            Session["idUsuario"] = null;
            Response.Redirect("Error500.aspx");
        }
    }
}
