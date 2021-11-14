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
    public partial class Cartilla_Crear : System.Web.UI.Page
    {
        public List<Especialidad> Especialidad { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            EspecialidadNegocio negocio = new EspecialidadNegocio();
            Especialidad = negocio.listar();

            if (!IsPostBack)
            {
                foreach(var item in Especialidad)
                {
                    ListItem aux = new ListItem(item.Descripcion,item.Descripcion);
                    ddlEspecialidad.Items.Add(aux);
                }
            }


            if(Request.QueryString["dni"] != null){
                MedicosNegocio medNegocio = new MedicosNegocio();

                Profesional med = new Profesional();
                med = medNegocio.buscarMedicoId(Request.QueryString["dni"]);
                nombre.Text = med.Nombre.ToString();
                Apellido.Text = med.Apellido.ToString();
                Dni.Text = med.Dni.ToString();
                ddlEspecialidad.SelectedValue = med.Especialidad.ToString();
                matricula.Text = med.Matricula.ToString();
                telefono.Text = med.Telefono.ToString();
                if (med.Sexo == "m" || med.Sexo == "M")
                {
                    rbtnM.Selected = true;

                }
                if (med.Sexo == "f" || med.Sexo == "F")
                {
                    rbtnF.Selected = true;

                }
                if (med.Sexo == "x" || med.Sexo == "X")
                {
                    rbtnX.Selected = true;

                }
                email.Text = med.Mail.ToString();
                direccion.Text = med.Direccion.ToString();
                codigoPostal.Text = med.Localidad.ToString();

            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            MedicosNegocio negocio = new MedicosNegocio();
            Profesional medico = new Profesional();
            EspecialidadNegocio espNegocio = new EspecialidadNegocio();
            Especialidad = espNegocio.listar();

            medico.Nombre = nombre.Text;
            medico.Apellido = Apellido.Text;
            medico.Dni = Dni.Text;
        
            var espIndex = 0;
            var idesp = 0;
            foreach (var item in Especialidad)
            {
                espIndex++;
                if(ddlEspecialidad.SelectedValue == item.Descripcion)
                {
                    medico.Especialidad = ddlEspecialidad.SelectedValue;
                    idesp = espIndex;

                }
            }

            medico.Matricula = matricula.Text;

            medico.Telefono = telefono.Text;
 
            

            if (rbtnM.Selected == true)
            {
                medico.Sexo = rbtnM.Value;

            } 
            if(rbtnF.Selected == true)
            {
                medico.Sexo = rbtnF.Value;

            }
            if (rbtnX.Selected == true)
            {
                medico.Sexo = rbtnX.Value;
 
            }    


            if (email.Text != null) {
                medico.Mail = email.Text;
         
            }

            if (direccion.Text != null)
            {
                medico.Direccion = direccion.Text;
                
            }

            if (codigoPostal.Text != null)
            {
                medico.Localidad = int.Parse(codigoPostal.Text);
             
            }
         

            if (Request.QueryString["dni"] != null)
            {
                var grabo = negocio.modificar(medico);
                var grabo2 = espNegocio.modificarEspecialidad(idesp, medico.Dni);
            }
            else
            {
                var grabo = negocio.crear(medico);
                var grabo2 = espNegocio.setEspecialidad(idesp, medico.Dni);
            }


        }
    }
}