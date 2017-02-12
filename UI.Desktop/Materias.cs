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
    public partial class Materias : ApplicationForm
    {

        private MateriaLogic ml = new MateriaLogic();
        public Materias()
        {
            InitializeComponent();
            this.Listar();
        }

#region "Metodos / Eventos Controles
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }
        private void Listar()
        {
            dgvMaterias.AutoGenerateColumns = false;
            try
            {
                this.dgvMaterias.DataSource = ml.GetAllSinPlan();
            }
            catch (NotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CustomException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MateriaDesktop frmMateriaDesktop = new MateriaDesktop(ModoForm.Alta);
            frmMateriaDesktop.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (ValidarDGV(dgvMaterias))
            {
                int ID = ((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).Id;
                MateriaDesktop frmMateriaDesktop = new MateriaDesktop(ID, ModoForm.Modificacion);
                frmMateriaDesktop.ShowDialog();
            }
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ValidarDGV(dgvMaterias)) 
            {
                int ID = ((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).Id;
                MateriaDesktop frmMateriaDesktop = new MateriaDesktop(ID, ModoForm.Baja);
                frmMateriaDesktop.ShowDialog();
            }            
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
#endregion



      
    }
}
