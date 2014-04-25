using System;
using System.Collections.Specialized;

namespace Framework.Network.Http
{
    public class HttpContextAnalysis
    {
        /// <summary>
        /// GetHttpRequest
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <returns></returns>
        public HttpRequestInfo GetHttpRequest(String httpRequest)
        {
            var httpRequestInfo = new HttpRequestInfo();

            if (String.IsNullOrWhiteSpace(httpRequest))
            {
                return httpRequestInfo;
            }

            var requestHtmlSplit = httpRequest.Trim().Replace("\n", "").Split('\r');

            // Head解析
            var requestHead = requestHtmlSplit[0].Split(' ');

            httpRequestInfo.HttpMethod = requestHead[0];

            httpRequestInfo.Url = requestHead[1].StartsWith("/") ? requestHead[1] : "/" + requestHead[1];

            httpRequestInfo.QueryString = new NameValueCollection();

            var queryIndex = httpRequestInfo.Url.IndexOf('?');

            if (queryIndex != -1 && (queryIndex != httpRequestInfo.Url.Length - 1))
            {
                var queryStringSplit = httpRequestInfo.Url.Substring(httpRequestInfo.Url.IndexOf('?') + 1).Split('&');

                foreach (var s in queryStringSplit)
                {
                    var sSplit = s.Split('=');

                    if (sSplit.Length == 2)
                    {
                        httpRequestInfo.QueryString[sSplit[0]] = sSplit[1];
                    }
                }
            }

            return httpRequestInfo;
        }
    }
}