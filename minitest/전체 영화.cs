using minitest.db;
using minitest.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minitest
{
    public partial class 전체_영화 : Form
    {
        private 정보 mnumber;


        public 전체_영화(정보 mnumber)
        {
            InitializeComponent();

            this.mnumber = mnumber;

            dbs.Openconnect();
            string sql = $"select 영화명 from 영화 where 영화번호 = {mnumber.movienumber}";
            OracleCommand mn = new OracleCommand(sql, dbs.conn);
            OracleDataReader MN = mn.ExecuteReader();

            while (MN.Read())
            {
                영화명.Text = MN.GetString(0);
            }
            string movietime = $"SELECT TO_CHAR(시작시간, 'HH24:MI') AS 시작시간 FROM 시간표 WHERE 영화번호 = {mnumber.movienumber}";
            OracleCommand mt = new OracleCommand(movietime, dbs.conn);
            OracleDataReader MT = mt.ExecuteReader();

            List<string> list = new List<string>();

            int labelIndex = 0; 
            while (MT.Read() && labelIndex < 10) 
            {
                string startTime = MT.GetString(0);
                list.Add(startTime);
                switch (labelIndex)
                {
                    case 0:
                        label1.Text = list[labelIndex];
                        break;

                    case 1:
                        label2.Text = list[labelIndex];
                        break;

                    case 2:
                        label3.Text = list[labelIndex];
                        break;

                    case 3:
                        label4.Text = list[labelIndex];
                        break;

                    case 4:
                        label5.Text = list[labelIndex];
                        break;

                    case 5:
                        label6.Text = list[labelIndex];
                        break;
                    case 6:
                        label7.Text = list[labelIndex];
                        break;
                    case 7:
                        label8.Text = list[labelIndex];
                        break;
                    case 8:
                        label9.Text = list[labelIndex];
                        break;
                    case 9:
                        label10.Text = list[labelIndex];
                        break;
                    default:
                        break;
                }
                labelIndex++;
            }


            dbs.Closeconnect();
        }
    }

}
