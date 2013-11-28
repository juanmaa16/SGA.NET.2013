using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using Util;

namespace UI.Web
{
    public partial class Usuarios : WebUI
    {

        UsuarioLogic _logicUsuario;
        PersonaLogic _logicPersona;

        private UsuarioLogic LogicUsuario
        {
            get
            {
                if (_logicUsuario == null)
                {
                    _logicUsuario = new UsuarioLogic();
                }
                return _logicUsuario;
            }
        }

        private PersonaLogic LogicPersona
        {
            get
            {
                if (_logicPersona == null)
                {
                    _logicPersona = new PersonaLogic();
                }
                return _logicPersona;
            }
        }

        private void LoadGrid()
        {
            this.gridView.DataSource = this.LogicUsuario.GetAll();
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
        private Usuario EntityUsuario
        {
            get;
            set;
        }
        private Persona EntityPersona
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

        private void LoadForm(int id)
        {
            this.EntityUsuario = this.LogicUsuario.GetOne(id);
            this.nombreTextBox.Text = this.EntityUsuario.Nombre;
            this.apellidoTextBox.Text = this.EntityUsuario.Apellido;
            this.emailTextBox.Text = this.EntityUsuario.Email;
            this.habilitadoCheckBox.Checked = this.EntityUsuario.Habilitado;
            this.nombreUsuarioTextBox.Text = this.EntityUsuario.NombreUsuario;

            this.EntityPersona = this.LogicPersona.GetOne(id);
            this.telefonoTextBox.Text = this.EntityPersona.Telefono;
            this.direccionTextBox.Text = this.EntityPersona.Direccion;
            this.fechaNacimientoCalendar.SelectedDate = this.EntityPersona.FechaNacimiento;
            this.legajoTextBox.Text = this.EntityPersona.Legajo.ToString();
            this.idPlanTextBox.Text = this.EntityPersona.IdPlan.ToString();
            //this.TipoPersonaDDL.SelectedValue = ; //TODO: ARREGLAR

        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        private void LoadEntity(Usuario usuario, Persona persona)
        {
            usuario.Nombre = this.nombreTextBox.Text;
            usuario.Apellido = this.apellidoTextBox.Text;
            usuario.Email = this.emailTextBox.Text;
            usuario.NombreUsuario = this.nombreUsuarioTextBox.Text;
            usuario.Password = this.claveTextBox.Text;
            usuario.Habilitado = this.habilitadoCheckBox.Checked;

            persona.Nombre = this.nombreTextBox.Text;
            persona.Apellido = this.apellidoTextBox.Text;
            persona.Direccion = this.direccionTextBox.Text;
            persona.Email = this.emailTextBox.Text;
            persona.Telefono = this.telefonoTextBox.Text;
            persona.FechaNacimiento = this.fechaNacimientoCalendar.SelectedDate;
            persona.Legajo = int.Parse(this.legajoTextBox.Text);
            persona.TipoPersona = this.SeleccionaTipoPersona(int.Parse(this.TipoPersonaDDL.SelectedValue));
            persona.IdPlan = int.Parse(this.idPlanTextBox.Text);

        }

        private Persona.TiposPersona SeleccionaTipoPersona(int tipoPersonaSelected)
        {
            Persona.TiposPersona tipoPersona;
            switch (tipoPersonaSelected)
            {
                case 0: tipoPersona = Persona.TiposPersona.Alumno;
                    break;
                case 1: tipoPersona = Persona.TiposPersona.Docente;
                    break;
                case 2: tipoPersona = Persona.TiposPersona.Administrador;
                    break;
                default: tipoPersona = Persona.TiposPersona.Administrador;
                    break;
            }
            return tipoPersona;
        }

        private void SaveEntity(Usuario usuario, Persona persona)
        {
            this.LogicPersona.Save(persona);
            this.LogicUsuario.Save(usuario);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    if (!Utilidades.validaClavesIguales(claveTextBox.Text, repetirClaveTextBox.Text))
                    {   
                        string script = @"<script language='javascript'>alert('Las contraseñas no coinciden');</script>";
                        Page.RegisterStartupScript("alerta", script);
                        break;
                    }
                    this.EntityUsuario = new Usuario();
                    this.EntityPersona = new Persona();
                    this.LoadEntity(this.EntityUsuario, this.EntityPersona);
                    this.SaveEntity(this.EntityUsuario, this.EntityPersona);
                    this.LoadGrid();
                    break;
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.EntityUsuario = new Usuario();
                    this.EntityPersona = new Persona();
                    this.EntityUsuario.ID = this.SelectedID;
                    this.EntityPersona.IdPersona = this.SelectedID;
                    this.EntityUsuario.State = BusinessEntity.States.Modified;
                    this.EntityPersona.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.EntityUsuario, this.EntityPersona);
                    this.SaveEntity(this.EntityUsuario, this.EntityPersona);
                    this.LoadGrid();
                    break;
                default:
                    break;
            }
            this.formPanel.Visible = false;
        }

        private void EnableForm(bool enable)
        {
            this.nombreTextBox.Enabled = enable;
            this.apellidoTextBox.Enabled = enable;
            this.emailTextBox.Enabled = enable;
            this.nombreUsuarioTextBox.Enabled = enable;
            this.claveTextBox.Visible = enable;
            this.claveLabel.Visible = enable;
            this.repetirClaveTextBox.Visible = enable;
            this.repetirClaveLabel.Visible = enable;

            this.telefonoTextBox.Enabled = enable;
            this.direccionTextBox.Enabled = enable;
            this.fechaNacimientoCalendar.Enabled = enable;
            this.legajoTextBox.Enabled = enable;
            this.idPlanTextBox.Enabled = enable;
            this.TipoPersonaDDL.Enabled = enable;

        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        private void DeleteEntity(int id)
        {
            this.LogicUsuario.Delete(id);
            this.LogicPersona.Delete(id);
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
            this.nombreTextBox.Text = string.Empty;
            this.apellidoTextBox.Text = string.Empty;
            this.emailTextBox.Text = string.Empty;
            this.habilitadoCheckBox.Checked = false;
            this.nombreUsuarioTextBox.Text = string.Empty;
            this.telefonoTextBox.Text = string.Empty;
            this.direccionTextBox.Text = string.Empty;
            this.legajoTextBox.Text = string.Empty;
            this.idPlanTextBox.Text = string.Empty;
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
                    hlAlumnos.Visible = true;
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
    }
}