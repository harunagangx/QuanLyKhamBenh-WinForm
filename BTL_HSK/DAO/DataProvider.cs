using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BTL_HSK.DAO
{
    public class DataProvider
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;
        private string connectionString = ConfigurationManager.ConnectionStrings["sqlQuanLyKhamBenh"].ConnectionString;

        private static DataProvider instance;

        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return instance;
            }

            private set => instance = value;
        }

        private DataProvider() { }

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            using (conn = new SqlConnection(connectionString))
            {
                using (cmd = new SqlCommand(query, conn))
                {
                    if (parameter != null)
                    {
                        string[] listParameter = query.Split(' ');
                        int i = 0;

                        foreach (string s in listParameter)
                        {
                            if (s.Contains("@"))
                            {
                                cmd.Parameters.AddWithValue(s, parameter[i]);
                                i++;
                            }
                        }
                    }
                    using (adapter = new SqlDataAdapter(cmd))
                    {
                        dt = new DataTable();
                        adapter.Fill(dt);

                        return dt;
                    }
                }
            }
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            using (conn = new SqlConnection(connectionString))
            {
                using (cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    if (parameter != null)
                    {
                        string[] listParameter = query.Split(' ');
                        int i = 0;

                        foreach (string s in listParameter)
                        {
                            if (s.Contains("@"))
                            {
                                cmd.Parameters.AddWithValue(s, parameter[i]);
                                i++;
                            }
                        }
                    }

                    int result = cmd.ExecuteNonQuery();

                    conn.Close();

                    return result;
                }
            }
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            using (conn = new SqlConnection(connectionString))
            {
                using (cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    if (parameter != null)
                    {
                        string[] listParameter = query.Split(' ');
                        int i = 0;

                        foreach (string s in listParameter)
                        {
                            if (s.Contains("@"))
                            {
                                cmd.Parameters.AddWithValue(s, parameter[i]);
                                i++;
                            }
                        }
                    }

                    var res = cmd.ExecuteScalar();

                    conn.Close();

                    return res;
                }
            }
        }
    }
}
