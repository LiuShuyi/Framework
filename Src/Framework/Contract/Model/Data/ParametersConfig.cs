using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Framework.Contract.Model.Data
{
    /// <summary>
    /// ParametersConfig
    /// </summary>
    public class ParametersConfig
    {
        /// <summary>
        /// Parameters
        /// </summary>
        [XmlElement]
        public List<ParmConfig> Parm { get; set; }
    }
}
