using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Util;

namespace UI.Desktop
{
    public partial class frmUsuario : Form
    {
        #region Constructor

        public frmUsuario()
        {
            InitializeComponent();
        }

        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }
        #region Eventos

        private void frmUsuario_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Metodos

        private void Guardar()
        {
            // Genero una nueva instancia de la entidad
            Entidades.Usuario oUsuario = new Entidades.Usuario();
            
            try
            {
                // Completo la entidad con informacion del formulario.
                oUsuario.Id = Convert.ToInt32(txtId.Text.Trim());
                oUsuario.Apellido = txtApellido.Text.Trim();
                oUsuario.Nombre = txtNombre.Text.Trim();
                oUsuario.TipoDocumento = Convert.ToString(cbxTipoDocumento.SelectedValue);
                oUsuario.NroDocumento = Convert.ToInt32(txtNroDocumento.Text.Trim());
                oUsuario.FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text.Trim());
                oUsuario.Direccion = txtDireccion.Text.Trim();
                oUsuario.Telefono = txtTelefono.Text.Trim();
                oUsuario.Celular = txtCelular.Text.Trim();
                oUsuario.Email = txtEmail.Text.Trim();
            }
            catch (Exception ex)
            {
                // Muestro cualquier error de la aplicacion
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                // Libero objetos
                oUsuario = null;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.Guardar();
        }

        /*private bool Validar()
        {
            String mensaje = "";
            if (!Utilidades.validaApellido(txtApellido.Text.Trim()))
            {
                mensaje += "- El apellido no puede estar en blanco \n";
            }

            if (!Utilidades.validaNombre(txtNombre.Text.Trim()))
            {
                mensaje += "- El nombre no puede estar en blanco \n";
            }

            if (cbxTipoDocumento.SelectedValue == null)
            {
                mensaje += "- Debe seleccionar un tipo de documento \n";
            }
        }*/



        #endregion



    }
}
