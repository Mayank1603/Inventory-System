using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSystem.Domain.Entities
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<InventoryItem> Items { get; set; }
    }
}
