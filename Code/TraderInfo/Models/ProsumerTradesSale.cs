using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TraderInfo.Models
{
    public class ProsumerTradesSale
    {
        [JsonProperty(PropertyName = "id")]
        public string ProsumerTradeSalesID { get; set; }

        [JsonProperty(PropertyName = "ProsumerSellerID")]
        public int ProsumerSellerID { get; set; }

        [JsonProperty(PropertyName = "OfferFromTime")]
        public DateTime OfferFromTime { get; set; }

        [JsonProperty(PropertyName = "OfferToTime")]
        public DateTime OfferToTime { get; set; }

        [JsonProperty(PropertyName = "KWhBlocks")]
        public int KWhBlocks { get; set; }

        [JsonProperty(PropertyName = "KWhBlockPrice")]
        public int KWhBlockPrice { get; set; }
    }
}
