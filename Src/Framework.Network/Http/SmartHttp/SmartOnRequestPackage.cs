using System.Net.Sockets;

namespace Framework.Network.Http.SmartHttp
{
    /// <summary>
    /// OnRequestPackage
    /// </summary>
    public class SmartOnRequestPackage
    {
        /// <summary>
        /// Client
        /// </summary>
        public Socket Client { get; set; }

        /// <summary>
        /// HttpContext
        /// </summary>
        public SmartHttpContext HttpContext { get; set; }
    }
}
