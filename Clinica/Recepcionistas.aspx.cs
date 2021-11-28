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
    public partial class Recepcionistas : System.Web.UI.Page
    {
        public List<Recepcionista> listaRecepcionistas { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["username"]== null)
            {
                Response.Redirect("Login.aspx");
            }

            RecepcionistaNegocio negocio = new RecepcionistaNegocio();
            listaRecepcionistas = negocio.listar();

            if (Request.QueryString["dni"] != null)
            {
                string dni = Request.QueryString["dni"];
                eliminarRegistro(dni);
                Response.Redirect("Recepcionistas.aspx");
            }
        }
        protected void eliminarRegistro(string dni)
        {

            RecepcionistaNegocio negocio = new RecepcionistaNegocio();
            try
            {
                negocio.Baja(dni);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e, string dni)
        {
            string str = Request.QueryString["dni"];
            Response.Write("<script lenguage=javascript>alert('" + str + "');</script>");

        }

    }
}