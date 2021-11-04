using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Localidad
    {
        public int codigoPostal { get; set; }
        public string nombre { get; set; }
        public string provincia { get; set; }
        public string pais { get; set; }

        public Localidad()
        {
            nombre = string.Empty;
            provincia = string.Empty;
            pais = string.Empty;
        }

    }
}
