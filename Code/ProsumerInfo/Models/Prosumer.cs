using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProsumerInfo.Models
{
    public class Prosumer
    {
        [Key]
        public int ProsumerID { get; set; }
        public int InstallationsID { get; set; }
        public int KWhBlocksTotalProduction { get; set; }
        public int KWhBlocksTotalConsumed { get; set; }
        public DateTime kWhBlocksLastMeterStamp { get; set; }
        public int ProsumerCurrencyNowInBlocks { get; set; }
        public DateTime ProsumerLastUpdated { get; set; }
    }
}
