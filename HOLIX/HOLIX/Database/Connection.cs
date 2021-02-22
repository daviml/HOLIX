using System;
using System.Data;
using System.Data.SqlClient;

namespace HOLIX.Database
{
    /// <summary>
    /// Database connection class.
    /// </summary>
    public static class Connection
    {
        /// <summary>
        /// Database connection.
        /// </summary>
        [ThreadStatic]
        private static SqlConnection conn;

        /// <summary>
        /// Gets or sets connection string.
        /// </summary>
        /// <value>Connection config.</value>
        public static string ConnectionString { get; set; }

        /// <summary>
        /// Gets database connection.
        /// </summary>
        /// <value>Connection.</value>
        public static SqlConnection Conn
        {
            get
            {
                try
                {
                    if (conn == null)
                    {
                        conn = new SqlConnection
                        {
                            ConnectionString = ConnectionString,
                        };
                    }

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"It wasn't possible start connection with database. {ex}");
                }

                return conn;
            }
        }

        /// <summary>
        /// Start the database connection.
        /// </summary>
        /// <param name="connectionString">Connection string.</param>
        public static void StartConnection(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
