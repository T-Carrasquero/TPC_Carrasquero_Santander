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

            if (Request.QueryString["idCancel"] != null)
            {
                int id = int.Parse(Request.QueryString["idCancel"].ToString());
                TurnoNegocio turnoNegocio = new TurnoNegocio();
                turnoNegocio.cancelar(id);
                Response.Redirect("Turnos.aspx");
            }
            if (Request.QueryString["idConfirm"] != null)
            {
                int id = int.Parse(Request.QueryString["idConfirm"].ToString());
                TurnoNegocio turnoNegocio = new TurnoNegocio();
                turnoNegocio.confirmar(id);
                Response.Redirect("Turnos.aspx");
            }


            if (Session["tipoUsuario"].ToString() == "Paciente")
            {
                string dni = Session["dni"].ToString();

                TurnoNegocio turnoNegocio = new TurnoNegocio();
                turnosLista = turnoNegocio.listar(dni);
            }

            if (Session["tipoUsuario"].ToString() == "Administrador")
            {
                string dni = Session["dni"].ToString();

                TurnoNegocio turnoNegocio = new TurnoNegocio();
                turnosLista = turnoNegocio.listarTodos();
            }


        }

    }
}