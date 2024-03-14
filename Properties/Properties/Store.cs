using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    /*internal*/ class Store
    {
        int id;

        public string Name { get; set; }
        public Address Address { get; set; }
        public string Category { get; init; }

        public Store(string name)
        {
            Name = name;   
        }
    }
}
