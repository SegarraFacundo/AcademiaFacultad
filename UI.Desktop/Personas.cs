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
    public partial class Personas : ApplicationForm
    {
        public Persona p;
        public Personas()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                this.Close();
            }
        }
        public override bool Validar()
        {
             if (txtApellido.Text == "" || txtFechaNacimiento.Text == "" || txtTelefono.Text == "" || txtEmail.Text == "" || txtNombre.Text == "" || txtDireccion.Text == "" ) 
            {
                Notificar("Atención", "Primero complete todos los datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }           
            //Falta validar mail            
            return true; 
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            PersonaLogic pl = new PersonaLogic();
            pl.Save(p);
        }
        public override void MapearADatos()
        {
            switch (this.Modo)
            {
                case ModoForm.Alta:                                       
                    p.Nombre = this.txtNombre.Text;
                    p.Apellido = this.txtApellido.Text;
                    p.Email = this.txtEmail.Text;
                    p.Telefono = this.txtTelefono.Text;
                    p.Direccion = this.txtDireccion.Text;
                    //p.FechaNacimiento = this.txtFechaNacimiento.Text;
                    this.p.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Consulta:
                    //this.UsuarioActual.State = BusinessEntity.States.Unmodified;
                    break;
                case ModoForm.Modificacion: p.Nombre = this.txtNombre.Text;
                    p.Apellido = this.txtApellido.Text;
                    p.Email = this.txtEmail.Text;
                    p.Telefono = this.txtTelefono.Text;
                    this.p.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Baja:
                    //this.UsuarioActual.State = BusinessEntity.States.Deleted;
                    break;
                default:
                    //this.UsuarioActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }
    }

}
