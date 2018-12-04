using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Trader.Models
{
    public class Trader
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }
        [JsonProperty(PropertyName = "TraderId")]
        public int TraderID { get; set; }
        [JsonProperty(PropertyName = "DailyProfit")]
        public int DailyProfit { get; set; }
        [JsonProperty(PropertyName = "AllTimeProfit")]
        public int AllTimeProfit { get; set; }

        public int SellRate { get; set; }
    }
}
