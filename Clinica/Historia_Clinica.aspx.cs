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
    public partial class Historia_Clinica : System.Web.UI.Page
    {
        public List<Turno> turnos { get; set; }
        public Paciente pac { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (Session["TipoUsuario"].ToString() != "Administrador" && Session["TipoUsuario"].ToString() != "Medico")
            {
                Response.Redirect("Default.aspx");
            }

            if (!IsPostBack)
            {

                if (Request.QueryString["idHistoria"] != null)
                {
                    TurnoNegocio turNegocio = new TurnoNegocio();
                    PacienteNegocio pacNegocio = new PacienteNegocio();

                    pac = pacNegocio.buscarPaciente(Request.QueryString["idHistoria"].ToString());
                    turnos = turNegocio.getHistoriaClinica(Request.QueryString["idHistoria"].ToString());

                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        protected void Volver_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["origin"].ToString() == "pacientes")
            {
                Response.Redirect("Pacientes.aspx");
            }

            if (Request.QueryString["origin"].ToString() == "atencion")
            {
                var idTurno = Request.QueryString["idTurno"].ToString();
                Response.Redirect("Atencion.aspx?idEdit="+idTurno+"");
            }
        }
    }
}