using System;
using System.Xml.Serialization;

namespace Framework.Contract.Model.Data
{
    /// <summary>
    /// Connection
    /// </summary>
    public class ConnectionConfig
    {
        /// <summary>
        /// Name
        /// </summary>
        [XmlAttribute]
        public String Name { get; set; }

        /// <summary>
        /// RetryTimes
        /// </summary>
        [XmlAttribute]
        public Int32 RetryTimes { get; set; }

        /// <summary>
        /// DbType
        /// </summary>
        [XmlElement]
        public ConnectionTypeConfig ConnectionType { get; set; }
    }
}