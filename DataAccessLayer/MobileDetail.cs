using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public class MobileDetail
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        public static SqlConnection Connect()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MVCConnectionString"].ConnectionString);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            else
            {
                con.Open();
            }
            return con;
        }

        public bool DMLOperation(string q)
        {
            cmd = new SqlCommand(q, MobileDetail.Connect());
            int x = cmd.ExecuteNonQuery();
            if (x == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable SelectAll(string q)
        {
            da = new SqlDataAdapter(q, MobileDetail.Connect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
