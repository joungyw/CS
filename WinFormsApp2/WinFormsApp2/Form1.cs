namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach (Control control in Controls)
            {
                Console.WriteLine(control);

                if (control is Panel)
                {
                    Panel panel = control as Panel;
                    foreach (Control subcontrol in panel.Controls)
                    {
                        subcontrol.Text= "���ڹٲٱ�";
                    }
                }
                    control.Text = "���ڹٲٱ�";
                    control.Font = new Font("���� ���", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
                if (control is Button) 
                {
                    Button button = control as Button;  
                    control.AutoSize = true;   
                }
            }

        }
    }
}
