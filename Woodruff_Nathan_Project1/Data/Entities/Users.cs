using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Users
    {
        public Users()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
