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
    public partial class Especialidades : ApplicationForm
    {
        public Especialidades()
        {
            InitializeComponent();
        }

        private void Especialidades_Load(object sender, EventArgs e)
        {
            this.listar();
        }

        private void listar()
        {
            this.dgvEspecialidades.AutoGenerateColumns = false;
            EspecialidadLogic eLogic = new EspecialidadLogic();
            dgvEspecialidades.DataSource = eLogic.getAll();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            EspecialidadDesktop frmEspecialidadesDesktop = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            frmEspecialidadesDesktop.ShowDialog();
            this.listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (base.ValidarDGV(dgvEspecialidades))
            {
                int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).Id;
                EspecialidadDesktop frmEspecialidadesDesktop = new EspecialidadDesktop(ID, ModoForm.Modificacion);
                frmEspecialidadesDesktop.ShowDialog();
                this.listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (base.ValidarDGV(dgvEspecialidades))
            {
                int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).Id;
                EspecialidadDesktop frmEspecialidadesDesktop = new EspecialidadDesktop(ID, ModoForm.Baja);
                frmEspecialidadesDesktop.MapearADatos();
                frmEspecialidadesDesktop.Show();
            }
            
        }



        

    }
}
