using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;
using Util;
using Util.CustomException;

namespace UI.Desktop
{
    public partial class LogIn : ApplicationForm
    {
        private Usuario usuario;

        private UsuarioLogic usuarioLogic;

        private AdministradorLogic administradorLogic;

        public LogIn()
        {
            this.usuarioLogic = new UsuarioLogic();
            this.administradorLogic = new AdministradorLogic();
            InitializeComponent();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.userName != string.Empty)
            {
                txtUser.Text = Properties.Settings.Default.userName;
                txtPass.Text = Properties.Settings.Default.passUser;
                chkRecordar.Checked = Properties.Settings.Default.rememberMe;
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                this.usuario = this.usuarioLogic.LogIn(txtUser.Text, txtPass.Text);
            }
            catch (NotFoundException ex)
            {
                Notificar(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CustomException ex)
            {
                Notificar(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Notificar(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if (this.usuario == null) {
                Notificar("Error", "Error de inicio de sesión, credenciales incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUser.Focus();
                return;
            }
            else
            {
                try
                {
                    Administrador administrador = this.administradorLogic.GetOne(this.usuario.IdPersona);

                    if (administrador.Id != 0)
                    {
                        if (chkRecordar.Checked)
                        {
                            //Estas son propiedades que yo mismo defini del proyecto UI.Desktop, son como variables a las cuales se puede acceder
                            //Para acceder: click derecho UI.Desktop->Propiedades->Configuraciones y ahi estan, no se si es la manera mas eficiente, pero funciona.
                            Properties.Settings.Default.userName = txtUser.Text;
                            Properties.Settings.Default.passUser = txtPass.Text;
                            Properties.Settings.Default.rememberMe = chkRecordar.Checked;
                            Properties.Settings.Default.Save();
                        }
                        else
                        {
                            Properties.Settings.Default.userName = "";
                            Properties.Settings.Default.passUser = "";
                            Properties.Settings.Default.rememberMe = false;
                            Properties.Settings.Default.Save();
                        }
                        this.Hide();
                        MainMenu mainMenu = new MainMenu(this.usuario);
                        mainMenu.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        Notificar("Info", "No inicio de sesión, no tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtUser.Focus();
                        return;
                    }
                }
                catch (NotFoundException ex)
                {
                    Notificar(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (CustomException ex)
                {
                    Notificar(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    Notificar(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnIngresar_Click(null, null);
            }


        }



    }
}
