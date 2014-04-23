using Framework.Data.SqlServer;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Framework.Test.UnitTesting.Framework.Data.SqlServer
{
    /// <summary>
    /// Framework.Data.SqlServer.SqlServerDataCommand 单元测试
    /// </summary>
    [TestFixture]
    public class SqlServerDataCommandTest
    {
        [Test]
        public void 数据库测试()
        {
            var userList = new List<String>();

            using (var command = SqlServerDataCommand.GetSqlCommand("SelectCustomer"))
            {
                command.SetParameterValue("@TransactionNumber", 2);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userList.Add(String.Format("{0}{1}", reader["Name"], reader["Password"]));
                    }
                }
            }

            Assert.AreEqual(userList[0], "jtgoodday");
        }
    }
}
