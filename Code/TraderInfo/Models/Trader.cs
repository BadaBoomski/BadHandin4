using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TraderInfo.Models
{
    public class Trader
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "PlantProsumekWhBlocks")]
        public int PlantProsumekWhBlocks { get; set; }

        [JsonProperty(PropertyName = "PlantProsumeFromTime")]
        public DateTime PlantProsumeFromTime { get; set; }

        [JsonProperty(PropertyName = "LastUpdated")]
        public DateTime LastUpdated { get; set; }
    }
}
