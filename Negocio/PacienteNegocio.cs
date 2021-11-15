using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class PacienteNegocio
    {
        public List<Paciente> listar()
        {
            List<Paciente> lista = new List<Paciente>();
            SqlConnection Conexion = new SqlConnection();
            SqlCommand Comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                Conexion.ConnectionString = "data source=.\\SQLEXPRESS; initial catalog=TPC_CLINICA_DB; integrated security=sspi";
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.CommandText = "select Dni Apellidos, Nombres, Sexo, CodigoPostal, Direccion, Email, Telefono, Estado from Pacientes";
                Comando.Connection = Conexion;

                Conexion.Open();
                lector = Comando.ExecuteReader();

                while (lector.Read())
                {
                    Paciente aux = new Paciente();
                    aux.Apellido = (string)lector["Apellidos"];
                    aux.Nombre = (string)lector["Nombres"];
                    aux.Dni = (string)lector["Dni"];
                    aux.Sexo = (string)lector["Sexo"];
                    aux.Estado = (bool)lector["Estado"];
                    lista.Add(aux);
                }
                Conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Paciente buscarPaciente(string dni)
        {
            Paciente aux = new Paciente();
            SqlConnection Conexion = new SqlConnection();
            SqlCommand Comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                Conexion.ConnectionString = "data source=.\\SQLEXPRESS; initial catalog=TPC_CLINICA_DB; integrated security=sspi";
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.CommandText = "select Dni, Apellidos, Nombres, Sexo, CodigoPostal, Direccion, Email, Telefono, Estado from Pacientes";
                Comando.Connection = Conexion;

                Conexion.Open();
                lector = Comando.ExecuteReader();
                while (lector.Read())
                {

                    aux.Apellido = (string)lector["Apellidos"];
                    aux.Nombre = (string)lector["Nombres"];
                    aux.Dni = (string)lector["Dni"];
                    aux.Sexo = (string)lector["Sexo"];
                    aux.Direccion = (string)lector["Direccion"];
                    aux.Mail = (string)lector["Email"];
                    aux.Telefono = (string)lector["Telefono"];
                    aux.Localidad = (int)lector["CodigoPostal"];
                }

                Conexion.Close();
                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool crear(Paciente nuevo)
        {
            try
            {
                AccesoDatos conexion = new AccesoDatos();

                conexion.SetearConsulta("insert into Pacientes(Dni,Apellidos,Nombres,Sexo,CodigoPostal,Direccion,Mail,Telefono) values (@dni,@apellidos,@nombres,@sexo,@cp,@direccion,@mail,@telefono) ");

                conexion.agregarParametro("@dni", nuevo.Dni);
                conexion.agregarParametro("@apellidos", nuevo.Apellido);
                conexion.agregarParametro("@nombres", nuevo.Nombre);
                conexion.agregarParametro("@sexo", nuevo.Sexo);
                conexion.agregarParametro("@cp", nuevo.Localidad);
                conexion.agregarParametro("@direccion", nuevo.Direccion);
                conexion.agregarParametro("@mail", nuevo.Mail);
                conexion.agregarParametro("@telefono", nuevo.Telefono);

                conexion.ejecutarAccion();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modificar(Paciente nuevo)
        {
            try
            {
                AccesoDatos conexion = new AccesoDatos();

                conexion.SetearConsulta("update Pacientes set Dni = @dni, Apellidos = @apellidos, Nombres = @nombres, Sexo = @sexo, CodigoPostal = @cp, Direccion = @direccion, Mail = @mail,Telefono = @telefono where Dni = @dni ");

                conexion.agregarParametro("@dni", nuevo.Dni);
                conexion.agregarParametro("@apellidos", nuevo.Apellido);
                conexion.agregarParametro("@nombres", nuevo.Nombre);
                conexion.agregarParametro("@sexo", nuevo.Sexo);
                conexion.agregarParametro("@cp", nuevo.Localidad);
                conexion.agregarParametro("@direccion", nuevo.Direccion);
                conexion.agregarParametro("@email", nuevo.Mail);
                conexion.agregarParametro("@telefono", nuevo.Telefono);
                
                conexion.ejecutarAccion();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Baja(string dni)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                conexion.SetearConsulta("update Paciente set estado=0 where Dni=@dni");
                conexion.agregarParametro("@dni", dni);
                conexion.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
