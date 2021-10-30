using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Localidad
    {
        private int codigoPostal { get; set; }
        private string nombre { get; set; }
        private string provincia { get; set; }
        private string pais { get; set; }

        public Localidad()
        {
            nombre = string.Empty;
            provincia = string.Empty;
            pais = string.Empty;
        }

    }
}
