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
    public partial class Atencion : System.Web.UI.Page
    {
        public Turno tur { get; set; }
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

                if (Request.QueryString["idEdit"] != null)
                {

                    TurnoNegocio turNegocio = new TurnoNegocio();

                   
                    tur = turNegocio.buscarPorId(Request.QueryString["idEdit"].ToString());
                    Paciente.Text = tur.Paciente;
                   
                }
            }

        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            TurnoNegocio negocio = new TurnoNegocio();
            
           int id = int.Parse(Request.QueryString["idEdit"].ToString());
        
            string informe = Informe.Text;
            string indicaciones = Indicaciones.Text;

            negocio.guardarParteMedico(id, informe, indicaciones);

            Response.Redirect("Turnos.aspx");
        }
    }
}