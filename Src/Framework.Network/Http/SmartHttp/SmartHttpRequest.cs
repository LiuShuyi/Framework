using System;
using System.Collections.Specialized;

namespace Framework.Network.Http.SmartHttp
{
    /// <summary>
    /// SmartHttpRequest
    /// </summary>
    public class SmartHttpRequest
    {
        /// <summary>
        /// HttpMethod
        /// </summary>
        public String HttpMethod { get; set; }

        /// <summary>
        /// Request Url
        /// </summary>
        public String Url { get; set; }

        /// <summary>
        /// QueryString
        /// </summary>
        public NameValueCollection QueryString { get; set; }
    }
}