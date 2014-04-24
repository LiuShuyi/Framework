using System;
using System.Xml.Serialization;

namespace Framework.Base.Contract.Model.Data
{
    [Config(FilePath = @"\Configs\Data", Extensions = "config")]
    public class DataCommandConfig
    {
        /// <summary>
        /// Name
        /// </summary>
        [XmlAttribute]
        public String Name { get; set; }

        /// <summary>
        /// Connection Name
        /// </summary>
        [XmlAttribute]
        public String ConnectionName { get; set; }

        /// <summary>
        /// Command Type
        /// </summary>
        [XmlAttribute]
        public String CommandType { get; set; }

        /// <summary>
        /// Command Text
        /// </summary>
        [XmlElement]
        public String CommandText { get; set; }

        /// <summary>
        /// Parameters
        /// </summary>
        [XmlElement]
        public ParametersConfig Parameters { get; set; }
    }
}
