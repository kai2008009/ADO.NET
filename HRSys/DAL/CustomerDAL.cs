using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSys.DAL
{
    class CustomerDAL
    {
        public static readonly string connStr = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        public static int ExecuteNonQuery(string sql, params SqlParameter[] partamters)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(partamters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScale(string sql, params SqlParameter[] partamters)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(partamters);
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] partamters)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(partamters);

                    DataSet dataset=new DataSet();
                    SqlDataAdapter adapter=new SqlDataAdapter(cmd);
                    adapter.Fill(dataset);

                    return dataset.Tables[0];
                }
            }
        }

        public static object FromDbValue(object value)
        {
            if (value == DBNull.Value)
            {
                return null;
            }
            else
            {
                return value;
            }
        }

        public static object ToDbValue(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }
    }
}
