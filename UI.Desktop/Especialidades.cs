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
    public partial class Especialidades : ApplicationForm
    {

        private EspecialidadLogic especialidadLogic;

        public Especialidades()
        {
            this.especialidadLogic = new EspecialidadLogic();
            InitializeComponent();
        }

        private void Especialidades_Load(object sender, EventArgs e)
        {
            this.listar();
        }

        private void listar()
        {
            this.dgvEspecialidades.AutoGenerateColumns = false;
            try
            {
                dgvEspecialidades.DataSource = this.especialidadLogic.GetAll();
            }
            catch (NotFoundException ex)
            {
                Notificar(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CustomException ex)
            {
                Notificar(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Notificar(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.listar();
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
                try
                {
                    int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).Id;
                    EspecialidadDesktop frmEspecialidadesDesktop = new EspecialidadDesktop(ID, ModoForm.Modificacion);
                    frmEspecialidadesDesktop.ShowDialog();
                    this.listar();
                }
                catch (NotFoundException ex)
                {
                    Notificar(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (CustomException ex)
                {
                    Notificar(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    Notificar(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (base.ValidarDGV(dgvEspecialidades))
            {
                try
                {
                    int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).Id;
                    EspecialidadDesktop frmEspecialidadesDesktop = new EspecialidadDesktop(ID, ModoForm.Baja);
                    frmEspecialidadesDesktop.MapearADatos();
                    frmEspecialidadesDesktop.Show();
                }
                catch (NotFoundException ex)
                {
                    Notificar(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (CustomException ex)
                {
                    Notificar(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    Notificar(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
