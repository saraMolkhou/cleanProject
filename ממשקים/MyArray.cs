using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class MyArray
    {
        private object[] array;
        private int lenght;
        private int count;


        public MyArray(int l)
        {
            lenght = l;
            count = 0;
            array= new object[lenght];
        }

        public void AddToArray(object obj)
        {
            if(count<lenght)
                array[count++] = obj;
            else
                Console.WriteLine("there is no more place in array");      
        }



    }
}
