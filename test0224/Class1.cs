using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test0224
{
    internal class Class1
    {
        public void A(){ 
             using (OracleCommand cmd = new OracleCommand("select 확인 from 상영관 where 시간표 = 1 AND num = {}", con))
                {
                    using (OracleDataReader a = cmd.ExecuteReader())
                    {
                        if (a.Read())
                        {
                            string 확인 = a.GetString(0);
                            if (확인.Equals("n"))
                            {
                                button1.BackColor = Color.Blue;
                                MessageBox.Show("선택되었습니다.");
                                using (OracleCommand updateCmd = new OracleCommand("UPDATE 상영관 set 확인 = 'y' where num = 1", con))
                                    updateCmd.ExecuteNonQuery();
                                con.Close();

                            }
                            else
{
    button1.BackColor = Color.Red;
    MessageBox.Show("선택불가");
}
                            }

    }
}
