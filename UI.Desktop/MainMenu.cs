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

namespace UI.Desktop
{
    public partial class MainMenu : ApplicationForm
    {
        private Persona persona;
        public MainMenu(Persona p)
        {
            InitializeComponent();
            persona = p;
            label1.Text = p.Apellido + ", " + p.Nombre + ". Legajo: " + p.Legajo;
        }
    }
}
