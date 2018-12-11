using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SmartGridInfo.Models
{
    public class SmartGridDbContext : DbContext
    {
        public SmartGridDbContext() { }
        public SmartGridDbContext(DbContextOptions<SmartGridDbContext> options) : base(options) { }
        public DbSet<SmartGrid> SmartGrids { get; set; }
        public DbSet<SmartGridProsumer> SmartGridProsumers { get; set; }
    }
}
