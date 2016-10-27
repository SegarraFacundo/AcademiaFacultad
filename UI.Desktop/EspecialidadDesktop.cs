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
using Util.CustomException;

namespace UI.Desktop
{
    public partial class EspecialidadDesktop : ApplicationForm
    {
        public Especialidad especialidad;

        private EspecialidadLogic especialidadLogic;

        public EspecialidadDesktop()
        {
            this.especialidadLogic = new EspecialidadLogic();
            InitializeComponent();
        }

        public EspecialidadDesktop (ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public EspecialidadDesktop (int id, ModoForm modo) : this(){
            this.Modo = modo;
            this.InitializeWithData(id);
        }

        public override void MapearDeDatos()
        {
            txtNombre.Text = this.especialidad.Descripcion;
            txtId.Text = this.especialidad.Id.ToString();

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
                    this.especialidad = new Especialidad();
                    this.especialidad.Descripcion = txtNombre.Text;
                    this.especialidad.State = TiposDatos.States.New;

                    break;
                case ModoForm.Baja:
                    this.especialidad.State = TiposDatos.States.Deleted;
                    break;
                case ModoForm.Modificacion:
                    this.especialidad.Descripcion = txtNombre.Text;
                    this.especialidad.State = TiposDatos.States.Modified;
                    break;
                default:
                    this.especialidad.State = TiposDatos.States.Unmodified;
                    break;
            }

        }

        public override void GuardarCambios()
        {
            try
            {
                MapearADatos();
                this.especialidadLogic.Save(this.especialidad);
                Notificar("Información", "Cambios realizados exitosamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
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

        private void InitializeWithData(int idEspecialidad)
        {
            try
            {
                this.especialidad = this.especialidadLogic.GetOne(idEspecialidad);
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
