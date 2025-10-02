using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSystem.Domain.Entities
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public int InventoryId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
