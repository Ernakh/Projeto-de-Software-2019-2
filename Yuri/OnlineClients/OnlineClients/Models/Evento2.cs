using System;
using System.Collections.Generic;

namespace OnlineClients.Models
{
    public partial class Evento2
    {
        public int Idevento { get; set; }
        public string Nome { get; set; }
        public string TipoEvento { get; set; }
        public int? QuantidadePessoas { get; set; }
        public int? Idsalao { get; set; }

        public Salao2 IdsalaoNavigation { get; set; }
    }
}
