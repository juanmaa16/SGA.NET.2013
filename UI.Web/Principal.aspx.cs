using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace UI.Web
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Logueado())
            {
                Page.Response.Write("No estas registrado");
                this.PanelPrincipal.Visible = false;
            }
            else
            {
                this.cargaModulos();
                lblUsuario.Text = Session["NombreUsuario"].ToString();
            }

        }

        private bool Logueado()
        {
            if (Session["IdUsuario"] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void cargaModulos()
        {
            Usuario.TiposPersona tipoPersona = (Usuario.TiposPersona)Session["TipoPersona"];
            switch (tipoPersona)
            {
                case Usuario.TiposPersona.Alumno:
                    hlUsuarios.Visible = false;
                    hlEspecialidades.Visible = false;
                    hlPlanes.Visible = false;
                    break;
                case Usuario.TiposPersona.Docente:
                    hlUsuarios.Visible = false;
                    hlPlanes.Visible = false;
                    break;
            }
        }
    }
}