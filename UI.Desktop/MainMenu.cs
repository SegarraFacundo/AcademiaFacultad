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

        private void menuAlumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alumnos frmAlumnos = new Alumnos();
            frmAlumnos.ShowDialog();
        }


        private void menuUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios frmUsuario = new Usuarios();
            frmUsuario.ShowDialog();
            frmUsuario.Dispose();
        }

        private void menuAlumnosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Alumnos frmAlumnos = new Alumnos();
            frmAlumnos.ShowDialog();
            frmAlumnos.Dispose();
        }

        private void menuDocentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Docentes frmDocentes = new Docentes();
            frmDocentes.ShowDialog();
            frmDocentes.Dispose();
        }



    }
}
