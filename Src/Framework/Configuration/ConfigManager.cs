using Framework.Contract.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Xml.Serialization;

namespace Framework.Configuration
{
    /// <summary>
    /// Config Manager
    /// </summary>
    public static class ConfigManager
    {
        /// <summary>
        /// GetConfig
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <returns>ListT</returns>
        public static List<T> GetConfigList<T>() where T : class, new()
        {
            var classAttribute = Attribute.GetCustomAttribute(typeof(T), typeof(ConfigAttribute)) as ConfigAttribute;

            if (classAttribute == null)
            {
                throw new Exception("Config Type Illegal.");
            }

            return GetConfigListByFileFolder<T>(classAttribute.FilePath, classAttribute.Extensions);
        }


        /// <summary>
        /// GetConfig
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <returns>ListT</returns>
        public static T GetConfig<T>() where T : class, new()
        {
            var classAttribute = Attribute.GetCustomAttribute(typeof(T), typeof(ConfigAttribute)) as ConfigAttribute;

            if (classAttribute == null)
            {
                throw new Exception("Config Type Illegal.");
            }

            if (String.IsNullOrEmpty(classAttribute.FileName))
            {
                throw new Exception("");
            }

            return GetCoinfigByFileFullName<T>(String.Format(@"{0}{1}\{2}", GetConfigFilePath(), classAttribute.FilePath, classAttribute.FileName));
        }

        /// <summary>
        /// Get ConfigList By FileFolder
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <param name="extensions"></param>
        /// <returns></returns>
        private static List<T> GetConfigListByFileFolder<T>(String filePath, String extensions) where T : class
        {
            var configList = new List<T>();

            var configsFilePath = GetConfigFilePath() + filePath;

            var mydir = new DirectoryInfo(configsFilePath);

            foreach (var fileSystemInfo in mydir.GetFileSystemInfos())
            {
                var info = fileSystemInfo as FileInfo;

                if (info != null)
                {
                    if (Path.GetExtension(info.FullName).Equals("." + extensions))
                    {
                        var config = GetCoinfigByFileFullName<T>(info.FullName);

                        configList.Add(config);
                    }
                }
            }

            return configList;
        }

        /// <summary>
        /// GetCoinfig By FileFullName
        /// </summary>
        /// <param name="fileFullName"></param>
        /// <returns></returns>
        private static T GetCoinfigByFileFullName<T>(String fileFullName) where T : class
        {
            var xs = new XmlSerializer(typeof(T));

            using (var sr = new StreamReader(fileFullName))
            {
                var config = xs.Deserialize(sr) as T;

                return config;
            }
        }

        /// <summary>
        /// GetConfigFilePath
        /// </summary>
        /// <returns></returns>
        private static String GetConfigFilePath()
        {
            if (HttpContext.Current == null)
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }
            else
            {
                return HttpContext.Current.Server.MapPath("~");
            }
        }
    }
}
