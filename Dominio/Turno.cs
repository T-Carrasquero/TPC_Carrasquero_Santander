using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Turno
    {
        public string dniPaciente { get; set; }
        public int id { get; set; }
        public string Especialidad { get; set; }
        public string Medico { get; set; }
        public DateTime Fecha { get; set; }
        public float Hora { get; set; }
        public string Paciente { get; set; }
        public string Estado { get; set; }
        public string Informe { get; set; }
        public string Indicaciones { get; set; }


        public Turno()
        {
            dniPaciente = string.Empty;
            Especialidad = string.Empty;
            Medico = string.Empty;
            Paciente = string.Empty;
            Fecha =   DateTime.Now;
            Estado = string.Empty;
            Indicaciones = string.Empty;
            Informe = string.Empty;

        }
    }
}
