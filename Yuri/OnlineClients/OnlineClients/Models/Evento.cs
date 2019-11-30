using System;
using System.Collections.Generic;

namespace OnlineClients.Models
{
    public partial class Evento
    {
        public Evento()
        {
            Reserva = new HashSet<Reserva>();
        }

        public int Idevento { get; set; }
        public int Idsalao { get; set; }
        public string Nome { get; set; }
        public string TipoEvento { get; set; }
        public int? QuantidadePessoas { get; set; }

        public Salao IdsalaoNavigation { get; set; }
        public ICollection<Reserva> Reserva { get; set; }
    }
}
