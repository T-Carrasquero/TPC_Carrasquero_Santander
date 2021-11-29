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
    public partial class ObrasSociales : System.Web.UI.Page
    {
        public List<ObraSocial> listaObrasSociales { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            ObraSocialNegocio negocio = new ObraSocialNegocio();
            listaObrasSociales = negocio.listar();

            if (Request.QueryString["Rnos"] != null)
            {
                string rnos = Request.QueryString["Rnos"];
                eliminarRegistro(rnos);
                Response.Redirect("ObrasSociales.aspx");
            }
        }

        protected void eliminarRegistro(string rnos)
        {

            ObraSocialNegocio negocio = new ObraSocialNegocio();
            try
            {
                negocio.Baja(rnos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}