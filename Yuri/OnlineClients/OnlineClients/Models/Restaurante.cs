using System;
using System.Collections.Generic;

namespace OnlineClients.Models
{
    public partial class Restaurante
    {
        public int Idrestaurante { get; set; }
        public int Idmesa { get; set; }
        public int Idcardapio { get; set; }
        public int IdChefCozinha { get; set; }
        public int IdGarcom { get; set; }

        public Pessoa IdChefCozinhaNavigation { get; set; }
        public Pessoa IdGarcomNavigation { get; set; }
        public Cardapio IdcardapioNavigation { get; set; }
        public Mesa IdmesaNavigation { get; set; }
    }
}
