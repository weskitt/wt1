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
            this.panel1 = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.OpenBtn = new System.Windows.Forms.Button();
            this.General = new System.Windows.Forms.Button();
            this.Switch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_p = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.perDev = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1593, 1032);
            this.panel1.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // OpenBtn
            // 
            this.OpenBtn.AutoSize = true;
            this.OpenBtn.Location = new System.Drawing.Point(11, 1044);
            this.OpenBtn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.OpenBtn.Name = "OpenBtn";
            this.OpenBtn.Size = new System.Drawing.Size(100, 30);
            this.OpenBtn.TabIndex = 11;
            this.OpenBtn.Text = "Open Wave";
            this.OpenBtn.UseVisualStyleBackColor = true;
            this.OpenBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // General
            // 
            this.General.AutoSize = true;
            this.General.Location = new System.Drawing.Point(226, 1044);
            this.General.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.General.Name = "General";
            this.General.Size = new System.Drawing.Size(98, 30);
            this.General.TabIndex = 12;
            this.General.Text = "General";
            this.General.UseVisualStyleBackColor = true;
            this.General.Click += new System.EventHandler(this.General_Click);
            // 
            // Switch
            // 
            this.Switch.AutoSize = true;
            this.Switch.Location = new System.Drawing.Point(123, 1044);
            this.Switch.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Switch.Name = "Switch";
            this.Switch.Size = new System.Drawing.Size(92, 30);
            this.Switch.TabIndex = 13;
            this.Switch.Text = "Switch";
            this.Switch.UseVisualStyleBackColor = true;
            this.Switch.Click += new System.EventHandler(this.Switch_Click);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(335, 1044);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 30);
            this.button1.TabIndex = 14;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(453, 1050);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "Period:";
            // 
            // label_p
            // 
            this.label_p.AutoSize = true;
            this.label_p.Location = new System.Drawing.Point(531, 1050);
            this.label_p.Name = "label_p";
            this.label_p.Size = new System.Drawing.Size(44, 18);
            this.label_p.TabIndex = 16;
            this.label_p.Text = "NULL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(600, 1050);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "粗略误差：";
            // 
            // perDev
            // 
            this.perDev.AutoSize = true;
            this.perDev.Location = new System.Drawing.Point(689, 1050);
            this.perDev.Name = "perDev";
            this.perDev.Size = new System.Drawing.Size(44, 18);
            this.perDev.TabIndex = 18;
            this.perDev.Text = "NULL";
            // 
            // Fm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1604, 1096);
            this.Controls.Add(this.perDev);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_p);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Switch);
            this.Controls.Add(this.General);
            this.Controls.Add(this.OpenBtn);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Fm1";
            this.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fo";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Fm1_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button OpenBtn;
        private System.Windows.Forms.Button General;
        private System.Windows.Forms.Button Switch;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_p;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label perDev;
    }
}

