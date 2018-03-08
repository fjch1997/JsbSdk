using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsbSdk
{
    /// <summary>
    /// Base class for all JSB responses
    /// </summary>
    public class JsbResponse
    {
        /// <summary>
        /// When the reqeust is successful, this value will be null.
        /// </summary>
        [JsonProperty("error_response")]
        public ErrorResponse ErrorResponse { get; set; }
        /// <summary>
        /// Whether the request was successful. If not, see <see cref="ErrorResponse"/> for details.
        /// </summary>
        public bool Success => ErrorResponse == null;
    }

    public class ErrorResponse
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("msg")]
        public string Message { get; set; }
        [JsonProperty("sub_code")]
        public string SubCode { get; set; }
        [JsonProperty("sub_msg")]
        public string SubMessage { get; set; }
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
    }
}
