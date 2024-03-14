namespace genericsFunctions
{
    public interface ISortable
    {
        void Sort();
    }
    public class genericArray<T> where T : ISortable
    {
        private int maxdata;
        private List<T> data;
        public genericArray(int maxData = 100)
        {
            this.maxdata = maxData;
            this.data = new List<T>();
        }
        public bool addDataToArray(T item)
        {
            if (data.Count < maxdata)
            {
                data.Add(item);
                return true;
            }

            else
                return false;
        }
        // מקבל מערך והפרמס מאפשר כמות שונה של ערכים ובודק אם כמות הנתונים במערך כעט ועוד גודל המערך הנתון
        // קטן מהכמות המקסימלית שניתן להכניס אז אפשר להכניס את נתוני המערך
        public bool AddListAndSingle(params T[] array)
        {
            if (data.Count + array.Length < maxdata)
            {
                data.AddRange(array);
                return true;
            }
            return false;
        }
        public T[] sortedArray()
        {
            T[] newArray = data.ToArray();
            Array.Sort(newArray);
            return newArray;
        }

    }
    class Flower
    {
        private String Type { get; set; }
        private String Name { get; set; }
        public Flower(String type, String name)
        {
            this.Type = type;
            this.Name = name;
        }
    }
    class program
    {
        static void Main()
        {
            genericArray<Flower> array = new genericArray<Flower>();
            Flower rose = new Flower("flower", "rose");
            array.addDataToArray(rose);
            foreach (var flower in array)
            {
                Console.WriteLine(flower.Name);
            }
        }
    }
    public interface Iprintable
    {
        void Print();
    }
    public class Fruit : Iprintable
    {
        private String Name { get; set; }
        private string Color { get; set; }
        public Fruit(string name, string color)
        {
            Name = name;
            Color = color;
        }
        public void Print()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Color);
        }

    }
    class print
    {
        public static void printObject<T>(T obj)
        {
            Console.WriteLine($"********{obj}*******");
        }
    }
    public class newGeneric<T1, T2, T3>
    {
        private T1 obj1;
        private T2 obj2;
        private T3 obj3;
        public newGeneric(T1 obj1, T2 obj2, T3 obj3)
        {
            this.obj1 = obj1;
            this.obj2 = obj2;
            this.obj3 = obj3;
        }
        public string returnstring()
        {
            return $"{obj1.ToString()}{obj2.ToString()}{obj3.ToString()}";


        }
    }
}



