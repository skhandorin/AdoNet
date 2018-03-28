using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DB
    {
        public static string ConnectionString
        {
            get
            {
                string connString = ConfigurationManager.ConnectionStrings["AWConnection"].ToString();

                SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder(connString);
                stringBuilder.ApplicationName = ApplicationName ?? stringBuilder.ApplicationName;
                stringBuilder.ConnectTimeout = (ConnectionTimeout > 0) ? ConnectionTimeout : stringBuilder.ConnectTimeout;

                return stringBuilder.ToString();
            }
        }

        /// <summary>
        /// Returns an opened connection to the caller
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetSqlConnection()
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            return sqlConnection;
        }

        /// <summary>
        /// Overrides the connection timeout
        /// </summary>
        public static int ConnectionTimeout { get; set; }

        /// <summary>
        /// Property used to override the name of the application
        /// </summary>
        public static string ApplicationName
        {
            get;
            set;
        }
    }
}
