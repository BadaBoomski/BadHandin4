using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProsumerInfo.Models
{
    public class ProsumerDbContext : DbContext
    {
        public ProsumerDbContext() { }
        public ProsumerDbContext(DbContextOptions<ProsumerDbContext> options) : base(options) { }
        public DbSet<Prosumer> Prosumers { get; set; }
        public DbSet<ProsumerSmartMeterRecordsLog> ProsumerSmartMeterRecordsLogs { get; set; }
    }
}
