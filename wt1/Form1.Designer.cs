namespace wt1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.skinTrackBar1 = new CCWin.SkinControl.SkinTrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.resetBtn = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.skinTrackBar4 = new CCWin.SkinControl.SkinTrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.skinTrackBar6 = new CCWin.SkinControl.SkinTrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.skinTrackBar8 = new CCWin.SkinControl.SkinTrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.skinTrackBar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinTrackBar4)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinTrackBar6)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinTrackBar8)).BeginInit();
            this.SuspendLayout();
            // 
            // skinTrackBar1
            // 
            this.skinTrackBar1.BackColor = System.Drawing.Color.Transparent;
            this.skinTrackBar1.Bar = ((System.Drawing.Image)(resources.GetObject("skinTrackBar1.Bar")));
            this.skinTrackBar1.BarStyle = CCWin.SkinControl.HSLTrackBarStyle.Img;
            this.skinTrackBar1.BaseColor = System.Drawing.Color.DimGray;
            this.skinTrackBar1.Location = new System.Drawing.Point(70, 8);
            this.skinTrackBar1.Name = "skinTrackBar1";
            this.skinTrackBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.skinTrackBar1.Size = new System.Drawing.Size(104, 45);
            this.skinTrackBar1.TabIndex = 1;
            this.skinTrackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.skinTrackBar1.Track = ((System.Drawing.Image)(resources.GetObject("skinTrackBar1.Track")));
            this.skinTrackBar1.Value = 50;
            this.skinTrackBar1.Scroll += new System.EventHandler(this.skinTrackBar1_Scroll);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 936);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "50";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.resetBtn);
            this.groupBox1.Controls.Add(this.skinTrackBar1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 942);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 54);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(6, 20);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(58, 22);
            this.resetBtn.TabIndex = 4;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.skinTrackBar4);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(232, 942);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(214, 54);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(58, 22);
            this.button3.TabIndex = 4;
            this.button3.Text = "Reset";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // skinTrackBar4
            // 
            this.skinTrackBar4.BackColor = System.Drawing.Color.Transparent;
            this.skinTrackBar4.Bar = global::wt1.Properties.Resources._3;
            this.skinTrackBar4.BarStyle = CCWin.SkinControl.HSLTrackBarStyle.Img;
            this.skinTrackBar4.BaseColor = System.Drawing.Color.DimGray;
            this.skinTrackBar4.Location = new System.Drawing.Point(70, 8);
            this.skinTrackBar4.Name = "skinTrackBar4";
            this.skinTrackBar4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.skinTrackBar4.Size = new System.Drawing.Size(104, 45);
            this.skinTrackBar4.TabIndex = 1;
            this.skinTrackBar4.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.skinTrackBar4.Track = ((System.Drawing.Image)(resources.GetObject("skinTrackBar4.Track")));
            this.skinTrackBar4.Value = 50;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(180, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "50";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button5);
            this.groupBox6.Controls.Add(this.skinTrackBar6);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Location = new System.Drawing.Point(452, 942);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(214, 54);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "groupBox6";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 20);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(58, 22);
            this.button5.TabIndex = 4;
            this.button5.Text = "Reset";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // skinTrackBar6
            // 
            this.skinTrackBar6.BackColor = System.Drawing.Color.Transparent;
            this.skinTrackBar6.Bar = global::wt1.Properties.Resources._3;
            this.skinTrackBar6.BarStyle = CCWin.SkinControl.HSLTrackBarStyle.Img;
            this.skinTrackBar6.BaseColor = System.Drawing.Color.DimGray;
            this.skinTrackBar6.Location = new System.Drawing.Point(70, 8);
            this.skinTrackBar6.Name = "skinTrackBar6";
            this.skinTrackBar6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.skinTrackBar6.Size = new System.Drawing.Size(104, 45);
            this.skinTrackBar6.TabIndex = 1;
            this.skinTrackBar6.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.skinTrackBar6.Track = ((System.Drawing.Image)(resources.GetObject("skinTrackBar6.Track")));
            this.skinTrackBar6.Value = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(180, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "50";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.button7);
            this.groupBox8.Controls.Add(this.skinTrackBar8);
            this.groupBox8.Controls.Add(this.label8);
            this.groupBox8.Location = new System.Drawing.Point(672, 942);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(214, 54);
            this.groupBox8.TabIndex = 10;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "groupBox8";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(6, 20);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(58, 22);
            this.button7.TabIndex = 4;
            this.button7.Text = "Reset";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // skinTrackBar8
            // 
            this.skinTrackBar8.BackColor = System.Drawing.Color.Transparent;
            this.skinTrackBar8.Bar = global::wt1.Properties.Resources._3;
            this.skinTrackBar8.BarStyle = CCWin.SkinControl.HSLTrackBarStyle.Img;
            this.skinTrackBar8.BaseColor = System.Drawing.Color.DimGray;
            this.skinTrackBar8.Location = new System.Drawing.Point(70, 8);
            this.skinTrackBar8.Name = "skinTrackBar8";
            this.skinTrackBar8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.skinTrackBar8.Size = new System.Drawing.Size(104, 45);
            this.skinTrackBar8.TabIndex = 1;
            this.skinTrackBar8.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.skinTrackBar8.Track = ((System.Drawing.Image)(resources.GetObject("skinTrackBar8.Track")));
            this.skinTrackBar8.Value = 50;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(180, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "50";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(892, 972);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(75, 23);
            this.openBtn.TabIndex = 11;
            this.openBtn.Text = "Open Wave";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1673, 1006);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.skinTrackBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinTrackBar4)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinTrackBar6)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinTrackBar8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CCWin.SkinControl.SkinTrackBar skinTrackBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button3;
        private CCWin.SkinControl.SkinTrackBar skinTrackBar4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button5;
        private CCWin.SkinControl.SkinTrackBar skinTrackBar6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button button7;
        private CCWin.SkinControl.SkinTrackBar skinTrackBar8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button openBtn;
    }
}

