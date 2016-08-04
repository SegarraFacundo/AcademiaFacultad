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
    public partial class Docentes : ApplicationForm
    {
        private Persona persona;
        public Docentes(Persona p)
        {
            InitializeComponent();
            persona = p;
        }


    }
}
