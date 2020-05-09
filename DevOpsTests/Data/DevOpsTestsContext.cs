using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DevOpsTests.Models;

namespace DevOpsTests.Data
{
    public class DevOpsTestsContext : DbContext
    {
        public DevOpsTestsContext (DbContextOptions<DevOpsTestsContext> options)
            : base(options)
        {
        }

        public DbSet<DevOpsTests.Models.Vehicle> Vehicle { get; set; }
    }
}
