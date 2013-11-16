using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Entidades;
using Util;

namespace UI.Desktop
{
    public partial class CursoDesktop : ApplicationForm
    {

        private ModoForm _modo;

        public ModoForm Modo
        {
            get { return _modo; }
            set { _modo = value; }
        }
        public CursoDesktop()
        {
            InitializeComponent();
        }
        public CursoDesktop(ModoForm modo)
            : this()
        {
            Modo = modo;
            btnAceptar.Text = "Guardar";
        }

        public CursoDesktop(ModoForm modo, int ID)
            : this()
        {
            _modo = modo;
            CursoLogic cl = new CursoLogic();
            CursoActual = cl.GetOne(ID);
            this.MapearDeDatos();
            switch (_modo)
            {
                case ModoForm.Modificacion:
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    break;
            }
        }
        private void CursoDesktop_Load(object sender, EventArgs e)
        {

        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            CursoLogic cl = new CursoLogic();
            cl.Save(CursoActual);
        }

        public override void MapearDeDatos()
        {
            this.txtIDCurso.Text = this.CursoActual.IdCurso.ToString();
            this.txtIDMateria.Text = this.CursoActual.IdMateria.ToString();
            this.txtIDComision.Text = this.CursoActual.IdComision.ToString();
            this.txtAnioCalendario.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
        }

        public override void MapearADatos()
        {
            if (_modo == ModoForm.Alta)
            {
                CursoActual = new Curso();
            }

            CursoActual.IdMateria = Convert.ToInt32(txtIDMateria.Text.Trim());
            CursoActual.IdComision = Convert.ToInt32(txtIDComision.Text.Trim());
            CursoActual.AnioCalendario = Convert.ToInt32(txtAnioCalendario.Text.Trim());
            CursoActual.Cupo = Convert.ToInt32(txtCupo.Text.Trim());
            switch (_modo)
            {
                case ModoForm.Modificacion:
                    CursoActual.State = Plan.States.Modified;
                    break;
                case ModoForm.Baja:
                    CursoActual.State = Plan.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    CursoActual.State = Plan.States.Unmodified;
                    break;
                case ModoForm.Alta:
                    CursoActual.State = Plan.States.New;
                    break;
            }
        }

        public override bool Validar()
        {
            String mensaje = "";
            bool dev = true;
            /* if (!Utilidades.validaAnioCalendario(txtAnioCalendario))
             {
                 mensaje += "- El anio no puede estar en blanco \n";
             }*/
            return dev;
        }

        public void Notificar(string titulo, string mensaje, MessageBoxButtons
        botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }

        public void Notificar(string mensaje, MessageBoxButtons botones,
        MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        public Entidades.Curso CursoActual
        {
            get;
            set;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}