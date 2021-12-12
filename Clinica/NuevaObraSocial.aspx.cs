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
    public partial class NuevaObraSocial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!(Session["TipoUsuario"].ToString() == "Administrador" || Session["TipoUsuario"].ToString() == "Recepcionista"))
            {
                Response.Redirect("Default.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["rnos"] != null)
                {
                    ObraSocialNegocio negocio = new ObraSocialNegocio();

                    ObraSocial obraSocial = new ObraSocial();
                    obraSocial = negocio.buscarObraSocial(Request.QueryString["rnos"]);
                    rnos.Text = obraSocial.Rnos;
                    sigla.Text = obraSocial.Sigla;
                    nombre.Text = obraSocial.Nombre;
                    email.Text = obraSocial.Email;
                    direccion.Text = obraSocial.Domicilio;
                    codigoPostal.Text = obraSocial.CodigoPostal.ToString();
                }
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ObraSocialNegocio negocio = new ObraSocialNegocio();
            ObraSocial obraSocial = new ObraSocial();

            obraSocial.Rnos = rnos.Text;
            obraSocial.Sigla = sigla.Text;
            obraSocial.Nombre = nombre.Text;

            if (email.Text != null)
            {
                obraSocial.Email = email.Text;

            }

            if (direccion.Text != null)
            {
                obraSocial.Domicilio = direccion.Text;

            }

            if (codigoPostal.Text != null)
            {
                obraSocial.CodigoPostal = int.Parse(codigoPostal.Text);
            }

            if (Request.QueryString["rnos"] != null)
            {
                var grabo = negocio.modificar(obraSocial);
            }
            else
            {
                var grabo = negocio.crear(obraSocial);
            }

            Response.Redirect("/ObrasSociales.aspx");
        }
    }
 
}