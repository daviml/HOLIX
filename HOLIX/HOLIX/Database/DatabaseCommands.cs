using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using Database.Lib;

namespace HOLIX.Database
{
    /// <summary>
    /// Database commands class.
    /// </summary>
    public static class DatabaseCommands
    {
        /// <summary>
        /// Execute query parametrized.
        /// </summary>
        /// <param name="connection">Sql connection.</param>
        /// <param name="querys">Sql querys.</param>
        /// <param name="parameters">Parameters.</param>
        /// <param name="errorMessage">Error message.</param>
        /// <returns>True: success | False: error.</returns>
        public static bool ExecuteCommands(SqlConnection connection, ICollection<string> querys, ICollection<DbParam> parameters, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (connection == null)
            {
                errorMessage = "Error it was not possible execute query, invalid connection.";
                return false;
            }

            try
            {
                foreach (string query in querys)
                {
                    DbCommand command = connection.CreateCommand();
                    foreach (var param in parameters)
                    {
                        DbParameter parameter = command.CreateParameter();
                        parameter.ParameterName = param.ParameterName;
                        parameter.Value = param.Value;
                        parameter.DbType = param.DbType;
                        command.Parameters.Add(parameter);
                    }

                    command.CommandText = query;
                    command.CommandTimeout = 0;
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                errorMessage = $"Error it was not possible execute query. {ex}";
                return false;
            }

            return true;
        }
    }
}
