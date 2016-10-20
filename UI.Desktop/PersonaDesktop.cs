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

namespace UI.Desktop
{
    public partial class PersonaDesktop : ApplicationForm
    {
        public Persona PersonaActual;

        public PersonaDesktop()
        {
            this.CompleteComboBox();
            InitializeComponent();
        }

        public PersonaDesktop(ModoForm modo) : this()
        {
            this.CompleteComboBox();
            this.Modo = modo;
        }

        public PersonaDesktop(int ID, ModoForm modo) : this()
        {
            this.CompleteComboBox();
            this.Modo = modo;
            this.PersonaActual = new PersonaLogic().GetOne(ID);
            this.MapearDeDatos();
        }

        public override bool Validar()
        {


            if (txtApellido.Text == "" || txtNombre.Text == "" || dtpFechaNacimiento.Text == "" || cbTipoPersona.Text == "")
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

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        public void CompleteComboBox()
        {
            List<Plan> Planes = new PlanLogic().GetAll();

            foreach (Plan plan in Planes)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = plan.Descripcion;
                item.Value = plan.Id;
                cbIdPlan.Items.Add(item);
            }

            foreach (string tp in Enum.GetNames(typeof(Persona.TiposPersona)))
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = tp;
                cbTipoPersona.Items.Add(item);
            }

        }


        public override void MapearDeDatos()
        {
            this.txtId.Text = this.PersonaActual.Id.ToString();
            this.txtApellido.Text = this.PersonaActual.Apellido;
            this.txtNombre.Text = this.PersonaActual.Nombre;
            this.txtDireccion.Text = this.PersonaActual.Direccion;
            this.txtEmail.Text = this.PersonaActual.Email;
            this.txtTelefono.Text = this.PersonaActual.Telefono;
            this.dtpFechaNacimiento.Value = this.PersonaActual.FechaNacimiento;
            this.cbIdPlan.SelectedIndex = PersonaActual.IdPlan;
            this.cbTipoPersona.SelectedIndex = (int)PersonaActual.TipoPersona;

            switch (this.Modo)
            {
                case ModoForm.Baja:
                    this.txtNombre.Enabled = false;
                    this.txtApellido.Enabled = false;
                    this.txtEmail.Enabled = false;
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.txtNombre.Enabled = false;
                    this.txtApellido.Enabled = false;
                    this.txtEmail.Enabled = false;
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
                    Persona persona = new Persona();
                    persona.Nombre = this.txtNombre.Text;
                    persona.Apellido = this.txtApellido.Text;
                    persona.Email = this.txtEmail.Text;
                    this.PersonaActual = persona;
                    this.PersonaActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Consulta:
                    this.PersonaActual.State = BusinessEntity.States.Unmodified;
                    break;
                case ModoForm.Modificacion:
                    this.PersonaActual.Nombre = this.txtNombre.Text;
                    this.PersonaActual.Apellido = this.txtApellido.Text;
                    this.PersonaActual.Email = this.txtEmail.Text;
                    this.PersonaActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    this.PersonaActual.State = BusinessEntity.States.Deleted;
                    break;
                default:
                    this.PersonaActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            PersonaLogic pl = new PersonaLogic();
            pl.Save(PersonaActual);

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
    }
}
