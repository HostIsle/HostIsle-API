using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie1.Models
{
    public class Town
    {
        public Town(string name,string postalCode)
        {
            this.Name = name;
            this.PostalCode = postalCode;
            this.Addresses = new HashSet<Address>();

        }
        public Town()
        {
            this.Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string PostalCode { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

    }
}
