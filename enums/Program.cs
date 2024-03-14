namespace enums
{
    internal class Program
    {
        [Flags]
        enum Seasons
        {
            Summer,
            Fall,
            Winter,
            Spring
        }
        class Date
        {
            
            [Flags]
            public enum WeekD
            {
                sun = 1,
                mon = 2,
                tus = 4,
                wen = 8,
                thu = 16,
                fri = 32
            }
            public WeekD Day;
        }
        
        class Shift
        {

            public Date.WeekD Day { get; set; }
            public Shift(int num)
            {
                Day = (Date.WeekD)num;
            }
            public string ShiftString(string dayName)
            {
                return dayName;
            }
        }
        static void Main(string[] args)
        {
            Seasons season = Seasons.Fall;
            Seasons another = Seasons.Spring;
            Seasons same = another;
            Console.WriteLine(season);
            Console.WriteLine(another);
            Console.WriteLine(same);
            another = Seasons.Winter;
            Console.WriteLine(same + "third");
            Console.WriteLine(another + "second");
            if ((int)same == (int)another)
            {
                Console.WriteLine("equals");
            }
            else { Console.WriteLine("diffrent"); }
            Console.WriteLine("enter a number");
            byte value = byte.Parse(Console.ReadLine());
            Shift shift1= new Shift(value);
            Console.WriteLine("enter a day");
            string dayFromUser=Console.ReadLine();
            Shift shift2;
            shift2.ShiftString(dayFromUser);
            Shift shift3 = new Shift(Date.WeekD.sun , Date.WeekD.mon );
            for (int i = 0; i < int.MaxValue; i++)
            {
                if (Enum.IsDefined(typeof(Date.WeekD), i))
                    Console.WriteLine((Date.WeekD)i);
            }
            foreach (Date.WeekD tres in Enum.GetValues(typeof(Date.WeekD)))
            {
                Console.WriteLine(tres);
            }
           
        }
    }
}


