using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> listar()
        {
            List<Usuario> lista = new List<Usuario>();
            SqlConnection Conexion = new SqlConnection();
            SqlCommand Comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                Conexion.ConnectionString = "data source=.\\SQLEXPRESS; initial catalog=TPC_CLINICA_DB; integrated security=sspi";
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.CommandText = "select u.*, tu.Descripcion from Usuarios u left join Usuarios_tipos tu on u.IdTipoUsuario = tu.Id where u.Estado=1";
                Comando.Connection = Conexion;

                Conexion.Open();
                lector = Comando.ExecuteReader();

                while (lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Username = (string)lector["Nombre"];
                    aux.Password = (string)lector["Contraseña"];
                    aux.Dni = (string)lector["dniPaciente"];
                    aux.TipoUsuario = (string)lector["Descripcion"];
                   
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

        public Usuario buscarUsuario(string username)
        {
            Usuario aux = new Usuario();
            AccesoDatos Conexion = new AccesoDatos();

            try
            {

                Conexion.SetearConsulta("select u.*, tu.Descripcion from Usuarios u left join Usuarios_tipo tu on u.IdTipoUsuario = tu.Id where u.Estado=1 and u.Nombre = '"+ username +"' ");
                
                while (Conexion.Lector.Read())
                {

                    aux.Username = (string)Conexion.Lector["Nombre"];
                    aux.Password = (string)Conexion.Lector["Contrseña"];
                    aux.Dni = (string)Conexion.Lector["Dni"];
                    aux.TipoUsuario = (string)Conexion.Lector["Descripcion"];
                }

                Conexion.cerrarConexion();
                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       /* public bool crear(Usuario nuevo)
        {
            AccesoDatos Conexion = new AccesoDatos();

            try
            {
                Conexion.SetearConsulta("");

            }
            catch (Exception)
            {

                throw;
            }

        }*/

        public bool modificarContraseña(string password, string username)
        {
            AccesoDatos Conexion = new AccesoDatos();

            try
            {
                Conexion.SetearConsulta("update Usuario set Contraseña=@password where Nombre=@username");

                Conexion.agregarParametro("@username", username);
                Conexion.agregarParametro("@password", password);

                Conexion.ejecutarAccion();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Conexion.cerrarConexion();
            }
        }

        public bool eliminar(string username)
        {
            try
            {
                AccesoDatos conexion = new AccesoDatos();

                conexion.SetearConsulta("Update Usuarios set Estado=0 where Nombre='" + username + "' ");

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
