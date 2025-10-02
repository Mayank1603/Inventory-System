using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POSSystem.Application.Features.Commands;

namespace POSSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddCustomer([FromBody] AddCustomerCommand command, CancellationToken cancellationToken)
        {
            var added = await _mediator.Send(command, cancellationToken);
            if (added)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            command.Id = id;
            var updated = await _mediator.Send(command, cancellationToken);
            if (updated)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
