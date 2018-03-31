using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ConnectionStatistics
    {
        public IDictionary OriginalStats { get; set; }
        public long ExecutionTime { get; set; }
        public long BytesReceived { get; set; }

        public ConnectionStatistics(IDictionary stats)
        {
            OriginalStats = stats;
            if (stats.Contains("ExecutionTime")) ExecutionTime = long.Parse(stats["ExecutionTime"].ToString());
            if (stats.Contains("BytesReceived")) BytesReceived = long.Parse(stats["BytesReceived"].ToString());

        }
    }

    public class DB
    {
        /// <summary>
        /// Last connection statistics gathered
        /// </summary>
        public static ConnectionStatistics LastStatistics { get; set; }

        /// <summary>
        /// Set to true to enable gathering statistics
        /// </summary>
        public static bool EnableStatistics { get; set; }

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
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            conn.StatisticsEnabled = DB.EnableStatistics;
            conn.StateChange += Conn_StateChange;
      
            return conn;
        }

        private static void Conn_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            // Takes place when the connection state changes
            if (e.CurrentState == System.Data.ConnectionState.Closed)
            {
                if (((SqlConnection)sender).StatisticsEnabled)
                {
                    LastStatistics = new ConnectionStatistics(((SqlConnection)sender).RetrieveStatistics());
                }
            }
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
