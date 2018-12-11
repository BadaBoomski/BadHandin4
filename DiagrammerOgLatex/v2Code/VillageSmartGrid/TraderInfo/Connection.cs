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
        private string CollectionId = "Traders";

        private void SetCollectionID()
        {
            if (GetType() == typeof(Trader)) { CollectionId = "Traders"; }
            if (this.GetType() == typeof(CurrentTrade)) { CollectionId = "CurrentTrades"; }
            if (this.GetType() == typeof(CompletedTradesLog)) { CollectionId = "CompletedTradesLogs"; }
            if (this.GetType() == typeof(PlannedTrade)) { CollectionId = "PlannedTrades"; }
            if (this.GetType() == typeof(ProsumerTraderInfo)) { CollectionId = "ProsumerTraderInfos"; }
            if (this.GetType() == typeof(ProsumerTradesOffer)) { CollectionId = "ProsumerTradesOffer"; }
            if (this.GetType() == typeof(ProsumerTradesSale)) { CollectionId = "ProsumerTradesSale"; }
        }
    }
}
