using EventsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class FakeContext : IDataContext
    {
        public List<Event> events {  get; set; }
        public FakeContext()
        {
            events = new List<Event> 
            {
                  new Event{  id = 1, title = "wedding", start = new DateTime(), end = new DateTime() }
            };
        }
       
    }
}
