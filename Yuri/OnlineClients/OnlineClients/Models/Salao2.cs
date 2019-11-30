using System;
using System.Collections.Generic;

namespace OnlineClients.Models
{
    public partial class Salao2
    {
        public Salao2()
        {
            Evento2 = new HashSet<Evento2>();
        }

        public int Idsalao { get; set; }
        public string Nome { get; set; }
        public int? Capacidade { get; set; }

        public ICollection<Evento2> Evento2 { get; set; }
    }
}
