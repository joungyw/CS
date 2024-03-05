using minitest.db;
using minitest.DB;
using minitest.Properties;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace minitest
{
    public partial class 영화선택 : Form
    {
        정보 mnumber = new 정보();

        public 영화선택()
        {
            
            InitializeComponent();
               
        dbs.Openconnect();
            int a = 0;
            int b = 0;
          
    
            for (int i = 0; i < 6; i++)
            {
                a = i;
                string move = $"select * from 영화 where 영화번호 ={a}";
                string Time1 = $"SELECT (TO_CHAR(시작시간, 'HH24:MI'))  FROM 시간표 WHERE 영화번호 = {a} AND TO_CHAR(시작시간, 'HH24:MI') > TO_CHAR(SYSTIMESTAMP AT TIME ZONE 'Asia/Seoul', 'HH24:MI')";
                string Time2 = $"SELECT (TO_CHAR(시작시간, 'HH24:MI')) FROM ( SELECT 시작시간, ROWNUM AS rn FROM ( SELECT 시작시간 FROM 시간표 WHERE 영화번호 = {a} and TO_CHAR(시작시간, 'HH24:MI') > TO_CHAR(SYSTIMESTAMP AT TIME ZONE 'Asia/Seoul', 'HH24:MI')))WHERE rn = 2 ";
                string Time3 = $"SELECT (TO_CHAR(시작시간, 'HH24:MI')) FROM ( SELECT 시작시간, ROWNUM AS rn FROM ( SELECT 시작시간 FROM 시간표 WHERE 영화번호 = {a} and TO_CHAR(시작시간, 'HH24:MI') > TO_CHAR(SYSTIMESTAMP AT TIME ZONE 'Asia/Seoul', 'HH24:MI')))WHERE rn = 3 ";
                OracleCommand cmd1 = new OracleCommand(move, dbs.conn);
                OracleCommand cmd2 = new OracleCommand(Time1, dbs.conn);
                OracleCommand cmd3 = new OracleCommand(Time2, dbs.conn);
                OracleCommand cmd4 = new OracleCommand(Time3, dbs.conn);
                OracleDataReader M = cmd1.ExecuteReader();
                OracleDataReader T1 = cmd2.ExecuteReader();
                OracleDataReader T2 = cmd3.ExecuteReader();
                OracleDataReader T3 = cmd4.ExecuteReader();

                


                while (M.Read() && T1.Read() && T2.Read()&& T3.Read())
                {
                    if (a == 1)
                    {
                        영화명1.Text = M.GetString(1);
                        상영등급1.Text = M.GetString(2);
                        러닝타임1.Text = M.GetString(3);
                        줄거리1.Text = M.GetString(4);

                        시간11.Text = T1.GetString(0);
                        시간12.Text = T2.GetString(0);
                        시간13.Text = T3.GetString(0);
                    }

                    if (a == 2)
                    {
                        영화명2.Text = M.GetString(1);
                        상영등급2.Text = M.GetString(2);
                        러닝타임2.Text = M.GetString(3);
                        줄거리2.Text = M.GetString(4);


                        시간21.Text = T1.GetString(0);
                        시간22.Text = T2.GetString(0);
                        시간23.Text = T3.GetString(0);
                    }
                    pictureBox1.Image = Resources.새벽의_저주;






                }

     
             

            }
            dbs.Closeconnect();
        }

        private void 시간11_Click(object sender, EventArgs e)
        {
           인원선택 인원= new 인원선택();
           Hide();
           인원.ShowDialog();
        }

        private void 시간12_Click(object sender, EventArgs e)
        {
        
            인원선택 인원 = new 인원선택();
            Hide();
            인원.ShowDialog();
        }

        private void 시간13_Click(object sender, EventArgs e)
        {
          
            인원선택 인원 = new 인원선택();
            Hide();
            인원.ShowDialog();
        }

        private void 시간21_Click(object sender, EventArgs e)
        {
            
            인원선택 인원 = new 인원선택();
            Hide();
            인원.ShowDialog();
        }

        private void 시간22_Click(object sender, EventArgs e)
        {
            
            인원선택 인원 = new 인원선택();
            Hide();
            인원.ShowDialog();
        }

        private void 시간23_Click(object sender, EventArgs e)
        {
          
            인원선택 인원 = new 인원선택();
            Hide();
            인원.ShowDialog();
        }

        private void 전체시간2_Click(object sender, EventArgs e)
        {
            정보 mnumber = new 정보();
            mnumber.movienumber = 2;

            전체_영화 전체영화폼 = new 전체_영화(mnumber);
            전체영화폼.ShowDialog();
        }

        private void 전체시간1_Click(object sender, EventArgs e)
        { 

            정보 mnumber = new 정보();
            mnumber.movienumber = 1; // 예시로 값을 할당

            전체_영화 전체영화폼 = new 전체_영화(mnumber); // mnumber 객체를 전달
            전체영화폼.ShowDialog();
        }
    }


}

