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
    public partial class Personas : ApplicationForm
    {
        public Personas()
        {
            InitializeComponent();
        }

        private void Personas_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void tlPersonas_Paint(object sender, PaintEventArgs e)
        {

        }

        public void Listar()
        {
            this.dgvPersonas.AutoGenerateColumns = false;
            PersonaLogic pl = new PersonaLogic();
            this.dgvPersonas.DataSource = pl.GetAll();
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
            PersonaDesktop pd = new PersonaDesktop(ApplicationForm.ModoForm.Alta);
            pd.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (base.ValidarDGV(dgvPersonas))
            {
                int ID = ((Business.Entities.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).Id;
                PersonaDesktop pd = new PersonaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                pd.MapearDeDatos();
                pd.ShowDialog();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (base.ValidarDGV(dgvPersonas))
            {
                int ID = ((Business.Entities.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).Id;
                PersonaDesktop pd = new PersonaDesktop(ID, ApplicationForm.ModoForm.Baja);
                pd.MapearDeDatos();
                pd.ShowDialog();
            }
        }
    }
}
