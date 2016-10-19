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
using System.IFormatProvider;
namespace UI.Desktop
{
    public partial class PersonasDesktop : ApplicationForm
    {
        public Persona p;
        PersonaLogic pl;
        public PersonasDesktop()
        {
            InitializeComponent();
        }

        Plan Plan = new Plan();

        public PersonasDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
            pl = new PersonaLogic();
            txtLegajo.Text = pl.obtenerProximoLegajo().ToString();
        }
        private bool Validar()
        {

            if (txtNombre.Text == "" || txtApellido.Text == "" || txtFechaNacimiento.Text == "" )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void GuardarCambios()
        {
            MapearADatos();
            pl = new PersonaLogic();
            pl.Save(p);
            Notificar("Información", "Cambios realizados exitosamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (Validar()) { GuardarCambios(); }
            else
            {
                Notificar("Atención!", "Debe completar los textos en blanco!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public override void MapearADatos()
        {
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    Persona personaActual = new Persona();
                    personaActual.Nombre   = txtNombre.Text;
                    personaActual.Apellido = txtApellido.Text;
                    personaActual.Direccion = txtDirección.Text;
                    personaActual.Telefono = txtTelefono.Text;
                    personaActual.Email = txtEmail.Text;
                    personaActual.Legajo = Int32.Parse(txtLegajo.Text);

                    this.p = personaActual;
                    this.p.State = BusinessEntity.States.New;

                    break;
                case ModoForm.Baja:
                    p.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Modificacion:
                    p.Nombre   = txtNombre.Text;
                    p.Apellido = txtApellido.Text;
                    p.Direccion = txtDirección.Text;
                    p.Telefono = txtTelefono.Text;
                    p.Email = txtEmail.Text; 
                    this.p.State = BusinessEntity.States.Modified;
                    break;
                default:
                    this.p.State = BusinessEntity.States.Unmodified;
                    break;
                 }
            }

        public override void MapearDeDatos()
        {
            txtNombre.Text = p.Nombre;
            txtApellido.Text = p.Apellido;
            txtDirección.Text = p.Direccion;
            txtFechaNacimiento.Text = p.FechaNacimiento.ToString();
            txtTelefono.Text = p.Telefono;
            txtEmail.Text = p.Email;
                   
        }

        }

    }

