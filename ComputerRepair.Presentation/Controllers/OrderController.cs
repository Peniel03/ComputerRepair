using AutoMapper;
using ComputerRepair.BusinessLogic.Dto;
using ComputerRepair.BusinessLogic.Interfaces;
using ComputerRepair.DataAccess.Interfaces;
using ComputerRepair.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ComputerRepair.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService,
                               IOrderRepository orderRepository, IMapper mapper)
        {
            _orderService = orderService;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        //
        [HttpGet("{OrderName}")]
        public ActionResult<OrderReadDto> Get(string OrderName)
        {
            var order = _orderService.GetOrderByNameAsync(OrderName);
            // Destination --> Source
            var orderReadDto = _mapper.Map<OrderReadDto>(order);
            return Ok(orderReadDto);
        }
        //à implemener dans tous les controllers
        [HttpPost]
        public async Task<IActionResult> Add(Order order)
        {
           await _orderService.AddAsync(order);

            return Ok();
        }
        //-----n'oublie pas .
        //
        [HttpPost]
        public ActionResult<OrderCreateDto> Post(OrderCreateDto orders)
        {
            //Map CreatedDto to Order
            var CreatedOrder = _mapper.Map<Order>(orders);

            //Create Order
            var createdOrderService = _orderService.AddAsync(CreatedOrder);

            //Map order to Read Dto
            var orderCreateDto = _mapper.Map<OrderCreateDto>(createdOrderService);

            return Ok(CreatedOrder);
        }

        //---

        [HttpPut]
        public ActionResult<OrderCreateDto> Update(OrderCreateDto order)
        {
            var ordertoUpdateDto = _mapper.Map<Order>(order);

            var _order = _orderService.UpdateAsync(ordertoUpdateDto);

            var userCreateDto = _mapper.Map<OrderCreateDto>(_order);

            return Ok(_order);
        }

        //-----

        [HttpDelete]
        public IActionResult Delete(Order order)
        {
            _orderService.DeleteAsync(order);
            return Ok("Order deleted");
        }
        //----
 



    }
}
