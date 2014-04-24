using System.Collections.Generic;
using System.Xml.Serialization;

namespace Framework.Base.Contract.Model.Data
{
    /// <summary>
    /// ConnectionStrings
    /// </summary>
    [Config(FileName = "ConnectionString.config", FilePath = @"\Configs")]
    public class ConnectionStrings
    {
        /// <summary>
        /// Database
        /// </summary>
        [XmlElement]
        public List<ConnectionConfig> Connection;
    }
}
