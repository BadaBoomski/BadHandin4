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

        [JsonProperty(PropertyName = "ComplatedTrades")]
        public CompletedTradesLog[] completedTrades { get; set; }

        [JsonProperty(PropertyName = "CurrentTrades")]
        public CurrentTrade[] currentTrade { get; set; }

        [JsonProperty(PropertyName = "FutureTrades")]
        public PlannedTrade[] plannedTrades { get; set; }

        [JsonProperty(PropertyName = "ProsumerTradeInfo")]
        public ProsumerTraderInfo[] prosumerTraderInfo { get; set; }

        [JsonProperty(PropertyName = "ProsumerTradesOffer")]
        public ProsumerTradesOffer[] prosumerTradesOffers { get; set; }

        [JsonProperty(PropertyName = "ProsumerTradeSales")]
        public ProsumerTradesSale[] prosumerTradesSales { get; set; }




    }
}
