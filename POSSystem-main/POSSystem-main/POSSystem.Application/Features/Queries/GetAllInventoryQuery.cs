using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSSystem.Domain.Entities;

namespace POSSystem.Application.Features.Queries
{
    public class GetAllInventoryQuery:IRequest<IEnumerable<Inventory>>
    {
    }
}
