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


public partial class LogIn : System.Web.UI.Page
{

    private UsuarioLogic usuarioLogic;

    private Usuario currentUsuario;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        this.usuarioLogic = new UsuarioLogic();
        this.currentUsuario = new Usuario();

        if (Session["idUsuario"] != null)
        {
            try
            {
                int idUsuario = Convert.ToInt32(Session["idUsuario"]);
                this.currentUsuario = this.usuarioLogic.GetOne(idUsuario);
                Response.Redirect("MainMenu.aspx");
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
    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        try
        {
            this.currentUsuario = this.usuarioLogic.LogIn(txtUsuario.Text, txtContraseña.Text);
            if (this.currentUsuario != null)
            {
                Session["idUsuario"] = this.currentUsuario.Id.ToString();
                Session["id_persona"] = this.currentUsuario.IdPersona.ToString();

                Response.Redirect("MainMenu.aspx", false);
            }
            else
            {
                Session["idUsuario"] = null;
                this.lbError.Text = "Credenciales incorrectas";
            }
        }
        catch(NotFoundException)
        {
            Session["idUsuario"] = null;
            throw;
        }
        catch (Exception ex)
        {
            Session["idUsuario"] = null;
            throw ex;  
        }

    }
}