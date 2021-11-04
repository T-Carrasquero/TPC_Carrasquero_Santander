using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Profesional
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public string Especialidad { get; set; }
        public Localidad Localidad { get; set; }
        public string Direccion { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public string Matricula { get; set; }

        public Profesional()
        {
            Dni = string.Empty;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Sexo = string.Empty;
            Especialidad = string.Empty;
            Direccion = string.Empty;
            Mail = string.Empty;
            Telefono = string.Empty;
            Matricula = string.Empty;
        }

    }

}
