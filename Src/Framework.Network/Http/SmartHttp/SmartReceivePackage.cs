using System;
using System.Net.Sockets;

namespace Framework.Network.Http.SmartHttp
{
    /// <summary>
    /// SmartReceive Package
    /// </summary>
    public class SmartReceivePackage
    {
        /// <summary>
        /// Client
        /// </summary>
        public Socket Client { get; set; }

        /// <summary>
        /// Buffer
        /// </summary>
        public Byte[] Buffer { get; set; }
    }
}
