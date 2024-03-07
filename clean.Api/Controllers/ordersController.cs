using AutoMapper;
using clean.Api.model;
using clean.core;
using clean.core.DTOs;
using clean.core.Entities;
using clean.services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clean.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ordersController : ControllerBase
    {
        private readonly orderServies _orderServies;
        private readonly IMapper _mapper;
        public ordersController(orderServies oS, IMapper mapper)
        {
            _orderServies = oS;
            _mapper = mapper;
        }
        // GET: api/<ordersController>
        [HttpGet]
        public ActionResult<order> Get()
        {
            var list = _orderServies.GetAll();
            var listDto = _mapper.Map<IEnumerable<orderDTO>>(list);
            
            return Ok(listDto);
        }

        // GET api/<ordersController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var resOrd = _orderServies.GetOrderById(id);
            var ordDto = _mapper.Map<orderDTO>(resOrd);
            return Ok(ordDto);
        }

        // POST api/<ordersController>
        [HttpPost]
        public void Post([FromBody] orderPostModel value)
        {
            var newOrder = new order { orderNum = value.orderNum, orderSum = value.orderSum, orderDate = value.orderDate, customerId = value.customerId };
            _orderServies.AddOrder(newOrder);
        }

        // PUT api/<ordersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] order value)
        {
            _orderServies.UpdateOrder(value, id);
        }
    }
}
