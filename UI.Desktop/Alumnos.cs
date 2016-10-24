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
using Business.Logic;

namespace UI.Desktop
{
    public partial class Alumnos : ApplicationForm
    {
        public Alumnos()
        {
            InitializeComponent();
        }

        private void Alumnos_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void tlAlumnos_Paint(object sender, PaintEventArgs e)
        {

        }

        public void Listar()
        {
            this.dgvAlumnos.AutoGenerateColumns = false;
            AlumnoLogic al = new AlumnoLogic();
            this.dgvAlumnos.DataSource = al.GetAll();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            AlumnoDesktop ad = new AlumnoDesktop(ApplicationForm.ModoForm.Alta);
            ad.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (base.ValidarDGV(dgvAlumnos))
            {
                int ID = ((Business.Entities.Alumno)this.dgvAlumnos.SelectedRows[0].DataBoundItem).Id;
                AlumnoDesktop ad = new AlumnoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                ad.MapearDeDatos();
                ad.ShowDialog();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (base.ValidarDGV(dgvAlumnos))
            {
                int ID = ((Business.Entities.Alumno)this.dgvAlumnos.SelectedRows[0].DataBoundItem).Id;
                AlumnoDesktop ad = new AlumnoDesktop(ID, ApplicationForm.ModoForm.Baja);
                ad.MapearDeDatos();
                ad.ShowDialog();
            }
        }
    }
}
