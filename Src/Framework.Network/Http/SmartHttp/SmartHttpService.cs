using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Framework.Network.Http.SmartHttp
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public delegate void RequestEventHandler(SmartHttpContext context);

    /// <summary>
    /// Smart Http Service
    /// </summary>
    public class SmartHttpService
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="ipEndPoint"></param>
        /// <param name="encoding"></param>
        /// <param name="socketBacklogLength"></param>
        public SmartHttpService(EndPoint ipEndPoint, Encoding encoding, Int32 socketBacklogLength = 1000)
        {
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            this.encoding = encoding;

            this.socketBacklogLength = socketBacklogLength;

            socket.Bind(ipEndPoint);

            socket.Listen(socketBacklogLength);
        }

        /// <summary>
        /// Socket
        /// </summary>
        private Socket socket;

        /// <summary>
        /// Encoding
        /// </summary>
        private Encoding encoding;

        /// <summary>
        /// Socket Backlog Length
        /// </summary>
        private Int32 socketBacklogLength;

        /// <summary>
        /// OnRequest
        /// </summary>
        public event RequestEventHandler OnRequest;

        /// <summary>
        /// Async Listen
        /// </summary>
        public void AsyncReceive()
        {
            socket.Listen(socketBacklogLength);

            while (true)
            {
                var client = socket.Accept();

                var package = new SmartReceivePackage
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
            var receivePackage = result.AsyncState as SmartReceivePackage;

            var receiveLength = 0;

            try
            {
                receiveLength = receivePackage.Client.EndReceive(result);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);

                return;
            }

            var request = encoding.GetString(receivePackage.Buffer, 0, receiveLength);

            var onRequest = OnRequest;

            if (onRequest != null)
            {
                var httpContext = new HttpContextAnalysis().CreateSmartHttpContext(request);

                onRequest.BeginInvoke(httpContext, OnRequestEvent, new SmartOnRequestPackage
                {
                    Client = receivePackage.Client,
                    HttpContext = httpContext
                });
            }
            else
            {
                receivePackage.Client.Dispose();
            }
        }

        /// <summary>
        /// OnRequestEvent
        /// </summary>
        /// <param name="result"></param>
        private void OnRequestEvent(IAsyncResult result)
        {
            var package = result.AsyncState as SmartOnRequestPackage;

            var response = encoding.GetBytes(package.HttpContext.Response.ResponseContent);

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
    }
}
