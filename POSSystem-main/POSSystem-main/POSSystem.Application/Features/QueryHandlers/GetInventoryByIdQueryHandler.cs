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
    public class GetInventoryByIdQueryHandler: IRequestHandler<GetInventoryByIdQuery, Inventory>
    {
        private readonly IInventoryRepository inventoryRepository;
    public GetInventoryByIdQueryHandler(IInventoryRepository inventoryRepository)
    {
        this.inventoryRepository = inventoryRepository;
    }
    public async Task<Inventory> Handle(GetInventoryByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await inventoryRepository.GetByIdAsync(new Inventory(), request.Id);
        if (result==null)
        {
            return null;
        }
        return result;
    }
}
}
