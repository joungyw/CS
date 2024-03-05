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

namespace _0217
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521:1521))(CONNECT_DATA=(SERVICE_NAME=xe)));User Id=movie;Password=1234;";
        OracleConnection con = new OracleConnection();
        OracleCommand cmd = new OracleCommand();
        OracleDataReader reader = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

          
          

            DataSet ds = new DataSet();
            string SQL = "SELECT * FROM movie";
            OracleDataAdapter ad = new OracleDataAdapter();
            ad.SelectCommand = new OracleCommand(SQL, con);
            ad.Fill(ds, "movie");

       
           
    
        }
    }
}
