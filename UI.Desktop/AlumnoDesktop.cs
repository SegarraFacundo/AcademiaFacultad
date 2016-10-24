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

namespace UI.Desktop
{
    public partial class AlumnoDesktop : ApplicationForm
    {
        public Alumno AlumnoActual;

        public List<Especialidad> especialidades;

        public AlumnoDesktop()
        {
            InitializeComponent();
        }

        public AlumnoDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
            AlumnoLogic alumnoLogic = new AlumnoLogic();
            if (this.Modo == ModoForm.Alta)
            {
                AlumnoLogic alumnoLogico = new AlumnoLogic();
                txtLegajo.Text = alumnoLogico.obtenerProximoLegajo().ToString();
            }

            this.loadEspecialidades();
        }

        public AlumnoDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            this.MapearDeDatos();
        }

        public override bool Validar()
        {


            if (txtApellido.Text == "" || txtNombre.Text == "" || dtpFechaNacimiento.Text == "" || cbPlan.SelectedItem == null)
            {
                Notificar("Atención", "Primero complete todos los datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtNombre.TextLength < 4)
            {
                Notificar("Atención", "El nombre debe contener al menos 4 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombre.Focus();
                return false;
            }
            //Falta validar

            return true;
        }

        public override void MapearDeDatos()
        {
            this.txtId.Text = this.AlumnoActual.Id.ToString();
            this.txtApellido.Text = this.AlumnoActual.Apellido;
            this.txtNombre.Text = this.AlumnoActual.Nombre;
            this.txtDireccion.Text = this.AlumnoActual.Direccion;
            this.txtEmail.Text = this.AlumnoActual.Email;
            this.txtTelefono.Text = this.AlumnoActual.Telefono;
            this.dtpFechaNacimiento.Value = this.AlumnoActual.FechaNacimiento;
            this.txtLegajo.Text = this.AlumnoActual.Legajo.ToString();

           
            
            //this.cbPlan.SelectedValue = this.AlumnoActual.IdPlan;

            switch (this.Modo)
            {
                case ModoForm.Baja:
                    this.txtNombre.Enabled = false;
                    this.txtApellido.Enabled = false;
                    this.txtEmail.Enabled = false;
                    this.txtDireccion.Enabled = false;
                    this.txtTelefono.Enabled = false;
                    this.dtpFechaNacimiento.Enabled = false;
                    this.cbPlan.Enabled = false;
                    this.cbEspecialidad.Enabled = false;
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.txtNombre.Enabled = false;
                    this.txtApellido.Enabled = false;
                    this.txtEmail.Enabled = false;
                    this.txtDireccion.Enabled = false;
                    this.txtTelefono.Enabled = false;
                    this.dtpFechaNacimiento.Enabled = false;
                    this.cbPlan.Enabled = false;
                    this.cbEspecialidad.Enabled = false;
                    this.btnAceptar.Text = "Aceptar";
                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
            }

        }

        public override void MapearADatos()
        {
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    Alumno a = new Alumno();
                    a.IdPlan = Int32.Parse(this.cbPlan.SelectedValue.ToString());
                    a.Nombre = this.txtNombre.Text;
                    a.Apellido = this.txtApellido.Text;
                    a.Email = this.txtEmail.Text;
                    a.Direccion = this.txtDireccion.Text;
                    a.Legajo = Int32.Parse(this.txtLegajo.Text);
                    a.Telefono = this.txtTelefono.Text;
                    a.FechaNacimiento = this.dtpFechaNacimiento.Value;
                    a.State = TiposDatos.States.New;
                    
                    this.AlumnoActual = a;
                    break;
                case ModoForm.Consulta:
                    this.AlumnoActual.State = TiposDatos.States.Unmodified;
                    break;
                case ModoForm.Modificacion:
                    this.AlumnoActual.Nombre = this.txtNombre.Text;
                    this.AlumnoActual.Apellido = this.txtApellido.Text;
                    this.AlumnoActual.Email = this.txtEmail.Text;
                    this.AlumnoActual.Direccion = this.txtDireccion.Text;
                    this.AlumnoActual.Legajo = Int32.Parse(this.txtLegajo.Text);
                    this.AlumnoActual.Telefono = this.txtTelefono.Text;
                    this.AlumnoActual.FechaNacimiento = this.dtpFechaNacimiento.Value;
                    if (this.cbPlan.SelectedValue != null)
                    {
                        this.AlumnoActual.IdPlan = Int32.Parse(this.cbPlan.SelectedValue.ToString());
                    }
                    this.AlumnoActual.State = TiposDatos.States.Modified;
                    break;
                case ModoForm.Baja:
                    this.AlumnoActual.State = TiposDatos.States.Deleted;
                    break;
                default:
                    this.AlumnoActual.State = TiposDatos.States.Unmodified;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            AlumnoLogic al = new AlumnoLogic();
            al.Save(AlumnoActual);

        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbTipoAlumno_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cbEspecialidad_SelectedValueChanged(object sender, EventArgs e)
        {
            this.cbPlan.ValueMember = "Id";
            this.cbPlan.DisplayMember = "Descripcion";
            if(this.cbEspecialidad.SelectedValue != null)
            {
                this.cbPlan.DataSource = new PlanLogic().GetByEspecialidad(Int32.Parse(this.cbEspecialidad.SelectedValue.ToString()));
                this.cbPlan.Visible = true;
                this.lblPlan.Visible = true;
            }
            
        }

        private void cbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void loadEspecialidades()
        {
            this.especialidades = new EspecialidadLogic().getAll();
            this.cbEspecialidad.ValueMember = "Id";
            this.cbEspecialidad.DisplayMember = "Descripcion";
            this.cbEspecialidad.DataSource = this.especialidades;
        }
    }
}
