using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Agenda.Data
{
    public static class IServiceCollectionExtensions
    {   
        public static void AddEntityFrameworkStore(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApiDbContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}
