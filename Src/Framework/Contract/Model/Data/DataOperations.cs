using System.Collections.Generic;
using System.Xml.Serialization;

namespace Framework.Contract.Model.Data
{
    /// <summary>
    /// DataOperations
    /// </summary>
    [Config(FilePath = @"\Configs\Data", Extensions = "config")]
    public class DataOperations
    {
        /// <summary>
        /// DataCommand
        /// </summary>
        [XmlElement]
        public List<DataCommandConfig> DataCommand;
    }
}