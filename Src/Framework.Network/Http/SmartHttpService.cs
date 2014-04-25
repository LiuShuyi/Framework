using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Framework.Network.Http
{
    /// <summary>
    /// Smart Http Service
    /// </summary>
    public class SmartHttpService
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="ipEndPoint"></param>
        /// <param name="socketBacklogLength"></param>
        public SmartHttpService(EndPoint ipEndPoint, Int32 socketBacklogLength = 1000)
        {
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            this.socketBacklogLength = socketBacklogLength;

            socket.Bind(ipEndPoint);

            socket.Listen(socketBacklogLength);
        }

        /// <summary>
        /// Socket
        /// </summary>
        private Socket socket;

        /// <summary>
        /// Socket Backlog Length
        /// </summary>
        private Int32 socketBacklogLength;

        /// <summary>
        /// HttpProcessingDelegate
        /// </summary>
        public HttpProcessingDelegate HttpProcessingDelegate { get; set; }

        /// <summary>
        /// Async Listen
        /// </summary>
        public void AsyncReceive()
        {
            socket.Listen(socketBacklogLength);

            while (true)
            {
                var client = socket.Accept();

                var package = new ReceivePackage
                {
                    Client = client,
                    Buffer = new Byte[1000]
                };

                client.BeginReceive(package.Buffer, 0, package.Buffer.Length, SocketFlags.None, ReceiveRequest, package);
            }
        }

        /// <summary>
        /// ReceiveRequest
        /// </summary>
        /// <param name="result"></param>
        private void ReceiveRequest(IAsyncResult result)
        {
            var receivePackage = result.AsyncState as ReceivePackage;

            var receiveLength = receivePackage.Client.EndReceive(result);

            var request = Encoding.UTF8.GetString(receivePackage.Buffer, 0, receiveLength);

            var httpProcessingDelegate = HttpProcessingDelegate;

            if (httpProcessingDelegate != null)
            {
                // 解析HttpRequest
                httpProcessingDelegate.BeginInvoke(new HttpContextAnalysis().GetHttpRequest(request), HttpProcessing, new HttpProcessingDelegatePackage
                {
                    Client = receivePackage.Client,
                    HttpProcessingDelegate = httpProcessingDelegate
                });
            }
            else
            {
                receivePackage.Client.Dispose();
            }
        }

        /// <summary>
        /// Http Processing
        /// </summary>
        /// <param name="result"></param>
        private void HttpProcessing(IAsyncResult result)
        {
            var package = result.AsyncState as HttpProcessingDelegatePackage;

            var httpResponse = package.HttpProcessingDelegate.EndInvoke(result);

            var response = Encoding.UTF8.GetBytes(httpResponse.ResponseContent);

            package.Client.BeginSend(response, 0, response.Length, SocketFlags.None, SendResponse, package.Client);
        }

        /// <summary>
        /// Send Response
        /// </summary>
        /// <param name="result"></param>
        private void SendResponse(IAsyncResult result)
        {
            var client = result.AsyncState as Socket;

            client.Dispose();
        }

        public class HttpProcessingDelegatePackage
        {
            /// <summary>
            /// Client
            /// </summary>
            public Socket Client { get; set; }

            /// <summary>
            /// HttpProcessingDelegate
            /// </summary>
            public HttpProcessingDelegate HttpProcessingDelegate { get; set; }
        }

        public class ReceivePackage
        {
            public Socket Client { get; set; }

            public Byte[] Buffer { get; set; }
        }
    }
}
