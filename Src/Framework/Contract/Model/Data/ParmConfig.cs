using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Framework.Contract.Model.Data
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
