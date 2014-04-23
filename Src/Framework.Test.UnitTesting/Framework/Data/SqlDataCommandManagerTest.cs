using Framework.Data;
using Framework.Data.SqlServer;
using NUnit.Framework;

namespace Framework.Test.UnitTesting.Framework.Data
{
    /// <summary>
    /// Framework.Data.SqlDataCommandManager 单元测试
    /// </summary>
    [TestFixture]
    public class SqlDataCommandManagerTest
    {
        [Test]
        public void 获取DataCommand测试()
        {
            var dataCommand = SqlServerDataCommand.GetSqlCommand("SelectCustomer");

            Assert.IsNotNull(dataCommand);

            Assert.AreEqual(dataCommand.CommandName, "SelectCustomer");
        }
    }
}