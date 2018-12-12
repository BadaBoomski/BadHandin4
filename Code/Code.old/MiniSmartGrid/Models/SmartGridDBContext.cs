using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MiniSmartGrid.Models
{
    public class SmartGridDBContext : DbContext
    {
        public SmartGridDBContext() { }
        public SmartGridDBContext(DbContextOptions<SmartGridDBContext> options)
            : base(options) { }
        public DbSet<SmartGrid> SmartGrids { get; set; }
    }
}
