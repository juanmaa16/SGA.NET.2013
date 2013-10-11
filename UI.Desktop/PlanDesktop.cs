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
    public partial class PlanDesktop : ApplicationForm
    {
        private ModoForm _modo;

        public ModoForm Modo
        {
            get { return _modo; }
            set { _modo = value; }
        }

        public PlanDesktop()
        {
            InitializeComponent();
        }

        public PlanDesktop(ModoForm modo):this()
        {
            Modo = modo;
            btnAceptar.Text = "Guardar";
        }

        public PlanDesktop(ModoForm modo,int ID): this()
        {
            _modo=modo;
            PlanLogic pl = new PlanLogic();
            PlanActual = pl.GetOne(ID);
            this.MapearDeDatos();
            switch(_modo)
            {case ModoForm.Modificacion:
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

        private void PlanDesktop_Load(object sender, EventArgs e)
        {

        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            PlanLogic pl = new PlanLogic();
            pl.Save(PlanActual);
        }

        public override void MapearDeDatos()
        {
            this.txtIDPlan.Text = this.PlanActual.IdPlan.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion;
            this.txtIDEspecialidad.Text = this.PlanActual.IdEspecialidad.ToString();
        }

        public override void MapearADatos()
        {
            if (_modo == ModoForm.Alta)
            {
                PlanActual = new Plan();
            }

            PlanActual.IdEspecialidad = Convert.ToInt32(txtIDEspecialidad.Text.Trim());
            PlanActual.Descripcion = txtDescripcion.Text.Trim();

            switch (_modo)
            {
                case ModoForm.Modificacion:
                    PlanActual.State = Plan.States.Modified;
                    break;
                case ModoForm.Baja:
                    PlanActual.State = Plan.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    PlanActual.State = Plan.States.Unmodified;
                    break;
                case ModoForm.Alta:
                    PlanActual.State = Plan.States.New;
                    break;
            }
        }

        public override bool Validar()
        {
            String mensaje = "";
            bool dev=true;
            /*if (!Utilidades.validaApellido(txtApellido.Text.Trim()))
            {
                mensaje += "- El apellido no puede estar en blanco \n";
            }

            if (!Utilidades.validaNombre(txtNombre.Text.Trim()))
            {
                mensaje += "- El nombre no puede estar en blanco \n";
            }
            if (!Utilidades.validaClavesIguales(txtClave.Text.Trim(), txtConfirmarClave.Text.Trim()))
            {
                mensaje += "- Las claves deben coincidir \n";
            }
            if (!Utilidades.validaNombre(txtUsuario.Text.Trim()))
            {
                mensaje += "- El nombre de usuario no puede estar en blanco \n";
            }
            if (!Utilidades.validaClave(txtClave.Text.Trim()))
            {
                mensaje += "- La contraseña no puede estar en blanco";
            }
            if (!Utilidades.validaClaveCaracteres(txtClave.Text.Trim()))
            {
                mensaje += "- La contraseña debe tener mas de 8 caracteres\n";
            }
            if (!Utilidades.validarEmail(txtEmail.Text.Trim()))
            {
                mensaje += "- Ingrese un email valido\n";
            }

            if (mensaje == "")
            {
                dev = true;
                //llamar a notificar para decir que esta todo bien
            }
            else
            {
                dev = false;
                //llamar a notificar para decir que esta todo mal
                MessageBox.Show(mensaje);
            }
             * */
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

        public Entidades.Plan PlanActual
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

        private void tlPlanDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
