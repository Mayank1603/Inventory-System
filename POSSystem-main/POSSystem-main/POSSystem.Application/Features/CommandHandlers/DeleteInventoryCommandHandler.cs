using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSSystem.Application.Features.Commands;
using POSSystem.Application.Interfaces;
using POSSystem.Domain.Entities;

namespace POSSystem.Application.Features.CommandHandlers
{
    public class DeleteInventoryCommandHandler:IRequestHandler<DeleteInventoryCommand, bool>
    {
        private readonly IInventoryRepository _inventoryRepository;

        public DeleteInventoryCommandHandler(IInventoryRepository inventoryRepository) {
            this._inventoryRepository = inventoryRepository;
        }

        public async Task<bool> Handle(DeleteInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventory = await _inventoryRepository.GetByIdAsync(new Inventory(), request.Id);
            if (inventory == null)
            {
                return false;
            }
            return await _inventoryRepository.DeleteAsync(inventory);
        }
    }
}
