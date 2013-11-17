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
    public partial class Modulos : Form
    {
        public Modulos()
        {
            InitializeComponent();
            this.Listar();
        }
        public void Listar()
        {
            ModuloLogic ml = new ModuloLogic();
            this.dgvModulos.DataSource = ml.GetAll();
        }
        private void Modulos_Load(object sender, EventArgs e)
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

            ModuloDesktop md = new ModuloDesktop(ApplicationForm.ModoForm.Alta);
            md.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Entidades.Modulo)this.dgvModulos.SelectedRows[0].DataBoundItem).IDModulo;
            ModuloDesktop ud = new ModuloDesktop(ApplicationForm.ModoForm.Modificacion, ID);
            ud.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Entidades.Modulo)this.dgvModulos.SelectedRows[0].DataBoundItem).IDModulo;
            ModuloLogic ml = new ModuloLogic();
            ml.Delete(ID);
            this.Listar();
        }


    }
}

