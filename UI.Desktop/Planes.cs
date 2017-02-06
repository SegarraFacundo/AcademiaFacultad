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
using Util;
namespace UI.Desktop
{
    public partial class Planes : ApplicationForm
    {
        private PlanLogic planLogic = new PlanLogic();
        public Planes()
        {
            InitializeComponent();
        }

#region "Metodos"
        private void Listar()
        {
            dgvPlanes.DataSource = planLogic.GetAll();
        }
        #endregion

#region "Eventos / Metodos Controles"
        private void Planes_Load(object sender, EventArgs e)
        {
            this.Listar();
         }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            PlanesDesktop frmPlanesDesktop = new PlanesDesktop(ApplicationForm.ModoForm.Alta);
            frmPlanesDesktop.ShowDialog();
            frmPlanesDesktop.Dispose();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (ValidarDGV(dgvPlanes))
            {
                int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).Id;
                PlanesDesktop frmPlanesDesktop = new PlanesDesktop(ID, ModoForm.Modificacion);
                frmPlanesDesktop.ShowDialog();
                frmPlanesDesktop.Dispose();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ValidarDGV(dgvPlanes))
            {
                int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).Id;
                PlanesDesktop frmPlanesDesktop = new PlanesDesktop(ID, ModoForm.Baja);
                frmPlanesDesktop.ShowDialog();
                frmPlanesDesktop.Dispose();
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
