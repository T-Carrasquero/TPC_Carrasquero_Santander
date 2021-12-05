using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Clinica
{
    public partial class Turnos : System.Web.UI.Page
    {
        public List<Turno> turnosLista = new List<Turno>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            string dni = Session["dni"].ToString();

            TurnoNegocio turnoNegocio = new TurnoNegocio();
            turnosLista = turnoNegocio.listar(dni);

        }



    }
}