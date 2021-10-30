using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    class Profesional
    {
        private int dni { get; set; }
        private string nombre { get; set; }
        private string apellido { get; set; }
        private string sexo { get; set; }
        private Especialidad especialidad { get; set; }
        private Localidad localidad { get; set; }
        private string direccion { get; set; }
        private string mail { get; set; }
        private string telefono { get; set; }
        private string matricula { get; set; }

        public Profesional()
        {
            nombre = string.Empty;
            apellido = string.Empty;
            sexo = string.Empty;
            direccion = string.Empty;
            mail = string.Empty;
            telefono = string.Empty;
            matricula = string.Empty;
        }

    }

}
