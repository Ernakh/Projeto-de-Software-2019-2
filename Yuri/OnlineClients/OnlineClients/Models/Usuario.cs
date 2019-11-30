using System;
using System.Collections.Generic;

namespace OnlineClients.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Pessoa = new HashSet<Pessoa>();
        }

        public int Idusuario { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public byte? TipoUsuario { get; set; }

        public ICollection<Pessoa> Pessoa { get; set; }
    }
}
