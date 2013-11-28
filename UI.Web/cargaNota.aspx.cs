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
    public partial class cargaNota : WebUI
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

        private void LoadDropDownList()
        {
            //this.CursosDocenteDDL.DataSource = this.Logic.GetAll();
            //this.CursosDocenteDDL.DataBind();
            int idDocente = (int)Session["IdUsuario"];
            List<DocenteCurso> vDocentes = this.Logic.GetAllByDocente(idDocente);
            ListItem item = new ListItem();
            foreach (DocenteCurso dc in vDocentes)
            {
                item = new ListItem();
                item.Value = dc.IdCurso.ToString();
                item.Text = dc.DescMateria;
                CursosDocenteDDL.Items.Add(item);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadDropDownList();
        }

        protected void cargarNotasLinkButton_Click(object sender, EventArgs e)
        {
            string url = "panelNotas.aspx?idCurso=" + CursosDocenteDDL.SelectedValue;
            Page.Response.Redirect(url);
        }
    }
}