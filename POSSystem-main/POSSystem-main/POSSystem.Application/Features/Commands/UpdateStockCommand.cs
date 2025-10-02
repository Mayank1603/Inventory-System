using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace POSSystem.Application.Features.Commands
{
    public class UpdateStockCommand:IRequest<bool>
    {
        public int Id { get; set; }
        public int Stock { get; set; }
    }
}
