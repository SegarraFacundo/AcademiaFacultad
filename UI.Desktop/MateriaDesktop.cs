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
using Util.CustomException;

namespace UI.Desktop
{
    public partial class MateriaDesktop : ApplicationForm
    {
        private MateriaLogic ml = new MateriaLogic();
        private PlanLogic pl = new PlanLogic();
        private Materia materia;
        
        public MateriaDesktop()
        {
            InitializeComponent();
        }

#region "Constructores"

        public MateriaDesktop(ModoForm modo) :this ()
        {
            this.Modo = modo;
        }
        public MateriaDesktop(int ID, ModoForm modo)
            : this()
        {
            this.Modo = modo;
            try
            {
                materia = ml.GetOne(ID);
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
#endregion

#region "Metodos"


        public override void MapearADatos()
        {
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    Materia m = new Materia();
                    m.HsSemanales = Convert.ToInt32(txtHorasSemanales.Text);
                    m.HsTotales = Convert.ToInt32(txtHorasTotales.Text);
                    m.Descripcion = txtDescripcion.Text;
                    m.State = Util.TiposDatos.States.New;
                    materia = m;
                    break;
                case ModoForm.Modificacion:
                    materia.HsSemanales = Convert.ToInt32(txtHorasSemanales.Text);
                    materia.HsTotales = Convert.ToInt32(txtHorasTotales.Text);
                    materia.Descripcion = txtDescripcion.Text;
                    materia.State = Util.TiposDatos.States.Modified;
                    break;
                case ModoForm.Baja:
                    materia.State = Util.TiposDatos.States.Deleted;
                    break;
            }
        }
        public override void MapearDeDatos()
        {
            if (materia == null) { return; }

            txtDescripcion.Text = materia.Descripcion;
            txtHorasSemanales.Text = materia.HsSemanales.ToString();
            txtHorasTotales.Text = materia.HsTotales.ToString();
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    btnGuardar.Text = "Guardar";
                    this.EnabledForm(true);
                    break;
                case ModoForm.Modificacion:                    
                    btnGuardar.Text = "Modificar";
                    this.EnabledForm(true);
                    break;
                case ModoForm.Baja:
                    btnGuardar.Text = "Eliminar";
                    this.EnabledForm(false);
                    break;
            }
        }
        public override bool Validar()
        {
            if (txtDescripcion.Text == "" || txtHorasSemanales.Text == "" || txtHorasTotales.Text == "")
            {
                MessageBox.Show("Por favor complete los espacios en blanco", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        public override void GuardarCambios()
        {
            try
            {
                if (this.Validar())
                {
                    this.MapearADatos();
                    ml.Save(materia);
                    this.Close();
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
        private void EnabledForm(bool v)
        {
            this.txtDescripcion.Enabled = v;
            this.txtHorasSemanales.Enabled = v;
            this.txtHorasTotales.Enabled = v;
        }
#endregion

#region "Controles"

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.GuardarCambios();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
#endregion



     


    }
}
