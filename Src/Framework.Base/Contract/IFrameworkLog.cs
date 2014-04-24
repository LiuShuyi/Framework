using System;

namespace Framework.Base.Contract
{
    /// <summary>
    /// I Log
    /// </summary>
    public interface IFrameworkLog
    {
        /// <summary>
        /// Exception
        /// </summary>
        /// <param name="error"></param>
        void Exception(Object error);

        /// <summary>
        /// Warn
        /// </summary>
        /// <param name="warn"></param>
        void Warn(Object warn);

        /// <summary>
        /// Info
        /// </summary>
        /// <param name="error"></param>
        void Info(Object error);

        /// <summary>
        /// Debug
        /// </summary>
        /// <param name="debug"></param>
        void Debug(Object debug);
    }
}
