using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Clinica
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public List<Profesional> medicos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            MedicosNegocio negocio = new MedicosNegocio();
            medicos = negocio.listar();

            if (Request.QueryString["dni"] != null)
            {
                string dni = Request.QueryString["dni"];
                eliminarRegistro(dni);
                Response.Redirect("Cartilla.aspx");
            }
        }

        protected void eliminarRegistro(string dni)
        {
            MedicosNegocio negocio = new MedicosNegocio();
            EspecialidadNegocio espNegocio = new EspecialidadNegocio();
            try
            {
                espNegocio.eliminar(dni);
                negocio.eliminar(dni);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e, string dni)
        {
            string str = Request.QueryString["dni"];
            Response.Write("<script lenguage=javascript>alert('" + str + "');</script>");

        }

    
    }
}