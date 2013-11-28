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
    public partial class panelNotas : WebUI
    {
        AlumnoInscripcionLogic _logic;
        private AlumnoInscripcionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new AlumnoInscripcionLogic();
                }
                return _logic;
            }
        }

        private void LoadGrid()
        {
            int idCurso = int.Parse(Request.QueryString["idCurso"]);
            this.gridView.DataSource = this.Logic.GetAllByIdCurso(idCurso);
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

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }
        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }
        private Entidades.AlumnoInscripcion Entity
        {
            get;
            set;
        }
        private int SelectedID_A
        {
            get
            {
                if (this.ViewState["SelectedID_A"] != null)
                {
                    return (int)this.ViewState["SelectedID_A"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID_A"] = value;
            }
        }
        private int SelectedID_C
        {
            get
            {
                if (this.ViewState["SelectedID_C"] != null)
                {
                    return (int)this.ViewState["SelectedID_C"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID_C"] = value;
            }
        }

        private bool isEntitySelected
        {
            get
            {
                return (this.SelectedID_A != 0 && this.SelectedID_C != 0);
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.SelectedID = (int)this.gridView.SelectedValue;
            var columnasPrim = gridView.DataKeys[gridView.SelectedIndex].Values;
            int id_a = (int)columnasPrim[0];
            int id_c = (int)columnasPrim[1];
            this.SelectedID_A = id_a;
            this.SelectedID_C = id_c;

        }

        private void LoadForm(int id_a, int id_c)
        {
            this.Entity = this.Logic.GetOne(id_a, id_c);
            this.IdCursoTextBox.Text = this.Entity.IdCurso.ToString();
            this.IdAlumnoTextBox.Text = this.Entity.IdAlumno.ToString();
            this.NombreTextBox.Text = this.Entity.NombreAlumno;
            this.ApellidoTextBox.Text = this.Entity.ApellidoAlumno;
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID_A, this.SelectedID_C);
            }
        }

        private void LoadEntity(AlumnoInscripcion alumnoInscripcion)
        {
            alumnoInscripcion.IdAlumno = int.Parse(this.IdAlumnoTextBox.Text);
            alumnoInscripcion.IdCurso = int.Parse(this.IdCursoTextBox.Text);
            alumnoInscripcion.Condicion = this.CondicionDDL.SelectedValue;
            alumnoInscripcion.Nota = Convert.ToInt32(this.NotaDDL.SelectedValue);
        }

        private void SaveEntity(AlumnoInscripcion alumnoInscripcion)
        {
            this.Logic.Save(alumnoInscripcion);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Modificacion:
                    this.Entity = new AlumnoInscripcion();
                    this.Entity.IdAlumno = this.SelectedID_A;
                    this.Entity.IdCurso = this.SelectedID_C;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                default:
                    break;
            }
            this.formPanel.Visible = false;
        }

        private void EnableForm(bool enable)
        {
            this.IdCursoTextBox.Enabled = enable;
            this.IdCursoTextBox.Enabled = enable;
            this.CondicionDDL.Enabled = enable;
            this.NotaDDL.Enabled = enable;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID_A, this.SelectedID_C);
            }
        }

        private void DeleteEntity(int id_a, int id_c)
        {
            this.Logic.Delete(id_a, id_c);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        private void ClearForm()
        {
            this.IdCursoTextBox.Text = string.Empty;
            this.IdCursoTextBox.Text = string.Empty;
            this.ApellidoTextBox.Text = string.Empty;
            this.NombreTextBox.Text = string.Empty;
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
                    hlReportes.Visible = false;
                    hlCargaNota.Visible = false;
                    break;
                case Usuario.TiposPersona.Docente:
                    hlUsuarios.Visible = false;
                    hlDocentesCursos.Visible = false;
                    hlAlumnosInscripciones.Visible = false;
                    hlProfesores.Visible = false;
                    hlReportes.Visible = false;
                    break;
                case Usuario.TiposPersona.Administrador:
                    hlAlumnosInscripciones.Visible = false;
                    hlCargaNota.Visible = false;
                    break;
            }
        }

        protected void cancelarLinkButton_Click1(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
            this.ClearForm();
            this.EnableForm(false);
        }
    }
}