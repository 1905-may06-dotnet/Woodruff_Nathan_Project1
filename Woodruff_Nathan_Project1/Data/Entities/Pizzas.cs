using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Pizzas
    {
        public Pizzas()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Size { get; set; }
        public string Crust { get; set; }
        public string Type { get; set; }
        public decimal? Cost { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
