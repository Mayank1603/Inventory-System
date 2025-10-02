using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSSystem.Application.Interfaces;
using POSSystem.Domain.Entities;
using POSSystem.Persistence.Data;

namespace POSSystem.Persistence.Repositories
{
    public class InventoryRepository : GenericRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(POSSystemDbContext context) : base(context)
        {
        }
    }
}
