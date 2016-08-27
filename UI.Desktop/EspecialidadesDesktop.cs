﻿using System;
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
    public partial class EspecialidadesDesktop : ApplicationForm
    {
        public Especialidad e;
        public EspecialidadesDesktop()
        {
            InitializeComponent();
        }

        public EspecialidadesDesktop (ModoForm modo) : this()
        {
            this.Modo = modo;
        }
        public EspecialidadesDesktop (int id, ModoForm modo) : this(){
            this.Modo = modo;
            this.e = new EspecialidadLogic().GetOne(id);
            this.MapearDeDatos();

        }

        public override void MapearDeDatos()
        {
            txtNombre.Text = this.e.Descripcion;
            txtId.Text = this.e.Id.ToString();
        }

        public override void MapearADatos()
        {
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    Especialidad especialidadActual = new Especialidad();
                    especialidadActual.Descripcion = txtNombre.Text;
                    this.e = especialidadActual;
                    this.e.State = BusinessEntity.States.New;

                    break;
                case ModoForm.Baja:
                    e.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Modificacion:
                    e.Descripcion = txtNombre.Text;
                    this.e.State = BusinessEntity.States.Modified;
                    break;
                default:
                    this.e.State = BusinessEntity.States.Unmodified;
                    break;
            }

        }
        public override void GuardarCambios()
        {
            MapearADatos();
            EspecialidadLogic el = new EspecialidadLogic();
            el.Save(e);
            Notificar("Información", "Cambios realizados exitosamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
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
