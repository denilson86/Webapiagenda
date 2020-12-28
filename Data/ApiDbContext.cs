using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Agenda.Models;

namespace WebApi.Agenda.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<agenda> agenda { get; set; }

        public ApiDbContext(DbContextOptions options/*, IDomainEventDispatcher eventDispatcher*/) : base(options)
        { }
    }
}
