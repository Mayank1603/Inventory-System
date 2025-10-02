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
    public class UpdateStockCommandHandler:IRequestHandler<UpdateStockCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IInventoryRepository _inventoryRepository;
        public UpdateStockCommandHandler(IMapper mapper, IInventoryRepository inventoryRepository)
        {
            this._inventoryRepository = inventoryRepository;
            this._mapper = mapper;
        }
        public async Task<bool> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
        {
            var existingInventoryDetails = await _inventoryRepository.GetByIdAsync(new Inventory(), request.Id);
            if (existingInventoryDetails == null)
            {
                return false;
            }
            if (request.Stock < 10)
            {
                Console.WriteLine("Stock is less than 10");
            }

            var inventoryStockToUpdate = _mapper.Map<Inventory>(request);
            var result = await _inventoryRepository.UpdateAsync(inventoryStockToUpdate);
            return result;
        }
    }
}
