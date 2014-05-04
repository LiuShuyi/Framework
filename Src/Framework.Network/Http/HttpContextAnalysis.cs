using System;
using System.Collections.Specialized;
using System.Linq;
using Framework.Network.Http.SmartHttp;

namespace Framework.Network.Http
{
    /// <summary>
    /// HttpContextAnalysis
    /// </summary>
    public class HttpContextAnalysis
    {
        /// <summary>
        /// Create SmartHttpContext
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <returns></returns>
        public SmartHttpContext CreateSmartHttpContext(String httpRequest)
        {
            var smartHttpContext = new SmartHttpContext
            {
                Request = CreateSmartHttpRequest(httpRequest),
                Response = new SmartHttpResponse()
            };

            return smartHttpContext;
        }

        /// <summary>
        /// GetHttpRequest
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <returns></returns>
        private SmartHttpRequest CreateSmartHttpRequest(String httpRequest)
        {
            var httpRequestInfo = new SmartHttpRequest();

            if (String.IsNullOrWhiteSpace(httpRequest))
            {
                return httpRequestInfo;
            }

            // HttpHeader
            var requestHeaderSplit = httpRequest.Trim().Replace("\n", "").Split('\r').ToList();

            #region HttpMethod Url QueryString

            var headerHttpMethod = requestHeaderSplit[0].ToUpperInvariant().Split(' ');
            var headerHost = requestHeaderSplit.Find((s => s.ToUpperInvariant().StartsWith("HOST"))).ToUpperInvariant();


            // HttpMethod
            httpRequestInfo.HttpMethod = headerHttpMethod[0];

            // Url
            httpRequestInfo.Url = new SmartHttpRequestUrl
            {
                Path = headerHttpMethod[1].StartsWith("/") ? headerHttpMethod[1] : "/" + headerHttpMethod[1],
            };

            var host = headerHost.Substring(5, headerHost.Length - 5).Trim().Split(':');

            if (host.Length == 2)
            {
                httpRequestInfo.Url.Host = host[0];
                httpRequestInfo.Url.Port = Int32.Parse(host[1]);
            }
            else if (host.Length == 1)
            {
                httpRequestInfo.Url.Host = host[0];
                httpRequestInfo.Url.Port = 80;
            }

            // QueryString
            httpRequestInfo.QueryString = new NameValueCollection();

            var queryIndex = httpRequestInfo.Url.Path.IndexOf('?');

            if (queryIndex != -1 && (queryIndex != httpRequestInfo.Url.Path.Length - 1))
            {
                var queryStringSplit = httpRequestInfo.Url.Path.Substring(httpRequestInfo.Url.Path.IndexOf('?') + 1).Split('&');

                foreach (var s in queryStringSplit)
                {
                    var sSplit = s.Split('=');

                    if (sSplit.Length == 2)
                    {
                        httpRequestInfo.QueryString[sSplit[0]] = sSplit[1];
                    }
                }
            }

            #endregion


            return httpRequestInfo;
        }
    }
}