﻿using System;
using System.Text;

namespace Framework.Network.Http.SmartHttp
{
    /// <summary>
    /// SmartHttpResponse
    /// </summary>
    public class SmartHttpResponse
    {
        /// <summary>
        /// ResponseContent
        /// </summary>
        private StringBuilder responseContent = new StringBuilder();

        /// <summary>
        /// Response Content
        /// </summary>
        public String ResponseContent
        {
            get { return responseContent.ToString(); }
        }

        /// <summary>
        /// Clear
        /// </summary>
        public void ClearContent()
        {
            responseContent.Clear();
        }

        /// <summary>
        /// Write
        /// </summary>
        public void WriteContent(String writeContent)
        {
            responseContent.Append(writeContent);
        }
    }
}
