using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace POSSystem.Application.Features.Commands
{
    public class DeleteInventoryCommand:IRequest<bool>
    {
        public int Id { get; set; }
    }
}
