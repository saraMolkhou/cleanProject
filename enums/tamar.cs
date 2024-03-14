using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enumHW
{
    [Flags]
    public enum seasons : byte
    {
        summer = 1,
        winter = 2,
        Autumn = 4,
        Spring = 8
    }



}


namespace enumHW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            seasons s = seasons.Spring;
            seasons w = seasons.winter;
            seasons x = w;
            Console.WriteLine(s + " " + w + " " + x);
            w = seasons.Autumn;
            Console.WriteLine(s + " " + w + " " + x);
            Date d = new Date() { wd = Date.weekDays.Tuesday | Date.weekDays.Sunday };
            Console.WriteLine(d.wd);

            //8
            Console.WriteLine("insert day for shift");
            Shift myShift = new Shift(int.Parse(Console.ReadLine()));
            Console.WriteLine(myShift.day);
            //9
            Console.WriteLine("insert day for shift");
            int dd = int.Parse(Console.ReadLine());
            if (Enum.IsDefined(typeof(Date.weekDays), (Date.weekDays)dd))
            {
                Shift newSift = new Shift(dd);
                Console.WriteLine(newSift.day);
            }



        }

        internal class Date
        {
            public weekDays wd;

            [Flags]
            public enum weekDays : byte
            {
                Sunday = 1,
                Monday = 2,
                Tuesday = 4,
                Wednesda = 8,
                Thursday = 16

            }
        }
        internal class Shift
        {
            public Date.weekDays day;

            public Shift(int shiftD)
            {
                day = (Date.weekDays)shiftD;
            }
        }

    }
}
