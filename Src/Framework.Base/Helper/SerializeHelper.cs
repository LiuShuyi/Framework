using System;
using System.Web.Script.Serialization;

namespace Framework.Base.Helper
{
    /// <summary>
    /// 序列化Helper
    /// </summary>
    public static class SerializeHelper
    {
        /// <summary>
        /// Object To Json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static String ObjectToJson(Object obj)
        {
            try
            {
                return new JavaScriptSerializer().Serialize(obj);
            }
            catch
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// Json To Object
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T JsonToObject<T>(String json) where T : class
        {
            try
            {
                return new JavaScriptSerializer().Deserialize<T>(json);
            }
            catch
            {
                return null;
            }
        }
    }
}
