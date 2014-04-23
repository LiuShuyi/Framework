using Framework.Configuration;
using Framework.Contract.Model.Data;
using NUnit.Framework;

namespace Framework.Test.UnitTesting.Framework.Configuration
{
    /// <summary>
    /// Framework.Configuration.ConfigManager 单元测试
    /// </summary>
    [TestFixture]
    public class ConfigManagerTest
    {
        [Test]
        public void GetConfig测试()
        {
            var dataOperationsConfig = ConfigManager.GetConfigList<DataOperations>();

            var connectionStringsConfig = ConfigManager.GetConfig<ConnectionStrings>();

            Assert.IsNotNull(dataOperationsConfig);

            Assert.IsNotNull(connectionStringsConfig);
        }
    }
}