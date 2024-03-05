using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    class Car
    {
        public string Name { get; set; }
       

    }
    public partial class Form2 : Form
    {
        int y = 10;

        List<Car> list = new List<Car>();
       
     
        public Form2()
        {
            InitializeComponent();

        //    MakeLabel(10, y, "안녕하세요");
          //  MakeLabel(10, y += 40, "동적라벨생성");
          // MakeLabel(10, 90, "추가됨");
            Car car1 = new Car() { Name = "안녕하세요 자동차 1입니다." };
            Car car2 = new Car() { Name = "자동차 2입니다." };

            list.Add(car1);
            list.Add(car2); 

            foreach(Car car in list)
            {
                Console.WriteLine(car);
                MakeLabel(10,y, car.Name);
                y += 40;
            }
        }
        public void MakeLabel(int x, int y, string text)
        {
            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Location = new Point(x, y);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = text;
            this.Controls.Add(label1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(textBox1.Text);
            textBox1.Text = "";
            MakeLabel(10, y = y + 40, textBox1.Text);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1_Click(null, null);
            }
        }
    }
}
