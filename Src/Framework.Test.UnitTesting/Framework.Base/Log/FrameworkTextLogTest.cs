using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using frameworkLib = Framework;

namespace Framework.Test.UnitTesting.Framework.Base.Log
{
    /// <summary>
    /// Framework.Log.TextLogProvider.FrameworkTextLog 单元测试
    /// </summary>
    [TestFixture]
    public class FrameworkTextLogTest
    {
        [NUnit.Framework.Test]
        public void 写入日志测试()
        {
            frameworkLib.Base.Log.TextLog.TextLogProvider.Current.Debug("This is Debug Log");

            frameworkLib.Base.Log.TextLog.TextLogProvider.Current.Info("This is Info Log");

            frameworkLib.Base.Log.TextLog.TextLogProvider.Current.Warn("This is Warn Log");

            frameworkLib.Base.Log.TextLog.TextLogProvider.Current.Exception("This is Exception Log");
        }
    }
}
