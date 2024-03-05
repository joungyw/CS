namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.파일쓰기 = new System.Windows.Forms.Button();
            this.불러오기 = new System.Windows.Forms.Button();
            this.삭제 = new System.Windows.Forms.Button();
            this.업데이트 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(411, 654);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // 파일쓰기
            // 
            this.파일쓰기.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.파일쓰기.Location = new System.Drawing.Point(411, 589);
            this.파일쓰기.Name = "파일쓰기";
            this.파일쓰기.Size = new System.Drawing.Size(454, 65);
            this.파일쓰기.TabIndex = 1;
            this.파일쓰기.Text = "파일 쓰기";
            this.파일쓰기.UseVisualStyleBackColor = true;
            this.파일쓰기.Click += new System.EventHandler(this.파일쓰기_Click);
            // 
            // 불러오기
            // 
            this.불러오기.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.불러오기.Location = new System.Drawing.Point(411, 524);
            this.불러오기.Name = "불러오기";
            this.불러오기.Size = new System.Drawing.Size(454, 65);
            this.불러오기.TabIndex = 2;
            this.불러오기.Text = "불러오기";
            this.불러오기.UseVisualStyleBackColor = true;
            this.불러오기.Click += new System.EventHandler(this.불러오기_Click);
            // 
            // 삭제
            // 
            this.삭제.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.삭제.Location = new System.Drawing.Point(411, 459);
            this.삭제.Name = "삭제";
            this.삭제.Size = new System.Drawing.Size(454, 65);
            this.삭제.TabIndex = 5;
            this.삭제.Text = "삭제";
            this.삭제.UseVisualStyleBackColor = true;
            this.삭제.Click += new System.EventHandler(this.삭제_Click);
            // 
            // 업데이트
            // 
            this.업데이트.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.업데이트.Location = new System.Drawing.Point(411, 394);
            this.업데이트.Name = "업데이트";
            this.업데이트.Size = new System.Drawing.Size(454, 65);
            this.업데이트.TabIndex = 6;
            this.업데이트.Text = "업데이트";
            this.업데이트.UseVisualStyleBackColor = true;
            this.업데이트.Click += new System.EventHandler(this.업데이트_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Location = new System.Drawing.Point(411, 369);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(454, 25);
            this.textBox1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(411, 344);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "글자입력";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 654);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.업데이트);
            this.Controls.Add(this.삭제);
            this.Controls.Add(this.불러오기);
            this.Controls.Add(this.파일쓰기);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button 파일쓰기;
        private System.Windows.Forms.Button 불러오기;
        private System.Windows.Forms.Button 삭제;
        private System.Windows.Forms.Button 업데이트;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}

