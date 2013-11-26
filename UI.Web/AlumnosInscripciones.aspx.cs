using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace UI.Web
{
    public partial class AlumnosInscripciones : WebUI
    {
        CursoLogic _cursoLogic;
        AlumnoInscripcionLogic _alumnoInscripcionLogic;

        private CursoLogic CursoLogic
        {
            get
            {
                if (_cursoLogic == null)
                {
                    _cursoLogic = new CursoLogic();
                }
                return _cursoLogic;
            }
        }

        private AlumnoInscripcionLogic AlumnoInscripcionLogic
        {
            get
            {
                if (_alumnoInscripcionLogic == null)
                {
                    _alumnoInscripcionLogic = new AlumnoInscripcionLogic();
                }
                return _alumnoInscripcionLogic;
            }
        }


        private void LoadGrid()
        {
            this.gridView.DataSource = this.CursoLogic.GetAllInscripcion((int)Session["IdPlan"]);
            this.gridView.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Logueado())
            {
                Page.Response.Redirect("Login.aspx");
            }
            else
            {
                this.cargaModulos();
                if (!this.IsPostBack)
                {
                    this.LoadGrid();
                }
            }
        }
        private Curso CursoEntety
        {
            get;
            set;
        }
        private AlumnoInscripcion EntityAlumnoInscripcion
        {
            get;
            set;
        }
        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        private bool isEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void LoadEntity(AlumnoInscripcion alumnoInscripcion)
        {
            alumnoInscripcion.IdAlumno = (int)Session["IdUsuario"];
            alumnoInscripcion.IdCurso = this.SelectedID;
            alumnoInscripcion.Nota = 0;
            alumnoInscripcion.Condicion = "Inscripto";
        }

        private void SaveEntity(AlumnoInscripcion alumnoInscripcion)
        {
            this.AlumnoInscripcionLogic.Save(alumnoInscripcion);
        }


        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.EntityAlumnoInscripcion = new AlumnoInscripcion();
            this.LoadEntity(this.EntityAlumnoInscripcion);
            this.SaveEntity(this.EntityAlumnoInscripcion);
            //Page.Response.Redirect("InscripcionFinalizada.aspx?comision="+this.gridView.Rows);
            //this.LoadGrid();
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