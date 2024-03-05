using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp2.db;
using WindowsFormsApp2.file;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        filecontrol fc = new filecontrol();
        FileTBdb ftdb = new FileTBdb();

        private string selectString = "";

        //List<string> list = new List<string>();


        public Form1()
        {
            InitializeComponent();
            //List<string> list = fc.read();

            List<string> list = ftdb.read();
            listBox1.DataSource = null;
            listBox1.DataSource = list;
        }

        private void 불러오기_Click(object sender, EventArgs e)
        {
            //List<string> list = fc.read();
            List<string> list = ftdb.read();
            listBox1.DataSource = null;
            listBox1.DataSource = list;
        }

        private void 파일쓰기_Click(object sender, EventArgs e)
        {
            // 혹시나 아무글자 않넣으면 그다음꺼 진행 하지 않고 종료
            if (textBox1.Text == "")
            {
                MessageBox.Show("글자를 입력하세요");
                return;
            }

            // 파일에 list 저장
            //fc.write(textBox1.Text, list);

            // list 객체안에 글자 담기
            //list.Add(textBox1.Text);

            // DB 에 저장하기
            ftdb.insert(textBox1.Text); // insert 하는거

            List<string> list = ftdb.read(); // select 하는거

            listBox1.DataSource = null;
            listBox1.DataSource = list; // 화면내용 다시 보여주기

            // 글자 적은거 깨끗하게
            textBox1.Text = "";

            //listBox1.Items.Add("추가");

        }

        private void 업데이트_Click(object sender, EventArgs e)
        {
            MessageBox.Show("수정");

            if (textBox1.Text == "")
            {
                MessageBox.Show("글자를 입력하세요...");
                return;
            }

            string updateStr = textBox1.Text;

            ftdb.update(selectString, updateStr);

            // select 버튼 누른거 이벤트 발생
            파일쓰기.PerformClick();
            textBox1.Text = "";

            // 불러오기 함수 호출
            //불러오기(null, null);

            불러오기.PerformClick();
            textBox1.Text = "";

        }

        private void 삭제_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)" +
           "(HOST=127.0.0.1)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)));" +
           "User Id=hr;Password=1234;";

            // DB 연결...
            OracleConnection con = new OracleConnection(connectionString);
            con.Open();  // db 열기

            // sql 구문 만들기
            OracleCommand oracleCommand = new OracleCommand($"delete from filetb where str='{textBox1.Text}'", con);
            // 실행하기
            oracleCommand.ExecuteNonQuery();
            con.Close();  // db 닫기

            파일쓰기.PerformClick();
            textBox1.Text = "";

            MessageBox.Show("삭제");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(listBox1.SelectedIndex);
            Console.WriteLine(listBox1.SelectedItem);

            if (listBox1.SelectedItem != null)
            {
                textBox1.Text = listBox1.SelectedItem.ToString();
                selectString = listBox1.SelectedItem.ToString();
                MessageBox.Show("글자 수정" + selectString);
            }
        }
    }
}
