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
    public partial class EspecialidadDesktop : ApplicationForm
    {
        public Especialidad e;

        public EspecialidadDesktop()
        {
            InitializeComponent();
        }

        public EspecialidadDesktop (ModoForm modo) : this()
        {
            this.Modo = modo;
        }
        public EspecialidadDesktop (int id, ModoForm modo) : this(){
            this.Modo = modo;
            try
            {
                this.e = new EspecialidadLogic().GetOne(id);
                this.MapearDeDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void MapearDeDatos()
        {
            txtNombre.Text = this.e.Descripcion;
            txtId.Text = this.e.Id.ToString();

            switch (this.Modo)
            {
                case ModoForm.Baja:
                    this.txtNombre.Enabled = false;
                    this.txtId.Enabled = false;
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.txtNombre.Enabled = false;
                    this.txtId.Enabled = false;
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
                    Especialidad especialidadActual = new Especialidad();
                    especialidadActual.Descripcion = txtNombre.Text;
                    this.e = especialidadActual;
                    this.e.State = TiposDatos.States.New;

                    break;
                case ModoForm.Baja:
                    e.State = TiposDatos.States.Deleted;
                    break;
                case ModoForm.Modificacion:
                    e.Descripcion = txtNombre.Text;
                    this.e.State = TiposDatos.States.Modified;
                    break;
                default:
                    this.e.State = TiposDatos.States.Unmodified;
                    break;
            }

        }
        public override void GuardarCambios()
        {
            try
            {
                MapearADatos();
                EspecialidadLogic el = new EspecialidadLogic();
                el.Save(e);
                Notificar("Información", "Cambios realizados exitosamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar()) { GuardarCambios();}
            else { 
                Notificar("Atención!", "Debe completar los textos en blanco!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombre.Focus();
            }
        }

        public override bool Validar()
        {
            if (txtNombre.Text == ""){return false;}
            else { return true;  }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
