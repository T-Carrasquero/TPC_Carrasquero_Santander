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
    public partial class Registrarse : System.Web.UI.Page
    {
        public List<Paciente> PacientesLista;
        public List<Usuario> UsuariosLista;
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            PacienteNegocio pacienteNegocio = new PacienteNegocio();
            UsuariosLista = usuarioNegocio.listar();
            PacientesLista = pacienteNegocio.listar();

            if (Request.QueryString["ex"] != null)
            {
                var ex = int.Parse(Request.QueryString["ex"]);
                if (ex == 1)
                {
                    dni.BorderColor = System.Drawing.Color.Red;
                }
                else if (ex == 2)
                {
                    usuario.BorderColor = System.Drawing.Color.Red;
                    usuario.Text = "El usuario no existe";
                }

            }
        }

        protected void guardar_Click(object sender, EventArgs e)
        {
            try
            {
                PacienteNegocio pacienteNegocio = new PacienteNegocio();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

                Paciente paciente = new Paciente();
                Usuario user = new Usuario();

                paciente.Nombre = nombre.Text;
                paciente.Apellido = apellido.Text;
                paciente.Dni = dni.Text;
                paciente.Telefono = telefono.Text;

                user.Dni = dni.Text;
                user.Username = usuario.Text;
                user.Password = Password.Text;
                user.TipoUsuario = "Paciente"; 

                foreach(var item in PacientesLista)
                {
                    if(item.Dni == user.Dni)
                    {
                        Response.Redirect("/Registrarse.aspx?ex=1");
                        Response.Write("<script>alert('El dni ya fue registrado');</script>");
                    }
                }


                if (rbtnM.Selected == true)
                {
                    paciente.Sexo = rbtnM.Value;

                }
                if (rbtnF.Selected == true)
                {
                    paciente.Sexo = rbtnF.Value;

                }
                if (rbtnX.Selected == true)
                {
                    paciente.Sexo = rbtnX.Value;

                }

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

                Response.Redirect("/Login.aspx");
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}