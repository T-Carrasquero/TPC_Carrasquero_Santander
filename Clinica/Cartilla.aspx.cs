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
        public List<Profesional> medico { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            MedicosNegocio negocio = new MedicosNegocio();
         
            medico = negocio.listar();
        }
    }
}