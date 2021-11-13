using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Dominio
{
    public class AccesoDatos
    {
        private SqlConnection Conexion { get; set; }
        private SqlCommand Comando { get; set; }
        private SqlDataReader lector { get; set; }

        public AccesoDatos()
        {
            Conexion = new SqlConnection("data source=.\\SQLEXPRESS; initial catalog=TPC_CLINICA_DB2; integrated security=sspi");
            Comando = new SqlCommand();
        }

        public void AbrirConexion()
        {
            Conexion.Open();
        }
        public void SetearConsulta(string consulta)
        {
            Comando.CommandType = System.Data.CommandType.Text;
            Comando.CommandText = consulta;
        }

        public void EjecutarLectura()
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            lector = Comando.ExecuteReader();

        }

        public void CerrarConexion()
        {
            if (lector != null)
                lector.Close();
            Conexion.Close();
        }

        public SqlDataReader Lector
        {
            get { return lector; }
        }
       
        public void agregarParametro(string nombre, object valor)
        {
            Comando.Parameters.AddWithValue(nombre, valor);
        }

        internal void ejecutarAccion()
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.ExecuteNonQuery();
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            Conexion.Close();
        }
    }
}
