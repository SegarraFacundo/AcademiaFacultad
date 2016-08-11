﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class LogIn : ApplicationForm
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
          
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioLogic UserLogic = new UsuarioLogic();
            Usuario currentUser = UserLogic.LogIn(txtUser.Text, txtPass.Text);
            if (currentUser == null)
                Notificar("Error", "Error de incio de seción, credenciales incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            {
                PersonaLogic personaLogic = new PersonaLogic();
                Persona p = personaLogic.GetOne(currentUser.IdPersona);
                switch (p.TipoPersona) { 
                    case Persona.TiposPersona.Docente:
                        MenuDocentes docente = new MenuDocentes(p);
                        docente.ShowDialog();
                        break;
                    case Persona.TiposPersona.Alumno:
                        MenuAlumnos alumno = new MenuAlumnos(p);
                        alumno.ShowDialog();
                        break;
                }
            }
        }

    }
}