﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Turno
    {
        public string Medico { get; set; }
        public DateTime Fecha { get; set; }
        public float Hora { get; set; }
        public string Paciente { get; set; }
        public string Estado { get; set; }

        public Turno()
        {
            Medico = string.Empty;
            Paciente = string.Empty;
            Fecha =   DateTime.Now;
            Estado = string.Empty;
        }
    }
}
