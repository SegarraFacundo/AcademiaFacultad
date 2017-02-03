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
using Util.CustomException;

namespace UI.Desktop
{
    public partial class Docentes : ApplicationForm
    {
        private DocenteLogic DocenteLogic;
        public Docentes()
        {
            this.DocenteLogic = new DocenteLogic();
            InitializeComponent();
        }
        private void Docentes_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void Listar()
        {
            this.dgvDocentes.AutoGenerateColumns = false;

            try
            {
                dgvDocentes.DataSource = DocenteLogic.GetAll();
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
            DocentesDesktop frmDocentesDesktop = new DocentesDesktop(ModoForm.Alta);
            frmDocentesDesktop.ShowDialog();
            frmDocentesDesktop.Dispose();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (base.ValidarDGV(dgvDocentes))
            { 
                try
                {
                    int idDocente = ((Business.Entities.Docente)this.dgvDocentes.SelectedRows[0].DataBoundItem).Id;
                    DocentesDesktop frmDocentesDesktop = new DocentesDesktop(idDocente, ModoForm.Modificacion);
                    frmDocentesDesktop.ShowDialog();
                    frmDocentesDesktop.Dispose();
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
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ValidarDGV(dgvDocentes))
            {
                try
                {
                    int ID = ((Business.Entities.Docente)this.dgvDocentes.SelectedRows[0].DataBoundItem).Id;
                    DocentesDesktop frmDocenteDesktop = new DocentesDesktop(ID, ApplicationForm.ModoForm.Baja);
                    frmDocenteDesktop.ShowDialog();
                    frmDocenteDesktop.Dispose();
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
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualziar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

    }
}
