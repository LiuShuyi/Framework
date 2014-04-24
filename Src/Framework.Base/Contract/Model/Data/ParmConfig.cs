using System;
using System.Xml.Serialization;

namespace Framework.Base.Contract.Model.Data
{
    /// <summary>
    /// ParmConfig
    /// </summary>
    public class ParmConfig
    {
        /// <summary>
        /// Parm Name
        /// </summary>
        [XmlAttribute]
        public String Name { get; set; }

        /// <summary>
        /// DbType
        /// </summary>
        [XmlAttribute]
        public String DbType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlAttribute]
        public Int32 Size { get; set; }
    }
}
