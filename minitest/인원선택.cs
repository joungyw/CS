
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
    public partial class 인원선택 : Form
    {

        private int sum1 = 0;
        private int sum2 = 0;
        private int sum3 = 0;
        private int sum4 = 0;
        private int all = 0;
        int peple = 0;
 
        OracleDataReader rdr = null;
       
        public 인원선택()
        {
            InitializeComponent();
           
            dbs.Openconnect();


            string sql = "select count(확인) from 상영관 where 시간표 = 1 and 확인 = 'n'";
            Adult.Text = sum1.ToString();
            Teenager.Text = sum2.ToString();
            old.Text = sum3.ToString();
            Disabled.Text = sum4.ToString();
            OracleCommand cmd = new OracleCommand(sql, dbs.conn);     
            OracleDataReader rdr = cmd.ExecuteReader();
            

            while (rdr.Read()) {
            peple = rdr.GetInt32(0);
            }

            count.Text = peple.ToString();
            dbs.Closeconnect();
        }

        private void m1_Click_1(object sender, EventArgs e)
        {
           
            if (sum1 == 0)
            {
                MessageBox.Show("0명 입니다,");
                Adult.Text = sum1.ToString();
         
            }
            else
            {
                sum1--;
                Adult.Text = sum1.ToString();
                all = sum1 + sum2 + sum3 + sum4;
            }
            Console.WriteLine(sum1);
            Console.WriteLine(sum2);
            Console.WriteLine(sum3);
            Console.WriteLine(sum4);
            Console.WriteLine(all);

        }

        private void p1_Click_1(object sender, EventArgs e)
        {
          
            if (sum1 < peple)
            {
                sum1++;
                Adult.Text = sum1.ToString();
                all = sum1 + sum2 + sum3 + sum4;

            }
            if (all == peple)
            {
                MessageBox.Show("더 이상 입장이 불가 합니다.");
                Adult.Text = sum1.ToString();
     
            }
            else if (sum1 == 15)
            {
                MessageBox.Show("더 이상 입장이 불가 합니다.");
                Adult.Text = sum1.ToString();
                
            }

            Console.WriteLine(sum1);
            Console.WriteLine(sum2);
            Console.WriteLine(sum3);
            Console.WriteLine(sum4);
            Console.WriteLine(all);
        }

        private void m2_Click(object sender, EventArgs e)
        {
           
            if (sum2 == 0)
            {
                MessageBox.Show("0명 입니다,");

                Teenager.Text = sum2.ToString();
           
            }
            else
            {
                sum2--;
                Teenager.Text = sum2.ToString();
                all = sum1 + sum2 + sum3 + sum4;
            }
            Console.WriteLine(sum1);
            Console.WriteLine(sum2);
            Console.WriteLine(sum3);
            Console.WriteLine(sum4);
            Console.WriteLine(all);
        }

        private void p2_Click(object sender, EventArgs e)
        {
            all = sum1 + sum2 + sum3 + sum4;
            if (sum2 < peple)
            {
                sum2++;
                Teenager.Text = sum2.ToString();
         
            }
          if (all == peple)
            {
                MessageBox.Show("더 이상 입장이 불가 합니다.");
                Teenager.Text = sum2.ToString();
            
            }
            else if (sum2 == 15)
            {
                MessageBox.Show("더 이상 입장이 불가 합니다.");
                Teenager.Text = sum2.ToString();
               ;
            }
            Console.WriteLine(sum1);
            Console.WriteLine(sum2);
            Console.WriteLine(sum3);
            Console.WriteLine(sum4);
            Console.WriteLine(all);
        }

        private void m3_Click(object sender, EventArgs e)
        {
          
            if (sum3 == 0)
            {
                MessageBox.Show("0명 입니다,");
                old.Text = sum3.ToString();

            }
            else
            {
                sum3--;
                old.Text = sum3.ToString();
                all = sum1 + sum2 + sum3 + sum4;
            }
                Console.WriteLine(sum1);
                Console.WriteLine(sum2);
                Console.WriteLine(sum3);
                Console.WriteLine(sum4);
                Console.WriteLine(all);
            }
        

        private void p3_Click(object sender, EventArgs e)
        {
          
            if (sum3 < peple)
            {
                sum3++;
                old.Text = sum3.ToString();
                all = sum1 + sum2 + sum3 + sum4;
            }
            if (all == peple)
            {
                MessageBox.Show("더 이상 입장이 불가 합니다.");
                old.Text = sum3.ToString();
         
            }
            else if (sum3 == 15)
            {
                MessageBox.Show("더 이상 입장이 불가 합니다.");
                old.Text = sum3.ToString();
                
            }

            Console.WriteLine(sum1);
            Console.WriteLine(sum2);
            Console.WriteLine(sum3);
            Console.WriteLine(sum4);
            Console.WriteLine(all);
        }

        private void m4_Click(object sender, EventArgs e)
        {
            all = sum1 + sum2 + sum3 + sum4;
            if (sum4 == 0)
            {
                MessageBox.Show("0명 입니다,");
                Disabled.Text = sum4.ToString();
             
            }
            else
            {
                sum4--;
                Disabled.Text = sum4.ToString();
                all = sum1 + sum2 + sum3 + sum4;
            }
            Console.WriteLine(sum1);
            Console.WriteLine(sum2);
            Console.WriteLine(sum3);
            Console.WriteLine(sum4);
            Console.WriteLine(all);
        }

        private void p4_Click(object sender, EventArgs e)
        {
           
            if (sum4 < peple)
            {
                sum4++;
                Disabled.Text = sum4.ToString();
                all = sum1 + sum2 + sum3 + sum4;
            }
            if (all == peple)
            {
                MessageBox.Show("더 이상 입장이 불가 합니다.");
                Disabled.Text = sum4.ToString();
             
            }
            else if (sum4 == 15)
            {
                MessageBox.Show("더 이상 입장이 불가 합니다.");
                Disabled.Text = sum4.ToString();
        
            }

            Console.WriteLine(sum1);
            Console.WriteLine(sum2);
            Console.WriteLine(sum3);
            Console.WriteLine(sum4);
            Console.WriteLine(all);
        }

        private void 이전화면_Click(object sender, EventArgs e)
        {
            영화선택 영화 = new 영화선택();
            Hide();
            영화.ShowDialog();
        }

        private void 확인_Click(object sender, EventArgs e)
        {
      
        }
    }

}
