using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGridInfo.Models
{
    public class SmartGridProsumer
    {
        [Key]
        public int SmartGridProsumerID { get; set; }
        public int SmartGridID { get; set; }
        public SmartGrid SmartGrid { get; set; }
        public int InstallationsID { get; set; }
    }
}
