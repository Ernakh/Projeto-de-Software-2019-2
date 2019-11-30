using System;
using System.Collections.Generic;

namespace OnlineClients.Models
{
    public partial class Frigobar
    {
        public Frigobar()
        {
            Quarto = new HashSet<Quarto>();
        }

        public int Idfrigobar { get; set; }
        public int Iditem { get; set; }

        public Item IditemNavigation { get; set; }
        public ICollection<Quarto> Quarto { get; set; }
    }
}
