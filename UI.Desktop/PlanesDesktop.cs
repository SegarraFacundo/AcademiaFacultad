using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Util;
using Util.CustomException;
using Business.Entities;
using Business.Logic;


namespace UI.Desktop
{
    
    public partial class PlanesDesktop : ApplicationForm
    {
        private MateriaLogic ml = new MateriaLogic();
        private Plan plan;
        private PlanLogic planLogic = new PlanLogic();
        private EspecialidadLogic el = new EspecialidadLogic();
        
        public PlanesDesktop()
        {
            InitializeComponent();
        }

        public PlanesDesktop(ModoForm modo) : this()
        {

        }

        public PlanesDesktop(int ID, ModoForm modo)
            : this()
        {
            try
            {
                plan = planLogic.GetOne(ID);
                LoadMaterias();
                LoadEspecialidades();
                MapearDeDatos();

                
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
        private void PlanesDesktop_Load(object sender, EventArgs e)
        {
                                    
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                GuardarCambios();
                this.Close();
            }
        }

        #region "Metodos"

        public override bool Validar()
        {
            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("Ingrese la descripción del Plan", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescripcion.Focus();
                return false;
            }
            return true;
        }

        #endregion

        public override void MapearDeDatos()
        {
            txtDescripcion.Text = plan.Descripcion;
            cmbEspecialidad.SelectedValue = plan.IdEspecialidad;
            try
            {
                plan.ListaMaterias = ml.GetMateriasPorPlan(plan.Id);
                foreach (Materia m in plan.ListaMaterias)
                {
                    foreach (DataGridViewRow row in dgvMaterias.Rows)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["Selected"];
                        if (m.Descripcion == row.Cells["desc_materia"].Value.ToString())
                        {
                            chk.TrueValue = true;
                        }
                    }
                }
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

        private void LoadEspecialidades()
        {
            cmbEspecialidad.DisplayMember = "Descripcion";
            cmbEspecialidad.ValueMember = "Id";
            try
            {
                this.cmbEspecialidad.DataSource = this.el.GetAll();
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

        public override void MapearADatos()
        {
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    Plan p = new Plan();
                    p.Descripcion = txtDescripcion.Text;
                    p.IdEspecialidad = Convert.ToInt32(cmbEspecialidad.SelectedValue);
                    p.State = TiposDatos.States.New;
                    this.plan = p;
                    break;
                case ModoForm.Modificacion:
                    this.plan.Descripcion = txtDescripcion.Text;
                    this.plan.IdEspecialidad = Convert.ToInt32(cmbEspecialidad.SelectedValue);
                    this.plan.State = TiposDatos.States.Modified;
                    break;
                case ModoForm.Consulta:
                    this.plan.State = TiposDatos.States.Unmodified;
                    break;
                case ModoForm.Baja:
                    this.plan.State = TiposDatos.States.Deleted;
                    break;

            }
                       
        }

        public override void GuardarCambios()
        {
            try
            {
                this.MapearADatos();
                planLogic.Save(plan);
            }
            catch (NotFoundException ex)
            {
                Notificar(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CustomException ex)
            {
                Notificar(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Notificar(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadMaterias()
        {
            this.dgvMaterias.AutoGenerateColumns = false;
            dgvMaterias.DataSource = ml.GetAllSinPlan();
        }
    }
}
