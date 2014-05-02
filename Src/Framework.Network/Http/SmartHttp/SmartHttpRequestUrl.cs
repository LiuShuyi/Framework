using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Network.Http.SmartHttp
{
    /// <summary>
    /// Url
    /// </summary>
    public class SmartHttpRequestUrl
    {
        /// <summary>
        /// Full Path
        /// </summary>
        public String Path { get; set; }

        /// <summary>
        /// Port
        /// </summary>
        public Int32 Port { get; set; }

        /// <summary>
        /// Host
        /// </summary>
        public String Host { get; set; }
    }
}
