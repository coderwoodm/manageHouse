using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Demo
{
    class DBHelper
    {
        public static string connString = "server=DESKTOP-L47KVF6;database=House;Integrated Security=True; MultipleActiveResultSets=true";
        public static SqlConnection conn = null;
        public static void InitConnection() { 
        
        if(conn==null){
            conn = new SqlConnection(connString);
        
        }
            if(conn.State==ConnectionState.Closed){
                conn.Open();
            }

            if(conn.State==ConnectionState.Broken){
                conn.Close();
                conn.Open();
            }
        }
        public static SqlDataReader GetDataReader(string sqlStr) {

            InitConnection();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        
        }

        public static bool ExecuteNonQuery(string sqlStr) {

            InitConnection();
            SqlCommand cmd = new SqlCommand(sqlStr,conn);
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result > 0;
        }

        public static object ExecuteScalar(string sqlStr) {

            InitConnection();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            object result = cmd.ExecuteScalar();
            conn.Close();
            return result;
        
        }
    }
}
