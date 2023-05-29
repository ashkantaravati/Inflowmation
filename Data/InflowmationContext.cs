using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inflowmation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Inflowmation.Data
{
    public class InflowmationContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public InflowmationContext (DbContextOptions<InflowmationContext> options)
            : base(options)
        {
        }

        public DbSet<Issue> Issues { get; set; } = default!;

        public DbSet<Department> Departments { get; set; } = default!;

        public DbSet<Employee> Employees { get; set; } = default!;
    }
}
