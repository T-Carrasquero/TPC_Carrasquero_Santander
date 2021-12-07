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
    public partial class Solicitar_Turno : System.Web.UI.Page
    {
        public List<Turno> horariosLista = new List<Turno>();
        public List<Especialidad> Especialidad { get; set; }
        public List<Profesional> Medicos { get; set; }
        public List<Paciente> Pacientes { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            DateTime hoy = DateTime.Today;

            EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
            Especialidad = especialidadNegocio.listar();
            PacienteNegocio pacienteNegocio = new PacienteNegocio();
            Pacientes = pacienteNegocio.listar();

            if(fecha.Text == hoy.ToString("yyyy-MM-dd"))
            {
                fecha.BorderColor = System.Drawing.Color.Red;
                Response.Redirect("/Solicitar_Turno.aspx?ex=1");
            }

            if (Request.QueryString["ex"] != null)
            {
                var ex = int.Parse(Request.QueryString["ex"]);
                if (ex == 1)
                {
                    fecha.BorderColor = System.Drawing.Color.Red;
                }

            }

            if (!IsPostBack)
            {
                foreach (var item in Especialidad)
                {
                    ListItem aux = new ListItem(item.Descripcion, item.Descripcion);
                    ddlEspecialidad.Items.Add(aux);
                }
                if (Session["tipoUsuario"].ToString() == "Administrador")
                {
                    foreach (var item in Pacientes)
                    {
                        ListItem aux = new ListItem(item.Nombre + " " + item.Apellido, item.Dni);
                        ddlPaciente.Items.Add(aux);
                    }
                }
            }


        }

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            MedicosNegocio negocio = new MedicosNegocio();
            Medicos = negocio.listarPorEspecialidad(ddlEspecialidad.SelectedValue.ToString());

            ddlMedicos.Items.Clear();

            foreach (var item in Medicos)
                {
                    ListItem aux = new ListItem(item.Nombre + " " + item.Apellido,item.Dni);
                    ddlMedicos.Items.Add(aux);
                }
        }

        protected void ddlEspecialidad_TextChanged(object sender, EventArgs e)
        {
            MedicosNegocio negocio = new MedicosNegocio();
            Medicos = negocio.listarPorEspecialidad(ddlEspecialidad.SelectedValue.ToString());

            if (!IsPostBack)
            {
                foreach (var item in Medicos)
                {
                    ListItem aux = new ListItem(item.Nombre + " " + item.Apellido, item.Dni);
                    ddlMedicos.Items.Add(aux);
                }
            }
        }

        protected void fecha_TextChanged(object sender, EventArgs e)
        {
            TurnoNegocio turnoNegocio = new TurnoNegocio();
            horariosLista = turnoNegocio.horariosOcupadosPorMedico(ddlMedicos.SelectedValue.ToString(), fecha.Text.ToString());
            

            for(int i = 7; i <= 22; i++)
            {
                if (horariosLista.Count != 0)
                {
                    foreach (var ocupado in horariosLista)
                    {
                        if (i != ocupado.Hora)
                        {
                            ListItem aux = new ListItem(i.ToString() + ":00hs", i.ToString());
                            ddlHorarios.Items.Add(aux);
                        }
                    }
                }
                else
                {
                    ListItem aux = new ListItem(i.ToString() + ":00hs", i.ToString());
                    ddlHorarios.Items.Add(aux);
                }
                
            }

        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            TurnoNegocio negocio = new TurnoNegocio();
            Turno turno = new Turno();

            if (Session["tipoUsuario"].ToString() == "Administrador")
            {
                turno.Paciente = ddlPaciente.SelectedValue.ToString();
                turno.Estado = "1";
            }

            if (Session["tipoUsuario"].ToString() == "Paciente")
            {

                turno.Paciente = Session["dni"].ToString();
                turno.Estado = "4";
            }

            turno.Medico = ddlMedicos.SelectedValue.ToString();
            turno.Fecha = DateTime.Parse(fecha.Text);
            turno.Hora = float.Parse(ddlHorarios.SelectedValue.ToString());


            Response.Write("<script>alert('" + turno.Paciente + "');</script>");
            Response.Write("<script>alert('" + turno.Medico + "');</script>");
            Response.Write("<script>alert('" + turno.Fecha.ToString("yyyy-MM-dd") + "');</script>");
            Response.Write("<script>alert('" + turno.Hora + "');</script>");
            Response.Write("<script>alert('" + turno.Estado + "');</script>");

            var grabo = negocio.crear(turno);

            //if (Session["tipoUsuario"].ToString() == "Administrador")
            //{
            //}

            //if (Request.QueryString["dni"] != null)
            //{
            //    var grabo = negocio.modificar(medico);

            //}
            //else
            //{
            //    var grabo = negocio.crear(turno);

            //}

           // Response.Redirect("/Turnos.aspx");
        }
    }
}