using Newtonsoft.Json;

namespace JsbSdk.Trade
{
    public class JsbTradeFullinfoGetResponse : JsbResponse
    {

        [JsonProperty("trade_fullinfo_get_response")]
        public TradeFullinfoGetResponse TradeFullinfoGetResponse { get; set; }
    }

    public class TradeFullinfoGetResponse
    {
        [JsonProperty("trade")]
        public Trade Trade { get; set; }
    }
}