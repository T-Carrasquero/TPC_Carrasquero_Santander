using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class EspecialidadNegocio
    {

        public List<Especialidad> listar()
        {
            List<Especialidad> lista = new List<Especialidad>();

            AccesoDatos Conexion = new AccesoDatos();
            try
            {
                Conexion.SetearConsulta("select * from Especialidades");
                Conexion.EjecutarLectura();

                while (Conexion.Lector.Read())
                {
                    Especialidad aux = new Especialidad();
                    aux.Descripcion = (string)Conexion.Lector["Descripcion"];

                    lista.Add(aux);
                }
                Conexion.CerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool setEspecialidad(int index, string dni)
        {
            AccesoDatos Conexion = new AccesoDatos();

            try
            {
                Conexion.SetearConsulta("insert into EspecialidadesPorMedico (DniMedico,IdEspecialidad) values (@dni,@idEsp)");

                Conexion.agregarParametro("@dni", dni);
                Conexion.agregarParametro("@idEsp", index);

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

        public bool modificarEspecialidad(int index, string dni)
        {
            AccesoDatos Conexion = new AccesoDatos();

            try
            {
                Conexion.SetearConsulta("update EspecialidadesPorMedico set DniMedico=@dni,IdEspecialidad=@idEsp where DniMedico=@dni");

                Conexion.agregarParametro("@dni", dni);
                Conexion.agregarParametro("@idEsp", index);

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

        public bool eliminar(string dni)
        {
            try
            {
                AccesoDatos conexion = new AccesoDatos();

                conexion.SetearConsulta("DELETE FROM EspecialidadesPorMedico WHERE DniMedico='" + dni + "' ");

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
