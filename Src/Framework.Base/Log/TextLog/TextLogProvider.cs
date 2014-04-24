using System;
using Framework.Base.Contract;
using log4net;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Log4Net.config", Watch = true)]
namespace Framework.Base.Log.TextLog
{
    /// <summary>
    /// Text Log
    /// Realize by log4net
    /// </summary>
    public class TextLogProvider : IFrameworkLog
    {
        #region fields

        /// <summary>
        /// ExceptionLogger
        /// </summary>
        private static readonly ILog ExceptionLogger = LogManager.GetLogger("ExceptionLogger");

        /// <summary>
        /// InfoLogger
        /// </summary>
        private static readonly ILog InfoLogger = LogManager.GetLogger("InfoLogger");

        /// <summary>
        /// WarnLogger
        /// </summary>
        private static readonly ILog WarnLogger = LogManager.GetLogger("WarnLogger");

        /// <summary>
        /// DebugLogger
        /// </summary>
        private static readonly ILog DebugLogger = LogManager.GetLogger("DebugLogger");

        /// <summary>
        /// Sync
        /// </summary>
        private static readonly Object Locker = new object();

        /// <summary>
        /// Instance
        /// </summary>
        private static TextLogProvider instance;

        #endregion

        /// <summary>
        /// 单例日志对象
        /// </summary>
        public static TextLogProvider Current
        {
            get
            {
                if (instance == null)
                {
                    lock (Locker)
                    {
                        if (instance == null)
                        {
                            instance = new TextLogProvider();
                        }
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// Exception
        /// </summary>
        /// <param name="error"></param>
        public void Exception(Object error)
        {
            ExceptionLogger.Error(error);
        }

        /// <summary>
        /// Warn
        /// </summary>
        /// <param name="warn"></param>
        public void Warn(Object warn)
        {
            WarnLogger.Warn(warn);
        }

        /// <summary>
        /// Info
        /// </summary>
        /// <param name="error"></param>
        public void Info(Object error)
        {
            InfoLogger.Info(error);
        }

        /// <summary>
        /// Debug
        /// </summary>
        /// <param name="debug"></param>
        public void Debug(Object debug)
        {
            DebugLogger.Debug(debug);
        }
    }
}


