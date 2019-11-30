using System;
using System.Collections.Generic;

namespace OnlineClients.Models
{
    public partial class ItemCardapio
    {
        public ItemCardapio()
        {
            Cardapio = new HashSet<Cardapio>();
        }

        public int IditemCardapio { get; set; }
        public string Comida { get; set; }
        public float? Preco { get; set; }
        public float? TempoEspera { get; set; }
        public string Descricao { get; set; }
        public float? Calorias { get; set; }

        public ICollection<Cardapio> Cardapio { get; set; }
    }
}
