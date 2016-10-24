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

namespace UI.Desktop
{
    public partial class LogIn : ApplicationForm
    {
        private Usuario currentUser;
        public LogIn()
        {
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
                UsuarioLogic UserLogic = new UsuarioLogic();
                currentUser = UserLogic.LogIn(txtUser.Text, txtPass.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }          
           

            if (currentUser == null) {
                Notificar("Error", "Error de incio de seción, credenciales incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUser.Focus();
                return;
            }
            else
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
                MainMenu mainMenu = new MainMenu(currentUser);                
                mainMenu.ShowDialog();
                this.Close();
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
