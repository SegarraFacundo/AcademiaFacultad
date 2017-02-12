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
   
    public partial class CursoDesktop : ApplicationForm
    {
        private Curso curso;
        private CursoLogic cl = new CursoLogic();
        private MateriaLogic ml = new MateriaLogic();
        private ComisionLogic comisionLogic = new ComisionLogic();
        public CursoDesktop()
        {
            InitializeComponent();
        }

#region "Constructores"

        public CursoDesktop(ModoForm modo)
            : this()
        {
            this.Modo = modo;
            LoadComboBoxes();
        }

        public CursoDesktop(int Id, ModoForm modo)
            : this()
        {
            try
            {
                this.Modo = modo;
                curso = cl.GetOne(Id);
                LoadComboBoxes();
                this.MapearDeDatos();

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
        public override bool Validar()
        {
            if (txtAnio.Text == "" || txtCupo.Text == "" || txtDescripcion.Text == "")
            {
                MessageBox.Show("Por favor, complete los espacios en blanco", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private int GetIdMateria()
        {
            //Buscamos el idMateria a travez de la comision, sacando su id_plan y el nombre del DropDownList
            Curso c = new Curso();
            ComisionLogic cl = new ComisionLogic();
            Comision comision = cl.GetOne(Convert.ToInt32(cmbComisiones.SelectedValue));

            MateriaLogic ml = new MateriaLogic();
            string nombreMateria = this.cmbMaterias.GetItemText(this.cmbMaterias.SelectedItem);
            Materia materia = ml.SearchByName(comision.IdPlan, nombreMateria);
            if (materia != null)
            {
                return materia.Id;
            }
            return 0;
        }
        public override void MapearADatos()
        {
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    Curso c = new Curso();
                    c.Descripcion = txtDescripcion.Text;
                    c.AnioCalendario = Convert.ToInt32(txtAnio.Text);
                    c.Cupo = Convert.ToInt32(txtCupo.Text);
                    c.IdComision = Convert.ToInt32(cmbComisiones.SelectedValue);
                    c.IdMateria = GetIdMateria();
                    if (c.IdMateria == 0)
                    {
                        MessageBox.Show("Ocurrio un error al recuperar la materia. No se guardaran los cambios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        break;
                    }
                    c.State = TiposDatos.States.New;
                    curso = c;
                    break;
                case ModoForm.Baja:
                    curso.State = TiposDatos.States.Deleted;
                    break;
                case ModoForm.Modificacion:
                    curso.Descripcion = txtDescripcion.Text;
                    curso.AnioCalendario = Convert.ToInt32(txtAnio.Text);
                    curso.Cupo = Convert.ToInt32(txtCupo.Text);
                    curso.IdComision = Convert.ToInt32(cmbComisiones.SelectedValue);
                    curso.IdMateria = GetIdMateria();
                    if (curso.IdMateria == 0)
                    {
                        MessageBox.Show("Ocurrio un error al recuperar la materia. No se guardaran los cambios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        break;
                    }                   
                    curso.State = TiposDatos.States.Modified;
                    break;
            }
        }
        public override void MapearDeDatos()
        {
            txtDescripcion.Text = curso.Descripcion;
            txtCupo.Text = curso.Cupo.ToString();
            txtAnio.Text = curso.AnioCalendario.ToString();
            cmbComisiones.SelectedValue = curso.IdComision;
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    btnGuardar.Text = "Guardar";
                    EnabledForm(true);
                    break;
                case ModoForm.Baja:
                    btnGuardar.Text = "Eliminar";
                    EnabledForm(false);
                    break;
                case ModoForm.Modificacion:
                    btnGuardar.Text = "Modificar";
                    EnabledForm(true);
                    break;
            }
        }
        private void EnabledForm(bool v)
        {
            this.txtAnio.Enabled = v;
            this.txtCupo.Enabled = v;
            this.txtDescripcion.Enabled = v;
            this.cmbComisiones.Enabled = v;
            this.cmbMaterias.Enabled = v;
        }
#endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.GuardarCambios();
        }
        public override void GuardarCambios()
        {
            if (this.Validar())
                try
                {
                    this.MapearADatos();
                    this.cl.Save(curso);
                    this.Close();
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
        private void LoadComboBoxes()
        {
            cmbComisiones.DisplayMember = "Descripcion";
            cmbComisiones.ValueMember = "Id";
            cmbMaterias.DisplayMember = "Descripcion";
            cmbMaterias.ValueMember = "Id";

            try
            {
                cmbComisiones.DataSource = comisionLogic.GetAll();
                cmbMaterias.DataSource = ml.GetAllSinPlan();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
