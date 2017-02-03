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
using Util;
namespace UI.Desktop
{
    public partial class DocentesDesktop : ApplicationForm
    {
        private DocenteLogic docenteLogic = new DocenteLogic();
        private Docente docente;
        private EspecialidadLogic especialidadLogic = new EspecialidadLogic();

        public DocentesDesktop()
        {
            InitializeComponent();
        }
        #region "Constructores"
        public DocentesDesktop(ModoForm modo)
            : this()
        {
            this.Modo = modo;

            if (this.Modo == ModoForm.Alta)
            {
                try
                {
                    txtLegajo.Text = docenteLogic.obtenerProximoLegajo().ToString();
                    
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

        }

        public DocentesDesktop(int ID, ModoForm modo)
            : this()
        {
            this.Modo = modo;
            try
            {
                this.docente = docenteLogic.GetOne(ID);
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

#region "Funciones"



        public override bool Validar()
        {


            if (txtApellido.Text == "" || txtNombre.Text == "" || dtpFechaNacimiento.Text == "")
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
            if (this.docente != null)
            {
                this.txtId.Text = this.docente.Id.ToString();
                this.txtApellido.Text = this.docente.Apellido;
                this.txtNombre.Text = this.docente.Nombre;
                this.txtDireccion.Text = this.docente.Direccion;
                this.txtEmail.Text = this.docente.Email;
                this.txtTelefono.Text = this.docente.Telefono;
                this.dtpFechaNacimiento.Value = this.docente.FechaNacimiento;
                this.txtLegajo.Text = this.docente.Legajo.ToString();     
                switch (this.Modo)
                {
                    case ModoForm.Baja:
                        this.txtNombre.Enabled = false;
                        this.txtApellido.Enabled = false;
                        this.txtEmail.Enabled = false;
                        this.txtDireccion.Enabled = false;
                        this.txtTelefono.Enabled = false;
                        this.dtpFechaNacimiento.Enabled = false;
                        this.btnAceptar.Text = "Eliminar";
                        break;
                    case ModoForm.Consulta:
                        this.txtNombre.Enabled = false;
                        this.txtApellido.Enabled = false;
                        this.txtEmail.Enabled = false;
                        this.txtDireccion.Enabled = false;
                        this.txtTelefono.Enabled = false;
                        this.dtpFechaNacimiento.Enabled = false;
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
                    Docente d = new Docente();                    
                    d.Nombre = this.txtNombre.Text;
                    d.Apellido = this.txtApellido.Text;
                    d.Email = this.txtEmail.Text;
                    d.Direccion = this.txtDireccion.Text;
                    d.Legajo = Int32.Parse(this.txtLegajo.Text);
                    d.Telefono = this.txtTelefono.Text;
                    d.FechaNacimiento = this.dtpFechaNacimiento.Value;
                    d.State = TiposDatos.States.New;

                    this.docente = d;
                    break;
                case ModoForm.Consulta:
                    this.docente.State = TiposDatos.States.Unmodified;
                    break;
                case ModoForm.Modificacion:
                    this.docente.Nombre = this.txtNombre.Text;
                    this.docente.Apellido = this.txtApellido.Text;
                    this.docente.Email = this.txtEmail.Text;
                    this.docente.Direccion = this.txtDireccion.Text;
                    this.docente.Legajo = Int32.Parse(this.txtLegajo.Text);
                    this.docente.Telefono = this.txtTelefono.Text;
                    this.docente.FechaNacimiento = this.dtpFechaNacimiento.Value;
                   
                    this.docente.State = TiposDatos.States.Modified;
                    break;
                case ModoForm.Baja:
                    this.docente.State = TiposDatos.States.Deleted;
                    break;
                default:
                    this.docente.State = TiposDatos.States.Unmodified;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            try
            {
                MapearADatos();
                docenteLogic.Save(docente);
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
#region "Metodos Controles"

#endregion

    }


}
