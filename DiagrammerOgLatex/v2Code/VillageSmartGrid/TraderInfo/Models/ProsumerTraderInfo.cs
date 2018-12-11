using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TraderInfo.Models
{
    public class ProsumerTraderInfo
    {
        [JsonProperty(PropertyName = "ProsumerID")]
        public int ProsumerID { get; set; }

        [JsonProperty(PropertyName = "DailyProfit")]
        public int DailyProfit { get; set; }

        [JsonProperty(PropertyName = "AllTimeProfit")]
        public int AllTimeProfit { get; set; }

        [JsonProperty(PropertyName = "SellRate")]
        public int SellRate { get; set; }
    }
}
