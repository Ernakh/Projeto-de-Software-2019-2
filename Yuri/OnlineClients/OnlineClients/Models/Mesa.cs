using System;
using System.Collections.Generic;

namespace OnlineClients.Models
{
    public partial class Mesa
    {
        public Mesa()
        {
            Pedido = new HashSet<Pedido>();
            Restaurante = new HashSet<Restaurante>();
        }

        public int Idmesa { get; set; }
        public int? Numeromesa { get; set; }
        public int? Capacidade { get; set; }

        public ICollection<Pedido> Pedido { get; set; }
        public ICollection<Restaurante> Restaurante { get; set; }
    }
}
