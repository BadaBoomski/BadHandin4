using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace MiniSmartGrid.Models
{
    public class SmartGrid
    {
        public int SmartGridID { get; set; }
        public string SmartMeter { get; set; }
        public string ConsumerType { get; set; }
        public string ProductionType { get; set; }
        }
}
