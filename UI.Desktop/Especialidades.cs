using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace UI.Desktop
{
    public partial class Especialidades : Form
    {
        public Especialidades()
        {
            InitializeComponent();
            this.Listar();
        }
        public void Listar()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.dgvEspecialidades.DataSource = el.GetAll();
        }
        private void Especialidades_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {

            EspecialidadDesktop ed = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            ed.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Entidades.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).IdEspecialidad;
            EspecialidadDesktop ed = new EspecialidadDesktop(ApplicationForm.ModoForm.Modificacion, ID);
            ed.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Entidades.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).IdEspecialidad;
            EspecialidadLogic el = new EspecialidadLogic();
            el.Delete(ID);
            this.Listar();
        }

    }
}
