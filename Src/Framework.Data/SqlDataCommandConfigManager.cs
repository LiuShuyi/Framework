using Framework.Configuration;
using Framework.Contract.Model.Data;
using System;
using System.Collections.Generic;

namespace Framework.Data
{
    /// <summary>
    /// SqlDataCommandConfig Manager
    /// </summary>
    internal class SqlDataCommandConfigManager
    {
        /// <summary>
        /// static .ctor
        /// </summary>
        static SqlDataCommandConfigManager()
        {
            InitDataCommandCollection();
            InitConnectionCollection();
        }

        /// <summary>
        /// DataCommand Collection
        /// </summary>
        private static Dictionary<String, DataCommandConfig> DataCommandDictionary { get; set; }

        /// <summary>
        /// Connection Collection
        /// </summary>
        private static Dictionary<String, ConnectionConfig> ConnectionDictionary { get; set; }

        /// <summary>
        /// GetSqlDataCommand By Name
        /// </summary>
        /// <param name="sqlDataCommandName"></param>
        /// <returns></returns>
        internal static DataCommandConfig GetSqlDataCommandByName(String sqlDataCommandName)
        {
            var key = sqlDataCommandName.ToUpperInvariant();

            if (!DataCommandDictionary.ContainsKey(key))
            {
                throw new Exception(String.Format("CommandName does not exist. {0}", key));
            }

            return DataCommandDictionary[key];
        }

        /// <summary>
        /// GetConnectionString By Name
        /// </summary>
        /// <param name="connectionName"></param>
        /// <returns></returns>
        internal static ConnectionConfig GetConnectionByName(String connectionName)
        {
            var key = connectionName.ToUpperInvariant();

            if (!ConnectionDictionary.ContainsKey(key))
            {
                throw new Exception(String.Format("Connection Name does not exist. {0}", key));
            }

            return ConnectionDictionary[key];
        }

        /// <summary>
        /// Init DataCommandList
        /// </summary>
        private static void InitDataCommandCollection()
        {
            DataCommandDictionary = new Dictionary<String, DataCommandConfig>();

            var configList = ConfigManager.GetConfigList<DataOperations>();

            foreach (var dataOperationse in configList)
            {
                foreach (var dataCommand in dataOperationse.DataCommand)
                {
                    var key = dataCommand.Name.ToUpperInvariant();

                    if (DataCommandDictionary.ContainsKey(key))
                    {
                        throw new Exception(String.Format("DataCommandDictionary contain duplicate values. {0}", dataCommand.Name));
                    }

                    DataCommandDictionary[key] = dataCommand;
                }
            }
        }

        /// <summary>
        /// Init ConnectionStringCollection
        /// </summary>
        private static void InitConnectionCollection()
        {
            ConnectionDictionary = new Dictionary<String, ConnectionConfig>();

            var connectionStringConfig = ConfigManager.GetConfig<ConnectionStrings>();

            foreach (var database in connectionStringConfig.Connection)
            {
                var key = database.Name.ToUpperInvariant();

                if (ConnectionDictionary.ContainsKey(key))
                {
                    throw new Exception(String.Format("InitConnectionDictionary contain duplicate values. {0}", database.Name));
                }

                ConnectionDictionary[key] = database;
            }
        }
    }
}
