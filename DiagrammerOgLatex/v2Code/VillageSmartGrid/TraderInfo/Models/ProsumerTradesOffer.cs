using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TraderInfo.Models
{
    public class ProsumerTradesOffer
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }

        [JsonProperty(PropertyName = "ProsumerTradesOffersID")]
        public int ProsumerTradesOffersID { get; set; }

        [JsonProperty(PropertyName = "ProsumerSellerID")]
        public int ProsumerSellerID { get; set; }

        [JsonProperty(PropertyName = "KWhBlocks")]
        public int KWhBlocks { get; set; }

        [JsonProperty(PropertyName = "KWhBlockPrice")]
        public double KWhBlockPrice { get; set; }
    }
}
