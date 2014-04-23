using System;
using System.Data;
using System.Data.SqlClient;

namespace Framework.Contract.Model
{
    public class DataCommand : IDisposable
    {
        /// <summary>
        /// .ctor
        /// </summary>
        public DataCommand(String commandName, SqlCommand sqlCommand)
        {
            this.CommandName = commandName;

            this.sqlCommand = sqlCommand;
        }

        /// <summary>
        /// SqlCommand
        /// </summary>
        private readonly SqlCommand sqlCommand;

        /// <summary>
        /// CommandName
        /// </summary>
        public String CommandName { get; private set; }

        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <returns></returns>
        public Int32 ExecuteNonQuery()
        {
            PrepareExecute();

            return sqlCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// ExecuteReader
        /// </summary>
        /// <returns></returns>
        public IDataReader ExecuteReader()
        {
            PrepareExecute();

            return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// ExecuteScalar
        /// </summary>
        /// <returns></returns>
        public Object ExecuteScalar()
        {
            PrepareExecute();

            return sqlCommand.ExecuteScalar();
        }

        /// <summary>
        /// Set Parameter Value
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="value"></param>
        public void SetParameterValue(String paramName, Object value)
        {
            if (sqlCommand.Parameters.Contains(paramName))
            {
                sqlCommand.Parameters[paramName].Value = value;
            }
            else
            {
                sqlCommand.Parameters.Add(new SqlParameter(paramName, value));
            }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (sqlCommand != null && sqlCommand.Connection != null && sqlCommand.Connection.State != ConnectionState.Closed)
                {
                    sqlCommand.Connection.Close();
                }

                if (sqlCommand != null && sqlCommand.Connection != null)
                {
                    sqlCommand.Connection.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
            }
            //释放非托管资源
        }

        /// <summary>
        /// PrepareExecute
        /// </summary>
        private void PrepareExecute()
        {
            if (sqlCommand.Connection.State != ConnectionState.Open)
            {
                sqlCommand.Connection.Open();
            }
        }
    }
}
