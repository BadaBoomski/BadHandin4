using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGridInfo.Models
{
    public class SmartGrid
    {
        [Key]
        public int SmartGridID { get; set; }
        public string SmartGridInfo { get; set; }
        public string SmartGridRegistration { get; set; }
        public int TotalProsumersCount { get; set; }
    }
}
