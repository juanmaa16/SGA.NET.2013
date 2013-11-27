using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace UI.Web
{
    public partial class Reporte_cursos : WebUI
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Logueado())
            {
                Page.Response.Redirect("Login.aspx");
            }
            else
            {
                this.cargaModulos();
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
                    hlDocentesCursos.Visible = false;
                    hlAlumnos.Visible = false;
                    hlProfesores.Visible = false;
                    break;
                case Usuario.TiposPersona.Docente:
                    hlUsuarios.Visible = false;
                    hlDocentesCursos.Visible = false;
                    hlAlumnosInscripciones.Visible = false;
                    hlProfesores.Visible = false;
                    break;
                case Usuario.TiposPersona.Administrador:
                    hlAlumnosInscripciones.Visible = false;
                    break;
            }
        }
    }
}