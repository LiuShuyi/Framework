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

            var dataOperationsConfig1 = dataOperationsConfig[0].DataCommand.Find(config => config.Name.Equals("UnintTesting1"));

            var dataOperationsConfig2 = dataOperationsConfig[0].DataCommand.Find(config => config.Name.Equals("UnintTesting2"));

            var connectionStringsConfig1 = connectionStringsConfig.Connection.Find(config => config.Name.Equals("UnintTesting1"));

            var connectionStringsConfig2 = connectionStringsConfig.Connection.Find(config => config.Name.Equals("UnintTesting2"));

            Assert.IsNotNull(dataOperationsConfig1);

            Assert.AreEqual(dataOperationsConfig1.Name, "UnintTesting1");
            Assert.AreEqual(dataOperationsConfig1.CommandText.Trim(), "SELECT 'UnintTesting1'");
            Assert.AreEqual(dataOperationsConfig1.CommandType, "Text");
            Assert.AreEqual(dataOperationsConfig1.ConnectionName, "Local");
            Assert.AreEqual(dataOperationsConfig1.Parameters.Parm[0].Name, "@UnintTestingParm11");
            Assert.AreEqual(dataOperationsConfig1.Parameters.Parm[0].DbType, "VarChar");
            Assert.AreEqual(dataOperationsConfig1.Parameters.Parm[0].Size, 36);
            Assert.AreEqual(dataOperationsConfig1.Parameters.Parm[1].Name, "@UnintTestingParm12");
            Assert.AreEqual(dataOperationsConfig1.Parameters.Parm[1].DbType, "Char");
            Assert.AreEqual(dataOperationsConfig1.Parameters.Parm[1].Size, 21);

            Assert.IsNotNull(dataOperationsConfig2);

            Assert.AreEqual(dataOperationsConfig2.Name, "UnintTesting2");
            Assert.AreEqual(dataOperationsConfig2.CommandText.Trim(), "SELECT 'UnintTesting2'");
            Assert.AreEqual(dataOperationsConfig2.CommandType, "StoredProcedure");
            Assert.AreEqual(dataOperationsConfig2.ConnectionName, "Master");
            Assert.AreEqual(dataOperationsConfig2.Parameters.Parm[0].Name, "@UnintTestingParm21");
            Assert.AreEqual(dataOperationsConfig2.Parameters.Parm[0].DbType, "Text");
            Assert.AreEqual(dataOperationsConfig2.Parameters.Parm[0].Size, 15);
            Assert.AreEqual(dataOperationsConfig2.Parameters.Parm[1].Name, "@UnintTestingParm22");
            Assert.AreEqual(dataOperationsConfig2.Parameters.Parm[1].DbType, "Int");
            Assert.AreEqual(dataOperationsConfig2.Parameters.Parm[1].Size, 0);

            Assert.IsNotNull(connectionStringsConfig);

            Assert.AreEqual(connectionStringsConfig1.Name, "UnintTesting1");
            Assert.AreEqual(connectionStringsConfig1.RetryTimes, 3);
            Assert.AreEqual(connectionStringsConfig1.ConnectionType.Name, "Transaction");
            Assert.AreEqual(connectionStringsConfig1.ConnectionType.ConnectionString.Trim(), "Data Source=UnintTesting1");
            
            Assert.AreEqual(connectionStringsConfig2.Name, "UnintTesting2");
            Assert.AreEqual(connectionStringsConfig2.RetryTimes, 3);
            Assert.AreEqual(connectionStringsConfig2.ConnectionType.Name, "Transaction");
            Assert.AreEqual(connectionStringsConfig2.ConnectionType.ConnectionString.Trim(), "Data Source=UnintTesting2");
        }
    }
}