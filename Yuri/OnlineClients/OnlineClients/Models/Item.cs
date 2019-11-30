using System;
using System.Collections.Generic;

namespace OnlineClients.Models
{
    public partial class Item
    {
        public Item()
        {
            Frigobar = new HashSet<Frigobar>();
        }

        public int Iditem { get; set; }
        public string Nome { get; set; }
        public float? Preco { get; set; }
        public int? Quantidade { get; set; }

        public ICollection<Frigobar> Frigobar { get; set; }
    }
}
