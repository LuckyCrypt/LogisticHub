using System.Collections.Generic;
using LogisticHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogisticHub.Domain
{
    public class LogisticHubContext : DbContext
    {

        public DbSet<OrdersApp> Orders { get; set; }


        public LogisticHubContext(DbContextOptions options) : base(options)
        {

        }

       
    }
}
