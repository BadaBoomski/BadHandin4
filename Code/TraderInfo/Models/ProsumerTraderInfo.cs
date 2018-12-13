using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TraderInfo.Models
{
    public class ProsumerTraderInfo
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "ProsumerTraderInfoID")]
        public string ProsumerTraderInfoID { get; set; }

        [JsonProperty(PropertyName = "ProsumerID")]
        public int ProsumerID { get; set; }

        [JsonProperty(PropertyName = "DailyProfit")]
        public double DailyProfit { get; set; }

        [JsonProperty(PropertyName = "AllTimeProfit")]
        public double AllTimeProfit { get; set; }

        [JsonProperty(PropertyName = "SellRate")]
        public double SellRate { get; set; }
    }
}
