using System;
using System.Xml;
using System.Xml.Serialization;

namespace Framework.Contract.Model.Data
{
    /// <summary>
    /// DbType
    /// </summary>
    public class ConnectionTypeConfig
    {
        /// <summary>
        /// Name
        /// </summary>
        [XmlAttribute]
        public String Name { get; set; }

        /// <summary>
        /// ConnectionString
        /// </summary>
        [XmlElement]
        public String ConnectionString { get; set; }
    }
}
