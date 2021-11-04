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
                Comando.CommandText = "Select Dni, Nombres, Apellidos, Sexo, Direccion, Email, Telefono, Matricula from Medicos";
                Comando.Connection = Conexion;

                Conexion.Open();
                lector = Comando.ExecuteReader();

                while (lector.Read())
                {
                    Profesional aux = new Profesional();
                    aux.Apellido = (string)lector["Apellidos"];
                    aux.Nombre = (string)lector["Nombres"];
                    aux.Dni = (int)lector["Dni"];
                    aux.Sexo = (string)lector["Sexo"];
                    aux.Direccion = (string)lector["Direccion"];
                    aux.Mail = (string)lector["Email"];
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
    }
}
