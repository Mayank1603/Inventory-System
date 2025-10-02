using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSSystem.Domain.Entities;

namespace POSSystem.Application.Interfaces
{
    public interface IOrderRepository:IGenericRepository<Order>
    {
    }
}
