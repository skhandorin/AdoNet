using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ApplicatioLog
    {
        /// <summary>
        /// Add a comment to the application log in database
        /// </summary>
        /// <param name="comment"></param>
        public static void Add(string comment)
        {
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"AddAppLog";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var p1 = new SqlParameter("comment", System.Data.SqlDbType.NVarChar, 100)
                    {
                        Value = comment
                    };

                    cmd.Parameters.Add(p1);

                    int result = cmd.ExecuteNonQuery();

                }
            }
        }

        /// <summary>
        /// Add a comment and return the last ID generated
        /// </summary>
        /// <param name="comment"></param>
        public static void Add2(string comment)
        {
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"AddAppLog2";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var p1 = new SqlParameter("comment", System.Data.SqlDbType.NVarChar, 100)
                    {
                        Value = comment
                    };

                    cmd.Parameters.Add(p1);

                    object result = cmd.ExecuteScalar();

                }
            }
        }

        /// <summary>
        /// Add a comment and use an output parameter
        /// </summary>
        /// <param name="comment"></param>
        public static void Add3(string comment)
        {
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"AddAppLog3";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var p1 = new SqlParameter("comment", System.Data.SqlDbType.NVarChar, 100)
                    {
                        Value = comment
                    };
                    cmd.Parameters.Add(p1);

                    var p2 = new SqlParameter("outid", System.Data.SqlDbType.Int);
                    p2.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(p2);

                    cmd.ExecuteNonQuery();

                    object result = p2.Value;

                }
            }
        }

        /// <summary>
        /// Add a comment and use the Return value
        /// </summary>
        /// <param name="comment"></param>
        public static void Add4(string comment)
        {
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"AddAppLog4";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var p1 = new SqlParameter("comment", System.Data.SqlDbType.NVarChar, 100)
                    {
                        Value = comment
                    };
                    cmd.Parameters.Add(p1);

                    var p2 = new SqlParameter("ReturnValue", System.Data.SqlDbType.Int);
                    p2.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(p2);

                    cmd.ExecuteNonQuery();

                    object result = p2.Value;

                }
            }
        }

        /// <summary>
        /// Delete all comments for a specific application
        /// </summary>
        /// <param name="appName"></param>
        public static void DeleteCommentsForApp(string appName)
        {
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DeleteAppLog";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var p1 = new SqlParameter("appName", System.Data.SqlDbType.NVarChar, 100);
                    p1.Value = appName;
                    cmd.Parameters.Add(p1);

                    int res = cmd.ExecuteNonQuery();
                    
                }
            }
        }

        /// <summary>
        /// Retrieves applicaion log details for a given application
        /// </summary>
        /// <param name="appName"></param>
        /// <returns></returns>
        public static DataTable GetLog(string appName)
        {
            DataTable table = new DataTable("ApplicationLog");
            SqlDataAdapter dataAdapter = null;

            using (var conn = DB.GetSqlConnection())
            {
                var cmd = new SqlCommand("select * from ApplicationLog where application_name = @appname", conn);
                cmd.Parameters.Add(new SqlParameter("appname", SqlDbType.NVarChar, 100));
                cmd.Parameters["appname"].Value = appName;

                dataAdapter = new SqlDataAdapter(cmd);

                int res = dataAdapter.Fill(table);
            }

            return table;
        }

        /// <summary>
        /// Applies the INSERT, DELETE and UPDATE operations from the disconnected data table 
        /// </summary>
        /// <param name="tableLog"></param>
        /// <returns></returns>
        public static DataTable UpdateLogChanges(DataTable tableLog)
        {
            SqlDataAdapter da = new SqlDataAdapter();

            using (var conn = DB.GetSqlConnection())
            {
                da.SelectCommand = new SqlCommand("select * from ApplicationLog", conn);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
                int res = da.Update(tableLog);
            }

            return tableLog;
        }
    }
}
