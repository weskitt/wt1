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
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1416, 860);
            this.panel1.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // OpenBtn
            // 
            this.OpenBtn.AutoSize = true;
            this.OpenBtn.Location = new System.Drawing.Point(10, 870);
            this.OpenBtn.Margin = new System.Windows.Forms.Padding(5);
            this.OpenBtn.Name = "OpenBtn";
            this.OpenBtn.Size = new System.Drawing.Size(89, 25);
            this.OpenBtn.TabIndex = 11;
            this.OpenBtn.Text = "Open Wave";
            this.OpenBtn.UseVisualStyleBackColor = true;
            this.OpenBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // General
            // 
            this.General.AutoSize = true;
            this.General.Location = new System.Drawing.Point(201, 870);
            this.General.Margin = new System.Windows.Forms.Padding(5);
            this.General.Name = "General";
            this.General.Size = new System.Drawing.Size(87, 25);
            this.General.TabIndex = 12;
            this.General.Text = "General";
            this.General.UseVisualStyleBackColor = true;
            this.General.Click += new System.EventHandler(this.General_Click);
            // 
            // Switch
            // 
            this.Switch.AutoSize = true;
            this.Switch.Location = new System.Drawing.Point(109, 870);
            this.Switch.Margin = new System.Windows.Forms.Padding(5);
            this.Switch.Name = "Switch";
            this.Switch.Size = new System.Drawing.Size(82, 25);
            this.Switch.TabIndex = 13;
            this.Switch.Text = "Switch";
            this.Switch.UseVisualStyleBackColor = true;
            this.Switch.Click += new System.EventHandler(this.Switch_Click);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(298, 870);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 25);
            this.button1.TabIndex = 14;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(403, 875);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Period:";
            // 
            // label_p
            // 
            this.label_p.AutoSize = true;
            this.label_p.Location = new System.Drawing.Point(472, 875);
            this.label_p.Name = "label_p";
            this.label_p.Size = new System.Drawing.Size(39, 15);
            this.label_p.TabIndex = 16;
            this.label_p.Text = "NULL";
            // 
            // Fm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1426, 913);
            this.Controls.Add(this.label_p);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Switch);
            this.Controls.Add(this.General);
            this.Controls.Add(this.OpenBtn);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Fm1";
            this.Padding = new System.Windows.Forms.Padding(5);
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
    }
}

