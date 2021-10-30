using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Turnos
    {
        private Profesional medico { get; set; }
        private DateTime fecha { get; set; }
        private Paciente paciente { get; set; }
        private string estado { get; set; }

        public Turnos()
        {
            fecha = DateTime.Now;
            estado = string.Empty;
        }
    }
}
