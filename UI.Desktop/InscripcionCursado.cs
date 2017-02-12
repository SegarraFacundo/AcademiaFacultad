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
using Util;
namespace UI.Desktop
{
    public partial class InscripcionCursado : ApplicationForm
    {
        private CursoLogic cursoLogic = new CursoLogic();
        private AlumnoInscriptoLogic inscripcionLogic = new AlumnoInscriptoLogic();
        private Usuario currentUser;
        public InscripcionCursado(Usuario u)
        {
            InitializeComponent();
            currentUser = u;
            this.Listar();
        }

#region "Metodos"

        private void Listar()
        {
            this.dgvCursos.AutoGenerateColumns = false;
            try
            {
                this.dgvCursos.DataSource = cursoLogic.GetAll();
            }
            catch (NotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CustomException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

#endregion

        private void btnInscribir_Click(object sender, EventArgs e)
        {
            if (ValidarDGV(dgvCursos))
            {
                AlumnoLogic alumnoLogic = new AlumnoLogic();
                Alumno currentAlumno = alumnoLogic.GetOne(currentUser.IdPersona);
                if (currentAlumno != null)
                {
                    //ahora que capturamos el alumno nos pasamos de capa para validar la inscripcion y hacerla 
                    CursoLogic cursoLogic = new CursoLogic();
                    int ID = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).Id;
                    Curso currentCurso = cursoLogic.GetOne(ID);
                    string rta = inscripcionLogic.ValidarInscripcion(currentAlumno, currentCurso);
                    if (rta == "")
                    {
                        AlumnoInscripto currentInscripcion = new AlumnoInscripto();
                        currentInscripcion.IdAlumno = currentAlumno.Id;
                        currentInscripcion.IdCurso = currentCurso.Id;
                        currentInscripcion.State = TiposDatos.States.New;
                        currentInscripcion.Condicion = "inscripto";
                        inscripcionLogic.Save(currentInscripcion);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo inscribir al cursado por la siguiente razón:" + System.Environment.NewLine + rta, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
