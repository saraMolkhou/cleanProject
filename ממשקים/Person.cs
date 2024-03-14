using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Person
    {
        public string Name { get; set; }
        public string Tel { get; set; }
        public DateTime BornDate { get; set; }

      public Person(string name, string tel, DateTime bornDate)
        {
            Name = name;
            Tel = tel;
            BornDate = bornDate;
        }

        public override string ToString()
        { 
            string st = "";
        st += this.Name + " " + this.Tel + " " + this.BornDate.ToShortDateString();
          
            return st;
        }
      
    }
}
