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
    public partial class ComisionDesktop : ApplicationForm
    {
        ComisionLogic cl = new ComisionLogic();
        Comision comision;
        PlanLogic planLogic = new PlanLogic();
        public ComisionDesktop()
        {
            InitializeComponent();
        }
#region "Constructores"

        public ComisionDesktop(ModoForm modo) : this()
        {
            this.Text = "Nueva Comisión";
            this.btnGuardar.Text = "Guardar";
            this.Modo = modo;
            LoadPlanes();
        }

        public ComisionDesktop(int ID, ModoForm modo) :this()
        {
            this.Modo = modo;
            comision = cl.GetOne(ID);
            LoadPlanes();
            MapearDeDatos();
        }
#endregion

#region "Metodos"

        private void LoadPlanes()
        {
            cmbPlan.DisplayMember = "Descripcion";
            cmbPlan.ValueMember = "Id";
            try
            {
                cmbPlan.DataSource = planLogic.GetAll();
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

        public override void MapearDeDatos()
        {
            txtAnio.Text = comision.AnioEspecialidad.ToString();
            txtDescripcion.Text = comision.Descripcion;
            cmbPlan.SelectedValue = Convert.ToInt32(comision.IdPlan);
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    this.EnabledForm(true);
                    this.Text = "Nueva Comisión";
                    this.btnGuardar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.EnabledForm(false);
                    this.Text = "Eliminar Comisión";
                    this.btnGuardar.Text = "Eliminar";
                    break;
                case ModoForm.Modificacion:
                    this.EnabledForm(true);
                    this.Text = "Eliminar Comisión";
                    this.btnGuardar.Text = "Modificar";
                    break;
            }
        }
        public override void MapearADatos()
        {
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    Comision c = new Comision();
                    c.Descripcion = txtDescripcion.Text;
                    c.AnioEspecialidad = Convert.ToInt32(txtAnio.Text);
                    c.IdPlan = Convert.ToInt32(cmbPlan.SelectedValue);
                    c.State = TiposDatos.States.New;
                    comision = c;
                    break;
                case ModoForm.Baja:
                    comision.State = TiposDatos.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    comision.State = TiposDatos.States.Unmodified;
                    break;
                case ModoForm.Modificacion:
                    comision.Descripcion = txtDescripcion.Text;
                    comision.AnioEspecialidad = Convert.ToInt32(txtAnio.Text);
                    comision.IdPlan = Convert.ToInt32(cmbPlan.SelectedValue);;
                    comision.State = TiposDatos.States.Modified;
                    break;
            }
        }

        public override bool Validar()
        {
            if (txtAnio.Text == "" || txtDescripcion.Text == "")
            {
                MessageBox.Show("Por favor, complete los campos en blanco", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        public override void GuardarCambios()
        {
            try
            {
                this.MapearADatos();
                cl.Save(comision);  
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

        private void EnabledForm(bool v)
        {
            this.txtAnio.Enabled = v;
            this.txtDescripcion.Enabled = v;
            this.cmbPlan.Enabled = v;
        }
#endregion


#region "Metodos Controles"
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                this.Close();
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
#endregion



    }
}
