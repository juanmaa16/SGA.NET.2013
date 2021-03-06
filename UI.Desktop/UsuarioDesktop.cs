﻿using System;
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
    public partial class UsuarioDesktop : ApplicationForm
    {
        private ModoForm _modo;

        public ModoForm Modo
        {
            get { return _modo; }
            set { _modo = value; }
        }

        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo)
            : this()
        {
            Modo = modo;
            btnAceptar.Text = "Guardar";
        }

        public UsuarioDesktop(ModoForm modo, int ID)
            : this()
        {
            _modo = modo;
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual = ul.GetOne(ID);
            PersonaLogic pl = new PersonaLogic();
            PersonaActual = pl.GetOne(ID);
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

        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {

        }

        public override void MapearDeDatos()
        {
            this.txtId.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Password;
            this.txtConfirmarClave.Text = this.UsuarioActual.Password;
            this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();
            this.txtTipoPersona.Text = this.PersonaActual.TipoPersona.ToString();
            this.txtIDPlan.Text = this.PersonaActual.IdPlan.ToString();
            this.dtpFechaNacimiento.Text = this.PersonaActual.FechaNacimiento.ToShortDateString();
            this.txtDireccion.Text = this.PersonaActual.Direccion;
            this.txtTelefono.Text = this.PersonaActual.Telefono;
        }

        public override void MapearADatos()
        {
            if (_modo == ModoForm.Alta)
            {
                UsuarioActual = new Usuario();
                PersonaActual = new Persona();
            }

            //UsuarioActual.Id = Convert.ToInt32(txtId.Text.Trim());
            UsuarioActual.NombreUsuario = txtUsuario.Text.Trim();
            UsuarioActual.Apellido = txtApellido.Text.Trim();
            UsuarioActual.Nombre = txtNombre.Text.Trim();
            UsuarioActual.Email = txtEmail.Text.Trim();
            UsuarioActual.Password = txtClave.Text.Trim();
            UsuarioActual.Habilitado = chkHabilitado.Checked;
            PersonaActual.Legajo = Convert.ToInt32(txtLegajo.Text.Trim());
            PersonaActual.TipoPersona = Persona.TiposPersona.Alumno; //CAMBIAR!!!
            PersonaActual.IdPlan = Convert.ToInt32(txtIDPlan.Text.Trim());
            PersonaActual.FechaNacimiento = dtpFechaNacimiento.Value;
            PersonaActual.Direccion = txtDireccion.Text.Trim();
            PersonaActual.Telefono = txtTelefono.Text.Trim();
            PersonaActual.Nombre = txtNombre.Text.Trim();
            PersonaActual.Apellido = txtApellido.Text.Trim();
            PersonaActual.Email = txtEmail.Text.Trim();

            switch (_modo)
            {
                case ModoForm.Modificacion:
                    UsuarioActual.State = Usuario.States.Modified;
                    PersonaActual.State = Persona.States.Modified;
                    break;
                case ModoForm.Baja:
                    UsuarioActual.State = Usuario.States.Deleted;
                    PersonaActual.State = Persona.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    UsuarioActual.State = Usuario.States.Unmodified;
                    PersonaActual.State = Persona.States.Unmodified;
                    break;
                case ModoForm.Alta:
                    UsuarioActual.State = Usuario.States.New;
                    PersonaActual.State = Usuario.States.New;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            PersonaLogic pl = new PersonaLogic();
            pl.Save(PersonaActual);
            UsuarioLogic ul = new UsuarioLogic();
            ul.Save(UsuarioActual);

        }

        public override bool Validar()
        {
            String mensaje = "";
            bool dev;
            if (!Utilidades.validaApellido(txtApellido.Text.Trim()))
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

        public Usuario UsuarioActual
        {
            get;
            set;
        }

        public Persona PersonaActual
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
