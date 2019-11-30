using System;
using System.Collections.Generic;

namespace OnlineClients.Models
{
    public partial class Usuarios2
    {
        public int IdUser { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public byte Adm { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
    }
}
