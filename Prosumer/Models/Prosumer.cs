using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prosumer.Models
{
    public class Prosumer
    {
        public int ProsumerID { get; set; }
        public int ExpectedComsumed { get; set; }
        public int ExpectedProduced { get; set; }
        public int CurrentComsumed { get; set; }
        public int CurrentProduced { get; set; }
        public int ActualComsumed { get; set; }
        public int ActualProduced { get; set; }
        public string Type { get; set; }


    }
}
