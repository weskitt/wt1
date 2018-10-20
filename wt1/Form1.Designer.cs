namespace wt1
{
    partial class Fm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fm1));
            this.skinTrackBar1 = new CCWin.SkinControl.SkinTrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.resetBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openBtn = new System.Windows.Forms.Button();
            this.General = new System.Windows.Forms.Button();
            this.Switch = new System.Windows.Forms.Button();
            this.Both = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.skinTrackBar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinTrackBar1
            // 
            this.skinTrackBar1.BackColor = System.Drawing.Color.Transparent;
            this.skinTrackBar1.Bar = ((System.Drawing.Image)(resources.GetObject("skinTrackBar1.Bar")));
            this.skinTrackBar1.BarStyle = CCWin.SkinControl.HSLTrackBarStyle.Img;
            this.skinTrackBar1.BaseColor = System.Drawing.Color.DimGray;
            this.skinTrackBar1.Location = new System.Drawing.Point(105, 12);
            this.skinTrackBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.skinTrackBar1.Name = "skinTrackBar1";
            this.skinTrackBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.skinTrackBar1.Size = new System.Drawing.Size(156, 69);
            this.skinTrackBar1.TabIndex = 1;
            this.skinTrackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.skinTrackBar1.Track = ((System.Drawing.Image)(resources.GetObject("skinTrackBar1.Track")));
            this.skinTrackBar1.Value = 50;
            this.skinTrackBar1.Scroll += new System.EventHandler(this.SkinTrackBar1_Scroll);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1431, 388);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "50";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.resetBtn);
            this.groupBox1.Controls.Add(this.skinTrackBar1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(261, 1359);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(306, 81);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(9, 30);
            this.resetBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(87, 33);
            this.resetBtn.TabIndex = 4;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(15, 1360);
            this.openBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(112, 34);
            this.openBtn.TabIndex = 11;
            this.openBtn.Text = "Open Wave";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // General
            // 
            this.General.Location = new System.Drawing.Point(15, 1404);
            this.General.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.General.Name = "General";
            this.General.Size = new System.Drawing.Size(112, 34);
            this.General.TabIndex = 12;
            this.General.Text = "General";
            this.General.UseVisualStyleBackColor = true;
            this.General.Click += new System.EventHandler(this.General_Click);
            // 
            // Switch
            // 
            this.Switch.Location = new System.Drawing.Point(136, 1360);
            this.Switch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Switch.Name = "Switch";
            this.Switch.Size = new System.Drawing.Size(112, 34);
            this.Switch.TabIndex = 13;
            this.Switch.Text = "Switch";
            this.Switch.UseVisualStyleBackColor = true;
            this.Switch.Click += new System.EventHandler(this.Switch_Click);
            // 
            // Both
            // 
            this.Both.Location = new System.Drawing.Point(136, 1404);
            this.Both.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Both.Name = "Both";
            this.Both.Size = new System.Drawing.Size(112, 34);
            this.Both.TabIndex = 14;
            this.Both.Text = "Both";
            this.Both.UseVisualStyleBackColor = true;
            // 
            // Fm1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.Both);
            this.Controls.Add(this.Switch);
            this.Controls.Add(this.General);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Fm1";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Fm1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.skinTrackBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private CCWin.SkinControl.SkinTrackBar skinTrackBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Button General;
        private System.Windows.Forms.Button Switch;
        private System.Windows.Forms.Button Both;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

