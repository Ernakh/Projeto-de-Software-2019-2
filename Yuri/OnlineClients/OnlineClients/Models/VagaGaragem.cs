using System;
using System.Collections.Generic;

namespace OnlineClients.Models
{
    public partial class VagaGaragem
    {
        public VagaGaragem()
        {
            Garagem = new HashSet<Garagem>();
            Reserva = new HashSet<Reserva>();
        }

        public int IdvagaGaragem { get; set; }
        public int? Andar { get; set; }
        public int? Numero { get; set; }
        public float? Valor { get; set; }
        public byte? Disponivel { get; set; }

        public ICollection<Garagem> Garagem { get; set; }
        public ICollection<Reserva> Reserva { get; set; }
    }
}
