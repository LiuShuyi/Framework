using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Framework.Network;
using Framework.Network.Http.SmartHttp;

namespace Framework.Test.ConsoleTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var endIp = new IPEndPoint(NetworkHelper.GetFirstLocalhostAddress(AddressFamily.InterNetwork), 12100);

            var smartHttpService = new SmartHttpService(endIp, Encoding.UTF8, 10000);

            smartHttpService.OnRequest += smartHttpService_OnRequest;

            smartHttpService.AsyncReceive();
        }

        private static void smartHttpService_OnRequest(SmartHttpContext context)
        {
            var abc = 0;
            for (int i = 0; i < 10000000; i++)
            {
                abc++;
            }
            context.Response.Write(String.Format("<html><body><p>Hello {0} {1}</p></body></html>", abc, DateTime.Now));
        }
    }
}
