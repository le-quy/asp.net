using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace quan_ly_cafe.DAO
{
    public class Dataprovider
    {
        private static Dataprovider instance;

        public static Dataprovider Instance
        {
            get { if (instance == null) instance = new Dataprovider(); return Dataprovider.instance; }
            private set { Dataprovider.instance = value; }
        }
        private Dataprovider() { }
        string connectionString = ConfigurationManager.ConnectionStrings["myconnect"].ConnectionString;
        public DataTable Query (string sql)
        { 
            DataTable data = new DataTable();
            using (SqlConnection conn  = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(sql,conn);
                da.Fill(data);
            }
            return data;
        }
        public int ExNonQuery (string sql)
        {
            int data = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand com = new SqlCommand(sql,conn);
                data = com.ExecuteNonQuery();
            }
            return data;
        }

        public int ExScalar(string sql)
        {
            int data = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand com = new SqlCommand(sql, conn);
                data =(int) com.ExecuteScalar();
            }
            return data;
        }
    }
}