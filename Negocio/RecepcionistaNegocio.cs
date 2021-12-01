using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class RecepcionistaNegocio
    {
        public List<Recepcionista> listar()
        {
            List<Recepcionista> lista = new List<Recepcionista>();
            SqlConnection Conexion = new SqlConnection();
            SqlCommand Comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                Conexion.ConnectionString = "data source=.\\SQLEXPRESS; initial catalog=TPC_CLINICA_DB; integrated security=sspi";
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.CommandText = "select R.*, L.Nombre, L.Provincia from Recepcionistas R left join Localidades L on R.CodigoPostal = L.CodigoPostal where Estado=1";
                Comando.Connection = Conexion;

                Conexion.Open();
                lector = Comando.ExecuteReader();

                while (lector.Read())
                {
                    Recepcionista aux = new Recepcionista();
                    //aux.Legajo = (int)lector["Legajo"];
                    aux.Apellido = (string)lector["Apellidos"];
                    aux.Nombre = (string)lector["Nombres"];
                    aux.Dni = (string)lector["Dni"];
                    aux.Direccion = (string)lector["Direccion"];
                    aux.Mail = (string)lector["Email"];
                    //aux.Localidad = (int)lector["CodigoPostal"] + " - " + (string)lector["Nombre"] " - " + (string)lector["Provincia"];
                    aux.Localidad = (int)lector["CodigoPostal"];
                    aux.Telefono = (string)lector["Telefono"];
                    aux.Sexo = (string)lector["Sexo"];
                    aux.Estado = (bool)lector["Estado"];
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

        public Recepcionista buscarRecepcionista(string dni)
        {
            Recepcionista aux = new Recepcionista();
            SqlConnection Conexion = new SqlConnection();
            SqlCommand Comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                Conexion.ConnectionString = "data source=.\\SQLEXPRESS; initial catalog=TPC_CLINICA_DB; integrated security=sspi";
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.CommandText = "select Dni, Apellidos, Nombres, Sexo, CodigoPostal, Direccion, Email, Telefono, Estado from Recepcionistas where Dni = '@Dni'";
                Comando.Connection = Conexion;
                Comando.CommandText = Comando.CommandText.Replace("@Dni", dni);

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

        public bool crear(Recepcionista nuevo)
        {
            try
            {
                AccesoDatos conexion = new AccesoDatos();

                conexion.SetearConsulta("insert into Recepcionistas(Dni,Apellidos,Nombres,Sexo,CodigoPostal,Direccion,Email,Telefono) values (@dni,@apellidos,@nombres,@sexo,@cp,@direccion,@mail,@telefono) ");

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
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool modificar(Recepcionista nuevo)
        {
            try
            {
                AccesoDatos conexion = new AccesoDatos();

                conexion.SetearConsulta("update Recepcionistas set Dni = @dni, Apellidos = @apellidos, Nombres = @nombres, Sexo = @sexo, CodigoPostal = @cp, Direccion = @direccion, Email = @email,Telefono = @telefono where Dni = @dni ");

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
                conexion.SetearConsulta("update Recepcionistas set estado=0 where Dni=@dni");
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
