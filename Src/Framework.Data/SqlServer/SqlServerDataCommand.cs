using System.Data;
using System.Data.SqlClient;
using Framework.Contract.Model;
using System;

namespace Framework.Data.SqlServer
{
    /// <summary>
    /// SqlServerDataCommand
    /// </summary>
    public static class SqlServerDataCommand
    {
        /// <summary>
        /// GetSqlCommand
        /// </summary>
        /// <param name="commandName"></param>
        /// <returns></returns>
        public static DataCommand GetSqlCommand(String commandName)
        {
            return new DataCommand(commandName, CreateSqlCommand(commandName));
        }

        /// <summary>
        /// CreateSqlCommand
        /// </summary>
        /// <returns></returns>
        private static SqlCommand CreateSqlCommand(String commandName)
        {
            var commandConfig = SqlDataCommandConfigManager.GetSqlDataCommandByName(commandName);

            var connectionConfig = SqlDataCommandConfigManager.GetConnectionByName(commandConfig.ConnectionName);

            var sqlCommand = new SqlCommand(commandConfig.CommandText, new SqlConnection(connectionConfig.ConnectionType.ConnectionString));

            foreach (var parm in commandConfig.Parameters.Parm)
            {
                sqlCommand.Parameters.Add(new SqlParameter(parm.Name, (SqlDbType)Enum.Parse(typeof(SqlDbType), parm.DbType), parm.Size));
            }

            return sqlCommand;
        }
    }
}
