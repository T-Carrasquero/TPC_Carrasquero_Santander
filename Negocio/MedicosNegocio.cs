﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;


namespace Negocio
{
    public class MedicosNegocio
    {
        
        public List<Profesional> listar()
        {
            List<Profesional> lista = new List<Profesional>();
            SqlConnection Conexion = new SqlConnection();
            SqlCommand Comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                Conexion.ConnectionString = "data source=.\\SQLEXPRESS; initial catalog=TPC_CLINICA_DB; integrated security=sspi";
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.CommandText = "select medicos.Dni, medicos.Nombres, medicos.Apellidos, medicos.Sexo, medicos.Matricula, e.Descripcion from Medicos medicos left join EspecialidadesPorMedico epm on Dni = epm.DniMedico left join Especialidades e on epm.IdEspecialidad = e.Id";
                Comando.Connection = Conexion;

                Conexion.Open();
                lector = Comando.ExecuteReader();

                while (lector.Read())
                {
                    Profesional aux = new Profesional();
                    aux.Apellido = (string)lector["Apellidos"];
                    aux.Nombre = (string)lector["Nombres"];
                    aux.Dni = (string)lector["Dni"];
                    aux.Sexo = (string)lector["Sexo"];
                    aux.Especialidad = (string)lector["Descripcion"];
                    /* aux.Direccion = (string)lector["Direccion"];
                     aux.Mail = (string)lector["Email"];*/
                    aux.Matricula = (string)lector["Matricula"];

                    lista.Add(aux);
                }
                Conexion.Close();
                return lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool crear(Profesional nuevo)
        {
            try
            {
                AccesoDatos conexion = new AccesoDatos();

                conexion.SetearConsulta("insert into Medicos(Dni,Apellidos,Nombres,Sexo,CodigoPostal,Direccion,Email,Telefono,Matricula) values (@dni,@apellidos,@nombres,@sexo,@cp,@direccion,@email,@tel,@matricula) ");
                
                conexion.agregarParametro("@dni", nuevo.Dni);
                conexion.agregarParametro("@apellidos", nuevo.Apellido);
                conexion.agregarParametro("@nombres", nuevo.Nombre);
                conexion.agregarParametro("@sexo", nuevo.Sexo);
                conexion.agregarParametro("@cp", nuevo.Localidad);
                conexion.agregarParametro("@direccion", nuevo.Direccion);
                conexion.agregarParametro("@email", nuevo.Mail);
                conexion.agregarParametro("@tel", nuevo.Telefono);
                conexion.agregarParametro("@matricula", nuevo.Matricula);

                conexion.ejecutarAccion();

                return true;
            }
            catch
            { 
                return false;
            }
        }
    }
}
