using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Paciente
    {
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string sexo { get; set; }
        public Localidad localidad { get; set; }
        public string direccion { get; set; }
        public string mail { get; set; }
        public string telefono { get; set; }

        public Paciente()
        {
            nombre = string.Empty;
            apellido = string.Empty;
            sexo = string.Empty;
            direccion = string.Empty;
            mail = string.Empty;
            telefono = string.Empty;
        }
    }
}
