using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Turnos
    {
        private Profesional medico { get; set; }
        private DateTime fecha { get; set; }
        private Paciente paciente { get; set; }
        private string Estado { get; set; }

        public Turnos()
        {
            fecha = DateTime.Now;
            Estado = string.Empty;
        }
    }
}
