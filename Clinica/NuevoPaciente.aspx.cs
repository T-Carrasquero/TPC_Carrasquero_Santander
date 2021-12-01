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
    public partial class NuevoPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (Session["TipoUsuario"].ToString() != "Administrador" || Session["TipoUsuario"].ToString() != "Recepcionista")
            {
                Response.Redirect("Default.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["dni"] != null)
                {
                    PacienteNegocio pacienteNegocio = new PacienteNegocio();

                    Paciente paciente = new Paciente();
                    paciente = pacienteNegocio.buscarPaciente(Request.QueryString["dni"]);
                    nombre.Text = paciente.Nombre;
                    Apellido.Text = paciente.Apellido;
                    Dni.Text = paciente.Dni;
                    if (paciente.Sexo == "f" || paciente.Sexo == "F")
                    {
                        rbtnF.Selected = true;
                    }
                    if (paciente.Sexo == "m" || paciente.Sexo == "M")
                    {
                        rbtnM.Selected = true;
                    }
                    if (paciente.Sexo == "x" || paciente.Sexo == "X")
                    {
                        rbtnX.Selected = true;
                    }
                    direccion.Text = paciente.Direccion;
                    email.Text = paciente.Mail;
                    telefono.Text = paciente.Telefono;
                    codigoPostal.Text = paciente.Localidad.ToString();
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            PacienteNegocio pacienteNegocio = new PacienteNegocio();
            Paciente paciente = new Paciente();

            paciente.Nombre = nombre.Text;
            paciente.Apellido = Apellido.Text;
            paciente.Dni = Dni.Text;
            paciente.Telefono = telefono.Text;

            paciente.Sexo = ObtenerSexo();

            if (email.Text != null)
            {
                paciente.Mail = email.Text;

            }

            if (direccion.Text != null)
            {
                paciente.Direccion = direccion.Text;

            }

            if (codigoPostal.Text != null)
            {
                paciente.Localidad = int.Parse(codigoPostal.Text);
            }

            if (Request.QueryString["dni"] != null)
            {
                var grabo = pacienteNegocio.modificar(paciente);
            }
            else
            {
                var grabo = pacienteNegocio.crear(paciente);
            }

            Response.Redirect("/Pacientes.aspx");
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