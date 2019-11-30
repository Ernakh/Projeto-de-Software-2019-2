using System;
using System.Collections.Generic;

namespace OnlineClients.Models
{
    public partial class Reserva
    {
        public int Idreserva { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public float? Valor { get; set; }
        public int IdformaPagamento { get; set; }
        public int Idquarto { get; set; }
        public int Idevento { get; set; }
        public int Idpessoa { get; set; }
        public int IdvagaGaragem { get; set; }

        public Evento IdeventoNavigation { get; set; }
        public FormaPagamento IdformaPagamentoNavigation { get; set; }
        public Pessoa IdpessoaNavigation { get; set; }
        public Quarto IdquartoNavigation { get; set; }
        public VagaGaragem IdvagaGaragemNavigation { get; set; }
    }
}
