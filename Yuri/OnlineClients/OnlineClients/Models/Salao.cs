using System;
using System.Collections.Generic;

namespace OnlineClients.Models
{
    public partial class Salao
    {
        public Salao()
        {
            Evento = new HashSet<Evento>();
        }

        public int Idsalao { get; set; }
        public string Nome { get; set; }
        public int Capacidade { get; set; }

        public ICollection<Evento> Evento { get; set; }
    }
}
