using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Configuration
{
    /// <summary>
    /// Config Manager
    /// </summary>
    public static class ConfigManager
    {
        /// <summary>
        /// Configs File Path
        /// </summary>
        public const String ConfigsFilePath = "/Configs";

        /// <summary>
        /// 获取配置。
        /// </summary>
        /// <typeparam name="T">配置对象类型。</typeparam>
        /// <returns>配置。</returns>
        public static T GetConfig<T>() where T : class, new()
        {
            return GetConfigSource().GetConfig<T>();
        }
    }
}
