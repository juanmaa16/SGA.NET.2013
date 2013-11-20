using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Web
{
    public partial class WebUI : System.Web.UI.Page
    {
        public bool Logueado()
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

        public void SessionDestroy()
        {
            Session.Clear();
            Page.Response.Redirect("Login.aspx");
        }


    }
}