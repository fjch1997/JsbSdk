using Newtonsoft.Json;
using System.Collections.Generic;

namespace JsbSdk.Trade
{
    public class TradesSoldIncrementGetResponse
    {

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        [JsonProperty("trades")]
        public Trades Trades { get; set; }

        [JsonProperty("has_next")]
        public bool HasNext { get; set; }
    }

    public class JsbTradesSoldIncrementGetResponse : JsbResponse
    {

        [JsonProperty("trades_sold_increment_get_response")]
        public TradesSoldIncrementGetResponse TradesSoldIncrementGetResponse { get; set; }
    }

}