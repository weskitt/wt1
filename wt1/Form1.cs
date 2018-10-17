using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using MathNet;

namespace wt1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Width = this.Width;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Green);
            SolidBrush bb = new SolidBrush(Color.Black);

            Rectangle rect = new Rectangle(0, 0, panel1.Width, panel1.Height);

            g.FillRectangle(bb, rect);
            g.DrawLine(p, 0, rect.Height / 2, rect.Width, rect.Height / 2);
        }

        private void skinTrackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = skinTrackBar1.Value.ToString();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            skinTrackBar1.Value = skinTrackBar1.Maximum/2;
            label1.Text = skinTrackBar1.Value.ToString();
        }
    }
}
