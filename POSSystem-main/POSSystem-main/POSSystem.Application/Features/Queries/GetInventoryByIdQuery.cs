using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSSystem.Domain.Entities;

namespace POSSystem.Application.Features.Queries
{
    public class GetInventoryByIdQuery:IRequest<Inventory>
    {
        public int Id { get; set; }
    }
}
