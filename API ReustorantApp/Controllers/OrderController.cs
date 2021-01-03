using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Data;
using DataLibrary.Models;

namespace API_ReustorantApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IFoodData _foodData;
        private readonly IOrderData _orderData;

        public OrderController(IFoodData foodData, IOrderData orderData)
        {
            _foodData = foodData;
            _orderData = orderData;
        }

        [HttpPost]
        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(OrderModel order)
        {
            var food = await _foodData.GetFood();

            order.Total = order.Quantity * food.Where(x => x.Id == order.Id).First().Price;

            int id = await _orderData.CreateOrder(order);

            return Ok(id);
        }
    }
}
