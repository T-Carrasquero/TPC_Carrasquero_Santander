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
    public partial class NuevoRecepcionista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["dni"] != null)
                {
                    RecepcionistaNegocio negocio = new RecepcionistaNegocio();

                    Recepcionista recepcionista = new Recepcionista();
                    recepcionista = negocio.buscarRecepcionista(Request.QueryString["dni"]);
                    nombre.Text = recepcionista.Nombre;
                    Apellido.Text = recepcionista.Apellido;
                    Dni.Text = recepcionista.Dni;
                    if (recepcionista.Sexo == "f" || recepcionista.Sexo == "F")
                    {
                        rbtnF.Selected = true;
                    }
                    if (recepcionista.Sexo == "m" || recepcionista.Sexo == "M")
                    {
                        rbtnM.Selected = true;
                    }
                    if (recepcionista.Sexo == "x" || recepcionista.Sexo == "X")
                    {
                        rbtnX.Selected = true;
                    }
                    direccion.Text = recepcionista.Direccion;
                    email.Text = recepcionista.Mail;
                    telefono.Text = recepcionista.Telefono;
                    codigoPostal.Text = recepcionista.Localidad.ToString();
                } 
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            RecepcionistaNegocio negocio = new RecepcionistaNegocio();
            Recepcionista recepcionista = new Recepcionista();

            recepcionista.Nombre = nombre.Text;
            recepcionista.Apellido = Apellido.Text;
            recepcionista.Dni = Dni.Text;
            recepcionista.Telefono = telefono.Text;

            recepcionista.Sexo = ObtenerSexo();

            if (email.Text != null)
            {
                recepcionista.Mail = email.Text;

            }

            if (direccion.Text != null)
            {
                recepcionista.Direccion = direccion.Text;

            }

            if (codigoPostal.Text != null)
            {
                recepcionista.Localidad = int.Parse(codigoPostal.Text);
            }

            if (Request.QueryString["dni"] != null)
            {
                var grabo = negocio.modificar(recepcionista);
            }
            else
            {
                var grabo = negocio.crear(recepcionista);
            }

            Response.Redirect("/Recepcionistas.aspx");
        }

        private string ObtenerSexo()
        {
            if (rbtnM.Selected)
            {
                return rbtnM.Value;

            }
            if (rbtnF.Selected)
            {
                return rbtnF.Value;

            }
            if (rbtnX.Selected)
            {
                return rbtnX.Value;
            }

            return string.Empty;
        }
    }
}