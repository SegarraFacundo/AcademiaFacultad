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
    public partial class Usuarios : ApplicationForm
    {
        public Usuarios()
        {
            InitializeComponent();
        }


        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.dgvUsuarios.DataSource = ul.GetAll();
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
                int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).Id;
                UsuarioDesktop ud = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                ud.MapearDeDatos();
                ud.ShowDialog();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (base.ValidarDGV(dgvUsuarios))
            {
                int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).Id;
                UsuarioDesktop ud = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Baja);
                ud.MapearDeDatos();
                ud.ShowDialog();
            }
        }
    }
}
