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
    public partial class Planes : Form
    {
        public Planes()
        {
            InitializeComponent();
            this.Listar();
        }
        public void Listar()
        {
            PlanLogic pl = new PlanLogic();
            this.dgvPlanes.DataSource = pl.GetAll();
        }
        private void Planes_Load(object sender, EventArgs e)
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

           PlanDesktop ud = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            ud.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Entidades.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).IdPlan;
            PlanDesktop ud = new PlanDesktop(ApplicationForm.ModoForm.Modificacion, ID);
            ud.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Entidades.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).IdPlan;
            PlanLogic pl = new PlanLogic();
            pl.Delete(ID);
            this.Listar();
        }

       
    }
}
