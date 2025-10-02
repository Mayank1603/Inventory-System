using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace POSSystem.Application.Features.Commands
{
    public class AddOrderCommand:IRequest<bool>
    {
        public int InventoryId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string Progress { get; set; }
    }
}
