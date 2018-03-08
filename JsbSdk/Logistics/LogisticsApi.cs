using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsbSdk.Logistics
{
    public class LogisticsApi : JsbWeb
    {
        public LogisticsApi(string accessKey, string secretKey) : base(accessKey, secretKey) { }

        /// <summary>
        /// 用户调用该接口可实现无需物流（虚拟）发货,使用该接口发货，交易订单状态会直接变成卖家已发货。
        /// http://open.taobao.com/doc2/apiDetail.htm?spm=a219a.7629065.0.0.eth87Q&apiId=10691
        /// </summary>
        /// <param name="tid">淘宝交易ID.</param>
        /// <param name="feature">feature参数格式
        /// 范例: identCode=tid1:识别码1,识别码2|tid2:识别码3;machineCode=tid3:3C机器号A,3C机器号B
        /// identCode为识别码的KEY, machineCode为3C的KEY, 多个key之间用”;”分隔
        /// “tid1:识别码1,识别码2|tid2:识别码3”为identCode对应的value。"|"不同商品间的分隔符。
        /// 例1商品和2商品，之间就用"|"分开。
        /// TID就是商品代表的子订单号，对应taobao.trade.fullinfo.get 接口获得的oid字段。(通过OID可以唯一定位到当前商品上)
        /// ":"TID和具体传入参数间的分隔符。冒号前表示TID,之后代表该商品的参数属性。
        /// "," 属性间分隔符。（对应商品数量，当存在一个商品的数量超过1个时，用逗号分开）。
        /// 具体:当订单中A商品的数量为2个，其中手机串号分别为"12345","67890"。
        /// 参数格式：identCode=TIDA:12345,67890。TIDA对应了A宝贝，冒号后用逗号分隔的"12345","67890".说明本订单A宝贝的数量为2，值分别为"12345","67890"。
        /// 当存在"|"时，就说明订单中存在多个商品，商品间用"|"分隔了开来。|"之后的内容含义同上。</param>
        /// <returns></returns>
        public async Task<JsbLogisticsDummySendResponse> LogisticsDummySendAsync(long tid, string feature = null, string seller_ip = null)
        {
            Dictionary<string, string> data = LogisticsDummySendInternal(tid, feature, seller_ip);
            return JsonConvert.DeserializeObject<JsbLogisticsDummySendResponse>(await base.FetchAsync(new Uri("logistics/LogisticsDummySendRequest", UriKind.Relative), "PUT", data));
        }

        /// <summary>
        /// 用户调用该接口可实现无需物流（虚拟）发货,使用该接口发货，交易订单状态会直接变成卖家已发货。
        /// http://open.taobao.com/doc2/apiDetail.htm?spm=a219a.7629065.0.0.eth87Q&apiId=10691
        /// </summary>
        /// <param name="tid">淘宝交易ID.</param>
        /// <param name="feature">feature参数格式
        /// 范例: identCode=tid1:识别码1,识别码2|tid2:识别码3;machineCode=tid3:3C机器号A,3C机器号B
        /// identCode为识别码的KEY, machineCode为3C的KEY, 多个key之间用”;”分隔
        /// “tid1:识别码1,识别码2|tid2:识别码3”为identCode对应的value。"|"不同商品间的分隔符。
        /// 例1商品和2商品，之间就用"|"分开。
        /// TID就是商品代表的子订单号，对应taobao.trade.fullinfo.get 接口获得的oid字段。(通过OID可以唯一定位到当前商品上)
        /// ":"TID和具体传入参数间的分隔符。冒号前表示TID,之后代表该商品的参数属性。
        /// "," 属性间分隔符。（对应商品数量，当存在一个商品的数量超过1个时，用逗号分开）。
        /// 具体:当订单中A商品的数量为2个，其中手机串号分别为"12345","67890"。
        /// 参数格式：identCode=TIDA:12345,67890。TIDA对应了A宝贝，冒号后用逗号分隔的"12345","67890".说明本订单A宝贝的数量为2，值分别为"12345","67890"。
        /// 当存在"|"时，就说明订单中存在多个商品，商品间用"|"分隔了开来。|"之后的内容含义同上。</param>
        /// <returns></returns>
        public JsbLogisticsDummySendResponse LogisticsDummySend(long tid, string feature = null, string seller_ip = null)
        {
            Dictionary<string, string> data = LogisticsDummySendInternal(tid, feature, seller_ip);
            return JsonConvert.DeserializeObject<JsbLogisticsDummySendResponse>(base.Fetch(new Uri("logistics/LogisticsDummySendRequest", UriKind.Relative), "PUT", data));
        }

        /// <summary>
        /// 用户调用该接口可实现无需物流（虚拟）发货,使用该接口发货，交易订单状态会直接变成卖家已发货。
        /// http://open.taobao.com/doc2/apiDetail.htm?spm=a219a.7629065.0.0.eth87Q&apiId=10691
        /// </summary>
        /// <param name="tid">淘宝交易ID.</param>
        /// <param name="feature">feature参数格式
        /// 范例: identCode=tid1:识别码1,识别码2|tid2:识别码3;machineCode=tid3:3C机器号A,3C机器号B
        /// identCode为识别码的KEY, machineCode为3C的KEY, 多个key之间用”;”分隔
        /// “tid1:识别码1,识别码2|tid2:识别码3”为identCode对应的value。"|"不同商品间的分隔符。
        /// 例1商品和2商品，之间就用"|"分开。
        /// TID就是商品代表的子订单号，对应taobao.trade.fullinfo.get 接口获得的oid字段。(通过OID可以唯一定位到当前商品上)
        /// ":"TID和具体传入参数间的分隔符。冒号前表示TID,之后代表该商品的参数属性。
        /// "," 属性间分隔符。（对应商品数量，当存在一个商品的数量超过1个时，用逗号分开）。
        /// 具体:当订单中A商品的数量为2个，其中手机串号分别为"12345","67890"。
        /// 参数格式：identCode=TIDA:12345,67890。TIDA对应了A宝贝，冒号后用逗号分隔的"12345","67890".说明本订单A宝贝的数量为2，值分别为"12345","67890"。
        /// 当存在"|"时，就说明订单中存在多个商品，商品间用"|"分隔了开来。|"之后的内容含义同上。</param>
        /// <returns></returns>
        public Task<JsbLogisticsDummySendResponse> LogisticsDummySendAsync(Trade.Trade trade, string feature = null, string seller_ip = null)
        {
            return LogisticsDummySendAsync((trade ?? throw new ArgumentNullException(nameof(trade))).Tid, feature, seller_ip);
        }

        /// <summary>
        /// 用户调用该接口可实现无需物流（虚拟）发货,使用该接口发货，交易订单状态会直接变成卖家已发货。
        /// http://open.taobao.com/doc2/apiDetail.htm?spm=a219a.7629065.0.0.eth87Q&apiId=10691
        /// </summary>
        /// <param name="tid">淘宝交易ID.</param>
        /// <param name="feature">feature参数格式
        /// 范例: identCode=tid1:识别码1,识别码2|tid2:识别码3;machineCode=tid3:3C机器号A,3C机器号B
        /// identCode为识别码的KEY, machineCode为3C的KEY, 多个key之间用”;”分隔
        /// “tid1:识别码1,识别码2|tid2:识别码3”为identCode对应的value。"|"不同商品间的分隔符。
        /// 例1商品和2商品，之间就用"|"分开。
        /// TID就是商品代表的子订单号，对应taobao.trade.fullinfo.get 接口获得的oid字段。(通过OID可以唯一定位到当前商品上)
        /// ":"TID和具体传入参数间的分隔符。冒号前表示TID,之后代表该商品的参数属性。
        /// "," 属性间分隔符。（对应商品数量，当存在一个商品的数量超过1个时，用逗号分开）。
        /// 具体:当订单中A商品的数量为2个，其中手机串号分别为"12345","67890"。
        /// 参数格式：identCode=TIDA:12345,67890。TIDA对应了A宝贝，冒号后用逗号分隔的"12345","67890".说明本订单A宝贝的数量为2，值分别为"12345","67890"。
        /// 当存在"|"时，就说明订单中存在多个商品，商品间用"|"分隔了开来。|"之后的内容含义同上。</param>
        /// <returns></returns>
        public JsbLogisticsDummySendResponse LogisticsDummySend(Trade.Trade trade, string feature = null, string seller_ip = null)
        {
            return LogisticsDummySend((trade ?? throw new ArgumentNullException(nameof(trade))).Tid, feature, seller_ip);
        }

        private static Dictionary<string, string> LogisticsDummySendInternal(long tid, string feature, string seller_ip)
        {
            if (tid == default(long))
                throw new ArgumentException(nameof(tid) + " cannot be 0.");
            var data = new Dictionary<string, string>();
            data["tid"] = tid.ToString();
            if (feature != null)
                data["feature"] = feature;
            if (seller_ip != null)
                data["seller_ip"] = seller_ip;
            return data;
        }
    }
}
