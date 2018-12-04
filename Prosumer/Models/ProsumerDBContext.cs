using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Prosumer.Models
{
    public class ProsumerDBContext : DbContext
    {
        public ProsumerDBContext(){ }

        public ProsumerDBContext(DbContextOptions<ProsumerDBContext> options) : base(options)
        {

        }
        public DbSet<Prosumer> Prosumers { get; set; }
    }
}
