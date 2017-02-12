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
using Util;
using Util.CustomException;

namespace UI.Desktop
{
    public partial class Cursos : ApplicationForm
    {
        private CursoLogic cl = new CursoLogic();
        private Curso curso = new Curso();
        public Cursos()
        {
            InitializeComponent();
            this.Listar();
        }
#region "Metodos Controles"
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CursoDesktop frmCursoDesktop = new CursoDesktop(ModoForm.Alta);
            frmCursoDesktop.ShowDialog();
            this.Listar();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (ValidarDGV(dgvCursos))
            {
                int ID = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).Id;
                CursoDesktop frmCursoDesktop = new CursoDesktop(ID, ModoForm.Modificacion);
                frmCursoDesktop.ShowDialog();
                this.Listar();
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ValidarDGV(dgvCursos))
            {
                int ID = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).Id;
                CursoDesktop frmCursoDesktop = new CursoDesktop(ID, ModoForm.Baja);
                frmCursoDesktop.ShowDialog();
                this.Listar();
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
#endregion

#region "Metodos"
        private void Listar()
        {
            try
            {
                dgvCursos.AutoGenerateColumns = false;
                dgvCursos.DataSource = cl.GetAll();
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

#endregion



        

       
      
    }
}
