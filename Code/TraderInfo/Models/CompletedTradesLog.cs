using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TraderInfo.Models
{
    public class CompletedTradesLog
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "ProsumerBuyerID")]
        public int ProsumerBuyerID { get; set; }

        [JsonProperty(PropertyName = "ProsumerSellerID")]
        public int ProsumerSellerID { get; set; }

        [JsonProperty(PropertyName = "ProsumerTradeFromTime")]
        public DateTime ProsumerTradeFromTime { get; set; }

        [JsonProperty(PropertyName = "ProsumeTradeToTime")]
        public DateTime ProsumerTradeToTime { get; set; }

        [JsonProperty(PropertyName = "KWhBlocks")]
        public int KWhBlocks { get; set; }

        [JsonProperty(PropertyName = "TradeOccuredAt")]
        public DateTime TradeOccuredAt { get; set; }

        [JsonProperty(PropertyName = "KWhBlockPrice")]
        public double KWhBlockPrice { get; set; }
    }
}
