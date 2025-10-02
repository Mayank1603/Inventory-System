using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSystem.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int InventoryItemId { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public virtual Order Order { get; set; }
        public string Status { get; set; }
        public virtual InventoryItem InventoryItem { get; set; }
    }
}
