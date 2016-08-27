using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;

namespace UI.Desktop
{
    public partial class MainMenu : ApplicationForm
    {
        private Usuario usuario;
        public MainMenu(Usuario u)
        {
            InitializeComponent();
            usuario = u;
            label1.Text = u.Apellido + ", " + u.Nombre;
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios formUsuarios = new Usuarios();
            formUsuarios.ShowDialog();
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Especialidades frmEspecialidades = new Especialidades();
            frmEspecialidades.ShowDialog();
        }


    }
}
