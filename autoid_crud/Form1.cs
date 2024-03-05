using autoid_crud.db;
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

namespace autoid_crud
{
    public partial class Form1 : Form
    {
        private int autoid = 0;

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new object[] { "남자", "여자" });
            comboBox1.SelectedIndex = 0;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;

            select();



        }

        private void cleanControl()
        {
            FirstNametextbox.Text = string.Empty;
            LastNametextbox.Text = string.Empty;
            button2.Text = "UPDATE";
            button3.Text = "DELETE";
        }

        private void INSERT(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FirstNametextbox.Text.Trim())
                || string.IsNullOrEmpty(LastNametextbox.Text.Trim()))
            {
                MessageBox.Show("이름을 입력하세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            string gender = "남자";
            if (comboBox1.SelectedItem != null)
            {
                gender = comboBox1.SelectedItem.ToString();
            }

            string sql = $"insert into tb_smart_crud " +
                $" VALUES" +
                $"(tb_smart_seq.nextval, " +
                $"'{FirstNametextbox.Text}'," +
                $"'{LastNametextbox.Text})'," +
                $"'{gender}'";



            CRUD.con.Open();
            CRUD.cmd = new OracleCommand(sql, CRUD.con);
            CRUD.cmd.Parameters.Clear();

            CRUD.cmd.Parameters.Add(":FirstName", FirstNametextbox.Text);
            CRUD.cmd.Parameters.Add(":LastName", LastNametextbox.Text);
            CRUD.cmd.Parameters.Add(":gender", gender);
            CRUD.cmd.Parameters.Add(":autoid", this.autoid);


            CRUD.cmd.ExecuteNonQuery();
            CRUD.con.Close();

            MessageBox.Show("저장되었습니다.");
            Select();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (searchTEXT.Text.Equals(""))
                select();
            else
                select(searchTEXT.Text);
        }

        private void select(string searchTEXT = "")
        {
            MessageBox.Show(searchTEXT);

            CRUD.con.Open();

            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter();
            string sql = "select * from tb_smart_crud where concat(firstname, lastname) like :searchTEXT order by autoid desc";


            OracleCommand oracleCommand = new OracleCommand(sql, CRUD.con);
            oracleCommand.Parameters.Add(":searchTEXT", $"%{searchTEXT}%");

            oracleDataAdapter.SelectCommand = oracleCommand;

            DataSet dataSet = new DataSet();
            oracleDataAdapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];

            CRUD.con.Close();
            cleanControl();

            if (dataGridView1.Rows.Count > 0)
            {
                this.autoid = int.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString());
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.autoid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            string firstName = (dataGridView1.CurrentRow.Cells[1].Value.ToString());
            string lastName = (dataGridView1.CurrentRow.Cells[2].Value.ToString());
            string gander = (dataGridView1.CurrentRow.Cells[3].Value.ToString());

            FirstNametextbox.Text = firstName;
            LastNametextbox.Text = lastName;


            button2.Text = $"UPDATE ({autoid})";
            button3.Text = $"DELETE ({autoid})";


            comboBox1.SelectedItem = gander;
        }


        //update 버튼 누름
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FirstNametextbox.Text.Trim())
             || string.IsNullOrEmpty(LastNametextbox.Text.Trim()))
            {
                MessageBox.Show("이름을 입력하세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string gender = "남자";
            if (comboBox1.SelectedItem != null)
            {
                gender = comboBox1.SelectedItem.ToString();
            }

            string sql = $"update tb_smart_crud" +
                        " set firstname = :FirstName," +
                        " lastname = :LastName, gender = :gender" +
                        " where autoid = :autoid";



            CRUD.con.Open();
            CRUD.cmd = new OracleCommand(sql, CRUD.con);
            CRUD.cmd.Parameters.Clear();

            CRUD.cmd.Parameters.Add(":FirstName", FirstNametextbox.Text);
            CRUD.cmd.Parameters.Add(":LastName", LastNametextbox.Text);
            CRUD.cmd.Parameters.Add(":gender", gender);
            CRUD.cmd.Parameters.Add(":autoid", this.autoid);

            CRUD.cmd.ExecuteNonQuery();
            CRUD.con.Close();

            MessageBox.Show("수정되었습니다.");
            Select();
            cleanControl();
        }


        //delete 버튼 누름
        private void button3_Click(object sender, EventArgs e)
        {
            if (autoid == 0)
            {
                MessageBox.Show("삭제시킬 열을 선택하세요");
                return;
            }



            string sql = "delete tb_smart_crud where autoid = :autoid";


            CRUD.con.Open();
            CRUD.cmd = new OracleCommand(sql, CRUD.con);
            CRUD.cmd.Parameters.Clear();
            CRUD.cmd.Parameters.Add("autoid", this.autoid);

            CRUD.cmd.ExecuteNonQuery();
            CRUD.con.Close();

            MessageBox.Show("삭제되었습니다..");
            Select();
            cleanControl();
        }
    }
}