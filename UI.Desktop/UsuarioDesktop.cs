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
    public partial class UsuarioDesktop : ApplicationForm
    {
        private Usuario usuario;

        private UsuarioLogic usuarioLogic;
        
        public UsuarioDesktop()
        {
            this.usuarioLogic = new UsuarioLogic();
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            this.InitializeWithData(ID);
        }

        public override void MapearDeDatos()
        {
            if (this.usuario != null)
            {
                this.txtId.Text = this.usuario.Id.ToString();
                this.chkHabilitado.Checked = this.usuario.Habilitado;
                this.txtNombre.Text = this.usuario.Nombre;
                this.txtApellido.Text = this.usuario.Apellido;
                this.txtEmail.Text = this.usuario.Email;
                this.txtUsuario.Text = this.usuario.NombreUsuario;
                this.txtClave.Text = this.usuario.Clave;
                this.txtConfirmarClave.Text = this.usuario.Clave;
                switch (this.Modo)
                {
                    case ModoForm.Baja:
                        this.chkHabilitado.Enabled = false;
                        this.txtClave.Enabled = false;
                        this.txtConfirmarClave.Enabled = false;
                        this.txtNombre.Enabled = false;
                        this.txtApellido.Enabled = false;
                        this.txtEmail.Enabled = false;
                        this.txtUsuario.Enabled = false;
                        this.btnAceptar.Text = "Eliminar";
                        break;
                    case ModoForm.Consulta:
                        this.chkHabilitado.Enabled = false;
                        this.txtClave.Enabled = false;
                        this.txtConfirmarClave.Enabled = false;
                        this.txtNombre.Enabled = false;
                        this.txtApellido.Enabled = false;
                        this.txtEmail.Enabled = false;
                        this.txtUsuario.Enabled = false;
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
                Notificar("No se pudo encontrar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public override void MapearADatos()
        {
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    Usuario usuario = new Usuario();
                    usuario.Habilitado = this.chkHabilitado.Checked;
                    usuario.Nombre = this.txtNombre.Text;
                    usuario.Apellido = this.txtApellido.Text;
                    usuario.Email = this.txtEmail.Text;
                    usuario.NombreUsuario = this.txtUsuario.Text;
                    usuario.Clave = this.txtClave.Text;
                    this.usuario = usuario;
                    this.usuario.State = TiposDatos.States.New;
                    break;
                case ModoForm.Consulta:
                    this.usuario.State = TiposDatos.States.Unmodified;
                    break;
                case ModoForm.Modificacion:                    
                    this.usuario.Habilitado = this.chkHabilitado.Checked;
                    this.usuario.Nombre = this.txtNombre.Text;
                    this.usuario.Apellido = this.txtApellido.Text;
                    this.usuario.Email = this.txtEmail.Text;
                    this.usuario.NombreUsuario = this.txtUsuario.Text;
                    this.usuario.Clave = this.txtClave.Text;
                    this.usuario.State = TiposDatos.States.Modified;
                    break;
                case ModoForm.Baja:
                    this.usuario.State = TiposDatos.States.Deleted;
                    break;
                default:
                    this.usuario.State = TiposDatos.States.Unmodified;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            try
            {
                MapearADatos();
                this.usuarioLogic.Save(usuario);
            }
            catch (NotFoundException ex)
            {
                Notificar(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InsertException ex)
            {
                Notificar(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DeleteException ex)
            {
                Notificar(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UpdateException ex)
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

            if (txtApellido.Text == "" || txtClave.Text == "" || txtConfirmarClave.Text == "" || txtEmail.Text == "" || txtNombre.Text == "" || txtUsuario.Text == "" ) 
            {
                Notificar("Atención", "Primero complete todos los datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtClave.TextLength < 8)
            {
                Notificar("Atención", "La clave debe contener al menos 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtClave.Focus();
                return false;
            }
            else if(txtClave.Text != txtConfirmarClave.Text){
                Notificar("Atención!", "No coinciden las claves", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                txtClave.Focus();
                return false;
            }
            //Falta validar mail
            
            return true; 
        }

        private void InitializeWithData(int ID)
        {
            try
            {
                this.usuario = this.usuarioLogic.GetOne(ID);
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
        
        #region "Bbsura de los controles"
        #endregion

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
           if  (this.Validar()) {
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
