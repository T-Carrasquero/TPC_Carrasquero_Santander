using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Paciente
    {
        private int dni { get; set; }
        private string nombre { get; set; }
        private string apellido { get; set; }
        private string sexo { get; set; }
        private Localidad localidad { get; set; }
        private string direccion { get; set; }
        private string mail { get; set; }
        private string telefono { get; set; }

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
