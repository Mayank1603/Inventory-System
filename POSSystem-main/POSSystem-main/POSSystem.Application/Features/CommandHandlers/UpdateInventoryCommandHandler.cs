using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using POSSystem.Application.Features.Commands;
using POSSystem.Application.Interfaces;
using POSSystem.Domain.Entities;

namespace POSSystem.Application.Features.CommandHandlers
{
    public class UpdateInventoryCommandHandler:IRequestHandler<UpdateInventoryCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IInventoryRepository _inventoryRepository;
        public UpdateInventoryCommandHandler(IMapper mapper, IInventoryRepository inventoryRepository)
        {
            this._inventoryRepository = inventoryRepository;
            this._mapper = mapper;
        }
        public async Task<bool> Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
        {
            var existingInventoryDetails = await _inventoryRepository.GetByIdAsync(new Inventory(), request.Id);
            if (existingInventoryDetails == null)
            {
                return false;
            }

            var inventoryToUpdate = _mapper.Map<Inventory>(request);
            var result = await _inventoryRepository.UpdateAsync(inventoryToUpdate);
            return result;
        }
    }
}
