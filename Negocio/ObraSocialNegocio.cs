using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class ObraSocialNegocio
    {
        public List<ObraSocial> listar()
        {
            List<ObraSocial> lista = new List<ObraSocial>();
            SqlConnection Conexion = new SqlConnection();
            SqlCommand Comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                Conexion.ConnectionString = "data source=.\\SQLEXPRESS; initial catalog=TPC_CLINICA_DB; integrated security=sspi";
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.CommandText = "select * from ObraSocial where Estado=1";
                Comando.Connection = Conexion;

                Conexion.Open();
                lector = Comando.ExecuteReader();

                while (lector.Read())
                {
                    ObraSocial aux = new ObraSocial();

                    aux.Rnos = (string)lector["Rnos"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Sigla = (string)lector["Sigla"];
                    aux.Domicilio = (string)lector["Domicilio"];
                    aux.Email = (string)lector["Email"];
                    //aux.Localidad = (int)lector["CodigoPostal"] + " - " + (string)lector["Nombre"] " - " + (string)lector["Provincia"];
                    aux.CodigoPostal = (int)lector["CodigoPostal"];
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

        public ObraSocial buscarObraSocial(string rnos)
        {
            ObraSocial aux = new ObraSocial();
            SqlConnection Conexion = new SqlConnection();
            SqlCommand Comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                Conexion.ConnectionString = "data source=.\\SQLEXPRESS; initial catalog=TPC_CLINICA_DB; integrated security=sspi";
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.CommandText = "select Rnos, Nombre, Sigla, Domicilio, CodigoPostal, Email from ObraSocial where Rnos =" + rnos;
                Comando.Connection = Conexion;

                Conexion.Open();
                lector = Comando.ExecuteReader();
                while (lector.Read())
                {

                    aux.Rnos = (string)lector["Rnos"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Sigla = (string)lector["Sigla"];
                    aux.Domicilio = (string)lector["Domicilio"];
                    aux.CodigoPostal = (int)lector["CodigoPostal"];
                    aux.Email = (string)lector["Email"];
                }

                Conexion.Close();
                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool crear(ObraSocial nuevo)
        {
            try
            {
                AccesoDatos conexion = new AccesoDatos();

                conexion.SetearConsulta("insert into ObraSocial(Rnos, Nombre, Sigla, Domicilio, CodigoPostal, Email) values (@rnos,@nombres,@sigla,@domicilio,@cp,@email) ");

                conexion.agregarParametro("@rnos", nuevo.Rnos);
                conexion.agregarParametro("@nombre", nuevo.Nombre);
                conexion.agregarParametro("@sigla", nuevo.Sigla);
                conexion.agregarParametro("@domicilio", nuevo.Domicilio);
                conexion.agregarParametro("@cp", nuevo.CodigoPostal);
                conexion.agregarParametro("@email", nuevo.Email);

                conexion.ejecutarAccion();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool modificar(ObraSocial nuevo)
        {
            try
            {
                AccesoDatos conexion = new AccesoDatos();

                conexion.SetearConsulta("update ObraSocial set Rnos = @rnos, Nombres = @nombre, Sigla = @sigla, Domicilio = @domicilio, CodigoPostal = @cp, Email = @email where Rnos = @rnos ");

                conexion.agregarParametro("@rnos", nuevo.Rnos);
                conexion.agregarParametro("@nombre", nuevo.Nombre);
                conexion.agregarParametro("@sigla", nuevo.Sigla);
                conexion.agregarParametro("@domicilio", nuevo.Domicilio);
                conexion.agregarParametro("@cp", nuevo.CodigoPostal);
                conexion.agregarParametro("@email", nuevo.Email);

                conexion.ejecutarAccion();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Baja(string rnos)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                conexion.SetearConsulta("update ObraSocial set estado=0 where Rnos=@rnos");
                conexion.agregarParametro("@rnos", rnos);
                conexion.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
