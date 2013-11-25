using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class InscripcionFinalizada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMateria.Text = Request.Form["materia"];
            lblComision.Text = Request.Form["comision"];

        }
    }
}