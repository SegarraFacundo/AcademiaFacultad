using System;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;
using Util;
using Util.CustomException;

namespace UI.Desktop
{
    public partial class AlumnoDesktop : ApplicationForm
    {
        private Alumno alumno;
        private AlumnoLogic alumnoLogic = new AlumnoLogic();
        private PlanLogic planLogic = new PlanLogic();
        private EspecialidadLogic especialidadLogic = new EspecialidadLogic();

        public AlumnoDesktop()
        {
            InitializeComponent();
        }
        #region "Constructores"
        public AlumnoDesktop(ModoForm modo)
            : this()
        {
            this.Modo = modo;

            if (this.Modo == ModoForm.Alta)
            {
                try
                {
                    txtLegajo.Text = alumnoLogic.obtenerProximoLegajo().ToString();
                    this.loadEspecialidades();
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

        }

        public AlumnoDesktop(int ID, ModoForm modo)
            : this()
        {
            this.Modo = modo;
            try
            {
                this.alumno = alumnoLogic.GetOne(ID);
                this.loadEspecialidades();
                this.MapearDeDatos();
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

        #endregion
        #region "Metodos Controles"
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
        private void cbEspecialidad_SelectedValueChanged(object sender, EventArgs e)
        {
            this.cbPlan.ValueMember = "Id";
            this.cbPlan.DisplayMember = "Descripcion";
            if (this.cbEspecialidad.SelectedValue != null)
            {
                int idEspecialidad = Int32.Parse(this.cbEspecialidad.SelectedValue.ToString());

                try
                {
                    this.cbPlan.DataSource = new PlanLogic().GetByEspecialidad(idEspecialidad);
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

                this.cbPlan.Visible = true;
                this.lblPlan.Visible = true;
            }
        }
        #endregion     
        #region "Metodos"
        private void loadEspecialidades()
        {
            this.cbEspecialidad.ValueMember = "Id";
            this.cbEspecialidad.DisplayMember = "Descripcion";

            try
            {
                this.cbEspecialidad.DataSource = this.especialidadLogic.GetAll();
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

        public override void GuardarCambios()
        {
            try
            {
                MapearADatos();
                alumnoLogic.Save(alumno);
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
            if (this.alumno != null)
            {
                this.txtId.Text = this.alumno.Id.ToString();
                this.txtApellido.Text = this.alumno.Apellido;
                this.txtNombre.Text = this.alumno.Nombre;
                this.txtDireccion.Text = this.alumno.Direccion;
                this.txtEmail.Text = this.alumno.Email;
                this.txtTelefono.Text = this.alumno.Telefono;
                this.dtpFechaNacimiento.Value = this.alumno.FechaNacimiento;
                this.txtLegajo.Text = this.alumno.Legajo.ToString();

                Plan p = this.planLogic.GetOne(this.alumno.IdPlan);
                this.cbPlan.SelectedValue = p.Id;
                this.cbEspecialidad.SelectedValue = p.IdEspecialidad;

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
            else
            {
                Notificar("No se pudo encontrar el alumno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    this.alumno = a;
                    break;
                case ModoForm.Consulta:
                    this.alumno.State = TiposDatos.States.Unmodified;
                    break;
                case ModoForm.Modificacion:
                    this.alumno.Nombre = this.txtNombre.Text;
                    this.alumno.Apellido = this.txtApellido.Text;
                    this.alumno.Email = this.txtEmail.Text;
                    this.alumno.Direccion = this.txtDireccion.Text;
                    this.alumno.Legajo = Int32.Parse(this.txtLegajo.Text);
                    this.alumno.Telefono = this.txtTelefono.Text;
                    this.alumno.FechaNacimiento = this.dtpFechaNacimiento.Value;
                    if (this.cbPlan.SelectedValue != null)
                    {
                        this.alumno.IdPlan = Int32.Parse(this.cbPlan.SelectedValue.ToString());
                    }
                    this.alumno.State = TiposDatos.States.Modified;
                    break;
                case ModoForm.Baja:
                    this.alumno.State = TiposDatos.States.Deleted;
                    break;
                default:
                    this.alumno.State = TiposDatos.States.Unmodified;
                    break;
            }
        }

        #endregion



    }
}
