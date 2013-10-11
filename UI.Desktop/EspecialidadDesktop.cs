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
    public partial class EspecialidadDesktop : ApplicationForm
    {
        private ModoForm _modo;

        public ModoForm Modo
        {
            get { return _modo; }
            set { _modo = value; }
        }

        public EspecialidadDesktop()
        {
            InitializeComponent();
        }

        public EspecialidadDesktop(ModoForm modo):this()
        {
            Modo = modo;
            btnAceptar.Text = "Guardar";
        }

        public EspecialidadDesktop(ModoForm modo, int ID) : this()
        {
            _modo=modo;
            EspecialidadLogic el = new EspecialidadLogic();
            EspecialidadActual = el.GetOne(ID);
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
        
        public override void GuardarCambios()
        {
            this.MapearADatos();
            EspecialidadLogic el = new EspecialidadLogic();
            el.Save(EspecialidadActual);
        }

        public override void MapearDeDatos()
        {
            this.txtIDEspecialidad.Text = this.EspecialidadActual.IdEspecialidad.ToString();
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion;
        }

        public override void MapearADatos()
        {
            if (_modo == ModoForm.Alta)
            {
                EspecialidadActual = new Especialidad();
            }

            EspecialidadActual.Descripcion = txtDescripcion.Text.Trim();

            switch (_modo)
            {
                case ModoForm.Modificacion:
                    EspecialidadActual.State = Especialidad.States.Modified;
                    break;
                case ModoForm.Baja:
                    EspecialidadActual.State = Especialidad.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    EspecialidadActual.State = Especialidad.States.Unmodified;
                    break;
                case ModoForm.Alta:
                    EspecialidadActual.State = Especialidad.States.New;
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

        public Entidades.Especialidad EspecialidadActual
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
