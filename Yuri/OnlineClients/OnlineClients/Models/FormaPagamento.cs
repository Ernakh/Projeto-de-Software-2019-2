using System;
using System.Collections.Generic;

namespace OnlineClients.Models
{
    public partial class FormaPagamento
    {
        public FormaPagamento()
        {
            Reserva = new HashSet<Reserva>();
        }

        public int IdformaPagamento { get; set; }
        public string Titulo { get; set; }

        public ICollection<Reserva> Reserva { get; set; }
    }
}
