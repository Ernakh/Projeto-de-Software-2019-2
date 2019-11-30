using System;
using System.Collections.Generic;

namespace OnlineClients.Models
{
    public partial class Quarto
    {
        public Quarto()
        {
            Reserva = new HashSet<Reserva>();
        }

        public int Idquarto { get; set; }
        public int Idfrigobar { get; set; }
        public int? Numero { get; set; }
        public int? Andar { get; set; }
        public int? QuantidadeCamas { get; set; }
        public string TipoCama { get; set; }
        public string Categoria { get; set; }
        public byte? Luxo { get; set; }

        public Frigobar IdfrigobarNavigation { get; set; }
        public ICollection<Reserva> Reserva { get; set; }
    }
}
