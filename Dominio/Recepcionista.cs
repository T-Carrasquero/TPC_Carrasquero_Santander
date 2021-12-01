using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Recepcionista
    {
        public int Legajo { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public int Localidad { get; set; }
        public string Direccion { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }

        public Recepcionista()
        {
            Nombre = string.Empty;
            Apellido = string.Empty;
            Sexo = string.Empty;
            //Localidad = string.Empty;
            Direccion = string.Empty;
            Mail = string.Empty;
            Telefono = string.Empty;
        }
    }
}
