using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inflowmation.Models;

namespace Inflowmation.Data
{
    public class InflowmationContext : DbContext
    {
        public InflowmationContext (DbContextOptions<InflowmationContext> options)
            : base(options)
        {
        }

        public DbSet<Inflowmation.Models.Request> Request { get; set; } = default!;
    }
}
