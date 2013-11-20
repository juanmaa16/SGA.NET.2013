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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private Usuario Entity
        {
            get;
            set;
        }

        UsuarioLogic _logic;
        private UsuarioLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new UsuarioLogic();
                }
                return _logic;
            }
        }

        private bool verificaUser(string user,string pass)
        {
            this.Entity = this.Logic.GetOneUser(user);
            if (Entity.Password == pass)
            {
                Session["IdUsuario"] = Entity.ID;
                Session["NombreUsuario"] = Entity.NombreUsuario;
                Session["TipoPersona"] = (Usuario.TiposPersona)Entity.TipoPersona;
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string user = this.txtUsuario.Text.ToString();
            string pass = this.txtPassword.Text.ToString();
            if (verificaUser(user, pass))
            {
                Response.Redirect("Principal.aspx");
            }
            else
            {
                Page.Response.Write("Usuario y/o Contraseña incorrectos");
            }
        }
    }
}