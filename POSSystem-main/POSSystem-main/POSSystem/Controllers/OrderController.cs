using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POSSystem.Application.Features.Commands;
using POSSystem.Application.Features.Queries;

namespace POSSystem.API.Controllers
{
    
    [Authorize(Roles = "Admin, Cashier")]
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddOrder([FromBody] AddOrderCommand command, CancellationToken cancellationToken)
        {
            var added = await _mediator.Send(command, cancellationToken);
            if (added)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPatch("updateStatus/{id}")]
        public async Task<IActionResult> UpdateOrderStatus(int id, [FromBody] UpdateOrderStatusCommand command, CancellationToken cancellationToken)
        {
            command.Id = id;
            var updated = await _mediator.Send(command, cancellationToken);
            if (updated)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllOrders(GetAllOrdersQuery getAllOrdersQuery, CancellationToken cancellationToken)
        {
            var orders = await _mediator.Send(getAllOrdersQuery, cancellationToken);
            return Ok(orders);
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetOrderByCustomerId(int CustomerId, GetOrderByIdQuery getOrderByIdQuery, CancellationToken cancellationToken)
        {
            getOrderByIdQuery.CustomerId = CustomerId;
            var order = await _mediator.Send(getOrderByIdQuery, cancellationToken);
            return Ok(order);
        }
        [HttpGet("orderSummary")]
        public async Task<IActionResult> GetOrderSummary(DateTime From, DateTime To, GetOrderSummaryQuery getOrderSummaryQuery, CancellationToken cancellationToken)
        {
            var orderSummary = await _mediator.Send(getOrderSummaryQuery, cancellationToken);
            return Ok(orderSummary);
        }
    }
}
