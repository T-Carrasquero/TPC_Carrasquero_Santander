using System;
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
                Comando.CommandText = "select medicos.*, e.Descripcion from Medicos medicos left join EspecialidadesPorMedico epm on Dni = epm.DniMedico left join Especialidades e on epm.IdEspecialidad = e.Id";
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
                    aux.Direccion = (string)lector["Direccion"];
                    aux.Mail = (string)lector["Email"];
                    aux.Telefono = (string)lector["Telefono"];
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

        public Profesional buscarMedicoId(string dni)
        {
            Profesional aux = new Profesional();
            SqlConnection Conexion = new SqlConnection();
            SqlCommand Comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                Conexion.ConnectionString = "data source=.\\SQLEXPRESS; initial catalog=TPC_CLINICA_DB; integrated security=sspi";
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.CommandText = "SELECT m.*, e.Descripcion from Medicos m left join EspecialidadesPorMedico epm on Dni = epm.DniMedico left join Especialidades e on epm.IdEspecialidad = e.Id where m.Dni='"+ dni +"'";
                Comando.Connection = Conexion;

                Conexion.Open();
                lector = Comando.ExecuteReader();
                while (lector.Read())
                {

                    aux.Apellido = (string)lector["Apellidos"];
                    aux.Nombre = (string)lector["Nombres"];
                    aux.Dni = (string)lector["Dni"];
                    aux.Sexo = (string)lector["Sexo"];
                    aux.Especialidad = (string)lector["Descripcion"];
                    aux.Direccion = (string)lector["Direccion"];
                    aux.Mail = (string)lector["Email"];
                    aux.Telefono = (string)lector["Telefono"];
                    aux.Localidad = (int)lector["CodigoPostal"];
                    aux.Matricula = (string)lector["Matricula"];
                }

                Conexion.Close();
                return aux;
            }
            catch (Exception ex)
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

        public bool modificar(Profesional nuevo)
        {
            try
            {
                AccesoDatos conexion = new AccesoDatos();

                conexion.SetearConsulta("update Medicos set Dni = @dni, Apellidos = @apellidos, Nombres = @nombres, Sexo = @sexo, CodigoPostal = @cp, Direccion = @direccion, Email = @email,Telefono = @tel, Matricula = @matricula where Dni = @dni ");

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

        public bool eliminar(string dni)
        {
            try
            {
                AccesoDatos conexion = new AccesoDatos();

                conexion.SetearConsulta("DELETE FROM Medicos WHERE Dni='"+ dni +"' ");

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
