﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp2.db
{
    public class FileTBdb
    {
        private static string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)" +
             "(HOST=127.0.0.1)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)));" +
             "User Id=hr;Password=1234;";

        private static OracleConnection con = null;

        public static OracleConnection connect()
        {
            if (con == null)
            {
                con = new OracleConnection(connectionString);
                con.Open();
            }
            else
            {
                con.Open();
            }
            return con;
        }

        public void insert(string text)
        {
            // DB 연결
            OracleConnection con = connect();

            string sql = "insert into FILETB values (:value1)";

            using (OracleCommand command = new OracleCommand(sql, con))
            {
                command.Parameters.Add(":value1", text);
                int rowId = command.ExecuteNonQuery();
                Console.WriteLine($" {rowId} 행을 삽입했습니다");
            }

            con.Close();
        }

        public List<string> read()
        {
            List<string> list = new List<string>();

            OracleConnection con = connect();

            string sql = "select * from filetb";

            using (OracleCommand command = new OracleCommand(sql, con))
            {
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader["str"].ToString());
                }
            }

            con.Close();

            return list;
        }

        public void update(string org, string dst)
        {
            string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)" +
            "(HOST=192.168.0.38)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)));" +
            "User Id=hr;Password=1234;";

            // DB 연결...
            OracleConnection con = new OracleConnection(connectionString);
            con.Open();  // db 열기

            // sql 구문 만들기
            OracleCommand oracleCommand = new OracleCommand($" update filetb set str='{dst}' " +
                                                             $" where str='{org}' ", con);
            // 실행하기
            oracleCommand.ExecuteNonQuery();

            con.Close();  // db 닫기

        }
    }
}
