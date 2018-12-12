using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProsumerInfo.Models
{
    public class ProsumerSmartMeterRecordsLog
    {
        [Key]
        public int ProsumerSmartMeterRecordsID { get; set; }
        public Prosumer Prosumer { get; set; }
        public int ProsumerID { get; set; }
        public int InstallationsID { get; set; }
        public int KWhBlocksProduced { get; set; }
        public int KWhBlocksConsumed { get; set; }
    }
}
