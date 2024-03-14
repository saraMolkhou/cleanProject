using basicAPI;
using basicAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventsUnitTests
{
    public class eventsControllerTest
    {
        [Fact]
        public void getAll_Ok()
        {
            //AAA
            //ARRANGE - נתונים שרוצים לשלוח לאשקין (הפונקציות שרשמנו שקונטרולר)

            //ACT - הפעלת האקשין בעצמו

            var eventcontroller = new EventsController();
            var result = eventcontroller.Get();

            //ASSERT - הכררזה מה אני מצפה לקקבל מהפונקציה

            Assert.IsType<List<Event>>(result);
        }

        [Fact]
        public void getById_ReturnOk()
        {
            //AAA
            //ARRANGE - נתונים שרוצים לשלוח לאשקין (הפונקציות שרשמנו שקונטרולר)

            var id = 1;

            //ACT - הפעלת האקשין בעצמו

            var eventcontroller = new EventsController();
            var result = eventcontroller.Get(id);

            //ASSERT - הכררזה מה אני מצפה לקקבל מהפונקציה

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void getById_ReturnNotFound()
        {
            //AAA
            //ARRANGE - נתונים שרוצים לשלוח לאשקין (הפונקציות שרשמנו שקונטרולר)

            var id = 10;

            //ACT - הפעלת האקשין בעצמו

            var eventcontroller = new EventsController();
            var result = eventcontroller.Get(id);

            //ASSERT - הכררזה מה אני מצפה לקקבל מהפונקציה

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
