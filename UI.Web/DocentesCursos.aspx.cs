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
    public partial class DocentesCursos : WebUI
    {
        DocenteCursoLogic _logic;
        private DocenteCursoLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new DocenteCursoLogic();
                }
                return _logic;
            }
        }

        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
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
                Usuario.TiposPersona tipoPersona = (Usuario.TiposPersona)Session["TipoPersona"];
                if (tipoPersona != Usuario.TiposPersona.Administrador)
                {
                    Page.Response.Redirect("principal.aspx");
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
        private DocenteCurso Entity
        {
            get;
            set;
        }
        private int SelectedID_D
        {
            get
            {
                if (this.ViewState["SelectedID_D"] != null)
                {
                    return (int)this.ViewState["SelectedID_D"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID_D"] = value;
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
                return (this.SelectedID_D != 0 && this.SelectedID_C != 0);
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.SelectedID = (int)this.gridView.SelectedValue;
            var columnasPrim = gridView.DataKeys[gridView.SelectedIndex].Values;
            int id_d = (int)columnasPrim[0];
            int id_c = (int)columnasPrim[1];
            this.SelectedID_D = id_d;
            this.SelectedID_C = id_c;

        }

        private void LoadForm(int id_d, int id_c)
        {
            this.Entity = this.Logic.GetOne(id_d, id_c);
            this.IDCursoTextBox.Text = this.Entity.IdCurso.ToString();
            this.IDDocenteTextBox.Text = this.Entity.IdDocente.ToString(); ;
            //   this.tipoCargoDDL.Text = this.Entity.Cargo.ToString();
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID_D, this.SelectedID_C);
            }
        }

        private void LoadEntity(DocenteCurso docentecurso)
        {

            docentecurso.IdCurso = int.Parse(this.IDCursoTextBox.Text);
            docentecurso.IdDocente = int.Parse(this.IDDocenteTextBox.Text);
            docentecurso.Cargo = this.SeleccionaTipoCargo(int.Parse(this.tipoCargoDDL.SelectedValue));
        }

        private DocenteCurso.TiposCargo SeleccionaTipoCargo(int tipoCargoSelected)
        {
            DocenteCurso.TiposCargo tipoCargo;
            switch (tipoCargoSelected)
            {
                case 0: tipoCargo = DocenteCurso.TiposCargo.Titular;
                    break;
                case 1: tipoCargo = DocenteCurso.TiposCargo.Provisional;
                    break;
                default: tipoCargo = DocenteCurso.TiposCargo.Provisional;
                    break;
            }
            return tipoCargo;
        }

        private void SaveEntity(DocenteCurso docentecurso)
        {
            this.Logic.Save(docentecurso);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.Entity = new DocenteCurso();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID_D, this.SelectedID_C);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = new DocenteCurso();
                    this.Entity.IdDocente = this.SelectedID_D;
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
            this.IDCursoTextBox.Enabled = enable;
            this.IDDocenteTextBox.Enabled = enable;
            this.tipoCargoDDL.Enabled = enable;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID_D, this.SelectedID_C);
            }
        }

        private void DeleteEntity(int id_d, int id_c)
        {
            this.Logic.Delete(id_d, id_c);
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
            this.IDCursoTextBox.Text = string.Empty;
            this.IDDocenteTextBox.Text = string.Empty;
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
                    nuevoLinkButton.Visible = false;
                    eliminarLinkButton.Visible = false;
                    editarLinkButton.Visible = false;
                    hlAlumnos.Visible = false;
                    hlProfesores.Visible = false;
                    hlReportes.Visible = false;
                    hlCargaNota.Visible = false;
                    break;
                case Usuario.TiposPersona.Docente:
                    hlUsuarios.Visible = false;
                    nuevoLinkButton.Visible = false;
                    eliminarLinkButton.Visible = false;
                    editarLinkButton.Visible = false;
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
            //no funciona con nuevo
        }
    }
}