using System;
using System.Collections.Generic;

namespace OnlineClients.Models
{
    public partial class Cardapio
    {
        public Cardapio()
        {
            Restaurante = new HashSet<Restaurante>();
        }

        public int Idcardapio { get; set; }
        public int IditemCardapio { get; set; }

        public ItemCardapio IditemCardapioNavigation { get; set; }
        public ICollection<Restaurante> Restaurante { get; set; }
    }
}
