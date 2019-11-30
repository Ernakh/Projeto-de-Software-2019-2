using System;
using System.Collections.Generic;

namespace OnlineClients.Models
{
    public partial class Pedido
    {
        public int Idpedido { get; set; }
        public int Idmesa { get; set; }
        public float? Valor { get; set; }
        public int Idpessoa { get; set; }

        public Mesa IdmesaNavigation { get; set; }
        public Pessoa IdpessoaNavigation { get; set; }
    }
}
