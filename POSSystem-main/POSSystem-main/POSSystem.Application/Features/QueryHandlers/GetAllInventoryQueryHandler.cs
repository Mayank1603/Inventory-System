using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSSystem.Application.Features.Queries;
using POSSystem.Application.Interfaces;
using POSSystem.Domain.Entities;

namespace POSSystem.Application.Features.QueryHandlers
{
    public class GetAllInventoryQueryHandler : IRequestHandler<GetAllInventoryQuery, IEnumerable<Inventory>>
    {
        private readonly IInventoryRepository inventoryRepository;
        public GetAllInventoryQueryHandler(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }
        public async Task<IEnumerable<Inventory>> Handle(GetAllInventoryQuery request, CancellationToken cancellationToken)
        {
            var result = await inventoryRepository.GetAllAsync();
            if (!result.Any())
            {
                return null;
            }
            return result;
        }
    }
}
