namespace Properties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            ////object initializer////
            Store t = new("Pinat") {Category="חטיפים ומתוקים",Address=new Address() {Street="ChazonIsh",City="BB" } };
            
            //t.Category = "ממתקים"; //init only field
            

        }
    }
}