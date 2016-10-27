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

namespace UI.Desktop
{
    public partial class Usuarios : ApplicationForm
    {
        private UsuarioLogic usuarioLogic;
        public Usuarios()
        {
            this.usuarioLogic = new UsuarioLogic();
            InitializeComponent();
        }


        public void Listar()
        {
            this.dgvUsuarios.AutoGenerateColumns = false;

            try
            {
                this.dgvUsuarios.DataSource = this.usuarioLogic.GetAll();
            }
            catch (NotFoundException ex)
            {
                Notificar("Atención!", ex.Message , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (CustomException ex)
            {
                Notificar("Atención!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                Notificar("Atención!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuarioDesktop ud = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            ud.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (base.ValidarDGV(dgvUsuarios))
            {
                try
                {
                    int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).Id;
                    UsuarioDesktop ud = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                    ud.ShowDialog();
                }
                catch (NotFoundException ex)
                {
                    Notificar("Atención!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (CustomException ex)
                {
                    Notificar("Atención!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    Notificar("Atención!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (base.ValidarDGV(dgvUsuarios))
            {
                try
                {
                    int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).Id;
                    UsuarioDesktop ud = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Baja);
                    ud.ShowDialog();
                }
                    catch (NotFoundException ex)
                {
                    Notificar("Atención!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (CustomException ex)
                {
                    Notificar("Atención!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    Notificar("Atención!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
