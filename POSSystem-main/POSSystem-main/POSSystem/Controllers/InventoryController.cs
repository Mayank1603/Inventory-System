using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POSSystem.Application.Features.Commands;
using POSSystem.Application.Features.Queries;

namespace POSSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public InventoryController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddInventory([FromBody] AddInventoryCommand command, CancellationToken cancellationToken)
        {
            var added = await _mediator.Send(command, cancellationToken);
            if (added)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateInventory(int id, [FromBody] UpdateInventoryCommand command, CancellationToken cancellationToken)
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
        public async Task<IActionResult> GetAllInventory(GetAllInventoryQuery getAllInventoryQuery, CancellationToken cancellationToken)
        {
            var inventories = await _mediator.Send(getAllInventoryQuery, cancellationToken);
            return Ok(inventories);
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetInventoryById(GetInventoryByIdQuery getInventoryByIdQuery, CancellationToken cancellationToken)
        {
            var inventory = await _mediator.Send(getInventoryByIdQuery, cancellationToken);
            return Ok(inventory);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteInventory(DeleteInventoryCommand deleteInventoryCommand, CancellationToken cancellationToken)
        {
            var deleted = await _mediator.Send(deleteInventoryCommand, cancellationToken);
            if (deleted)
            {
                return Ok();
            }
            return BadRequest();
        }

        // Stock Management

        [HttpPut("stock/update/{id}")]
        public async Task<IActionResult> UpdateStock(UpdateStockCommand updateStockCommand, CancellationToken cancellationToken)
        {
            var updated = await _mediator.Send(updateStockCommand, cancellationToken);
            if (updated)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
