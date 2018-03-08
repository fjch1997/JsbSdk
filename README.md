# JsbSdk
## Usage
### Create an instance
```
var jsbWeb = new JsbSdk.JsbWeb("AccessKey", "SecretKey");
```

### Get orders
```
var response = await jsbWeb.Trades.TradesSoldGetAsync("tid,has_buyer_message,payment,orders,receiver_address,received_payment,title,created,buyer_nick,orders", DateTime.Now.AddDays(-3), DateTime.Now, JsbSdk.Trade.TradeStatus.WAIT_SELLER_SEND_GOODS);
var trades = result.TradesSoldGetResponse.Trades.Trade;
foreach (var trade in trades)
{
    // Do something.
}
```

### Call other APIs
```
var data = new Dictionary<string, string>();
data["fields"] = "tid,has_buyer_message,payment,orders,receiver_address,received_payment,title,created,buyer_nick,orders";
if (start_created != null)
    data["start_created"] = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd HH:mm:ss");
if (end_created != null)
    data["end_created"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
if (status != null)
    data["status"] = JsbSdk.Trade.TradeStatus.WAIT_SELLER_SEND_GOODS.ToString();
var responseJson = await jsbWeb.FetchAsync(new Uri("trade/TradesSoldGetRequest", UriKind.Relative), data); // When a relative Uri is passed in, the request will be sent with Base URI "http://120.55.246.87/JSB/rest/". JsbWeb.JsbRestBaseUri.
var response = (JObject)JsonConvert.DeserializeObject(responseJson);
```
