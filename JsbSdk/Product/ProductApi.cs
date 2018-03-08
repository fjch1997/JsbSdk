using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsbSdk.Product
{
    public class ProductApi : JsbWeb
    {
        public ProductApi(string accessKey, string secretKey) : base(accessKey, secretKey) { }

        public async Task<JsbProductsSearchResponse> ProductsSearchAsync(string fields, string q = null, int? cid = null, string props = null, string status = null, int? page_no = 0, int? page_size = 40, int? vertical_market = null, string customer_props = null, string market_id = null, string suite_items_str = null, string barcode_str = null)
        {
            Dictionary<string, string> data = ProductsSearchInternal(fields, q, cid, props, status, page_no, page_size, vertical_market, customer_props, market_id, suite_items_str, barcode_str);

            return JsonConvert.DeserializeObject<JsbProductsSearchResponse>(await base.FetchAsync(new Uri("products/ProductsSearchRequest", UriKind.Relative), data));
        }

        public JsbProductsSearchResponse ProductsSearch(string fields, string q = null, int? cid = null, string props = null, string status = null, int? page_no = 0, int? page_size = 40, int? vertical_market = null, string customer_props = null, string market_id = null, string suite_items_str = null, string barcode_str = null)
        {
            Dictionary<string, string> data = ProductsSearchInternal(fields, q, cid, props, status, page_no, page_size, vertical_market, customer_props, market_id, suite_items_str, barcode_str);

            return JsonConvert.DeserializeObject<JsbProductsSearchResponse>(base.Fetch(new Uri("products/ProductsSearchRequest", UriKind.Relative), data));
        }

        private static Dictionary<string, string> ProductsSearchInternal(string fields, string q, int? cid, string props, string status, int? page_no, int? page_size, int? vertical_market, string customer_props, string market_id, string suite_items_str, string barcode_str)
        {
            var data = new Dictionary<string, string>();
            data["fields"] = fields;
            if (q != null)
                data["q"] = q;
            if (cid != null)
                data["cid"] = cid.ToString();
            if (props != null)
                data["props"] = props;
            if (status != null)
                data["status"] = status;
            if (page_no != null)
                data["page_no"] = page_no.ToString();
            if (page_size != null)
                data["page_size"] = page_size.ToString();
            if (vertical_market != null)
                data["vertical_market"] = vertical_market.ToString();
            if (customer_props != null)
                data["customer_props"] = customer_props;
            if (market_id != null)
                data["market_id"] = market_id;
            if (suite_items_str != null)
                data["suite_items_str"] = suite_items_str;
            if (barcode_str != null)
                data["barcode_str"] = barcode_str;
            return data;
        }
    }
}
