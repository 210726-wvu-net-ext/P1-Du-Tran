using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApp.Domain
{
    public class Restaurant
    {
        public Restaurant() { }

        public Restaurant(string name, string zipcode)
        {
            this.Name = name;
            this.Zipcode = zipcode;
        }

        public Restaurant(int id, string name, string location, string contact, string zipcode) : this(name, zipcode)
        {
            this.Id = id;
            this.Location = location;
            this.Contact = contact;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string Zipcode { get; set; }
    }
}
