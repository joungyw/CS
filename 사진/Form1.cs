using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace 사진
{
    public partial class Form1 : Form
    {
        // Oracle 데이터베이스 연결 문자열 설정
        string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)));User Id=MOVIE;Password=1234;";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 사용자가 입력한 영화 번호 가져오기
            int movieId;
            if (!int.TryParse(textBox1.Text, out movieId))
            {
                MessageBox.Show("잘못된 영화 번호입니다.");
                return;
            }

            // SQL 쿼리
            string sqlQuery = "SELECT 영화사진 FROM 영화 WHERE 영화번호 = :영화번호";

            // 이미지를 표시할 PictureBox 컨트롤
            PictureBox pictureBox = new PictureBox();
            pictureBox.Width = 300;
            pictureBox.Height = 300;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pictureBox);

            // Oracle 연결 생성
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                OracleCommand command = new OracleCommand(sqlQuery, connection);

                try
                {
                    // Oracle 연결 열기
                    connection.Open();

                    // 파라미터 설정
                    command.Parameters.Add(new OracleParameter(":영화번호", movieId));

                    // 쿼리 실행하여 결과 가져오기
                    OracleBlob blob = (OracleBlob)command.ExecuteScalar();

                    if (blob != null)
                    {
                        // BLOB 데이터를 바이트 배열로 읽음
                        byte[] blobData = new byte[blob.Length];
                        blob.Read(blobData, 0, (int)blob.Length);

                        // 바이트 배열을 이미지로 변환하여 PictureBox에 표시
                        using (MemoryStream ms = new MemoryStream(blobData))
                        {
                            Image image = Image.FromStream(ms);
                            pictureBox.Image = image;
                        }
                    }
                    else
                    {
                        MessageBox.Show("해당하는 영화 사진을 찾을 수 없습니다.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("오류: " + ex.Message);
                }
            }
        }
    }
}