using System;

namespace Framework.Contract.Model
{
    /// <summary>
    /// DataOperationsFilePath Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ConfigAttribute : Attribute
    {
        /// <summary>
        /// File Path
        /// </summary>
        public String FilePath { get; set; }

        /// <summary>
        /// FileName
        /// </summary>
        public String FileName { get; set; }

        /// <summary>
        /// Extensions
        /// </summary>
        public String Extensions { get; set; }
    }
}
