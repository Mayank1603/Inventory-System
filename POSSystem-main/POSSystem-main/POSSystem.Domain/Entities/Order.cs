using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSystem.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int InventoryId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
