using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POSSystem.Persistence.Data;

namespace POSSystem.Persistence
{
    public static class ServiceClassExtension
    {
        public static void AddPersistence(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<POSSystemDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
