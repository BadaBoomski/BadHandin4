using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraderInfo.Models;
using TraderInfo.Interfaces;

namespace TraderInfo.Repository
{
    public partial class AzureDBRepository<Trade> : IAzureDBRepository<Trade> where Trade : class
    {
        //private readonly string Endpoint = "https://e18i4dab.documents.azure.com:443";
        //private readonly string Key = "kM87VaX0sSG87AFM2x6LgtUoZ80N6YRumqvnc5TUhyOrH6yoiPHGFpjAEhYeQL1PhRCkN2nKzpNEBifo3mVthw==";
        //private readonly string DatabaseId = "E18I4DABH4Gr13";
        //private string CollectionId = ""; //default : "Gr13Database"

        private readonly string Endpoint = "https://localhost:8081";
        private readonly string Key = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private readonly string DatabaseId = "TestTrader";
        private string CollectionId = "";

        private void SetCollectionID()
        {
            if (typeof(Trade) == typeof(Trader)) { CollectionId = "Traders"; }
            if (typeof(Trade) == typeof(CurrentTrade)) { CollectionId = "CurrentTrades"; }
            if (typeof(Trade) == typeof(CompletedTradesLog)) { CollectionId = "CompletedTradesLogs"; }
            if (typeof(Trade) == typeof(PlannedTrade)) { CollectionId = "PlannedTrades"; }
            if (typeof(Trade) == typeof(ProsumerTraderInfo)) { CollectionId = "ProsumerTraderInfos"; }
            if (typeof(Trade) == typeof(ProsumerTradesOffer)) { CollectionId = "ProsumerTradesOffer"; }
            if (typeof(Trade) == typeof(ProsumerTradesSale)) { CollectionId = "ProsumerTradesSale"; }
        }
    }
}
