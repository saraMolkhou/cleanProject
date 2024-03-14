using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyArray m = new MyArray(30);
            m.AddToArray(new Employee(35, DateTime.Today, 40, "moshe", "0548484848", new DateTime(01 / 01 / 1999)));
        }
    }
}