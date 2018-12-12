using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraderInfo.Repository
{
    public partial class TradeRepository<T> : ITradeRepository<T> where T : class
    {
        private readonly string Endpoint = "https://e18i4dab.documents.azure.com:443";
        private readonly string Key = "kM87VaX0sSG87AFM2x6LgtUoZ80N6YRumqvnc5TUhyOrH6yoiPHGFpjAEhYeQL1PhRCkN2nKzpNEBifo3mVthw==";
        private readonly string DatabaseId = "E18I4DABH4Gr13";
        private readonly string CollectionId = "Gr13Database";
    }
}
