using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Log.TextLog;
using frameworkLib = Framework;

namespace Framework.Test.UnitTesting.Framework.Log.TextLogProvider
{
    /// <summary>
    /// Framework.Log.TextLogProvider.FrameworkTextLog 单元测试
    /// </summary>
    [NUnit.Framework.TestFixture]
    public class FrameworkTextLogTest
    {
        [NUnit.Framework.Test]
        public void 写入日志测试()
        {
            frameworkLib.Log.TextLog.TextLogProvider.Current.Debug("This is Debug Log");

            frameworkLib.Log.TextLog.TextLogProvider.Current.Info("This is Info Log");

            frameworkLib.Log.TextLog.TextLogProvider.Current.Warn("This is Warn Log");

            frameworkLib.Log.TextLog.TextLogProvider.Current.Exception("This is Exception Log");
        }
    }
}
