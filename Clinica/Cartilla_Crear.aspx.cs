﻿using System;
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
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            MedicosNegocio negocio = new MedicosNegocio();
            Profesional medico = new Profesional();
            EspecialidadNegocio espNegocio = new EspecialidadNegocio();
            Especialidad = espNegocio.listar();
            

            medico.Nombre = nombre.Text;
           

            medico.Apellido = Apellido.Text;
        ;
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
         

            var grabo = negocio.crear(medico);
            Response.Write("<script language=javascript> alert('" + grabo  + "'); </script>");
            var grabo2 = espNegocio.setEspecialidad(idesp, medico.Dni);
            Response.Write("<script language=javascript> alert('" + grabo2 + "'); </script>");


        }
    }
}