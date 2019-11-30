using System;
using System.Collections.Generic;

namespace OnlineClients.Models
{
    public partial class Garagem
    {
        public int Idgaragem { get; set; }
        public int IdvagaGaragem { get; set; }
        public int Idgaragista { get; set; }

        public Pessoa IdgaragistaNavigation { get; set; }
        public VagaGaragem IdvagaGaragemNavigation { get; set; }
    }
}
