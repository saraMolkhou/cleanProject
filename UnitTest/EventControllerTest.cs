using EventsProject;
using EventsProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class EventControllerTest
    {
        private readonly EventController _controller;
        public EventControllerTest()
        {
            FakeContext context = new FakeContext();
            _controller = new EventController(context);
        }
        [Fact]
        public void getAll_Ok()
        {
            //AAA
            //ARRANGE - נתונים שרוצים לשלוח לאשקין (הפונקציות שרשמנו שקונטרולר)

            //ACT - הפעלת האקשין בעצמו

            var result = _controller.Get();

            //ASSERT - הכררזה מה אני מצפה לקקבל מהפונקציה

            Assert.IsType<List<Event>>(result);
        }

        [Fact]
        public void getById_ReturnOk()
        {
            //AAA
            //ARRANGE - נתונים שרוצים לשלוח לאשקין (הפונקציות שרשמנו שקונטרולר)

            var id = 2;

            //ACT - הפעלת האקשין בעצמו

            
            var result = _controller.Get(id);

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

            
            var result = _controller.Get(id);

            //ASSERT - הכררזה מה אני מצפה לקקבל מהפונקציה

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
