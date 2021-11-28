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
    public partial class Login : System.Web.UI.Page
    {
        public List<Usuario> lista;
        protected void Page_Load(object sender, EventArgs e)
        {
           UsuarioNegocio negocio = new UsuarioNegocio();
            lista = negocio.listar();
            if (!IsPostBack)
            {

                if (Request.QueryString["ex"]!=null)
                {
                    var ex = int.Parse(Request.QueryString["ex"]);
                    if (ex == 1)
                    {
                        Password.BorderColor = System.Drawing.Color.Red;
                    } else if (ex == 2)
                    {
                        usuario.BorderColor = System.Drawing.Color.Red;
                        usuario.Text = "El usuario no existe";
                    }
                   
                }
            }
        }

        protected void Ingresar_Click(object sender, EventArgs e)
        {
           foreach (var user in lista)
            {
                if (usuario.Text == user.Username)
                {
                    if (Password.Text == user.Password)
                    {
                        Session.Add("username", user.Username);
                        Session.Add("contraseña", user.Password);
                        Session.Add("tipoUsuario", user.TipoUsuario);
                        Session.Add("dni", user.Dni);
                      
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        
                        Response.Redirect("Login.aspx?ex=1");
                    }

                }   

            }
                Response.Redirect("Login.aspx?ex=2");
        }
    }
}