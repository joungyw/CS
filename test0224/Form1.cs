using Oracle.ManagedDataAccess.Client;
using System;
using System.Drawing;

using System.Windows.Forms;

namespace test0224
{
    public partial class Form1 : Form
    {
        private static string connectionString = "data source = localhost; user id = MOVIE; password = 1234;";
        private static OracleConnection con = null;

        public static OracleConnection connect()
        {
            if (con == null)
            {
                con = new OracleConnection(connectionString);
                con.Open();
            }
            return con;

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click1(object sender, EventArgs e)
        {
            connect();
            
           
                            con.Close();
                        }
                    }
                }
            }
        }
    }
      
        







