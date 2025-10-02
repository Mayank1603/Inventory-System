using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSSystem.Domain.Entities;

namespace POSSystem.Application.Features.Commands
{
    public class AddInventoryCommand:IRequest<bool>
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
    }
}
