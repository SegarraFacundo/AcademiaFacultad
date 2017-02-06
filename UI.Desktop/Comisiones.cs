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
    public partial class Comisiones : ApplicationForm
    {
        private ComisionLogic cl = new ComisionLogic();
        public Comisiones()
        {
            InitializeComponent();
        }

#region "Metodos"

        private void Listar()
        {
            dgvComisiones.AutoGenerateColumns = false;
            try
            {
                dgvComisiones.DataSource = cl.GetAll();
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


#region "Eventos Controles"
        private void Comisiones_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ComisionDesktop fmrComisionDesktop = new ComisionDesktop(ModoForm.Alta);
            fmrComisionDesktop.ShowDialog();
            this.Listar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (ValidarDGV(dgvComisiones))
            {
                int ID = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).Id;
                ComisionDesktop frmComisionDesktop = new ComisionDesktop(ID, ModoForm.Modificacion);
                frmComisionDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ValidarDGV(dgvComisiones))
            {
                int ID = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).Id;
                ComisionDesktop frmComisionDesktop = new ComisionDesktop(ID, ModoForm.Baja);
                frmComisionDesktop.ShowDialog();
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







    }
}
