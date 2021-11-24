using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Dni { get; set; }
        public string TipoUsuario { get; set; }

        public Usuario()
        {
            Username = string.Empty;
            Password = string.Empty;
            Dni = string.Empty;
            TipoUsuario = string.Empty;
        }
    }

    
}
