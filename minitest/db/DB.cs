using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minitest.DB
{
   
    public static class dbs
    {
        public static string dbstr
             = "data source = localhost; user id = movie; password = 1234;";
        public static OracleConnection conn = null;

        public static OracleConnection Openconnect()
        {
            if (conn == null)
            {
                conn = new OracleConnection(dbstr);
                conn.Open();
            }
            else
            {
                conn.Open();
            }
            return conn;
        }
        public static void Closeconnect()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
    }
}
