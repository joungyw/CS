using Oracle.ManagedDataAccess.Client;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=();User Id=hr;Password=1234;";
        public Form1()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
    OracleConnection conn = new OracleConnection(connectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand("select * from �л�",conn);
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                MessageBox.Show(reader["�й�"].ToString);
            }
            reader.Close();
            conn.Close();
        }
    }
}
