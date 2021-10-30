using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Usuario
    {
        private string username { get; set; }
        private string password { get; set; }

        public Usuario()
        {
            username = string.Empty;
            password = string.Empty;
        }
    }

    
}
