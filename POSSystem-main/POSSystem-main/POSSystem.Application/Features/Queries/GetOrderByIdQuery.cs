using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSSystem.Domain.Entities;

namespace POSSystem.Application.Features.Queries
{
    public class GetOrderByIdQuery:IRequest<Order>
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
    }
}
